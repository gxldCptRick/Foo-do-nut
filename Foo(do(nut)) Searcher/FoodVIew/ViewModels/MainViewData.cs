using CommonLib;
using DataAccessLib.services;
using DataAccessLib.services.interfaces;
using FoodVIew.testData;
using FoodVIew.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
        private ObservableCollection<WikiPageData> _results;
        public ObservableCollection<WikiPageData> Results
        {
            get => _results; set
            {
                _results = value;
                PropertyChanging();
            }
        }
        private string _searchTerm = "";

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
            service = new WikiService();
        }
        private string _previousQuery = null;
        public event EventHandler ResultsLoaded;
        public async void GetSearchResultsAsync(string query)
        {
            if (query != _previousQuery)
            {
                if (!PreviousSearches.Contains(query)) PreviousSearches.Add(query);
                if (Results is null) Results = new ObservableCollection<WikiPageData>();
                else Results.Clear();
                var loadedData = await GetDataBasedOnQuery(query);
                foreach (var wikiPage in loadedData)
                {
                    Results.Add(new WikiPageData(wikiPage));
                }
                _previousQuery = query;
            }
           ResultsLoaded?.Invoke(this, EventArgs.Empty);
        }

        private async Task<IList<WikiPage>> GetDataBasedOnQuery(string query)
        {
            IList<WikiPage> loadedData;
            if (String.IsNullOrWhiteSpace(query))
            {
                loadedData = await Task.Run<IList<WikiPage>>( () => service.GetAllPages().ToList());
            }
            else
            {
                loadedData = await Task.Run<IList<WikiPage>>(() => service.GetSpecificPagesBasedOnString(query).ToList());
            }
            return loadedData;
        }

        public void Save()
        {
            fileGuy.WriteFile(previousSearches, filePath);
        }
    }
}
