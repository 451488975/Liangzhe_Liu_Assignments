// Question: Adv or disadvantages of arrays
// Advantages:
// 1. Efficient access to elements, time complexity to access is O(1) regardless of the size of the array
// 2. Efficient memory usage, no overhead for storing elements
// 3. Cache friendly, elements are stored contiguously in memory
// 4. Easy to implement and use, compatible with most hardware platforms
//
// Disadvantages:
// 1. Fixed size, cannot be resized
// 2. Insertion and deletion is expensive, time complexity is O(n) as elements need to be shifted
// 3. Wastage of memory, if the array is not full and elements are inserted at the end, unused memory is wasted
// 4. Limited data type, all elements must be of the same type

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ArrayListDemo
    {
        public static void Main(string[] args)
        {
            // ArrayList with Fixed Size
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            ArrayList fixedSizeArrayList = ArrayList.FixedSize(arrayList);
            // fixedSizeArrayList.Add(4); // throws NotSupportedException
            Console.WriteLine($"arrayList is fixed size: {arrayList.IsFixedSize}");
            Console.WriteLine($"fixedSizeArrayList is fixed size: {fixedSizeArrayList.IsFixedSize}");
            Console.WriteLine($"fixedSizeArrayList capacity: {fixedSizeArrayList.Capacity}, Count: {fixedSizeArrayList.Count}");
            Console.WriteLine();

            // AddRange(ICollection)
            ArrayList arrayList1 = new ArrayList();
            arrayList1.Add(1);
            arrayList1.Add(2);
            arrayList1.Add(3);
            ArrayList arrayList2 = new ArrayList();
            arrayList2.Add(4);
            arrayList2.Add(5);
            arrayList2.Add(6);
            Console.WriteLine($"Before AddRange(), arrayList1 capacity: {arrayList1.Capacity}, Count: {arrayList1.Count}");
            arrayList1.AddRange(arrayList2);
            Console.WriteLine($"After AddRange(), arrayList1 capacity: {arrayList1.Capacity}, Count: {arrayList1.Count}");
            Console.WriteLine();

            // BinarySearch(Int32, Int32, Object, IComparer)
            ArrayList array1 = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                array1.Add(i);
            }
            Console.WriteLine("Find 5 in the ArrayList of 1 through 10");
            Console.WriteLine("The result is: " + array1.BinarySearch(0, array1.Count, 5, null));
            Console.WriteLine();

            // Clone() prove that it creates a shallow copy
            ArrayList target = new ArrayList();
            target.Add(1);
            target.Add(2);
            target.Add(3);
            ArrayList shallowCopy = (ArrayList)target.Clone();
            Console.WriteLine($"target capacity: {target.Capacity}, Count: {target.Count}");
            Console.WriteLine($"shallowCopy capacity: {shallowCopy.Capacity}, Count: {shallowCopy.Count}");
            target.Add(4);
            Console.WriteLine($"After adding 4 to target, target capacity: {target.Capacity}, Count: {target.Count}");
            Console.WriteLine($"After adding 4 to target, shallowCopy capacity: {shallowCopy.Capacity}, Count: {shallowCopy.Count}");
            Console.WriteLine($"Reference equals: {Object.ReferenceEquals(target, shallowCopy)}");
            Console.WriteLine();

            // Sort(Int32, Int32, IComparer)
            ArrayList arr = new ArrayList();
            arr.Add(1);
            arr.Add(1);
            arr.Add(4);
            arr.Add(5);
            arr.Add(1);
            arr.Add(4);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            arr.Sort(0, arr.Count, new MyComparer());
            Console.WriteLine("After sorting");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public class MyComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return (int)x - (int)y;
            }
        }
    }
}
