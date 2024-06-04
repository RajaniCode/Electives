using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Collections;

namespace MvcFakes
{
    public interface ICache : IEnumerable
    {

        void Insert(string key, object value);
        void Insert(string key, object value, CacheDependency dependency);
        void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);

        void Add(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);

        object Remove(string key);

        int Count { get; }

        object this[string key] { get; set; }


    }
}
