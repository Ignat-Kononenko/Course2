using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Check check1 = new Check("NewCheck", new DateTime(2024, 12, 4), "Dima", "lab13", 100);
            Check check2 = new Check("NewCheck", new DateTime(2024, 12, 5), "Andrey", "Lab13", 200);
            Check check3 = new Check("NewCheck", new DateTime(2024, 12, 6), "Pavel", "LAb13", 300);
            Check check4 = new Check("NewCheck", new DateTime(2024, 12, 7), "Vadim", "LAb13", 400);

            Console.WriteLine("Бинарная сериализация");
            Serializer.Serialize("check1.bin", check1);

            Console.WriteLine("JSON сериализация");
            Serializer.Serialize("check2.json", check2);

            Console.WriteLine("XML сериализация");
            Serializer.Serialize("check3.xml", check3);

            Console.WriteLine("SOAP сериализация");
            Serializer.Serialize("check4.soap", check4);

            Console.WriteLine("\n\nБинарная десериализация");
            Serializer.Deserialize("check1.bin");

            Console.WriteLine("JSON десериализация");
            Serializer.Deserialize("check2.json");

            Console.WriteLine("XML десериализация");
            Serializer.Deserialize("check3.xml");

            Console.WriteLine("SOAP десериализация");
            Serializer.Deserialize("check4.soap");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Check>));
            List<Check> checks = new List<Check>();
            checks.Add(check1);
            checks.Add(check2);
            checks.Add(check3);
            checks.Add(check4);

            using (FileStream fs = new FileStream("Collection.xml", FileMode.Create))
            {
                serializer.Serialize(fs, checks);
            }

            Console.WriteLine("XML сериализация коллекции");
            using (FileStream fr = new FileStream("Collection.xml", FileMode.Open))
            {
                List<Check> newLst = (List<Check>)serializer.Deserialize(fr);
                foreach (var item in newLst)
                {
                    Console.WriteLine($"Десеарелизован: " + item.ToString());
                }
            }

            XmlDocument document = new XmlDocument();                                   // Создаем XML-документ
            document.Load("Collection.xml");                                            // Загружаем XML-документ из файла
            XmlNode xmlRoot = document.DocumentElement;                                 // Получаем корневой элемент
            XmlNodeList allPlants = xmlRoot.SelectNodes("*");                           // Получаем список всех узлов в документе
            foreach (XmlNode node in allPlants)
            {
                Console.WriteLine(node.InnerText);
            }

            XElement language;
            XElement name;
            XAttribute year;

            XDocument Lang = new XDocument();
            XElement root = new XElement("ЯП");

            language = new XElement("language");
            name = new XElement("name");
            name.Value = "C#";
            year = new XAttribute("year", "1998");
            language.Add(name);
            language.Add(year);
            root.Add(language);

            language = new XElement("language");
            name = new XElement("name");
            name.Value = "C++";
            year = new XAttribute("year", "1983");
            language.Add(name);
            language.Add(year);
            root.Add(language);

            language = new XElement("language");
            name = new XElement("name");
            name.Value = "Java";
            year = new XAttribute("year", "1995");
            language.Add(name);
            language.Add(year);
            root.Add(language);

            Lang.Add(root);
            Lang.Save("Lang.xml");


            Console.WriteLine("Введите год для поиска языка программирования: ");
            string yearXML = Console.ReadLine();
            var allAlbums = root.Elements("language");
            int i = 0;
          
                foreach (var item in allAlbums)
                {
                    if (item.Attribute("year").Value == yearXML)
                    {
                        Console.WriteLine(item.Value);
                        i++;
                    }
                }
                
                if(i == 0)
                {
                Console.WriteLine("Не удалось найти");
                }
           
        }
    }
}
