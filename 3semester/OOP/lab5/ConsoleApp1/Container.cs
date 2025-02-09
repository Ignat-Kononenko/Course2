using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Container<T> 
    {
        private List<T> items = new List<T>();      

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public T Get(int index)
        {
            return items[index];
        }

        public void Set(int index, T item)
        {
            items[index] = item;
        }

        public void DisplayAll()
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
        public List<T> Items => items;
    }
}
