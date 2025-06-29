using System;

namespace FactoryMethodPatternExample
{
    
    public class WordDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument(string name)
        {
            Console.WriteLine("WordDocumentFactory: Creating Word document...");
            return new WordDocument(name);
        }
    }
}