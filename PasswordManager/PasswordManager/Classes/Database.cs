using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Classes
{
    class Database
    {
        string password, keyfile, dbLocation;
        List<passwordData> entries;

        public string Password { get { return password; } set { password = value; } }
        public string Keyfile { get { return keyfile; } set { keyfile = value; } }
        public string DbLocation { get { return dbLocation; } set { dbLocation = value; } }
        public List<passwordData> Entries { get { return entries; }  set { entries = value; } }

        public Database(string password, string keyfile, string dbLocation)
        {
            entries = new List<passwordData>();
            this.password = Encrypter.Hash(password);
            this.keyfile = Encrypter.Hash(keyfile);
            Entries.Add(new passwordData("cim", "link", "username", "password"));
            entries.Add(new passwordData("cim1", "link1", "username1", "password1"));
            this.dbLocation = dbLocation;

        }


        public void saveDatabase()
        {

            //StreamWriter fs = new StreamWriter(dbLocation);
            string db = JsonConvert.SerializeObject(this);
            Debug.WriteLine(db+"\n");
            //fs.WriteLine(db);
            //fs.Close();
        }


      public override string? ToString()
        {
            /*string data = "{" + "password : " + this.password + "," +
                                "keyFile : " + this.keyfile + "," +
                                "entries : {";
                                foreach (var entry in entries)
                                {
                                    data += "{ " + entry.name + " : {";
                                                data += "username :" + entry.username + ",";
                                                data += "password :" + entry.password + ",";
                                                data += "link :" + entry.link +",";
                                    data += "},";
                                }
                                data = data + "}" + 
                          "}";

            return data;*/
            //string password, keyfile, dbLocation;
            return Password + " | " + Keyfile + " | " + DbLocation;

        }
    }
}
