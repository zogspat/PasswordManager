using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class StartUpActions
    {
        private Constants _constants = new Constants();
        private String _convertedPasswd;

        public CryptoOperations bce = new CryptoOperations();
        public DatabaseActions databaseActions = new DatabaseActions();
        public String StartWithPasswordFromInputBox(String inputPasswd)
        {
            if (!_constants.databaseExists)
            {
                Console.WriteLine("Database doesn't exist....");
                SQLiteConnection.CreateFile(_constants.databaseFile);
                databaseActions.FirstRun(_constants.databaseFile);
            }
            //string input = Microsoft.VisualBasic.Interaction.InputBox(_inputBoxString, "Let's get started!", "here", -1, -1);
            PasswordConverter paswdConverter = new PasswordConverter(inputPasswd);
            _convertedPasswd = paswdConverter.ConvertPwdTo16Bytes();
            Console.WriteLine("Password: {0} ", _convertedPasswd);
            if (_constants.databaseExists)
            {
                // decrypt
                // NOT FIRING FOR SOME REASON....
                int recCount = databaseActions.GetCount(_constants.databaseFile);
                Console.WriteLine("database has {0} elements", recCount);
               
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
