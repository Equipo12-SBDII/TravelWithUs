using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Security
{
    public class SecuritySeed
    {

        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, TravelWithUsDbContext context)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, context);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager, TravelWithUsDbContext context)
        {

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var user = new ApplicationUser
                {   
                    FirstName = "Jose",
                    LastName = "Perez",
                    Level = 1,
                    NormalizedUserName = "ADMIN",
                    UserName = "Admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,

                };
                try
                {
                    IdentityResult identityResult = userManager.CreateAsync(user, "Password123!").Result;
                    if (identityResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
                catch (Exception e)
                {
                    var d = e.InnerException;
                }
            }

        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult identityResult = roleManager.CreateAsync(role).Result;
            }

        }



    }
}
