using System.Collections.Generic;
using System.Threading.Tasks;
using DapperTestProject;
using DapperTestProject.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace DapperTests.IntergrationTests
{
    public class BasicTests: IClassFixture<APITestFactory>
    {
        private readonly APITestFactory _factory;

        public BasicTests(APITestFactory factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Employee")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
            
            var result = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<List<Employee>>(result);
        }
    }
}