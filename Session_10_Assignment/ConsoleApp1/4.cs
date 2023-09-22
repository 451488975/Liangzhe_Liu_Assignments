//// Please uncomment the code to run the program.
//// Write a C# program that implements a method that divides two numbers. Handle the DivideByZeroException that occurs if the denominator is 0.

//using System;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                // Read the numerator and denominator from the user
//                Console.Write("Enter the numerator: ");
//                double numerator = double.Parse(Console.ReadLine());
//                Console.Write("Enter the denominator: ");
//                double denominator = double.Parse(Console.ReadLine());
//                if (denominator == 0)
//                {
//                    throw new DivideByZeroException("The denominator cannot be 0.");
//                }
//                else
//                {
//                    // Divide the two numbers
//                    double result = numerator / denominator;
//                    // Print the result
//                    Console.WriteLine($"The result is: {result}.");
//                }
//            }
//            // Handle the DivideByZeroException that occurs if the denominator is 0
//            catch (DivideByZeroException e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}
