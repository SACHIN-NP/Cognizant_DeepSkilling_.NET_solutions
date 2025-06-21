using System;

namespace FactoryMethodPatternExample
{
    
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument(string name)
        {
            Console.WriteLine("ExcelDocumentFactory: Creating Excel document...");
            return new ExcelDocument(name);
        }
    }
}