using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericRepository
{
    public class EFGenericRepository : GenericRepositoryBase
    {
        private ObjectContext _context;


        public EFGenericRepository(ObjectContext context)
        {
            _context = context;
        }


        protected string GetEntitySetName<T>()
        {
            return String.Format("{0}Set", typeof(T).Name);
        }

        #region IGenericRepository Members

        public override IQueryable<T> List<T>()
        {
            return _context.CreateQuery<T>(GetEntitySetName<T>()); 
        }

        public override T Get<T>(int id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));           
        }

        public override void Create<T>(T entityToCreate)
        {
            var entitySetName = GetEntitySetName<T>();
            _context.AddObject(entitySetName, entityToCreate);
            _context.SaveChanges();
        }

        public override void Edit<T>(T entityToEdit)
        {
            var originalEntity = Get<T>(GetKeyPropertyValue<T>(entityToEdit));
            _context.ApplyPropertyChanges(GetEntitySetName<T>(), entityToEdit);
            _context.SaveChanges();
        }

        public override void Delete<T>(T entityToDelete)
        {
            var originalEntity = Get<T>(GetKeyPropertyValue<T>(entityToDelete));
            _context.DeleteObject(originalEntity);
            _context.SaveChanges();
        }


        #endregion
    }
}
