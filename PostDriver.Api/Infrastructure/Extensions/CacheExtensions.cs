using System;
using Microsoft.Extensions.Caching.Memory;
using PostDriver.Api.ViewModels.Jwt;

namespace PostDriver.Api.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, JwtViewModel jwt)
            => cache.Set(GetJwtKey(jwt.TokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtViewModel GetJwt(this IMemoryCache cache, Guid TokenId)
            => cache.Get<JwtViewModel>(GetJwtKey(TokenId));

        private static string GetJwtKey(Guid TokenId)
            => $"jwt-{TokenId}";
    }
}