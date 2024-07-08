

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebAppDbContext _dbContext;

        public UserRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateRole()
        {

            _dbContext.Roles.Add(new IdentityRole("ADMIN"));
            _dbContext.Roles.Add(new IdentityRole("PREMIUM_USER"));
            _dbContext.Roles.Add(new IdentityRole("USER"));

            // _dbContext.Users.AddRange(new IdentityUser("patrykprusko@gmail.com"), new IdentityUser("user@gmail.com"), new IdentityUser("premium_user@gmail.com"));

            await _dbContext.SaveChangesAsync();

        }

        public async Task<string> getRole(string email)
        {
            string role = "";

            if ("patrykprusko@gmail.com" == email)
            {
                var user1 = _dbContext.Users.FirstOrDefault(u => u.Email == email);
                if (user1 != null) 
                {
                    var role1 = await _dbContext.Roles.FirstAsync(r => r.Name == "ADMIN");
                    role1.Id = user1.Id;
                    _dbContext.Roles.Update(role1);
                }
            }
            else if ("user@gmail.com" == email) 
            {
                var user2 = _dbContext.Users.FirstOrDefault(u => u.Email == email);
                if (user2 != null)
                {
                    var role2 = await _dbContext.Roles.FirstAsync(r => r.Name == "USER");
                    role2.Id = user2.Id;
                    _dbContext.Roles.Update(role2);
                }
            }
            else if ("premium_user@gmail.com" == email)
            {
                var user3 = _dbContext.Users.FirstOrDefault(u => u.Email == email);
                if (user3 != null)
                {
                    var role3 = await _dbContext.Roles.FirstAsync(r => r.Name == "PREMIUM_USER");
                    role3.Id = user3.Id;
                    _dbContext.Roles.Update(role3);
                }
            }
            await _dbContext.SaveChangesAsync();


            return role;
        }
    }
}
