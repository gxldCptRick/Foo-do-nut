using Newtonsoft.Json;
using System.Collections.Generic;

namespace WikiData
{
    public partial class Formatting
    {
        [JsonProperty("bold", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Bold { get; set; }

        [JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Italic { get; set; }
    }
}
