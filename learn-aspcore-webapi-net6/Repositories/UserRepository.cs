using learn_aspcore_webapi_net6.Data;
using learn_aspcore_webapi_net6.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace learn_aspcore_webapi_net6.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public UserRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await nZWalksDbContext.Users.FirstOrDefaultAsync(x => x.Username.Equals(username) && x.Password.Equals(password));

            if (user == null)
            {
                return null;
            }

            user.Roles = new List<string>();
            var userRoles = await nZWalksDbContext.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();
            if (userRoles.Any())
            {
                foreach (var userRole in userRoles)
                {
                    var role = await nZWalksDbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }
    }
}
