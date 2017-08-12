using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Domain.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PostDriver;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly IConnectionFactory _connection;

        public UserRepo(IConnectionFactory connection)
        {
            _connection = connection;
        }
        
        public async Task AddUserAsync(User User)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("INSERT INTO Users (UserName, Email, Password, FullName, Role, CreatedAt) VALUES (@Username, @Email, @Password, @FullName, @Role, @CreatedAt)", User);
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            var connect = _connection.Connect(connectionString);
            var user = await Task.FromResult(connect.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Email"));
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            var user = await Task.FromResult(connect.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Id"));
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var connect = _connection.Connect(connectionString);
            var users = await connect.QueryAsync<User>("SELECT * FROM Users") as List<User>;
            return users;
        }

        public async Task RemoveUserAsync(Guid Id)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("DELETE u FROM Users u");
        }

        public async Task UpdateUserAsync(User User)
        {
            var connect = _connection.Connect(connectionString);
            await connect.ExecuteAsync("UPDATE Users u SET u.Email = @Email, u.Password = @Password, u.ConfirmPassword = @ConfirmPassword, u.FullName = @FullName, u.UserName = @UserName, u.Role = @Role , u.UpdateAt = @UpdateAt", User);
        }
    }
}