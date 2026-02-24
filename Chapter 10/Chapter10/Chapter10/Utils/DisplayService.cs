using Chapter10.Models;

namespace Chapter10.Utils
{
    public class DisplayService
    {
        public void DisplayStatistics(ProcessingStatistics statistics, List<string> errorMessages)
        {
            Console.WriteLine("\n=== Processing Statistics ===");
            if (statistics != null)
            {
                Console.WriteLine($"Total Records: {statistics.TotalRecords}");
                Console.WriteLine($"Error Count:   {statistics.ErrorCount}");
                Console.WriteLine($"Total Value:   {statistics.TotalValue}");
                Console.WriteLine($"Average Value: {statistics.AverageValue}");
            }

            if (errorMessages != null && errorMessages.Count > 0)
            {
                Console.WriteLine("\n=== Errors ===");
                foreach (var error in errorMessages)
                {
                    Console.WriteLine($"- {error}");
                }
            }
        }
    }
}
