//// Please uncomment the code to run the program.
//// Write a C# program that reads a number from the user and calculates its square root. Handle the exception if the number is negative.

//using System;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Read a number from the user
//            Console.Write("Enter a number: ");
//            try
//            {
//                double number = double.Parse(Console.ReadLine());
//                // Handle the exception if the number is negative
//                if (number < 0)
//                {
//                    throw new Exception("Number cannot be negative.");
//                }
//                // Calculate the square root of the number
//                Console.WriteLine($"Square root of {number} is {Math.Sqrt(number)}.");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}
