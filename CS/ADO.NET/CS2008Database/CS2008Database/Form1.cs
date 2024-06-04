using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

// Add Reference: 
// System.configuration
// Microsoft.SqlServer.ConnectionInfo
// Microsoft.SqlServer.Management.Sdk.Sfc 
// Microsoft.SqlServer.Smo

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace CS2008Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string Event;

        int ForwardCount;
        int BackwardCount;
        int ID;

        private string ConnectionString
        {
            get
            {
                try
                {
                    ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
                    return ConnectionStringSetting["ConnectionString"].ConnectionString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return string.Empty;
                }
            }
        }

        private void CreateDatabase()
        {
            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {

                    StringBuilder SqlQuery = new StringBuilder();

                    //SqlQuery.Append("IF DB_ID(N'ExampleDatabase') IS NOT NULL ");
                    //SqlQuery.Append("DROP DATABASE [ExampleDatabase]; ");

                    SqlQuery.Append("IF EXISTS (SELECT NAME FROM SYS.DATABASES ");
                    SqlQuery.Append("WHERE NAME = N'ExampleDatabase') ");
                    SqlQuery.Append("DROP DATABASE [ExampleDatabase]; ");

                    SqlQuery.Append("CREATE DATABASE [ExampleDatabase]; ");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    CommandSql.Connection.Open();
                    CommandSql.ExecuteNonQuery();
                    CommandSql.Connection.Close();

                    MessageBox.Show("Database Created.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateTable()
        {
            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");

                    SqlQuery.Append("IF OBJECT_ID (N'ExampleTable', N'U') IS NOT NULL ");
                    SqlQuery.Append("DROP TABLE dbo.ExampleTable; ");

                    //SqlQuery.Append("IF EXISTS (SELECT NAME FROM SYS.TABLES ");
                    //SqlQuery.Append("WHERE NAME = N'ExampleTable') ");
                    //SqlQuery.Append("DROP TABLE dbo.ExampleTable; ");

                    SqlQuery.Append("CREATE TABLE dbo.ExampleTable");
                    SqlQuery.Append("(");
                    SqlQuery.Append("ID INT IDENTITY(1,1) NOT NULL, ");
                    SqlQuery.Append("UserID INT NULL, ");
                    SqlQuery.Append("Name NVARCHAR(50) NULL, ");
                    SqlQuery.Append("DateOfBirth DATETIME, ");
                    SqlQuery.Append("IsActive BIT, ");
                    SqlQuery.Append("Phone NVARCHAR(50) NULL, ");
                    SqlQuery.Append("Fax NVARCHAR(50) NULL ");
                    SqlQuery.Append("CONSTRAINT PK_ID PRIMARY KEY(ID), ");
                    SqlQuery.Append("CONSTRAINT UNIQUE_Phone UNIQUE(Phone), ");
                    SqlQuery.Append("CONSTRAINT FK_UserID FOREIGN KEY(UserID) REFERENCES ExampleTable(ID), ");
                    SqlQuery.Append("CONSTRAINT FK_Fax FOREIGN KEY(Fax) REFERENCES ExampleTable(Phone)");
                    SqlQuery.Append("); ");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    CommandSql.Connection.Open();
                    CommandSql.ExecuteNonQuery();
                    CommandSql.Connection.Close();

                    MessageBox.Show("Table Created.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateProcedureCheckForeignKeyUserID()
        {
            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    Server server = new Server(new ServerConnection(ConnectionSql));

                    Database Datbase = server.Databases["ExampleDatabase"];

                    StoredProcedure Procedure = new StoredProcedure(Datbase, "CheckForeignKeyUserID");

                    Procedure.TextMode = false;
                    Procedure.AnsiNullsStatus = false;
                    Procedure.QuotedIdentifierStatus = false;

                    StoredProcedureParameter Parameter = new StoredProcedureParameter(Procedure, "@UserID", DataType.Int);
                    Procedure.Parameters.Add(Parameter);

                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("DECLARE @ResultUserID INT ");
                    SqlQuery.Append("IF EXISTS ");
                    SqlQuery.Append("(");
                    SqlQuery.Append("SELECT NULL FROM dbo.ExampleTable WITH (UPDLOCK) ");
                    SqlQuery.Append("WHERE ");
                    //SqlQuery.Append("ISNULL(ID, 'NULL') = ISNULL(@UserID, 'NULL') ");
                    SqlQuery.Append("(ID IS NULL AND @UserID is NULL) OR (@UserID = ID) ");
                    SqlQuery.Append(") ");
                    SqlQuery.Append("BEGIN SELECT @ResultUserID = 0 END ");
                    SqlQuery.Append("ELSE ");
                    SqlQuery.Append("BEGIN SELECT @ResultUserID = -1 END ");
                    SqlQuery.Append("RETURN @ResultUserID; ");

                    Procedure.TextBody = SqlQuery.ToString();

                    Procedure.Create();

                    MessageBox.Show("Procedure CheckForeignKeyUserID Created.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateProcedureCheckForeignKeyPhone()
        {
            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    Server server = new Server(new ServerConnection(ConnectionSql));

                    Database Datbase = server.Databases["ExampleDatabase"];

                    StoredProcedure Procedure = new StoredProcedure(Datbase, "CheckForeignKeyPhone");

                    Procedure.TextMode = false;
                    Procedure.AnsiNullsStatus = false;
                    Procedure.QuotedIdentifierStatus = false;

                    StoredProcedureParameter Parameter = new StoredProcedureParameter(Procedure, "@Phone", DataType.NVarCharMax);
                    Procedure.Parameters.Add(Parameter);

                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("DECLARE @ResultPhone INT ");
                    SqlQuery.Append("IF EXISTS ");
                    SqlQuery.Append("( ");
                    SqlQuery.Append("SELECT NULL FROM dbo.ExampleTable WITH (UPDLOCK) ");
                    SqlQuery.Append("WHERE ");
                    //SqlQuery.Append("ISNULL(Phone, 'NULL') = ISNULL(@Phone, 'NULL') ");
                    SqlQuery.Append("(Phone IS NULL AND @Phone IS NULL) OR (@Phone = Phone) ");
                    SqlQuery.Append(") ");
                    SqlQuery.Append("BEGIN SELECT @ResultPhone = 0 END ");
                    SqlQuery.Append("ELSE ");
                    SqlQuery.Append("BEGIN SELECT @ResultPhone = -1 END ");
                    SqlQuery.Append("RETURN @ResultPhone; ");

                    Procedure.TextBody = SqlQuery.ToString();

                    Procedure.Create();

                    MessageBox.Show("Procedure CheckForeignKeyPhone Created.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateProcedureCheckForeignKeyFax()
        {
            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    Server server = new Server(new ServerConnection(ConnectionSql));

                    Database Datbase = server.Databases["ExampleDatabase"];

                    StoredProcedure Procedure = new StoredProcedure(Datbase, "CheckForeignKeyFax");

                    Procedure.TextMode = false;
                    Procedure.AnsiNullsStatus = false;
                    Procedure.QuotedIdentifierStatus = false;

                    StoredProcedureParameter Parameter = new StoredProcedureParameter(Procedure, "@Fax", DataType.NVarCharMax);
                    Procedure.Parameters.Add(Parameter);

                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("DECLARE @ResultFax INT ");
                    SqlQuery.Append("IF EXISTS ");
                    SqlQuery.Append("( ");
                    SqlQuery.Append("SELECT NULL FROM dbo.ExampleTable WITH (UPDLOCK) ");
                    SqlQuery.Append("WHERE ");
                    //SqlQuery.Append("ISNULL(Phone, 'NULL') = ISNULL(@Fax, 'NULL') ");
                    SqlQuery.Append("(Phone IS NULL AND @Fax IS NULL) OR (@Fax = Phone) ");
                    SqlQuery.Append(") ");
                    SqlQuery.Append("BEGIN SELECT @ResultFax = 0 END ");
                    SqlQuery.Append("ELSE BEGIN SELECT @ResultFax = -1 END ");
                    SqlQuery.Append("RETURN @ResultFax; ");

                    Procedure.TextBody = SqlQuery.ToString();

                    Procedure.Create();

                    MessageBox.Show("Procedure CheckForeignKeyFax Created.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int SqlDataReaderRowCount()
        {
            int RowCount = 0;

            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");
                    SqlQuery.Append("SELECT COUNT(*) FROM dbo.ExampleTable;  ");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    while (DataReaderSql.Read())
                    {
                        RowCount = DataReaderSql.GetInt32(0);
                    }

                    DataReaderSql.Close();
                    //ConnectionSql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return RowCount;
        }       

        private int GetCurrentID()
        {
            int CurrentID = 0;

            try
            {
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");

                    SqlQuery.Append("SELECT IDENT_CURRENT('ExampleTable');");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    while (DataReaderSql.Read())
                    {
                        CurrentID = int.Parse(DataReaderSql.GetValue(0).ToString());
                    }

                    DataReaderSql.Close();
                    //ConnectionSql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return CurrentID;
        }

        private int GetNextID()
        {
            int NextID = 0;

            try
            {
                int CurrentID = GetCurrentID();

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");

                    SqlQuery.Append("SELECT IDENT_CURRENT('ExampleTable') + IDENT_INCR('ExampleTable'); ");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    while (DataReaderSql.Read())
                    {
                        NextID = int.Parse(DataReaderSql.GetValue(0).ToString());
                    }

                    DataReaderSql.Close();
                    //ConnectionSql.Close();

                    if (CurrentID == 1 && SqlDataReaderRowCount() == 0)
                    {
                        NextID = CurrentID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return NextID;
        }
        
        private void BindData(SqlDataReader dataReaderSql)
        {
            textBox1.Text = dataReaderSql.GetInt32(0).ToString();
            textBox2.Text = dataReaderSql.GetInt32(1).ToString();
            textBox3.Text = dataReaderSql.GetString(2);

            dateTimePicker1.Value = dataReaderSql.GetDateTime(3);

            if (dataReaderSql.GetBoolean(4))
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            textBox4.Text = dataReaderSql.GetString(5);
            textBox5.Text = dataReaderSql.GetString(6);
        }

        private void NavigateForward()
        {
            try
            {
                int RowCount = SqlDataReaderRowCount();  

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");
                    SqlQuery.Append("SELECT * FROM dbo.ExampleTable; ");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();           

                    while (DataReaderSql.Read())
                    {
                        if (ForwardCount < RowCount)
                        {
                            for (int intIndex = 0; intIndex < ForwardCount; intIndex++)
                            {
                                DataReaderSql.Read();
                            }
                        }
                        else
                        {
                            ForwardCount = 0;
                        }

                        BindData(DataReaderSql);

                        BackwardCount = RowCount - ForwardCount;

                        ForwardCount++;

                        return;
                    }
                    DataReaderSql.Close();
                    //ConnectionSql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NavigateBackward()
        {
            try
            {
                int RowCount = SqlDataReaderRowCount();  

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");
                    SqlQuery.Append("SELECT * FROM dbo.ExampleTable; ");

                    SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    while (DataReaderSql.Read())
                    {
                        if (BackwardCount == 0)
                        {                           
                            BindData(DataReaderSql);

                            ForwardCount = RowCount;
                        }
                        else if (BackwardCount > 0 && BackwardCount < RowCount)
                        {
                            for (int intIndex = 1; intIndex < (RowCount - BackwardCount); intIndex++)
                            {
                                DataReaderSql.Read();
                            }

                            BindData(DataReaderSql);

                            ForwardCount = RowCount - BackwardCount;

                            BackwardCount++;

                            return;
                        }
                        else
                        {
                            BackwardCount = 0;
                        }
                    }
                    BackwardCount++;

                    DataReaderSql.Close();
                    //ConnectionSql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDatabase();
            CreateTable();
            CreateProcedureCheckForeignKeyUserID();
            CreateProcedureCheckForeignKeyPhone();
            CreateProcedureCheckForeignKeyFax();
            
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = GetNextID().ToString();
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;

            dateTimePicker1.Value = DateTime.Now;

            button1.Enabled = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
                        
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;

            Event = "Add";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;

            Event = "Edit";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ID = int.Parse(textBox1.Text);

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;

            dateTimePicker1.Value = DateTime.Now;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;

            Event = "Delete";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Event == "Add")
            {
                try
                {
                    if (textBox1.Text != null && textBox2.Text != null)
                    {
                        int ID = int.Parse(textBox1.Text);

                        int UserID = int.Parse(textBox2.Text);

                        string Name = textBox3.Text;

                        DateTime DateOfBirth = dateTimePicker1.Value;

                        bool IsActive = false;

                        if (radioButton1.Checked)
                        {
                            IsActive = true;
                        }
                        else
                        {
                            IsActive = false;
                        }

                        string Phone = textBox4.Text;

                        string Fax = textBox5.Text;

                        //if ((CheckUserID(UserID) == 0 || ID == UserID) && CheckPhone(Phone) != 0 && (CheckFax(Fax) == 0 || Phone == Fax))
                        //{
                        StringBuilder SqlQuery = new StringBuilder();

                        SqlQuery.Append("USE [ExampleDatabase]; ");
                        SqlQuery.Append("INSERT INTO dbo.ExampleTable ");
                        SqlQuery.Append("( ");
                        SqlQuery.Append("UserID, ");
                        SqlQuery.Append("Name, ");
                        SqlQuery.Append("DateOfBirth, ");
                        SqlQuery.Append("IsActive, ");
                        SqlQuery.Append("Phone, ");
                        SqlQuery.Append("Fax ");
                        SqlQuery.Append(") ");
                        SqlQuery.Append("VALUES ");
                        SqlQuery.Append("( ");
                        SqlQuery.Append("" + UserID + ", ");
                        SqlQuery.Append("'" + Name + "', ");
                        SqlQuery.Append("'" + DateOfBirth + "', ");
                        SqlQuery.Append("'" + IsActive + "', ");
                        SqlQuery.Append("'" + Phone + "', ");
                        SqlQuery.Append("'" + Fax + "'");
                        SqlQuery.Append("); ");

                        using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                        {
                            SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);
                            CommandSql.Connection.Open();
                            CommandSql.ExecuteNonQuery();
                            ConnectionSql.Close();
                        }

                        MessageBox.Show("Row Added.");

                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = false;
                        button5.Enabled = true;
                        button6.Enabled = true;

                        Event = "Save";

                        ForwardCount = 0;

                        BackwardCount = 1;
                    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (Event == "Edit" && SqlDataReaderRowCount() > 0)
            {
                try
                {
                    if (textBox1.Text != null && textBox2.Text != null)
                    {
                        int ID = int.Parse(textBox1.Text);

                        int UserID = int.Parse(textBox2.Text);

                        string Name = textBox3.Text;

                        DateTime DateOfBirth = dateTimePicker1.Value;

                        bool IsActive = false;

                        if (radioButton1.Checked)
                        {
                            IsActive = true;
                        }
                        else
                        {
                            IsActive = false;
                        }

                        string Phone = textBox4.Text;

                        string Fax = textBox5.Text;

                        StringBuilder SqlQuery = new StringBuilder();

                        SqlQuery.Append("USE [ExampleDatabase]; ");
                        SqlQuery.Append("UPDATE dbo.ExampleTable ");
                        SqlQuery.Append("SET ");
                        SqlQuery.Append("UserID = ");
                        SqlQuery.Append("" + UserID + ", ");
                        SqlQuery.Append("Name = ");
                        SqlQuery.Append("'" + Name + "', ");
                        SqlQuery.Append("DateOfBirth = ");
                        SqlQuery.Append("'" + DateOfBirth + "', ");
                        SqlQuery.Append("IsActive = ");
                        SqlQuery.Append("'" + IsActive + "', ");
                        SqlQuery.Append("Phone = ");
                        SqlQuery.Append("'" + Phone + "', ");
                        SqlQuery.Append("Fax = ");
                        SqlQuery.Append("'" + Fax + "'");
                        SqlQuery.Append("WHERE ");
                        SqlQuery.Append("ID = ");
                        SqlQuery.Append("" + ID + "; ");

                        using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                        {
                            SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);
                            CommandSql.Connection.Open();
                            CommandSql.ExecuteNonQuery();
                            ConnectionSql.Close();
                        }

                        MessageBox.Show("Row Edited.");

                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = false;
                        button5.Enabled = true;
                        button6.Enabled = true;

                        Event = "Save";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (Event == "Delete" && SqlDataReaderRowCount() > 0)
            {
                try
                {
                    StringBuilder SqlQuery = new StringBuilder();

                    SqlQuery.Append("USE [ExampleDatabase]; ");
                    SqlQuery.Append("DELETE FROM dbo.ExampleTable ");
                    SqlQuery.Append("WHERE ");
                    SqlQuery.Append("ID = ");
                    SqlQuery.Append("" + ID + " ");

                    using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                    {
                        SqlCommand CommandSql = new SqlCommand(SqlQuery.ToString(), ConnectionSql);
                        CommandSql.Connection.Open();
                        CommandSql.ExecuteNonQuery();
                        ConnectionSql.Close();
                    }

                    MessageBox.Show("Row Deleted.");

                    button1.Enabled = true;

                    if (SqlDataReaderRowCount() > 0)
                    {
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = true;
                    }

                    button4.Enabled = false;

                    Event = "Save";

                    textBox1.Text = string.Empty;

                    ForwardCount--;

                    NavigateForward();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NavigateForward();
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            NavigateBackward();
        }      
    }
}
