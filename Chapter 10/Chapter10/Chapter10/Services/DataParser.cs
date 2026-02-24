using Chapter10.Models;

namespace Chapter10.Services
{
    public class DataParser
    {
        public ProcessingResult Parse(IEnumerable<string> rawData)
        {
            var parsedData = new ProcessingResult();
            foreach (var line in rawData)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    var record = new Record
                    {
                        Id = parts[0].Trim(),
                        Name = parts[1].Trim()
                    };

                    if (double.TryParse(parts[2].Trim(), out double val))
                        record.Value = val;

                    if (parts.Length >= 4 && DateTime.TryParse(parts[3].Trim(), out DateTime date))
                        record.Date = date;

                    parsedData.Records.Add(record);
                }
                else
                {
                    parsedData.ErrorCount++;
                    parsedData.ErrorMessages.Add($"Invalid line format: {line}");
                }
            }
            return parsedData;
        }
    }
}
