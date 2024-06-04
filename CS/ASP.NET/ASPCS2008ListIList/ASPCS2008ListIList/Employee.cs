using System;
using System.Data;
using System.Configuration;
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
    public class Employee
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }

        internal List<Skills> SkillSet { get; set; }
    }
}
