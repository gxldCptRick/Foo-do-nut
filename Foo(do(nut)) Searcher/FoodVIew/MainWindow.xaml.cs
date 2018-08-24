using CommonLib;
using DataAccessLib.services.interfaces;
using FoodVIew.testData;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> searches = new ObservableCollection<string>();
        public string filePath = "./searches/searches.txt";
        private FileGuy fileGuy = new FileGuy();
        private MainPage mainPage = new MainPage();
        private SearchPage searchPage = new SearchPage();
        private IWikiService service = new TestWikiService();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = mainPage.txtbxSearch.Text;
            searchPage.txtbxSearch.Text = searchTerm;
            frame.Navigate(searchPage);
            searches.Add(searchTerm);
            mainPage.txtbxSearch.Text = "";
            mainPage.lsbxPreviousSearches.ItemsSource = searches.Reverse();
            searchPage.lsbxResults.ItemsSource = service.GetSpecificPagesBasedOnString(searchTerm);
        }

        public void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            searches.Clear();
            mainPage.lsbxPreviousSearches.ItemsSource = searches;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            frame.Navigate(mainPage);
            mainPage.btnSearch.Click += BtnSearch_Click;
            searches = new ObservableCollection<string>(fileGuy.ReadFile());
            mainPage.btnClear.Click += BtnClear_Click;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSearches();
        }

        private void SaveSearches()
        {
            fileGuy.WriteFile(searches);
        }
    }
}
