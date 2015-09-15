using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace CSharp.XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //BuildXmlDocWithDOM();
            //BuildXmlDocWithLINQToXml();
            //MakeXElementFromArray();
            ParseAndLoadExistingXml(@"test.xml");
        }
        private static void BuildXmlDocWithDOM()
        {
            XmlDocument XMLDoc = new XmlDocument();
            XmlElement root = XMLDoc.CreateElement("root");
            XmlElement Car = XMLDoc.CreateElement("Car");
            Car.SetAttribute("ID", "1000");
            XmlElement name = XMLDoc.CreateElement("Name");
            name.SetAttribute("Name", "Jonh");

            XmlElement Color = XMLDoc.CreateElement("Color");
            Color.SetAttribute("Color", "blue");

            Car.AppendChild(name);
            Car.AppendChild(Color);
            root.AppendChild(Car);
            XMLDoc.AppendChild(root);
            XMLDoc.Save("test.xml");
        }

        private static void  BuildXmlDocWithLINQToXml(){
            XElement doc = new XElement("root",
                new XElement("ID", new XAttribute("ID", "100"),
                    new XElement("Name","Andy"),
                    new XElement("Color","Red"),
                        new XElement ("Make","BMW")
                        )                    
                );
            doc.Descendants("Name").Remove();//删除 Name元素
            doc.Save("LINQ.xml");
            Console.WriteLine("生成成功");
        }

       //map data to xml
        static void MakeXElementFromArray()
        {
            var people = new[] {
                new {FirstName="Mandy",age=23},
                new {FirstName="Andrew",age=24},
                new {FirstName="Dave",age=34},
                new {FirstName="Sara",age=32}
            };

            XElement peopleDoc = new XElement("people", from c in people
                                                        select new XElement("Person", new XAttribute("Age", c.age),
                                                            new XElement("FirstName", c.FirstName))
                );
            Console.WriteLine(peopleDoc);
            //peopleDoc.Save("peopleDOC.xml");
        }

        private static void ParseAndLoadExistingXml(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            Console.WriteLine(doc);
        }
    }
}
