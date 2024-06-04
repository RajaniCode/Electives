Imports System.Data
Imports System.Data.SqlClient
Imports GCheckout.Util
Imports GCheckout.Checkout
Public Class WebForm7
    Inherits System.Web.UI.Page

    Public Shared Rentaltype, city As String
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim con As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString.ToString()
    Dim conn As New SqlConnection(con)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            If Session("PostBack") = "true" Then
                Session("PostBack") = "false"
                city = Request.QueryString("Parameter1").Trim()
                Rentaltype = Request.QueryString("Parameter2").Trim()

                If Rentaltype = "FullDayRent" Then
                    adp = New SqlDataAdapter("Select FullDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails", conn)
                ElseIf Rentaltype = "HalfDayRent" Then
                    adp = New SqlDataAdapter("Select HalfDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails", conn)
                End If
                ds = New DataSet()
                adp.Fill(ds, "CarDetails")

                gvCarDetails.DataSource = ds
                gvCarDetails.DataBind()
            End If
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        If rbBanglore.Checked = True Then
            city = "Banglore"
        ElseIf rbChennai.Checked = True Then
            city = "Chennai"
        ElseIf rbDelhi.Checked = True Then
            city = "Delhi"
        ElseIf rbJaipur.Checked = True Then
            city = "Jaipur"
        ElseIf rbKolkata.Checked = True Then
            city = "Kolkata"
        ElseIf rbMumbai.Checked = True Then
            city = "Mumbai"
        End If
        If rbfullDay.Checked = True Then
            Rentaltype = "FullDayRent"
            adp = New SqlDataAdapter("Select FullDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails Where City = '" & city & "'", conn)
        ElseIf rbHalfDay.Checked = True Then
            Rentaltype = "HalfDayRent"
            adp = New SqlDataAdapter("Select HalfDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails Where City = '" & city & "'", conn)
        End If
        ds = New DataSet()
        adp.Fill(ds, "CarDetails")

        gvCarDetails.DataSource = ds
        gvCarDetails.DataBind()
    End Sub

    Protected Sub gvCarDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gvCarDetails.SelectedIndexChanged
        Session("CarPostback") = "true"
        Response.Redirect("~/Car_Address.aspx?Parameter1=" & gvCarDetails.SelectedRow.Cells(2).Text & "&Parameter2=" & Rentaltype & "&Parameter3=" & city)
    End Sub
End Class