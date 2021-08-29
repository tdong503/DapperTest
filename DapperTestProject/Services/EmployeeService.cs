using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperTestProject.Models;
using DapperTestProject.Repositories;

namespace DapperTestProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var allAsync = await _employeeRepository.GetAllAsync();
            return allAsync.ToList();
        }

        public async Task<Employee> GetEmployeesById(int id)
        {
            return await _employeeRepository.GetByIDAsync(id);
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }
    }
}