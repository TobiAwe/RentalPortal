using System;
using System.Threading.Tasks;
using RentalPortal.Order.Persistence.Repository;

namespace RentalPortal.Order.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IEquipmentRepository Equipment { get; set; }
        IOrderRepository Orders { get; set; }

        Task CompleteAsync();
        void Complete();
    }
}
