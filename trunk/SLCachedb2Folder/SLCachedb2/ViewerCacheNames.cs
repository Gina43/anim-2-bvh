using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Gtk;

namespace SLCachedb2
{
    class ViewerCacheNames
    {
        public string[] aViewerP;
        public int[] aViewerT;
        public bool noOS;

        public ViewerCacheNames()
        {
            // Dictionary for path of cache files and cache type
            Dictionary<string, int> aDic = new Dictionary<string, int>();
            // class to test running SO and,  conseguently set the pathAppData and pathLocAppData
            OSinfoDet SSOO = new OSinfoDet();

            // noOS = true means SO non recognised
            noOS = SSOO.noOS;
            if (noOS == true)
                return;

            // SO depending directory separator character in the file path.
            string SC = System.IO.Path.DirectorySeparatorChar.ToString();
            // path where settings files are located
            string filename = SSOO.pathAppData + SC + "user_settings";
            // aV is populated with path of founds settings files
            string[] aV = Directory.GetFiles(filename, "settings*.xml");

            //
            string line;
            int ffoo;
            string cacheWpath;          // cache path 
            int cacheType;              // cache version
            string viewerType;          // default cache directory 
            for (int i = 0; i < aV.Length; ++i)
            {
                // we need the settings of viewers only
                if (aV[i].IndexOf("autocorrect")  > 0 | aV[i].IndexOf("crash") > 0)
                    continue;


                cacheWpath = "";
                viewerType = "";
                cacheType = 0;
                if (aV[i].IndexOf("settings.xml") > 0)   // Settings of Linden Second Life viewer
                {
                    //  directory of standard cache
                    if (SSOO.OStext != "Unix")
                        viewerType = "SecondLife";
                    else
                        viewerType = "cache";
                }
                else                                    // not linden viewer settings
                {
                    // directory of standard cache (viewerName + "viewer")
                    foreach (string vvww in Enum.GetNames(typeof(nameViewer)))
                    {
                        if (aV[i].IndexOf(vvww) > 0)
                        {
                            viewerType = vvww;
                            if (vvww != "firestorm")
                                viewerType += "viewer";
                        }
                    }
                }
                // Stream of each Settings file
                System.IO.StreamReader file =  new System.IO.StreamReader(aV[i]);

                ffoo = 0;
                while ((line = file.ReadLine()) != null)
                {
                    // search the cache location node. If there is not the node then default cache path is used
                    if (line.Trim() == "<key>CacheLocation</key>")
                    {
                        while ((line = file.ReadLine().Trim()) != "</map>")
                        {
                            // read the cache location value
                            if (line == "<key>Value</key>")
                            {
                                line = file.ReadLine().Trim();
                                string wrST = line.Substring(8, line.IndexOf("</string>") - 8);
                                if (wrST.Length > 2)
                                {
                                    cacheWpath = wrST;                  // cache is located in the CacheLocation Path (user setting)
                                }
                                ffoo++;
                                break;
                            }
                            if (ffoo > 1) break;            
                        }
                    }
                    else if (line.Trim() == "<key>LocalCacheVersion</key>")             //Cache version node
                    {
                        while ((line = file.ReadLine().Trim()) != "</map>")
                        {
                            // read the cache version no.
                            if (line == "<key>Value</key>")
                            {
                                line = file.ReadLine().Trim();
                                string wrTy = line.Substring(9, line.IndexOf("</integer>") - 9);
                                cacheType = Convert.ToInt32(wrTy);
                                ffoo++;
                                break;
                            }
                        }
                    }
                    if (ffoo > 1) break;
                }
                file.Close();
                if ((cacheWpath == "") && (viewerType != ""))               // Cache location not found, cache version found
                    cacheWpath = SSOO.pathLocAppData + SC + viewerType;     // means using default  path cache

                if (cacheWpath != "")                                       // Ok  path cache set
                {
                    //path cache and cache version added to dictionary
                    if (!aDic.ContainsKey(cacheWpath))
                        aDic.Add(cacheWpath,cacheType);
                }
            }
            // two array are generated from the dictionary
            aViewerP = aDic.Keys.ToArray();
            aViewerT = aDic.Values.ToArray();
        }
        public enum nameViewer
        {
            phoenix = 1,
            singularity = 2,
            firestorm = 3,
            imprudence = 4,
            coolvl = 5
        }
    }
}
