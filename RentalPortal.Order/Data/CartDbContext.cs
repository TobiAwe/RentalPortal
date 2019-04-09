using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Data
{
    public class CartDbContext : DbContext
    {
        public DbSet<CartItem> CartItems { get; set; }
    }
}
