using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToActiveDirectory;
using ActiveDs;

namespace QueryActiveDirectory
{
  [DirectorySchema("user", typeof(IADsUser))]
  class MyUser : DirectoryEntity
  {
    private DateTime expiration;

    [DirectoryAttribute("AccountExpirationDate", DirectoryAttributeType.ActiveDs)]
    public DateTime AccountExpirationDate
    {
      get { return expiration; }
      set
      {
        if (expiration != value)
        {
          expiration = value;
          OnPropertyChanged("AccountExpirationDate");
        }
      }
    }

    private string first;

    [DirectoryAttribute("givenName")]
    public string FirstName
    {
      get { return first; }
      set
      {
        if (first != value)
        {
          first = value;
          OnPropertyChanged("FirstName");
        }
      }
    }

    private string last;

    [DirectoryAttribute("sn")]
    public string LastName
    {
      get { return last; }
      set
      {
        if (last != value)
        {
          last = value;
          OnPropertyChanged("LastName");
        }
      }
    }

    private string office;

    [DirectoryAttribute("physicalDeliveryOfficeName")]
    public string Office
    {
      get { return office; }
      set
      {
        if (office != value)
        {
          office = value;
          OnPropertyChanged("Office");
        }
      }
    }

    private string accoutName;

    [DirectoryAttribute("sAMAccountName")]
    public string AccountName
    {
      get { return accoutName; }
      set
      {
        if (accoutName != value)
        {
          accoutName = value;
          OnPropertyChanged("AccountName");
        }
      }
    }

    public bool SetPassword(string password)
    {
      return this.DirectoryEntry.Invoke("SetPassword", new object[] { password }) == null;
    }
  }
}