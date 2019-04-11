using System;
using System.Threading.Tasks;
using RentalPortal.Order.Data;

namespace RentalPortal.Order.Persistence.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        OrderDbContext Context { get; }

        //IEquipmentRepository Equipment { get; set; }
        //IOrderRepository Orders { get; set; }
        //ICartRepository Carts { get; set; }
        //ISettingRepository Settings { get; set; }

        Task CompleteAsync();
        void Complete();
    }
}
