using System;
using System.Collections.Generic;

namespace FactoryMethodPatternExample
{
    
    public class DocumentManager
    {
        private Dictionary<string, DocumentFactory> _factories;
        
        public DocumentManager()
        {
            _factories = new Dictionary<string, DocumentFactory>
            {
                { "word", new WordDocumentFactory() },
                { "pdf", new PdfDocumentFactory() },
                { "excel", new ExcelDocumentFactory() }
            };
        }
        
        public Document CreateDocument(string type, string name)
        {
            type = type.ToLower();
            
            if (_factories.ContainsKey(type))
            {
                return _factories[type].ProcessDocument(name);
            }
            else
            {
                throw new ArgumentException($"Unsupported document type: {type}");
            }
        }
        
        public void ListSupportedTypes()
        {
            Console.WriteLine("Supported document types:");
            foreach (var type in _factories.Keys)
            {
                Console.WriteLine($"- {type}");
            }
        }
    }
}