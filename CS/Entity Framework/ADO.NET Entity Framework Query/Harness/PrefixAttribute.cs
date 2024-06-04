using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleQueries.Harness
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class PrefixAttribute : Attribute
    {
        public PrefixAttribute(string prefix)
        {
            this.Prefix = prefix;
        }

        public string Prefix { get; set; }
    }
}
