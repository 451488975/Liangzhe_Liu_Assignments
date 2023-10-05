using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_17_Assignment
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //1.Add a extension fn to ArrayList for implementing Memberwise clone.
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.Write("list: ");
            foreach (var item in list)
            {
                
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
            ArrayList newList = list.MemberwiseClone();
            Console.Write("new list: ");
            foreach (var item in newList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            //2. Demo for SyncRoot
            ArrayList list1 = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                list1.Add(i);
            }
            lock(list1.SyncRoot)
            {
                foreach (var item in list1)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine("\n");
            }

            //3. IComparer
            string[] names = { "Zebra", "Rabbit", "Tiger", "Cat", "Dog", "Horse"};
            Console.Write("Before sorting: ");
            foreach (var item in names)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
            Array.Sort(names, new ReverseSort());
            Console.Write("After sorting: ");
            foreach (var item in names)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            //4. IComparable
            Employee[] employees = new Employee[3];
            employees[0] = new Employee() { Id = 11, Name = "A" };
            employees[1] = new Employee() { Id = 45, Name = "B" };
            employees[2] = new Employee() { Id = 14, Name = "C" };
            Console.WriteLine("Before sorting: ");
            foreach (var item in employees)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
            }
            Console.WriteLine();
            Array.Sort(employees);
            Console.WriteLine("After sorting: ");
            foreach (var item in employees)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
            }
        }
    }

    public static class ArrayListExtension
    {
        public static ArrayList MemberwiseClone(this ArrayList list)
        {
            ArrayList newList = new ArrayList();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }
    }

    public class ReverseSort : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }

    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(Employee other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
