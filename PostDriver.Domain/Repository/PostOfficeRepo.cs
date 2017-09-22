using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Domain.Repository
{
    public class PostOfficeRepo : IPostOfficeRepo
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PostDriver;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly IConnectionFactory _connection;

        public PostOfficeRepo(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public async  Task AddPostOfficeAsync(PostOffice Office)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("INSERT INTO PostOffices (OfficeId, Name, Adress, Latitude, Longitude) VALUES(@OfficeId, @Name, @Adress, @Latitude, @Longitude)", new {Office.OfficeId, Office.Name, Office.Adress, Office.Latitude, Office.Longitude});
        }

        public async Task<PostOffice> GetPostOfficeByIdAsync(Guid OfficeId)
        {
            var connect = _connection.Connect(connectionString);
            return await connect.QueryFirstOrDefaultAsync<PostOffice>("SELECT * FROM PostOffices WHERE PostOfficeId = @OfficeId", new {OfficeId});
        }

        public async Task<PostOffice> GetPostOfficeByName(string Name)
        {
            var connect = _connection.Connect(connectionString);
            return await connect.QueryFirstOrDefaultAsync<PostOffice>("SELECT * FROM PostOffices WHERE Name = @Name", new {Name});
        }

        public async Task<IEnumerable<PostOffice>> GetPostOfficesAsync()
        {
            var connect = _connection.Connect(connectionString);
            return await connect.QueryAsync<PostOffice>("SELECT * FROM PostOffices");
        }

        public async Task RemovePostOfficeAsync(Guid OfficeId)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("DELETE p FROM PostOffices p", new {OfficeId});
        }

        public async Task UpdatePostOfficeAsync(PostOffice Office)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("UPDATE p PostOffices SET p.Name = @Name, p.Adress = @Adress, p.Longitude = @Longitude, p.Latitude = @Latitude", new {Office.Name, Office.Adress, Office.Latitude, Office.Longitude});
        }
    }
}