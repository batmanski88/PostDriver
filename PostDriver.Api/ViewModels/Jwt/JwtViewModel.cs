using System;

namespace PostDriver.Api.ViewModels.Jwt
{
    public class JwtViewModel
    {
        public Guid TokenId { get ; set; }
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}