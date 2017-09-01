using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.AccountViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;
using Xunit;

namespace PostDriver.Tests.Services
{
    public class UserServiceTest
    {
         [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepo>();
            var encrypterMock = new Mock<IEncrypter>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");
            var jwtHandlerMock = new Mock<IJwtHandler>();
            var cacheMock = new Mock<IMemoryCache>();
            var mapperMock = new Mock<IMapper>();
            var model = new RegisterViewModel
            {
                UserId = Guid.NewGuid(),
                Email = "user1@email.com",
                Password = "secret",
                ConfirmPassword = "secret",
                Username = "user1"
            };

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, jwtHandlerMock.Object, cacheMock.Object, mapperMock.Object);

            await userService.RegisterAsync(model);

            userRepositoryMock.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Once);

        }

        [Fact]
        public async Task where_calling_get_user_by_email_async_and_user_exists_it_should_invoke_user_repository_get_user_by_email_async()
        {
            var userRepositoryMock = new Mock<IUserRepo>();
            var encrypterMock = new Mock<IEncrypter>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");
            var jwtHandlerMock = new Mock<IJwtHandler>();
            var cacheMock = new Mock<IMemoryCache>();
            var mapperMock = new Mock<IMapper>();
           
            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, jwtHandlerMock.Object, cacheMock.Object, mapperMock.Object);

            await userService.GetUserByEmailAsync("user1@mail.com");

            var user = new User(Guid.NewGuid(), "user1", "user1@email.com", "secret", "salt", "user");
            

            userRepositoryMock.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);

            userRepositoryMock.Verify(x => x.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Where_calling_get_user_by_email_async_and_user_not_extsts_it_should_invoke_user_repository_get_user_by_email_async()
        {
            var userRepositoryMock = new Mock<IUserRepo>();
            var encrypterMock = new Mock<IEncrypter>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");
            var jwtHandlerMock = new Mock<IJwtHandler>();
            var cacheMock = new Mock<IMemoryCache>();
            var mapperMock = new Mock<IMapper>();
           
            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, jwtHandlerMock.Object, cacheMock.Object, mapperMock.Object);

            await userService.GetUserByEmailAsync("user1@mail.com");

            userRepositoryMock.Setup(x => x.GetUserByEmailAsync("user@mail.com")).ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
        }
    }
}