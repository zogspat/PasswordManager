using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IRecordManipulator
{
    String ConvertSecretToString(SecretThing inputSecret);
    SecretThing ConvertStringToSecret(String inputString);
}
public class RecordManipulator : IRecordManipulator
{
    public String ConvertSecretToString(SecretThing inputSecret)
    {
        String resultString = inputScret.
    }
    public SecretThing ConvertStringToSecret(String inputString)
    {

    }
}
