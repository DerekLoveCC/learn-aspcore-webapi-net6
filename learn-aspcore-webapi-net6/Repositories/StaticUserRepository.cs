using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User
            {
                FirstName = "Read Only",
                LastName="User",
                EmailAddress="readonly@user.com",
                Id=Guid.NewGuid(),
                Username="readonly@user.com",
                Password="readonly@user",
            },
            new User
            {
                FirstName = "Read Write",
                LastName="User",
                EmailAddress="readwrite@user.com",
                Id=Guid.NewGuid(),
                Username="readwrite@user.com",
                Password="readwrite@user",
            },
        };

        public StaticUserRepository() { }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            return user;
        }
    }
}
