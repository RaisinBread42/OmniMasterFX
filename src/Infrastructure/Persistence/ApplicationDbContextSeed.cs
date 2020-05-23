using OmniMasterFX.Domain.Entities;
using OmniMasterFX.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OmniMasterFX.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            var seedFile = string.Concat(Directory.GetParent(Directory.GetCurrentDirectory()), "\\infrastructure\\Migrations\\Seeds\\Initial.sql");
            context.Database.ExecuteSqlCommandAsync(File.ReadAllText(seedFile));
            //await context.SaveChangesAsync();
        }
    }
}
