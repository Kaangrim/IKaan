using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace IKaan.Web.Core.Config
{
    public class CryptoManager
    {
        //sha 암호화시 사용할 키 
        private static string SHAFrontKey = "KAAN";
        private static string SHAEndKey = "GRIM";

        public static string EncryptAES256(string EncryptString)
        {
            if (!string.IsNullOrEmpty(EncryptString))
            {
                AESManager Aes256 = new AESManager();
                return Aes256.Encrypt(EncryptString);
            }
            else {
                return null;
            }
        }

        public static string DecryptAES256(string DecryptString)
        {
            AESManager Aes256 = new AESManager();
            return Aes256.Decrypt(DecryptString);
        }

        //SHA256 단방향 암호화
        public static string EncryptSHA256(string EncryptString)
        {
            //문자 암호화 키 적용
            EncryptString = SHAFrontKey + EncryptString + SHAEndKey;

            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(EncryptString));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        //SHA512 단방향 암호화
        public static string EncryptSHA512(string EncryptString)
        {
            //문자 암호화 키 적용
            EncryptString = SHAFrontKey + EncryptString + SHAEndKey;

            SHA512 sha512 = new SHA512Managed();
            byte[] hash512 = sha512.ComputeHash(Encoding.ASCII.GetBytes(EncryptString));

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
        public string EncryptToByte(string EncryptString)
        {
            byte[] bytes = Encoding.Default.GetBytes(EncryptString);
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
        public string DecryptFromByte(string EncryptString)
        {
            string[] src = EncryptString.Split('&');
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