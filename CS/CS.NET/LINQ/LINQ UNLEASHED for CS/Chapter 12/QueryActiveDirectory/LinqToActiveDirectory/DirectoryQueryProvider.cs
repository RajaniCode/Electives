using System;
using System.Linq;
using System.Linq.Expressions;

namespace LinqToActiveDirectory
{
  public class DirectoryQueryProvider : IQueryProvider
  {
  
    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
      return new DirectoryQuery<TElement>(expression);
    }

    public IQueryable CreateQuery(Expression expression)
    {
      throw new NotImplementedException();
    }
  
    public TResult Execute<TResult>(Expression expression)
    {
      throw new NotImplementedException();
    }

    public object Execute(Expression expression)
    {
      throw new NotImplementedException();
    }

    




  }
}