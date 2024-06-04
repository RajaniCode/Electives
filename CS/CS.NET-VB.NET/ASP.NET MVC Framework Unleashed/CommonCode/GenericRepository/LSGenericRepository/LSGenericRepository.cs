using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace GenericRepository
{
    public class LSGenericRepository : GenericRepositoryBase
    {

        private DataContext _context;

        public LSGenericRepository(DataContext context)
        {
            _context = context;
        }


        public override IQueryable<T> List<T>() 
        {
            return _context.GetTable<T>();
        }

        public override T Get<T>(int id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));           
        }

        public override void Create<T>(T entityToCreate)
        {
            _context.GetTable<T>().InsertOnSubmit(entityToCreate);
            _context.SubmitChanges();
        }


        public override void Edit<T>(T entityToEdit)
        {
            _context.GetTable<T>().Attach(entityToEdit, true);
            _context.SubmitChanges();
        }

        public override void Delete<T>(T entityToDelete)
        {
            _context.GetTable<T>().Attach(entityToDelete);
            _context.GetTable<T>().DeleteOnSubmit(entityToDelete);
            _context.SubmitChanges();
        }
    }
}
