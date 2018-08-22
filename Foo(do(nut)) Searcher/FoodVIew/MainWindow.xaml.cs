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
using System.IO;
using System.Collections.ObjectModel;
using CommonLib;

namespace FoodVIew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> searches = new ObservableCollection<string>();
        public string filePath = "./searches/searches.txt";
        FileGuy fileGuy = new FileGuy();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searches.Add(this.mainPage.txtbxSearch.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.mainPage.btnSearch.Click += btnSearch_Click;
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
            fileGuy.WriteFile(searches);
        }
    }
}
