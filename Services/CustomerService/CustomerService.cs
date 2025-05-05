using billingSystem.Models;
using billingSystem.Data;
using Microsoft.EntityFrameworkCore;
using billingSystem.Dtos.CustomersDtos;

namespace billingSystem.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> CreateCustomer(CreateCustomerDto newCustomer)
        {
            var customer = new Customer
            {
                Name = newCustomer.name,
                Email = newCustomer.email
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(int id, UpdateCustomerDto updatedCustomer)
        {
            var customer = await GetCustomerById(id) ?? throw new Exception($"Customer ID: {id} not found");
            customer.Name = updatedCustomer.name;
            customer.Email = updatedCustomer.email;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await GetCustomerById(id) ?? throw new Exception($"Customer ID: {id} not found");
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
