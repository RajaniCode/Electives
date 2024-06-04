using System;
using System.Security.Principal;

namespace MvcApplication1.Tests.Models
{
    public class FakeIdentity : IIdentity
    {
        private string _name;

        public FakeIdentity(string name)
        {
            _name = name;
        }

        #region IIdentity Members

        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return _name; }
        }

        #endregion
    }
}
