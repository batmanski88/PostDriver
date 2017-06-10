using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using PostDriver.Domain.Domain;
using PostDriver.Domain.Infrastructure.Factories;
using PostDriver.Domain.IRepository;

namespace PostDriver.Domain.Repository
{
    public class RegionRepo : IRegionRepo
    {
        private readonly string connectionString;
        private readonly ConnectionFactory _connection;

        public async Task AddRegionAsync(Region Region)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("INSERT INTO Regions (PostOfficeId, Name) VALUES (@PostOfficeId, @Name) FROM Regions r INNER JOIN PostOffices p ON r.PostOfficeId = p.OfficeId", Region);
        }

        public async Task<Region> GetRegionByIdAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            var region = await connect.QueryFirstOrDefaultAsync<Region>("SELECT * FROM Regions WHERE RegionId = @Id");

            return region;
        }

        public Task<IEnumerable<Region>> GetRegionByOfficeIdAsync(Guid OfficeId)
        {
            var connect = _connection.Connect(connectionString);
            var regions = Task.FromResult(connect.Query<Region>("SELECT * FROM REGIONS WHERE PostOfficeId = @OfficeId"));

            return regions;
        }

        public async Task RemoveRegionAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("DELETE r FROM Regions r INNER JOIN PostOffices p ON c.PostOfficeId = p.OfficeId WHERE Regionid = @Id");
        }

        public async Task UpdateRegionAsync(Region Region)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("UPDATE Regions r SET r.Name = @Name, r.Adress = @Adress, r.Longtitude = @Longtitude, r.Latitude = @Latitude, r.StartHour = @StartHour, r.FinishHour = @FinishHour", Region);
        }
    }
}