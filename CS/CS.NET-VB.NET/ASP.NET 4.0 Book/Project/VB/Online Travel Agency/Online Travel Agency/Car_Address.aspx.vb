Imports System.Data
Imports System.Data.SqlClient
Imports GCheckout.Util
Imports GCheckout.Checkout
Public Class WebForm6
    Inherits System.Web.UI.Page
    Public Shared carmodel, carrent, city, rentaltype, purpose, pdate, ptime, passengers, paddress, daddress As String
    Public price As Decimal
    Public renttype As String
    Dim adp As SqlDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim con As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString.ToString()
    Dim conn As SqlConnection = New SqlConnection(con)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CarPostback") = "true" Then
            carmodel = Request.QueryString("Parameter1")
            rentaltype = Request.QueryString("Parameter2")
            city = Request.QueryString("Parameter3")
        End If
        Dim ln As LoginName = CType(Master.FindControl("LoginName1"), LoginName)
        If (Not ln.Page.User.Identity.IsAuthenticated) Then
            Session("CarPostback") = "false"
            Response.Redirect("~/Login.aspx?ReturnUrl=Car_Address.aspx") '?Parameter1= " + carmodel + "&Parameter2= " + rentaltype + "&Parameter3= " + city);
        Else
            adp = New SqlDataAdapter("Select " & rentaltype & ", CarModel, Price_ExtraKM, Price_ExtraHour, CarCapacity from CarDetails Where CarModel = '" & carmodel & "' and City = '" & city & "'", conn)
            adp.Fill(ds, "CarDetails")
            lblCarModel.Text += ds.Tables(0).Rows(0)("CarModel").ToString()
            lblCarCapacity.Text += ds.Tables(0).Rows(0)("CarCapacity").ToString()
            lblExtraHour.Text += ds.Tables(0).Rows(0)("Price_ExtraHour").ToString()
            lblExtraKM.Text += ds.Tables(0).Rows(0)("Price_ExtraKM").ToString()
            If rentaltype = "FullDayRent" Then
                lblRent.Text += ds.Tables(0).Rows(0)("FullDayRent").ToString()
                lblPurpose.Text &= "Full Day (80 Kms or 8 Hours)"
                carrent = ds.Tables(0).Rows(0)("FullDayRent").ToString()
                purpose = "Full Day (80 Kms or 8 Hours)"
            ElseIf rentaltype = "HalfDayRent" Then
                lblRent.Text += ds.Tables(0).Rows(0)("HalfDayRent").ToString()
                lblPurpose.Text &= "Half Day (40 Kms or 4 Hours)"
                carrent = ds.Tables(0).Rows(0)("HalfDayRent").ToString()
                purpose = "Half Day (40 Kms or 4 Hours)"
                price = Convert.ToDecimal(ds.Tables(0).Rows(0)("HalfDayRent").ToString())
            End If

            CalendarExtender1.SelectedDate = DateTime.Today.Date.AddDays(2)

            RangeValidator1.Type = ValidationDataType.Date
            RangeValidator1.MinimumValue = DateTime.Now.AddDays(2).ToShortDateString()
            RangeValidator1.MaximumValue = DateTime.Now.AddDays(20000).ToShortDateString()
            RangeValidator1.ErrorMessage = "Please select a date two days after the current date!"

            Dim cap As Integer = Convert.ToInt32(ds.Tables(0).Rows(0)("CarCapacity").ToString().Substring(0, 1))
            RangeValidator2.MaximumValue = (cap + 1).ToString()
            RangeValidator2.ErrorMessage = "Number of passenger is more than the car capacity"
        End If
    End Sub

    Protected Sub GCheckoutButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles GCheckoutButton1.Click
        If cbConfirm.Checked = False Then
            cbConfirm.Font.Bold = True
            cbConfirm.ForeColor = System.Drawing.Color.Red
        Else
            Dim Req As CheckoutShoppingCartRequest = GCheckoutButton1.CreateRequest()
            Req.AddItem(carmodel, "Booked for " & purpose & " on " & txtPickupDate.Text & "(" & dlHours.SelectedValue.ToString() & ":" & dlMinutes.SelectedValue.ToString() & " Hrs)", Convert.ToDecimal(carrent), 1)
            Dim Resp As GCheckoutResponse = Req.Send()
            Response.Redirect(Resp.RedirectUrl, True)
        End If
    End Sub
End Class