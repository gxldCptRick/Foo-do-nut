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

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        public SearchPage(string searchWord)
        {
            InitializeComponent();
            txtbxSearch.Text = searchWord;
        }

        private void DoubleClickList(object sender, MouseButtonEventArgs e)
        {
            // Open the results page with the selected item data
        }
    }
}
