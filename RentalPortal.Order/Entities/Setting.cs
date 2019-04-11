using System.ComponentModel.DataAnnotations;

namespace RentalPortal.Order.Entities
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
