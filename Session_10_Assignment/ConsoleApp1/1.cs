//// Please uncomment the code to run the program.
//// Write a C# program that implements a method that takes an array of integers as input and calculates the average value. Handle the exception if the array is empty.

//using System;

//namespace ConsoleApp1
//{
//    class EmptyArrayException : Exception
//    {
//        public EmptyArrayException(string message) : base(message) { }
//    }
//    class Program
//    {
//        // Takes an array of integers as input and calculates the average value.
//        static double ave(int[] nums)
//        {
//            // Handle the exception if the array is empty.
//            if (nums.Length == 0)
//            {
//                throw new EmptyArrayException("Array is empty.");
//            }

//            double sum = 0;
//            foreach (int num in nums)
//            {
//                sum += num;
//            }

//            return sum / nums.Length;
//        }

//        static void Main(string[] args)
//        {
//            try
//            {
//                // Test the method
//                int[] nums = { 1, 3, 5, 7, 9 };
//                Console.WriteLine(ave(nums));
//                // Test the exception
//                nums = new int[0];
//                Console.WriteLine(ave(nums));
//            }
//            catch (EmptyArrayException e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}
