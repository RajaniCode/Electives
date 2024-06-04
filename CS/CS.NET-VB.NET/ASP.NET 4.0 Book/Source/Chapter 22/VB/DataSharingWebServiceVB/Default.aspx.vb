
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnPopulate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPopulate.Click
        Dim service1 As New localhost.TypeSharingWebService1VB()
        'Change this URL if the location of the Web service changes
        service1.Url = "http://localhost:1178/DataSharingWebServiceVB/TypeSharingWebService1VB.asmx"
        Dim EmpDetail As localhost.EmpDetails = service1.ObtainEmpDetail("James", "Rojer", "Frank")
        lblPopEmpDetails.Text = "Success!  You have Populated Employee Details."
        'Save the EmpDetails instance so that it can later be shared
        Session("EmpDetails") = EmpDetail

    End Sub

    Protected Sub BtnUpdateDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdateDetails.Click
        If Session("EmpDetails") Is Nothing Then
            ErrEmpDetails.Text = "Error. You must first Populated Employee Details."
            Return
        End If
        Dim service2 As New localhost.TypeSharingWebService2VB()
        'Change this URL if the location of the Web service changes
        service2.Url = "http://localhost:1178/DataSharingWebServiceVB/TypeSharingWebService2VB.asmx"
        'Retrieve the EmpDetails instance and pass it to the second service
        Dim EmpDetail As localhost.EmpDetails = CType(Session("EmpDetails"), 
         localhost.EmpDetails)
        Dim updatedIEmpDetails As localhost.EmpDetails =
         service2.UpdateEmpDetail(EmpDetail, "EMP005", "Manager")
        'Print out the details from the updated updatedIEmpDetails
        Dim UpdatedEmpDetail As String = "Employee Details are : "
        UpdatedEmpDetail = UpdatedEmpDetail & "<br>First Name :" + updatedIEmpDetails.EmpFirstName
        UpdatedEmpDetail = UpdatedEmpDetail & "<br>Middle Name :" + updatedIEmpDetails.EmpMiddleName
        UpdatedEmpDetail = UpdatedEmpDetail & "<br>Last Name :" + updatedIEmpDetails.EmpLastName
        UpdatedEmpDetail = UpdatedEmpDetail & "<br>ID :" + updatedIEmpDetails.EmpID
        UpdatedEmpDetail = UpdatedEmpDetail & "<br>Designation :" + updatedIEmpDetails.EmpDesignation
        EmpDetailsLabel.Text = UpdatedEmpDetail
        'Save the updated EmpDetails instance
        Session("EmpDetails") = updatedIEmpDetails

    End Sub
End Class
