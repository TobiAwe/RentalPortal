using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPortal.Basket.Entities
{
        public class CartItem
        {
            public string CartItemId { get; set; }
            public string UserId { get; set; } 
            public int EquipmentId { get; set; }
            public int NoOfDays { get; set; }
            public DateTime DateCreated { get; set; }           
            public string Equipment { get; set; }

        }


 }
