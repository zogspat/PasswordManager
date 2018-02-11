using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
  
    public interface IPasswordConverter
    {
        string ConvertPwdTo16Bytes();
    }

    class PasswordConverter : IPasswordConverter
    {
        private String _inputPasswd;
        public PasswordConverter(String inputStr)
        {
            _inputPasswd = inputStr;
        }
        public string ConvertPwdTo16Bytes()
        {
            String fullHashResult = getHashSha256(_inputPasswd);
            String base64Variant = Base64Encode(fullHashResult);
            return base64Variant.Substring(0, Math.Min(base64Variant.Length, 16));
        }

        private static string getHashSha256(string text)
        {
            // https://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
