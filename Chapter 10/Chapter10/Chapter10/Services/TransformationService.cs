using Chapter10.Models;

namespace Chapter10.Services
{
    public class TransformationService
    {
        public void Transform(List<Record> parsedRecords)
        {
            foreach (var record in parsedRecords)
            {
                if (!string.IsNullOrEmpty(record.Name))
                    record.Name = record.Name.ToUpper();

                if (record.Value.HasValue)
                {
                    record.DoubledValue = record.Value.Value * 2;
                    record.SquaredValue = record.Value.Value * record.Value.Value;
                }
            }
        }
    }
}
