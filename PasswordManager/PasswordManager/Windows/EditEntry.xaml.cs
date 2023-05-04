using PasswordManager.Classes;
using PasswordManager.Pages;
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

namespace PasswordManager.Windows
{
    /// <summary>
    /// Interaction logic for AddEntry.xaml
    /// </summary>
    public partial class EditEntry : Window
    {
        int entryId;
        MainPage mainPage;

        bool showPass = false;
        public EditEntry(MainPage mainPage,int entryId )
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;

            this.mainPage = mainPage;
            this.entryId = entryId;

            tbEditUserName.Text = GlobalDb.db.Entries[entryId].username;
            pbEditPass.Password = GlobalDb.db.Entries[entryId].password;
            tbEditName.Text = GlobalDb.db.Entries[entryId].name;
            tbEditLink.Text = GlobalDb.db.Entries[entryId].link;


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
                tbEditPass.Text = pbEditPass.Password;
                tbEditPass.Visibility = Visibility.Visible;
                pbEditPass.Visibility = Visibility.Hidden;
            }
            else
            {
                showPass = false;
                pbEditPass.Password = tbEditPass.Text;
                pbEditPass.Visibility = Visibility.Visible;
                tbEditPass.Visibility = Visibility.Hidden;
            }
        }

        private void aBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aEditEntry(object sender, RoutedEventArgs e)
        {
            string pass = "";

            if (tbEditPass.Visibility == Visibility.Visible) pass = tbEditPass.Text;
            else if (pbEditPass.Visibility == Visibility.Visible) pass = pbEditPass.Password;

            GlobalDb.db.Entries[entryId].username = tbEditUserName.Text;
            GlobalDb.db.Entries[entryId].password = pass;
            GlobalDb.db.Entries[entryId].name = tbEditName.Text;
            GlobalDb.db.Entries[entryId].link = tbEditLink.Text;

            mainPage.refreshList();
            this.Close();
        }
    }
}
