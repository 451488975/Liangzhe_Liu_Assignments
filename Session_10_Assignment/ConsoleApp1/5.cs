//// Please uncomment the code to run the program.
//// Write a C# program that creates a method that reads a date from the user in the format "dd/mm/yyyy" and converts it to a DateTime object. Handle an exception if the input format is invalid.

//using System;
//using System.Globalization;

//namespace ConsoleApp1
//{
//    class FormatException : Exception
//    {
//        public FormatException(string message) : base(message) { }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Read a date from the user
//            Console.Write("Enter date in format dd/mm/yyyy: ");
//            string date = Console.ReadLine();
//            DateTime dateTime = new DateTime();
//            // Try to convert the input to a DateTime object
//            try
//            {
//                bool flag = DateTime.TryParseExact(
//                    date, "dd/MM/yyyy",
//                    new CultureInfo("en-US"),
//                    DateTimeStyles.None,
//                    out dateTime
//                );
//                // Handle an exception if the input format is invalid
//                if (!flag)
//                {
//                    throw new FormatException("Invalid date format.");
//                }
//                Console.WriteLine($"The datetime you entered is {dateTime}.");
//            }
//            catch (FormatException e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}
