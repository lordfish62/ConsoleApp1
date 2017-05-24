using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.IO;

namespace ConsoleApp1
{
    class XMLDemo
    {
        public static void SetItemValue<T>(string item, T value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Fram.xml");
            xmlDoc.GetElementsByTagName(item.Split('.').ElementAt<string>(1)).Item(0).Attributes.Item(0).Value = value.ToString();
            //xmlDoc.SelectSingleNode("Fram/" + item.Split('.').ElementAt<string>(0) + "/" + item.Split('.').ElementAt<string>(1)).Attributes.Item(0).Value = value.ToString();
            xmlDoc.Save("Fram.xml");
        }
        public static string GetItemValue<T>(string item, T value)
        {
            if (!File.Exists("Fram.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("Fram.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Fram");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Fram.xml");
            if (xmlDoc.GetElementsByTagName(item.Split('.').ElementAt<string>(0)).Count == 0)
            //if (xmlDoc.SelectSingleNode("Fram/" + item.Split('.').ElementAt<string>(0)) == null)
            {
                xmlDoc.DocumentElement.AppendChild(xmlDoc.CreateElement(item.Split('.').ElementAt<string>(0)));
            }
            if (xmlDoc.GetElementsByTagName(item.Split('.').ElementAt<string>(1)).Count == 0)
            //if (xmlDoc.SelectSingleNode("Fram/" + item.Split('.').ElementAt<string>(0) + "/" + item.Split('.').ElementAt<string>(1)) == null)
            {
                XmlElement elem = xmlDoc.CreateElement(item.Split('.').ElementAt<string>(1));
                elem.SetAttribute("value", value.ToString());
                xmlDoc.GetElementsByTagName(item.Split('.').ElementAt<string>(0)).Item(0).AppendChild(elem);
            }
            xmlDoc.Save("Fram.xml");
            return xmlDoc.GetElementsByTagName(item.Split('.').ElementAt<string>(1)).Item(0).Attributes.Item(0).Value;
            //return xmlDoc.SelectSingleNode("Fram/" + item.Split('.').ElementAt<string>(0) + "/" + item.Split('.').ElementAt<string>(1)).Attributes.Item(0).Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XMLDemo.GetItemValue("Feature.DoPolar", 0);
            XMLDemo.GetItemValue("Feature.DoTest1", 0);
            XMLDemo.GetItemValue("Feature.DoTest2", 0);
            XMLDemo.GetItemValue("Feature.DoTest3", 0);
            XMLDemo.GetItemValue("Feature.DoTest4", 0);
            XMLDemo.GetItemValue("Feature.DoTest5", 0);
            XMLDemo.GetItemValue("Turret.Linear_Offset", 0);
            XMLDemo.GetItemValue("Turret.Linear_Up_Speed", 0);
            XMLDemo.GetItemValue("Turret.Linear_Up_Acceleration", 0);
            XMLDemo.GetItemValue("Turret.Linear_Up_JerkTime", 0);
            XMLDemo.GetItemValue("Turret.Linear_Down_Speed", 0);
            XMLDemo.GetItemValue("Turret.Linear_Down_Speed_New", 3.5f);
            XMLDemo.GetItemValue("Reject.rate_limit0", 0);
            XMLDemo.GetItemValue("Reject.new", 3.5f);
            XMLDemo.GetItemValue("Reject.new2", 3.5f);
            XMLDemo.GetItemValue("Turret.Linear_Down_Speed_new", 0);
            XMLDemo.GetItemValue("Feature.new2", 3.5f);
            XMLDemo.GetItemValue("Feature.new3", 'N');
            XMLDemo.GetItemValue("Reject.new_0", 'N');
            XMLDemo.SetItemValue("Feature.DoPolar", 70.5f);
        }
    }
}
