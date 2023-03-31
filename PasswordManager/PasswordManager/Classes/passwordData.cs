using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PasswordManager.Classes
{
    public class passwordData
    {
        public string name, password, link, username;

         public passwordData(string n, string l, string un, string p) 
        {
            name = n;
            password = p;
            link = l;
            username = un;
        }

    }
}
