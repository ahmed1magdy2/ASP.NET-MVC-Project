using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace MyAccount
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            try
            {
                session.SetString(key, JsonSerializer.Serialize(value));
            }
            catch (Exception ex) { 

            }

        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
