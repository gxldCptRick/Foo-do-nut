using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void DoubleClickList(object sender, MouseButtonEventArgs e)
        {
            var mainView = (DataContext as MainViewData);
            mainView.SearchTerm = (lsbxPreviousSearches.SelectedItem as string);
        }
    }
}
