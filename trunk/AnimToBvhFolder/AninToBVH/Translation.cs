
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
            mTranslation = new BVHTrans[21];

            mTranslation[0].mName = "hip";
            mTranslation[0].mOutName = "mPelvis";
            mTranslation[0].mIgnore = false;

            mTranslation[1].mName = "abdomen";
            mTranslation[1].mOutName = "mTorso";
            mTranslation[1].mIgnore = false;

            mTranslation[2].mName = "chest";
            mTranslation[2].mOutName = "mChest";
            mTranslation[2].mIgnore = false;

            mTranslation[3].mName = "neckDummy";
            mTranslation[3].mOutName = "";
            mTranslation[3].mIgnore = true;

            mTranslation[4].mName = "neck";
            mTranslation[4].mOutName = "mNeck";
            mTranslation[4].mIgnore = false;

            mTranslation[5].mName = "head";
            mTranslation[5].mOutName = "mHead";
            mTranslation[5].mIgnore = false;

            mTranslation[6].mName = "figureHair";
            mTranslation[6].mOutName = "";
            mTranslation[6].mIgnore = true;

            mTranslation[7].mName = "lCollar";
            mTranslation[7].mOutName = "mCollarLeft";
            mTranslation[7].mIgnore = false;

            mTranslation[8].mName = "lShldr";
            mTranslation[8].mOutName = "mShoulderLeft";
            mTranslation[8].mIgnore = false;

            mTranslation[9].mName = "lForeArm";
            mTranslation[9].mOutName = "mElbowLeft";
            mTranslation[9].mIgnore = false;

            mTranslation[10].mName = "lHand";
            mTranslation[10].mOutName = "mWristLeft";
            mTranslation[10].mIgnore = false;

            mTranslation[11].mName = "rCollar";
            mTranslation[11].mOutName = "mCollarRight";
            mTranslation[11].mIgnore = false;

            mTranslation[12].mName = "rShldr";
            mTranslation[12].mOutName = "mShoulderRight";
            mTranslation[12].mIgnore = false;

            mTranslation[13].mName = "rForeArm";
            mTranslation[13].mOutName = "mElbowRight";
            mTranslation[13].mIgnore = false;

            mTranslation[14].mName = "rHand";
            mTranslation[14].mOutName = "mWristRight";
            mTranslation[14].mIgnore = false;

            mTranslation[15].mName = "lThigh";
            mTranslation[15].mOutName = "mHipLeft";
            mTranslation[15].mIgnore = false;

            mTranslation[16].mName = "lShin";
            mTranslation[16].mOutName = "mKneeLeft";
            mTranslation[16].mIgnore = false;

            mTranslation[17].mName = "lFoot";
            mTranslation[17].mOutName = "mAnkleLeft";
            mTranslation[17].mIgnore = false;

            mTranslation[18].mName = "rThigh";
            mTranslation[18].mOutName = "mHipRight";
            mTranslation[18].mIgnore = false;

            mTranslation[19].mName = "rShin";
            mTranslation[19].mOutName = "mKneeRight";
            mTranslation[19].mIgnore = false;

            mTranslation[20].mName = "rFoot";
            mTranslation[20].mOutName = "mAnkleRight";
            mTranslation[20].mIgnore = false;
        }

        public struct BVHTrans
        {
            public string mName;
            public string mOutName;
            public bool mIgnore;
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
