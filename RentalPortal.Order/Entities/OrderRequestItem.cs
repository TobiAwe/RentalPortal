using System;

namespace RentalPortal.Order.Entities
{
    public class OrderRequestItem
    {
        public int OrderRequestItemId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //FK
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public int OrderId { get; set; }
        public virtual  OrderRequest OrderRequest { get; set; }
    }
}
