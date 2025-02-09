using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;

namespace ConsoleApp1
{
    class Serializer
    {
        public static void Serialize(string filename, Check name)
        {
            string[] format = filename.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            binarForm.Serialize(fs, name);
                            Console.WriteLine($"Object {typeof(Check)} serialized to {filename}");
                        }
                        break;
                    }


                case "soap":
                    {
                        SoapFormatter soapForm = new SoapFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            soapForm.Serialize(fs, name);
                            Console.WriteLine($"Object {typeof(Check)} serialized to {filename}");
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Check));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            jsonForm.WriteObject(fs, name);
                            Console.WriteLine($"Object {typeof(Check)} serialized to {filename}");

                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(Check));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            xmlSer.Serialize(fs, name);
                            Console.WriteLine($"Object {typeof(Check)} serialized to {filename}");

                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong format");
                        break;
                    }
            }
        }

        public static void Deserialize(string fname)
        {
            string[] format = fname.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fr = new FileStream(fname, FileMode.Open))
                        {
                            Check newPl = (Check)binarForm.Deserialize(fr);
                            
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }


                case "soap":
                    {
                        SoapFormatter soapForm = new SoapFormatter();
                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            Check newPl = (Check)soapForm.Deserialize(fr);
                            
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }

                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Check));
                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            Check newPl = (Check)jsonForm.ReadObject(fr);
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(Check));                // получаем поток, куда будем записывать сериализованный объект

                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            Check newPl = (Check)xmlSer.Deserialize(fr);
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }
            }
        }
    }
}
