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
using System.Security.Policy;

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        passwordData? activePassdata = null;
        int activeId;
        Border lastBorder = new Border();

        public MainPage()
        {
            InitializeComponent();


            refreshList();

            //Debug.WriteLine(GlobalDb.db.Entries.Count);

        }
        public void AddGrid(passwordData pd,int id)
        {
            var b = new Border();
            b.MouseLeftButtonDown += aClicked;

            b.CornerRadius = new CornerRadius(35);
            b.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            spPasswordList.Children.Add(b);
            b.Margin = new Thickness(5);
            b.Padding = new Thickness(5);

            Grid cloneGrid = new Grid();
            cloneGrid.Height = 55;
            b.Child = cloneGrid;

            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(0.15, GridUnitType.Star);

            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = new GridLength(0.55, GridUnitType.Star);

            ColumnDefinition colDef3 = new ColumnDefinition();
            colDef3.Width = new GridLength(0.3, GridUnitType.Star);

            cloneGrid.ColumnDefinitions.Add(colDef1);
            cloneGrid.ColumnDefinitions.Add(colDef2);
            cloneGrid.ColumnDefinitions.Add(colDef3);

            RowDefinition rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(0.6, GridUnitType.Star);

            RowDefinition rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(0.4, GridUnitType.Star);

            cloneGrid.RowDefinitions.Add(rowDef1);
            cloneGrid.RowDefinitions.Add(rowDef2);

            var fullFilePath = pd.link + "favicon.ico";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            TextBlock nameTextBlock = new TextBlock();
            nameTextBlock.FontSize = 20;
            nameTextBlock.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(nameTextBlock, 0);
            Grid.SetColumn(nameTextBlock, 1);
            nameTextBlock.Text = pd.name;
            cloneGrid.Children.Add(nameTextBlock);

            TextBlock urlTextBlock = new TextBlock();
            urlTextBlock.FontSize = 12;
            urlTextBlock.Margin = new Thickness(10, 0, 0, 0);
            urlTextBlock.Text = pd.link;
            Grid.SetRow(urlTextBlock, 1);
            Grid.SetColumn(urlTextBlock, 1);
            cloneGrid.Children.Add(urlTextBlock);

            TextBlock usernameTextBlock = new TextBlock();
            usernameTextBlock.FontSize = 15;
            usernameTextBlock.VerticalAlignment = VerticalAlignment.Center;
            usernameTextBlock.Text = pd.username;
            Grid.SetRow(usernameTextBlock, 0);
            Grid.SetColumn(usernameTextBlock, 2);
            cloneGrid.Children.Add(usernameTextBlock);

            TextBlock passwdTextBlock = new TextBlock();
            passwdTextBlock.Visibility = Visibility.Hidden;
            passwdTextBlock.Text = pd.password;
            cloneGrid.Children.Add(passwdTextBlock);

            var entryId = new TextBlock();
            entryId.Visibility = Visibility.Hidden;
            entryId.Text = id.ToString();
            cloneGrid.Children.Add(entryId);

            TextBlock passwordBox = new TextBlock();
            passwordBox.FontSize = 12;
            passwordBox.Text = "******";
            Grid.SetRow(passwordBox, 1);
            Grid.SetColumn(passwordBox, 2);
            cloneGrid.Children.Add(passwordBox);

            var image = new System.Windows.Controls.Image();
            Grid.SetRow(image, 0);
            Grid.SetColumn(image, 0);
            Grid.SetRowSpan(image, 2);
            image.Source = bitmap;
            image.Width = image.Height = 50;
            cloneGrid.Children.Add(image);

        }

        private void aClicked(object sender, MouseButtonEventArgs e)
        {

            lastBorder.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            lastBorder.Background.Opacity = 1;

            Border br = (Border)sender;
            lastBorder = br;

            //activeId = br.PersistId;
            //Debug.WriteLine(activeId);

            Grid gr = br.Child as Grid;

            TextBlock[] data = new TextBlock[5];

            /*if (activeId == gr.PersistId)
            {*/
            br.Background = new SolidColorBrush(Color.FromRgb(246, 198, 45));
            br.Background.Opacity = 0.9;
            //}

            for (int i = 0; i <= 4; i++)
            {
                data[i] = (TextBlock)gr.Children[i];
                //Debug.WriteLine(data[i].Text);
            }
            activePassdata = new passwordData(data[0].Text, data[1].Text, data[2].Text, data[3].Text);
            activeId = Int32.Parse(data[4].Text);
            


        }


        private void aNewEntry(object sender, RoutedEventArgs e)
        {
            AddEntry ae = new AddEntry(this);
            ae.Show();
        }

        private void aEditEntry(object sender, RoutedEventArgs e)
        {
            if (activePassdata != null)
            {

                EditEntry ee = new EditEntry(this, activeId);
                ee.Show();
            }
        }

        private void aLogout(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/Login.xaml", UriKind.Relative));
            //Kijelentkezés
        }

        private void aSearch(object sender, TextChangedEventArgs e)
        {
            spPasswordList.Children.Clear();
            for (int i = 0; i < GlobalDb.db.Entries.Count(); i++)
            {
                if (GlobalDb.db.Entries[i].name.Contains(tbSearchBar.Text) || GlobalDb.db.Entries[i].username.Contains(tbSearchBar.Text))
                {
                    AddGrid(GlobalDb.db.Entries[i], i);
                }
            }
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

        public void refreshList() {

            spPasswordList.Children.Clear();

            for (int i = 0; i < GlobalDb.db.Entries.Count(); i++)
            {
                //var pd = new passwordData($"Reddit{i}", "www.reddit.com", "Alma", "Alma0110");

                AddGrid(GlobalDb.db.Entries[i],i);
                //AddGrid(pd);
            }


        }

        private void aDeleteEntry(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show
                ("Do you want to close this window?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

            {

                GlobalDb.db.Entries.Remove(GlobalDb.db.Entries[activeId]);
                GlobalDb.db.saveDatabase();
                refreshList();

            }
            else
            {
                // Do not close the window
            }


        }
    }
}
