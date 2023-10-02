// Please change the starting project in the solution to this project
// This program demostrate the use of thread pool
// Thread pool threads are background threads, so they are terminated when the main thread is terminated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ThreadPoolDemo
    {
        public static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Count);
            Console.WriteLine("Main Thread Started");
            Thread.Sleep(1000);
            // uncomment the following line to see the difference
            //Thread.Sleep(5000);
            Console.WriteLine("Main Thread Completed");
        }

        private static void Count(object state)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: " + i);
                Thread.Sleep(500);
                if (i == 10)
                    Console.WriteLine("Count Completed");
            }
        }
    }
}
