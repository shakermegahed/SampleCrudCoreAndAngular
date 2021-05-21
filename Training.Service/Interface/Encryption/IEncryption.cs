using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Service.Interface
{
    public interface IEncryption
    {
        string EncryptString(string text);
        string DecryptString(string cipherText);
        string ConvertStringToHex(string input);
        string ConvertHexToString(string hexInput);
        public string Zip(string Str);
        public string UnZip(string Byte);
    }
}
