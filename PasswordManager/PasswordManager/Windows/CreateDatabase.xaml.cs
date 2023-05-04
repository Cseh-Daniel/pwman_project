using Newtonsoft.Json;
using PasswordManager.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for CreateDatabase.xaml
    /// </summary>
    public partial class CreateDatabase : Window
    {
        bool showPass = false;
        bool showPassRe = false;

        public CreateDatabase()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void aSaveKeyFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "KeyFile";
            dlg.DefaultExt = ".KEY";
            dlg.Filter = "Key Files (.KEY)|*.KEY";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                tbSaveKeyFile.Text = dlg.FileName;
                string filename = dlg.FileName;
            }
        }

        private void aSaveDatabaseFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "DatabaseFile";
            dlg.DefaultExt = ".pdb";
            dlg.Filter = "Database files (.pdb)|*.pdb";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                tbSaveDatabaseFile.Text = dlg.FileName;
                string filename = dlg.FileName;
            }
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

        private void aBackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aCreateDatabase(object sender, RoutedEventArgs e)
        {
            string pass = "", passRe = "";

            if (tbLoginPass.Visibility == Visibility.Visible) pass = tbLoginPass.Text;
            else if (pbLoginPass.Visibility == Visibility.Visible) pass = pbLoginPass.Password;
            if (tbLoginPassRe.Visibility == Visibility.Visible) passRe = tbLoginPassRe.Text;
            else if (pbLoginPassRe.Visibility == Visibility.Visible) passRe = pbLoginPassRe.Password;

            if (pass != passRe || pass.Length == 0 || passRe.Length == 0)
            {
                ErrorMsg.Text = "Passwords don't match!";
                ErrorMsg.Visibility = Visibility.Visible;
            }
            else if (tbSaveKeyFile.Text.Length == 0)
            {
                ErrorMsg.Text = "Set a location for the key file!";
                ErrorMsg.Visibility = Visibility.Visible;
            }
            else if (tbSaveDatabaseFile.Text.Length == 0)
            {
                ErrorMsg.Text = "Set a location for the database file!";
                ErrorMsg.Visibility = Visibility.Visible;
            }
            else
            {
                //FileStream fs = File.Create(tbSaveKeyFile.Text); //keyfile location
                StreamWriter fs = new StreamWriter(tbSaveKeyFile.Text);

                //Generator generator = new Generator();
                //byte[] info = new UTF8Encoding(true).GetBytes(generator.generateKeyfileString());
                string info = Generator.generateKeyfileString();
                fs.Write(info);
                fs.Close();

                
                Database db = new Database(Encrypter.Hash(pass), Encrypter.Hash(info), tbSaveDatabaseFile.Text);
                db.Entries.Add(new passwordData("Példa bejegyzés", "link", "username", "password"));
                
                

                /*
                db.Entries.Add(new passwordData("cim1", "link1", "username1", "password1"));
                
                Debug.WriteLine(db);
                */

                db.saveDatabase();
                db = null;
                db = new Database();

                Debug.WriteLine("Cleared db\n"+db);
                /*
                db.loadDatabase(tbSaveDatabaseFile.Text);
                Debug.WriteLine(" db\n" + db);
                */

                this.Close();

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

        private void aChangePassRe(object sender, RoutedEventArgs e)
        {
            if (!showPassRe)
            {
                showPassRe = true;
                tbLoginPassRe.Text = pbLoginPassRe.Password;
                tbLoginPassRe.Visibility = Visibility.Visible;
                pbLoginPassRe.Visibility = Visibility.Hidden;
            }
            else
            {
                showPassRe = false;
                pbLoginPassRe.Password = tbLoginPassRe.Text;
                pbLoginPassRe.Visibility = Visibility.Visible;
                tbLoginPassRe.Visibility = Visibility.Hidden;
            }
        }


    }
}
