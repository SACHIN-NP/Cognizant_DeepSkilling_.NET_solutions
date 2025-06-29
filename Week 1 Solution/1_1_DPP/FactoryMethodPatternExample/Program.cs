using System;

namespace FactoryMethodPatternExample
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Method Pattern Example in C#");
            Console.WriteLine("====================================\n");
            
            // Run the factory method tests
            FactoryMethodTest.TestFactoryMethod();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}