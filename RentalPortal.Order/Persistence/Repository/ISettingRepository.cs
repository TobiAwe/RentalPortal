using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Persistence.Repository
{
    public interface ISettingRepository : IRepository<Setting>
    {
        string GetSettingsAsync(string name);
        
    }
}
