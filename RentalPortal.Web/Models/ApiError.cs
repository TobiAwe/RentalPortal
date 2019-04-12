using Newtonsoft.Json;

namespace RentalPortal.Web.Models
{
    public class ApiError
    {
        [JsonProperty("error")]
        public string ErrorType { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
