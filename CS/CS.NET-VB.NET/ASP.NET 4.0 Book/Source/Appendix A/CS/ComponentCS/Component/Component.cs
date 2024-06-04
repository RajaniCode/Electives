using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.EnterpriseServices;
using System.Reflection;

[assembly: ApplicationName("Component")]
[assembly: ApplicationAccessControl(false)]
[assembly: ApplicationActivation(ActivationOption.Server, SoapVRoot = "Component")]
[assembly: Description("Simple Serviced Component Sample")]
[assembly: AssemblyKeyFile("Component.snk")]


namespace Component
{
    public interface IMathOperation
    {
        int Add(int num1, int num2);
    }
    [EventTrackingEnabled(true)]
    [Description("Simple Serviced Component Sample")]

    public class Component : ServicedComponent, IMathOperation
    {
        public Component()
        {

        }

        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
