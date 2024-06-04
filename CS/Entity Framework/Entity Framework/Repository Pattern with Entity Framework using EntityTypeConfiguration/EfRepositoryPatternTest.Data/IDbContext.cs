using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Data
{
    public interface IDbContext
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity:class;
        int SaveChanges();
        void Dispose();
    }
}
