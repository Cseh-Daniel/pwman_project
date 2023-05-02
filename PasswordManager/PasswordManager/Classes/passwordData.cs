using Newtonsoft.Json;
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

        /*
        [JsonIgnore]
        public int id;
      */
        public passwordData(string n, string l, string un, string p /*, int id*/) 
        {
            name = n;
            password = p;
            link = l;
            username = un;
            //this.id = id;
        }

        public override string? ToString()
        {
            return name+" | "+username+"\t"+password;
        }
    }
}
