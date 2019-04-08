using System;
using System.Threading.Tasks;
using RentalPortal.Order.Common;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Service
{
    public interface IServiceHelper
    {
        Task<RentalPortalGenericException> GetExceptionAsync(string errorCode);
        string GetCurrentUserEmail();
        string NumberOfDays(DateTime startDate, DateTime endDate);
        decimal CalculateAmount(OrderRequestItem ori);
        decimal CalculateTotalOrderAmount(OrderDto order);
        int CalculateTotalOrderBonus(OrderDto order);
        T GetOrUpdateCacheItem<T>(string key, Func<T> update, TimeSpan idle = default(TimeSpan));
        void RemoveCachedItem(string key);
    }
}
