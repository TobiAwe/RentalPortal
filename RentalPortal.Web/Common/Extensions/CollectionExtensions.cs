using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalPortal.Web.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static string ToDelimitedString<T>(this IEnumerable<T> items, string delimeter = ",")
        {
            var list = items.Select(item => Convert.ToString(item)).ToList();

            return 
                list.Count <= 1
                ? $"{list.FirstOrDefault()}"
                : list.Aggregate((previous, next) => $"{previous}{delimeter}{next}");
        }
    }
}
