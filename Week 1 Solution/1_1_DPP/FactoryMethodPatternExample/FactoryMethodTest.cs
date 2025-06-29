using System;

namespace FactoryMethodPatternExample
{
    
    public class FactoryMethodTest
    {
        public static void TestFactoryMethod()
        {
            Console.WriteLine("=== Testing Factory Method Pattern ===\n");
            
            DocumentManager manager = new DocumentManager();
            
            // Display supported types
            manager.ListSupportedTypes();
            Console.WriteLine();
            
            try
            {
                // Test creating different types of documents
                Console.WriteLine("Creating various documents using Factory Method Pattern:\n");
                
                // Create Word document
                Document wordDoc = manager.CreateDocument("word", "ProjectReport");
                if (wordDoc is WordDocument wd)
                {
                    wd.AddText("This is a sample project report with multiple paragraphs.");
                    wd.Save();
                    wd.Print();
                    wd.Close();
                }
                
                // Create PDF document
                Document pdfDoc = manager.CreateDocument("pdf", "UserManual");
                if (pdfDoc is PdfDocument pd)
                {
                    pd.AddPage();
                    pd.AddPage();
                    pd.SetPasswordProtection(true);
                    pd.Save();
                    pd.Print();
                    pd.Close();
                }
                
                // Create Excel document
                Document excelDoc = manager.CreateDocument("excel", "SalesData");
                if (excelDoc is ExcelDocument ed)
                {
                    ed.AddWorksheet("Q1 Sales");
                    ed.AddWorksheet("Q2 Sales");
                    ed.AddData("Q1 Sales", "A1", "Product");
                    ed.AddData("Q1 Sales", "B1", "Revenue");
                    ed.Save();
                    ed.Print();
                    ed.Close();
                }
                
                // Test error handling
                Console.WriteLine("\n--- Testing error handling ---");
                try
                {
                    manager.CreateDocument("powerpoint", "Presentation");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Expected error caught: {ex.Message}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            
            Console.WriteLine("\nFactory Method Pattern test completed successfully!");
        }
    }
}