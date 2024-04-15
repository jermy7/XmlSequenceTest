// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Xml.Serialization;

var ser = new XmlSerializer(typeof(PriceGroups));
using var ms = new MemoryStream();
ser.Serialize(ms, new PriceGroups());
var xml = Encoding.UTF8.GetString(ms.ToArray());
Console.WriteLine(xml);

using var ms2 = new MemoryStream(Encoding.UTF8.GetBytes(xml));
var data = (PriceGroups?)ser.Deserialize(ms2);

Console.WriteLine(data);

public class PriceGroups
{
    [XmlElement("PriceGroup")]
    public List<PriceGroup> Groups { get; set; } = [
        new PriceGroup() { Id = 1 }
    ];
}

public class PriceGroup
{
    [XmlAttribute("ID")]
    public int Id { get; set; }

    [XmlElement("GradeID", typeof(GradeElement))]
    [XmlElement("Price", typeof(PriceElement))]
    public List<object> Grades { get; set; } = new List<object>()
    {
        new GradeElement() { GradeID = 1 },
        new PriceElement() { Price = 2310 },
        new GradeElement() { GradeID = 2 },
        new PriceElement() { Price = 1110 },
        new GradeElement() { GradeID = 3 },
        new PriceElement() { Price = 2210 },
        new GradeElement() { GradeID = 4 }
    };
}

public class GradeElement
{
    [XmlText]
    public int GradeID { get; set; }

}

public class PriceElement
{
    [XmlText]
    public int Price { get; set; }
}
