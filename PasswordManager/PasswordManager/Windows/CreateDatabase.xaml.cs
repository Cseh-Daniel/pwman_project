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
    /// Interaction logic for CreateDatabase.xaml
    /// </summary>
    public partial class CreateDatabase : Window
    {
        public CreateDatabase()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void aSaveFileExplorer(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".text";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                tbSaveFileExplorer.Text = dlg.FileName;
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
            this.Close();
        }
    }
}
