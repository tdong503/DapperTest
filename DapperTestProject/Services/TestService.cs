using System;
using System.Threading.Tasks;
using System.Transactions;
using DapperTestProject.Models;
using DapperTestProject.Repositories;

namespace DapperTestProject.Services
{
    public class TestService : ITestService
    {
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public TestService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Create(Employee employee)
        {
            var departmentId = Guid.NewGuid();
            var employeeDepartment = employee.Department;
            employeeDepartment.Id = departmentId;

            try
            {
                using var scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled);
                await _departmentRepository.AddAsync(employeeDepartment);
                var employeeId = Guid.NewGuid();

                employee.Id = employeeId;
                employee.DepartmentId = 1;
                await _employeeRepository.AddAsync(employee);
                
                scope.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}