using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class EncrypterTest
    {
        [TestMethod]
        public void TestHash()
        {
            string password = "password123";
            string expectedHash = "75K3eLr+dx6JJFuJ7LwIpEpOFmwGZZkRiB84PURz6U8=";

            string actualHash = Encrypter.Hash(password);

            Assert.AreEqual(expectedHash, actualHash);
        }
    }
}
