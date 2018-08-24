using DataAccessLib.services.interfaces;
using FoodVIew.testData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodVIew.ViewModels
{
    public class MainViewData
    {
        public List<WikiPageData> Results { get; set; }
        private IWikiService service;

        public MainViewData()
        {
            service = new TestWikiService();
        }

        public void GetSearchResults(string query)
        {
            Results = new List<WikiPageData>();
            if (String.IsNullOrWhiteSpace(query))
            {
                foreach (var wikiPage in service.GetAllPages())
                {
                    Results.Add(new WikiPageData(wikiPage));
                }
            }
        }
    }
}
