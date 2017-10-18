using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//네임스페이스 추가
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace IKaan.Web.Core.Config
{
    public class CryptoManager
    {

        //IV(Initialization Vector)
        private static byte[] iv = { 11, 30, 56, 177, 201, 75, 98, 168 };
        //Key는 데이터를 암호화하고 복호화시에 사용
        private static byte[] key = { 27, 111, 125, 118, 234, 61, 14, 64, 105, 116, 188, 9, 100, 20, 138, 7, 31, 22, 215, 91, 241, 1, 254, 180 };

        //aesKey 암호화 복호화시 사용할 키 
        //private static string aesKey = "abcdefghijklmnopqrstuvwxyz123456";

        //암호화
        public static string EncryptTripleDES(string str)
        {
            //문자를 byte[]으로 변환
            byte[] str_in = Encoding.UTF8.GetBytes(str.ToCharArray());

            MemoryStream ms = new MemoryStream();
            TripleDESCryptoServiceProvider tcs = new TripleDESCryptoServiceProvider();

            //key,iv값을 기준으로 CreateEncryptor 메서드를 사용해 암호화
            CryptoStream cs = new CryptoStream(ms, tcs.CreateEncryptor(key, iv), CryptoStreamMode.Write);

            cs.Write(str_in, 0, str_in.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());

        }


        //복호화
        public static string DecryptTripleDES(string str)
        {
            //문자열을 byte[]로 변환
            byte[] str_in = Convert.FromBase64String(str);

            MemoryStream ms = new MemoryStream(str_in, 0, str_in.Length);
            TripleDESCryptoServiceProvider tcs = new TripleDESCryptoServiceProvider();

            //key,iv값을 기준으로 CreateDecryptor 메서드를 사용해 복호화
            CryptoStream cs = new CryptoStream(ms, tcs.CreateDecryptor(key, iv), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();

        }

        public static string EncSHA256(string str)
        {
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(str));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
        public static string EncSHA512(string str)
        {
            SHA512 sha512 = new SHA512Managed();
            byte[] hash512 = sha512.ComputeHash(Encoding.ASCII.GetBytes(str));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash512)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 문자열을 '&'로 겹합된 바이트 배열형태로 변환한다.
        /// </summary>
        /// <param name="src">대상문자열</param>
        /// <returns>바이트배열 문자열</returns>
        public string EncryptToByte(string src)
        {
            byte[] bytes = Encoding.Default.GetBytes(src);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append("&");
                }
                sb.Append(bytes[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// '&'로 겹합된 바이트 배열형태의 문자열을 문자로 변환한다.
        /// </summary>
        /// <param name="s">바이트배열 문자열</param>
        /// <returns>대상문자열</returns>
        public string DecryptFromByte(string s)
        {
            string[] src = s.Split('&');
            byte[] bytes = new byte[src.Length];

            for (int i = 0; i < src.Length; i++)
            {
                bytes[i] = Convert.ToByte(src[i]);
            }

            return Encoding.Default.GetString(bytes);
        }


        /// <summary>
        /// 바이트배열형태의 문자열을 디코딩한다.
        /// </summary>
        /// <param name="src">Euc-kr바이트배열형태의 문자열</param>
        /// <returns>UTF-8 문자열</returns>
        public string DecodeEucKr(string src)
        {
            StringBuilder decStr = new StringBuilder(src.Length / 2);
            char[] chArray = src.ToCharArray();

            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '+')
                {	// Space
                    decStr.Append(' ');
                }
                else if (chArray[i] == '%')
                {	// 2Byte Character
                    string hexStr1 = src.Substring(i, 3).Replace("%", "");
                    int hex1 = ConvertToHex(hexStr1);

                    if (hex1 < 0 || hex1 >= 128)
                    {
                        string hexStr2 = src.Substring(i + 3, 3).Replace("%", "");

                        byte[] charCode = new byte[2];
                        charCode[0] = Convert.ToByte(ConvertToHex(hexStr1));
                        charCode[1] = Convert.ToByte(ConvertToHex(hexStr2));

                        decStr.Append(Encoding.Default.GetString(charCode));

                        i += 5;
                    }
                    else
                    {
                        byte[] charCode = new byte[1];
                        charCode[0] = Convert.ToByte(hex1);

                        decStr.Append(Encoding.Default.GetString(charCode));

                        i += 2;
                    }
                }
                else
                {	// 1Byte Character
                    decStr.Append(chArray[i]);
                }
            }

            return decStr.ToString();
        }

        /// <summary>
        /// 문자열을 Hex형태의 정수값으로 변환한다.
        /// </summary>
        /// <param name="s">Hex문자열</param>
        /// <returns>Hex정수값</returns>
        public int ConvertToHex(string s)
        {
            int retVal = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == s.Length - 1)
                    retVal += ConvertToHex(s[i]);
                else
                    retVal = ConvertToHex(s[i]) * (16 * (s.Length - 1));
            }

            return retVal;
        }

        /// <summary>
        /// 문자를 Hex형태의 정수값으로 변환한다.
        /// </summary>
        /// <param name="c">Hex문자</param>
        /// <returns>Hex정수값</returns>
        public int ConvertToHex(char c)
        {
            int retVal = 0;
            switch (c)
            {
                case 'A':
                case 'a':
                    retVal = 10;
                    break;
                case 'B':
                case 'b':
                    retVal = 11;
                    break;
                case 'C':
                case 'c':
                    retVal = 12;
                    break;
                case 'D':
                case 'd':
                    retVal = 13;
                    break;
                case 'E':
                case 'e':
                    retVal = 14;
                    break;
                case 'F':
                case 'f':
                    retVal = 15;
                    break;
                default:
                    retVal = (char.IsDigit(c) ? Convert.ToInt32(c.ToString()) : 0);
                    break;
            }

            return retVal;
        }

    }
}