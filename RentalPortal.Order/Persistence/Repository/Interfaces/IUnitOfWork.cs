using System;
using System.Threading.Tasks;

namespace RentalPortal.Order.Persistence.Repository.Interfaces
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
