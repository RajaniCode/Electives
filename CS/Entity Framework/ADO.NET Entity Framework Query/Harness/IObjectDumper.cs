using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleQueries.Harness
{
    public interface IObjectDumper
    {
        void Write(object o);
        void Write(object o, int expandDepth);
        void Write(object o, int expandDepth, int maxLoadDepth);
    }
}
