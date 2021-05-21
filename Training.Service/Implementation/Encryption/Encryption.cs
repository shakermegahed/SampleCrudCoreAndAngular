using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Training.Service.Interface;

namespace Training.Service.Implementation
{
    public class Encryption : IEncryption
    {
        public  string Zip(string str)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    zip.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
                }
                return Convert.ToBase64String(ms.ToArray());
            }

            //var bytes = Encoding.UTF8.GetBytes(str);

            //using (var msi = new MemorsyStream(bytes))
            //using (var mso = new MemoryStream())
            //{
            //    using (var gs = new GZipStream(mso, CompressionMode.Compress))
            //    {
            //        //msi.CopyTo(gs);
            //        CopyTo(msi, gs);
            //    }
               
            //    // From byte array to string
            //    return System.Text.Encoding.UTF8.GetString(mso.ToArray(), 0, mso.ToArray().Length);
            //}
        }
        public  string UnZip(string bytes)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(bytes)))
            {
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress, true))
                {
                    using (BinaryReader reader = new BinaryReader(zip))
                    {
                        return Encoding.UTF8.GetString(reader.ReadBytes(bytes.Length));
                    }
                }
            }
            // From string to byte array
            //byte[] bytesArray = System.Text.Encoding.UTF8.GetBytes(bytes);

            //using (var msi = new MemoryStream(bytesArray))
            //using (var mso = new MemoryStream())
            //{
            //    using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            //    {
            //        //gs.CopyTo(mso);
            //        CopyTo(gs, mso);
            //    }

            //    return Encoding.UTF8.GetString(mso.ToArray());
            //}
        }
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        const string KeyString = "!!!!C8DF278CD5%^$#69B522E6951234";
        public string EncryptString(string text)
        {
            var key = Encoding.UTF8.GetBytes(KeyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
                        return ConvertStringToHex(Convert.ToBase64String(result));
                    }
                }
            }
        }
        public string DecryptString(string cipherText)
        {
            cipherText = ConvertHexToString(cipherText);
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);

            var key = Encoding.UTF8.GetBytes(KeyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        public string ConvertStringToHex(string input)
        {
            Byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
        public string ConvertHexToString(string hexInput)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
