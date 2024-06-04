using System.Data.Services;

namespace WCF_DMLService
{
    public class CustomerDataService : DataService<CompanyEntities>
    {
        // Code file for the www.dotnetcurry.com article - www.dotnetcurry.com/ShowArticle.aspx?ID=571
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(IDataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("Customer", EntitySetRights.All);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            
        }
    }
}
