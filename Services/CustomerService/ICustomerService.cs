using billingSystem.Models;
using billingSystem.Dtos.CustomersDtos;

namespace billingSystem.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer?> GetCustomerById(int id);

        Task<Customer> CreateCustomer(CreateCustomerDto newCustomer);

        Task<Customer?> UpdateCustomer(int id, UpdateCustomerDto updatedCustomer);

        Task DeleteCustomer(int id);
    }
}
