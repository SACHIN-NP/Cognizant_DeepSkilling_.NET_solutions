using System;
using System.Threading;

namespace SingletonPatternExample
{
    /// <summary>
    /// Test class to verify Singleton implementation
    /// </summary>
    public class SingletonTest
    {
        public static void TestSingletonPattern()
        {
            Console.WriteLine("=== Testing Singleton Pattern ===\n");
            
            // Test 1: Get multiple instances and verify they are the same
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();
            Logger logger3 = Logger.GetInstance();
            
            Console.WriteLine("Testing instance equality:");
            Console.WriteLine($"logger1 == logger2: {ReferenceEquals(logger1, logger2)}");
            Console.WriteLine($"logger2 == logger3: {ReferenceEquals(logger2, logger3)}");
            Console.WriteLine($"logger1 == logger3: {ReferenceEquals(logger1, logger3)}");
            
            Console.WriteLine($"\nInstance Hash Codes:");
            Console.WriteLine($"logger1 HashCode: {logger1.GetHashCode()}");
            Console.WriteLine($"logger2 HashCode: {logger2.GetHashCode()}");
            Console.WriteLine($"logger3 HashCode: {logger3.GetHashCode()}");
            
            // Test 2: Use the logger for different types of logging
            Console.WriteLine("\n=== Testing Logger Functionality ===");
            logger1.LogInfo("Application started successfully");
            logger2.LogWarning("This is a warning message from logger2");
            logger3.LogError("This is an error message from logger3");
            logger1.LogInfo("All loggers are actually the same instance");
            
            // Test 3: Multi-threading test
            Console.WriteLine("\n=== Testing Thread Safety ===");
            Thread[] threads = new Thread[5];
            
            for (int i = 0; i < 5; i++)
            {
                int threadId = i;
                threads[i] = new Thread(() =>
                {
                    Logger threadLogger = Logger.GetInstance();
                    threadLogger.LogInfo($"Message from Thread {threadId} - HashCode: {threadLogger.GetHashCode()}");
                });
            }
            
            // Start all threads
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            
            // Wait for all threads to complete
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            
            Console.WriteLine("\nSingleton Pattern test completed successfully!");
        }
    }
}