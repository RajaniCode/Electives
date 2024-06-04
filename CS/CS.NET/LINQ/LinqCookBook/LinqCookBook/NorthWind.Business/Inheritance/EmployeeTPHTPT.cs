using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace EmInheritance.TPTTPH
{
    public partial class EmployeeTPHTPT
    {
        public ObjectQuery<Customer> Customers
        {
            get{return this.Persons.OfType<Customer>();}
        }
        public ObjectQuery<Employee> Employees
        {
            get { return this.Persons.OfType<Employee>(); }
        }
        public ObjectQuery<ClubMember> ClubMembers
        {
            get { return this.Persons.OfType<ClubMember>(); }
        }
        public ObjectQuery<HourlyEmployee> HourlyEmployees
        {
            get { return this.Persons.OfType<HourlyEmployee>(); }
        }
        public ObjectQuery<SalariedEmployee> SalariedEmployees
        {
            get { return this.Persons.OfType<SalariedEmployee>(); }
        }
    }
}
