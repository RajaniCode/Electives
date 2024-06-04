using System.Collections.Generic;
using System.Linq;
namespace DataAccessLibrary
{
    public class DataAccess
    {
        CompanyEntities objDataContext;
        public DataAccess()
        {
            objDataContext = new CompanyEntities();  
        }
        public void CreateEmployee(Employee objEmp)
        {
            objDataContext.AddToEmployee(objEmp);
            objDataContext.SaveChanges(); 
        }
        public List<Employee> GetAllEmployees()
        {
            return objDataContext.Employee.ToList<Employee>();    
        }
        public List<Department> GetAllDepartments()
        {
            return objDataContext.Department.ToList<Department>();   
        }
        public List<Employee> GetAllEmployeeBeDeptName(string DeptName)
        {
            var Res = (from Emp in objDataContext.Employee
                       from Dept in objDataContext.Department
                       where Emp.DeptNo == Dept.DeptNo && Dept.Dname == DeptName
                       select Emp).ToList<Employee>();
            return Res;
        }
    }
}
