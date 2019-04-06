using System;

namespace RentalPortal.Order.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Equipment { get; set; }
    }
}
