namespace PostDriver.Api.Services
{
    public interface IEncrypter : IService
    {
         string GetSalt(string value);
         string GetHash(string value, string salt);
    }
}