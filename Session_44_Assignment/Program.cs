public class Program
{
    //1. When 2 threads want to connect to 2 different methods that are synchronized, what happens.
    //    It would depend on whether the methods are synchronized on the same object or not.
    //    If the methods are synchronized on the same object, then one thread can be in two synchronized methods on the same object at once.
    //    If the methods are synchronized on different objects, then each thread will acquire the lock on its respective object and execute the synchronized method.

    //2. .NET core vs .NET differences
    //    .NET Core is the name of .NET before the 4.0 release. From version 1.0 to 3.1, it is .NET Core, and from 5.0 to today, it is .NET.
    //    However, .NET Framework and .NET are two different platforms. .NET framework is a Windows-only platform, while .NET is cross-platform which includes Windows, Mac, and Linux.

    //3. ienumerable vs ienumerator?
    //	These are two interfaces in C# that are used to iterate over collections.
    //	`IEnumerable` is used to create collections that can be iterated over, while `IEnumerator` is used to traverse those collections.
    //	In short, `IEnumerable` is used to create collections that can be iterated over using a `foreach` loop, while `IEnumerator` is used to traverse those collections using a `while` loop.

    //4. Singleton pros and cons?
    //    Pros:
    //    Singleton design pattern ensures that there is only one instance of the class, which can be accessed globally. This will be useful if we need to limit the number of instances of a class in our app.
    //    It can be used by any part of the applications that needs it.
    //    Singleton instance is created only when it is first needed, which can help to reduce memory usage.

    //    Cons:
    //    Since the Singleton class is responsible for creating and managing its own instance, it can become difficult to maintain and test.
    //    Singleton can mask bad design, especially when the components of the app correlate with others. This can make it difficult to change the design of the program later.
    //    Sington requires special treatment in a multithreaded environment to ensure that multiple threads don’t create a Singleton object several times.

    //5. Factory pattern vs DI?
    //    Factory pattern is a creational pattern that provides an interface for creating objects in a superclass but allows subclasses to alter the type of objects that will be created.
    //    Dependency Injection is an architectural pattern that allows objects to be created and dependencies to be injected into them at runtime.
    //    Both patterns can be used to manage object creation and dependencies. But Factory pattern offers higher-level abstraction than DI.

    //6. Struct vs Class Interface
    //    These are two different types of data structures that can be used to define custom types.
    //    The main difference between them is that structs are value types, while classes are reference types.
    //    Value type holds the data within its own memory allocation, whereas reference type contains a reference to the memory location where the data is stored.
    //    Structs stored on the stack, while classes stored on the heap in terms of memory allocation.
    //    Structs are generally used for small, simple data structures that do not require inheritance or polymorphism, while classes are more flexible and can support more advanced features like inheritance.

    //7. What is dll and why to use it?
    //    DLL stands for dynamic link library, which is a library that contains code and data that can be used by more than one program at the same time.
    //    It helps promote modularization of code, code reuse, efficient memory usage, and reduced disk space.

    //8. What is generic method?
    //    A generic method is a method that declared with type parameters, which allows us to define a method that can work with a variety of data types.

    //9. What is IOC?
    //    IOC stands for Inversion of Control, which is a design pattern that allows for the separation of concerns between classes and their dependencies.
    //    It is implemented using DI, which is a technique for achieving IOC between classes and their dependencies.

    //10. What is Race conditions?
    //    It is a common problem that occurs when multiple threads access shared data and try to modify it simultaneously.
    //    It often occurs when one thread does a check-then-act and another thread modifies the value of the shared data between the check and act.
    //    To prevent race conditions from occurring, we can use a lock to the shared data to ensure only one thread can access the data at a time.

    //11. What is deadlock in Thread?
    //    It is a situation that occurs when two or more threads are blocked, each waiting on the other to release the resource or lock.
    //    This results in a standstill where neither thread can proceed with its task. To prevent deadlocks, we can use techniques like using timeouts, avoiding nested locks, etc.

    //12. Generic method to convert array of class to array of another class.
    //    We can use `Array.ConvertAll` to achieve the goal.
    class MyClass1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class MyClass2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static void convertAll()
    {
        MyClass1[] myClass1Array = new MyClass1[2]
        {
            new MyClass1 { Id = 1, Name = "MyClass1" },
            new MyClass1 { Id = 2, Name = "MyClass2" }
        };

        MyClass2[] myClass2Array = Array.ConvertAll(myClass1Array, x => new MyClass2 { Id = x.Id, Name = x.Name });
    }

    //13. You have 3 presorted very large arrays. Find the first common element amongst them. No duplicates in each of the array.
    public static int FindFirstCommonElement(int[] arr1, int[] arr2, int[] arr3)
    {
        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
        {
            if (arr1[i] == arr2[j] && arr2[j] == arr3[k])
                return arr1[i];
            else if (arr1[i] < arr2[j])
                i++;
            else if (arr2[j] < arr3[k])
                j++;
            else
                k++;
        }

        return -1;
    }

    public static void Main()
    {
        int[] array1 = new int[] { 1, 2, 3, 4, 5 };
        int[] array2 = new int[] { 4, 5, 6, 7, 8 };
        int[] array3 = new int[] { 5, 6, 7, 8, 9 };
        Console.WriteLine(FindFirstCommonElement(array1, array2, array3));
    }



    //14. Repository pattern vs generic repository pattern
    //    Repository pattern is a design pattern to facilitate the separation of concerns between the data access layer and the business logic layer. It was used to abstract data persistence and retrieval, promoting code maintainability, testability, and scalability.
    //    Generic Repository Pattern is a design pattern that abstracts the application’s data layer, making it easier to manage data access logic across different data sources. It was used to reduce redundancy by implementing common data operations in a single, generic repository rather than having separate repositories for each entity type.
    //    If we want specific operation for specific entities, then we need to create a specific repo with the operations, while common operations for all entities should be defined inside the generic repo. Generic Repo is the one to go for CRUD operations, and specific operations, we use non-generic repo for different entity.
}