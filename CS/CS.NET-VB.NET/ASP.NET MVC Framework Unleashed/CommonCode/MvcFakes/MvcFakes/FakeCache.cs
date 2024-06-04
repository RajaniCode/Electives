using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Collections;

namespace MvcFakes
{
    public class FakeCache : ICache
    {

        private Dictionary<string, object> _cacheInternal = new Dictionary<string, object>();

        public void Insert(string key, object value)
        {
            this.Insert(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Insert(string key, object value, CacheDependency dependency)
        {
            this.Insert(key, value, dependency, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);

        }

        public void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            this.Insert(key, value, dependency, absoluteExpiration, slidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Insert(string key, object value, System.Web.Caching.CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, System.Web.Caching.CacheItemPriority priority, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            _cacheInternal[key] = value;
        }

        public void Add(string key, object value, System.Web.Caching.CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, System.Web.Caching.CacheItemPriority priority, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            _cacheInternal.Add(key, value);
        }

        public object Remove(string key)
        {
            object item = null;
            _cacheInternal.TryGetValue(key, out item);
            _cacheInternal.Remove(key);
            return item;
        }

        public object this[string key]
        {
            get
            {
                object item = null;
                _cacheInternal.TryGetValue(key, out item);
                return item;
            }
            set { _cacheInternal[key] = value; }
        }

        public int Count
        {
            get { return _cacheInternal.Count; }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException("GetEnumerator not implemented");
        }



    }
}
