using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract()]
public interface IMyService
{
    [OperationContract]
    string MyTask1(string MyValue);
    [OperationContract]
    string MyTask2(DataContract1 dcValue);
}

// NOTE: If you change the class name "Service" here, you must also update the reference to "Service" in Web.config and in the associated .svc file.
public class Service : IMyService
{
    public string MyTask1(string Myvalue)
    {
        return "Hello: " + Myvalue;
    }
    public string MyTask2(DataContract1 dcValue)
    {
        return "Hello: " + dcValue.FirstName;
    }
}
[DataContract]
public class DataContract1
{
    string firstName;
    string lastName;
    [DataMember]
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    [DataMember]
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
}
