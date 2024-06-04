using System.Security.Principal;
using System;
using MvcApplication1.Tests.Models;

public class FakePrincipal : IPrincipal
{

    private string _name;

    public FakePrincipal(string name)
    {
        _name = name;
    }

    #region IPrincipal Members

    public IIdentity Identity
    {
        get { return new FakeIdentity(_name); }
    }

    public bool IsInRole(string role)
    {
        throw new NotImplementedException();
    }

    #endregion
}
