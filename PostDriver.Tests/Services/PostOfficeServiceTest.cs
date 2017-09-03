using System.Threading.Tasks;
using AutoMapper;
using Moq;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.PostOfficeViewModel;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;
using Xunit;

namespace PostDriver.Tests.Services
{
    public class PostOfficeServiceTest
    {
        [Fact]
        public async Task add_post_office_should_invoke_add_post_office_on_repository()
        {
            var officeMock = new Mock<IPostOfficeRepo>();
            var mapperMock = new Mock<IMapper>();
            var model = new AddPostOfficeViewModel
            {
                Name = "UP1",
                Adress = "Świętokrzyska 12, Warszawa",
                Longitude = 34.12,
                Latitude = 35.34
            };

            var postOfficeService = new PostOfficeService(officeMock.Object, mapperMock.Object);
            
            await postOfficeService.AddOfficeAsync(model);

            officeMock.Verify(x => x.AddPostOfficeAsync(It.IsAny<PostOffice>()), Times.Once);
            
        }
    }
}