using System;
using RentalPortal.Order.Common.Enums;

namespace RentalPortal.Order.Entities
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public  string Email { get; set; }
        public  DateTime StartDate { get; set; }
        public  DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }

        public OrderStatus OrderStatus { get; set; }


        //FK
        public int EquipmentId { get; set; }
        public  virtual Equipment Equipment { get; set; }

    }
}
