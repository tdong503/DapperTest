using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTestProject.Models;

namespace DapperTestProject.Repositories
{
    public interface IDepartmentRepository
    {
        Task<bool> AddAsync(Department department);
        Task<IEnumerable<Department>> GetAllAsync();
    }
}