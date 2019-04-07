using System;
using System.Collections.Generic;
using RentalPortal.Order.Common.Enums;

namespace RentalPortal.Order.Entities
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public  string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderRequestItem> OrderRequestItems { get; set; }




    }
}
