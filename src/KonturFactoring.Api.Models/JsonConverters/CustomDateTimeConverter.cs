using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KonturFactoring.Api.Models.JsonConverters
{
    public class CustomDateTimeConverter : DateTimeConverterBase
    {
        private readonly string _format;

        public CustomDateTimeConverter(string format)
        {
            _format = format;
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(_format));
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var s = reader.Value.ToString();
            DateTime result;
            if (DateTime.TryParseExact(s, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }

            throw new FormatException("not accepted date format");
        }
    }
}