using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Basket.Entities;

namespace RentalPortal.Basket.Data
{
    public class EfDbContext : DbContext
    {
        public DbSet<CartItem> CartItems { get; set; }
    }
}
