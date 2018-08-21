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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReadSearches();
        }

        private void ReadSearches()
        {
            List<string> lines = new List<string>();
            string line;

            StreamReader reader = new StreamReader("./searches/searches.txt");
            line = reader.ReadLine();

            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }

            for (int i = 0; i < lines.Count; i++)
            {
            lsbxPreviousSearches.Items.Add(lines[i]);
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
