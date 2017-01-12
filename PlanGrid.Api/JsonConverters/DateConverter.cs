using System;
using Newtonsoft.Json;

namespace PlanGrid.Api.JsonConverters
{
    public class DateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (Date?)value;
            writer.WriteValue(date?.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return s == null ? null : (Date?)Date.Parse(s);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Date).IsAssignableFrom(Nullable.GetUnderlyingType(objectType) ?? objectType);
        }
    }
}
