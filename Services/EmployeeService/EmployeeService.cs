using billingSystem.Data;
using billingSystem.Models;
using Microsoft.EntityFrameworkCore;
using billingSystem.Dtos.EmployeeDtos;

namespace billingSystem.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> CreateEmployee(CreateEmployeeDto newEmployee)
        {
            var employee = new Employee
            {
                Name = newEmployee.name,
                IsActive = newEmployee.IsActive
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


        public async Task<Employee?> UpdateEmployee(int id, UpdateEmployeeDto updatedEmployee)
        {
            var employee = await GetEmployeeById(id) ?? throw new Exception($"Employee ID: {id} not found");
            employee.Name = updatedEmployee.name;
            employee.IsActive = updatedEmployee.IsActive;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await GetEmployeeById(id) ?? throw new Exception($"Employee ID: {id} not found");
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }



    }
}
