using PasswordManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class PasswordDataTest
    {
        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            // Arrange
            string name = "Facebook";
            string link = "https://www.facebook.com";
            string username = "john.doe";
            string password = "password123";
            string expected = "Facebook | john.doe\tpassword123";

            passwordData data = new passwordData(name, link, username, password);

            // Act
            string actual = data.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
