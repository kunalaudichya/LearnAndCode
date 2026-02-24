using Chapter10.Interfaces;
using Chapter10.Models;

namespace Chapter10.ExportServices
{
    public class CsvExporter : IExporter
    {
        public string FormatName => "csv";

        public List<string> Export(List<Record> records)
        {
            return new List<string> { "ID,NAME,VALUE" };
        }
    }
}
