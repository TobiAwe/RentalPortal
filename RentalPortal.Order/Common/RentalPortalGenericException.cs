using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPortal.Order.Common
{
    public class RentalPortalGenericException : Exception
    {
        public string ErrorCode { get; set; }

        public RentalPortalGenericException(string message) : base(message)
        {
        }

        public RentalPortalGenericException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
