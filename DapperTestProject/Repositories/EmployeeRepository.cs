using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DapperTestProject.Models;

namespace DapperTestProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConfig _dbConfig;

        public EmployeeRepository(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            return await conn.QueryAsync<Employee>(@"SELECT Id
                                            ,Name
                                            ,Email
                                        FROM Employee");
        }

        public async Task<Employee> GetByIDAsync(int id)
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            var sql = @"SELECT Id
                                ,Name
                                ,Email
                            FROM Employee
                            WHERE Id = @Id";
            return await conn.QueryFirstOrDefaultAsync<Employee>(sql, new {Id = id});
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            var sql = @"INSERT INTO Employee 
                            (Id,
                             Name
                            ,Email
                            ,DepartmentId)
                        VALUES
                            (@Id,
                             @Name
                            ,@Email
                            ,@DepartmentId)";
            return await conn.ExecuteAsync(sql, employee) > 0;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            var sql = @"UPDATE Employee SET 
                                Name = @Name
                                ,Email = @Email
                                ,DepartmentId= @DepartmentId
                           WHERE Id = @Id";
            return await conn.ExecuteAsync(sql, employee) > 0;
        }

        public async Task<bool> ClearAsync()
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            var sql = @"DELETE FROM Employee";
            return await conn.ExecuteAsync(sql) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            var sql = @"DELETE FROM Employee
                            WHERE Id = @Id";
            return await conn.ExecuteAsync(sql, new {Id = id}) > 0;
        }
        
        
    }
}