using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface ISecretManager
    {
        void AddSecret(SecretThing newSecret);
        void ListSecrets(List <SecretThing> allSecrets);
         
    }
    public class SecretManager : ISecretManager
    {
        public void AddSecret(SecretThing newSecret)
        {
            // convert to a single string with |+| as separators
            CryptoOperations encryption = new CryptoOperations();
            String result = encryption.AESEncryption("input string lets make it a bit longer", "1234567890123456", true);
            Console.WriteLine("result: " + result);
            // encrypt the string
            // write the string as a new line in text file
            // update the interface.
        }

        public void ListSecrets(List<SecretThing> allSecrets)
        {

        }
    }
}
