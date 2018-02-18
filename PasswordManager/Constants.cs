using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class Constants
    {
        const String _sqliteFile = "C:\\Users\\hanndo\\Documents\\PasswordManager\\MyDatabase.sqlite";

        //const String _sqliteFile = "C:\\Users\\donal\\Documents\\PasswordManager\\MyDatabase.sqlite";

        public String databaseFile { get; } = _sqliteFile;

        public Boolean databaseExists { get; } = File.Exists(_sqliteFile);

    }
}
