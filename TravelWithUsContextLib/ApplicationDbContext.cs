using Microsoft.EntityFrameworkCore;
using TravelWithUs.Models;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TravelWithUs.DBContext
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
 
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
 
    }
}

