using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Persistence.Repository.Interfaces
{
    public interface ISettingRepository : IRepository<Setting>
    {
        string GetSettingsAsync(string name);
        
    }
}
