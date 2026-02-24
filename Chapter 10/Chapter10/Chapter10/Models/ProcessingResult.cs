namespace Chapter10.Models
{
    public class ProcessingResult
    {
        public List<Record> Records { get; set; } = new();
        public List<string> ErrorMessages { get; set; } = new();
        public int ErrorCount { get; set; }
    }
}
