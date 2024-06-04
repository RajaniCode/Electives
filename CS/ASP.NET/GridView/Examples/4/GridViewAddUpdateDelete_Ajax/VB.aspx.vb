Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Partial Class VB
    Inherits System.Web.UI.Page
    Private strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim strQuery As String = "select CustomerID,ContactName,CompanyName" & _
                                " from customers"
        Dim cmd As New SqlCommand(strQuery)
        GridView1.DataSource = GetData(cmd)
        GridView1.DataBind()
    End Sub

    Private Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        con.Open()
        sda.SelectCommand = cmd
        sda.Fill(dt)
        Return dt
    End Function
    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        BindData()
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub AddNewCustomer(ByVal sender As Object, ByVal e As EventArgs)
        Dim CustomerID As String = DirectCast(GridView1.FooterRow _
                .FindControl("txtCustomerID"), TextBox).Text
        Dim Name As String = DirectCast(GridView1 _
                .FooterRow.FindControl("txtContactName"), TextBox).Text
        Dim Company As String = DirectCast(GridView1 _
                .FooterRow.FindControl("txtCompany"), TextBox).Text
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into customers(CustomerID, ContactName, " & _
        "CompanyName) values(@CustomerID, @ContactName, @CompanyName);" & _
        "select CustomerID,ContactName,CompanyName from customers"
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = Name
        cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Company
        GridView1.DataSource = GetData(cmd)
        GridView1.DataBind()
    End Sub

    Protected Sub DeleteCustomer(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from customers where " & _
        "CustomerID=@CustomerID;" & _
        "select CustomerID,ContactName,CompanyName from customers"
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value _
            = lnkRemove.CommandArgument
        GridView1.DataSource = GetData(cmd)
        GridView1.DataBind()
    End Sub
    Protected Sub EditCustomer(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        BindData()
    End Sub
    Protected Sub CancelEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        BindData()
    End Sub
    Protected Sub UpdateCustomer(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim CustomerID As String = DirectCast(GridView1.Rows(e.RowIndex) _
                                .FindControl("lblCustomerID"), Label).Text
        Dim Name As String = DirectCast(GridView1.Rows(e.RowIndex) _
                                .FindControl("txtContactName"), TextBox).Text
        Dim Company As String = DirectCast(GridView1.Rows(e.RowIndex) _
                                .FindControl("txtCompany"), TextBox).Text
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update customers set ContactName=@ContactName," _
        & "CompanyName=@CompanyName where CustomerID=@CustomerID;" _
        & "select CustomerID,ContactName,CompanyName from customers"
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = Name
        cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Company
        GridView1.EditIndex = -1
        GridView1.DataSource = GetData(cmd)
        GridView1.DataBind()
    End Sub
End Class
