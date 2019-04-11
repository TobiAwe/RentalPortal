using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RentalPortal.Order.Common;
using RentalPortal.Order.Common.Cache;
using RentalPortal.Order.Common.Enums;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence;
using RentalPortal.Order.Persistence.Repository.Interfaces;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Service
{
    public class ServiceHelper: IServiceHelper
    {
    private readonly IUnitOfWork _uow;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICacheManager _cacheManager;
    private readonly ISettingRepository _settingRepository;

        public ServiceHelper(IHttpContextAccessor httpContextAccessor, ICacheManager cacheManager, IUnitOfWork uow,ISettingRepository settingRepository)
        {
            _cacheManager = cacheManager;
            _uow = uow;
            _settingRepository = settingRepository;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

    public Task<RentalPortalGenericException> GetExceptionAsync(string errorCode)
    {

         throw new  RentalPortalGenericException("Error validating your request. Please try again.", errorCode);
    }

 

    public string GetCurrentUserEmail()
    {

            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = authorizationHeader.Split(" ")[1];
                var passedToken = tokenHandler.ReadJwtToken(token);

                var email = passedToken.Claims.FirstOrDefault(c => c.Type == "sub");

                if (email != null) return email.Value;
            }

            throw new ArgumentNullException("email");
        }


    public string NumberOfDays(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).TotalDays.ToString("####");
    }

    public decimal CalculateAmount(OrderRequestItem ori)
        {

            var oneTimeRentalFee = int.Parse(GetOrUpdateCacheItem("oneTimeRentalFee", () => _settingRepository.GetSettingsAsync("oneTimeRentalFee")));
            var premiumDailyFee = int.Parse(GetOrUpdateCacheItem("premiumDailyFee", () => _settingRepository.GetSettingsAsync("premiumDailyFee")));
            var regularDailyFee = int.Parse(GetOrUpdateCacheItem("regularDailyFee", () => _settingRepository.GetSettingsAsync("regularDailyFee")));

            
            //get total number of days
           var amount = 0;
           var check = int.TryParse(NumberOfDays(ori.StartDate, ori.EndDate), out var numberOfDays);
           if (!check)
           {
               return amount;
           }

           switch (ori.Equipment.EquipmentType)
          {
                case EquipmentType.Heavy:
                    //Heavy – rental price is one-time rental fee plus premium fee for each day rented.
                    amount = amount + oneTimeRentalFee + (numberOfDays * premiumDailyFee);
                    break;
                case EquipmentType.Regular:
                    //Regular – rental price is one - time rental fee plus premium fee for the first 2 days plus regular fee for the number of days over 2.
                    var firstHalf = 0;
                    var secondHalf = 0;
                    firstHalf = numberOfDays >= 2 ? firstHalf + 2 * premiumDailyFee : firstHalf + premiumDailyFee;
                    if (numberOfDays > 2){secondHalf = secondHalf + (numberOfDays - 2) * regularDailyFee;}
                    amount = amount + oneTimeRentalFee + firstHalf + secondHalf;
                    break;
                case EquipmentType.Specialized:
                    // • Specialized – rental price is premium fee for the first 3 days plus regular fee times the number of days over 3.
                    var sSecondHalf = 0;

                    decimal sFirstHalf;
                    if (numberOfDays <= 2)
                    {
                        if (numberOfDays == 2)
                        {
                            sFirstHalf = 2 * premiumDailyFee;
                        }
                        else
                        {
                            sFirstHalf = premiumDailyFee;
                        }
                    }
                    else
                    {
                        sFirstHalf = 3 * premiumDailyFee;
                    }

                    if (numberOfDays > 3)
                    {
                        sSecondHalf = (numberOfDays - 3) * regularDailyFee;
                    }

                    amount = (int) (amount + sFirstHalf + sSecondHalf);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
          }

          return amount;
        }

    public decimal CalculateTotalOrderAmount(OrderDto order)
    {
        decimal amount = decimal.Parse("0");
        if (order.OrderRequestItems.Any())
        {
            foreach (var item in order.OrderRequestItems)
            {
                amount = amount + CalculateAmount(item);
            }
        }
        return amount;
    }

    public int CalculateTotalOrderBonus(OrderDto order)
    {
        int counter = 0;
        if (order.OrderRequestItems.Any())
        {
            foreach (var item in order.OrderRequestItems)
            {
                switch (item.Equipment.EquipmentType)
                    {
                        case EquipmentType.Heavy:
                            counter = counter + 2;
                            break;
                        default:
                            counter = counter + 1;
                            break;
                    }
            }
        }

        return counter;
    }


    public T GetOrUpdateCacheItem<T>(string key, Func<T> update, TimeSpan idle = default(TimeSpan))
    {
        if (_cacheManager.Contains(key))
        {
            return (T)_cacheManager.Get(key);
        }

        var result = update.Invoke();

        if (result != null)
        {
            _cacheManager.Add(key, result, idle);
        }

        return result;
    }

    public void RemoveCachedItem(string key)
    {
        _cacheManager.Remove(key);
    }

    }
}
