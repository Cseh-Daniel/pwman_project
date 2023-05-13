using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void TestSaveAndLoadDatabase()
        {
            

            string password = "pashash";
            string dbLocation = "keyhashTest.pdb";
            string keyFileLocation = "keyFileTest.KEY";
            
            StreamWriter fs = new StreamWriter(keyFileLocation);
            string info = Generator.generateKeyfileString();
            fs.Write(info);
            fs.Close();

            Database database = new Database(Encrypter.Hash(password),Encrypter.Hash(info), dbLocation);
            database.Entries.Add(new passwordData("name", "link", "username", "pashash"));

            database.saveDatabase();
            Database loadedDatabase = new Database();
            loadedDatabase.loadDatabase(dbLocation);

            Assert.AreEqual(database.Password, loadedDatabase.Password);
            Assert.AreEqual(database.KeyFile, loadedDatabase.KeyFile);
            Assert.AreEqual(database.DbLocation, loadedDatabase.DbLocation);
            Assert.AreEqual(database.Entries[0].name, loadedDatabase.Entries[0].name);
            Assert.AreEqual(database.Entries[0].link, loadedDatabase.Entries[0].link);
            Assert.AreEqual(database.Entries[0].username, loadedDatabase.Entries[0].username);
            Assert.AreEqual(database.Entries[0].password, loadedDatabase.Entries[0].password);
        }
    }
}
