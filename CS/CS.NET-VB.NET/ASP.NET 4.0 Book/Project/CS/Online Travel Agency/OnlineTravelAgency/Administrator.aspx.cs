using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Administrator : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    
     DataTable dt = new DataTable();
     SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {    
        
        RangeValidator1.Type = ValidationDataType.Date;
        RangeValidator1.MinimumValue = DateTime.Now.ToShortDateString();
        RangeValidator1.MaximumValue = DateTime.Now.AddDays(20000).ToShortDateString();
        RangeValidator1.ErrorMessage = "Please select a valid date!";

        RangeValidator2.Type = ValidationDataType.Date;
        RangeValidator2.MinimumValue = DateTime.Now.ToShortDateString();
        RangeValidator2.MaximumValue = DateTime.Now.AddDays(20000).ToShortDateString();
        RangeValidator2.ErrorMessage = "Please select a valid date!";

        if (IsPostBack==false)
        {
            btnfeedback.Visible = false;
            Tablefeedback.Visible = true;
            bindfeeback();
        }
        if(!IsPostBack)
        {
           
            TableBusDetails.Visible = false;
            TableCarDetails.Visible = false;
            Traintable.Visible =false;
            bindtraindetails();      
            bindbusdetails();
            bindcardetails();
        }
    }
    public void bindtraindetails()
    {
        SqlDataAdapter datrain = new SqlDataAdapter("Select * from Traindetails", conn);
        dt.Clear();
        datrain.Fill(dt);
        gvTrainDetails.DataSource = dt;
        gvTrainDetails.DataBind();
    }
    public void bindbusdetails()
    {
        SqlDataAdapter dabus = new SqlDataAdapter("Select * from BusDetails", conn);
        dt.Clear();
        dabus.Fill(dt);
        gvBusDetails.DataSource = dt;
        gvBusDetails.DataBind();
    }
    public void bindcardetails()
    {
        SqlDataAdapter dacar = new SqlDataAdapter("Select * from CarDetails", conn);
        dt.Clear();
        dacar.Fill(dt);
        gvCarDetails.DataSource = dt;
        gvCarDetails.DataBind();
    }
    protected void gvTrainDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrainDetails.PageIndex = e.NewPageIndex;
        bindtraindetails();
    }
    protected void gvTrainDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTrainDetails.EditIndex = -1;
        bindtraindetails();
    }
    protected void gvTrainDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Tid;
          Tid = gvTrainDetails.Rows[e.RowIndex].Cells[1].Text;
        SqlDataAdapter dadelete = new SqlDataAdapter("Delete from TrainDetails where TrainID='" + Tid + "'", conn);
        dadelete.Fill(dt);
        dadelete.Update(dt);
        bindtraindetails();
    }
    protected void gvTrainDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTrainDetails.EditIndex = e.NewEditIndex;
        bindtraindetails();
    }
    protected void gvTrainDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string DepartStation, ArrivalStation, DepartureDate, SleeperClass, ACFirstClass, DepartureTime, Tid;
        int twoTier, threeTier, SleeperClassFare, ACFirstClassFare, twoTierFare, threeTierFare;
        Tid = gvTrainDetails.Rows[e.RowIndex].Cells[1].Text;

        DepartStation = ((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        ArrivalStation = ((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        DepartureDate = ((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        SleeperClass = ((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
        ACFirstClass = ((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
        twoTier = Convert.ToInt32(((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[7].Controls[0])).Text);
        threeTier = Convert.ToInt32(((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[8].Controls[0])).Text);
        SleeperClassFare = Convert.ToInt32(((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[9].Controls[0])).Text);
        ACFirstClassFare = Convert.ToInt32(((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[10].Controls[0])).Text);
        twoTierFare = Convert.ToInt32(((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[11].Controls[0])).Text);
        threeTierFare = Convert.ToInt32(((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[12].Controls[0])).Text);
        DepartureTime = ((TextBox)(gvTrainDetails.Rows[e.RowIndex].Cells[13].Controls[0])).Text;

        SqlDataAdapter da = new SqlDataAdapter("Update TrainDetails set DepartStation = ' " + DepartStation + "', ArrivalStation = '" + ArrivalStation + "', DepartureDate = '" + DepartureDate + "', SleeperClass ='" + SleeperClass + "', ACFirstClass = '" + ACFirstClass + "', [2Tier] = '" + twoTier + "', [3Tier] ='" + threeTier + "', SleeperClassFare = '" + SleeperClassFare + "', ACFirstClassFare = '" + ACFirstClassFare + "', [2TierFare] = '" + twoTierFare + "', [3TierFare] = '" + threeTierFare + "', DepartureTime = '" + DepartureTime + "' Where TrainID = '" + Tid + "' ", conn);
        dt.Clear();
        da.Fill(dt);
        da.Update(dt);
        gvTrainDetails.EditIndex = -1;
        bindtraindetails();

    }
    protected void gvTrainDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void btnAddTrain_Click(object sender, EventArgs e)
    { 
        SqlCommand insertcommand = new SqlCommand("INSERT INTO TrainDetails(DepartStation, ArrivalStation, DepartureDate, SleeperClass, ACFirstClass, [2Tier], [3Tier],SleeperClassFare, ACFirstClassFare, [2TierFare], [3TierFare], DepartureTime) VALUES (@DepartStation, @ArrivalStation, @DepartureDate, @SleeperClass, @ACFirstClass,@2Tier, @3Tier, @SleeperClassFare, @ACFirstClassFare, @2TierFare, @3TierFare, @DepartureTime)", conn);

        SqlParameter DepartStation = new SqlParameter("@DepartStation", SqlDbType.VarChar);
        SqlParameter ArrivalStation = new SqlParameter("@ArrivalStation", SqlDbType.VarChar);
        SqlParameter DepartureDate = new SqlParameter("@DepartureDate", SqlDbType.VarChar);
        SqlParameter SleeperClass = new SqlParameter("@SleeperClass", SqlDbType.Int);
        SqlParameter ACFirstClass = new SqlParameter("@ACFirstClass", SqlDbType.Int);
        SqlParameter Tier_2 = new SqlParameter("@2Tier", SqlDbType.Int);
        SqlParameter Tier_3 = new SqlParameter("@3Tier", SqlDbType.Int);
        SqlParameter SleeperClassFare = new SqlParameter("@SleeperClassFare", SqlDbType.Int);
        SqlParameter ACFirstClassFare = new SqlParameter("@ACFirstClassFare", SqlDbType.Int);
        SqlParameter TierFare_2 = new SqlParameter("@2TierFare", SqlDbType.Int);
        SqlParameter TierFare_3 = new SqlParameter("@3TierFare", SqlDbType.Int);
        SqlParameter DepartureTime = new SqlParameter("@DepartureTime", SqlDbType.VarChar);

        DepartStation.Value = txtDepartStation.Text.Trim();
        ArrivalStation.Value = txtArriveStation.Text.Trim();
        DepartureDate.Value = txtDepartDate.Text.Trim();
        SleeperClass.Value = Convert.ToInt32(txtSleeperClassSeats.Text.Trim());
        ACFirstClass.Value = Convert.ToInt32(txtACclassSeats.Text.Trim());
        Tier_2.Value = Convert.ToInt32(txt2TierSeats.Text.Trim());
        Tier_3.Value = Convert.ToInt32(txt3TierSeats.Text.Trim());
        SleeperClassFare.Value = Convert.ToInt32(txtSleeperFare.Text.Trim());
        ACFirstClassFare.Value = Convert.ToInt32(txtACFare.Text.Trim());
        TierFare_2.Value = Convert.ToInt32(txt2TierFare.Text.Trim());
        TierFare_3.Value = Convert.ToInt32(txt3TierFare.Text.Trim());
        DepartureTime.Value = txtDepartTime.Text.Trim();

        insertcommand.Parameters.Add(DepartStation);
        insertcommand.Parameters.Add(ArrivalStation);
        insertcommand.Parameters.Add(DepartureDate);
        insertcommand.Parameters.Add(SleeperClass);
        insertcommand.Parameters.Add(ACFirstClass);
        insertcommand.Parameters.Add(Tier_2);
        insertcommand.Parameters.Add(Tier_3);
        insertcommand.Parameters.Add(SleeperClassFare);
        insertcommand.Parameters.Add(ACFirstClassFare);
        insertcommand.Parameters.Add(TierFare_2);
        insertcommand.Parameters.Add(TierFare_3);
        insertcommand.Parameters.Add(DepartureTime);

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        insertcommand.ExecuteNonQuery();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }

        txtDepartStation.Text = null;
        txtArriveStation.Text = null;
        txtDepartDate.Text = null; ;
        txtSleeperClassSeats.Text = null;
        txtACclassSeats.Text = null;
        txt2TierSeats.Text = null;
        txt3TierSeats.Text = null;
        txtSleeperFare.Text = null;
        txtACFare.Text = null;
        txt2TierFare.Text = null;
        txt3TierFare.Text = null;
        txtDepartTime.Text = null;

        gvTrainDetails.DataBind();
        bindtraindetails();

    }
    protected void btnResetTrainDetails_Click(object sender, EventArgs e)
    {
        txtDepartStation.Text = null;
        txtArriveStation.Text = null;
        txtDepartDate.Text = null; ;
        txtSleeperClassSeats.Text = null;
        txtACclassSeats.Text = null;
        txt2TierSeats.Text = null;
        txt3TierSeats.Text = null;
        txtSleeperFare.Text = null;
        txtACFare.Text = null;
        txt2TierFare.Text = null;
        txt3TierFare.Text = null;
        txtDepartTime.Text = null;
    }    
    protected void BtnBusDetails_Click(object sender, EventArgs e)
    {
        Traintable.Visible = false;
        TableBusDetails.Visible = true;
        TableCarDetails.Visible = false;
        Tablefeedback.Visible = false;
        btnfeedback.Visible = true;
       bindbusdetails();     
    }
    protected void BtnTrainDetails_Click(object sender, EventArgs e)
    {
        Traintable.Visible = true;
        TableBusDetails.Visible = false;
        TableCarDetails.Visible = false;
        Tablefeedback.Visible = false;
        btnfeedback.Visible = true;
    }
    protected void btnAddBusDetails_Click(object sender, EventArgs e)
    {

        SqlCommand insertcommand = new SqlCommand("INSERT INTO BusDetails([From], [To], Date, SeatsAvailable, Fare) VALUES ('" + txtFrom.Text.Trim() + "', '" +txtTo.Text.Trim() + "', '" + txtDate.Text.Trim() + "', '" + txtSeatsAvailable.Text.Trim() + "', '" + txtFare.Text.Trim() + "')", conn);
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        insertcommand.ExecuteNonQuery();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        txtFrom.Text = null;
        txtTo.Text = null;
        txtDate.Text = null;
        txtSeatsAvailable.Text = null;
        txtFare.Text = null;

        bindbusdetails();
    }
    protected void btnResetBusDetails_Click(object sender, EventArgs e)
    {

        txtCarModel.Text = null;
        txtFullDayRent.Text = null;
        txtHalfDayRent.Text = null;
        txtExtraKM.Text = null;
        txtExtraHour.Text = null;
        txtCapacity.Text = null;
        txtCity.Text = null;
    }
    protected void gvBusDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlCommand insertcommand = new SqlCommand("INSERT INTO [CarDetails] ([CarModel], [FullDayRent], [HalfDayRent], [Price_ExtraKM], [Price_ExtraHour],[CarCapacity],[City]) VALUES (@CarModel, @FullDayRent, @HalfDayRent, @Price_ExtraKM, @Price_ExtraHour, @CarCapacity,@City)", conn);        
        SqlParameter carmodel = new SqlParameter("@CarModel", SqlDbType.VarChar);
        SqlParameter FullDayRent = new SqlParameter("@FullDayRent", SqlDbType.VarChar);
        SqlParameter HalfDayRent = new SqlParameter("@HalfDayRent", SqlDbType.VarChar);
        SqlParameter Price_ExtraKM = new SqlParameter("@Price_ExtraKM", SqlDbType.VarChar);
        SqlParameter Price_ExtraHour = new SqlParameter("@Price_ExtraHour", SqlDbType.VarChar);
        SqlParameter CarCapacity = new SqlParameter("@CarCapacity", SqlDbType.VarChar);        
        SqlParameter City = new SqlParameter("@City", SqlDbType.VarChar);

        carmodel.Value = txtCarModel.Text.Trim();
        FullDayRent.Value = txtFullDayRent.Text.Trim();
        HalfDayRent.Value = txtHalfDayRent.Text.Trim();
        Price_ExtraKM.Value = txtExtraKM.Text.Trim();
        Price_ExtraHour.Value = txtExtraHour.Text.Trim();
        CarCapacity.Value = txtCapacity.Text.Trim();        
        City.Value = txtCity.Text.Trim();

        insertcommand.Parameters.Add(carmodel);
        insertcommand.Parameters.Add(FullDayRent);
        insertcommand.Parameters.Add(HalfDayRent);
        insertcommand.Parameters.Add(Price_ExtraKM);
        insertcommand.Parameters.Add(Price_ExtraHour);
        insertcommand.Parameters.Add(CarCapacity);       
        insertcommand.Parameters.Add(City);

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        insertcommand.ExecuteNonQuery();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        txtCarModel.Text = null;
        txtFullDayRent.Text = null;
        txtHalfDayRent.Text = null;
        txtExtraKM.Text = null;
        txtExtraHour.Text = null;
        txtCapacity.Text = null;
        txtCity.Text = null;
    }   
    protected void Btncardetails_Click(object sender, EventArgs e)
    {
        Traintable.Visible = false;
        TableBusDetails.Visible = false;
        TableCarDetails.Visible = true;
        Tablefeedback.Visible = false;
        btnfeedback.Visible = true;
        bindcardetails();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtCarModel.Text = null;
        txtFullDayRent.Text = null;
        txtHalfDayRent.Text = null;
        txtExtraKM.Text = null;
        txtExtraHour.Text = null;
        txtCapacity.Text = null;
        txtCity.Text = null;
    }
    protected void gvBusDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusDetails.PageIndex = e.NewPageIndex;
        bindbusdetails();
    }
    protected void gvBusDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBusDetails.EditIndex = -1;
        bindbusdetails(); 
    }
    protected void gvBusDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Bid;
        Bid =gvTrainDetails.Rows[e.RowIndex].Cells[1].Text;
        SqlDataAdapter dadelete = new SqlDataAdapter("Delete from BusDetails where BusId='" + Bid + "'", conn);
        dadelete.Fill(dt);
        dadelete.Update(dt);
        bindbusdetails();
    }
    protected void gvBusDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBusDetails.EditIndex = e.NewEditIndex;
        bindbusdetails();
    }
    protected void gvBusDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {        
       
        string BFrom,To,Date,Bid;
        int  SeatsAvailable,Fare;
        Bid = gvBusDetails.Rows[e.RowIndex].Cells[1].Text;

        BFrom = ((TextBox)(gvBusDetails.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        To = ((TextBox)(gvBusDetails.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        Date = ((TextBox)(gvBusDetails.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        SeatsAvailable = Convert.ToInt32(((TextBox)(gvBusDetails.Rows[e.RowIndex].Cells[5].Controls[0])).Text);
        Fare = Convert.ToInt32(((TextBox)(gvBusDetails.Rows[e.RowIndex].Cells[6].Controls[0])).Text);

        SqlDataAdapter da = new SqlDataAdapter("Update BusDetails set BFrom = ' " + BFrom + "', BTo = '" + To + "', BDate = '" + Date + "', SeatsAvailable ='" + SeatsAvailable + "', Fare = '" + Fare + "' Where BusId = '" + Bid + "' ", conn);
        dt.Clear();
        da.Fill(dt);
        da.Update(dt);
        gvBusDetails.EditIndex = -1;
        bindbusdetails();
    }

    protected void gvCarDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCarDetails.PageIndex = e.NewPageIndex;
        bindcardetails();
    }
    protected void gvCarDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCarDetails.EditIndex = -1;
        bindcardetails(); 
    }
    protected void gvCarDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Cid;
        Cid = gvCarDetails.Rows[e.RowIndex].Cells[1].Text;
        SqlDataAdapter dadelete = new SqlDataAdapter("Delete from CarDetails where CarId='" + Cid + "'", conn);
        dadelete.Fill(dt);
        dadelete.Update(dt);
        bindcardetails();
    }
    protected void gvCarDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //CarId
        //CarModel
        //FullDayRent
        //HalfDayRent
        //Price_ExtraKM
        //Price_ExtraHour
        //CarCapacity
        //City 

        string CarModel, CarCapacity, City,Cid;
        int FullDayRent, HalfDayRent, Price_ExtraKM, Price_ExtraHour;

        Cid = gvCarDetails.Rows[e.RowIndex].Cells[1].Text;

        CarModel = ((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        FullDayRent = Convert.ToInt32( ((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[3].Controls[0])).Text);
        HalfDayRent = Convert.ToInt32(((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[4].Controls[0])).Text);
        Price_ExtraKM = Convert.ToInt32(((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[5].Controls[0])).Text);
        Price_ExtraHour = Convert.ToInt32(((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[6].Controls[0])).Text);
        CarCapacity = ((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[7].Controls[0])).Text;
        City = ((TextBox)(gvCarDetails.Rows[e.RowIndex].Cells[8].Controls[0])).Text;

        SqlDataAdapter da = new SqlDataAdapter("Update CarDetails set CarModel = ' " + CarModel + "', FullDayRent = '" + FullDayRent + "', HalfDayRent = '" + HalfDayRent + "', Price_ExtraKM ='" + Price_ExtraKM + "', Price_ExtraHour = '" + Price_ExtraHour + "' , CarCapacity='" + CarCapacity + "',City='" + City + "' Where CarId = '" + Cid + "' ", conn);
        dt.Clear();
        da.Fill(dt);
        da.Update(dt);
        gvCarDetails.EditIndex = -1;
        bindcardetails();
    }
    protected void gvCarDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCarDetails.EditIndex = e.NewEditIndex;
        bindcardetails(); 
    }
    public void bindfeeback()
    {
        SqlDataAdapter dafeedback = new SqlDataAdapter("Select * from Feedback", conn);
        dafeedback.Fill(dt);
        gvfeedback.DataSource = dt;
        gvfeedback.DataBind(); 
       
    }
    protected void gvfeedback_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Eid;
        Eid = gvfeedback.Rows[e.RowIndex].Cells[2].Text;
        SqlDataAdapter dadelete = new SqlDataAdapter("Delete from Feedback where Email='" + Eid + "'", conn);
        dadelete.Fill(dt);
        dadelete.Update(dt);
        bindfeeback();
    }

    protected void btnfeedback_Click(object sender, EventArgs e)
    {
        bindfeeback();
        Tablefeedback.Visible = true;
        TableCarDetails.Visible = false;
        TableBusDetails.Visible = false;
        Traintable.Visible = false;
    }
}