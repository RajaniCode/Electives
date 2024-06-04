using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web;

namespace MvcFakes
{
    public class CacheWrapper : ICache
    {
        private Cache _cache;

        public CacheWrapper(Cache cache)
        {
            _cache = cache;
        }

        public void Insert(string key, object value)
        {
            _cache.Insert(key, value);
        }

        public void Insert(string key, object value, CacheDependency dependency)
        {
            _cache.Insert(key, value, dependency);
        }

        public void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            _cache.Insert(key, value, dependency, absoluteExpiration, slidingExpiration);
        }

        public void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, System.Web.Caching.CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            _cache.Insert(key, value, dependency, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);

        }

        public void Add(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            _cache.Add(key, value, dependency, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);

        }

        public object Remove(string key)
        {
            return _cache.Remove(key);
        }


        public object this[string key]
        {
            get { return _cache[key]; }
            set { _cache[key] = value; }
        }

        public int Count
        {
            get { return _cache.Count; }
        }


        public System.Collections.IEnumerator GetEnumerator()
        {
            return _cache.GetEnumerator();
        }

    }
}
