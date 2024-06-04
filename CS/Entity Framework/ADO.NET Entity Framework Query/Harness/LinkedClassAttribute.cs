using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleQueries.Harness
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class LinkedClassAttribute : Attribute
    {
        public LinkedClassAttribute(string className)
        {
            this.ClassName = className;
        }

        public string ClassName { get; set; }
    }
}
