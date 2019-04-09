using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Data
{
    public class EfDbContext : DbContext 
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }

    }
}
