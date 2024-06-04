using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    private int _CustID;
    public int CustID
    {
        get { return _CustID; }
        set { _CustID = value; }
    }
    private string _CustName;
    public string CustName
    {
        get { return _CustName; }
        set { _CustName = value; }
    }
    private int _CustAge;
    public int CustAge
    {
        get { return _CustAge; }
        set { _CustAge = value; }
    }
    public Customer(int intCustID, string strCustName, int intCustAge)
    {
        _CustID = intCustID;
        _CustName = strCustName;
        _CustAge = intCustAge;
    }

}