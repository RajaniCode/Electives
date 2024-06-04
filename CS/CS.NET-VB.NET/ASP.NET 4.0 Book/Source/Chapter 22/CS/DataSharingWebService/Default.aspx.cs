using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void BtnPopulate_Click(object sender, EventArgs e)
    {
      
 localhost.TypeSharingWebService1CS service1 = new   localhost.TypeSharingWebService1CS();
        //'Change this URL if the location of the Web service changes

 service1.Url = "http://localhost:2099/DataSharingWebService/TypeSharingWebService1CS.asmx";
        localhost.EmpDetails EmpDetail = service1.ObtainEmpDetail("James", "Rojer","Frank");
        lblPopEmpDetails.Text = "Success!  You have Populated Employee Details.";
        //Save the EmpDetails instance so that it can later be shared
        Session["EmpDetails"] = EmpDetail;

    }
    protected void BtnUpdateDetails_Click(object sender, EventArgs e)
    {

        if (Session["EmpDetails"] == null)
        {
            ErrEmpDetails.Text = "Error. You must first Populate Employee Details.";
            return;
        }
        localhost.TypeSharingWebService2CS service2 = new     localhost.TypeSharingWebService2CS();
        //Change this URL if the location of the Web service changes
        service2.Url = "http://localhost:2099/DataSharingWebService/TypeSharingWebService2CS.asmx";
        //Retrieve the EmpDetails instance and pass it to the second service
        localhost.EmpDetails EmpDetail = (localhost.EmpDetails)Session["EmpDetails"];
        localhost.EmpDetails updatedIEmpDetails = service2.UpdateEmpDetail(EmpDetail,"EMP005", "Manager");
        //Print out the details from the updated updatedIEmpDetails
        string UpdatedEmpDetail = "Employee Details are : ";
        UpdatedEmpDetail = UpdatedEmpDetail + "<br>First Name :" +   updatedIEmpDetails.EmpFirstName;
        UpdatedEmpDetail = UpdatedEmpDetail + "<br>Middle Name :" +  updatedIEmpDetails.EmpMiddleName;
        UpdatedEmpDetail = UpdatedEmpDetail + "<br>Last Name :" +    updatedIEmpDetails.EmpLastName;
        UpdatedEmpDetail = UpdatedEmpDetail + "<br>ID :" + updatedIEmpDetails.EmpID;
        UpdatedEmpDetail = UpdatedEmpDetail + "<br>Designation :" +  updatedIEmpDetails.EmpDesignation;
        EmpDetailsLabel.Text = UpdatedEmpDetail;
        //Save the updated EmpDetails instance
        Session["EmpDetails"] = updatedIEmpDetails;

    }
}