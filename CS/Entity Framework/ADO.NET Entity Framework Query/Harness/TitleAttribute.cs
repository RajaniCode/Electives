using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleQueries.Harness
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class TitleAttribute : Attribute
    {
        public TitleAttribute(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }
    }
}
