using System;
using PostDriver.Api.ViewModels.Jwt;
using PostDriver.Api.Infrastructure.Settings;

namespace PostDriver.Api.Services
{
    public class JwtHandler : IJwtHandler
    {

        private readonly JwtSettings _settings;

        public JwtHandler(JwtSettings settings)
        {
            _settings = settings;
        }

        public JwtViewModel CreateToken(Guid userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}