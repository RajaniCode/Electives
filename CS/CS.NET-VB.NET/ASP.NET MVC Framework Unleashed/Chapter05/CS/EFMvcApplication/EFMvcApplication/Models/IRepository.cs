using GenericRepository;

namespace EFMvcApplication.Models
{
    interface IRepository : IGenericRepository
    {
        int GetProductCount();
    }
}
