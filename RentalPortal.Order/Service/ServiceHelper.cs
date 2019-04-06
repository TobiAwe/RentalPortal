using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RentalPortal.Order.Common;
using RentalPortal.Order.Persistence;

namespace RentalPortal.Order.Service
{
    public class ServiceHelper: IServiceHelper
    {
    private readonly IUnitOfWork _uow;

    public ServiceHelper(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<RentalPortalGenericException> GetExceptionAsync(string errorCode)
    {

            throw new RentalPortalGenericException("Error validating your request. Please try again.", errorCode);
    }

 

    public string GetCurrentUserEmail()
    {
        
        return "Anonymous";
    }

    }
}
