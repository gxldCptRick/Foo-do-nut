using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{
    public partial class InlineData
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public List<PurpleLink> Links { get; set; }

        [JsonProperty("fmt", NullValueHandling = NullValueHandling.Ignore)]
        public Formatting Format { get; set; }
    }
}
