using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;

namespace ASPCS2008ListIList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Employee> EList = GetList();
        }

        private string GetName(string Name, int index)
        {
            string[] FullName = Name.Split(' ');

            if (index == 1)
            {
                return FullName[0];
            }
            else
            {
                return FullName[1];
            }
        }

        private string GetSkills(IDictionary<int, string> SkillsIDictionary, int index)
        {
            return SkillsIDictionary[index].ToString();
        }
        

        private List<Employee> GetList()
        {
            List<Employee> EmployeeList = new List<Employee>();

            try
            {
                List<string> ListNames = new List<string>();
                ListNames.Add("Bill Gates");
                ListNames.Add("Anders Heilsberg");
                ListNames.Add("Herbert Schildt");

                IDictionary<string, string> IDictionarySkills = new Dictionary<string, string>();
                IDictionarySkills.Add("Primary", "ASP.NET, C#, VB.NET");
                IDictionarySkills.Add("Auxiliary", "SQL Server, SSRS, SSIS, SSAS");

                foreach (string s in ListNames)
                {
                    IList<Skills> SkillsIList = new List<Skills>();

                    Employee e = new Employee
                    {
                        FirstName = GetName(s, 1),
                        LastName = GetName(s, 2),
                    };

                    Skills skill = new Skills
                    {
                        Primary = IDictionarySkills["Primary"],
                        Auxiliary = IDictionarySkills["Auxiliary"],
                    };

                    e.SkillSet = new List<Skills>();
                    e.SkillSet.Add(skill);
                    EmployeeList.Add(e);
                }
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
            }
            return EmployeeList;
        }
    }
}
