using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace SLCachedb2
{
    class OSinfoDet
    {
        public string OStext;
        public string pathAppData;
        public string pathLocAppData;
        public bool noOS;
        public OSinfoDet()
        {
 

            OStext = GetOS();
            noOS = false;
            switch (OStext)
            {
                case "Mac":  
                    string userdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    int n = userdata.LastIndexOf('.');
                    pathAppData = userdata.Substring(0, n ) + "Library/Application Support/SecondLife";
                    pathLocAppData = userdata.Substring(0, n ) + "Library/Caches";
                    break;
                case "Unix":
                    pathAppData = appDataPath() + "secondlife";
                    pathLocAppData = pathAppData;
                    break;
                case "Win":
                    pathAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\SecondLife";
                    pathLocAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    break;
                case "Unknown":
                    noOS = true;
                    break;
            }
        }
        private string appDataPath()
        {
            string aPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            int n = aPath.LastIndexOf('.');
            return aPath.Substring(0, n+1);
        }
        public static string GetOS()
        {
            PlatformID platId = Environment.OSVersion.Platform;
            if (platId == PlatformID.Win32NT || platId == PlatformID.Win32Windows)
            {
                return "Win";
            }

            if (File.Exists("/System/Library/Frameworks/Cocoa.framework/Cocoa"))
            {
                return "Mac";
            }

            /*
             * .NET 1.x, under Mono, the UNIX code is 128. Under
             * .NET 2.x, Mono or MS, the UNIX code is 4
             */
            if (Environment.Version.Major == 1)
            {
                if ((int)platId == 128)
                {
                    return "Unix";
                }
            }
            else if ((int)platId == 4)
            {
                return "Unix";
            }

            return "Unknown";
        }
    }
}
