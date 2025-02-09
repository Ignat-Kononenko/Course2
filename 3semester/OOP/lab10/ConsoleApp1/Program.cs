using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


            int n = 4;

            var selectedMonth = from month in months            // передаем каждый элемент из months в переменную month
                                where month.Length == n
                                select month;
            Console.WriteLine(selectedMonth.GetType());
            Console.WriteLine("Месяц(ы) с длиной строки равной " + n + ":");
            foreach (var month in selectedMonth)
            {
                Console.WriteLine(month);
            }

            var allWinterAndSummerMonths = from month in months
                                      
                                           where   month == "December"  || month == "January" ||  month == "February" || month == "June" || month == "July" || month == "August" 
                                           select month;

            Console.WriteLine("Зимние и(или) летние mесяц(ы): ");
            foreach (var month in allWinterAndSummerMonths)
            {
                Console.WriteLine(month);
            }


            var sortedMonth = from month in months
                                            
                                           orderby month descending
                                           select month;

            Console.WriteLine("Сортированные mесяц(ы): ");
            foreach (var month in sortedMonth)
            {
                Console.WriteLine(month);
            }

            var UMonth = from month in months
                                           where month.Contains('u') && month.Length >= n
                                           select month;

            Console.WriteLine("Mесяц(ы) с 'u' и не менее 4 символа: ");
            foreach (var month in UMonth)
            {
                Console.WriteLine(month);
            }

            List<Abiturient> abiturients = new List<Abiturient>()
            {
                new Abiturient(1, "Ivanov", "Ivan", "Ivanovich", "Minsk", "+4231554", new int[] { 5, 7, 8, 4, 8 }, 1),
                new Abiturient(2, "Petrov", "Petr", "Ivanovich", "Minsk", "+4231555", new int[] { 8, 5, 2, 8, 8 }, 2),
                new Abiturient(3, "Vasiliev", "Vasya", "Ivanovich", "Minsk", "+4234554", new int[] { 5, 7, 8, 4, 8 }, 3),
                new Abiturient(4, "Popov", "Dmitry", "Ivanovich", "Minsk", "+4231654", new int[] { 4, 4, 4, 6, 8 }, 2),
                new Abiturient(5, "Smirnov", "Ivan", "Ivanovich", "Moscow", "+4231354", new int[] { 6, 7, 8, 3, 8 },1),
                new Abiturient(6, "Nikolaev", "Vadim", "Ivanovich", "Minsk", "+4221554", new int[] { 8, 8, 8, 4, 8 },2),
                new Abiturient(7, "Fedorov", "Ilya", "Ivanovich", "Minsk", "+4231555", new int[] { 5, 7, 5, 6, 7 },3),
                new Abiturient(8, "Semenov", "Danila", "Ivanovich", "Minsk", "+4231354", new int[] { 6, 6, 7, 7, 10 }, 1),
                new Abiturient(9, "Kuleshov", "Sasha", "Ivanovich", "Minsk", "+4231654", new int[] { 6, 4, 5, 6, 8 },2),
                new Abiturient(10, "Tarasevich", "Ivan", "Ivanovich", "Minsk", "+5431554", new int[] { 6, 6, 6, 4, 8 }, 3),
            };

            var highAverageScoreAbiturients = from abiturient in abiturients                    // оператор запроса
                                              where abiturient.CalculateAvarageGrade() > 6 
                                              select abiturient; 
            Console.WriteLine("Абитуриенты с средним баллом выше 4:"); 
            foreach (var abiturient in highAverageScoreAbiturients)
            {
                Console.WriteLine(abiturient);
            }

            var lowAverageScoreAbiturients = abiturients.Where(a => a.FindMin() <= 5);          // метод расширения LINQ

            Console.WriteLine("Абитуриенты с средним баллом ниже 5:");
            foreach (var abiturient in lowAverageScoreAbiturients)
            {
                Console.WriteLine(abiturient);
            }

            var studetsWithBadMarks = from abiturient in abiturients
                                      where abiturient.FindMin() <= 4
                                      select abiturient;

            Console.WriteLine("Абитуриенты, у которых оценка ниже 4:");
            foreach (var abiturient in studetsWithBadMarks)
            {
                Console.WriteLine(abiturient);
            }

            var studentsWithHigherSum = from abiturient in abiturients
                                        where abiturient.CalculateSumGrade() > 33
                                        select abiturient;

            Console.WriteLine("Абитуриенты, у которых сумма оценок больше 33:");
            foreach (var abiturient in studentsWithHigherSum)
            {
                Console.WriteLine(abiturient);
            }

            var studentsWithHigherMark = from abiturient in abiturients
                                        where abiturient.FindMax() > 9
                                        select abiturient;

            Console.WriteLine("Абитуриенты, у которых оценка 10:");
            foreach (var abiturient in studentsWithHigherMark)
            {
                Console.WriteLine(abiturient);
            }

            var studentsOrderedByName = abiturients.OrderBy(a => a.Surname).ThenBy(a => a.Name).ToArray(); 
            Console.WriteLine("Абитуриенты, упорядоченные по алфавиту:"); 
            foreach (var student in studentsOrderedByName) { 
                Console.WriteLine(student); 
            }

            var studentsWithLowestPerformance = abiturients.OrderBy(a => a.CalculateAvarageGrade()).Take(4); 
            Console.WriteLine("\n4 последних абитуриента с самой низкой успеваемостью:"); 
            foreach (var student in studentsWithLowestPerformance) 
            { 
                Console.WriteLine(student); 
            }

            var query = abiturients.Where(a => a.CalculateAvarageGrade() > 4) .GroupBy(a => a.Address).Select(group => new { City = group.Key, Abiturients = group .OrderByDescending(a => a.CalculateSumGrade()).Take(5), MaxTotalGrade = group.Max(a => a.CalculateSumGrade()),  MinTotalGrade = group.Min(a => a.CalculateSumGrade())}) .Where(result => result.Abiturients.Any()).ToList();

            Console.WriteLine("Результаты сложного запроса:"); 
            foreach (var group in query) 
            { 
                Console.WriteLine($"\nГород: {group.City}"); 
                Console.WriteLine($"Максимальная сумма баллов: {group.MaxTotalGrade}"); 
                Console.WriteLine($"Минимальная сумма баллов: {group.MinTotalGrade}"); 
                foreach (var abiturient in group.Abiturients) 
                { 
                    Console.WriteLine(abiturient); 
                } 
            }

            List<Course> courses = new List<Course> { 
                new Course(1, "Mathematics"), 
                new Course(2, "Physics"), 
                new Course(3, "Chemistry") 
            };

            var abiturientsWithCourses = from abiturient in abiturients 
                                         join course in courses on abiturient.CourseId equals course.CourseId 
                                         select new { AbiturientName = $"{abiturient.Name} {abiturient.Surname}", 
                                             abiturient.Address, 
                                             CourseName = course.CourseName, 
                                             TotalGrade = abiturient.CalculateSumGrade() 
                                         }; 
            Console.WriteLine("Абитуриенты и их курсы:"); 
            foreach (var item in abiturientsWithCourses) 
            { 
                Console.WriteLine($"Name: {item.AbiturientName}, Address: {item.Address}, Course: {item.CourseName}, Total Grade: {item.TotalGrade}"); 
            }
        }
    }

    public class Abiturient
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int[] Grades { get; set; }
        public int CourseId { get; set; }

        public Abiturient(int id, string name, string secondname, string surname, string address, string phone, int[] grades, int courseId)
        {

            Id = id;
            Name = name;
            SecondName = secondname;
            Surname = surname;
            Address = address;
            Phone = phone;
            Grades = grades;
            CourseId = courseId;
        }

        public double CalculateAvarageGrade()
        {
            return Grades.Average();
        }

        public int CalculateSumGrade() 
        {
            return Grades.Sum();
        }

        public  int FindMax()
        {
            return Grades.Max();
        }

        public int FindMin()
        {
            return Grades.Min();
        }

        public override string ToString()
        {
            return $"ID: {Id}, Surname: {Surname}, Name: {Name}, SecondName: {SecondName}, Address: {Address}, Phone: {Phone}, Average Grade: {CalculateAvarageGrade()}";
        }


    }

    public class Course 
    {
        public int CourseId { get; set; } 
        public string CourseName { get; set; } 
        public Course(int courseId, string courseName) 
        { 
            CourseId = courseId; 
            CourseName = courseName; 
        }
        public override string ToString() 
        { 
            return $"CourseId: {CourseId}, CourseName: {CourseName}"; 
        } 
    }
}
