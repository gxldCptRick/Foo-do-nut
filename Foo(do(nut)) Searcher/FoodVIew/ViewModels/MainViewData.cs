using CommonLib;
using DataAccessLib.services.interfaces;
using FoodVIew.testData;
using FoodVIew.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WikiData;

namespace FoodVIew
{
    public class MainViewData : ViewModelBase
    {
        private ObservableCollection<string> previousSearches;
        public ObservableCollection<string> PreviousSearches
        {
            get => previousSearches; set => previousSearches = value;
        }
        private List<WikiPageData> _results;
        public List<WikiPageData> Results
        {
            get => _results; set
            {
                _results = value;
                PropertyChanging();
            }
        }
        private string _searchTerm;

        public WikiPageData SelectedPage { get; set; }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                PropertyChanging();
            }
        }

        private IWikiService service;
        public string filePath = "./searches/searches.txt";
        private FileGuy fileGuy = new FileGuy();

        public MainViewData()
        {
            PreviousSearches = new ObservableCollection<string>(fileGuy.ReadFile(filePath));
            service = new TestWikiService();
        }

        public void GetSearchResults(string query)
        {
            Results = new List<WikiPageData>();
            IEnumerable<WikiPage> loadedData;
            if (String.IsNullOrWhiteSpace(query))
            {
                loadedData = service.GetAllPages();
            }
            else
            {
                loadedData = service.GetSpecificPagesBasedOnString(query);
            }

            foreach (var wikiPage in loadedData)
            {
                Results.Add(new WikiPageData(wikiPage));
            }
        }

        public void Save()
        {
            fileGuy.WriteFile(previousSearches, filePath);
        }
    }
}
