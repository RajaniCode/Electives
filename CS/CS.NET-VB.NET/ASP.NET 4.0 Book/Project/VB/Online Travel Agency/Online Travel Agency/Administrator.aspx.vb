Imports System.Data
Imports System.Data.SqlClient
Public Class Administrator
    Inherits System.Web.UI.Page
    Dim ds As New DataSet()
    Dim con As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString.ToString()
    Dim conn As New SqlConnection(con)
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RangeValidator1.Type = ValidationDataType.Date
        RangeValidator1.MinimumValue = DateTime.Now.ToShortDateString()
        RangeValidator1.MaximumValue = DateTime.Now.AddDays(20000).ToShortDateString()
        RangeValidator1.ErrorMessage = "Please select a valid date!"

        RangeValidator2.Type = ValidationDataType.Date
        RangeValidator2.MinimumValue = DateTime.Now.ToShortDateString()
        RangeValidator2.MaximumValue = DateTime.Now.AddDays(20000).ToShortDateString()
        RangeValidator2.ErrorMessage = "Please select a valid date!"

        If IsPostBack = False Then
            Tablefeedback.Visible = True
            btnfeedback.Visible = False
            bindfeeback()
        End If

        If Not IsPostBack Then
            TableBusDetails.Visible = False
            TableCarDetails.Visible = False
            Traintable.Visible = False
            bindtraindetails()
            bindbusdetails()
            bindcardetails()
        End If

    End Sub
    Public Sub bindtraindetails()
        Dim datrain = New SqlDataAdapter("Select * from Traindetails", conn)
        dt.Clear()
        datrain.Fill(dt)
        gvTrainDetails.DataSource = dt
        gvTrainDetails.DataBind()
    End Sub
    Public Sub bindbusdetails()
        Dim dabus = New SqlDataAdapter("Select * from BusDetails", conn)
        dt.Clear()
        dabus.Fill(dt)
        gvBusDetails.DataSource = dt
        gvBusDetails.DataBind()
    End Sub
    Public Sub bindcardetails()
        Dim dacar As New SqlDataAdapter("Select * from CarDetails", conn)
        dt.Clear()
        dacar.Fill(dt)
        gvCarDetails.DataSource = dt
        gvCarDetails.DataBind()
    End Sub
    Protected Sub gvTrainDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvTrainDetails.PageIndex = e.NewPageIndex
        bindtraindetails()
    End Sub
    Protected Sub gvTrainDetails_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvTrainDetails.EditIndex = -1
        bindtraindetails()
    End Sub
    Protected Sub gvTrainDetails_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim Tid As String
        Tid = gvTrainDetails.Rows(e.RowIndex).Cells(1).Text
        Dim dadelete As SqlDataAdapter = New SqlDataAdapter("Delete from TrainDetails where TrainID='" & Tid & "'", conn)
        dadelete.Fill(dt)
        dadelete.Update(dt)
        bindtraindetails()
    End Sub
    Protected Sub gvTrainDetails_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvTrainDetails.EditIndex = e.NewEditIndex
        bindtraindetails()
    End Sub
    Protected Sub gvTrainDetails_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim DepartStation, ArrivalStation, DepartureDate, SleeperClass, ACFirstClass, DepartureTime, Tid As String
        Dim twoTier, threeTier, SleeperClassFare, ACFirstClassFare, twoTierFare, threeTierFare As Integer
        Tid = gvTrainDetails.Rows(e.RowIndex).Cells(1).Text

        DepartStation = (CType(gvTrainDetails.Rows(e.RowIndex).Cells(2).Controls(0), TextBox)).Text
        ArrivalStation = (CType(gvTrainDetails.Rows(e.RowIndex).Cells(3).Controls(0), TextBox)).Text
        DepartureDate = (CType(gvTrainDetails.Rows(e.RowIndex).Cells(4).Controls(0), TextBox)).Text
        SleeperClass = (CType(gvTrainDetails.Rows(e.RowIndex).Cells(5).Controls(0), TextBox)).Text
        ACFirstClass = (CType(gvTrainDetails.Rows(e.RowIndex).Cells(6).Controls(0), TextBox)).Text
        twoTier = Convert.ToInt32((CType(gvTrainDetails.Rows(e.RowIndex).Cells(7).Controls(0), TextBox)).Text)
        threeTier = Convert.ToInt32((CType(gvTrainDetails.Rows(e.RowIndex).Cells(8).Controls(0), TextBox)).Text)
        SleeperClassFare = Convert.ToInt32((CType(gvTrainDetails.Rows(e.RowIndex).Cells(9).Controls(0), TextBox)).Text)
        ACFirstClassFare = Convert.ToInt32((CType(gvTrainDetails.Rows(e.RowIndex).Cells(10).Controls(0), TextBox)).Text)
        twoTierFare = Convert.ToInt32((CType(gvTrainDetails.Rows(e.RowIndex).Cells(11).Controls(0), TextBox)).Text)
        threeTierFare = Convert.ToInt32((CType(gvTrainDetails.Rows(e.RowIndex).Cells(12).Controls(0), TextBox)).Text)
        DepartureTime = (CType(gvTrainDetails.Rows(e.RowIndex).Cells(13).Controls(0), TextBox)).Text

        Dim da As SqlDataAdapter = New SqlDataAdapter("Update TrainDetails set DepartStation = ' " & DepartStation & "', ArrivalStation = '" & ArrivalStation & "', DepartureDate = '" & DepartureDate & "', SleeperClass ='" & SleeperClass & "', ACFirstClass = '" & ACFirstClass & "', [2Tier] = '" & twoTier & "', [3Tier] ='" & threeTier & "', SleeperClassFare = '" & SleeperClassFare & "', ACFirstClassFare = '" & ACFirstClassFare & "', [2TierFare] = '" & twoTierFare & "', [3TierFare] = '" & threeTierFare & "', DepartureTime = '" & DepartureTime & "' Where TrainID = '" & Tid & "' ", conn)
        dt.Clear()
        da.Fill(dt)
        da.Update(dt)
        gvTrainDetails.EditIndex = -1
        bindtraindetails()
    End Sub
    Protected Sub gvTrainDetails_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

    End Sub
    Protected Sub btnAddTrain_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim insertcommand As SqlCommand = New SqlCommand("INSERT INTO TrainDetails(DepartStation, ArrivalStation, DepartureDate, SleeperClass, ACFirstClass, [2Tier], [3Tier],SleeperClassFare, ACFirstClassFare, [2TierFare], [3TierFare], DepartureTime) VALUES (@DepartStation, @ArrivalStation, @DepartureDate, @SleeperClass, @ACFirstClass,@2Tier, @3Tier, @SleeperClassFare, @ACFirstClassFare, @2TierFare, @3TierFare, @DepartureTime)", conn)

        Dim DepartStation As SqlParameter = New SqlParameter("@DepartStation", SqlDbType.VarChar)
        Dim ArrivalStation As SqlParameter = New SqlParameter("@ArrivalStation", SqlDbType.VarChar)
        Dim DepartureDate As SqlParameter = New SqlParameter("@DepartureDate", SqlDbType.VarChar)
        Dim SleeperClass As SqlParameter = New SqlParameter("@SleeperClass", SqlDbType.Int)
        Dim ACFirstClass As SqlParameter = New SqlParameter("@ACFirstClass", SqlDbType.Int)
        Dim Tier_2 As SqlParameter = New SqlParameter("@2Tier", SqlDbType.Int)
        Dim Tier_3 As SqlParameter = New SqlParameter("@3Tier", SqlDbType.Int)
        Dim SleeperClassFare As SqlParameter = New SqlParameter("@SleeperClassFare", SqlDbType.Int)
        Dim ACFirstClassFare As SqlParameter = New SqlParameter("@ACFirstClassFare", SqlDbType.Int)
        Dim TierFare_2 As SqlParameter = New SqlParameter("@2TierFare", SqlDbType.Int)
        Dim TierFare_3 As SqlParameter = New SqlParameter("@3TierFare", SqlDbType.Int)
        Dim DepartureTime As SqlParameter = New SqlParameter("@DepartureTime", SqlDbType.VarChar)

        DepartStation.Value = txtDepartStation.Text.Trim()
        ArrivalStation.Value = txtArriveStation.Text.Trim()
        DepartureDate.Value = txtDepartDate.Text.Trim()
        SleeperClass.Value = Convert.ToInt32(txtSleeperClassSeats.Text.Trim())
        ACFirstClass.Value = Convert.ToInt32(txtACclassSeats.Text.Trim())
        Tier_2.Value = Convert.ToInt32(txt2TierSeats.Text.Trim())
        Tier_3.Value = Convert.ToInt32(txt3TierSeats.Text.Trim())
        SleeperClassFare.Value = Convert.ToInt32(txtSleeperFare.Text.Trim())
        ACFirstClassFare.Value = Convert.ToInt32(txtACFare.Text.Trim())
        TierFare_2.Value = Convert.ToInt32(txt2TierFare.Text.Trim())
        TierFare_3.Value = Convert.ToInt32(txt3TierFare.Text.Trim())
        DepartureTime.Value = txtDepartTime.Text.Trim()

        insertcommand.Parameters.Add(DepartStation)
        insertcommand.Parameters.Add(ArrivalStation)
        insertcommand.Parameters.Add(DepartureDate)
        insertcommand.Parameters.Add(SleeperClass)
        insertcommand.Parameters.Add(ACFirstClass)
        insertcommand.Parameters.Add(Tier_2)
        insertcommand.Parameters.Add(Tier_3)
        insertcommand.Parameters.Add(SleeperClassFare)
        insertcommand.Parameters.Add(ACFirstClassFare)
        insertcommand.Parameters.Add(TierFare_2)
        insertcommand.Parameters.Add(TierFare_3)
        insertcommand.Parameters.Add(DepartureTime)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        insertcommand.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        txtDepartStation.Text = Nothing
        txtArriveStation.Text = Nothing
        txtDepartDate.Text = Nothing

        txtSleeperClassSeats.Text = Nothing
        txtACclassSeats.Text = Nothing
        txt2TierSeats.Text = Nothing
        txt3TierSeats.Text = Nothing
        txtSleeperFare.Text = Nothing
        txtACFare.Text = Nothing
        txt2TierFare.Text = Nothing
        txt3TierFare.Text = Nothing
        txtDepartTime.Text = Nothing

        gvTrainDetails.DataBind()
        bindtraindetails()
    End Sub
    Protected Sub btnResetTrainDetails_Click(ByVal sender As Object, ByVal e As EventArgs)
        txtDepartStation.Text = Nothing
        txtArriveStation.Text = Nothing
        txtDepartDate.Text = Nothing

        txtSleeperClassSeats.Text = Nothing
        txtACclassSeats.Text = Nothing
        txt2TierSeats.Text = Nothing
        txt3TierSeats.Text = Nothing
        txtSleeperFare.Text = Nothing
        txtACFare.Text = Nothing
        txt2TierFare.Text = Nothing
        txt3TierFare.Text = Nothing
        txtDepartTime.Text = Nothing
    End Sub
    Protected Sub BtnBusDetails_Click(ByVal sender As Object, ByVal e As EventArgs)
        Traintable.Visible = False
        TableBusDetails.Visible = True
        TableCarDetails.Visible = False
        Tablefeedback.Visible = False
        btnfeedback.Visible = True
        bindbusdetails()
    End Sub
    Protected Sub BtnTrainDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnTrainDetails.Click
        Traintable.Visible = True
        TableBusDetails.Visible = False
        TableCarDetails.Visible = False
        Tablefeedback.Visible = False
        btnfeedback.Visible = True
        bindtraindetails()
    End Sub
    Protected Sub btnAddBusDetails_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim insertcommand As SqlCommand = New SqlCommand("INSERT INTO BusDetails([From], [To], Date, SeatsAvailable, Fare) VALUES ('" & txtFrom.Text.Trim() & "', '" & txtTo.Text.Trim() & "', '" & txtDate.Text.Trim() & "', '" & txtSeatsAvailable.Text.Trim() & "', '" & txtFare.Text.Trim() & "')", conn)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        insertcommand.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        txtFrom.Text = Nothing
        txtTo.Text = Nothing
        txtDate.Text = Nothing
        txtSeatsAvailable.Text = Nothing
        txtFare.Text = Nothing

        bindbusdetails()
    End Sub
    Protected Sub btnResetBusDetails_Click(ByVal sender As Object, ByVal e As EventArgs)

        txtCarModel.Text = Nothing
        txtFullDayRent.Text = Nothing
        txtHalfDayRent.Text = Nothing
        txtExtraKM.Text = Nothing
        txtExtraHour.Text = Nothing
        txtCapacity.Text = Nothing
        txtCity.Text = Nothing
    End Sub
    Protected Sub gvBusDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim insertcommand As SqlCommand = New SqlCommand("INSERT INTO [CarDetails] ([CarModel], [FullDayRent], [HalfDayRent], [Price_ExtraKM], [Price_ExtraHour],[CarCapacity],[City]) VALUES (@CarModel, @FullDayRent, @HalfDayRent, @Price_ExtraKM, @Price_ExtraHour, @CarCapacity,@City)", conn)
        Dim carmodel As SqlParameter = New SqlParameter("@CarModel", SqlDbType.VarChar)
        Dim FullDayRent As SqlParameter = New SqlParameter("@FullDayRent", SqlDbType.VarChar)
        Dim HalfDayRent As SqlParameter = New SqlParameter("@HalfDayRent", SqlDbType.VarChar)
        Dim Price_ExtraKM As SqlParameter = New SqlParameter("@Price_ExtraKM", SqlDbType.VarChar)
        Dim Price_ExtraHour As SqlParameter = New SqlParameter("@Price_ExtraHour", SqlDbType.VarChar)
        Dim CarCapacity As SqlParameter = New SqlParameter("@CarCapacity", SqlDbType.VarChar)
        Dim City As SqlParameter = New SqlParameter("@City", SqlDbType.VarChar)

        carmodel.Value = txtCarModel.Text.Trim()
        FullDayRent.Value = txtFullDayRent.Text.Trim()
        HalfDayRent.Value = txtHalfDayRent.Text.Trim()
        Price_ExtraKM.Value = txtExtraKM.Text.Trim()
        Price_ExtraHour.Value = txtExtraHour.Text.Trim()
        CarCapacity.Value = txtCapacity.Text.Trim()
        City.Value = txtCity.Text.Trim()

        insertcommand.Parameters.Add(carmodel)
        insertcommand.Parameters.Add(FullDayRent)
        insertcommand.Parameters.Add(HalfDayRent)
        insertcommand.Parameters.Add(Price_ExtraKM)
        insertcommand.Parameters.Add(Price_ExtraHour)
        insertcommand.Parameters.Add(CarCapacity)
        insertcommand.Parameters.Add(City)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        insertcommand.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        txtCarModel.Text = Nothing
        txtFullDayRent.Text = Nothing
        txtHalfDayRent.Text = Nothing
        txtExtraKM.Text = Nothing
        txtExtraHour.Text = Nothing
        txtCapacity.Text = Nothing
        txtCity.Text = Nothing
    End Sub
    Protected Sub Btncardetails_Click(ByVal sender As Object, ByVal e As EventArgs)
        Traintable.Visible = False
        TableBusDetails.Visible = False
        TableCarDetails.Visible = True
        Tablefeedback.Visible = False
        btnfeedback.Visible = True
        bindcardetails()
    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs)
        txtCarModel.Text = Nothing
        txtFullDayRent.Text = Nothing
        txtHalfDayRent.Text = Nothing
        txtExtraKM.Text = Nothing
        txtExtraHour.Text = Nothing
        txtCapacity.Text = Nothing
        txtCity.Text = Nothing
    End Sub
    Protected Sub gvBusDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvBusDetails.PageIndex = e.NewPageIndex
        bindbusdetails()
    End Sub
    Protected Sub gvBusDetails_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvBusDetails.EditIndex = -1
        bindbusdetails()
    End Sub
    Protected Sub gvBusDetails_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim Bid As String
        Bid = gvTrainDetails.Rows(e.RowIndex).Cells(1).Text
        Dim dadelete As SqlDataAdapter = New SqlDataAdapter("Delete from BusDetails where BusId='" & Bid & "'", conn)
        dadelete.Fill(dt)
        dadelete.Update(dt)
        bindbusdetails()
    End Sub
    Protected Sub gvBusDetails_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvBusDetails.EditIndex = e.NewEditIndex
        bindbusdetails()
    End Sub
    Protected Sub gvBusDetails_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Dim BFrom, [To], [Date], Bid As String
        Dim SeatsAvailable, Fare As Integer
        Bid = gvBusDetails.Rows(e.RowIndex).Cells(1).Text

        BFrom = (CType(gvBusDetails.Rows(e.RowIndex).Cells(2).Controls(0), TextBox)).Text
        [To] = (CType(gvBusDetails.Rows(e.RowIndex).Cells(3).Controls(0), TextBox)).Text
        [Date] = (CType(gvBusDetails.Rows(e.RowIndex).Cells(4).Controls(0), TextBox)).Text
        SeatsAvailable = Convert.ToInt32((CType(gvBusDetails.Rows(e.RowIndex).Cells(5).Controls(0), TextBox)).Text)
        Fare = Convert.ToInt32((CType(gvBusDetails.Rows(e.RowIndex).Cells(6).Controls(0), TextBox)).Text)

        Dim da As SqlDataAdapter = New SqlDataAdapter("Update BusDetails set BFrom = ' " & BFrom & "', BTo = '" & [To] & "', BDate = '" & [Date] & "', SeatsAvailable ='" & SeatsAvailable & "', Fare = '" & Fare & "' Where BusId = '" & Bid & "' ", conn)
        dt.Clear()
        da.Fill(dt)
        da.Update(dt)
        gvBusDetails.EditIndex = -1
        bindbusdetails()
    End Sub

    Protected Sub gvCarDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvCarDetails.PageIndex = e.NewPageIndex
        bindcardetails()
    End Sub
    Protected Sub gvCarDetails_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvCarDetails.EditIndex = -1
        bindcardetails()
    End Sub
    Protected Sub gvCarDetails_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim Cid As String
        Cid = gvCarDetails.Rows(e.RowIndex).Cells(1).Text
        Dim dadelete As SqlDataAdapter = New SqlDataAdapter("Delete from CarDetails where CarId='" & Cid & "'", conn)
        dadelete.Fill(dt)
        dadelete.Update(dt)
        bindcardetails()
    End Sub
    Protected Sub gvCarDetails_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim CarModel, CarCapacity, City, Cid As String
        Dim FullDayRent, HalfDayRent, Price_ExtraKM, Price_ExtraHour As Integer

        Cid = gvCarDetails.Rows(e.RowIndex).Cells(1).Text

        CarModel = (CType(gvCarDetails.Rows(e.RowIndex).Cells(2).Controls(0), TextBox)).Text
        FullDayRent = Convert.ToInt32((CType(gvCarDetails.Rows(e.RowIndex).Cells(3).Controls(0), TextBox)).Text)
        HalfDayRent = Convert.ToInt32((CType(gvCarDetails.Rows(e.RowIndex).Cells(4).Controls(0), TextBox)).Text)
        Price_ExtraKM = Convert.ToInt32((CType(gvCarDetails.Rows(e.RowIndex).Cells(5).Controls(0), TextBox)).Text)
        Price_ExtraHour = Convert.ToInt32((CType(gvCarDetails.Rows(e.RowIndex).Cells(6).Controls(0), TextBox)).Text)
        CarCapacity = (CType(gvCarDetails.Rows(e.RowIndex).Cells(7).Controls(0), TextBox)).Text
        City = (CType(gvCarDetails.Rows(e.RowIndex).Cells(8).Controls(0), TextBox)).Text

        Dim da As SqlDataAdapter = New SqlDataAdapter("Update CarDetails set CarModel = ' " & CarModel & "', FullDayRent = '" & FullDayRent & "', HalfDayRent = '" & HalfDayRent & "', Price_ExtraKM ='" & Price_ExtraKM & "', Price_ExtraHour = '" & Price_ExtraHour & "' , CarCapacity='" & CarCapacity & "',City='" & City & "' Where CarId = '" & Cid & "' ", conn)
        dt.Clear()
        da.Fill(dt)
        da.Update(dt)
        gvCarDetails.EditIndex = -1
        bindcardetails()
	
    End Sub
    Protected Sub gvCarDetails_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvCarDetails.EditIndex = e.NewEditIndex
        bindcardetails()
    End Sub
    Protected Sub gvfeedback_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim Eid As String
        Eid = gvfeedback.Rows(e.RowIndex).Cells(2).Text
        Dim dadelete As SqlDataAdapter = New SqlDataAdapter("Delete from Feedback where Email='" & Eid & "'", conn)
        dadelete.Fill(dt)
        dadelete.Update(dt)
        bindfeeback()
    End Sub
    Public Sub bindfeeback()
        Dim dafeedback As SqlDataAdapter = New SqlDataAdapter("Select * from Feedback", conn)
        dafeedback.Fill(dt)
        gvfeedback.DataSource = dt
        gvfeedback.DataBind()

    End Sub
  
    Protected Sub btnfeedback_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnfeedback.Click
        bindfeeback()
        Tablefeedback.Visible = True
        TableCarDetails.Visible = False
        TableBusDetails.Visible = False
        Traintable.Visible = False
    End Sub

End Class
