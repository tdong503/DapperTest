using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperTestProject
{
    public class DbConfig
    {
        public DbConfig(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; set; }

        public IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}