//// Please uncomment the code to run the program.
//// Write a C# program that reads a list of integers from the user. Handle the exception that occurs if the user enters a value outside the range of Int32.

//using System;

//namespace ConsoleApp1
//{
//    class OutOfRangeException : Exception
//    {
//        public OutOfRangeException(string message) : base(message) { }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Create a list of 5 numbers waiting for user input
//            int[] numbers = new int[5];
//            for (int i = 0; i < numbers.Length;)
//            {
//                try
//                {
//                    // Read a number from the user
//                    Console.Write("Enter a number: ");
//                    int number;
//                    bool flag = Int32.TryParse(Console.ReadLine(), out number);
//                    if (!flag)
//                    {
//                        throw new OutOfRangeException("The input is outside the range of Int32, please re-enter the number.");
//                    }
//                    numbers[i] = number;
//                    i++;
//                }
//                // Handle the exception if the user enters a value outside the range of Int32
//                catch (OutOfRangeException e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//            // Print the list
//            Console.WriteLine("The list is: " + string.Join(", ", numbers));
//        }
//    }
//}
