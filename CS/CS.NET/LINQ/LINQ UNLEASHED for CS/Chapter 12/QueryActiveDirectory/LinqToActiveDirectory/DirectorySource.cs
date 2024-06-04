using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace LinqToActiveDirectory
{
  public class DirectorySource<T> : IOrderedQueryable<T>, IDirectorySource
  {
    private DirectoryEntry searchRoot;
    private SearchScope searchScope;
    private TextWriter log;

    public DirectorySource(DirectoryEntry searchRoot, SearchScope searchScope)
    {
      this.searchRoot = searchRoot;
      this.searchScope = searchScope;
    }


    public TextWriter Log
    {
      get { return log; }
      set { log = value; }
    }

    public DirectoryEntry Root
    {
      get { return searchRoot; }
    }

    public SearchScope Scope
    {
      get { return searchScope; }
    }

    public Type ElementType
    {
      get { return typeof(T); }
    }

    public Type OriginalType
    {
      get { return typeof(T); }
    }

    public Expression Expression
    {
      get { return Expression.Constant(this); }
    }

    public IQueryProvider Provider
    {
      get { return new DirectoryQueryProvider(); }
    }

    
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new DirectoryQuery<T>(this.Expression).GetEnumerator();
    }
  }
}