using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RentalPortal.Web.Models
{
    public class Login
    {
        [JsonProperty("username")]
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [JsonProperty("password")]
        [Required, Display(Name = "Password", Prompt = "password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}