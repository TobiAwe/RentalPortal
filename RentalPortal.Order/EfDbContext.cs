using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order
{
    public class EfDbContext : DbContext 
    {
        public  DbSet<Equipment> Equipment { get; set; }
        public DbSet<OrderRequest> OrderRequest { get; set; }

    }
}
