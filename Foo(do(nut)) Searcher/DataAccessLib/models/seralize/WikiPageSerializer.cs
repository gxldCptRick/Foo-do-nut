using Newtonsoft.Json;
using WikiData.Converters;

namespace WikiData
{
    public static class Serialize
    {
        public static string ToJson(this WikiPage self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

}
