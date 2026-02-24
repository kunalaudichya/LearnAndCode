namespace Chapter10.Models
{
    public class Record
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
        public DateTime? Date { get; set; }
        public double DoubledValue { get; set; }
        public double SquaredValue { get; set; }
    }
}
