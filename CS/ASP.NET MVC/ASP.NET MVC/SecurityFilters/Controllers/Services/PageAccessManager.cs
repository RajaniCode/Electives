using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace SecurityFilters.Controllers.Services
{
    public class PageAccessManager
    {
        public static bool IsAccessAllowed(string Controller, string Action, IPrincipal User, string IP)
        {
            if (Controller == "Public")
                return true;
            if (Controller == "Registered" && Action == "Login")
                return true;
            if (Controller == "Registered" && Action != "Login" && (User.IsInRole("Registered") || User.IsInRole("Admin")))
                return true;
            if (Controller == "Admin" && User.IsInRole("Admin"))
                return true;

            return false;
        }

    }
}