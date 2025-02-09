using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Warrior warrior1 = new Warrior("ff", 100);
            Healer healer1 = new Healer("fg", 100);

            game.AttackEvent += warrior1.OnAttack;
            game.AttackEvent += healer1.OnAttack;
            game.HealEvent += warrior1.OnHeal;
            game.HealEvent += healer1.OnHeal;

            List<GameObject> gameObjects = new List<GameObject> { warrior1, healer1 };
            PrintStatuses(gameObjects);

            Console.WriteLine("Нанесено урона - 20");
            game.Attack(20);
            PrintStatuses(gameObjects);

            Console.WriteLine("Прибавлено урона - 14");
            game.Heal(14);
            PrintStatuses(gameObjects);

            Func<string, string>[] processors = new Func<string, string>[]  // Объявляем массив Func<string, string>
            {
                RemovePunction,
                input => AddSymbol(input,'!'),
                ToUpperCase,
                RemoveExtraSpaces
            };
            string text = "Hello, world! Welcome* to the C# programming."; // Обрабатываем строку всеми методами
           
            foreach(var processor in processors)
            {
                text = processor(text);
            }
            Console.WriteLine(text);
        
            Action<string> print = s => Console.WriteLine($"Processed string: {s}"); // one param(void)

            Predicate<string> containsAsterisk = s => s.Contains('!');              // true/false
            print(text);
            if (containsAsterisk(text)) { 
                Console.WriteLine("Строка содержит символ '!'");
            } 
            else {
                Console.WriteLine("Строка не содержит символ '!'");
            }
        }
        static void PrintStatuses(List<GameObject> gameObjects)
        {
           gameObjects.ForEach(obj => obj.PrintStatus());   
        }

        static string RemovePunction(string input)
        {
            return new string(input.Where(c=> !char.IsPunctuation(c)).ToArray());
        }
        static string AddSymbol(string input, char symbol)
        {
            return input + symbol;
        }
        static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }
        static string RemoveExtraSpaces(string input)
        {
            return string.Join(" ", input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
    }

 

    public delegate void XP(int value);
    public class Game
    {
        public event XP AttackEvent;
        public event XP HealEvent;
        public void Attack(int damage)
        {
           AttackEvent?.Invoke(damage);     // вызываем метод(если не null) безопасно
        }
        public void Heal(int amount)
        {
            HealEvent?.Invoke(amount);
        }
    }

    public abstract class GameObject
    {

        public string Name { get; set; }
        public int Health { get; set; }

        public GameObject(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void OnAttack(int damage)
        {
            HandleAttack(damage);
        }

        public void OnHeal(int amount)
        {
            HandleHeal(amount);
        }

        protected abstract void HandleAttack(int damage);
        protected abstract void HandleHeal(int amount);
        public void PrintStatus() { 
            Console.WriteLine($"{Name} имеет {Health} единиц здоровья.");
        }
    }

    public class Warrior : GameObject
    {
        public Warrior(string name, int health):base(name, health) { }

        protected override void HandleAttack(int damage)
        {
            Health -= damage;

        }

        protected override void HandleHeal(int amount)
        {
            Health += amount;
          
        }


    }

    public class Healer : GameObject
    {
        public Healer(string name, int health) : base(name, health) { }

        protected override void HandleAttack(int damage)
        {
            Health -= damage / 2;
            Console.WriteLine($"{Name} отрaзил половину урона");
        }

        protected override void HandleHeal(int amount)
        {
            Health += amount * 2;
            Console.WriteLine($"{Name} прибавил в два раза здоровья");
        }

    }
    

}
