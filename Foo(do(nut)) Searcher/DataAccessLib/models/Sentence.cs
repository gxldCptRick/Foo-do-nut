using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{
    public partial class Sentence
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("formatting", NullValueHandling = NullValueHandling.Ignore)]
        public Formatting Formatting { get; set; }
    }
}
