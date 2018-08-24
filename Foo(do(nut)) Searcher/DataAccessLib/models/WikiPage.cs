using System.Collections.Generic;
using Newtonsoft.Json;
using WikiData.Converters;

namespace WikiData
{
    public class WikiPage
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Categories { get; set; }

        [JsonProperty("citations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Citation> Citations { get; set; }

        [JsonProperty("sections", NullValueHandling = NullValueHandling.Ignore)]
        public List<Section> Sections { get; set; }

        public static WikiPage FromJson(string json) => JsonConvert.DeserializeObject<WikiPage>(json, Converter.Settings);

    }

}
