using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Models;

namespace TravelWithUsService.Security
{
    public class SecuritySeed
    {

        public static void SeedData(UserManager<Turista> userManager, RoleManager<IdentityRole> roleManager,TravelWithUsDbContext context)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager,context);
        }

        private static void SeedUsers(UserManager<Turista> userManager, TravelWithUsDbContext context)
        {
           
            if(userManager.FindByNameAsync("Admin").Result == null)
            {
                var user = new Turista
                { 
                    Nombre = "Admin",
                    TuristaID = 100,
                    Nacionalidad = "Cuba"
                    NormalizedUserName = "ADMIN",
                    UserName = "Admin",
                    // SecurityStamp = Guid.NewGuid().ToString(),
                    // LockoutEnabled = false,
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
