using WikiData;

namespace FoodVIew.ViewModels
{
    public class SectionData
    {
        private readonly Section _section;

        public string Text { get; set; }
        public string Title => _section.Title;
        public SectionData(Section section)
        {
            _section = section;
            Text = "";
            foreach (var sentence in section.Sentences)
            {
                Text += $"{sentence.Text}\r\n";
            }
        }
    }
}