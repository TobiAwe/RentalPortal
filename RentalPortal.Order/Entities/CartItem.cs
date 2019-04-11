using System;
using System.ComponentModel.DataAnnotations;
using RentalPortal.Order.Common.Helpers;

namespace RentalPortal.Order.Entities
{
    public class CartItem
    {
        public CartItem()
        {
            CartItemId = SequentialGuid.NewGuid();
        }
        [Key]
        public Guid CartItemId { get; set; }
        public string UserId { get; set; }
        public int EquipmentId { get; set; }
        public int NoOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Equipment Equipment { get; set; }


    }
}
