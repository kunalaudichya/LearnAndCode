using Chapter10.Interfaces;
using Chapter10.Models;

namespace Chapter10.ExportServices
{
    public class XmlExporter: IExporter
    {
        public string FormatName => "xml";
        public List<string> Export(List<Record> records)
        {
            var xmlLines = new List<string>
            {
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>",
                "<records>"
            };

            foreach (var record in records)
            {
                xmlLines.Add("  <record>")
                xmlLines.Add($"    <id>{record.Id}</id>");
                xmlLines.Add($"    <name>{record.Name}</name>");
                xmlLines.Add($"    <value>{record.Value}</value>");
                xmlLines.Add($"    <date>{record.Date?.ToString("yyyy-MM-dd")}</date>");
                xmlLines.Add($"    <doubled_value>{record.DoubledValue}</doubled_value>");
                xmlLines.Add($"    <squared_value>{record.SquaredValue}</squared_value>");
                xmlLines.Add("  </record>");
            }

            xmlLines.Add("</records>");
            return xmlLines;
        }

    }
}
