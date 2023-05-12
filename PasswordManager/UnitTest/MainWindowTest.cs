using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UnitTest
{
    [TestClass]
    public class MainWindowTest
    {
        [TestMethod]
        public void TestForMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            Frame navigationFrame = mainWindow.MainFrame;

            Assert.IsNotNull(navigationFrame);
            Assert.IsInstanceOfType(navigationFrame.NavigationService.Content, typeof(Login));

        }
    }
}
