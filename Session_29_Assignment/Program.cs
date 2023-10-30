// 1. What is the output of below program?
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Base obj = new Derive();
            obj.F1();
            obj.F2();
            obj.F3();
            Console.WriteLine("Hello World!");
        }
    }

    public class Base
    {
        public void F1() { Console.WriteLine("Base F1"); }
        public virtual void F2() { Console.WriteLine("Base F2"); }
        public virtual void F3() { Console.WriteLine("Base F3"); }
    }

    public class Derive : Base
    {
        new public void F1()
        {
            Console.WriteLine("Derive F1");
        }

        public override void F2()
        {
            Console.WriteLine("Derive F2");
        }

        public new void F3()
        {
            Console.WriteLine("Derive F3");
        }
    }
}

// Output: 
// Base F1
// Derive F2
// Base F3
// Hello World!
//
// Explanation:
// 1. Base class method F1 is not virtual so it will not be overridden in Derive class.
// 2. Base class method F2 is virtual so it will be overridden in Derive class.
// 3. The object is of Base class so it will call Base class method F3.

// 2. Why IDisposable is used?
// IDisposable is used to release unmanaged resources like file, database connection, network connection etc.

// 3. What is Finalizer is used for?
// Finalizer is used to perform any necessary final clean-up when a class instance is being collected by the garbage collector.

// 4. How GC works in .net?
// In the common language runtime (CLR), the garbage collector (GC) serves as an automatic memory manager.
// The garbage collector manages the allocation and release of memory for an application.
// Therefore, developers working with managed code don't have to write code to perform memory management tasks.
// The garbage collector performs the following operations:
// 1. Allocates memory for managed objects.
// 2. Reclaims memory for objects that are no longer being used.
// 3. Promotes objects to generations that are based on their longevity.
// 4. Provides an efficient mechanism for reclaiming memory for dead objects, and for keeping short-lived objects from being promoted unnecessarily to higher generations.
// 5. Provides a finalizer method for releasing unmanaged resources.

// 5. What is difference between .Net and .Net Core?
// .NET is a free, cross-platform, open-source developer platform for building many different types of applications.
// .NET Core is the name of .NET before version 3.1. Starting with version 5.0, .NET Core is just called .NET.
// Differences between .NET Framework and .NET:
// 1. .NET Framework is a Windows-only platform that supports Windows Desktop, Windows Store, and Windows Phone; .NET is cross-platform and supports Windows, macOS, Linux, iOS, and Android.
// 2. .NET Framework supports .NET Framework libraries and NuGet packages; .NET supports .NET libraries, NuGet packages, and new project types (such as Blazor, Xamarin, and ASP.NET Core).
// 3. .NET Framework supports ASP.NET Web Forms and WCF; .NET supports ASP.NET Core.
// 4. .NET is open source and can be used by any person or organization in any scenario; .NET Framework is only open source for limited scenarios (such as bug fixes and feature requests).

// 6. What is difference between Manged v/s unmanaged memory in .Net?
// Managed code is the code that is executed by the Common Language Runtime (CLR) in .NET Framework.
// It is compiled into an intermediate language known as IL or MSIL or CIL. The CLR provides runtime services like garbage collection, exception handling, and security to the application written in .NET Framework.
// On the other hand, Unmanaged code is the code that is directly executed by the operating system. It is compiled directly into native languages.
// It does not provide any security to the application and does not provide runtime services like garbage collection or exception handling.

// 7. If program is developed in .net core in Windows then can we run the same program in Linux without changing anything?
// Yes, we can run the same program in Linux without changing anything.

// 8. .Net core deployment modes?
// .NET Core provides three different deployment modes for publishing applications: Framework-dependent deployment (FDD), Self-contained deployment (SCD), and Framework-dependent executables (FDE)
// 1. Framework-dependent deployment (FDD): This is the default deployment mode in .NET Core. In this mode, the application is dependent on the .NET Core runtime installed on the target machine.
//    The application only contains the app-specific code and external dependencies. The .dll will be running with the help of a utility called dotnet.
// 2. Self-contained deployment (SCD): In this mode, the final application build contains all the app-specific code and its dependencies along with .NET Core libraries and .NET Core runtime.
//    As .NET Core is cross-platform, we can build our code depending upon the platform we want to run the app.
// 3. Framework-dependent executables (FDE): This mode produces an executable that can be run on any target machine. In this mode, we are not using dotnet utility to run our app.

// 9. What is extension methods and when to use?
// Extension methods are a way to add new functionality to an existing type without modifying the type itself.
// They are defined as static methods but are called by using instance method syntax. We can use extension methods to extend a class or interface, but not to override them.
// Common uses of extension methods:
// 1. Adding functionality to an interface that we don’t control.
// 2. Adding functionality to a class that we don’t control or cannot derive from.
// 3. Separating concerns when creating reusable code.