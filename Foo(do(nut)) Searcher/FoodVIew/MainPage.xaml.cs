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

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ObservableCollection<string> searches = new ObservableCollection<string>();
        public string filePath = "./searches/searches.txt";

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
            List<string> lines = new List<string>();
            string line;
            Directory.CreateDirectory("./searches");


            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                line = reader.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            lsbxPreviousSearches.ItemsSource = lines;
        }

        public event EventHandler ButtonMethodThing;

        protected virtual void OnButtonMethodThing()
        {
            ButtonMethodThing?.Invoke(this, EventArgs.Empty);
        }
    }
}
