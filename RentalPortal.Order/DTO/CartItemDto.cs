using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPortal.Order.DTO
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public string UserId { get; set; }
        public int EquipmentId { get; set; }
        public int NoOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public string Equipment  { get; set; }

    }
}
