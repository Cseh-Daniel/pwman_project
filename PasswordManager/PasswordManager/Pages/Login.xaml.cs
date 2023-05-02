using PasswordManager.Classes;
using PasswordManager.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        bool showPass = false;
        public Login()
        {
            InitializeComponent();
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

        private void aOpenDatabaseFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".pdb";
            dlg.Filter = "Password Database File (*.pdb)|*.pdb";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                //tbFileExplorer.Text = filename;
                tbDatabaseFileExplorer.Text = filename;
            }
        }

        private void aOpenKeyFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".KEY";
            dlg.Filter = "Key Files (.KEY)|*.KEY";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                //tbFileExplorer.Text = filename;
                tbKeyFileExplorer.Text = filename;
            }
        }

        private void aToCreate(object sender, RoutedEventArgs e)
        {
            CreateDatabase cd = new CreateDatabase();
            cd.Show();
        }

        private void aToPasswordList(object sender, RoutedEventArgs e)
        {
            Database mainDb = new Database();
            mainDb.loadDatabase(tbDatabaseFileExplorer.Text);

            string pass = "";

            if (tbLoginPass.Visibility == Visibility.Visible) pass = tbLoginPass.Text;
            else if (pbLoginPass.Visibility == Visibility.Visible) pass = pbLoginPass.Password;

            if (mainDb.authentication(pass, tbKeyFileExplorer.Text))
            {
                this.NavigationService.Navigate(new Uri("/Pages/Main.xaml", UriKind.Relative));
            }
        }

        private void aChangePass(object sender, RoutedEventArgs e)
        {
            if (!showPass)
            {
                showPass = true;
                tbLoginPass.Text = pbLoginPass.Password;
                tbLoginPass.Visibility = Visibility.Visible;
                pbLoginPass.Visibility = Visibility.Hidden;
            }
            else
            {
                showPass = false;
                pbLoginPass.Password = tbLoginPass.Text;
                pbLoginPass.Visibility = Visibility.Visible;
                tbLoginPass.Visibility = Visibility.Hidden;
            }
        }
    }
}
