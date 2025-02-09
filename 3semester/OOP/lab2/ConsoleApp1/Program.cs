using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Abiturient firstAbiturient = new Abiturient();
            firstAbiturient.Surname = "Ivanov";





            /*  Console.WriteLine("Введите фамилию:");*/
            Console.WriteLine("|     \t\t Журнал    ");
            Abiturient[] classmate = new Abiturient[2];    // массив объекта 
            classmate[0] = new Abiturient("Ivanov", "Ivan", "Ivanovich", "f", 2314, new int[] { 2, 5, 2 });
            classmate[1] = new Abiturient("Ivanov", "Petya", "Ivanovich", "ffef", 223314, new int[] { 6, 8, 4 });

            Abiturient.showList(classmate[0]);
            Abiturient.showList(classmate[1]);

            var student = new[]                            // анонимный тип(объект с некоторым набором свойств без определения класса)
            {
                new{Name = "Ivan", Marks = new int[] {2, 5, 2} },
                 new{Name = "Petya", Marks = new int[] {6, 8, 4} }
            };

           /* showL(student);*/

            Console.WriteLine("-----------Задание a-----------------");
            Console.WriteLine("Список студентов, которые имеют неудовлетворительные оценки:");

            for (int i = 0; i < classmate.Length; i++)
            {
               Abiturient.findBadMark(classmate[i]);
            }

            Console.WriteLine("-----------Задание b-----------------");
            Console.WriteLine("Список студентов, у которых сумма баллов выше заданной:");

            for (int i = 0; i < classmate.Length; i++)
            {
                Abiturient.findHighScore(classmate[i]);
            }


            
        }
    }

    public partial class Abiturient
    {
        private string surname, name, secondname, adress;          // закрытые поля 
        private int[] massiveOfMark= new int[100];
        private int telephone;

        public string Surname
        {
            get { return surname; }
            set 
            {
                int count = 0;
                for (int i = 0; i < surname.Length; i++)
                {
                    if (!Char.IsLetter(surname[i]) && surname[i] != '-')
                        count++;
                }
                if (count > 0)
                {
                    Console.WriteLine("В фамилии могут быть только буквы и тире");
                }
                else
                {
                    surname = value;
                }

            }
        }

        public string Name                                      // свойство
        {
            get { return name; }                                // Возвращает значение поля name
            set                                                 //  Устанавливает значение поля
            {
                int count = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    if (!Char.IsLetter(name[i]) && name[i] != '-')
                        count++;
                }
                if (count > 0)
                {
                    Console.WriteLine("В имени могут быть только буквы и тире");
                }
                else
                {
                    name = value;
                }

            }                              
        }

        public string Secondname
        {
            get { return secondname; }
            set
            {
                int count = 0;
                for (int i = 0; i < secondname.Length; i++)
                {
                    if (!Char.IsLetter(secondname[i]))
                        count++;
                }
                if (count > 0)
                {
                    Console.WriteLine("В отчестве может быть только буквы");
                }
                else
                {
                    secondname = value;
                }

            }
        }

        public int Telephone
        {
            get { return telephone; }
            set
            {
               if(telephone < 0)
                    Console.WriteLine("Номер телефона не может быть отрицательной");
                else
                   telephone  = value;

            }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public int[] MassiveOfMark
        {
            get { return massiveOfMark; }
            set {
                int count = 0;
             for(int i = 0; i < value.Length; i++)
                {
                    if (value[i] < 0)
                        count++;
                }
                if(count > 0)
                    Console.WriteLine("Оценка не может быть отрицательной");
                else
                    massiveOfMark = value;
            
            }
        }

        public readonly int ID;                                            //
        public const int minResultOfMark = int.MaxValue;                   //
        public const int maxResultOfMark = int.MinValue;

        public static void showList(Abiturient abiturient)
        {
            Console.WriteLine("________________________________________");
            Console.WriteLine("|     \t Информация о абитуриенте    ");
            Console.WriteLine($"| id: {abiturient.ID}");
            Console.WriteLine($"| Фамилия: {abiturient.surname}"); ;
            Console.WriteLine($"| Имя: {abiturient.name}");
            Console.WriteLine($"| Отчество: {abiturient.secondname}");
            Console.WriteLine($"| Адрес: {abiturient.adress}");
            Console.WriteLine($"| Телефон: {abiturient.telephone}");
            Console.Write("| Массив оценок: ");
            Console.WriteLine(string.Join(", ", abiturient.massiveOfMark));
        }

/*        public static void showL(dynamic student)
        {
            Console.WriteLine("________________________________________");
            Console.WriteLine("|     \t Информация о абитуриенте    ");
            Console.WriteLine($"| id: {student.ID}");
            Console.WriteLine($"| Фамилия: {student.surname}"); ;
            Console.WriteLine($"| Имя: {student.name}");
            Console.WriteLine($"| Отчество: {student.secondname}");
            Console.WriteLine($"| Адрес: {student.adress}");
            Console.WriteLine($"| Телефон: {student.telephone}");
            Console.Write("| Массив оценок: ");
            Console.WriteLine(string.Join(", ", student.massiveOfMark));
        }*/

        private static int numberOfObjects = 0;                         // статическое поле, хранящее количество созданных обЪектов 
        private static readonly Random rnd = new Random();

        public Abiturient(ref string s, string n, string sN, int[] m)      // конструктор с параметрами
        {
        
            ID = rnd.Next(1, 9999);
            surname = s;
            name = n;
            secondname = sN;
            adress = "Неизвестно";
            telephone = 0;
            massiveOfMark = m;

            numberOfObjects++;
        }

        // параметры по умолчанию
        public Abiturient(string surname = "не определен", string name = "не определен", string secondname = "не определен", string adress = "не определен", int telephone = 0, int[] mas = null) 
        {

            ID = rnd.Next(1, 9999);
            this.surname = surname;
            this.name = name;   
            this.secondname = secondname;
            this.adress = adress;
            this.telephone = telephone;
            this.massiveOfMark = mas ?? new int[0];
            
            numberOfObjects++;
        }
     
        public Abiturient()                                           // конструктор без параметров
        {
            ID = 234;
            surname = "Popov";
            name = "Nick";
            secondname = "Petrovich";
            adress = "Minsk";
            telephone = 42455;
            massiveOfMark = new int[]{ 5, 6, 4 };
            numberOfObjects++;
        }

        static Abiturient()                                          // статический конструктор(вызывается только один раз, он инициализирует статические члены и нет индификатора доступа)
        {
            
        }

        private Abiturient(int b)                                    // закрытый конструктор(нужно контролить создание объектов, внутри класса)
        {
            
        }

        public override bool Equals(object obj) {                   // переопределение(override) метода Equals
            if (obj == null || GetType() != obj.GetType())
                return false;

            Abiturient other = (Abiturient)obj;
            return ID == other.ID &&
                surname == other.surname &&
                name == other.name &&
                secondname == other.secondname &&
                adress == other.adress &&
                telephone == other.telephone &&
                massiveOfMark == other.massiveOfMark;
        }

        public override int GetHashCode() => telephone.GetHashCode();

        // Переопределение метода ToString
        public override string ToString()
        {
            return $"ID: {ID}, Фамилия: {surname}, Имя: {name}, Отчество: {secondname}, Адрес: {adress}, Телефон: {telephone}";
        }

        public static float countAverage(int[] marks)
        {
            int sum = 0, count = 0;
            float average;
            foreach (int mark in marks)
            {
                sum += mark;
                count++;
            }
            average = (float)sum / count;
            return average;
        }

        public static int findMax(int[] marks)
        {
            int maxMark = maxResultOfMark;

            foreach (int mark in marks)
            {
                if(mark > maxMark)
                {
                    maxMark = mark;
                }
            }

            return maxMark;
        }

        public static int findMin(int[] marks)
        {
            int minMark = minResultOfMark;

            foreach (int mark in marks)
            {
                if (mark > minMark)
                {
                    minMark = mark;
                }
            }
            return minMark;
        }


        public static void findBadMark(Abiturient abiturient)
        {
            int badMark = 3;

            foreach(int mark in abiturient.massiveOfMark)
            {
                if(mark <= badMark)
                {
                    Abiturient.showList(abiturient);
                    break;
                }
            }
        }

        public static void findHighScore(Abiturient abiturient)
        {
            int minScore = 10, sumOfScore = 0;

            foreach (int mark in abiturient.massiveOfMark)
            {
                sumOfScore += mark;
            }
            if (minScore <= sumOfScore)
            {
                Abiturient.showList(abiturient);
            }
        }

    }
}
