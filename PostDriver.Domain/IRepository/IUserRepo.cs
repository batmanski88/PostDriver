using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Domain.Domain;

namespace PostDriver.Domain.IRepository
{
    public interface IUserRepo 
    {
        Task<User> GetUserByIdAsync(Guid Id);
        Task<User> GetUserByEmailAsync(string Email);
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User User);
        Task UpdateUserAsync(User User);
        Task RemoveUserAsync(Guid Id); 
    }
}