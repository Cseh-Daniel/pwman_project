using PasswordManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PasswordManager.Pages;

namespace PasswordManager.Windows
{
    /// <summary>
    /// Interaction logic for AddEntry.xaml
    /// </summary>
    public partial class AddEntry : Window
    {
        MainPage mainPage;
        bool showPass = false;
        public AddEntry(MainPage mainPage)
        {
            this.mainPage = mainPage;
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }
        private void aToPage(object sender, RoutedEventArgs e)
        {
            var destinationurl = "https://github.com/Cseh-Daniel/pwman_project";
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }

        private void aChangePass(object sender, RoutedEventArgs e)
        {
            if (!showPass)
            {
                showPass = true;
                tbNewPass.Text = pbNewPass.Password;
                tbNewPass.Visibility = Visibility.Visible;
                pbNewPass.Visibility = Visibility.Hidden;
            }
            else
            {
                showPass = false;
                pbNewPass.Password = tbNewPass.Text;
                pbNewPass.Visibility = Visibility.Visible;
                tbNewPass.Visibility = Visibility.Hidden;
            }
        }

        private void aBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aAddEntry(object sender, RoutedEventArgs e)
        {
            string pass = "";

            if (tbNewPass.Visibility == Visibility.Visible) pass = tbNewPass.Text;
            else if (pbNewPass.Visibility == Visibility.Visible) pass = pbNewPass.Password;

            if (tbNewName.Text.Length == 0)
            {
                tbErrorMessage.Visibility = Visibility.Visible;
                tbErrorMessage.Text = "The name field can't be empty!";
                return;
            }
            else if (tbNewLink.Text.Length == 0)
            {
                tbErrorMessage.Visibility = Visibility.Visible;
                tbErrorMessage.Text = "The link field can't be empty!";
                return;
            }
            else if (!tbNewLink.Text.Contains("http://") && !tbNewLink.Text.Contains("https://"))
            {
                tbErrorMessage.Visibility = Visibility.Visible;
                tbErrorMessage.Text = "The link field must contain http/https!";
                return;
            }
            else if (tbNewUser.Text.Length == 0)
            {
                tbErrorMessage.Visibility = Visibility.Visible;
                tbErrorMessage.Text = "The username field can't be empty!";
                return;
            }
            else if (pass.Length == 0)
            {
                tbErrorMessage.Visibility = Visibility.Visible;
                tbErrorMessage.Text = "The password field can't be empty!";
                return;
            }
            if (tbNewLink.Text[tbNewLink.Text.Length -1] != '/') tbNewLink.Text += "/";

            GlobalDb.db.Entries.Add(new passwordData(tbNewName.Text, tbNewLink.Text, tbNewUser.Text, pass));
            GlobalDb.db.saveDatabase();
            mainPage.refreshList();

            this.Close();

        }
    }
}
