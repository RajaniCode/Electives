========================================================================
                  CSASPNETMVC3AjaxEnabled Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The Project illustrates how to create a web site with AJAX enabled in MVC
framework. In fact, more site owners wants to shift their sites to MVC, it
turns to be a problem. This sample shows how to use AJAX by XmlHttpRequest,
Ajax helper class and JQuery.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETMVC3AjaxEnabled.sln.

Step 2: Expand the CSASPNETMVC3AjaxEnabled web application and press 
        Ctrl + F5 to show the AjaxComment view.

Step 3: In this page, you will find a Textbox and a Click Me link. Please 
        input some text in TextBox and click the link, the input text will
		show below. If you look carefully, the output text contains "Target
		page return:", it because the page create a XmlHttpRequest and 
		connect to AjaxTarget action.  

Step 4: The you need modify Global.asax file to reset startup action for testing
        other views. For example:
		[code]
		public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Ajax", action = "AjaxComment", id = UrlParameter.Optional } // Parameter defaults
            );

        }
		[/code]
		You need replace "AjaxComment" to "AjaxHelper", then you can
		press ctrl + F5 to show AjaxHelper view. 
		By the way, you can modify the url address for changing to correct view,
		such as "your local address/Ajax/AjaxHelp".

Step 5: In AjaxHelper view, you will find some TextBox controls, input your name,
        age, telephone number and private comments, click submit button, and
		you can find your information below, in a unordered list.

Step 6: Modify action name to "JQueryHelper" follow step 4.

Step 7: Input your messages and click submit button follow step 5

Step 8: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET MVC 3 Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETMVC3AjaxEnabled".

Step 2. Please select empty project template.

Step 3. Add a model class in Models folder, the model class is used to manage 
        data for our application, name it as "Person.cs".

Step 4. The model class code as shown below:
        [code]
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
		[/code]

Step 5. Add an controller class under the Controllers folder, name it as "AjaxController.cs".
		
Step 6  The AjaxController class contains all actions of this sample, The 
        code as shown below
		[code]
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
	    [/code] 

Step 7. Add action views form controller class, the AjaxComment view use to handle XmlHttpRequest
        and send data to AjaxTarget action.
		AjaxComment.cshtml
		[code]
    <script type="text/javascript">
    var xmlHttpRequest;
    function Ajax() {
        if (window.ActiveXObject) {
            xmlHttpRequest = new ActiveXObject("Microsoft.XMLHTTP");
        }
        else if (window.XMLHttpRequest) {
            xmlHttpRequest = new XMLHttpRequest();
        }
        else {
            document.getElementById("output").innerHTML = "Do not support Ajax.";
        }
        var targetUrl = "Ajax/AjaxTarget?resource=" + document.getElementById("tbInput").value;
        xmlHttpRequest.open("GET", targetUrl, true);
        xmlHttpRequest.onreadystatechange = Success;
        xmlHttpRequest.send(null);
    }

    function Success() {
        if (xmlHttpRequest.readyState == 4) {
            if (xmlHttpRequest.status == 200) {
                document.getElementById("output").innerHTML += xmlHttpRequest.responseText+"<br />";
            }
        }
    }
    </script>
    <input type="text" id="tbInput" />
    <div id="output" >
    </div>
    <a href="#" onclick="Ajax();">Click me</a>
		[/code]

Step 8. AjaxHelper.cshtml use Ajax.BeginForm method to connect DisplayPerson
        action, and this action can validate input messages and send relative
		messages back.
		[code]
	@model CSASPNETMVC3AjaxEnabled.Models.Person
    @{
        ViewBag.Title = "AjaxHelper";
    }
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.unobtrusive-ajax.js" type="text/javascript"></script>
    <h2>AjaxHelper</h2>

    @using (Ajax.BeginForm("DisplayPerson", new AjaxOptions { UpdateTargetId = "ajaxResult",
	     LoadingElementId = "loading", InsertionMode = InsertionMode.Replace }))
    {
        <p>Name:</p>
        @Html.TextBox("Name", string.Empty, new { style = "width=120px" })
        <p>Age:</p>
        @Html.TextBox("Age", string.Empty, new { style = "width=120px" })
        <p>Telephone:</p>
        @Html.TextBox("Telephone", string.Empty, new { style = "width=120px" })
        <p>Comment:</p>
        @Html.TextBox("Comment", string.Empty, new { style = "width=120px" })
        <br/>
        <input type="submit" value="Submit" />
    }
    <ul id="ajaxResult"></ul>
		[/code]

Step 9. The JQuery.cshtml html code as shown below:
        [code]
	<h2>JQueryHelper</h2>
    <script type="text/javascript">
        function GetJQuery() {
        $.ajax({
            type: "POST",
            url: "/Ajax/DisplayPerson",
            data: "Name=" + $('#Name').attr("value") + "&Age=" + $('#Age').attr("value") +
            "&Telephone=" + $('#Telephone').attr("value") + "&Comment=" + $('#Comment').attr("value"),
            success: function (msg) {
                $("#JqueryResult").Replace(msg);
            }
        });
        }
    </script>


    <p>Name:</p>
        @Html.TextBox("Name", string.Empty, new { style = "width=120px" })
    <p>Age:</p>
        @Html.TextBox("Age", string.Empty, new { style = "width=120px" })
    <p>Telephone:</p>
        @Html.TextBox("Telephone", string.Empty, new { style = "width=120px" })
    <p>Comment:</p>
        @Html.TextBox("Comment", string.Empty, new { style = "width=120px" })
    <br/>
    <input type="button" value="Submit" onclick="GetJQuery()"  />
    <br/>
    <br/>
    <ul id="JqueryResult"></ul>
		[/code] 

Step 10. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: Controller Class
http://msdn.microsoft.com/en-us/library/system.web.mvc.controller.aspx

MSDN: Models and Validation in ASP.NET MVC
http://msdn.microsoft.com/en-us/library/dd410405.aspx
/////////////////////////////////////////////////////////////////////////////