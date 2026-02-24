using Chapter10.Models;

namespace Chapter10.Services
{
    public class ValidationService
    {
        public void Validate(ProcessingResult parsedData)
        {
            var validRecords = new List<Record>();

            foreach (var record in parsedData.Records)
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(record.Id))
                {
                    isValid = false;
                    parsedData.ErrorMessages.Add("Record missing ID");
                }

                if (string.IsNullOrEmpty(record.Name))
                {
                    isValid = false;
                    parsedData.ErrorMessages.Add($"Record {record.Id} missing name");
                }

                if (!record.Value.HasValue)
                {
                    isValid = false;
                    parsedData.ErrorMessages.Add($"Record {record.Id} has invalid value");
                }

                if (isValid)
                {
                    validRecords.Add(record);
                }
                else
                {
                    parsedData.ErrorCount++;
                }
            }
            parsedData.Records = validRecords;
        }
    }
}
