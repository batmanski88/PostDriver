using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.PostOfficeViewModels;

namespace PostDriver.Api.Services
{
    public interface IPostOfficeService
    {
         Task<IEnumerable<PostOfficeViewModel>> GetOfficesAsync();
         Task AddOfficeAsync(AddPostOfficeViewModel model);
         Task RemoveOffice(Guid OfficeId);
         Task<PostOfficeViewModel> GetPostOfficeByNameAsync(string Name);
    
    }
}