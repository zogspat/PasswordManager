using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class SecretThing
    {
        public int secretId { get; set; }
        public String title { get; set; }
        public String password { get; set; }
        public String url { get; set; }
        public String privateKey { get; set; }
        public String comment { get; set; }
    }
}
