using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

namespace IKaan.Web.Core.Config
{
    public class AESManager
    {
        private static readonly string AesKey = "01234567890123456789012345678901";
        private static readonly string Key128 = AesKey.Substring(0, 128 / 8);
        private static readonly string Key256 = AesKey.Substring(0, 256 / 8);


        //AES_256 암호화
        public String Encrypt(String KeyText)
        {
            RijndaelManaged aes = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = Encoding.UTF8.GetBytes(AesKey),
                IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var StrCrypto = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(KeyText);
                    
                    StrCrypto.Write(xXml, 0, xXml.Length);
                    StrCrypto.Close();
                }

                xBuff = ms.ToArray();
            }

            String Output = Convert.ToBase64String(xBuff);
            return Output;
        }
        
        //AES_256 복호화
        public String Decrypt(String KeyText)
        {
            RijndaelManaged aes = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = Encoding.UTF8.GetBytes(AesKey),
                IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var decrypt = aes.CreateDecryptor();
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var StrCrypto = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(KeyText);
                    StrCrypto.Write(xXml, 0, xXml.Length);
                    StrCrypto.Close();
                }
                
                xBuff = ms.ToArray();
                
            }
            
            String Output = Encoding.UTF8.GetString(xBuff);
            return Output;
        }
    }
}