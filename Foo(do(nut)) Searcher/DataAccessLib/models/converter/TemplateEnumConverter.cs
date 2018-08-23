using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData.Enums;

namespace WikiData.Converters
{
   internal class TemplateEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TemplateEnum) || t == typeof(TemplateEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "citation")
            {
                return TemplateEnum.Citation;
            }
            throw new Exception("Cannot unmarshal type TemplateEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TemplateEnum)untypedValue;
            if (value == TemplateEnum.Citation)
            {
                serializer.Serialize(writer, "citation");
                return;
            }
            throw new Exception("Cannot marshal type TemplateEnum");
        }

        public static readonly TemplateEnumConverter Singleton = new TemplateEnumConverter();
    }
}
