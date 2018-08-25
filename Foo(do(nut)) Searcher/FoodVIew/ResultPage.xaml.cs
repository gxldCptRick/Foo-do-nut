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
using FoodVIew.ViewModels;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        private WikiPageData selectedPage;

        public ResultPage()
        {
            InitializeComponent();
        }

        public ResultPage(string resultInfo)
        {
            InitializeComponent();
            lblResult.Content = resultInfo;
        }

        public ResultPage(WikiPageData selectedPage)
        {
            this.selectedPage = selectedPage;
        }
    }
}
