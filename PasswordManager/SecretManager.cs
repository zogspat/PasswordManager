using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface ISecretManager
    {
        void AddSecret(SecretThing newSecret, String convertedPasswd);
        void ListSecrets(List <SecretThing> allSecrets);
         
    }
    public class SecretManager : ISecretManager
    {
        private Constants constants = new Constants();
        public void AddSecret(SecretThing newSecret, String convertedPasswd)
        {
            RecordManipulator converter = new RecordManipulator();
            String convertedRec = converter.ConvertSecretToString(newSecret);
            CryptoOperations encryption = new CryptoOperations();
            String encryptedRec = encryption.AESEncryption(convertedRec, convertedPasswd, true);
            if (constants.passwordFileExists)
            {
                AppendToFile(encryptedRec);
            }
            else
            {
                CreateNewFile(encryptedRec);
            }
        }

        public void ListSecrets(List<SecretThing> allSecrets)
        {

        }

        private void AppendToFile(String encryptedRec)
        {
            using (StreamWriter sw = File.AppendText(constants.passwordFile))
            {
                sw.WriteLine(encryptedRec);
            }
        }

        private void CreateNewFile(String encryptedRec)
        {
            using (StreamWriter sw = File.CreateText(constants.passwordFile))
            {
                sw.WriteLine(encryptedRec);
            }
        }
    }
}
