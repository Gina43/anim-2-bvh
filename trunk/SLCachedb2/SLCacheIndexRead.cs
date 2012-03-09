using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SLCachedb2
{
    class SLCacheIndexRead
    {
        public recordIndex[]  SLCacheRecordIndex;

        public SLCacheIndexRead(byte[] cacheindexdata)
        {
            int IndexCount = (cacheindexdata.Length / 34);
            int i = 0;
            SLCacheRecordIndex = new recordIndex[IndexCount];

            // deserialize the number of record in the index.
            for (int iter = 0; iter < IndexCount; iter++)
            {
                recordIndex  inex = readIndex(cacheindexdata, ref i);
                SLCacheRecordIndex[iter] = inex;
            }
       
        }

        



        public recordIndex  readIndex(byte[] data, ref int i)
        {
            recordIndex pIndex = new recordIndex();
            if (!BitConverter.IsLittleEndian)
            {
                pIndex.dwOffset = Utils.BytesToUInt(EndianSwap(data, i, 4)); i += 4;
                pIndex.wMagic = Utils.BytesToUInt16(EndianSwap(data, i, 2)); i += 2;
                pIndex.wFlags = Utils.BytesToUInt16(EndianSwap(data, i, 2)); i += 2; 
                pIndex.time_t = Utils.BytesToUInt(EndianSwap(data, i, 4)); i += 4;
            }
            else
            {
                pIndex.dwOffset = Utils.BytesToUInt(data, i); i += 4;
                pIndex.wMagic = Utils.BytesToUInt16(data, i); i += 2; 
                pIndex.wFlags = Utils.BytesToUInt16(data, i); i += 2; 
                pIndex.time_t = Utils.BytesToUInt(data, i); i += 4;
            }
            pIndex.sUUID = UUIDfromLLUUID(data , ref i);
            if (!BitConverter.IsLittleEndian)
            {
                pIndex.wType = Utils.BytesToUInt16(EndianSwap(data, i, 2)); i += 2;
                pIndex.dwSize = Utils.BytesToUInt(EndianSwap(data, i, 4), 0); i += 4;
            }
            else
            {
                pIndex.wType = Utils.BytesToUInt16(data, i); i += 2;
                pIndex.dwSize = Utils.BytesToUInt(data, i); i += 4;
            }
            return pIndex;
        }

        private byte[] EndianSwap(byte[] arr, int offset, int len)
        {
            byte[] bendian = new byte[offset + len];
            Buffer.BlockCopy(arr, offset, bendian, 0, len);
            Array.Reverse(bendian);
            return bendian;
        }


        private string UUIDfromLLUUID(byte[] data, ref int i)
        {
            byte[] wstr = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

            UUID UUIDParsed = UUID.Zero;
            for (int j = 0; j < 16; j++)
            {
                wstr[j] =data[i+j];
            }
            i += 16;
            string hex = BitConverter.ToString(wstr).Replace("-", string.Empty);
            if (UUID.TryParse(hex, out UUIDParsed))
                return UUIDParsed.ToString();
            else
                return UUID.Zero.ToString();
        }


    }







        struct recordIndex
        {
            public uint dwOffset;
            public ushort wMagic;
            public ushort wFlags;
            public uint time_t;
            public string sUUID;
            public ushort wType;
            public uint   dwSize;
        }
    }

