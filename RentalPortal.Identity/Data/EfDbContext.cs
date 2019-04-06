using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Identity.Entities;

namespace RentalPortal.Identity.Data
{
    public class EfDbContext : IdentityDbContext<AppUser>
    {
        public EfDbContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}

