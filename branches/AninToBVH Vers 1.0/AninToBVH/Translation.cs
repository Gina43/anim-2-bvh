
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace AninToBVH
{
    class Translation
    {
        public BVHTrans[] mTranslation;
        public string mStatus;

        public Translation()
        {
            StatusCode vStatus = new StatusCode();
            mStatus = vStatus.ST_OK;
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\SecondLife\\app_settings\\anim.ini";
            if (!(File.Exists(filename)))
            {
                filename = Application.StartupPath + "\\anim.ini";
                if (!File.Exists(filename))
                {
                    MessageBox.Show("  File Anim.ini not found in " + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) +
                           "\\SecondLife\\app_settings" + System.Environment.NewLine +
                           "Copy a valid anim.ini file to the AnimToBVH.exe's folder then try again");
                    mStatus = vStatus.ST_NO_XLT_FILE;
                }
            }
            if (mStatus==vStatus.ST_OK)
             {
                using (StreamReader sr = new StreamReader(filename))
                {
                    String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    line = sr.ReadLine();
                    if (sr.EndOfStream)
                    {
                        mStatus = vStatus.ST_NO_XLT_FILE;
                    }
                    else
                    {
                        string[] stArr = null;
                        stArr = ConvertStrArr(line);

                        if (!(stArr[0] == "Translations"))
                        {
                            mStatus = vStatus.ST_NO_XLT_HEADER;
                        }
                        else
                        {
                            mTranslation = new BVHTrans[21];
                            int count=0;
                            while  (!sr.EndOfStream)
                            {
                                line = sr.ReadLine();
                                stArr = null;
                                stArr = ConvertStrArr(line);
                                if (stArr[0].Length < 1)
                                    continue;
                                if (stArr[0][0] == '[')
                                {
                                    if (stArr[0] == "[GLOBALS]")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        char[] warr = new char[stArr[0].Length - 2];
                                        for (int ju = 1; ju < stArr[0].Length - 1; ju++)
                                            warr[ju - 1] = stArr[0][ju];
                                        mTranslation[count].mName = new string(warr);
                                        count++;
                                        continue;
                                    }
                                }
                                if (stArr[0] == "ignore")
                                {
                                    mTranslation[count - 1].mIgnore = true;
                                    continue;
                                }

                                if (stArr[0] == "outname")
                                {
                                    mTranslation[count - 1].mOutName = stArr[2];
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }

        public struct BVHTrans
        {
            public string mName;
            public string mOutName;
            public bool mIgnore;
        }
        static string[] ConvertStrArr(string value)
        {
            string str = value.Trim();
            string[] strArr = null;
            string pattern = "\\s+";
            string replacement = " ";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(str, replacement);
            strArr = result.Split(' ');
            return strArr;
        }
    }
    public class StatusCode
    {
        public string ST_OK = "Ok";
        public string ST_EOF = "Premature end of file.";
        public string ST_NO_XLT_FILE = "Can't open translation file.";
        public string ST_NO_XLT_HEADER = "Can't read translation header.";
        public string ST_NO_XLT_NAME = "Can't read translation names.";
        public string ST_NO_XLT_IGNORE = "Can't read translation ignore value.";
        public string ST_NO_XLT_OUTNAME = "Can't read translation outname value.";
    }

}
