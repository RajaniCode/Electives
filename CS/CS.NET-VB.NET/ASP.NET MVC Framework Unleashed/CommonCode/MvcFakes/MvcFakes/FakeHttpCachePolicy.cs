using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcFakes
{
    public class FakeHttpCachePolicy : HttpCachePolicyBase
    {
        public override void SetProxyMaxAge(TimeSpan delta)
        {
        }

        public override void AddValidationCallback(HttpCacheValidateHandler handler, object data)
        {
        }
    }
}
