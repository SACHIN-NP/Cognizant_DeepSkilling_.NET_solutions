using System;
using System.Collections.Generic;

namespace FactoryMethodPatternExample
{
  
    public class ExcelDocument : Document
    {
        public int SheetCount { get; private set; }
        public List<string> SheetNames { get; private set; }
        
        public ExcelDocument(string name) : base(name)
        {
            FileExtension = ".xlsx";
            SheetCount = 1;
            SheetNames = new List<string> { "Sheet1" };
        }
        
        public override void Open()
        {
            Console.WriteLine($"Opening Excel document: {Name}{FileExtension}");
            Console.WriteLine("Microsoft Excel application launched");
        }
        
        public override void Save()
        {
            Console.WriteLine($"Saving Excel document: {Name}{FileExtension}");
            Console.WriteLine("Workbook saved in Excel format");
        }
        
        public override void Close()
        {
            Console.WriteLine($"Closing Excel document: {Name}{FileExtension}");
            Console.WriteLine("Excel application closed");
        }
        
        public override void Print()
        {
            Console.WriteLine($"Printing Excel document: {Name}{FileExtension}");
            Console.WriteLine("Printing all sheets...");
        }
        
        public void AddWorksheet(string sheetName)
        {
            SheetCount++;
            SheetNames.Add(sheetName);
            Console.WriteLine($"Added worksheet '{sheetName}'. Total sheets: {SheetCount}");
        }
        
        public void AddData(string sheetName, string cellReference, object value)
        {
            Console.WriteLine($"Added data to {sheetName}[{cellReference}]: {value}");
        }
    }
}