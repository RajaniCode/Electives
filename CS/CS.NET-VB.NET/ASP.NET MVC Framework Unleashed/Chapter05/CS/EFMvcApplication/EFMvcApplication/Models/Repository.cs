using System.Data.Objects;
using System.Linq;
using GenericRepository;

namespace EFMvcApplication.Models
{
    public class Repository : EFGenericRepository, IRepository
    {
        public Repository(ObjectContext context) 
            : base(context) { }
        

        #region IRepository Members

        public int GetProductCount()
        {
            return this.List<Product>().Count();
        }

        #endregion
    }
}
