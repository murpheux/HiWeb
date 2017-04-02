using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace HiMVC.Services
{
    public class CacheServices : ICache
    {

        string host = "gru";

        public void Set<T>(string key, T value)
        {
            using (var client = ConnectionMultiplexer.Connect(host))
            {
                //if (client.Get<string>(key) == null)
                //{
                //    // save value in cache
                //    client.Set(key, value);
                //}
            }
        }

        public T Get<T>(string key)
        {
            using (var client = ConnectionMultiplexer.Connect(host))
            {
                try
                {
                    // get value from the cache by key
                    return default(T); // client.Get<T>(key);
                }
                catch
                {
                    return default(T);
                }
            }
        }

    }
}
