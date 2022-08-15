using Newtonsoft.Json;

namespace HelloWorldService.Models
{
    public class Phone
    {
        [JsonProperty("number", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Number { get; set; }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PhoneType PhoneType { get; set; }
    }
}