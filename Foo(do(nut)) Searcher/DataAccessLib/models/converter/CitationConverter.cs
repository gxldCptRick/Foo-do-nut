using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData.Enums;

namespace WikiData.Converters
{
    internal class CitationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CitationType) || t == typeof(CitationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "inline")
            {
                return CitationType.Inline;
            }
            throw new Exception("Cannot unmarshal type CitationType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CitationType)untypedValue;
            if (value == CitationType.Inline)
            {
                serializer.Serialize(writer, "inline");
                return;
            }
            throw new Exception("Cannot marshal type CitationType");
        }

        public static readonly CitationTypeConverter Singleton = new CitationTypeConverter();
    }
}
