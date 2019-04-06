using System;
using RentalPortal.Order.Common.Enums;

namespace RentalPortal.Order.Entities
{
    public class Equipment 
    {
        public  int EquipmentId { get; set; }
        public  string Name { get; set; }
        public int StockCount { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
