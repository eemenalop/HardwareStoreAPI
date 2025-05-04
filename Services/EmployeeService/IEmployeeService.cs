using billingSystem.Dtos.CustomersDtos;
using billingSystem.Models;
using billingSystem.Dtos.EmployeeDtos;

namespace billingSystem.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee?> GetEmployeeById(int id);

        Task<Employee> CreateEmployee(CreateEmployeeDto newEmployee);

        Task<Employee?> UpdateEmployee(int id, UpdateEmployeeDto updatedEmployee);

        Task DeleteEmployee(int id);
    }
}
