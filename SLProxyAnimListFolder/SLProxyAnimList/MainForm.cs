/*
 * AnimList.
 * This source is a modification of the original MyNewProxy (Copyright Mockba the Borg)
 * 
 * 
 * 
 * All rights reserved.  
 *  
 * - Redistribution and use in source and binary forms, with or without   
 *   modification, are permitted provided that the following conditions are met:  
 *  
 * - Redistributions of source code must retain the above copyright notice, this  
 *   list of conditions and the following disclaimer.  
 * - Neither the name of Mockba the Borg nor the names of his contributors may  
 *   be used to endorse or promote products derived from this software without  
 *   specific prior written permission.  
 *   
 *  
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"   
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE   
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE   
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE   
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR   
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF   
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS   
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN   
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)   
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE   
 * POSSIBILITY OF SUCH DAMAGE.  
 */



using GridProxy;
using Nwc.XmlRpc;
using OpenMetaverse;
using OpenMetaverse.Assets;
using OpenMetaverse.Imaging;
using OpenMetaverse.Packets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace AnimList
{
    public partial class MainForm : Form
    {
        // 
        private string _progname = "AnimList";
        private string _version = "1.20";
        private string _libopenmv = "30913";
        private ProxyFrame frame;
        private Proxy proxy;
        private Boolean loggedin = false;
        private uint mylocalid = 0;  

        private UUID monitored = UUID.Zero;

        // Dictionaries for working with Avatars  
        private Dictionary<uint, UUID> AvatarIDtoUUID = new Dictionary<uint, UUID>();
        private Dictionary<UUID, uint> AvatarUUIDtoID = new Dictionary<UUID, uint>();
        private Dictionary<string, UUID> AvatarNameToUUID = new Dictionary<string, UUID>();
        private Dictionary<UUID, string> AvatarUUIDToName = new Dictionary<UUID, string>();
        private Dictionary<UUID, AvatarAppearancePacket> Appearances = new Dictionary<UUID, AvatarAppearancePacket>();

        private Dictionary<uint, Avatar> Avatars = new Dictionary<uint, Avatar>();


        // Other dictionaries (for Animation)  
        private Dictionary<UUID, string> KeyToAnim = new Dictionary<UUID, string>();
        private Dictionary<UUID, string> animFound = new Dictionary<UUID, string>();

        // Variables for the anim

        StringBuilder llaa = new StringBuilder();
        private string llaaName;
        private string NL = "\r\n";
        private int animRead = 0;

        // Base path for storing files (MUST NOT contain spaces... for now, and MUST exist)
        // Right now it points to the local folder as default.
        static string sepChar = System.IO.Path.DirectorySeparatorChar.ToString();
        private string basepath = AppDomain.CurrentDomain.BaseDirectory;


        // Main Program
        public MainForm()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            InitializeComponent();

            this.frame = new ProxyFrame(Environment.GetCommandLineArgs());
            this.proxy = this.frame.proxy;
            
            
            // build the table of login response delegates
            InitializeLoginDelegates();

            // build the table of packet delegates
            InitializePacketDelegates();

            // build the table of /command delegates
            InitializeCommandDelegates();

            // sets the window title
            this.Text = _progname + " v" + _version;
            // sets the initial console text (welcome text)
            SayToUser(_progname + " v" + _version + " initialized.");
            SayToUser("Built against LibOpenMetaverse v" + _libopenmv + ".");
            SayToUser("Connecting to " + this.proxy.proxyConfig.remoteLoginUri.ToString());
            SayToUser("");

            StatusSetMsg("Not logged in.");

            // Starts the proxy
            this.proxy.Start();
        }

        #region Login Delegates

        // Creates the entry points for dealing with login requests
        private void InitializeLoginDelegates()
        {
            this.proxy.AddLoginRequestDelegate(new XmlRpcRequestDelegate(this.MyLoginRequest));
            this.proxy.AddLoginResponseDelegate(new XmlRpcResponseDelegate(this.MyLoginResponse));
        }

        // LoginRequest: tell the user about login process starting
        private void MyLoginRequest(object sender, XmlRpcRequestEventArgs request)
        {
            SayToUser("Sending login request to server.");
            StatusSetMsg("Logging in...");
        }

        // LoginResponse: dump a login response to the console
        private void MyLoginResponse(XmlRpcResponse response)
        {
            string firstname = "Un";
            string lastname = "Known";
            string myname;

            LoginResponseData responsedata = new LoginResponseData();
            responsedata.Parse((Hashtable)response.Value);
            firstname = responsedata.FirstName;
            lastname = responsedata.LastName;

            firstname = firstname.Trim('"');
            myname = firstname + " " + lastname;

            SayToUser("My name is     : " + myname);
            SayToUser("AgentID        : " + this.frame.AgentID);
            SayToUser("SessionID      : " + this.frame.SessionID);
            SayToUser("SecureSessionID: " + this.frame.SecureSessionID);
            SayToUser("InventoryRoot  : " + this.frame.InventoryRoot);
            SayToUser("Logged in.");
            SayToUser("");

            StatusSetName(myname);
            StatusSetUUID(this.frame.AgentID.ToString());
//            skeleton = responsedata.InventorySkeleton;
            loggedin = true;
            StatusSetMsg("Logged in.");
        }

        #endregion

        #region Packet Delegates

        // Creates the entry points for dealing with received/transmitted packets
        private void InitializePacketDelegates()
        {
            // outbound packets
            proxy.AddDelegate(PacketType.AgentAnimation, Direction.Outgoing, new PacketDelegate(ProcessAgentAnimation));
            // inbound packets
            proxy.AddDelegate(PacketType.ObjectProperties, Direction.Incoming, new PacketDelegate(ProcessObjectProperties));
            proxy.AddDelegate(PacketType.ObjectUpdate, Direction.Incoming, new PacketDelegate(ProcessObjectUpdate));
            proxy.AddDelegate(PacketType.ObjectPropertiesFamily, Direction.Incoming, new PacketDelegate(ProcessObjectPropertiesFamily));
            proxy.AddDelegate(PacketType.KillObject, Direction.Incoming, new PacketDelegate(ProcessKillObject));
            proxy.AddDelegate(PacketType.LogoutReply, Direction.Incoming, new PacketDelegate(ProcessLogoutReply));
            proxy.AddDelegate(PacketType.TeleportStart, Direction.Incoming, new PacketDelegate(ProcessTeleportStart));
            proxy.AddDelegate(PacketType.TeleportProgress, Direction.Incoming, new PacketDelegate(ProcessTeleportProgress));
            proxy.AddDelegate(PacketType.CompletePingCheck, Direction.Incoming, new PacketDelegate(ProcessCompletePingCheck));
            proxy.AddDelegate(PacketType.AvatarAnimation, Direction.Incoming, new PacketDelegate(ProcessAvatarAnimation));
        }
        // Processes object properties packets  
        private Packet ProcessObjectProperties(Packet packet, IPEndPoint endpoint)
        {
            ObjectPropertiesPacket properties = (ObjectPropertiesPacket)packet;
            ObjectPropertiesPacket.ObjectDataBlock[] blocks = properties.ObjectData;

            for (int i = 0; i < blocks.Length; i++)
            {
                ObjectPropertiesPacket.ObjectDataBlock block = blocks[i];

                uint localid = 0;
                if (AvatarUUIDtoID.TryGetValue(block.ObjectID, out localid))
                {
                    SayToUser(string.Format("{0}: {1}", block.ObjectID, Utils.BytesToString(block.Name)));
                }
            }

            return packet;
        }
        // Processes object update packets (Avatars and Objects entering drawing distance)  
        private Packet ProcessObjectUpdate(Packet packet, IPEndPoint endpoint)
        {
                ObjectUpdatePacket update = (ObjectUpdatePacket)packet;

                for (int b = 0; b < update.ObjectData.Length; b++)
                {
                    ObjectUpdatePacket.ObjectDataBlock block = update.ObjectData[b];

                    ObjectMovementUpdate objectupdate = new ObjectMovementUpdate();
                    NameValue[] nameValues;
                    string firstname = "";
                    string lastname = "";
                    PCode pcode = (PCode)block.PCode;

                    #region NameValue parsing

                    string nameValue = Utils.BytesToString(block.NameValue);
                    if (nameValue.Length > 0)
                    {
                        string[] lines = nameValue.Split('\n');
                        nameValues = new NameValue[lines.Length];

                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (!String.IsNullOrEmpty(lines[i]))
                            {
                                NameValue nv = new NameValue(lines[i]);
                                if (nv.Name == "FirstName") firstname = nv.Value.ToString();
                                if (nv.Name == "LastName") lastname = nv.Value.ToString();
                                nameValues[i] = nv;
                            }
                        }
                    }
                    else
                    {
                        nameValues = new NameValue[0];
                    }

                    #endregion NameValue parsing

                   #region Decode Object (primitive) parameters
                    Primitive.ConstructionData data = new Primitive.ConstructionData();
                    data.State = block.State;
                    data.Material = (Material)block.Material;
                    data.PathCurve = (PathCurve)block.PathCurve;
                    data.profileCurve = block.ProfileCurve;
                    data.PathBegin = Primitive.UnpackBeginCut(block.PathBegin);
                    data.PathEnd = Primitive.UnpackEndCut(block.PathEnd);
                    data.PathScaleX = Primitive.UnpackPathScale(block.PathScaleX);
                    data.PathScaleY = Primitive.UnpackPathScale(block.PathScaleY);
                    data.PathShearX = Primitive.UnpackPathShear((sbyte)block.PathShearX);
                    data.PathShearY = Primitive.UnpackPathShear((sbyte)block.PathShearY);
                    data.PathTwist = Primitive.UnpackPathTwist(block.PathTwist);
                    data.PathTwistBegin = Primitive.UnpackPathTwist(block.PathTwistBegin);
                    data.PathRadiusOffset = Primitive.UnpackPathTwist(block.PathRadiusOffset);
                    data.PathTaperX = Primitive.UnpackPathTaper(block.PathTaperX);
                    data.PathTaperY = Primitive.UnpackPathTaper(block.PathTaperY);
                    data.PathRevolutions = Primitive.UnpackPathRevolutions(block.PathRevolutions);
                    data.PathSkew = Primitive.UnpackPathTwist(block.PathSkew);
                    data.ProfileBegin = Primitive.UnpackBeginCut(block.ProfileBegin);
                    data.ProfileEnd = Primitive.UnpackEndCut(block.ProfileEnd);
                    data.ProfileHollow = Primitive.UnpackProfileHollow(block.ProfileHollow);
                    data.PCode = pcode;
                    #endregion

                    #region Decode Additional packed parameters in ObjectData
                    int pos = 0;
                    switch (block.ObjectData.Length)
                    {
                        case 76:
                            // Collision normal for avatar  
                            objectupdate.CollisionPlane = new Vector4(block.ObjectData, pos);
                            pos += 16;
                            goto case 60;

                        case 60:
                            // Position  
                            objectupdate.Position = new Vector3(block.ObjectData, pos);
                            pos += 12;
                            // Velocity  
                            objectupdate.Velocity = new Vector3(block.ObjectData, pos);
                            pos += 12;
                            // Acceleration  
                            objectupdate.Acceleration = new Vector3(block.ObjectData, pos);
                            pos += 12;
                            // Rotation (theta)  
                            objectupdate.Rotation = new Quaternion(block.ObjectData, pos, true);
                            pos += 12;
                            // Angular velocity (omega)  
                            objectupdate.AngularVelocity = new Vector3(block.ObjectData, pos);
                            pos += 12;
                            break;

                        case 48:
                            // Collision normal for avatar  
                            objectupdate.CollisionPlane = new Vector4(block.ObjectData, pos);
                            pos += 16;
                            goto case 32;

                        case 32:
                            // The data is an array of unsigned shorts  

                            // Position  
                            objectupdate.Position = new Vector3(
                                Utils.UInt16ToFloat(block.ObjectData, pos, -0.5f * 256.0f, 1.5f * 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 2, -0.5f * 256.0f, 1.5f * 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 4, -256.0f, 3.0f * 256.0f));
                            pos += 6;
                            // Velocity  
                            objectupdate.Velocity = new Vector3(
                                Utils.UInt16ToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 4, -256.0f, 256.0f));
                            pos += 6;
                            // Acceleration  
                            objectupdate.Acceleration = new Vector3(
                                Utils.UInt16ToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 4, -256.0f, 256.0f));
                            pos += 6;
                            // Rotation (theta)  
                            objectupdate.Rotation = new Quaternion(
                                Utils.UInt16ToFloat(block.ObjectData, pos, -1.0f, 1.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 2, -1.0f, 1.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 4, -1.0f, 1.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 6, -1.0f, 1.0f));
                            pos += 8;
                            // Angular velocity (omega)  
                            objectupdate.AngularVelocity = new Vector3(
                                Utils.UInt16ToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f),
                                Utils.UInt16ToFloat(block.ObjectData, pos + 4, -256.0f, 256.0f));
                            pos += 6;
                            break;

                        case 16:
                            // The data is an array of single bytes (8-bit numbers)  

                            // Position  
                            objectupdate.Position = new Vector3(
                                Utils.ByteToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 1, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f));
                            pos += 3;
                            // Velocity  
                            objectupdate.Velocity = new Vector3(
                                Utils.ByteToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 1, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f));
                            pos += 3;
                            // Accleration  
                            objectupdate.Acceleration = new Vector3(
                                Utils.ByteToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 1, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f));
                            pos += 3;
                            // Rotation  
                            objectupdate.Rotation = new Quaternion(
                                Utils.ByteToFloat(block.ObjectData, pos, -1.0f, 1.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 1, -1.0f, 1.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 2, -1.0f, 1.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 3, -1.0f, 1.0f));
                            pos += 4;
                            // Angular Velocity  
                            objectupdate.AngularVelocity = new Vector3(
                                Utils.ByteToFloat(block.ObjectData, pos, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 1, -256.0f, 256.0f),
                                Utils.ByteToFloat(block.ObjectData, pos + 2, -256.0f, 256.0f));
                            pos += 3;
                            break;

                        default:
                            SayToUser("ERROR: Got an ObjectUpdate block with ObjectUpdate field length of " + block.ObjectData.Length);
                            continue;
                    }
                    #endregion

                    // Determine the object type and create the appropriate class  
                    switch (pcode)
                    {
                        #region Prim and Foliage
                        case PCode.Grass:
                        case PCode.Tree:
                        case PCode.NewTree:
                        case PCode.Prim:
                            break;
                        #endregion Prim and Foliage

                        #region Avatar
                        case PCode.Avatar:
                            if (block.FullID == this.frame.AgentID)
                            {
                                mylocalid = block.ID;
                                StatusSetLocalID(mylocalid.ToString());
                            }

                            #region Create an Avatar from the decoded data

                            Avatar avatar = new Avatar();
                            if (Avatars.ContainsKey(block.ID))
                            {
                                avatar = Avatars[block.ID];
                            }

                            objectupdate.Avatar = true;
                            // Textures  
                            objectupdate.Textures = new Primitive.TextureEntry(block.TextureEntry, 0,
                                block.TextureEntry.Length);

                            uint oldSeatID = avatar.ParentID;

                            avatar.ID = block.FullID;
                            avatar.LocalID = block.ID;
                            avatar.CollisionPlane = objectupdate.CollisionPlane;
                            avatar.Position = objectupdate.Position;
                            avatar.Velocity = objectupdate.Velocity;
                            avatar.Acceleration = objectupdate.Acceleration;
                            avatar.Rotation = objectupdate.Rotation;
                            avatar.AngularVelocity = objectupdate.AngularVelocity;
                            avatar.NameValues = nameValues;
                            avatar.PrimData = data;
                            if (block.Data.Length > 0) 
                                SayToUser("ERROR: Unexpected Data field for an avatar update, length " + block.Data.Length);
                            avatar.ParentID = block.ParentID;
                            avatar.RegionHandle = update.RegionData.RegionHandle;

                            // Textures  
                            avatar.Textures = objectupdate.Textures;

                            // Save the avatar  
                            lock (Avatars) Avatars[block.ID] = avatar;

                            // Fill up the translation dictionaries  
                            lock (AvatarIDtoUUID) AvatarIDtoUUID[block.ID] = block.FullID;
                            lock (AvatarUUIDtoID) AvatarUUIDtoID[block.FullID] = block.ID;
                            lock (AvatarUUIDToName) AvatarUUIDToName[block.FullID] = firstname + " " + lastname;
                            lock (AvatarNameToUUID) AvatarNameToUUID[firstname + " " + lastname] = block.FullID;

                            #endregion Create an Avatar from the decoded data

                            break;
                        #endregion Avatar

                        case PCode.ParticleSystem:
//                            ConsoleWriteLine("ERROR: Got a particle system update.");
//                            // TODO: Create a callback for particle updates  
                            break;

                        default:
                            SayToUser("ERROR: Got an ObjectUpdate block with an unrecognized PCode " + pcode.ToString());
                            break;
                    }
                }
            return packet;
        }
        // Processes object properties family packets  
        private Packet ProcessObjectPropertiesFamily(Packet packet, IPEndPoint endpoint)
        {
                ObjectPropertiesFamilyPacket properties = (ObjectPropertiesFamilyPacket)packet;
                ObjectPropertiesFamilyPacket.ObjectDataBlock block = properties.ObjectData;
                uint localid = 0;
                if (AvatarUUIDtoID.TryGetValue(block.ObjectID, out localid))
                {
                    SayToUser(string.Format("{0}: {1}", block.ObjectID, Utils.BytesToString(block.Name)));
                    SetSelectedAvatar(Utils.BytesToString(block.Name));
                }
            return packet;
        }
        // Processes kill object packets (Avatars and Objects leaving the drawing distance)  
        private Packet ProcessKillObject(Packet packet, IPEndPoint endpoint)
        {
                KillObjectPacket kill = (KillObjectPacket)packet;

                for (int i = 0; i < kill.ObjectData.Length; i++)
                {
                    if (AvatarIDtoUUID.ContainsKey(kill.ObjectData[i].ID)) // it's a known avatar  
                    {
                        UUID who = AvatarIDtoUUID[kill.ObjectData[i].ID];

                        // Clear some of the translation dictionaries  
                        lock (AvatarNameToUUID) AvatarNameToUUID.Remove(AvatarUUIDToName[who]);
                        lock (AvatarUUIDToName) AvatarUUIDToName.Remove(who);
                        lock (AvatarUUIDtoID) AvatarUUIDtoID.Remove(who);
                        lock (AvatarIDtoUUID) AvatarIDtoUUID.Remove(kill.ObjectData[i].ID);
                        // Out of sight, out of mind  
                        lock (Appearances) Appearances.Remove(who);
                        lock (Avatars) Avatars.Remove(kill.ObjectData[i].ID);
                    }
                }
            return packet;
        }
        // Processes the Logout packet
        private Packet ProcessLogoutReply(Packet packet, IPEndPoint endpoint)
        {
            this.loggedin = false;
            StatusSetName("");
            StatusSetUUID("");
            StatusSetLocalID("");
            StatusSetMsg("Not logged in.");
            HeartbeatReset();
            SayToUser("Logged out.");

            return packet;
        }

        // Processes the Ping Checks received
        private Packet ProcessCompletePingCheck(Packet packet, IPEndPoint endpoint)
        {
            HeartbeatToggle();

            return packet;
        }

        private Packet ProcessTeleportStart(Packet packet, IPEndPoint endpoint)
        {
            SayToUser("Teleporting...");
            return packet;
        }

        // Processes the Teleport Progress packets  
        private Packet ProcessTeleportProgress(Packet packet, IPEndPoint endpoint)
        {
            TeleportProgressPacket progress = (TeleportProgressPacket)packet;
            string msg = Utils.BytesToString(progress.Info.Message);

            if (msg == "Sending to destination.")
            {
                lock (AvatarIDtoUUID) AvatarIDtoUUID.Clear();
                lock (AvatarUUIDtoID) AvatarUUIDtoID.Clear();
                lock (AvatarNameToUUID) AvatarNameToUUID.Clear();
                lock (AvatarUUIDToName) AvatarUUIDToName.Clear();
                lock (Appearances) Appearances.Clear();
                lock (Avatars) Avatars.Clear();

                SayToUser("Dictionaries cleared for the new region.");
            }

            return packet;
        }
        // Processes the agent animation packet (or drops it of AO is active)  
        private Packet ProcessAgentAnimation(Packet packet, IPEndPoint endpoint)
        {
            AgentAnimationPacket animations = (AgentAnimationPacket)packet;

            if (monitored == this.frame.AgentID)
            {
                for (int i = 0; i < animations.AnimationList.Length; i++)
                {
                    string animname;
                    if (KeyToAnim.TryGetValue(animations.AnimationList[i].AnimID, out animname))
                    { }
                    else
                    {
                        animname = "Unknown";
                        if (!animFound.ContainsKey(animations.AnimationList[i].AnimID))
                        {
                            animFound.Add(animations.AnimationList[i].AnimID, string.Format("Ag. anim {0}: {1} {2} {3}", i, animations.AnimationList[i].AnimID, animname, animations.AnimationList[i].StartAnim));
                            SayToUser(string.Format("Ag. anim {0}: {1} {2} {3}", i, animations.AnimationList[i].AnimID, animname, animations.AnimationList[i].StartAnim));
                            animRead++;
                            textMonTot.Text = animRead.ToString();
                       }
                    }
                }
            }
            return animations;
        }

        // Processes the avatar animation packet (and overrides the animations if AO is active)  
        private Packet ProcessAvatarAnimation(Packet packet, IPEndPoint endpoint)
        {
            AvatarAnimationPacket animations = (AvatarAnimationPacket)packet;

            if (animations.Sender.ID == monitored)
            {
                for (int i = 0; i < animations.AnimationList.Length; i++)
                {
                    string animname;
                    if (KeyToAnim.TryGetValue(animations.AnimationList[i].AnimID, out animname))
                    { }
                    else
                    {
                        animname = "Unknown";
                        if (!animFound.ContainsKey(animations.AnimationList[i].AnimID))
                        {
                            animFound.Add(animations.AnimationList[i].AnimID, string.Format("Ag. anim {0}: {1} {2}", i, animations.AnimationList[i].AnimID, animname));
                            SayToUser(string.Format("Ag. anim {0}: {1} {2}", i, animations.AnimationList[i].AnimID, animname));
                            animRead++;
                            textMonTot.Text = animRead.ToString();
                        }
                    }
                }
            }
            return packet;  
        }
        #endregion

        #region Local Functions

        private void SayToUser(string text)
        {
            ConsoleWrite(text);
            ConsoleWrite("\r\n");
        }

        #endregion

        #region Interface Functions

        private void SetSelectedAvatar(string name)
        {
            if (this.SelectedAvatar.InvokeRequired)
            {
                this.SelectedAvatar.Invoke(new MethodInvoker(delegate
                {
                    this.SelectedAvatar.ResetText();
                    this.SelectedAvatar.AppendText(name);
                }));
            }
            else
            {
                this.SelectedAvatar.ResetText();
                this.SelectedAvatar.AppendText(name);
            }
        }  

        private void StatusSetName(string name)
        {
            if (this.StatusName.InvokeRequired)
            {
                this.StatusName.Invoke(new MethodInvoker(delegate
                {
                    this.StatusName.ResetText();
                    this.StatusName.AppendText(name);
                }));
            }
            else
            {
                this.StatusName.ResetText();
                this.StatusName.AppendText(name);
            }
        }

        private void StatusSetUUID(string uuid)
        {
            if (this.StatusUUID.InvokeRequired)
            {
                this.StatusUUID.Invoke(new MethodInvoker(delegate
                {
                    this.StatusUUID.ResetText();
                    this.StatusUUID.AppendText(uuid);
                }));
            }
            else
            {
                this.StatusUUID.ResetText();
                this.StatusUUID.AppendText(uuid);
            }
        }

        private void StatusSetLocalID(string id)
        {
            if (this.StatusLocalID.InvokeRequired)
            {
                this.StatusLocalID.Invoke(new MethodInvoker(delegate
                {
                    this.StatusLocalID.ResetText();
                    this.StatusLocalID.AppendText(id);
                }));
            }
            else
            {
                this.StatusLocalID.ResetText();
                this.StatusLocalID.AppendText(id);
            }
        }

        private void StatusSetMsg(string text)
        {
            if (this.StatusMsg.InvokeRequired)
            {
                this.StatusMsg.Invoke(new MethodInvoker(delegate
                {
                    this.StatusMsg.ResetText();
                    this.StatusMsg.AppendText(text);
                }));
            }
            else
            {
                this.StatusMsg.ResetText();
                this.StatusMsg.AppendText(text);
            }
        }

        private void ConsoleWrite(string text)
        {
            if (this.Console.InvokeRequired)
            {
                this.Console.Invoke(new MethodInvoker(delegate { this.Console.AppendText(text); }));
            }
            else
            {
                this.Console.AppendText(text);
            }
        }

        private void HeartbeatToggle()
        {
            if (this.HeartBeat.InvokeRequired)
            {
                this.HeartBeat.Invoke(new MethodInvoker(delegate
                {
                    if (this.HeartBeat.Checked)
                        this.HeartBeat.Checked = false;
                    else
                        this.HeartBeat.Checked = true;
                }
                ));
            }
        }

        private void HeartbeatReset()
        {
            if (this.HeartBeat.InvokeRequired)
            {
                this.HeartBeat.Invoke(new MethodInvoker(delegate
                {
                    this.HeartBeat.Checked = false;
                }));
            }
        }
                #region Command Delegates  
 
        // Creates the entry points for dealing with the typed commands  
        private void InitializeCommandDelegates()
        {
            frame.AddCommand("/monitore", new ProxyFrame.CommandDelegate(CmdMonitore));
        }
        // CmdMonitore: Monitores one avatar for animations  
        private void CmdMonitore(string[] words)
        {
            if (words.Length == 2)
            {
                if (words[1] == "help")
                {
                    SayToUser("This command activates the monitoring of an avatar.");
                    SayToUser("It will show the animations that the avatar is playing,");
                    SayToUser("so they can be added later to an AO system.");
                    SayToUser("This command can be used to monitor your own animations.");
                    SayToUser("Usage: /monitore <off | name>");
                    SayToUser("off = disables the monitoring.");
                    return;
                }
            }
            if (words.Length < 2 | words.Length > 3)
                SayToUser("Usage: /monitore <off | name>");
            else
            {
                if (words[1] == "off")
                {
                    monitored = UUID.Zero;
                    if (animFound.Count>0)
                    {
                        foreach(KeyValuePair<UUID, string> pair in animFound)
                        {
                            llaa.Append(pair.Value).Append(NL);
                        }
                        animFound.Clear();
                        animRead = 0;
                        this.textMonTot.Text = "0";
                        string name = llaaName;

                        SayToUser("Saving Anim List");
                        string dirname = basepath + name.Replace(" ", "_");
                        if (!Directory.Exists(dirname))
                            Directory.CreateDirectory(dirname);
                        string filename = dirname + sepChar + "Animation List.txt";
                        try { File.WriteAllText(filename, llaa.ToString()); }
                        catch (Exception e) { SayToUser(e.Message); }
                        llaa.Length=0;
                    }
                    SayToUser("Stopped monitoring.");
                    textMonitoring.Text = string.Empty;
                    bMonOff.Enabled = false;
                    bMonOn.Enabled = true;
                }
                else
                {
                    if (words.Length == 2)
                        SayToUser("Wrong name format.");
                    else
                    {
                        string name = words[1] + " " + words[2];
                        if (AvatarNameToUUID.TryGetValue(name, out monitored))
                        {
                            SayToUser("Monitoring " + name + "...");
                            llaaName = name;
                            textMonitoring.Text = name;
                            textMonTot.Text = "0";
                            bMonOn.Enabled = false;
                            bMonOff.Enabled = true;
                        }
                        else
                            SayToUser("Name not found.");
                    }
                }
            }
        }
                #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (llaa.Length > 0)
            {
                string command = "/monitore off";
                SayToUser(command);
                string[] words = command.Split(' ');
                ((GridProxy.ProxyFrame.CommandDelegate)this.frame.commandDelegates[words[0]])(words);
            }
            this.proxy.Stop();
        }
        #endregion

        private void bMonOn_Click(object sender, EventArgs e)
        {
            if (loggedin)
            {
                string command = "/monitore " + this.SelectedAvatar.Text;
                SayToUser(command);
                string[] words = command.Split(' ');
                ((GridProxy.ProxyFrame.CommandDelegate)this.frame.commandDelegates[words[0]])(words);
            }
            else
                SayToUser("Not logged in");
            }

        private void bMonOff_Click(object sender, EventArgs e)
        {
            if (loggedin)
            {
                string command = "/monitore off";
                SayToUser(command);
                string[] words = command.Split(' ');
                ((GridProxy.ProxyFrame.CommandDelegate)this.frame.commandDelegates[words[0]])(words);
            }
            else
                SayToUser("Not logged in");
            }
    }
}
