Imports System.Data
Imports System.Data.SqlClient
Imports GCheckout.Util
Imports GCheckout.Checkout
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim adp, adp1, adp2, adp3 As SqlDataAdapter
    Public Shared dataset As DataSet = New DataSet()
    Dim ds As DataSet = New DataSet()
    Dim con As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString.ToString()
    Dim conn As New SqlConnection(con)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            'Retrieving the city names from the database.
            adp = New SqlDataAdapter("Select distinct BFrom from BusDetails", conn)
            ds.Clear()
            adp.Fill(ds, "BusDetails")

            'binding the items in the From drop down list
            dlFrom.Items.Clear()
            dlFrom.Items.Add("Select a City")
            For Each dr As DataRow In ds.Tables("BusDetails").Rows
                dlFrom.Items.Add(dr("BFrom").ToString())
            Next dr

            adp1 = New SqlDataAdapter("Select distinct [BTo] from BusDetails", conn)
            ds.Clear()
            adp1.Fill(ds, "BusDetails")

            'binding the items in the To drop down list
            dlTo.Items.Clear()
            dlTo.Items.Add("Select a City")
            For Each dr As DataRow In ds.Tables("BusDetails").Rows
                dlTo.Items.Add(dr("BTo").ToString())
            Next dr

            If Session("PostBack") = "true" Then
                Dim From, [to], [date], passenger As String
                Session("PostBack") = "false"

                From = Request.QueryString("Parameter1").Trim()
                [to] = Request.QueryString("Parameter2").Trim()
                [date] = Request.QueryString("Parameter3").Trim()
                passenger = Request.QueryString("Parameter4").Trim()

                adp2 = New SqlDataAdapter("Select * from BusDetails Where [BFrom] = '" & From & "' and [BTo] = '" & [to] & "' and BDate = '" & [date] & "' and SeatsAvailable >=" & passenger, conn)
                dataset.Clear()
                adp2.Fill(dataset, "BusDetails")
                If dataset.Tables("BusDetails").Rows.Count > 0 Then
                    gvBusDetails.DataSource = dataset
                    gvBusDetails.DataBind()
                Else
                    Dim message As String = "No Matching record found"
                    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message)
                    sb.Append("')};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                End If
                dlFrom.SelectedValue = From
                dlTo.SelectedValue = [to]
                txtDepart.Text = [date]
                dlPassengers.SelectedValue = passenger
            End If
        End If


    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        If dlFrom.SelectedValue = dlTo.SelectedValue Then
            Dim message As String = "Departing and Arrival city cannot be same"
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        ElseIf Convert.ToDateTime(txtDepart.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()) Then
            Dim message As String = "The Dearture date is not valid"
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            adp2 = New SqlDataAdapter("Select * from BusDetails Where [BFrom] = '" & dlFrom.SelectedValue & "' and [BTo] = '" & dlTo.SelectedValue & "' and BDate = '" & txtDepart.Text & "' and SeatsAvailable >=" & dlPassengers.SelectedValue, conn)
            dataset.Clear()
            adp2.Fill(dataset, "BusDetails")
            If dataset.Tables("BusDetails").Rows.Count > 0 Then
                gvBusDetails.DataSource = dataset
                gvBusDetails.DataBind()
            Else
                Dim message As String = "No record found for the selected date and location"
                Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If
        End If
    End Sub

    Protected Sub gvBusDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gvBusDetails.SelectedIndexChanged
        Dim id As String = dataset.Tables("BusDetails").Rows(gvBusDetails.SelectedIndex)("BusId").ToString()
        adp3 = New SqlDataAdapter("Select * from BusDetails Where BusID = " & id, conn)
        ds.Clear()
        adp3.Fill(ds, "BusDetials")

        Dim gc As GCheckoutButton = New GCheckoutButton()
        Session("PostBack") = "false"

        Dim route As String = "Ticket(s) from " & ds.Tables(0).Rows(0)("BFrom").ToString() & " to " & ds.Tables(0).Rows(0)("BTo").ToString() & " on " & ds.Tables(0).Rows(0)("BDate").ToString()
        Dim [date] As String = ds.Tables(0).Rows(0)("BDate").ToString()
        Dim price As Decimal = Convert.ToDecimal(ds.Tables(0).Rows(0)("Fare").ToString())
        Dim passengers As Integer = Convert.ToInt32(dlPassengers.SelectedValue)

        Dim Req As CheckoutShoppingCartRequest = gc.CreateRequest()
        Req.AddItem(route, [date], price, passengers)
        Dim Resp As GCheckoutResponse = Req.Send()
        Dim link As String = Resp.RedirectUrl.ToString()

        Dim ln As LoginName = CType(Master.FindControl("LoginName1"), LoginName)
        Dim username As String = ln.Page.User.Identity.Name
        If (Not ln.Page.User.Identity.IsAuthenticated) Then
            Session("PostBack") = "false"
            Dim message As String = "Please login before booking the tickets."
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            Response.Redirect(Resp.RedirectUrl, True)
            'Response.Redirect("~/PaymentDetails_Bus.aspx?Parameter1= " + id + "&Parameter2= " + dlPassengers.SelectedValue);
        End If

    End Sub
End Class