using Chapter10.Models;

namespace Chapter10.Interfaces
{
    public interface IExporter
    {
        string FormatName { get; } 
        List<string> Export(List<Record> records);
    }
}
