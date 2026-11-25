using System.Xml.Serialization;

string FileName = "person.xml";

Person person = new Person()
{
    Name = "John Doe",
    Age = 30
};

XmlSerializer serializer = new XmlSerializer(typeof(Person));
using (StringWriter writer = new StringWriter())
{
    serializer.Serialize(writer, person);
    string xml = writer.ToString();
    File.WriteAllText(FileName, xml);
}

using (StringReader reader = new StringReader(File.ReadAllText(FileName)))
{
    Person? p = serializer.Deserialize(reader) as Person;
    if (p != null)
    {
        Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
    }
}
public class Person
{
    [XmlElement("FullName")]
    public string Name { get; set; } = String.Empty;
    public int Age { get; set; }
}