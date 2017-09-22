using System;
using PostDriver.Api.ViewModels.Jwt;

namespace PostDriver.Api.Services
{
    public interface IJwtHandler 
    {
         JwtViewModel CreateToken(Guid userId, string role);
    }
}