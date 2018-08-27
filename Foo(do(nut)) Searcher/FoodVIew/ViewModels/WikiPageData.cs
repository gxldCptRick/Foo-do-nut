using System.Collections.Generic;
using WikiData;

namespace FoodVIew.ViewModels
{
    public class WikiPageData
    {
        private readonly WikiPage _wikiPage;
        public string Title => _wikiPage.Title;
        public List<SectionData> Sections { get; }
        private string _text;
        public string Text
        {
            get
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
            if (wikiPage.Sections != null)
            {
                foreach (var section in wikiPage.Sections)
                {
                    Sections.Add(new SectionData(section));
                }
            }
            if (wikiPage.Citations != null)
            {
                foreach (var citation in wikiPage.Citations)
                {
                    Citations.Add(new CitationViewData(citation));
                }
            }
        }
    }
}
