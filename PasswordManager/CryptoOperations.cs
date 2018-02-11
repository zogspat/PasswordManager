using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface ICryptoOperations
    {
        string AESEncryption(string plain, string key, bool fips);
        string AESDecryption(string cipher, string key, bool fips);
    }
    class CryptoOperations: ICryptoOperations
    {

        Encoding _encoding = Encoding.ASCII;
        Pkcs7Padding pkcs = new Pkcs7Padding();
        public IBlockCipherPadding _padding;
        public string AESEncryption(string plain, string key, bool fips)
        {
            Console.WriteLine("AESEncryption: {0}; key: {1})", plain, key);
            _padding = pkcs;
            BCEngine bcEngine = new BCEngine(new AesEngine(), _encoding);
            bcEngine.SetPadding(_padding);
            //return bcEngine.Encrypt(plain, key);
            String resultStr = bcEngine.Encrypt(plain, key);
            Console.WriteLine("result length: {0}. String: {1}", resultStr.Length, resultStr);
            return resultStr;
        }

        public string AESDecryption(string cipher, string key, bool fips)
        {
            BCEngine bcEngine = new BCEngine(new AesEngine(), _encoding);
            bcEngine.SetPadding(_padding);
            return bcEngine.Decrypt(cipher, key);
        }

    }
}
