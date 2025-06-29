using System;

namespace FactoryMethodPatternExample
{
 
    public class PdfDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument(string name)
        {
            Console.WriteLine("PdfDocumentFactory: Creating PDF document...");
            return new PdfDocument(name);
        }
    }
}