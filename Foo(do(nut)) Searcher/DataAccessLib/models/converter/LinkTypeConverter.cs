using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData.Enums;

namespace WikiData.Converters
{
    internal class LinkTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LinkType) || t == typeof(LinkType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "external")
            {
                return LinkType.External;
            }
            throw new Exception("Cannot unmarshal type LinkType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LinkType)untypedValue;
            if (value == LinkType.External)
            {
                serializer.Serialize(writer, "external");
                return;
            }
            throw new Exception("Cannot marshal type LinkType");
        }

        public static readonly LinkTypeConverter Singleton = new LinkTypeConverter();
    }
}
