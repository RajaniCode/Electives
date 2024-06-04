Imports System.Data
Imports System.Data.SqlClient
Imports GCheckout.Util
Imports GCheckout.Checkout
Public Class WebForm2
    Inherits System.Web.UI.Page
    Public Shared passengers As Integer
    Public Shared class1, classfare As String
    Dim adp, adp1, adp2, adp3 As SqlDataAdapter
    Public Shared dataset As DataSet = New DataSet()
    Dim ds As DataSet = New DataSet()
    Dim con As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString.ToString()
    Dim conn As New SqlConnection(con)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            'displaying the station name from the SQL Server database
            adp = New SqlDataAdapter("Select distinct DepartStation from TrainDetails", conn)
            ds.Clear()
            adp.Fill(ds, "TrainDetails")

            'binding the items in the From drop down list
            dlFrom.Items.Clear()
            dlFrom.Items.Add("Select Station")
            For Each dr As DataRow In ds.Tables("TrainDetails").Rows
                dlFrom.Items.Add(dr("DepartStation").ToString())
            Next dr

            adp1 = New SqlDataAdapter("Select distinct ArrivalStation from TrainDetails", conn)
            ds.Clear()
            adp1.Fill(ds, "TrainDetails")

            'binding the items in the To drop down list
            dlTo.Items.Clear()
            dlTo.Items.Add("Select Station")
            For Each dr As DataRow In ds.Tables("TrainDetails").Rows
                dlTo.Items.Add(dr("ArrivalStation").ToString())
            Next dr
            If Session("PostBack") = "true" Then
                Dim From, [to], [date], passengers As String

                From = Request.QueryString("Parameter1").Trim()
                [to] = Request.QueryString("Parameter2").Trim()
                [date] = Request.QueryString("Parameter3").Trim()
                class1 = Request.QueryString("Parameter4").Trim()
                passengers = Request.QueryString("Parameter5").Trim()
                classfare = Request.QueryString("Parameter6").Trim()

                dlFrom.SelectedValue = From
                dlTo.SelectedValue = [to]
                txtDate.Text = [date]
                dlClass.SelectedValue = class1
                dlpassengers.SelectedValue = passengers

                adp2 = New SqlDataAdapter("Select * from TrainDetails Where DepartStation = '" & From & "' and ArrivalStation = '" & [to] & "' and DepartureDate = '" & [date] & "' and " & class1 & ">=" & passengers, conn)
                dataset.Clear()
                adp2.Fill(dataset, "TrainDetails")
                If dataset.Tables("TrainDetails").Rows.Count > 0 Then
                    gvTrainDetails.DataSource = dataset
                    gvTrainDetails.DataBind()
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
            End If
        End If
    End Sub

    Protected Sub gvTrainDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gvTrainDetails.SelectedIndexChanged
        Session("PostBack") = "false"
        Dim id As String = dataset.Tables("TrainDetails").Rows(gvTrainDetails.SelectedIndex)("TrainId").ToString()
        adp3 = New SqlDataAdapter("Select * from TrainDetails Where TrainId = " & id, conn)
        ds.Clear()
        adp3.Fill(ds, "TrainDetials")

        Dim gc As GCheckoutButton = New GCheckoutButton()
        Dim route As String = "Ticket(s) from " & ds.Tables(0).Rows(0)("DepartStation").ToString() & " to " & ds.Tables(0).Rows(0)("ArrivalStation").ToString() & " on " & ds.Tables(0).Rows(0)("DepartureDate").ToString()
        Dim Travelclass As String = "In " & dlClass.SelectedValue
        Dim price As Decimal = Convert.ToDecimal(ds.Tables(0).Rows(0)(classfare).ToString())
        Dim passengers As Integer = Convert.ToInt32(dlpassengers.SelectedValue)

        Dim Req As CheckoutShoppingCartRequest = gc.CreateRequest()
        Req.AddItem(route, Travelclass, price, passengers)
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
        ElseIf Convert.ToDateTime(txtDate.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()) Then
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
            If dlClass.SelectedValue = "Sleeper Class" Then
                class1 = "SleeperClass"
                classfare = "SleeperClassFare"
            ElseIf dlClass.SelectedValue = "AC First Class" Then
                class1 = "ACFirstClass"
                classfare = "ACFirstClassFare"
            ElseIf dlClass.SelectedValue = "2 Tier" Then
                class1 = "[2Tier]"
                classfare = "2TierFare"
            ElseIf dlClass.SelectedValue = "3 Tier" Then
                class1 = "[3Tier]"
                classfare = "3TierFare"
            End If
            adp2 = New SqlDataAdapter("Select TrainID, DepartStation as 'Departure Station', ArrivalStation as 'Arrival Station', DepartureDate as 'Depart Date', DepartureTime as 'Depart Time', [" & classfare & "] as Fare from TrainDetails Where DepartStation = '" & dlFrom.SelectedValue & "' and ArrivalStation = '" & dlTo.SelectedValue & "' and DepartureDate = '" & txtDate.Text & "' and " & class1 & ">=" & dlpassengers.SelectedValue, conn)
            dataset.Clear()
            adp2.Fill(dataset, "TrainDetails")
            If dataset.Tables("TrainDetails").Rows.Count > 0 Then
                gvTrainDetails.DataSource = dataset
                gvTrainDetails.DataBind()
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
        End If
    End Sub
End Class