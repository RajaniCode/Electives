using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericRepository
{
    public class FakeGenericRepository : GenericRepositoryBase
    {

        private MemoryDatabase _db = new MemoryDatabase();


        #region IGenericRepository Members

        public override IQueryable<T> List<T>()
        {
            return _db.Select<T>();
        }

        public override T Get<T>(int id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override void Create<T>(T entityToCreate)
        {
            _db.Insert<T>(entityToCreate);
        }

        public override void Edit<T>(T originalEntity)
        {
            _db.Update<T>(originalEntity, originalEntity);
        }


        public override void Delete<T>(T entityToDelete)
        {
            _db.Delete<T>(entityToDelete);
        }


        #endregion
    }
}
