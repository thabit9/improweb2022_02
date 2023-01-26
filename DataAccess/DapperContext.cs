using System.Data;
using improweb2022_02.Models;
using improweb2022_02.PayGate;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.DataAccess
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("improwebDbContextCon");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }

}