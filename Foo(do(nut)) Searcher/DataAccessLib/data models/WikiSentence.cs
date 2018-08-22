using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataAccessLib.data_models
{
    public class WikiSentence
    {
        public string Text { get; set; }
        public List<WikiLinks> Links { get; set; }

        public WikiSentence(JToken jsonSentence)
        {
            this.Text = jsonSentence["text"].ToObject<string>();

        }
    }
}