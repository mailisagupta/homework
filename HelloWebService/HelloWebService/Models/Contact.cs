using Newtonsoft.Json;
using System;

namespace HelloWorldService.Models
{
    public class Contact
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        public string ? Name { get; set; }
        public DateTime DateAdded { get; set; }
        public Phone[]? Phones { get; set; }
    }
}