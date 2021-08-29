using System;
using System.Threading.Tasks;
using DapperTestProject.Models;
using DapperTestProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperTestProject.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class EmployeeAndDepartmentController : ControllerBase
    {
        private readonly ITestService _testService;

        public EmployeeAndDepartmentController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            return Created("", await _testService.Create(employee));
        }
    }
}