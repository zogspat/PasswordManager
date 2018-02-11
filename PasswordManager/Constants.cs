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
        const String _passwordFile = "C:\\Users\\hanndo\\Documents\\PasswordManager\\passwords.txt";

        public String passwordFile { get; } = _passwordFile;

        public Boolean passwordFileExists { get; } = File.Exists(_passwordFile); 

    }
}
