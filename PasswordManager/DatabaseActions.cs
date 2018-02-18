using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface IDatabaseActions
    {
        void FirstRun(String databaseFilePath);
        int GetCount(String databaseFilePath);
        SecretThing ReadSingleResult(int secretID, String convertedPwd, String databaseFilePath);
        void WriteSingleResult(SecretThing inputSecret, String convertedpwd, String databaseFilePath);
    }
    public class DatabaseActions : IDatabaseActions
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private CryptoOperations crypt = new CryptoOperations();

        public void FirstRun(String databaseFilePath)
        {
            // create the database:
            SQLiteConnection.CreateFile("databaseFilePath");
            SetConnection(databaseFilePath);
            // title url comment, password key
            string sql = "create table secrets (secretId integer primary key, title varchar(50), comment varchar(100), url varchar(100), password varchar(50), privateKey varchar(200))";
            ExecuteQuery(sql, databaseFilePath);
        }

        public int GetCount(String databaseFilePath)
        {
            SetConnection(databaseFilePath);
            string sql = "select count(*) from secrets";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            sql_con.Open();
            int countVal = Convert.ToInt32(command.ExecuteScalar());
            return countVal;
        }
        private void ExecuteQuery(String txtQuery, String databaseFilePath)
        {
            Console.WriteLine("ExecuteQuery: {0}", txtQuery);
            SetConnection(databaseFilePath);
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public SecretThing ReadSingleResult(int secretID, String convertedPwd, String databaseFilePath)
        {
            String sql = "select * from secrets where secretId = " + secretID;
            SecretThing resultSecret = new SecretThing(); 
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            // this breaks silently if there's more than 1.
            // it may break noisily if there's no result!
            resultSecret.title = reader["title"].ToString();
            Console.WriteLine("title: {0}", resultSecret.title);
            resultSecret.comment = reader["comment"].ToString();
            resultSecret.url = reader["url"].ToString();
            resultSecret.password = reader["password"].ToString();
            // This seems like going round the houses but...
            String realtmp = reader["secretId"].ToString();
            Console.WriteLine("secretIdL {0}", realtmp);
            resultSecret.secretId = Int32.Parse(realtmp);
            resultSecret.privateKey = reader["privateKey"].ToString();
            SecretThing unencryptedSecret = crypt.DecryptSecret(resultSecret, convertedPwd);
            return unencryptedSecret;
        }

        // may need to change the return type to be a list containing the updated
        // contents of the table.
        public void WriteSingleResult(SecretThing inputSecret, String convertedPwd, String databaseFilePath)
        {
            int countId = GetCount(databaseFilePath);
            inputSecret.secretId = countId+1;
            Console.WriteLine("inputSecret.secretId: {0}", inputSecret.secretId);
            SecretThing encyptedSecret = crypt.EncryptSecret(inputSecret, convertedPwd);
            String concat = "\"" + encyptedSecret.secretId + "\"," +
                            "\"" + encyptedSecret.title + "\"," +
                            "\"" + encyptedSecret.comment + "\"," +
                            "\"" + encyptedSecret.url + "\"," +
                            "\"" + encyptedSecret.password + "\"," +
                            "\"" + encyptedSecret.privateKey + "\"";
            Console.WriteLine("concat: {0}", concat);
            String sql = "insert into secrets (secretId, title, comment, url, password, privateKey) values (" + concat + ")";
            Console.WriteLine("sql string = {0}", sql);
            ExecuteQuery(sql, databaseFilePath);
        }

        public List<SecretThing> getAllRecords(int count, String databaseFilePath)
        {

        }

        public void DeleteSingleResult(SecretThing inputSecret, String databaseFilePath)
        {
            // to do. same thing: probably need to return this as a list.
        }

        private void SetConnection(String databaseFilePath)
        {
            sql_con = new SQLiteConnection
                ("Data Source=" + databaseFilePath +  ";Version=3;New=False;Compress=True;");
        }
    }
}
