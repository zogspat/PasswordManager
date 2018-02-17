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
        SecretThing ReadSingleResult(int secretID, String databaseFilePath);
        void WriteSingleResult(SecretThing inputSecret, String databaseFilePath);
    }
    public class DatabaseActions : IDatabaseActions
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        public void FirstRun(String databaseFilePath)
        {
            // create the database:
            SQLiteConnection.CreateFile("databaseFilePath");
            SetConnection(databaseFilePath);
            // title url comment, password key
            string sql = "create table secrets (secretid integer primary key, title varchar(50), url  varchar(75), password varchar(50), key varchar(200))";
            ExecuteQuery(sql, databaseFilePath);
        }

        public int GetCount(String databaseFilePath)
        {
            SetConnection(databaseFilePath);
            string sql = "select count(*) from secrets";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            sql_con.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            // this is a bit of a guess
            return (int)reader[""] ;
        }
        private void ExecuteQuery(String txtQuery, String databaseFilePath)
        {
            SetConnection(databaseFilePath);
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public SecretThing ReadSingleResult(int secretID, String databaseFilePath)
        {
            String sql = "select * from secrets where secretId = " + secretID;
            SecretThing resultSecret = new SecretThing(); 
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            // this breaks silently if there's more than 1.
            // it may break noisily if there's no result!
            resultSecret.title = reader["title"].ToString();
            resultSecret.comment = reader["comment"].ToString();
            resultSecret.url = reader["url"].ToString();
            resultSecret.password = reader["password"].ToString();
            resultSecret.secretId = (int)reader["secretId"];
            resultSecret.privateKey = reader["privateKey"].ToString();
            return resultSecret;
        }

        // may need to change the return type to be a list containing the updated
        // contents of the table.
        public void WriteSingleResult(SecretThing inputSecret, String databaseFilePath)
        {
            String concat = inputSecret.title + "," + inputSecret.comment + "," + inputSecret.url + "," + inputSecret.password + "," + inputSecret.secretId + "," + inputSecret.privateKey;
            String sql = "insert into secrets (title, comment, url, password, secretId, privateKey) values (" + concat + ")";
            ExecuteQuery(sql, databaseFilePath);
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
