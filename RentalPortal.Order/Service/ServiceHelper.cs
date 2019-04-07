using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RentalPortal.Order.Common;
using RentalPortal.Order.Common.Enums;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence;

namespace RentalPortal.Order.Service
{
    public class ServiceHelper: IServiceHelper
    {
    private readonly IUnitOfWork _uow;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ServiceHelper(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
    {
    _uow = uow;
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

                var email = passedToken.Claims.FirstOrDefault(c => c.Type == "email");

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
            decimal oneTimeRentalFee  =decimal.Parse("100");
            decimal premiumDailyFee = decimal.Parse("60");
            decimal regularDailyFee = decimal.Parse("40");
      
            //get total number of days
           var amount = decimal.Parse("0");
           var check = int.TryParse(NumberOfDays(ori.StartDate, ori.EndDate), out int numberOfDays);
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
                    decimal firstHalf = decimal.Parse("0");
                    decimal secondHalf = decimal.Parse("0");
                    firstHalf = numberOfDays >= 2 ? firstHalf + 2 * premiumDailyFee : firstHalf + premiumDailyFee;
                    if (numberOfDays > 2){secondHalf = secondHalf + (numberOfDays - 2) * regularDailyFee;}
                    amount = amount + oneTimeRentalFee + firstHalf + secondHalf;
                    break;
                case EquipmentType.Specialized:
                    // • Specialized – rental price is premium fee for the first 3 days plus regular fee times the number of days over 3.
                    decimal sFirstHalf;
                    decimal sSecondHalf = decimal.Parse("0");

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

                    amount = amount + sFirstHalf + sSecondHalf;
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

    }
}
