using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiData
{
    public partial class DataBook
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public DataClass Data { get; set; }
    }
}
