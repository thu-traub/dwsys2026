using System.Text.Json.Serialization;
using System.Collections.Generic;

public  class Root
{
    [JsonPropertyName("data")]
    public Data Data { get; set; } = new Data();
}

public  class Data
{
    [JsonPropertyName("person")]
    public List<Person> Person { get; set; } = new List<Person>();
}

public  class Person
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public long Age { get; set; }
    public string City { get; set; } = string.Empty;
}