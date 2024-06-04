using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace jQuery_ModalPopUp_In_MVC_4.Models
{
    public class ModelServices
    {
        private readonly MyCompanyEntities entities = new MyCompanyEntities();

        public IEnumerable<Employee> GetEmployee()
        {
            return entities.Employee.ToList();
        } 

        public IEnumerable<Employee> GetEmployeePage(int pageNumber, int pageSize, string searchCriteria)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            return entities.Employee  
                .OrderBy(m =>m.Name)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();
        }
        public int CountAllEmployee()
        {
            return entities.Employee.Count();
        }

        public void Dispose()
        {
            entities.Dispose();
        }

        //For Edit 
        public Employee GetEmployeeDetail(int mCustID)
        {
            return entities.Employee.Where(m => m.ID == mCustID).FirstOrDefault();
        }

        public bool AddEmployee(Employee emp)
        {
            try
            {
                entities.Employee.Add(emp);
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            try
            {
                Employee data = entities.Employee.Where(m => m.ID == emp.ID).FirstOrDefault();

                data.Name = emp.Name;
                data.Dept = emp.Dept;
                data.City = emp.City;
                data.State = emp.State;
                data.Country = emp.Country;
                data.Mobile = emp.Mobile;
                entities.SaveChanges();
                return true;
            }
            catch (Exception mex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int mCustID)
        {
            try
            {
                Employee data = entities.Employee.Where(m => m.ID == mCustID).FirstOrDefault();
                entities.Employee.Remove(data);
                entities.SaveChanges();
                return true;
            }
            catch (Exception mex)
            {
                return false;
            }
        }
    }

    public class PagedEmployeeModel
    {
        public int TotalRows { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
        public int PageSize { get; set; }
    }

    public class EmployeeModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Code")]
        public string Emp_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Department")]
        [UIHint("Multiline")]
        public string Dept { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile")]
        public string Mobile { get; set; }
    }
}