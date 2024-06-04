using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleQueries.Harness
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
