using Microsoft.AspNetCore.Identity;

namespace RentalPortal.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

