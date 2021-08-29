using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DapperTestProject.Models;

namespace DapperTestProject.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConfig _dbConfig;

        public DepartmentRepository(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            return await conn.QueryAsync<Department>(@"SELECT Id
                                            ,Name
                                        FROM Department");
        }

        public async Task<bool> AddAsync(Department department)
        {
            using IDbConnection conn = _dbConfig.GetSqlConnection();
            var sql = @"INSERT INTO Department 
                            (Id,
                             Name)
                        VALUES
                            (@Id,
                             @Name)";
            return await conn.ExecuteAsync(sql, department) > 0;
        }
    }
}