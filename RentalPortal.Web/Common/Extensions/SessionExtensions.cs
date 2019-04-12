using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RentalPortal.Web.Common.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static bool ContainsKey(this ISession session, string key)
        {
            return session.GetString(key) != null;
        }
    }

}
