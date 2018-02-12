using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class StartUpActions
    {
        private Constants _constants = new Constants();
        private String _inputBoxString = "Enter your password:";
        private String _convertedPasswd;

        public CryptoOperations bce = new CryptoOperations();
        public SecretManager secretManager = new SecretManager();
        public String convertedPwd { get; }
        public String StartWithPasswordFromInputBox()
        {
            if (!_constants.passwordFileExists)
            {
                _inputBoxString = "Enter your new password:";
            }
            string input = Microsoft.VisualBasic.Interaction.InputBox(_inputBoxString, "Let's get started!", "here", -1, -1);
            PasswordConverter paswdConverter = new PasswordConverter(input);
            _convertedPasswd = paswdConverter.ConvertPwdTo16Bytes();
            Console.WriteLine("Password: {0} ", _convertedPasswd);
            if (_constants.passwordFileExists)
            {
                // decrypt
               
            }
            else
            {
                // we're done
                Console.WriteLine("We're done!");
            }
            return _convertedPasswd;
        }


    }
}
