using System;

namespace SingletonPatternExample
{
    /// <summary>
    /// Main program entry point
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton Pattern Example in C#");
            Console.WriteLine("================================\n");
            
            // Run the singleton tests
            SingletonTest.TestSingletonPattern();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}