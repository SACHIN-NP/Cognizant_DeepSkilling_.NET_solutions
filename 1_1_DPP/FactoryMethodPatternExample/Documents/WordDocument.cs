using System;

namespace FactoryMethodPatternExample
{
    
    public class WordDocument : Document
    {
        public int WordCount { get; private set; }
        
        public WordDocument(string name) : base(name)
        {
            FileExtension = ".docx";
            WordCount = 0;
        }
        
        public override void Open()
        {
            Console.WriteLine($"Opening Word document: {Name}{FileExtension}");
            Console.WriteLine("Microsoft Word application launched");
        }
        
        public override void Save()
        {
            Console.WriteLine($"Saving Word document: {Name}{FileExtension}");
            Console.WriteLine("Document saved in Word format");
        }
        
        public override void Close()
        {
            Console.WriteLine($"Closing Word document: {Name}{FileExtension}");
            Console.WriteLine("Word application closed");
        }
        
        public override void Print()
        {
            Console.WriteLine($"Printing Word document: {Name}{FileExtension}");
            Console.WriteLine("Sending to default printer...");
        }
        
        public void AddText(string text)
        {
            WordCount += text.Split(' ').Length;
            Console.WriteLine($"Added text to document. Current word count: {WordCount}");
        }
    }
}