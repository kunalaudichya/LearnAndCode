
using Week2.Assignment5.Entities;

namespace Week2.Assignment5.Repositories
{
    public interface IEmployeeRepository
    {
        void SaveEmployee(Employee employee);
        void TerminateEmployee(Employee employee);
    }
}
