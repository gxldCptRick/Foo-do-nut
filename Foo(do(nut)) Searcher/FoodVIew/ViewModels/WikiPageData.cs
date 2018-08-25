using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData;

namespace FoodVIew.ViewModels
{
    public class WikiPageData
    {
        private readonly WikiPage _wikiPage;
        public string Title { get => _wikiPage.Title; }
        public List<SectionData> Sections { get; }
        private string _text;
        public string Text { get
            {
                if (_text is null)
                {
                    _text = "";
                    foreach (var section in Sections)
                    {
                        _text += section.Text + "\r\n";
                    }
                }

                return _text;
            }
        }
        public List<CitationViewData> Citations { get; }
        public WikiPageData(WikiPage wikiPage)
        {
            _wikiPage = wikiPage;
            Sections = new List<SectionData>();
            Citations = new List<CitationViewData>();
            foreach (var section in wikiPage.Sections)
            {
                Sections.Add(new SectionData(section));
            }

            foreach (var citation in wikiPage.Citations)
            {
                Citations.Add(new CitationViewData(citation));
            }
        }
    }
}
