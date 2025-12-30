using System.Collections.Generic;

namespace Week2.Assignment3
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
