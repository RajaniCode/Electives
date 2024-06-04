using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericRepository
{
    public abstract class GenericRepositoryBase : IGenericRepository
    {
        const string KeyPropertyName = "Id";

        protected Expression<Func<T, bool>> CreateGetExpression<T>(int id)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(KeyPropertyName);
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(id, typeof(int));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }


        protected int GetKeyPropertyValue<T>(object entity)
        {
            return (int)typeof(T).GetProperty(KeyPropertyName).GetValue(entity, null);
        }


        #region IGenericRepository Members

        public abstract IQueryable<T> List<T>() where T : class;
 
        public abstract T Get<T>(int id) where T:class;

        public abstract void Create<T>(T entityToCreate) where T : class;

        public abstract void Edit<T>(T entityToEdit) where T : class;

        public abstract void Delete<T>(T entityToDelete) where T : class;
 
        #endregion
    }
}
