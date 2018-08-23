using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{

    public partial class Inline
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public InlineData Data { get; set; }
    }
}
