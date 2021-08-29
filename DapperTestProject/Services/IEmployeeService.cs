using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTestProject.Models;

namespace DapperTestProject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeesById(int id);
        Task<bool> CreateEmployee(Employee employee);
    }
}