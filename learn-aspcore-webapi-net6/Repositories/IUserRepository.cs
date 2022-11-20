using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
