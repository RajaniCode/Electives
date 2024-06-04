using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleQueries.Harness;
using System.Collections;

namespace SampleQueries.Dumper
{
    public class NullObjectDumper : IObjectDumper
    {
        public static readonly IObjectDumper Instance = new NullObjectDumper();

        private NullObjectDumper()
        {
        }

        #region IObjectDumper Members

        public void Write(object o)
        {
            if (o is IEnumerable)
            {
                foreach (object o2 in (IEnumerable)o)
                {
                }
            }
        }

        public void Write(object o, int expandDepth)
        {
            Write(o);
        }

        public void Write(object o, int expandDepth, int maxLoadDepth)
        {
            Write(o);
        }

        #endregion
    }
}
