using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DapperTestProject.Controllers;
using DapperTestProject.Models;
using DapperTestProject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DapperTests.UnitTests.Controllers
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _controller;
        private readonly Mock<IEmployeeService> _employeeServiceMock;
        
        private readonly Employee _validEmployee = new Employee
        {
            Name = "Test Name",
            Email = "test@test.com",
            Department = new Department()
        };
        
        public EmployeeControllerTests()
        {
            _employeeServiceMock = new Mock<IEmployeeService>();
            _controller = new EmployeeController(_employeeServiceMock.Object);
        }

        [Fact]
        public async Task GivenValidAEmployee_WhenCreateEmployee_ThenShouldReturnCreatedId()
        {
            //Assign
            var employee = _validEmployee;
            _employeeServiceMock.Setup(x => x.CreateEmployee(employee))
                .ReturnsAsync(true);

            //Act
            var result = await _controller.CreateEmployee(employee);

            //Assert
            var createdObjectResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal((int) HttpStatusCode.Created, createdObjectResult.StatusCode.Value);
            var returnValue = Assert.IsType<bool>(createdObjectResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task GivenEmployeeId_WhenGetEmployeesById_ThenShouldReturnExpectedEmployees()
        {
            //Assign
            var employees = _validEmployee;

            _employeeServiceMock.Setup(x => x.GetEmployeesById(It.IsAny<int>()))
                .ReturnsAsync(employees);
            //Act
            var result = await _controller.GetEmployeesById(1);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int) HttpStatusCode.OK, okObjectResult.StatusCode.Value);
            var returnValue = Assert.IsType<Employee>(okObjectResult.Value);
            Assert.Equal(_validEmployee, returnValue);
        }
    }
}