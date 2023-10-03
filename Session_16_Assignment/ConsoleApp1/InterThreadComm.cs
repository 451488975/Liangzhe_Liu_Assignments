// Please change the starting object to this file to run the program.
// This program demonstrates inter thread communication using AutoResetEvent class.
// Sender sends a signal to Receiver using AutoResetEvent class.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InterThreadComm
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");
            Thread t1 = new Thread(Sender)
            {
                Name = "Sender"
            };
            Thread t2 = new Thread(Receiver)
            {
                Name = "Receiver"
            };
            t1.Start();
            t2.Start();
            
            Console.WriteLine("Main Completed");
        }

        public static void Sender()
        {
            Console.WriteLine("Sender started");
            Console.WriteLine("Press enter to send a signal...");
            Console.ReadLine();
            autoResetEvent.Set();
            Console.WriteLine("Signal sent!");
            Console.WriteLine("Sender completed");
        }

        public static void Receiver()
        {
            Console.WriteLine("Receiver started");
            Console.WriteLine("Receiver is waiting for a signal...");
            autoResetEvent.WaitOne();
            Console.WriteLine("Receiver got a signal!");
            Console.WriteLine("Receiver Completed");
        }
    }
}
