using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = (DataContext as MainViewData)?.SearchTerm;
            var searchPage = new SearchPage()
            {
                DataContext = DataContext
            };
            searchPage.txtbxSearch.Text = searchTerm;
            frame.Navigate(searchPage);
            (DataContext as MainViewData)?.PreviousSearches.Add(searchTerm);
            (DataContext as MainViewData)?.GetSearchResults(searchTerm);
        }

        public void OpenResults(object sender, RoutedEventArgs e)
        {
            var selectedSearch = searchPage.lsbxResults.SelectedItem;
            frame.Navigate(resultPage);
            resultPage.lblResult.Content = selectedSearch;
        }

        public void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewData)?.PreviousSearches.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var mainPage = new MainPage()
            {
                DataContext = this.DataContext
            };
            frame.Navigate(mainPage);
            mainPage.btnSearch.Click += BtnSearch_Click;
            mainPage.btnClear.Click += BtnClear_Click;
            searchPage.lsbxResults.MouseDoubleClick += OpenResults;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSearches();
        }

        private void SaveSearches()
        {
            (DataContext as MainViewData)?.Save();
        }
    }
}
