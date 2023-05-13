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

    public class Database
    {
        private string password, keyFile, dbLocation, vector, encryptedPass;
        List<passwordData> entries;

        public string Password { get { return password; } set { password = value; } }
        public string KeyFile { get { return keyFile; } set { keyFile = value; } }
        public string DbLocation { get { return dbLocation; } set { dbLocation = value; } }

        [JsonIgnore]
        public List<passwordData> Entries
        {
            get { return entries; }
            set
            {
                entries = value;
            }
        }

        public string Vector { get { return vector; } set { vector = value; } }
        public string EncryptedPass { get { return encryptedPass; } set { encryptedPass = value; } }

        public Database()
        {
            Password = "";
            Vector = "";
            KeyFile = "";
            DbLocation = "";
            EncryptedPass = "";
            Entries = new List<passwordData>();

        }

        public Database(string password, string keyfile, string dbLocation)
        {
            Entries = new List<passwordData>();
            Password = password;
            KeyFile = keyfile;

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

            fs.Write(db);
            fs.Close();
        }

        public void loadDatabase(string location)
        {
            Debug.WriteLine("\n\nLoad DB eleje\n\n");
            dbLocation = location;
            if (dbLocation.Length == 0) return;
            StreamReader fs = new StreamReader(dbLocation);
            var temp = JsonConvert.DeserializeObject<Database>(fs.ReadToEnd());

            clear();

            this.Password = temp.Password;
            this.Vector = temp.Vector;
            Encrypter.setVector(Vector);
            this.KeyFile = temp.KeyFile;
            this.DbLocation = temp.DbLocation;
            this.EncryptedPass = temp.EncryptedPass;

            Debug.WriteLine("\n\nEncrypted\n" + this + "\n-------------------\n");

            this.EncryptedPass = Encrypter.DecryptData(EncryptedPass, Encrypter.keyGenerator(Password, keyFile), Vector);
            Entries = JsonConvert.DeserializeObject<List<passwordData>>(EncryptedPass);
            Debug.WriteLine("\t\nDecrypted:\n\n" + this);
            fs.Close();
            Debug.WriteLine("\n\nLoad DB vége\n\n");
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

        public Boolean authentication(string password, string keyLoc)
        {
            Debug.WriteLine("\n\nAuth eleje\n\n");
            if (keyLoc.Length == 0 || password.Length == 0) return false;
            StreamReader fs = new StreamReader(keyLoc);

            string keyF = fs.ReadToEnd();
            fs.Close();
            if ((Encrypter.Hash(password) == Password) && (Encrypter.Hash(keyF) == KeyFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string? ToString()
        {
            string allEntry = "The passwords:\n";

            foreach (var item in Entries)
            {
                allEntry += item + "\n";
            }

            return Password + " | " + KeyFile + " | " + DbLocation + " | " + Vector + "\n" + allEntry + "\n" + EncryptedPass;

        }
    }
}
