using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface IRecordManipulator
    {
        String ConvertSecretToString(SecretThing inputSecret);
        SecretThing ConvertStringToSecret(String inputString);
    }
    public class RecordManipulator : IRecordManipulator
    {// url comment password key
        public String ConvertSecretToString(SecretThing inputSecret)
        {
            String resultString = inputSecret.title + "||o||" + inputSecret.url + "||o||" + inputSecret.comment + "||o||" + inputSecret.password + "||o||" + inputSecret.privateKey;
            return resultString; 
        }
        public SecretThing ConvertStringToSecret(String inputString)
        {
            SecretThing recordSecret = new SecretThing();
            String[] words = inputString.Split(new string[] {"||o||"}, StringSplitOptions.None);
            recordSecret.title = words[0];
            recordSecret.url = words[1];
            recordSecret.comment = words[2];
            recordSecret.password = words[3];
            recordSecret.privateKey = words[4];
            return recordSecret;
        }
    }
}
