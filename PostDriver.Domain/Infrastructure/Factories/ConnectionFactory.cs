using System.Data;
using System.Data.SqlClient;

namespace PostDriver.Domain.Infrastructure.Factories
{
    public class ConnectionFactory
    {
        public IDbConnection Connect(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}