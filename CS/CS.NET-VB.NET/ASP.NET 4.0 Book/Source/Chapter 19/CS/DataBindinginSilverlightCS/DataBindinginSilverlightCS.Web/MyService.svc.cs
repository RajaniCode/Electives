using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataBindinginSilverlightCS.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    public class MyService : IMyService
    {
        public void DoWork()
        {
        }

        #region IMyService Members
        public List<Employee> GetByLastName(string lastname)
        {
           // throw new NotImplementedException();
            DataBindinginSilverlightCS.Web.MyClassDataContext db = new MyClassDataContext();
            var data = from p in db.Employees
                       where p.LastName.StartsWith(lastname)
                       select p;
            return data.ToList();
        }
        #endregion 
    }
}
