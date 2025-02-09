using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Controller
    {
        private Container<Technic> container = new Container<Technic>();

        public void AddTechnic(Technic technic)
        {
            container.Add(technic);
        }

        public void RemoveTechnic(Technic technic)
        {
            container.Remove(technic);
        }
        public List<Technic> GetTechnicOlderThan(int year) 
        {
            return container.Items.Where(t => t.Lf.Year > year).ToList();
        }

        public Dictionary<TechnicType, int> GetTechnicCountsByType()                                // словарь
        {
            return container.Items.GroupBy(t =>t.Type).ToDictionary(g => g.Key, g => g.Count());
        }

        public List<Technic> GetTechnicSortedByPrice()
        {
            return container.Items.OrderByDescending(t => t.Price).ToList();                        // сортирует элементы последовательности в порядке убывания.
        }

        public int TotalPrice()
        {
            return container.Items.Sum(t => t.Price);
        }
        
        
        public void DisplayAllTechnic()
        {
            container.DisplayAll();
        }
    }
}
