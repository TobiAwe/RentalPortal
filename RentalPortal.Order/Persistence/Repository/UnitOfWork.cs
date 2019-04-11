using System;
using System.Threading.Tasks;
using Ninject;
using RentalPortal.Order.Data;
using RentalPortal.Order.Persistence.Repository.Interfaces;

namespace RentalPortal.Order.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork //where TContext : OrderDbContext
    {
        ////[Inject]
        //public IEquipmentRepository Equipment { get; set; }
        ////[Inject]
        //public IOrderRepository Orders { get; set; }
        ////[Inject]
        //public ICartRepository Carts { get; set; }
        ////[Inject]
        //public ISettingRepository Settings { get; set; }



        public  OrderDbContext Context { get; }

        public UnitOfWork(OrderDbContext context)
        {
            Context = context;
        }

        public async Task CompleteAsync()
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    await Context.SaveChangesAsync();
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
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.SaveChanges();
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
            Context.Dispose();
            _isDisposing = false;
        }

  
    }
}

