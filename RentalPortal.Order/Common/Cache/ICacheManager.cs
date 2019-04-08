using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPortal.Order.Common.Cache
{
    public interface ICacheManager
    {
        void Add(string key, object value, TimeSpan idle = default(TimeSpan));
        object Get(string key);
        void Remove(string key);
        bool Contains(string key);
    }
}
