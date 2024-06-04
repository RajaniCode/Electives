-------------------------------------------------------------
     Sample application for "Design Patterns in ASP.NET" 
-------------------------------------------------------------

To use the sample application, you can open the file DemoSite.sln 
in Visual Studio 2005. This project contains both the main 
application (in the DemoSite folder) and the Web Service that it
uses (in the DemoService folder). 

Alternatively, you can run the application under Internet 
Information Services (IIS). To do this, place the files in a folder
within your default Web site root (wwwroot) and create a virtual 
application for both the DemoSite and DemoService folders in IIS
Manager. Open the Properties window for each folder in IIS 
Manager and click the Create button to create a virtual application
root for each one. Make sure that these application roots are
configured to run under ASP.NET 2.0 (v 2.0.50727) in the ASP.NET
tab of the Properties dialog.

In both VS2005 and IIS, you must also edit the Web.config file in 
the DemoSite folder:

* In the <connectionStrings> section, edit the connection string for
the NorthwindConnectionString item to point to an instance of the 
SQL Server Northwind database (a sample database provided with SQL 
Server). If you do not already have this database, you can attach 
the MDF file provided in the database folder of the sample files.

* In the <appSettings> section, edit the entry for the Web Service
named LocalDemoService.Service to point to the file Service.asmx 
in the DemoService folder. If you are using Visual Studio, you must
include the port number that the Visual Studio Web Server uses. To
find this, run the application and look at the URL in the browser's
address bar. The default value when running under VS is:
http://localhost:1878/DemoService/Service.asmx

-------------------------------------------------------------



   