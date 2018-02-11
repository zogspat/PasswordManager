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
        public void StartWithPasswordFromInputBox()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your password", "Let's get started!", "here", -1, -1);
            PasswordConverter paswdConverter = new PasswordConverter(input);
            Console.WriteLine("Password: {0} ", paswdConverter.ConvertPwdTo16Bytes());
            if (_constants.passwordFileExists)
            {
                // decrypt
            }
            else
            {
                // we're done
                Console.WriteLine("We're done!");
            }
        }


    }
}
