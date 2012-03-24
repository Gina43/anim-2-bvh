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

        #region BytesTo

        /// <summary>
        /// Convert the first four bytes starting at the given position in
        /// little endian ordering to a signed integer
        /// </summary>
        /// <param name="bytes">An array four bytes or longer</param>
        /// <param name="pos">Position to start reading the int from</param>
        /// <returns>A signed integer, will be zero if an int can't be read
        /// at the given position</returns>
        public static int BytesToInt(byte[] bytes, int pos)
        {
            if (bytes.Length < pos + 4) return 0;
            return (int)(bytes[pos + 0] + (bytes[pos + 1] << 8) + (bytes[pos + 2] << 16) + (bytes[pos + 3] << 24));
        }

        /// <summary>
        /// Convert the first four bytes of the given array in little endian
        /// ordering to a signed integer
        /// </summary>
        /// <param name="bytes">An array four bytes or longer</param>
        /// <returns>A signed integer, will be zero if the array contains
        /// less than four bytes</returns>
        public static int BytesToInt(byte[] bytes)
        {
            return BytesToInt(bytes, 0);
        }

        /// <summary>
        /// Convert the first two bytes starting at the given position in
        /// little endian ordering to an unsigned short
        /// </summary>
        /// <param name="bytes">Byte array containing the ushort</param>
        /// <param name="pos">Position to start reading the ushort from</param>
        /// <returns>An unsigned short, will be zero if a ushort can't be read
        /// at the given position</returns>
        public static ushort BytesToUInt16(byte[] bytes, int pos)
        {
            if (bytes.Length <= pos + 1) return 0;
            return (ushort)(bytes[pos] + (bytes[pos + 1] << 8));
        }

        /// <summary>
        /// Convert two bytes in little endian ordering to an unsigned short
        /// </summary>
        /// <param name="bytes">Byte array containing the ushort</param>
        /// <returns>An unsigned short, will be zero if a ushort can't be
        /// read</returns>
       public static ushort BytesToUInt16(byte[] bytes)
        {
            return BytesToUInt16(bytes, 0);
        }

        /// <summary>
        /// Convert the first four bytes starting at the given position in
        /// little endian ordering to an unsigned integer
        /// </summary>
        /// <param name="bytes">Byte array containing the uint</param>
        /// <param name="pos">Position to start reading the uint from</param>
        /// <returns>An unsigned integer, will be zero if a uint can't be read
        /// at the given position</returns>
        public static uint BytesToUInt(byte[] bytes, int pos)
        {
            if (bytes.Length < pos + 4) return 0;
            return (uint)(bytes[pos + 0] + (bytes[pos + 1] << 8) + (bytes[pos + 2] << 16) + (bytes[pos + 3] << 24));
        }

        /// <summary>
        /// Convert the first four bytes of the given array in little endian
        /// ordering to an unsigned integer
        /// </summary>
        /// <param name="bytes">An array four bytes or longer</param>
        /// <returns>An unsigned integer, will be zero if the array contains
        /// less than four bytes</returns>
        public static uint BytesToUInt(byte[] bytes)
        {
            return BytesToUInt(bytes, 0);
        }

        /// <summary>
        /// Convert four bytes in little endian ordering to a floating point
        /// value
        /// </summary>
        /// <param name="bytes">Byte array containing a little ending floating
        /// point value</param>
        /// <param name="pos">Starting position of the floating point value in
        /// the byte array</param>
        /// <returns>Single precision value</returns>
        public static float BytesToFloat(byte[] bytes, int pos)
        {
            if (!BitConverter.IsLittleEndian)
            {
                byte[] newBytes = new byte[4];
                Buffer.BlockCopy(bytes, pos, newBytes, 0, 4);
                Array.Reverse(newBytes, 0, 4);
                return BitConverter.ToSingle(newBytes, 0);
            }
            else
            {
                return BitConverter.ToSingle(bytes, pos);
            }
        }

        #endregion BytesTo


        #region Strings

        /// <summary>
        /// Convert a variable length UTF8 byte array to a string
        /// </summary>
        /// <param name="bytes">The UTF8 encoded byte array to convert</param>
        /// <returns>The decoded string</returns>
       public static string BytesToString(byte[] bytes)
        {
            if (bytes.Length > 0 && bytes[bytes.Length - 1] == 0x00)
                return UTF8Encoding.UTF8.GetString(bytes, 0, bytes.Length - 1);
            else
                return UTF8Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }


        #endregion Strings

        #region Packed Values

        public static float UInt16ToFloat(byte[] bytes, int pos, float lower, float upper)
        {
            ushort val = BytesToUInt16(bytes, pos);
            return UInt16ToFloat(val, lower, upper);
        }

        public static float UInt16ToFloat(ushort val, float lower, float upper)
        {
            const float ONE_OVER_U16_MAX = 1.0f / (float)UInt16.MaxValue;

            float fval = (float)val * ONE_OVER_U16_MAX;
            float delta = upper - lower;
            fval *= delta;
            fval += lower;

            // Make sure zeroes come through as zero
            float maxError = delta * ONE_OVER_U16_MAX;
            if (Math.Abs(fval) < maxError)
                fval = 0.0f;

            return fval;
        }
        #endregion Packed Values
    }
}
