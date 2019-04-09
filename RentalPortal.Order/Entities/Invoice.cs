using System.Collections.Generic;

namespace RentalPortal.Order.Entities
{
    public class Invoice
    {
        public string Title { get; set; }
        public IList<Rent> Rents { get; set; }
        public decimal TotalPrice { get; set; }
        public int Bonus { get; set; }
    }

    public class Rent
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }

    //• Title
   // • Line items for every rental, displaying name and rental price
    //• Summary displaying total price and number of bonus points earned
}
