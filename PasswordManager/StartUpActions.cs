using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class StartUpActions
    {
        private Constants _constants = new Constants();
        
        public CryptoOperations bce = new CryptoOperations();
        public DatabaseActions databaseActions = new DatabaseActions();
        public List<SecretThing> StartWithPasswordFromInputBox(String convertedPwd)
        {
            List<SecretThing> recsFromDb = new List<SecretThing>();
            if (!_constants.databaseExists)
            {
                Console.WriteLine("Database doesn't exist....");
                SQLiteConnection.CreateFile(_constants.databaseFile);
                databaseActions.FirstRun(_constants.databaseFile);
            }
            //string input = Microsoft.VisualBasic.Interaction.InputBox(_inputBoxString, "Let's get started!", "here", -1, -1);
                        if (_constants.databaseExists)
            // The contstants are set at start up, so if I re-use the .databaseExists on first run where the database
            // has just been created, it's still false. So...

            if (File.Exists(_constants.databaseFile))
            {
                // decrypt
                // NOT FIRING FOR SOME REASON....
                Console.WriteLine("up here");
                int recCount = databaseActions.GetCount(_constants.databaseFile);
                Console.WriteLine("database has {0} elements", recCount);
                SecretThing tmpThing = new SecretThing();
                tmpThing = databaseActions.ReadSingleResult(1, convertedPwd, _constants.databaseFile);
                Console.WriteLine("back from the database and... {0}", tmpThing.title);
               
            }
            else
            {
                // we're done
                Console.WriteLine("We're done!");
            }
            return recsFromDb;
        }


    }
}
