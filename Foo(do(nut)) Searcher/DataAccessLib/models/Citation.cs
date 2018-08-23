using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData.Enums;

namespace WikiData
{
    public partial class Citation
    {
        [JsonProperty("template", NullValueHandling = NullValueHandling.Ignore)]
        public TemplateEnum? Template { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public CitationType? Type { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public CitationData Data { get; set; }

        [JsonProperty("inline", NullValueHandling = NullValueHandling.Ignore)]
        public Inline Inline { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
