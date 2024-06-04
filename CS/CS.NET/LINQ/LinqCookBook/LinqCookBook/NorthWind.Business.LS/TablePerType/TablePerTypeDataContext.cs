using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Business.LS.TablePerType
{
    public partial class TablePerTypeDataContext
    {
        partial void InsertEmployee(Employee instance)
        {
            int? empid = instance.EmployeeId;
            if (instance is HourlyEmployee)
            {
                HourlyEmployee emp = instance as HourlyEmployee;
                this.InsertHourlyEmployee(ref empid, emp.Name, emp.Email, emp.Hours, emp.Rate);
                instance.EmployeeId = empid.Value;
            }
            if (instance is SalariedEmployee)
            {
                SalariedEmployee emp = instance as SalariedEmployee;
                this.InsertSalariedEmployee(ref empid, emp.Name, emp.Email, emp.Salary, emp.VacationDays);
                instance.EmployeeId = empid.Value;
            }
            if (instance is CommissionedEmployee)
            {
                CommissionedEmployee emp = instance as CommissionedEmployee;
                this.InsertCommissionedEmployee(ref empid, emp.Name, emp.Email, emp.CommPerc, emp.ItemsSold);
                instance.EmployeeId = empid.Value;
            }
        }

        partial void DeleteEmployee(Employee instance)
        {
            if (instance is HourlyEmployee)
            {
                this.DeleteHourlyEmployee(instance.EmployeeId);
            }
        }
    }

}
