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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ICollection<string> searches = new ObservableCollection<string>();
        public string filePath = "./searches/searches.txt";
        FileGuy fileGuy = new FileGuy();

        public MainPage()
        {
            InitializeComponent();
        }
        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReadSearches();
        }

        private void ReadSearches()
        {
            searches = fileGuy.ReadFile();
            lsbxPreviousSearches.ItemsSource = searches.Reverse();
        }

        public event EventHandler ButtonMethodThing;

        protected virtual void OnButtonMethodThing()
        {
            ButtonMethodThing?.Invoke(this, EventArgs.Empty);
        }
    }
}
