using System.Threading.Tasks;
using DapperTestProject.Models;

namespace DapperTestProject.Services
{
    public interface ITestService
    {
        Task<bool> Create(Employee employee);
    }
}