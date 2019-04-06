using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalPortal.Order.Common;

namespace RentalPortal.Order.Service
{
    public interface IServiceHelper
    {
        Task<RentalPortalGenericException> GetExceptionAsync(string errorCode);
        string GetCurrentUserEmail();
    }
}
