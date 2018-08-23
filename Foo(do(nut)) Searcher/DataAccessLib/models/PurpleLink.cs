using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData.Enums;

namespace WikiData
{
    public partial class PurpleLink
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public LinkType? Type { get; set; }

        [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }
}
