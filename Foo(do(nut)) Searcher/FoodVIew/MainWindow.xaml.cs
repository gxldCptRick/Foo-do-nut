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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using CommonLib;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> searches = new ObservableCollection<string>();
        public string filePath = "./searches/searches.txt";
        FileGuy fileGuy = new FileGuy();
        MainPage mainPage = new MainPage();
        SearchPage searchPage = new SearchPage();


        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.searchPage.txtbxSearch.Text = this.mainPage.txtbxSearch.Text;
            frame.Navigate(this.searchPage);
            searches.Add(this.mainPage.txtbxSearch.Text);
            this.mainPage.txtbxSearch.Text = "";
            SaveSearches();
            this.mainPage.lsbxPreviousSearches.ItemsSource = this.searches.Reverse();
        }

        public void btnClear_Click(object sender, RoutedEventArgs e)
        {
            searches.Clear();
            this.mainPage.lsbxPreviousSearches.ItemsSource = this.searches;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            frame.Navigate(this.mainPage);
            this.mainPage.btnSearch.Click += btnSearch_Click;
            searches = new ObservableCollection<string>(fileGuy.ReadFile());

            mainPage.btnClear.Click += btnClear_Click;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void SaveSearches()
        {
            fileGuy.WriteFile(searches);
        }
    }
}
