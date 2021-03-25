using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//01:10:00 timer
namespace The_PIG_Dice_Game_Application.Models
{
    public static class SessionExtensions
    {
        // static method requires static class
        public static void SetObject<T>(this ISession session, string key, T value) // generic T
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObject<T>(this ISession session,string key)
        {
            var jsonstring=session.GetString(key);
            if (string.IsNullOrEmpty(jsonstring))
            {
                return default(T); // return default constructor
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(jsonstring);
            }
        }
    }
}
