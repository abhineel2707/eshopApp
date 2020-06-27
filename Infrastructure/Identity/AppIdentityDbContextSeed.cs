using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Test User",
                    Email = "test@test.com",
                    UserName = "test@test.com",
                    Address = new Address
                    {
                        FirstName = "test",
                        LastName = "user",
                        Street = "17th Street",
                        City = "Zombieland",
                        State = "Never Come Here",
                        Zipcode = "000007"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}