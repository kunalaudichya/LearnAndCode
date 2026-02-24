using Chapter10.Models;

namespace Chapter10.Services
{
    public class StatisticsService
    {
        public ProcessingStatistics Generate(List<Record> records, int errorCount)
        {
            double totalValue = records.Where(r => r.Value.HasValue).Sum(r => r.Value.Value);

            return new ProcessingStatistics
            {
                TotalRecords = records.Count,
                ErrorCount = errorCount,
                TotalValue = (int)totalValue,
                AverageValue = records.Count > 0 ? (int)(totalValue / records.Count) : 0
            };
        }
    }
}
