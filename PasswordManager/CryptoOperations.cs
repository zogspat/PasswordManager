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

        public SecretThing EncryptSecret(SecretThing plainTextSecret, String key)
        {
            SecretThing tempForEncryptedVals = new SecretThing();
            tempForEncryptedVals.title = AESEncryption(plainTextSecret.title, key, true);
            tempForEncryptedVals.url = AESEncryption(plainTextSecret.url, key, true);
            tempForEncryptedVals.comment = AESEncryption(plainTextSecret.comment, key, true);
            tempForEncryptedVals.password = AESEncryption(plainTextSecret.password, key, true);
            tempForEncryptedVals.privateKey = AESEncryption(plainTextSecret.privateKey, key, true);
            tempForEncryptedVals.secretId = plainTextSecret.secretId;
            return tempForEncryptedVals;
        }

        public SecretThing DecryptSecret(SecretThing encryptedSecret, String key)
        {
            SecretThing tempForDecryptedVals = new SecretThing();
            tempForDecryptedVals.title = AESDecryption(encryptedSecret.title, key, true);
            tempForDecryptedVals.url = AESDecryption(encryptedSecret.url, key, true);
            tempForDecryptedVals.comment = AESDecryption(encryptedSecret.comment, key, true);
            tempForDecryptedVals.password = AESDecryption(encryptedSecret.password, key, true);
            tempForDecryptedVals.privateKey = AESDecryption(encryptedSecret.privateKey, key, true);
            tempForDecryptedVals.secretId = encryptedSecret.secretId;
            return tempForDecryptedVals;
        }

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
