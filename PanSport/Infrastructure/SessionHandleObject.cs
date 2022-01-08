using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Infrastructure
{
    public static class SessionHandleObject
    {
        public static void Put<T>(this ISession session, string key, T value) where T : class
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key) where T : class
        {
            string str = session.GetString(key);
            return str == null ? null : JsonConvert.DeserializeObject<T>(str);
        }
    }
}
