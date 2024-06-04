using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SampleQueries.Harness;

namespace SampleQueries.Runner
{
    public class SampleGroup : SampleBase
    {
        private IList<SampleBase> _children = new List<SampleBase>();

        public SampleGroup(SampleSuite sampleSuite,
            string title,
            string description)
            : base(sampleSuite, title, description)
        {
        }

        public IList<SampleBase> Children
        { 
            get { return _children; }
        }
    }
}
