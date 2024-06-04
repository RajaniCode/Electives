Imports System.Data.SqlClient
Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub lnkCustDetails_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Fetch the customer id
        Dim lb As LinkButton = TryCast(sender, LinkButton)
        Dim custID As String = lb.Text
        lblCustValue.Text = custID
        ' Connection
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
        Dim sql As String = "SELECT CompanyName, ContactName, Address FROM Customers WHERE CustomerID = @CustID"
        Dim connection As New SqlConnection(constr)
        Dim cmd As New SqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@CustID", custID)
        cmd.CommandType = CommandType.Text
        connection.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        ' Bind the reader to the GridView
        ' You can also use a lighter control 
        ' like the Repeater to display data
        GridView2.DataSource = dr
        GridView2.DataBind()
        connection.Close()
        ' Show the modalpopupextender
        ModalPopupExtender1.Show()

    End Sub

End Class
