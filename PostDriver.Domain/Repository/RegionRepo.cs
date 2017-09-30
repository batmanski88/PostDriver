using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using PostDriver.Domain.Domain;
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
            await connect.ExecuteAsync("INSERT INTO Regions (RegionId, PostOfficeId, Name) VALUES (@RegionId, @PostOfficeId, @Name) FROM Regions r INNER JOIN PostOffices p ON r.PostOfficeId = p.OfficeId", new {Region.RegionId, Region.PostOfficeId, Region.RegionName});
        }

        public async Task<Region> GetRegionByIdAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            return await connect.QueryFirstOrDefaultAsync<Region>("SELECT * FROM Regions WHERE RegionId = @Id", new {Id});
        }

        public async Task<Region> GetRegionByOfficeIdAsync(Guid OfficeId)
        {
            var connect = _connection.Connect(connectionString);
            return await connect.QueryFirstOrDefaultAsync<Region>("SELECT * FROM REGIONS WHERE PostOfficeId = @OfficeId", new {OfficeId});
        }

        public async Task RemoveRegionAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("DELETE r FROM Regions r INNER JOIN PostOffices p ON c.PostOfficeId = p.OfficeId WHERE Regionid = @Id", new {Id});
        }

        public async Task UpdateRegionAsync(Region Region)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("UPDATE Regions r SET r.RegionName = @RegionName,", new {Region.RegionName});
        }
    }
}