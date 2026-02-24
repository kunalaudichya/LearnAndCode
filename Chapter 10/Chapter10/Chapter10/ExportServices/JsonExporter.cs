using Chapter10.Interfaces;
using Chapter10.Models;

namespace Chapter10.ExportServices
{
    public class JsonExporter: IExporter
    {
        public string FormatName => "json";
        public List<string> Export(List<Record> records)
        {
            var jsonLines = new List<string> { "[" };

            for (int i = 0; i < records.Count; i++)
            {
                var record = records[i];

                var properties = new List<string>
                {
                    $"\"id\": \"{record.Id}\"",
                    $"\"name\": \"{record.Name}\"",
                    $"\"value\": \"{record.Value}\"",
                    $"\"date\": \"{record.Date?.ToString("yyyy-MM-dd")}\"",
                    $"\"doubled_value\": \"{record.DoubledValue}\"",
                    $"\"squared_value\": \"{record.SquaredValue}\""
                };

                var jsonObj = "  { " + string.Join(", ", properties) + " }";

                if (i < records.Count - 1)
                    jsonObj += ",";

                jsonLines.Add(jsonObj);
            }

            jsonLines.Add("]");
            return jsonLines;
        }
    }
}
