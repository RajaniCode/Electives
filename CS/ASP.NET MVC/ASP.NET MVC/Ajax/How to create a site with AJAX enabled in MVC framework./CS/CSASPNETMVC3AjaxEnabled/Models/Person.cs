/****************************** Module Header ******************************\
* Module Name: Person.cs
* Project:     CSASPNETMVC3AjaxEnabled
* Copyright (c) Microsoft Corporation
*
* The Project illustrates how to create a web site with AJAX enabled in MVC
* framework. In fact, more site owners wants to shift their sites to MVC, it
* turns to be a problem. This sample shows how to use AJAX by XmlHttpRequest,
* Ajax helper class and JQuery.
* 
* The Model class in MVC framework responsible for core application or business
* logic, here we provide a Person model class to record user information.
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

namespace CSASPNETMVC3AjaxEnabled.Models
{
    public class Person
    {
        private string name;
        private int age;
        private string telephone;
        private string comment;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }
    }
}