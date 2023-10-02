// Please change the starting project in the solution to this project
// This program demostrate the use of background threads
// Background threads are terminated when the main thread is terminated

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BackgoundThreadsDemo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            Thread t1 = new Thread(Count);
            Thread t2 = new Thread(BackgroundCount);
            t2.IsBackground = true;
            t1.Start();
            t2.Start();
            Console.WriteLine("Main Thread Completed");
        }

        private static void Count()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: " + i);
                Thread.Sleep(500);
                // uncomment the following line to see the difference
                //Thread.Sleep(501);
                if (i == 10)
                    Console.WriteLine("Count Completed");
            }
        }
        private static void BackgroundCount()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Background: " + i);
                Thread.Sleep(1000);
                if (i == 10)
                    Console.WriteLine("Background Count Completed");
            }
        }
    }
}
