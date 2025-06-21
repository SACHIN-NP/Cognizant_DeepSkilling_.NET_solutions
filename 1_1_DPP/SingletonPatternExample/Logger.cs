using System;
using System.IO;

namespace SingletonPatternExample
{
    /// <summary>
    /// Thread-safe Singleton Logger class that ensures only one instance exists
    /// throughout the application lifecycle for consistent logging.
    /// </summary>
    public sealed class Logger
    {
        // Private static instance variable
        private static Logger? _instance = null;
        
        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Private constructor to prevent external instantiation
        private Logger()
        {
            // Initialize logging configuration
            InitializeLogger();
        }
        
        /// <summary>
        /// Public static method to get the single instance of Logger
        /// Implements double-checked locking for thread safety
        /// </summary>
        /// <returns>The single Logger instance</returns>
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
        
        /// <summary>
        /// Initialize logger settings
        /// </summary>
        private void InitializeLogger()
        {
            Console.WriteLine("Logger initialized successfully!");
        }
        
        /// <summary>
        /// Log an informational message
        /// </summary>
        /// <param name="message">The message to log</param>
        public void LogInfo(string message)
        {
            string logEntry = $"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(logEntry);
            WriteToFile(logEntry);
        }
        
        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="message">The error message to log</param>
        public void LogError(string message)
        {
            string logEntry = $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(logEntry);
            WriteToFile(logEntry);
        }
        
        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="message">The warning message to log</param>
        public void LogWarning(string message)
        {
            string logEntry = $"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(logEntry);
            WriteToFile(logEntry);
        }
        
        /// <summary>
        /// Write log entry to file (simplified implementation)
        /// </summary>
        /// <param name="logEntry">The log entry to write</param>
        private void WriteToFile(string logEntry)
        {
            try
            {
                string logFile = "application.log";
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Get the hash code of the current instance for testing purposes
        /// </summary>
        /// <returns>Hash code of the instance</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}