using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reflector<T>
    {
        public static void Find(T Obj) {
            Type type = Obj.GetType();

            string returnString = "";
            Console.WriteLine("Информация о классе");
            returnString += "Info: " + type.AssemblyQualifiedName + "\n";
            returnString += "Name: " + type.Name + "\n";
            returnString += "fullName" + type.FullName + "\n";
            returnString += "Namespace: " + type.Namespace + "\n";
            returnString += "IsValueType: " + type.IsValueType + "\n";
            returnString += "IsClass: " + type.IsClass + "\n";
            returnString += "\n";

            foreach(var i in type.GetConstructors()) 
            {
                returnString += "Конструкторы: " + i.Name + "\n";
            }

            returnString += "\n";

            foreach (var i in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                returnString += ": " + i.Name + "\n";
                foreach(var parm in i.GetParameters())
                {
                    returnString += "\n Параметры: " + parm.ParameterType + "\n";
                }
            }

            returnString += "\n";

            foreach (var i in type.GetFields())
            {
                returnString += "Поля: " + i.Name + "\n";
            }

            returnString += "\n";

            foreach (var i in type.GetProperties())
            {
                returnString += "Свойства: " + i.Name + "\n";
            }

            returnString += "\n";

            foreach (var i in type.GetInterfaces())
            {
                returnString += "Интерфейсы: " + i.Name + "\n";
            }

            returnString += "\n";

            FileStream fileStream = null;
            using (fileStream = new FileStream("file.txt", FileMode.Create))
            {
                byte[] input = Encoding.Default.GetBytes(returnString);
                fileStream.Write(input, 0, input.Length);
                fileStream.Close();
            }
            Console.WriteLine(returnString);
        }

        public static object Create(T obj)
        {
            Type type = obj.GetType();
            return Activator.CreateInstance(type);                                                      // создание экземпляра типа(метод)
        }

    }
}
