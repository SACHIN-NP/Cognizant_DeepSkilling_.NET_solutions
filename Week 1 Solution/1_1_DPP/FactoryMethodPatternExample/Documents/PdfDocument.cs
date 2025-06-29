using System;

namespace FactoryMethodPatternExample
{
 
    public class PdfDocument : Document
    {
        public int PageCount { get; private set; }
        public bool IsPasswordProtected { get; private set; }
        
        public PdfDocument(string name) : base(name)
        {
            FileExtension = ".pdf";
            PageCount = 1;
            IsPasswordProtected = false;
        }
        
        public override void Open()
        {
            Console.WriteLine($"Opening PDF document: {Name}{FileExtension}");
            Console.WriteLine("PDF reader application launched");
        }
        
        public override void Save()
        {
            Console.WriteLine($"Saving PDF document: {Name}{FileExtension}");
            Console.WriteLine("Document saved in PDF format");
        }
        
        public override void Close()
        {
            Console.WriteLine($"Closing PDF document: {Name}{FileExtension}");
            Console.WriteLine("PDF reader closed");
        }
        
        public override void Print()
        {
            Console.WriteLine($"Printing PDF document: {Name}{FileExtension}");
            Console.WriteLine("High-quality PDF printing initiated...");
        }
        
        public void AddPage()
        {
            PageCount++;
            Console.WriteLine($"Added new page. Current page count: {PageCount}");
        }
        
        public void SetPasswordProtection(bool enabled)
        {
            IsPasswordProtected = enabled;
            Console.WriteLine($"Password protection {(enabled ? "enabled" : "disabled")}");
        }
    }
}