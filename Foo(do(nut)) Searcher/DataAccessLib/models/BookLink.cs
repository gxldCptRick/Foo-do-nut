using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{
    public partial class BookLink
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public string Page { get; set; }
    }
}
