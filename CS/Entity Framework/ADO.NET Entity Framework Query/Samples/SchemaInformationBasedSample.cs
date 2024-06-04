using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindEFModel;
using System.Data.EntityClient;
using System.Configuration;
using System.Data.Entity.Design;
using SampleQueries.Harness;

namespace SampleQueries.Samples
{
    class SchemaInformationBasedSample : SampleSuite
    {
        protected Store.SchemaInformation context;
        private EntityConnection schemaConnection;

        public SchemaInformationBasedSample()
            : base()
        {
        }

        public override void InitSample(string connectionString)
        {
            // parse connection string to get provider name and provider connection string

            EntityConnectionStringBuilder csb = new EntityConnectionStringBuilder();
            csb.ConnectionString = connectionString;

            // create schema connection
            schemaConnection = EntityStoreSchemaGenerator.CreateStoreSchemaConnection(csb.Provider, csb.ProviderConnectionString);
            schemaConnection.Open();

            context = new Store.SchemaInformation(schemaConnection);
        }

        public override void TearDownSample()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
            if (schemaConnection != null)
            {
                schemaConnection.Dispose();
                schemaConnection = null;
            }
            base.TearDownSample();
        }
    }
}
