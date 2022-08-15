using Newtonsoft.Json;

var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5220/api/");

client.DefaultRequestHeaders.Add("Accept", "application/json");



var newContact = new Contact
{
    Name = "New Name",
    Phones = new[] {
            new Phone {
                Number = "425-111-2222",
                PhoneType = PhoneType.Mobile
            }
        }
};

var newJson = JsonConvert.SerializeObject(newContact);

var postContent = new StringContent(newJson, System.Text.Encoding.UTF8,
                                      "application/json");

var postResult = await client.PostAsync("contacts", postContent);

Console.WriteLine(postResult.StatusCode);


var result = await client.GetAsync("contacts");

var json = await result.Content.ReadAsStringAsync();

Console.WriteLine(json);
//var list = JsonConvert.DeserializeObject<List<dynamic>>(json);
var list = JsonConvert.DeserializeObject<List<Contact>>(json);

var id = list[0].Id;
result = await client.DeleteAsync($"contacts/{id}");

Console.ReadLine();

public class Contact
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("date_added")]
    public DateTime DateAdded { get; set; }

    [JsonProperty("phones")]
    public Phone[] Phones { get; set; }
}

public class Phone
{
    [JsonProperty("phone_number")]
    public string Number { get; set; }

    [JsonProperty("phone_type")]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public PhoneType PhoneType { get; set; }
}

public enum PhoneType
{
    Nil,
    Home,
    Mobile,
}