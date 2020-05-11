using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace serialPort_Bord { 
    class BytesArrayHelper
    {
        public static string ArrayToString(byte[] byt)
        {
            string s = "";
            for (int i = 0; i < byt.Length; i++)
            {
                s = s + "[" + i.ToString() + "]=" + byt[i].ToString() + ",";
            }
            return s;
        }

        public static byte[] copy(byte[] fromArray, int len)
        {
            byte[] tmp = new byte[len];
            for (int i = 0; i < len; i++)
                tmp[i] = fromArray[i];

            return tmp;
        }
        /// <summary>  
        /// 16进制转换BCD（解压BCD）  
        /// </summary>  
        /// <param name="AData"></param>  
        /// <returns></returns>  
        public static string ConvertTo(byte[] AData)
        {
            try
            {
                StringBuilder sb = new StringBuilder(AData.Length * 2);
                foreach (Byte b in AData)
                {
                    sb.Append(b >> 4);
                    sb.Append(b & 0x0f);
                }
                return sb.ToString();
            }
            catch { return null; }
        }
        /// <summary>
        /// byte[]转16进制格式string： new byte[]{ 0x30, 0x31}转成"3031":        
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;

            if (bytes != null)
            {

                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {

                    strB.Append(bytes[i].ToString("X2"));

                }

                hexString = strB.ToString();

            }
            return hexString;

        }
        /// <summary>
        /// byte[]转16进制格式string： new byte[]{ 0x30, 0x31}转成"3031":     默认10字节  固定  前面0  自动去掉    
        /// </summary>
        /// <param name="bytes"> </param> 
        /// <returns></returns>
        public static string ToMETERNOHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;

            if (bytes != null)
            {

                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < 4; i++)
                {

                    strB.Append(bytes[i].ToString("X2"));

                }

                hexString = strB.ToString();

            }
            return hexString.TrimStart('0');
        }

        /// <summary>
        /// 将Hex字符串转为bytes数组
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static byte[] HexStringToBytes(string hexStr)
        {
            if (string.IsNullOrEmpty(hexStr))
            {
                return new byte[0];
            }

            if (hexStr.StartsWith("0x"))
            {
                hexStr = hexStr.Remove(0, 2);
            }

            var count = hexStr.Length;

            if (count % 2 == 1)
            {
                throw new ArgumentException("Invalid length of bytes:" + count);
            }

            var byteCount = count / 2;
            var result = new byte[byteCount];
            for (int ii = 0; ii < byteCount; ++ii)
            {
                var tempBytes = Byte.Parse(hexStr.Substring(2 * ii, 2), System.Globalization.NumberStyles.HexNumber);
                result[ii] = tempBytes;
            }

            return result;
        }

        

        public string StrToHex(string str)
        {
            string strResult;
            byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(str);
            strResult = "";
            foreach (byte b in buffer)
            {
                strResult += b.ToString("X2");//X是16进制大写格式 
            }
            return strResult;
        }

        /// <summary>
        /// Uint32字节序转换
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static uint SwapUInt32(uint n)
        {
            return (uint)(((SwapUInt16((ushort)n) & 0xffff) << 0x10) |
                           (SwapUInt16((ushort)(n >> 0x10)) & 0xffff));
        }

        /// <summary>
        /// ushort字节序转换
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ushort SwapUInt16(ushort n)
        {
            return (ushort)(((n & 0xff) << 8) | ((n >> 8) & 0xff));
        }

    }
}
