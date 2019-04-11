using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Data
{
    public class OrderDbContext : DbContext 
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }
        //public OrderDbContext()
        //{
        //}
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }

    }
}
