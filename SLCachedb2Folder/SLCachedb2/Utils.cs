/*
 * Copyright (c) 2008, openmetaverse.org
 * All rights reserved.
 *
 * - Redistribution and use in source and binary forms, with or without
 *   modification, are permitted provided that the following conditions are met:
 *
 * - Redistributions of source code must retain the above copyright notice, this
 *   list of conditions and the following disclaimer.
 * - Neither the name of the openmetaverse.org nor the names
 *   of its contributors may be used to endorse or promote products derived from
 *   this software without specific prior written permission.
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

using System;
using System.Text;

namespace SLCachedb2
{
    public static partial class Utils
    {
        /// <summary>
        /// Operating system
        /// </summary>
        public enum Platform
        {
            /// <summary>Unknown</summary>
            Unknown,
            /// <summary>Microsoft Windows</summary>
            Windows,
            /// <summary>Microsoft Windows CE</summary>
            WindowsCE,
            /// <summary>Linux</summary>
            Linux,
            /// <summary>Apple OSX</summary>
            OSX
        }

        /// <summary>
        /// Runtime platform
        /// </summary>
        public enum Runtime
        {
            /// <summary>.NET runtime</summary>
            Windows,
            /// <summary>Mono runtime: http://www.mono-project.com/</summary>
            Mono
        }

        public const float E = (float)Math.E;
        public const float LOG10E = 0.4342945f;
        public const float LOG2E = 1.442695f;
        public const float PI = (float)Math.PI;
        public const float TWO_PI = (float)(Math.PI * 2.0d);
        public const float PI_OVER_TWO = (float)(Math.PI / 2.0d);
        public const float PI_OVER_FOUR = (float)(Math.PI / 4.0d);
        /// <summary>Used for converting degrees to radians</summary>
        public const float DEG_TO_RAD = (float)(Math.PI / 180.0d);
        /// <summary>Used for converting radians to degrees</summary>
        public const float RAD_TO_DEG = (float)(180.0d / Math.PI);

        /// <summary>Provide a single instance of the CultureInfo class to
        /// help parsing in situations where the grid assumes an en-us 
        /// culture</summary>
        public static readonly System.Globalization.CultureInfo EnUsCulture =
            new System.Globalization.CultureInfo("en-us");

        /// <summary>UNIX epoch in DateTime format</summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1);

        public static readonly byte[] EmptyBytes = new byte[0];

        /// <summary>Provide a single instance of the MD5 class to avoid making
        /// duplicate copies and handle thread safety</summary>
        private static readonly System.Security.Cryptography.MD5 MD5Builder =
            new System.Security.Cryptography.MD5CryptoServiceProvider();

        /// <summary>Provide a single instance of the SHA-1 class to avoid
        /// making duplicate copies and handle thread safety</summary>
        private static readonly System.Security.Cryptography.SHA1 SHA1Builder =
            new System.Security.Cryptography.SHA1CryptoServiceProvider();

        private static readonly System.Security.Cryptography.SHA256 SHA256Builder =
            new System.Security.Cryptography.SHA256Managed();

        /// <summary>Provide a single instance of a random number generator
        /// to avoid making duplicate copies and handle thread safety</summary>
        private static readonly Random RNG = new Random();

        #region Math

        public static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }
        /// <summary>
        /// Compute the MD5 hash for a byte array
        /// </summary>
        /// <param name="data">Byte array to compute the hash for</param>
        /// <returns>MD5 hash of the input data</returns>
        public static byte[] MD5(byte[] data)
        {
            lock (MD5Builder)
                return MD5Builder.ComputeHash(data);
        }

        #endregion Math

        #region Platform

        /// <summary>
        /// Get the current running platform
        /// </summary>
        /// <returns>Enumeration of the current platform we are running on</returns>
        public static Platform GetRunningPlatform()
        {
            const string OSX_CHECK_FILE = "/Library/Extensions.kextcache";

            if (Environment.OSVersion.Platform == PlatformID.WinCE)
            {
                return Platform.WindowsCE;
            }
            else
            {
                int plat = (int)Environment.OSVersion.Platform;

                if ((plat != 4) && (plat != 128))
                {
                    return Platform.Windows;
                }
                else
                {
                    if (System.IO.File.Exists(OSX_CHECK_FILE))
                        return Platform.OSX;
                    else
                        return Platform.Linux;
                }
            }
        }

        /// <summary>
        /// Get the current running runtime
        /// </summary>
        /// <returns>Enumeration of the current runtime we are running on</returns>
        public static Runtime GetRunningRuntime()
        {
            Type t = Type.GetType("Mono.Runtime");
            if (t != null)
                return Runtime.Mono;
            else
                return Runtime.Windows;
        }

        #endregion Platform
    }
}
