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
    public partial class AddEntry : Window
    {
        bool showPass = false;
        public AddEntry()
        {
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
                tbNewEntry.Text = pbNewEntry.Password;
                tbNewEntry.Visibility = Visibility.Visible;
                pbNewEntry.Visibility = Visibility.Hidden;
            }
            else
            {
                showPass = false;
                pbNewEntry.Password = tbNewEntry.Text;
                pbNewEntry.Visibility = Visibility.Visible;
                tbNewEntry.Visibility = Visibility.Hidden;
            }
        }

        private void aBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aAddEntry(object sender, RoutedEventArgs e)
        {
            //Implement
        }
    }
}
