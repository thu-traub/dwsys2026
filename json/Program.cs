using System.Text.Json;

Root? p = JsonSerializer.Deserialize<Root>(File.ReadAllText("person.json"));

if (p == null)
    return;

p.Data.Person[0].City = "Berlin";

var options = new JsonSerializerOptions { WriteIndented = true };
File.WriteAllText("person2.json", JsonSerializer.Serialize(p, options));

foreach (var person in p.Data.Person)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");
}