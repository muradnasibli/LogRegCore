using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogRegIdentity.Models
{
    public class AppIdentityUserDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityUserDbContext(DbContextOptions<AppIdentityUserDbContext> dbContext) : base(dbContext)
        {
        }
    }
}
