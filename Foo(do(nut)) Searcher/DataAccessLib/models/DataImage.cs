using Newtonsoft.Json;

namespace WikiData
{
    public partial class DataImage
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public PurpleImage Data { get; set; }
    }

}
