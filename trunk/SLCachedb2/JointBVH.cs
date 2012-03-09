using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SLCachedb2
{
    public class JointBVH
    {
        public BVHJoint[]   mJoints;
        public Quaternion   mFrameMatrix;
        public Quaternion   mOffsetMatrix;
        public string[]     wOrder;

        public JointBVH(int kCount)
        {
            wOrder = new string[19] 
               {
                "XZY","XZY","XZY","XZY","XZY","YZX","ZYX","YZX","ZYX",
                "YZX","ZYX","YZX","ZYX","XZY","XZY","XYZ","XZY","XZY",
                "XYZ"
               };
            mFrameMatrix = new Quaternion((float)0.5, (float)0.5, (float)0.5, (float)0.5);
            mOffsetMatrix = new Quaternion((float)0, (float)0, (float)0, (float)1);
            mJoints = new BVHJoint[19];
            for (int iter = 0; iter < 19; iter++)
            {
                BVHJoint joint = readJoint(iter, kCount);
                mJoints[iter] = joint;
            }
        }
        public BVHJoint readJoint(int iit, int kCount)
        {
            BVHJointKey [] positions;
            BVHJoint pJoint = new BVHJoint();
            pJoint.mOrder = wOrder[iit];
            positions = readkeys(iit, kCount);
            pJoint.mPosRotKeys  = positions;
            return pJoint;
        }
        public BVHJointKey[] readkeys(int iit,int kCount) 
        {
            BVHJointKey[] m_keys = new BVHJointKey[kCount];
            for (int j = 0; j < kCount; j++)
            {
                BVHJointKey pJKey = new BVHJointKey();
                pJKey.mPos.X  = 0;
                if (iit == 0) pJKey.mPos.Y  = (float)43.5285;
                else          pJKey.mPos.Y  = 0;
                pJKey.mPos.Z  = 0;
                pJKey.mRot.X  = 0;
                pJKey.mRot.Y  = 0;
                pJKey.mRot.Z  = 0;
                m_keys[j] = pJKey;
            }
            return m_keys;

        }
        public struct BVHJoint
        {
            public string mName;
            public string mOutName;
            public string mOrder;
            public int mIndent;
            public BVHJointKey[] mPosRotKeys;
        }
        public struct BVHJointKey
        {
            public Vector3  mPos;
            public Vector3  mRot;
            public bool mIgnorePos;
            public bool mIgnoreRot;
        }
    }

    enum Order
    {
        XYZ = 0,
        YZX = 1,
        ZXY = 2,
        XZY = 3,
        YXZ = 4,
        ZYX = 5
    };

   
}
