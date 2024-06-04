using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcFakes
{
    public class FakeHttpResponse : HttpResponseBase
    {
        private int _statusCode;
        private HttpCachePolicyBase _cachePolicy = new FakeHttpCachePolicy();

        public override int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
            }
        }

        public override HttpCachePolicyBase Cache
        {
            get
            {
                return _cachePolicy;
            }
        }

    }
}
