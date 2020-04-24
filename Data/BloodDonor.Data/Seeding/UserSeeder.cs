using BloodDonor.Common;
using BloodDonor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BloodDonor.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        private const string AdminEmail = "admin@abv.bg";
        private const string AdminPass = "Admin123456Admin";
        private const string AdminRole = "Administrator";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.Users.FirstOrDefault(x => x.Email == AdminEmail) != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                UserName = AdminEmail,
                Email = AdminEmail,
            };

            var result = await userManager.CreateAsync(user, AdminPass);

            await userManager.AddToRoleAsync(user, AdminRole);
        }
    }
}
