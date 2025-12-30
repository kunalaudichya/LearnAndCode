
using Week2.Assignment5.Entities;

namespace Week2.Assignment5.Services
{
    public interface IEmployeeServices
    {
        string GenerateEmployeeDetailsXML(Employee employee);
        string GenerateEmployeeDetailsCSV(Employee employee);
    }
}
