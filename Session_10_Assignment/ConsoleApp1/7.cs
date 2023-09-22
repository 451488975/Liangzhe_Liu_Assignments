//// Please uncomment the code to run the program.
//// Write a C# program that creates a method that takes a string as input and converts it to uppercase. Handle the NullReferenceException that occurs if the input string is null.

//using System;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter a string: ");
//            string input = Console.ReadLine();
//            try
//            {
//                if (input == null)
//                {
//                    throw new NullReferenceException("Input string cannot be null.");
//                }
//                Console.WriteLine(input.ToUpper());
//            }
//            catch (NullReferenceException e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}

//// Question: How to input a null string in console?