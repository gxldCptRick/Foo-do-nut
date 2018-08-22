using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.data_models
{
    public class WikiPage
    {
        public string WikiId { get; set; }
        public string Title { get; set; }
        public List<string> Categories { get; set; }
        public List<WikiSection> Sections { get; set; }
        public int PageID { get; set; }

        public WikiPage(JObject jsonWikiPage)
        {
            this.WikiId = jsonWikiPage["_id"].ToObject<string>();
            this.Title = jsonWikiPage["title"].ToObject<string>();
            foreach (var category in jsonWikiPage["categories"])
            {
                this.Categories.Add(category.ToObject<string>());
            }
            foreach (var section in jsonWikiPage["sections"])
            {
                Sections.Add(new WikiSection(section));
            }
        }

        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            using (StringWriter writer = new StringWriter(build))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    new JsonSerializer().Serialize(jsonWriter, this);
                }
            }
            return build.ToString();
        }
    }
}
