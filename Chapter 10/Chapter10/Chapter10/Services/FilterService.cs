using Chapter10.Models;

namespace Chapter10.Services
{
    public class FilterService
    {
        public List<Record> FilterByValue(List<Record> records, double minValue)
        {
            return records.Where(r => r.Value.HasValue && r.Value.Value >= minValue).ToList();
        }
    }
}
