using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Assignment
    {
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        private static string message;
        private static readonly object thisLock = new object();
        private static readonly object thatLock = new object();
        private static int count = 0;
        private static Semaphore semaphore = new Semaphore(0, 2);
        private static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            //Q. What are the Thread and Process?
            //A. A process is a program in execution. A thread is a unique execution path of a program.

            //Q. What is the difference between Process and Thread?
            //A. Every process has at least one thread. Threads are used to execute code concurrently within a process.

            //Q. Why do we need Multi-threading in our project?
            //A. Multi-threading can help us to improve the performance of out project by utilizing the available recouces more efficiently.

            //Q. What are the advantages and disadvantages of multithreading in C#?
            //A. Advantages:
            //   1. Improved responsiveness
            //   2. Better resource utilization
            //   3. Simplified program design
            //   4. Improved scalability
            //   Disadvantages:
            //   1. Increased complexity
            //   2. Synchronization overhead
            //   3. Debugging and testing is difficult
            //   4. Deadlocks

            //Q. How can we create a Thread in C#?
            Thread thread = new Thread(ThreadMethod);
            thread.Start();

            //Q. Why does a delegate need to be passed as a parameter to the Thread class constructor?
            //A. A delegate is a type that represents a reference to a method with a specific signature.
            //   It is used to encapsulate a method, and it can be passed as an argument to other methods or constructors. 
            //   A delegate specifies the method that will be executed on the thread.

            //Q. How to pass parameter in Thread?
            Thread th = new Thread(ThreadMethodWithParameter);
            th.Start(10);

            //Q. Why do we need a ParameterizedThreadStart delegate?
            //A. The ParameterizedThreadStart delegate is used to represent a method that takes an object as a parameter and returns void.

            //Q. When to use ParameterizedThreadStart over ThreadStart delegate?
            //A. The ParameterizedThreadStart delegate is used when you want to pass data to the method that will be executed on the thread.

            //Q. How to pass data to the thread function in a type-safe manner?
            //A. By using the ParameterizedThreadStart delegate.

            //Q. How to retrieve the data from a thread function?
            Thread t = new Thread(ThreadMethodRetrieve);
            t.Start();
            autoResetEvent.WaitOne();
            Console.WriteLine(message);

            //Q. What is the difference between Threads and Tasks?
            //A. Threads are used to execute code concurrently within a process. They are managed by the operating system and can be expensive to create and maintain.
            //   Tasks are lightweight objects that are used to execute code asynchronously. They are managed by the Task Scheduler and are less expensive to create and maintain.
            Task task = Task.Run(() => Console.WriteLine("Task is running...\n"));
            task.Wait();

            //Q. What is the Significance of Thread.Join and Thread.IsAlive functions in multithreading?
            //A. Thread.Join and Thread.IsAlive are used in to check whther a thread has finished its execution or not.
            //   Thread.Join method is used to wait for a thread to complete its execution. When you call the Join method on a thread instance, the calling thread is blocked until the specified thread has completed its work.
            //   Thread.IsAlive method is used to check whether a thread is still running or has completed its execution. When you call the IsAlive method on a thread instance, it returns true if the thread is still running, and false if the thread has completed its work.
            t.Join();
            if (t.IsAlive)
                Console.WriteLine("Thread is still running...\n");
            else
                Console.WriteLine("Thread has completed its execution...\n");

            //Q. What happens if shared resources are not protected from concurrent access in a multithreaded program?
            //A. If shared resources are not protected from concurrent access, the output or behavior of the program can become inconsistent.
            //   This is because multiple threads can access and modify the shared resources at the same time, leading to race conditions.
            //   A race condition occurs when two or more threads try to access and modify the same shared resource simultaneously, and the order in which they do so is unpredictable.
            //   As a result, the final state of the shared resource depends on the order in which the threads execute, which can lead to incorrect or unexpected results.

            //Q. How do protect shared resources from concurrent access?
            ModifyMessage();
            Console.WriteLine(GetMessage());

            //Q. What are the Interlocked functions?
            //A. The Interlocked class provides atomic operations for variables that are shared by multiple threads.
            //   These operations are performed in a thread-safe manner, and they are used to synchronize access to shared resources.
            //   The Interlocked class provides the following functions:
            //   1. Add
            //   2. CompareExchange
            //   3. Decrement
            //   4. Exchange
            //   5. Increment
            //   6. Read
            //   7. Write
            IncrementCount();
            Console.WriteLine($"Count after increment: {GetCount()}\n");
            DecrementCount();
            Console.WriteLine($"Count after decrement: {GetCount()}\n");

            //Q. What is a Lock?
            //A. A lock is a synchronization mechanism that is used to ensure that only one thread can access a shared resource at a time.

            //Q. What is the Difference between Monitor and lock in C#?
            //A. Both Monitor and lock are used to provide thread safety in a multithreaded application.
            //   The lock statement is a syntactic shortcut for the Monitor class. Here are the differences between them:
            //   1. Exception handling: The lock statement internally wraps the Enter and Exit methods in a try-finally block with exception handling, while the Monitor class requires you to use try-finally blocks explicitly to release locks properly.
            //   2. Fine-tuning: The Monitor class provides more control over the synchronization of various threads trying to access the same lock of code than the lock statement.
            //   3. Usage: The lock statement is the option for basic usage, while the Monitor class is better for more complex synchronization scenarios.
            IncrementCountWithLock();
            Console.WriteLine($"Count after increment with lock: {GetCount()}\n");
            IncrementCountWithMonitor();
            Console.WriteLine($"Count after increment with monitor: {GetCount()}\n");

            //Q. Explain why and how a deadlock can occur in multithreading with an example?
            //A. Deadlock is a situation that occurs when two or more threads are blocked, each waiting for the other to release a lock.
            //new Thread(() =>
            //{
            //    lock (thisLock)
            //    {
            //        Thread.Sleep(1000);
            //        lock (thatLock) { }
            //    }
            //}).Start();
            //lock (thatLock)
            //{
            //    Thread.Sleep(1000);
            //    lock (thisLock) { }
            //}
            //Deadlock would occur when the above code is running.

            //Q. How to resolve a deadlock in a multithreaded program?
            new Thread(() =>
            {
                if (Monitor.TryEnter(thisLock, 3000))
                {
                    try
                    {
                        Thread.Sleep(1000);
                        if (Monitor.TryEnter(thatLock, 3000))
                        {
                            try
                            {
                                Console.WriteLine("Both locks are acquired...\n");
                            }
                            finally
                            {
                                Monitor.Exit(thatLock);
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(thisLock);
                    }
                }
            }).Start();

            if (Monitor.TryEnter(thatLock, 3000))
            {
                try
                {
                    Thread.Sleep(1000);
                    if (Monitor.TryEnter(thisLock, 3000))
                    {
                        try
                        {
                            Console.WriteLine("You would not see this message because of Deadlock");
                        }
                        finally
                        {
                            Monitor.Exit(thisLock);
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(thatLock);
                }
            }

            //Q. What is AutoResetEvent and how it is different from ManualResetEvent?
            //A. AutoResetEvent and ManualResetEvent are two synchronization primitives that are used to coordinate the execution of multiple threads.
            //   The main difference between the two is that an AutoResetEvent resets automatically to an unsignaled state after releasing a single waiting thread,
            //   whereas a ManualResetEvent does not reset automatically and stays in a signaled state until the Reset() method is called.
            Thread autoThread = new Thread(AutoMethod);
            autoThread.Start();
            Thread.Sleep(1000);

            Thread manualThread = new Thread(ManualMethod);
            manualThread.Start();
            Thread.Sleep(1000);

            Console.WriteLine("Signaling AutoResetEvent...");
            autoResetEvent.Set();
            Console.WriteLine("Signaling ManualResetEvent...");
            manualResetEvent.Set();
            Thread.Sleep(1000);
            Console.WriteLine("Press enter to signaling ManualResetEvent again...");
            Console.ReadLine();
            manualResetEvent.Set();

            autoThread.Join();
            manualThread.Join();


            //Q. What is the Semaphore?
            //A. A semaphore is a synchronization object that limits the number of threads that can access a resource or pool of resources concurrently.
            for (int i = 1; i <= 5; i++)
            {
                Thread t1 = new Thread(SemaphoreMethod);
                t1.Start(i);
            }

            Thread.Sleep(500);
            Console.WriteLine("Main thread call Release(3)");
            semaphore.Release(2);

            //Q. Explain Mutex and how it is different from other Synchronization mechanisms?
            //A. A mutex is a synchronization primitive that grants exclusive access to a shared resource to only one thread at a time.
            //   It is used to protect shared resources from concurrent access and avoid race conditions.
            //   Mutex is different from other synchronization mechanisms in that it can be used to synchronize threads across processes.
            //   Unlike monitors, a mutex can be used for inter-process synchronization because it can be given a name so that both applications can access the same mutex object.
            //   However, using a mutex requires interop transitions that are more computationally expensive than those required by the Monitor class.
            for (int i = 0; i < 3; i++)
            {
                Thread thread1 = new Thread(MutexMethod)
                {
                    Name = $"Thread {i + 1}"
                };
                thread1.Start();
            }

            //Q. What is the Race condition?
            //A. A race condition is a situation that occurs when two or more threads or processes access shared data and try to change it at the same time, resulting in unpredictable behavior.

            //Q. How can you share data between multiple threads?
            //A. Please check above examples of changing message and count.

            //Q. What are Concurrent Collection Classes?
            //A. The System.Collections.Concurrent namespace in C# provides several collection classes that are both thread-safe and scalable. These classes can be used when multiple threads need to access the collection concurrently.
            //   The following are the concurrent collection classes:
            //   1. ConcurrentBag
            //   2. ConcurrentDictionary
            //   3. ConcurrentQueue
            //   4. ConcurrentStack
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Parallel.For(0, 10, i => bag.Add(i));
            Parallel.For(0, 10, i =>
            {
                int item;
                if (bag.TryTake(out item))
                    Console.WriteLine(item);
            });

            //Q. What is synchronization and why it is important?
            //A. Synchronization is a mechanism that ensures that only one thread accesses a shared resource at a time, preventing other threads from doing the same simultaneously.
            //   This is important because if multiple threads access the same resource simultaneously, it can lead to race conditions, deadlocks, and other issues that can cause the program to behave unpredictably or even crash.

            //Q. Explain the four necessary conditions for Deadlock?
            //A. The four necessary conditions for deadlock are:
            //   1. Mutual exclusion: At least one resource must be held in a non-shareable mode. Otherwise, deadlock would not occur.
            //   2. Hold and wait: A process must be holding at least one resource and waiting to acquire additional resources that are currently being held by other processes.
            //   3. No preemption: Resources cannot be preempted from a process. They can only be released voluntarily by the process holding them.
            //   4. Circular wait: A set of processes must be waiting for each other in a circular chain. For example, Process 1 is waiting for Process 2, Process 2 is waiting for Process 3, and so on.

            //Q. What is LiveLock?
            //A. Livelock is a situation in concurrent computing where two or more processes are stuck in a cycle of trying to complete an action, but none of them can proceed because they are waiting for the other processes to complete their actions.
            //   This is different from a deadlock, where the processes are blocked and cannot proceed.
            //   In a livelock, the processes are not blocked, but they are not making any progress either.
        }

        private static void ThreadMethod()
        {
            Console.WriteLine("ThreadMethod is running...\n");
        }

        private static void ThreadMethodWithParameter(object obj)
        {
            Console.WriteLine("ThreadMethodWithParameter is running...");
            Console.WriteLine($"Parameter: {obj}\n");
        }

        private static void ThreadMethodRetrieve()
        {
            message = "ThreadMethodRetrieve is running...\n";
            autoResetEvent.Set();
        }

        private static void ModifyMessage()
        {
            lock (thisLock)
            {
                message = "Message is modified...\n";
            }
        }

        private static string GetMessage()
        {
            lock (thisLock)
            {
                return message;
            }
        }

        private static void IncrementCount()
        {
            Interlocked.Increment(ref count);
        }

        private static void DecrementCount()
        {
            Interlocked.Decrement(ref count);
        }

        private static int GetCount()
        {
            Monitor.Enter(thisLock);
            try
            {
                return count;
            }
            finally
            {
                Monitor.Exit(thisLock);
            }
        }

        private static void IncrementCountWithLock()
        {
            lock (thisLock)
            {
                count++;
            }
        }

        private static void IncrementCountWithMonitor()
        {
            Monitor.Enter(thisLock);
            try
            {
                count++;
            }
            finally
            {
                Monitor.Exit(thisLock);
            }
        }

        private static void AutoMethod()
        {
            Console.WriteLine("AutoMethod is running...");
            autoResetEvent.WaitOne();
            Console.WriteLine("AutoMethod is ending...\n");
        }

        private static void ManualMethod()
        {
            Console.WriteLine("ManualMethod is running...");
            manualResetEvent.WaitOne();
            Console.WriteLine("ManualMethod is ending...");

            Console.WriteLine("Waiting for ManualResetEvent to be reset...");
            manualResetEvent.Reset();
            manualResetEvent.WaitOne();
            Console.WriteLine("ManualResetEvent is ending again...\n");
        }

        private static void SemaphoreMethod(object num)
        {
            Console.WriteLine($"Thread {num} is waiting to enter the semaphore...");
            semaphore.WaitOne();
            Console.WriteLine($"Thread {num} has entered the semaphore...");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {num} is releasing the semaphore...");
            Console.WriteLine($"Thread {num} previous semaphore count: {semaphore.Release()}");
        }

        private static void MutexMethod()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is requesting the mutex...");
            mutex.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the mutex...");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} is releasing the mutex...");
            mutex.ReleaseMutex();
            Console.WriteLine($"{Thread.CurrentThread.Name} has released the mutex...");
        }
    }
}
