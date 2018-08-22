using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataAccessLib.data_models
{
    public class WikiSection
    {
        public string Title { get; set; }
        public int Depth { get; set; }
        public List<WikiSentence> Sentences { get; set; }
        public WikiSection(JToken jsonSection)
        {
            this.Title = jsonSection["title"].ToObject<string>();
            this.Depth = jsonSection["depth"].ToObject<int>();
            foreach (var sentence in jsonSection["sentence"])
            {
                Sentences.Add(new WikiSentence(sentence));
            }

        }
    }
}