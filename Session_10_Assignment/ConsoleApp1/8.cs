//// Please uncomment the code to run the program.
//// Write a C# program that creates a method that calculates the factorial of a given number. Handle the OverflowException that occurs if the result exceeds the Int32 maximum value.

//using System;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter a number: ");
//            try
//            {
//                int number;
//                bool flag = int.TryParse(Console.ReadLine(), out number);
//                if (number < 0)
//                {
//                    throw new Exception("Number cannot be negative");
//                }
//                if (!flag)
//                {
//                    throw new Exception("Input must be a number.");
//                }
//                long f = 1;
//                for (int i = 1; i <= number; i++)
//                {
//                    f *= i;
//                    if (f > Int32.MaxValue)
//                    {
//                        throw new OverflowException("Factorial exceeds Int32 maximum value.");
//                    }
//                }
//                Console.WriteLine($"Factorial of {number} is {f}.");
//            }
//            catch (OverflowException e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}
