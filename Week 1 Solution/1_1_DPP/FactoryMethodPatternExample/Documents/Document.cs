using System;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Abstract base class defining the common interface for all documents
    /// </summary>
    public abstract class Document
    {
        public string Name { get; protected set; }
        public string FileExtension { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        
        protected Document(string name)
        {
            Name = name;
            CreatedDate = DateTime.Now;
        }
        
        // Abstract methods that concrete documents must implement
        public abstract void Open();
        public abstract void Save();
        public abstract void Close();
        public abstract void Print();
        
        // Common method for all documents
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Document: {Name}{FileExtension}");
            Console.WriteLine($"Created: {CreatedDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Type: {GetType().Name}");
        }
    }
}