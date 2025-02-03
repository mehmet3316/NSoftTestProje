using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IDapperRepository
    {
        Task<T> QuerySingleAsync<T>(string sql, object parameters, CommandType cmtyp);
        Task<int> ExecuteAsync<T>(string sql, object parameters, CommandType cmtyp);
    }

    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object parameters, CommandType cmtyp)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters, commandType: cmtyp);
            }
        }    

        public async Task<int> ExecuteAsync<T>(string sql, object parameters, CommandType cmtyp)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, parameters, commandType: cmtyp);
            }
        }
    }
}
