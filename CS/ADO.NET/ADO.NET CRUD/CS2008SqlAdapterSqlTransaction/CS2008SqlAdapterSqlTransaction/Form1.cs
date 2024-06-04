using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CS2008SqlAdapterSqlTransaction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int recordNumber = 0;

        private void NavigateForward()
        {
            int rowCount = GetRowCount();
            if (rowCount == 0)
            {
                MessageBox.Show("No records.");
                return;
            }
            else if (rowCount == -1)
            {
                return;
            }
            if (recordNumber >= 0 && recordNumber <= rowCount)
            {
                if (recordNumber == rowCount)
                {
                    recordNumber = 0;
                    BindData(recordNumber);
                }
                else
                {
                    BindData(recordNumber);
                }
                recordNumber++;
            }
            if (rowCount > 0)
            {
                textBox5.Text = Convert.ToString(recordNumber);
            }
        }

        private void NavigateBackward()
        {
            int rowCount = GetRowCount();
            if (rowCount == 0)
            {
                MessageBox.Show("No records.");
                return;
            }
            else if (rowCount == -1)
            {
                return;
            }
            if (recordNumber >= 0 && recordNumber <= rowCount)
            {
                if (recordNumber == 0)
                {
                    recordNumber = rowCount;
                    BindData(recordNumber - 1);
                }
                else if (recordNumber == 1)
                {
                    recordNumber = rowCount;
                    BindData(recordNumber - 1);
                }
                else
                {
                    recordNumber--;
                    BindData(recordNumber - 1);
                }
            }
            if (rowCount > 0)
            {
                textBox5.Text = Convert.ToString(recordNumber);
            }
        }

        private void BindData(int index)
        {
            DataTable datTable = SelectAll();
            int rowCount = GetRowCount();
            if (rowCount > 0)
            {
                textBox1.Text = datTable.Rows[index]["CustomerId"].ToString().Trim();
                textBox2.Text = datTable.Rows[index]["FirstName"].ToString().Trim();
                textBox3.Text = datTable.Rows[index]["LastName"].ToString().Trim();
                textBox4.Text = datTable.Rows[index]["Technology"].ToString().Trim();
            }
        }

        private int GetRowCount()
        {
            int recordCount = 0;
            DataTable datTable = SelectAll();
            if (datTable != null && datTable.Rows.Count > 0)
            {
                recordCount = datTable.Rows.Count;
            }
            else
            {
                recordCount = -1;
            }
            return recordCount;
        }

        private DataTable SelectAll()
        {
            DataTable datTable = null;
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append("Select * FROM Customer;");

                using (SqlCommand commandSql = new SqlCommand(selectQuery.ToString()))
                {
                    SQLServerHelper sqlHelper = new SQLServerHelper();
                    datTable = sqlHelper.Select(commandSql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datTable;
        }

        private bool Insert(string fName, string lName, string tech)
        {
            bool isInserted = false;
            try
            {
                int rowsAffected = 0;
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append("INSERT INTO Customer ");
                insertQuery.Append("(");
                insertQuery.Append("FirstName, ");
                insertQuery.Append("LastName, ");
                insertQuery.Append("Technology ");
                insertQuery.Append(") ");
                insertQuery.Append("VALUES ");
                insertQuery.Append("(");
                insertQuery.Append("@FirstName, ");
                insertQuery.Append("@LastName, ");
                insertQuery.Append("@Technology ");
                insertQuery.Append(");");

                using (SqlCommand commandSql = new SqlCommand(insertQuery.ToString()))
                {
                    commandSql.Parameters.AddWithValue("@FirstName", fName);
                    commandSql.Parameters.AddWithValue("@LastName", lName);
                    commandSql.Parameters.AddWithValue("@Technology", tech);

                    SQLServerHelper sqlHelper = new SQLServerHelper();
                    rowsAffected = sqlHelper.Insert(commandSql);
                }

                if (rowsAffected > 0)
                {
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isInserted;
        }


        private bool Update(int custId, string fName, string lName, string tech)
        {
            bool isUpdated = false;
            try
            {
                int rowsAffected = 0;
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append("UPDATE Customer ");
                updateQuery.Append("SET ");
                updateQuery.Append("FirstName = @FirstName, ");
                updateQuery.Append("LastName = @LastName, ");
                updateQuery.Append("Technology = @Technology ");
                updateQuery.Append("WHERE ");
                updateQuery.Append("CustomerId = @CustomerId;");
                using (SqlCommand commandSql = new SqlCommand(updateQuery.ToString()))
                {
                    commandSql.Parameters.AddWithValue("@CustomerId", custId);
                    commandSql.Parameters.AddWithValue("@FirstName", fName);
                    commandSql.Parameters.AddWithValue("@LastName", lName);
                    commandSql.Parameters.AddWithValue("@Technology", tech);
                    SQLServerHelper sqlHelper = new SQLServerHelper();
                    rowsAffected = sqlHelper.Update(commandSql);
                }

                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isUpdated;
        }

        private bool Delete(int custId)
        {
            bool isDeleted = false;

            try
            {
                int rowsAffected = 0;
                StringBuilder deleteQuery = new StringBuilder();
                deleteQuery.Append("DELETE FROM Customer ");
                deleteQuery.Append("WHERE ");
                deleteQuery.Append("CustomerId = @CustomerId;");
                using (SqlCommand commandSql = new SqlCommand(deleteQuery.ToString()))
                {
                    commandSql.Parameters.AddWithValue("@CustomerId", custId);
                    SQLServerHelper sqlHelper = new SQLServerHelper();
                    rowsAffected = sqlHelper.Delete(commandSql);
                }

                if (rowsAffected > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isDeleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult resultDialog = MessageBox.Show("Do you want to insert?", "Insert",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes)
            {
                string fName = textBox2.Text.Trim();
                string lName = textBox3.Text.Trim();
                string tech = textBox4.Text.Trim();
                if (Insert(fName, lName, tech))
                {
                    MessageBox.Show("Insert success.");

                    int RowCount = GetRowCount();
                    int index = RowCount - 1;
                    BindData(index);
                    recordNumber = RowCount;
                    textBox5.Text = Convert.ToString(recordNumber);
                }
            }
            else if (resultDialog == DialogResult.No)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Select or navigate to update.");
                return;
            }
            DialogResult resultDialog = MessageBox.Show("Do you want to update?", "Update",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes)
            {
                int custId = Convert.ToInt32(textBox1.Text.Trim());
                string fName = textBox2.Text.Trim();
                string lName = textBox3.Text.Trim();
                string tech = textBox4.Text.Trim();

                if (Update(custId, fName, lName, tech))
                {
                    MessageBox.Show("Update success.");

                    int index = recordNumber - 1;
                    BindData(index);
                    textBox5.Text = Convert.ToString(recordNumber);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Select or navigate to delete.");
                return;
            }
            DialogResult resultDialog = MessageBox.Show("Do you want to delete?", "Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes)
            {
                int custId = Convert.ToInt32(textBox1.Text.Trim());

                if (Delete(custId))
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    MessageBox.Show("Delete success.");
                    int RowCount = GetRowCount();
                    int index = RowCount - 1;
                    BindData(index);
                    recordNumber = RowCount;
                    if (RowCount > 0)
                    {
                        textBox5.Text = Convert.ToString(recordNumber);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim())
             || !string.IsNullOrEmpty(textBox2.Text.Trim())
             || !string.IsNullOrEmpty(textBox3.Text.Trim())
             || !string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                DataTable datTable = SelectAll();

                if (datTable != null && datTable.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                    {
                        int custId = Convert.ToInt32(textBox1.Text.Trim());

                        string expression = string.Format("CustomerId = {0}", custId);
                        string sortOrder = "CustomerId ASC";

                        DataRow[] dataRowsCustomer = datTable.Select(expression, sortOrder, DataViewRowState.CurrentRows);
                        DataRow firstOrDefaultCustomer = dataRowsCustomer.FirstOrDefault();
                        //IEnumerable<DataRow> TopNumber1Customer = dataRowsCustomer.Take(1);

                        if (dataRowsCustomer.Length > 0)
                        {
                            textBox1.Text = Convert.ToString(firstOrDefaultCustomer["CustomerId"]);
                            textBox2.Text = Convert.ToString(firstOrDefaultCustomer["FirstName"]);
                            textBox3.Text = Convert.ToString(firstOrDefaultCustomer["LastName"]);
                            textBox4.Text = Convert.ToString(firstOrDefaultCustomer["Technology"]);

                            //OrderBy is optional
                            var selectCustomerIds = datTable.AsEnumerable().Select((r, i) => new { Row = r, Index = i })
                                               .Where(x => x.Row.Field<int>("CustomerId") == custId)
                                               .OrderBy(x => x.Row.Field<int>("CustomerId"));

                            var selectCustomerIdsList = selectCustomerIds.ToList();

                            recordNumber = selectCustomerIdsList.First().Index + 1;
                            textBox5.Text = Convert.ToString(recordNumber);
                            MessageBox.Show("Top matching record.");
                        }
                        else
                        {
                            MessageBox.Show("No matching record.");
                        }
                    }
                    else if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                    {
                        string expression = string.Format("FirstName = '{0}'", textBox2.Text.Trim());
                        string sortOrder = "CustomerId ASC";

                        DataRow[] dataRowsCustomer = datTable.Select(expression, sortOrder, DataViewRowState.CurrentRows);
                        DataRow firstOrDefaultCustomer = dataRowsCustomer.FirstOrDefault();
                        //IEnumerable<DataRow> TopNumber1Customer = dataRowsCustomer.Take(1);

                        if (dataRowsCustomer.Length > 0)
                        {
                            textBox1.Text = Convert.ToString(firstOrDefaultCustomer["CustomerId"]);
                            textBox2.Text = Convert.ToString(firstOrDefaultCustomer["FirstName"]);
                            textBox3.Text = Convert.ToString(firstOrDefaultCustomer["LastName"]);
                            textBox4.Text = Convert.ToString(firstOrDefaultCustomer["Technology"]);

                            //OrderBy is optional
                            var selecFirstNames = datTable.AsEnumerable().Select((r, i) => new { Row = r, Index = i })
                                               .Where(x => x.Row.Field<string>("FirstName") == textBox2.Text.Trim())
                                               .OrderBy(x => x.Row.Field<int>("CustomerId"));

                            var selecFirstNamesList = selecFirstNames.ToList();

                            recordNumber = selecFirstNamesList.First().Index + 1;
                            textBox5.Text = Convert.ToString(recordNumber);
                            MessageBox.Show("Top matching record.");
                        }
                        else
                        {
                            MessageBox.Show("No matching record.");
                        }
                    }
                    else if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                    {
                        string expression = string.Format("LastName = '{0}'", textBox3.Text.Trim());
                        string sortOrder = "CustomerId ASC";

                        DataRow[] dataRowsCustomer = datTable.Select(expression, sortOrder, DataViewRowState.CurrentRows);
                        DataRow firstOrDefaultCustomer = dataRowsCustomer.FirstOrDefault();
                        IEnumerable<DataRow> TopNumber1Customer = dataRowsCustomer.Take(1);

                        if (dataRowsCustomer.Length > 0)
                        {
                            textBox1.Text = Convert.ToString(firstOrDefaultCustomer["CustomerId"]);
                            textBox2.Text = Convert.ToString(firstOrDefaultCustomer["FirstName"]);
                            textBox3.Text = Convert.ToString(firstOrDefaultCustomer["LastName"]);
                            textBox4.Text = Convert.ToString(firstOrDefaultCustomer["Technology"]);

                            //OrderBy is optional
                            var selectLastNames = datTable.AsEnumerable().Select((r, i) => new { Row = r, Index = i })
                                               .Where(x => x.Row.Field<string>("LastName") == textBox3.Text.Trim())
                                               .OrderBy(x => x.Row.Field<int>("CustomerId")); 

                            var selectLastNamesList = selectLastNames.ToList();

                            recordNumber = selectLastNamesList.First().Index + 1;
                            textBox5.Text = Convert.ToString(recordNumber);
                            MessageBox.Show("Top matching record.");
                        }
                        else
                        {
                            MessageBox.Show("No matching record.");
                        }
                    }
                    else if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
                    {
                        string expression = string.Format("Technology = '{0}'", textBox4.Text.Trim());
                        string sortOrder = "CustomerId ASC";

                        DataRow[] dataRowsCustomer = datTable.Select(expression, sortOrder, DataViewRowState.CurrentRows);
                        DataRow firstOrDefaultCustomer = dataRowsCustomer.FirstOrDefault();
                        IEnumerable<DataRow> TopNumber1Customer = dataRowsCustomer.Take(1);

                        if (dataRowsCustomer.Length > 0)
                        {
                            textBox1.Text = Convert.ToString(firstOrDefaultCustomer["CustomerId"]);
                            textBox2.Text = Convert.ToString(firstOrDefaultCustomer["FirstName"]);
                            textBox3.Text = Convert.ToString(firstOrDefaultCustomer["LastName"]);
                            textBox4.Text = Convert.ToString(firstOrDefaultCustomer["Technology"]);

                            //OrderBy is optional
                            var selectTechnologies = datTable.AsEnumerable().Select((r, i) => new { Row = r, Index = i })
                                               .Where(x => x.Row.Field<string>("Technology") == textBox4.Text.Trim())
                                               .OrderBy(x => x.Row.Field<int>("CustomerId"));

                            var selectTechnologiesList = selectTechnologies.ToList();

                            recordNumber = selectTechnologiesList.First().Index + 1;
                            textBox5.Text = Convert.ToString(recordNumber);
                            MessageBox.Show("Top matching record.");
                        }
                        else
                        {
                            MessageBox.Show("No matching record.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No such record.");
                    }
                }
                else
                {
                    MessageBox.Show("Records are empty.");
                }
            }
            else
            {
                MessageBox.Show("Please enter First Name or Last Name or Technology to retrieve the record.");
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

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}

/* Note Primary Key
if (datTable != null && datTable.Rows.Count > 0)
{
    datTable.PrimaryKey = new[] { datTable.Columns["CustomerId"] };

    //Also
    //DataRow[] datRows = datTable.Select();
    //DataRow datRow = datRows[0];
    DataRow datRow = datTable.Rows[0];

    DataTable recordDataTable = SelectAll();

    if (recordDataTable != null && recordDataTable.Rows.Count > 0)
    {
        recordDataTable.PrimaryKey = new[] { recordDataTable.Columns["CustomerId"] };

        DataRow primaryKeyDataRow = recordDataTable.Rows.Find(datRow["CustomerId"]);
        int index = recordDataTable.Rows.IndexOf(primaryKeyDataRow);

        //Also LINQ
        DataRow linqDataRow = recordDataTable.AsEnumerable().FirstOrDefault(r => r["CustomerId"].Equals(datRow["CustomerId"]));
        int linqIndex = recordDataTable.Rows.IndexOf(linqDataRow);

        BindData(index);
        recordNumber = index + 1;

        textBox5.Text = Convert.ToString(recordNumber);
    }
    else
    {
        textBox1.Text = string.Empty;
        textBox2.Text = string.Empty;
        textBox3.Text = string.Empty;
        textBox4.Text = string.Empty;
        textBox5.Text = string.Empty;
    }
}
*/