using PasswordManager.Classes;
using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            //mainFrame.Source = new Uri("Pages/Login.xaml", UriKind.RelativeOrAbsolute);
            mainFrame.NavigationService.Navigate(new Uri("/Pages/Login.xaml", UriKind.Relative));

            Debug.WriteLine("hashed data:\n"+Encrypter.Hash("alma"));

        }

    }
}
