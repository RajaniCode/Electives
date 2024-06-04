using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleQueries.Harness
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class LinkedMethodAttribute : Attribute
    {
        public LinkedMethodAttribute(string methodName)
        {
            this.MethodName = methodName;
        }

        public string MethodName { get; set; }
    }
}