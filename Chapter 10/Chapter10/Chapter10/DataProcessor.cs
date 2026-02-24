using Chapter10.Models;
using Chapter10.Services;
using Chapter10.Utils;

namespace Chapter10
{
    public class DataProcessor
    {
        private readonly LoggerService _logger = new LoggerService();
        private readonly DataParser _parser = new DataParser();
        private readonly ValidationService _validator = new ValidationService();
        private readonly TransformationService _transformer = new TransformationService();
        private readonly StatisticsService _statisticsService = new StatisticsService();

        public List<Record> ProcessedRecords { get; private set; } = new();
        public ProcessingStatistics Statistics { get; private set; } = new ProcessingStatistics();
        public List<string> ErrorMessages { get; private set; } = new();
        public int ErrorCount { get; private set; }

        public void ProcessData(string inputPath, string outputPath)
        {
            _logger.Log("Starting data processing");
            try
            {
                var rawData = File.ReadAllLines(inputPath);
                var parsedData = _parser.Parse(rawData);

                _validator.Validate(parsedData);
                _transformer.Transform(parsedData.Records);

                ProcessedRecords = parsedData.Records;
                ErrorMessages = parsedData.ErrorMessages;
                ErrorCount = parsedData.ErrorCount;
                Statistics = _statisticsService.Generate(ProcessedRecords, ErrorCount);

                var outputLines = new List<string> { "ID,NAME,VALUE,DATE,DOUBLED_VALUE,SQUARED_VALUE" };
                foreach (var r in ProcessedRecords)
                {
                    var line = $"{r.Id}," +
                               $"{r.Name}," +
                               $"{r.Value}," +
                               $"{r.Date?.ToString("yyyy-MM-dd")}," +
                               $"{r.DoubledValue}," +
                               $"{r.SquaredValue}";
                    outputLines.Add(line);
                }

                File.WriteAllLines(outputPath, outputLines);
                _logger.SaveToFile("processing.log");
            }
            catch (Exception ex)
            {
                _logger.Log($"FATAL: {ex.Message}");
            }
        }
    }
}