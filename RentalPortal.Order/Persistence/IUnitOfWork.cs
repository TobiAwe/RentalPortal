using System;
using System.Threading.Tasks;
using RentalPortal.Order.Persistence.Repository;
using RentalPortal.Order.Persistence.Repository.Interfaces;

namespace RentalPortal.Order.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IEquipmentRepository Equipment { get; set; }
        IOrderRepository Orders { get; set; }
        ICartRepository Carts { get; set; }
        ISettingRepository Settings { get; set; }

        Task CompleteAsync();
        void Complete();
    }
}
