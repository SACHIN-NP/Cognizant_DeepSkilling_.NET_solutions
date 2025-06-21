using System;

namespace FactoryMethodPatternExample
{
    
    public abstract class DocumentFactory
    {
        // Factory method - to be implemented by concrete factories
        public abstract Document CreateDocument(string name);
        
        // Template method that uses the factory method
        public Document ProcessDocument(string name)
        {
            Console.WriteLine($"\n--- Processing document creation for: {name} ---");
            Document document = CreateDocument(name);
            
            // Common processing steps
            document.DisplayInfo();
            document.Open();
            
            return document;
        }
    }
}