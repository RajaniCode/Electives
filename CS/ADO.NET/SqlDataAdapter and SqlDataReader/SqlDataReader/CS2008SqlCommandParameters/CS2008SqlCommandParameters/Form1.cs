using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace CS2008SqlCommandParameters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int ForwardCount;
        int BackwardCount;
        int CustomerID;

        string CustID;
        string FirstName;
        string LastName;
        string Country;

        string Event;

        private string ConnectionString
        {
            get
            {
                ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
                return ConnectionStringSetting["ConnectionString"].ConnectionString;
            }
        }

        private void Retrieve()
        {
            try
            {
                string SqlQuery = "SELECT * FROM dbo.Customer WHERE FirstName = @FirstName; ";

                int RowCount = GetRowCount();

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    CommandSql.Parameters.AddWithValue("@FirstName", textBox2.Text);

                    //Fourth parameter is optional
                    //CommandSql.Parameters.Add("@FirstName", SqlDbType.NVarChar, int.MaxValue);
                    //CommandSql.Parameters["@FirstName"].Value = textBox2.Text;

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    if (DataReaderSql.HasRows)
                    {
                        int CustomerIdentity = 0;

                        while (DataReaderSql.Read())
                        {
                            BindData(DataReaderSql);
                            MessageBox.Show("CustomerID: " + DataReaderSql.GetInt32(0).ToString());
                            CustomerIdentity = DataReaderSql.GetInt32(0);
                        }

                        int Index = GetIndex(CustomerIdentity);
                        BackwardCount = RowCount - Index;
                        ForwardCount = Index + 1;
                    }
                    else
                    {
                        MessageBox.Show("First Name does not exist in database.");
                        textBox2.Text = string.Empty;
                    }

                    DataReaderSql.Close();
                    //ConnectionSql.Close();
                }

                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = true;

                Event = "Save";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Add()
        {
            try
            {
                string SqlQuery = "INSERT INTO dbo.Customer ";
                SqlQuery += "( ";
                SqlQuery += "FirstName, ";
                SqlQuery += "LastName, ";
                SqlQuery += "Country ";
                SqlQuery += ") ";
                SqlQuery += "VALUES ";
                SqlQuery += "( ";
                SqlQuery += "@FirstName, ";
                SqlQuery += "@LastName, ";
                SqlQuery += "@Country ";
                SqlQuery += ") ";

                int RowsAffected = 0;
                
                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    CommandSql.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    CommandSql.Parameters.AddWithValue("@LastName", textBox3.Text);
                    CommandSql.Parameters.AddWithValue("@Country", textBox4.Text);
                    
                    //Fourth parameter is optional
                    //CommandSql.Parameters.Add("@FirstName", SqlDbType.NVarChar, int.MaxValue);
                    //CommandSql.Parameters.Add("@LastName", SqlDbType.NVarChar, int.MaxValue);
                    //CommandSql.Parameters.Add("@Country", SqlDbType.NVarChar, int.MaxValue);

                    //CommandSql.Parameters["@FirstName"].Value = textBox2.Text;
                    //CommandSql.Parameters["@LastName"].Value = textBox3.Text;
                    //CommandSql.Parameters["@Country"].Value = textBox4.Text;
                                       
                    ConnectionSql.Open();

                    RowsAffected = CommandSql.ExecuteNonQuery();
                }

                MessageBox.Show("Rows Affected: " + RowsAffected);

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = true;

                ForwardCount = 0;

                BackwardCount = 1;

                Event = "Save";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Modify()
        {
            try
            {
                string SqlQuery = "UPDATE dbo.Customer ";
                SqlQuery += "SET ";
                SqlQuery += "FirstName = @FirstName, ";
                SqlQuery += "LastName = @LastName, ";
                SqlQuery += "Country = @Country ";
                SqlQuery += "WHERE ";
                SqlQuery += "CustomerID = @CustomerID; ";

                int RowsAffected = 0;

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    CommandSql.Parameters.AddWithValue("@CustomerID", CustomerID);
                    CommandSql.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    CommandSql.Parameters.AddWithValue("@LastName", textBox3.Text);
                    CommandSql.Parameters.AddWithValue("@Country", textBox4.Text);
                    
                    //Fourth parameter is optional
                    //CommandSql.Parameters.Add("@CustomerID", SqlDbType.Int, int.MaxValue);
                    //CommandSql.Parameters.Add("@FirstName", SqlDbType.NVarChar, int.MaxValue);
                    //CommandSql.Parameters.Add("@LastName", SqlDbType.NVarChar, int.MaxValue);
                    //CommandSql.Parameters.Add("@Country", SqlDbType.NVarChar, int.MaxValue);

                    //CommandSql.Parameters["@CustomerID"].Value = CustomerID;
                    //CommandSql.Parameters["@FirstName"].Value = textBox2.Text;
                    //CommandSql.Parameters["@LastName"].Value = textBox3.Text;
                    //CommandSql.Parameters["@Country"].Value = textBox4.Text;
                                       
                    ConnectionSql.Open();

                    RowsAffected = CommandSql.ExecuteNonQuery();
                }

                MessageBox.Show("Rows Affected: " + RowsAffected);

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = true;

                Event = "Save";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Delete()
        {
            try
            {
                string SqlQuery = "DELETE FROM dbo.Customer ";
                SqlQuery += "WHERE ";
                SqlQuery += "CustomerID = @CustomerID; ";
                
                int RowsAffected = 0;

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    CommandSql.Parameters.AddWithValue("@CustomerID", CustomerID);

                    //Fourth parameter is optional
                    //CommandSql.Parameters.Add("@CustomerID", SqlDbType.Int, int.MaxValue);
                    //CommandSql.Parameters["@CustomerID"].Value = CustomerID;

                    ConnectionSql.Open();

                    RowsAffected = CommandSql.ExecuteNonQuery();
                }

                MessageBox.Show("Rows Affected: " + RowsAffected);

                button1.Enabled = true;
                button2.Enabled = true;

                if (GetRowCount() > 0)
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                }

                button5.Enabled = false;

                ForwardCount--;

                NavigateForward();

                Event = "Save";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int GetRowCount()
        {
            int RowCount = 0;

            try
            {
                string SqlQuery = "SELECT * FROM dbo.Customer;  ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    if (DataReaderSql.HasRows)
                    {
                        while (DataReaderSql.Read())
                        {
                            RowCount++;
                        }
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
                string SqlQuery = "SELECT IDENT_CURRENT('Customer'); ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    ConnectionSql.Open();

                    CurrentID = int.Parse(CommandSql.ExecuteScalar().ToString());

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

                string SqlQuery = "SELECT IDENT_CURRENT('Customer') + IDENT_INCR('Customer'); ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    ConnectionSql.Open();

                    NextID = int.Parse(CommandSql.ExecuteScalar().ToString());

                    //ConnectionSql.Close();                   
                }

                if (CurrentID == 1 && GetRowCount() == 0)
                {
                    NextID = CurrentID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return NextID;
        }

        private int GetIndex(int customerIdentity)
        {
            int Index = 0;

            try
            {
                int RowCount = 0;

                string SqlQuery = "SELECT * FROM dbo.Customer;  ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    if (DataReaderSql.HasRows)
                    {
                        while (DataReaderSql.Read())
                        {
                            RowCount++;
                            if (DataReaderSql.GetInt32(0) == customerIdentity)
                            {
                                break;
                            }
                        }
                    }                   
                    DataReaderSql.Close();
                    //ConnectionSql.Close();
                }

                Index = RowCount - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Index;
        }

        private void NavigateForward()
        {
            try
            {
                if (ForwardCount < 0)
                {
                    ForwardCount = 0;
                }

                int RowCount = GetRowCount();

                string SqlQuery = "SELECT * FROM dbo.Customer; ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    if (DataReaderSql.HasRows)
                    {
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
                int RowCount = GetRowCount();

                string SqlQuery = "SELECT * FROM dbo.Customer; ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlCommand CommandSql = new SqlCommand(SqlQuery, ConnectionSql);

                    ConnectionSql.Open();

                    SqlDataReader DataReaderSql = CommandSql.ExecuteReader();

                    if (DataReaderSql.HasRows)
                    {
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
        
        private void BindData(SqlDataReader dataReaderSql)
        {
            textBox1.Text = dataReaderSql.GetInt32(0).ToString();
            textBox2.Text = dataReaderSql.GetString(1);
            textBox3.Text = dataReaderSql.GetString(2);
            textBox4.Text = dataReaderSql.GetString(3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            if (GetRowCount() > 0)
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;

            textBox2.Focus();

            Event = "Retrieve";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustID = textBox1.Text;
            FirstName = textBox2.Text;
            LastName = textBox3.Text;
            Country = textBox4.Text;

            textBox1.Text = GetNextID().ToString();
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;

            Event = "Add";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustID = textBox1.Text;
            CustomerID = int.Parse(CustID);
            FirstName = textBox2.Text;
            LastName = textBox3.Text;
            Country = textBox4.Text;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;

            Event = "Modify";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustID = textBox1.Text;
            CustomerID = int.Parse(CustID);
            FirstName = textBox2.Text;
            LastName = textBox3.Text;
            Country = textBox4.Text;

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;

            Event = "Delete";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult ResultDialog = MessageBox.Show("Do you want to save?", "Message",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ResultDialog == DialogResult.No)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;

                textBox1.Text = CustID;
                textBox2.Text = FirstName;
                textBox3.Text = LastName;
                textBox4.Text = Country;

                button1.Enabled = true;
                button2.Enabled = true;

                button5.Enabled = false;

                if (GetRowCount() > 0)
                {
                    button6.Enabled = true;
                    button7.Enabled = true;
                }
                else
                {
                    button6.Enabled = false;
                    button7.Enabled = false;
                }

                if (CustID != string.Empty)
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                    button4.Enabled = false;
                }

                return;
            }

            if (Event == "Retrieve")
            {
                Retrieve();
            }
            else if (Event == "Add")
            {
                Add();
            }
            else if (Event == "Modify" && GetRowCount() > 0)
            {
                Modify();
            }
            else if (Event == "Delete" && GetRowCount() > 0)
            {
                Delete();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NavigateForward();

            if (GetRowCount() > 0)
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NavigateBackward();

            if (GetRowCount() > 0)
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
    }
}
