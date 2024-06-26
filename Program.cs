﻿// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Xml.Serialization;

var ser = new XmlSerializer(typeof(PriceGroups));
using var ms = new MemoryStream();
ser.Serialize(ms, new PriceGroups()
{
    Groups = [
        new PriceGroup()
        {
            Id = 1,
            Values = new List<object>()
            {
                new GradeElement() { GradeID = 1 },
                new PriceElement() { Price = 2310 },
                new GradeElement() { GradeID = 2 },
                new PriceElement() { Price = 1110 },
                new GradeElement() { GradeID = 3 },
                new PriceElement() { Price = 2210 },
                new GradeElement() { GradeID = 4 },
                new PriceElement() { Price = 1210 }
            }
        }
    ]
});
var xml = Encoding.UTF8.GetString(ms.ToArray());
Console.WriteLine(xml);

using var ms2 = new MemoryStream(Encoding.UTF8.GetBytes(xml));
var data = (PriceGroups?)ser.Deserialize(ms2);

if (data?.Groups is null)
{
    Console.WriteLine("Serialization failed");
    return;
}

foreach (var group in data.Groups)
{
    Console.WriteLine("Price Group ID: {0}", group.Id);

    if (group.Values is null)
    {
        Console.WriteLine("No values");
        continue;
    }

    for (int i = 0; i + 1 < group.Values.Count; i += 2)
    {
        Console.WriteLine("Grade {0} price {1}", group.Values[i], group.Values[i + 1]);
    }
}


public class PriceGroups
{
    [XmlElement("PriceGroup")]
    public List<PriceGroup>? Groups { get; set; }
}

public class PriceGroup
{
    [XmlAttribute("ID")]
    public int Id { get; set; }

    [XmlElement("GradeID", typeof(GradeElement))]
    [XmlElement("Price", typeof(PriceElement))]
    public List<object>? Values { get; set; }
}

public class GradeElement
{
    [XmlText]
    public int GradeID { get; set; }

    public override string ToString()
    {
        return $"{GradeID}";
    }

}

public class PriceElement()
{
    [XmlText]
    public int Price { get; set; }

    public override string ToString()
    {
        return $"{Price}";
    }
}
