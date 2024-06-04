using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindEFModel;
using SampleQueries.Harness;

namespace SampleQueries.Samples
{
    class NorthwindBasedSample : SampleSuite
    {
        protected NorthwindEntities context;

        public NorthwindBasedSample()
            : base()
        {
        }

        public override void InitSample(string connectionString)
        {
            if (context != null)
                context.Dispose();

            context = CreateContext(connectionString);
        }

        public override void TearDownSample()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }

        public NorthwindEntities CreateContext(string connectionString)
        {
            NorthwindEntities ent = new NorthwindEntities(connectionString);
            ent.Connection.Open();
            return ent;
        }
    }
}
