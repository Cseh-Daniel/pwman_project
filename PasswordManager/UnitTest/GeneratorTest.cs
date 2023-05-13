using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{

    [TestClass]
    public class GeneratorTest
    {
        [TestMethod]
        public void TestGenerateKeyfileString()
        {
            string keyfileString = Generator.generateKeyfileString();

            Assert.IsFalse(string.IsNullOrEmpty(keyfileString));

            Assert.AreEqual(256, keyfileString.Length);
        }
    }
}
