using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web.Caching;

namespace MvcFakes
{
    public class FakeHttpContext : HttpContextBase
    {
        private HttpRequestBase _request;
        private IPrincipal _principal;
        private FakeHttpResponse _response = new FakeHttpResponse();

        public FakeHttpContext()
        {
        }

        public FakeHttpContext(string appRelativePath)
            :this(appRelativePath, "GET", false, new NameValueCollection())
        {
        }

        public FakeHttpContext(string appRelativePath, string userName)
            : this(appRelativePath, "GET", true, new NameValueCollection())
        {
            _principal = new FakePrincipal(userName);
        }


        public FakeHttpContext(string appRelativePath, string httpMethod, bool isAuthenticated, NameValueCollection form)
        {
            _request = new FakeHttpRequest(appRelativePath, httpMethod, isAuthenticated, form);
        }




        public FakeHttpContext(HttpRequestBase request)
        {
            _request = request;
        }


        public override HttpRequestBase Request
        {
            get
            {
                if (_request == null)
                    _request = new FakeHttpRequest();
                return _request;
            }
        }

        public override IPrincipal User
        {
            get
            {
                return _principal;
            }
            set
            {
            }
        }


        public override HttpResponseBase Response
        {
            get
            {
                return _response;
            }
        }


    }
}
