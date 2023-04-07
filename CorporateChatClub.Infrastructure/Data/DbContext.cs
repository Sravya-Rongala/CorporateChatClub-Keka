using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CorporateChatClub.Infrastructure.Data
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        private IDbConnection _connection;
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("default")!;
        }

        public IDbConnection CreateConnection()
        {
            _connection = new SqlConnection(_connectionstring);
            return _connection;
        }
    }
}
