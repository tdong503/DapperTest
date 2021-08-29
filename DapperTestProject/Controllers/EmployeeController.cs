using System;
using System.Threading.Tasks;
using DapperTestProject.Models;
using DapperTestProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById(int id)
        {
            return Ok(await _employeeService.GetEmployeesById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            return Created("", await _employeeService.CreateEmployee(employee));
        }
    }
}