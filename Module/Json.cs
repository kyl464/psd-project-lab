using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDProject.Module
{
    public class Json<T>
    {
        public static string Encode(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
        }

        public static T Decode(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}