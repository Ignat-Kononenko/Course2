using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentCollection students = new StudentCollection();

            Student e1 = new Student(1, "Petya", "-");
            Student e2 = new Student(2, "Vasya", "no");
            Student e3 = new Student(3, "Ivan", "ererkfkek");

            students.Add(e1);
            students.Add(e2);
            students.Add(e3);

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            students.Remove();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            Student stud = students.FindStudent(2);

            Console.WriteLine("Студент в списке: " + stud);

            students.Add(new Student(1, "Roma", "fe"));

            Console.WriteLine("New list:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();
            int key = 1;
            foreach(var student in students)
            {
                studentDictionary.Add(key++, student);
            }

            Console.WriteLine("Another collection: ");

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }


            Console.WriteLine("Есть ли данное id в Dictionary? - " + studentDictionary.Values.Any(s => s.Id == 3));

            ObservableCollection<Student> people = new ObservableCollection<Student>();

            people.CollectionChanged += PeopleCollectionChanged;

            people.Add(new Student(1, "Petya", "fegegeg"));
            people.Add(new Student(2, "Vasya", "fegjjjjegeg"));
            people.Add(new Student(1, "Ivan", "fegegeegeeghhg"));

            people.Remove(people[1]);

            people[0] = new Student(4, "Sasha", "another");

            Console.WriteLine("Текущий список: ");

            foreach (var student in people)
            {
                Console.WriteLine(student);
            }

            void PeopleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch(e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (e.NewItems?[0] is Student newStudent)
                            Console.WriteLine($"Добавлен новый объект: {newStudent.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldItems?[0] is Student oldStudent)
                            Console.WriteLine($"Удален объект: {oldStudent.Name}");
                        break;
                        case NotifyCollectionChangedAction.Replace:
                        if ((e.NewItems?[0] is Student replaceStudent) &&
                            (e.OldItems?[0] is Student replacePerson))
                            Console.WriteLine($"Объект {replacePerson} заменен объектом {replaceStudent}");
                        break;
                }
            }
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Student(int id, string name, string description) {
        
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, description: {Description}";
        }

    }

    public class StudentCollection : IEnumerable<Student> 
    { 

        public Queue<Student> listOfStudents = new Queue<Student>();

        
        public void Add(Student student) 
        {
            listOfStudents.Enqueue(student);
           
        }

        public Student Remove()
        {
            return listOfStudents.Dequeue();
        }

        public Student FindStudent(int id)
        {
            return listOfStudents.FirstOrDefault(x => x.Id == id);      // возвращает первый элемент
        }
        public IEnumerator<Student> GetEnumerator()     // итерировать по коллекции(метод GetEnumerator)
        { 
            return listOfStudents.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator() // Этот метод необходим для реализации интерфейса
        { 
           return GetEnumerator(); 
        }

    }

}
