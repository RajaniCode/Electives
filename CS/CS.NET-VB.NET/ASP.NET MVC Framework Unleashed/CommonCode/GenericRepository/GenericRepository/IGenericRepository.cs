using System.Collections.Generic;
using System.Linq;

namespace GenericRepository
{
    public interface IGenericRepository
    {
        IQueryable<T> List<T>() where T:class;
        T Get<T>(int id) where T : class;
        void Create<T>(T entityToCreate) where T : class;
        void Edit<T>(T entityToEdit) where T : class;
        void Delete<T>(T entityToDelete) where T : class;
    }
}