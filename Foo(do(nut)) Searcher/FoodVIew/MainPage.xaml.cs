﻿using System;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(List<String> prevSearches)
        {
            InitializeComponent();
            foreach(var p in prevSearches)
            {
                lsbxPreviousSearches.Items.Add(p);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //call a file read that reads from a list of previous searches
        }

        private void ReadSearches()
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
