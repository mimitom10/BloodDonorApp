using BloodDonor.Common;
using BloodDonor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        private const string adminEmail = "admin@abv.bg";
        private const string adminPass = "Admin123456Admin";
        private const string adminRole = "Administrator";


        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
            };

            var result = await userManager.CreateAsync(user, adminPass);


            await userManager.AddToRoleAsync(user, adminRole);
            //    await dbContext.Categories.AddAsync(new Category
        }
    }
}
