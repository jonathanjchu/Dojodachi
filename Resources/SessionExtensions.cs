using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Resources
{
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));

            System.Console.WriteLine("Set Session:");
            System.Console.WriteLine(JsonConvert.SerializeObject(value));
            System.Console.WriteLine();
        }

        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static Domogachi GetObjectFromJson(this ISession session, string key)
        {
            string value = session.GetString(key);

            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? new Domogachi() : JsonConvert.DeserializeObject<Domogachi>(value);
        }
    }
}