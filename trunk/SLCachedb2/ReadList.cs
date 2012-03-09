using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLCachedb2
{
    class ReadList
    {
        public string[] aUUIDList;
        public ReadList(string ffile)
        {
            Dictionary<string, int> aDic = new Dictionary<string, int>();
            System.IO.StreamReader file = new System.IO.StreamReader(ffile);
            string line;
            Boolean MyPro = false;
            UUID UUIDParsed = UUID.Zero;
            while ((line = file.ReadLine()) != null)
            {
                string[] aLine = line.Split();
                if (!MyPro && aLine.Length > 1)

                    if (aLine[0] == "MyProxy" ||
                        aLine[0] == "AgentID" ||
                        aLine[0] == "Monitoring" ||
                        ((aLine[0] == "Av.") && (aLine[1] == "anim")))
                              MyPro = true;
                if (MyPro)
                    if (!(aLine[0] == "Av.") || !(aLine[aLine.Length - 1] == "Unknown"))
                        continue;
                
                for (int i = 0; i < aLine.Length; ++i)
                {
                    if (aLine[i].Length == 36)
                    {
                            if (UUID.TryParse(aLine[i], out UUIDParsed))
                            {
                                if (!aDic.ContainsKey(aLine[i]))
                                    aDic.Add(UUIDParsed.ToString(), 0);
                                break;
                            }
                    }
                }

            }
            file.Close();
            aUUIDList = aDic.Keys.ToArray();
        }
    }
}
