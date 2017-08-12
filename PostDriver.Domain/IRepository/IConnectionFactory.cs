using System.Data.Common;

namespace PostDriver.Domain.IRepository
{
    public interface IConnectionFactory
    {
         DbConnection Connect(string connectionString);
    }
}