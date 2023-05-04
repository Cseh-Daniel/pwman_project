using PasswordManager.Classes;
using PasswordManager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using System.IO;
using System.Diagnostics;

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        passwordData? activePassdata = null;
        //int activeId;
        Border lastBorder = new Border();

        public Create()
        {
            InitializeComponent();
            
            
            for (int i = 0; i < GlobalDb.db.Entries.Count(); i++)
            {
                //var pd = new passwordData($"Reddit{i}", "www.reddit.com", "Alma", "Alma0110");
                
                AddGrid(GlobalDb.db.Entries[i]);
                //AddGrid(pd);
            }

            Debug.WriteLine(GlobalDb.db.Entries.Count);

        }
        public void AddGrid(passwordData pd)
        {
            var b = new Border();

            b.MouseLeftButtonDown += aClicked;

            Grid protoGrid = new Grid();

            b.CornerRadius = new CornerRadius(35);
            b.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            this.spPasswordList.Children.Add(b);
            b.Margin = new Thickness(5);
            b.Padding = new Thickness(5);
            b.Child = protoGrid;

            var logo = new System.Windows.Controls.Image();
            var name = new TextBlock();
            var pass = new TextBlock();
            var username = new TextBlock();
            var link = new TextBlock();
            name.FontSize = 20;
            name.Text = pd.name;
            pass.Text = pd.password;
            username.Text = pd.username;
            link.Text = pd.link;

            var fullFilePath = @"http://" + pd.link + "/favicon.ico";
            Trace.WriteLine(fullFilePath);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            logo.Source = bitmap;
            logo.Width = logo.Height = 50;
            protoGrid.HorizontalAlignment = HorizontalAlignment.Center;
            protoGrid.Width = 300;
            protoGrid.Height = 70;

            protoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            protoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            protoGrid.ColumnDefinitions.Add(new ColumnDefinition());

            protoGrid.RowDefinitions.Add(new RowDefinition());
            protoGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(logo, 0);
            Grid.SetColumn(logo, 0);
            Grid.SetRowSpan(logo, 2);

            Grid.SetRow(name, 0);
            Grid.SetColumn(name, 1);
            Grid.SetRow(link, 1);
            Grid.SetColumn(link, 1);

            Grid.SetRow(username, 0);
            Grid.SetColumn(username, 2);
            Grid.SetRow(pass, 1);
            Grid.SetColumn(pass, 2);

            protoGrid.Children.Add(name);
            protoGrid.Children.Add(link);
            protoGrid.Children.Add(username);
            protoGrid.Children.Add(pass);
            protoGrid.Children.Add(logo);

        }

        private void aClicked(object sender, MouseButtonEventArgs e)
        {

            lastBorder.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));

            Border br = (Border)sender;
            lastBorder = br;

            //activeId = br.PersistId;
            //Debug.WriteLine(activeId);

            Grid gr = br.Child as Grid;

            TextBlock[] data = new TextBlock[4];

            /*if (activeId == gr.PersistId)
            {*/
            br.Background = new SolidColorBrush(Color.FromRgb(246, 198, 45));
            //}

            for (int i = 0; i <= 3; i++)
            {
                data[i] = (TextBlock)gr.Children[i];
                Debug.WriteLine(data[i].Text);
            }
            activePassdata = new passwordData(data[0].Text, data[1].Text, data[2].Text, data[3].Text);



        }


        private void aNewEntry(object sender, RoutedEventArgs e)
        {
            AddEntry ae = new AddEntry();
            ae.Show();
        }

        private void aEditEntry(object sender, RoutedEventArgs e)
        {
            EditEntry ee = new EditEntry();
            ee.Show();
        }

        private void aLogout(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/Login.xaml", UriKind.Relative));
            //Kijelentkezés
        }

        private void aSearch(object sender, TextChangedEventArgs e)
        {
        }

        private void aCopyUsername(object sender, RoutedEventArgs e)
        {
            if(activePassdata!=null) Clipboard.SetText(activePassdata.username);
        }

        private void aCopyPassword(object sender, RoutedEventArgs e)
        {
            if (activePassdata != null) Clipboard.SetText(activePassdata.password);
        }

        private void aOpenLink(object sender, RoutedEventArgs e)
        {
            

            if (activePassdata != null)
            {

                var destinationurl = activePassdata.link;
                var sInfo = new ProcessStartInfo(destinationurl)
                {
                    UseShellExecute = true,
                };
                Process.Start(sInfo);
            }
            return;
        }
    }
}
