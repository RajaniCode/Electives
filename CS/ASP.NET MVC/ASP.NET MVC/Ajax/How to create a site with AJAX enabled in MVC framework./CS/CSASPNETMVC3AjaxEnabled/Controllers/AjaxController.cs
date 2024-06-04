/****************************** Module Header ******************************\
* Module Name: AjaxController.cs
* Project:     CSASPNETMVC3AjaxEnabled
* Copyright (c) Microsoft Corporation
*
* The Project illustrates how to create a web site with AJAX enabled in MVC
* framework. In fact, more site owners wants to shift their sites to MVC, it
* turns to be a problem. This sample shows how to use AJAX by XmlHttpRequest,
* Ajax helper class and JQuery.
* 
* The controller class in MVC framework provides methods that respond to HTTP
* requests, this class contains all Actions.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSASPNETMVC3AjaxEnabled.Models;
using System.Text;

namespace CSASPNETMVC3AjaxEnabled.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxComment()
        {
            return View();
        }

        public ActionResult AjaxTarget()
        {
            return Content("Target page return :" + Request["resource"]);
        }

        public ActionResult AjaxHelper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DisplayPerson()
        {
            string name = Request["Name"].ToString();
            string age = Request["Age"].ToString();
            string telephone = Request["Telephone"].ToString();
            string comment = Request["Comment"].ToString();
            int intAge;
            Person p = new Person();
            if (name != string.Empty && age != string.Empty && telephone != string.Empty && comment != string.Empty)
            {
                if (!int.TryParse(age, out intAge))
                {
                    return Content("<li>Age must be a integer number</li>");
                }
                else
                {
                    p.Name = name;
                    p.Age = Convert.ToInt32(age);
                    p.Comment = comment;
                    p.Telephone = telephone;
                    StringBuilder strbComment = new StringBuilder();
                    strbComment.Append(String.Format("<li>Name:{0}</li>", Request["Name"].ToString()));
                    strbComment.Append(String.Format("<li>Age:{0}</li>", Request["Age"].ToString()));
                    strbComment.Append(String.Format("<li>Telephone:{0}</li>", Request["Telephone"].ToString()));
                    strbComment.Append(String.Format("<li>Comment:{0}</li>", Request["Comment"].ToString()));
                    return Content(string.Join("\n", strbComment.ToString()));
                }
            }
            else
            {
                return Content("<li>Information incomplete</li>");
            }
        }

        public ActionResult JQueryHelper()
        {
            return View();
        }
    }
}
