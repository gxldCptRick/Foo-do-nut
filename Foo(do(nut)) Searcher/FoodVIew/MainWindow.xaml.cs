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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> searches = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searches.Add(this.mainPage.txtbxSearch.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult save = MessageBox.Show("Do you want to save your searches?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (save == MessageBoxResult.Yes)
            {
                SaveSearches();
            }
        }

        private void SaveSearches()
        {
            using (StreamWriter writer = new StreamWriter("./searches/searches.txt"))
            {
                for (int i = 0; i < searches.Count; i++)
                {
                    writer.WriteLine(searches[i]);
                }
            }

        }
    }
}
