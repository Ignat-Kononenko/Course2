using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MySet<string> set1 = new MySet<string>(new[] { "apple", "banana", "orange" });
            Console.WriteLine(set1);

            MySet<string> set2 = new MySet<string>(new[] { "banana", "carrot" });
            Console.WriteLine(set2);

            Console.WriteLine($"Является ли set2 подмножеством set1? - {set1 > set2}");
            Console.WriteLine($"Проверка на неравенства set2 и set1? - {set1 != set2}");
            Console.WriteLine($"Пересекаются ли множества set2 и set1 - {set1 % set2}");

            set1 = set1 <= "nut";
            Console.WriteLine(set1);

            set2 = set2 >= "carrot";
            Console.WriteLine(set2);

            Console.WriteLine($"Является ли set2 подмножеством set1? - {set1 > set2}");
            Console.WriteLine($"Проверка на неравенства set2 и set1? - {set1 != set2}");
            Console.WriteLine($"Пересечение множеств set2 и set1 - {set1 % set2}");

            Console.WriteLine("Короткое слово - " + StaticOperation.FindShortestWord(set1));
    
            string sentence = "This is a sample sentence";
            Console.WriteLine("Короткое слово: " + sentence.FindShortestWord());

            MySet<string> sortedSet1 = set1.SortSet();
            Console.WriteLine("Упорядоченный set1: " + sortedSet1);

            var prods = new Production(1, "fe");
            Console.WriteLine(prods);


            Console.WriteLine("Количество элементов - " + StaticOperation.CountElements(set1));
            Console.WriteLine("Разница - " + StaticOperation.Difference(set1));
        }
    }
        public class MySet<T>
        {
            private HashSet<T> elements;

            public HashSet<T> Elements                                                        // Публичное свойство для доступа elements
            {
                get { return elements; }
            }
            public MySet()
            {
                elements = new HashSet<T>();
            }

            public MySet(IEnumerable<T> items)
            {
                elements = new HashSet<T>(items);
            }

            
            public static MySet<T> operator >=(MySet<T> set, T item)                          // Перегрузка оператора >= для удаления элемента из множества
            {
                set.elements.Remove(item);
                return set;
            }

            
            public static MySet<T> operator <=(MySet<T> set, T item)                          // Перегрузка оператора <= для добавления элемента в множество
            {
                set.elements.Add(item);
                return set;
            }

            public static bool operator >(MySet<T> set1, MySet<T> set2)
            {
                return set2.elements.IsSubsetOf(set1.elements);
            }

            public static bool operator <(MySet<T> set1, MySet<T> set2)
            {
                return !set2.elements.IsSubsetOf(set1.elements);
            }

            public static bool operator !=(MySet<T> set1, MySet<T> set2)
            {
                return !set2.elements.SetEquals(set1.elements);
            }

            public static bool operator ==(MySet<T> set1, MySet<T> set2)
            {
                return set2.elements.SetEquals(set1.elements);
            }

            public static MySet<T> operator %(MySet<T> set1, MySet<T> set2)
            {
                MySet<T> result = new MySet<T>();

                foreach (T item in set1.elements)
                {
                    if (set2.elements.Contains(item))
                    {
                        result.elements.Add(item);
                    }
                }
                return result;
            }

            public override string ToString()                                                // Метод для удобного вывода содержимого множества
            {
                return $"{{ {string.Join(", ", elements)} }}";
            }
            public Production prod = new Production(10,"jon");                               // Вложенный объект
            public void DisplayProduction()
            {
                Console.WriteLine(prod.ToString());
            }
            public class Developer
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Department { get; set; }
                public Developer  (int id, string name, string department)
                {
                    Id=id;
                    Name = name;
                    Department = department;
                }
                public override string ToString()
                {
                    return $"Production ID: {Id}, Name: {Name}, Organization: {Department}";
                }
            }
        }

        public class Production                                                          
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Production(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public override string ToString()
            {
                return $"Production ID: {Id}, Name: {Name}";
            }
        }
        public  class StaticOperation
        {
            public static int Sum(MySet<string> set)
            {
                return set.Elements.Count;
            }

            public static int Difference(MySet<string> set)
            {
               if(!set.Elements.Any()) {  return 0; }
                var lengths = set.Elements.Select(e => e.Length);
                return lengths.Max() - lengths.Min();
            }

            public static int CountElements(MySet<string> set)
            {
                return set.Elements.Count;
            }

            public static string FindShortestWord(MySet<string> set)
            {
                return set.Elements.OrderBy(e => e.Length).FirstOrDefault();                   // OrderBy - сортировка по возрастанию , FirstOrDefault - возвращает первый элемент
            }


        }

        public static class StaticOperationExtensions
        {
            public static string FindShortestWord(this string str)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return string.Empty;
                }
                var words = str.Split(' ');
                return words.OrderBy(e => e.Length).FirstOrDefault();
            }
            public static MySet<string> SortSet(this MySet<string> set)
            {
                var sortedElements = new MySet<string>(set.Elements.OrderBy(e => e));       // по возрастанию
                return sortedElements;
            } 
        }
    
}
