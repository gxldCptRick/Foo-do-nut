using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{
    public partial class Section
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("depth", NullValueHandling = NullValueHandling.Ignore)]
        public long? Depth { get; set; }

        [JsonProperty("sentences", NullValueHandling = NullValueHandling.Ignore)]
        public List<Sentence> Sentences { get; set; }

        [JsonProperty("templates", NullValueHandling = NullValueHandling.Ignore)]
        public List<TemplateElement> Templates { get; set; }
    }
}
