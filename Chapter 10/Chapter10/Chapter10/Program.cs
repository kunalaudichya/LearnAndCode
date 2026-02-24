using Chapter10;
using Chapter10.Interfaces;
using Chapter10.Services;
using Chapter10.ExportServices;
using Chapter10.Utils;

namespace CleanCodeAssignments.Comprehensive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataGenerator.GenerateSampleData("input.csv", 50);

            var processor = new DataProcessor();
            processor.ProcessData("input.csv", "output.csv");

            var displayService = new DisplayService();
            displayService.DisplayStatistics(processor.Statistics, processor.ErrorMessages);

            var exporters = new List<IExporter>
            {
                new JsonExporter(),
                new XmlExporter(),
                new CsvExporter()
            };

            var exportManager = new ExportManager(exporters);

            try
            {
                exportManager.ExportByFormat("output.json", "json", processor.ProcessedRecords);
                exportManager.ExportByFormat("output.xml", "xml", processor.ProcessedRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Export error: {ex.Message}");
            }

            var filterService = new FilterService();
            var filtered = filterService.FilterByValue(processor.ProcessedRecords, 100);

            Console.WriteLine($"\nFiltered records (Value >= 100): {filtered.Count}");
            Console.WriteLine($"\nRecords processed: {processor.ProcessedRecords.Count}");
            Console.WriteLine($"Errors: {processor.ErrorCount}");
        }
    }
}