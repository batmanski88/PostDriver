using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Domain.Repository
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly string connectionString = "Server=localhost; User Id=SA; Password=Batmanek88; Database=PostDriverDb";
        private readonly IConnectionFactory _connection;

        public CompanyRepo(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task AddCompanyAsync(Company Company)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("INSERT INTO Companies (CompanyId, RegionId, Name, Adress, Longitude, Latitude, StartHour, FinishHour) VALUES (@CompanyId, @RegionId, @Name, @Adress, @Longtitude, @Latitude, @StartHour@, @FinishHour) FROM Companies c INNER JOIN Regions r ON c.RegionId = r.REgionId", new {Company.CompanyId, Company.RegionId, Company.Name, Company.Adress, Company.Longitude, Company.Latitude, Company.StartHour, Company.FinishHour});
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            var connect = _connection.Connect(connectionString);
            return  await connect.QueryAsync<Company>("SELECT * FROM Companies");

        }

        public async Task<Company> GetCompanyByIdAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            var company = await connect.QueryFirstOrDefaultAsync<Company>("SELECT * FROM Companies WHERE CompanyId = @Id", new {Id});

            return company;
        }

        public async Task<Company> GetCompanyByNameAsync(string Name)
        {
            var connect = _connection.Connect(connectionString);
            var company = await connect.QueryFirstOrDefaultAsync<Company>("SELECT * FROM Companies WHERE Name = @Name", new {Name});

            return company;
        }

        public async Task RemoveCompanyAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("DELETE c FROM Companies c INNER JOIN Regions r ON c.RegionId = r.RegionId WHERE Companyid = @Id", new {Id});
        }

        public async Task UpdateCompanyAsync(Company Company)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("UPDATE Companies c SET c.Name = @Name,c.Adress = @Adress, c.Longitude = @Longitude, c.Latitude = @Latitude, c.StartHour = @StartHour, c.FinishHour = @FinishHour", new {Company.Name, Company.Adress, Company.Longitude, Company.Latitude, Company.StartHour, Company.FinishHour});
        }
    }
}