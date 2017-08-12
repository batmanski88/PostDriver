using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using PostDriver.Domain.IRepository;

namespace PostDriver.Domain.Repository
{
    public class ConnectionFactory : IConnectionFactory
    {

        public ConnectionFactory()
        {

        }

        public DbConnection Connect(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}