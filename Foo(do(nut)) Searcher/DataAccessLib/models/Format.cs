using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{
    public partial class Format
    {
        [JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Italic { get; set; }
    }
}
