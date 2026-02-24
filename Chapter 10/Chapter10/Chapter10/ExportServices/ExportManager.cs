using Chapter10.Interfaces;
using Chapter10.Models;

namespace Chapter10.ExportServices
{
    public class ExportManager
    {
        private readonly IEnumerable<IExporter> _exporters;

        public ExportManager(IEnumerable<IExporter> exporters)
        {
            _exporters = exporters;
        }

        public void ExportByFormat(string filePath, string format, List<Record> records)
        {
            var exporter = _exporters.FirstOrDefault(e => e.FormatName.Equals(format, StringComparison.OrdinalIgnoreCase));

            if (exporter == null)
            {
                throw new ArgumentException($"Unsupported format: {format}");
            }

            var exportedLines = exporter.Export(records);
            File.WriteAllLines(filePath, exportedLines);
        }
    }
}
