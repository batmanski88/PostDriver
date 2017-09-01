using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Domain.Domain;

namespace PostDriver.Domain.IRepository
{
    public interface IPostOfficeRepo
    {
         Task<IEnumerable<PostOffice>> GetPostOfficesAsync();
         Task AddPostOfficeAsync(PostOffice Office);
         Task UpdatePostOfficeAsync(PostOffice Office);
         Task<PostOffice> GetPostOfficeByName(string name);
         Task RemovePostOfficeAsync(Guid OfficeId);
         Task<PostOffice> GetPostOfficeByIdAsync(Guid OfficeId);
    }
}