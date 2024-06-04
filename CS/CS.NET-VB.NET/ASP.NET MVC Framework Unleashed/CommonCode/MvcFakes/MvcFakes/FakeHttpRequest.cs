using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace MvcFakes
{
    public class FakeHttpRequest : HttpRequestBase
    {
        private string _appRelativePath;
        private string _httpMethod;
        private bool _isAuthenticated;
        private NameValueCollection _form;
 
        public FakeHttpRequest()
        {
        }


        public FakeHttpRequest(string appRelativePath)
            :this(appRelativePath, "GET")
        {
        }


        public FakeHttpRequest(string appRelativePath, string httpMethod)
            :this(appRelativePath, httpMethod, false, new NameValueCollection())
        {
        }


        public FakeHttpRequest(string appRelativePath, string httpMethod, bool isAuthenticated, NameValueCollection form)
        {
            _appRelativePath = appRelativePath;
            _httpMethod = httpMethod;
            _isAuthenticated = isAuthenticated;
            _form = form;
        }

        public override string HttpMethod
        {
            get
            {
                return _httpMethod;
            }
        }


        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                if (_appRelativePath == null)
                    _appRelativePath = "~/";

                return _appRelativePath;
            }
        }


        public override bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
        }

        public override string RawUrl
        {
            get
            {
                return String.Empty;
            }
        }


        public override string PathInfo
        {
            get
            {
                return String.Empty;
            }
        }


        public override void ValidateInput()
        {
        }


        public override NameValueCollection Form
        {
            get
            {
                return _form;
            }
        }


    }
}
