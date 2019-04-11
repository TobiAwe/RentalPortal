using System;
using System.Threading.Tasks;
using Ninject;
using RentalPortal.Order.Data;
using RentalPortal.Order.Persistence.Repository.Interfaces;

namespace RentalPortal.Order.Persistence.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : OrderDbContext
    {
        [Inject]
        public IEquipmentRepository Equipment { get; set; }
        [Inject]
        public IOrderRepository Orders { get; set; }
        [Inject]
        public ICartRepository Carts { get; set; }
        [Inject]
        public ISettingRepository Settings { get; set; }

        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public void Complete()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private volatile bool _isDisposing;

        private void Dispose(bool disposing)
        {
            if (_isDisposing) return;

            _isDisposing = disposing;
            _context.Dispose();
            _isDisposing = false;
        }

  
    }
}

