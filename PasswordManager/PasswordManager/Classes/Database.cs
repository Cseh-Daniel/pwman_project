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
        private string password, keyFile, dbLocation, vector, encryptedPass;
        List<passwordData> entries;

        public string Password { get { return password; } set { password = value; } }
        public string KeyFile { get { return keyFile; } set { keyFile = value; } }
        public string DbLocation { get { return dbLocation; } set { dbLocation = value; } }
        List<passwordData> Entries { get { return entries; } set { entries = value; } }
        public string Vector { get { return vector; } set { vector = value; } }
        public string EncryptedPass { get { return encryptedPass; } set { encryptedPass = value; } }


        public Database(string password, string keyfile, string dbLocation)
        {
            entries = new List<passwordData>();
            Password = password;
            KeyFile = keyfile;

            //--test Datas
            /*
            Entries.Add(new passwordData("cim", "link", "username", "password"));
            Entries.Add(new passwordData("cim1", "link1", "username1", "password1"));
            */

            DbLocation = dbLocation;
            Vector = "";
            EncryptedPass = "";

        }


        public void saveDatabase()
        {
            StreamWriter fs = new StreamWriter(dbLocation);
            EncryptedPass = JsonConvert.SerializeObject(Entries, Formatting.Indented);
            EncryptedPass = Encrypter.EncryptData(EncryptedPass, Encrypter.keyGenerator(Password, keyFile));
            Vector = Encrypter.getVector();
            string db = JsonConvert.SerializeObject(this, Formatting.Indented);

            //Debug.WriteLine(db+"\n");
            fs.Write(db);
            fs.Close();
        }

        public void loadDatabase(string location)
        {
            dbLocation = location;
            StreamReader fs = new StreamReader(dbLocation);
            var temp = JsonConvert.DeserializeObject<Database>(fs.ReadToEnd());

            clear();

            this.Password = temp.Password;
            this.Vector = temp.Vector;
            this.KeyFile = temp.KeyFile;
            this.DbLocation = temp.DbLocation;
            this.EncryptedPass = temp.EncryptedPass;
            
            this.EncryptedPass = Encrypter.DecryptData(EncryptedPass, Encrypter.keyGenerator(Password, keyFile), Vector);
            Entries = JsonConvert.DeserializeObject<List<passwordData>>(EncryptedPass);
            //Debug.WriteLine("temp:\n" + this);
            fs.Close();
        }

        public void clear()
        {
            Password = "";
            Vector = "";
            KeyFile = "";
            DbLocation = "";
            EncryptedPass = "";
            Entries.Clear();
        }

        public override string? ToString()
        {
            //string password, keyfile, dbLocation;

            string allEntry = "";

            foreach (var item in Entries)
            {
                allEntry += item + "\n";
            }

            return Password + " | " + KeyFile + " | " + DbLocation + "\n" + allEntry + "\n" + EncryptedPass;

        }
    }
}
