using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTestProject.Models;

namespace DapperTestProject.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> AddAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIDAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Employee prod);
        Task<bool> ClearAsync();
    }
}