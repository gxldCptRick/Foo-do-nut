using System.Windows;
using System.Windows.Input;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchPage search;
        private MainPage mainPage;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var mainViewData = DataContext as MainViewData;

            var searchTerm = mainViewData?.SearchTerm?.Trim();
            if (search is null)
            {
                search = new SearchPage()
                {
                    DataContext = DataContext
                };
                search.lsbxResults.MouseDoubleClick += ResultDoubleClicked;
                search.btnSearch.Click += BtnSearch_Click;
                search.txtbxSearch.KeyDown += EnterPressed;
            }

            frame.Navigate(search);
            search.btnSearch.IsEnabled = false;
            loadingBar.Visibility = Visibility.Visible;
            mainViewData.GetSearchResultsAsync(searchTerm);
        }


        public void ResultDoubleClicked(object sender, RoutedEventArgs e)
        {
            var resultsPage = new ResultPage()
            {
                DataContext = (DataContext as MainViewData).SelectedPage
            };

            resultsPage.btnBack.Click += (s, even) => frame.GoBack();
            frame.Navigate(resultsPage);
        }

        public void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewData)?.PreviousSearches.Clear();
        }

        private KeyEventHandler EnterPressed;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainPage = new MainPage()
            {
                DataContext = DataContext
            };
            EnterPressed = (s, re) =>
            {
                if (re.Key == Key.Enter) this.BtnSearch_Click(s, re);
            };
            frame.Navigate(mainPage);
            mainPage.txtbxSearch.KeyDown += EnterPressed;
            mainPage.btnSearch.Click += BtnSearch_Click;
            mainPage.btnClear.Click += BtnClear_Click;
            mainPage.lsbxPreviousSearches.MouseDoubleClick += DoubleClickList;
            (DataContext as MainViewData).ResultsLoaded += (s, en) =>
            {
                search.btnSearch.IsEnabled = true;
                loadingBar.Visibility = Visibility.Hidden;
            };

        }

        private void DoubleClickList(object sender, MouseButtonEventArgs e)
        {
            var mainView = (DataContext as MainViewData);
            mainView.SearchTerm = (mainPage.lsbxPreviousSearches.SelectedItem as string);
            BtnSearch_Click(sender, e);
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
