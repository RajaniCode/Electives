using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int currentIndex = 0;

        private void BindData(int index)
        {
            using (var db = new EFCRUDContext())
            {
                var query = from c in db.Customers
                            select c;

                DataTable datTable = new DataTable();
                datTable.Columns.Add("CustomerId", typeof(int));
                datTable.Columns.Add("FirstName", typeof(string));
                datTable.Columns.Add("LastName", typeof(string));
                datTable.Columns.Add("Synonym", typeof(string));

                int RowCount = GetRowCount();
                if (RowCount > 0)
                {
                    // IQueryable Top 
                    var topNumberOfRecords = query.Take(index + 1);

                    //var rowCount = topNumberOfRecords.Count();
                    //var rowLongCount = topNumberOfRecords.LongCount();

                    //foreach (var record in topNumberOfRecords)
                    //{  
                    //    textBox1.Text = record.CustomerId.ToString().Trim();
                    //    textBox2.Text = record.FirstName.ToString().Trim();
                    //    textBox3.Text = record.LastName.ToString().Trim();
                    //    textBox4.Text = record.Synonym.ToString().Trim();     
                    //}

                    foreach (var record in topNumberOfRecords)
                    {
                        DataRow datRow = datTable.NewRow();
                        datRow["CustomerId"] = record.CustomerId.ToString().Trim();
                        datRow["FirstName"] = record.FirstName.ToString().Trim();
                        datRow["LastName"] = record.LastName.ToString().Trim();
                        datRow["Synonym"] = record.Synonym.ToString().Trim();
                        datTable.Rows.Add(datRow);
                    }

                    if (datTable.Rows.Count > 0)
                    {
                        textBox1.Text = datTable.Rows[datTable.Rows.Count -1]["CustomerId"].ToString().Trim();
                        textBox2.Text = datTable.Rows[datTable.Rows.Count - 1]["FirstName"].ToString().Trim();
                        textBox3.Text = datTable.Rows[datTable.Rows.Count - 1]["LastName"].ToString().Trim();
                        textBox4.Text = datTable.Rows[datTable.Rows.Count - 1]["Synonym"].ToString().Trim();
                    }                   
                }
            }
        }

        private DataTable SelectRecord()
        {
            DataTable datTable = new DataTable();
            datTable.Columns.Add("CustomerId", typeof(int));
            datTable.Columns.Add("FirstName", typeof(string));
            datTable.Columns.Add("LastName", typeof(string));
            datTable.Columns.Add("Synonym", typeof(string));
            try
            {
                using (var db = new EFCRUDContext())
                {
                    var query = from c in db.Customers
                                select c;
                   
                    foreach (var record in query)
                    {
                        DataRow datRow = datTable.NewRow();
                        datRow["CustomerId"] = record.CustomerId.ToString().Trim();
                        datRow["FirstName"] = record.FirstName.ToString().Trim();
                        datRow["LastName"] = record.LastName.ToString().Trim();
                        datRow["Synonym"] = record.Synonym.ToString().Trim();
                        datTable.Rows.Add(datRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datTable;
        }

        private DataTable SelectRecord(string column)
        {
            DataTable datTable = new DataTable();
            datTable.Columns.Add("CustomerId", typeof(int));
            datTable.Columns.Add("FirstName", typeof(string));
            datTable.Columns.Add("LastName", typeof(string));
            datTable.Columns.Add("Synonym", typeof(string));

            try
            {                
                using (var db = new EFCRUDContext())
                {                    
                    IQueryable<Customer> query = null;

                    if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                    {
                        int custId = Convert.ToInt32(textBox1.Text.Trim());
                        query = from c in db.Customers
                               where c.CustomerId.Equals(custId)
                               select c;
                    }
                    else if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                    {
                        query = from c in db.Customers
                                    where c.FirstName == textBox2.Text.Trim()
                                    select c;
                    }
                    else if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                    {
                        query = from c in db.Customers
                                    where c.LastName == textBox3.Text.Trim()
                                    select c;
                    }
                    else if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
                    {
                       query = from c in db.Customers
                                    where c.Synonym == textBox4.Text.Trim()
                                    select c;
                    }

                    if (query != null)
                    {
                        foreach (var record in query)
                        {                            
                            DataRow datRow = datTable.NewRow();
                            datRow["CustomerId"] = Convert.ToInt32(record.CustomerId);
                            datRow["FirstName"] = record.FirstName.ToString().Trim();
                            datRow["LastName"] = record.LastName.ToString().Trim();
                            datRow["Synonym"] = record.Synonym.ToString().Trim();
                            datTable.Rows.Add(datRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datTable;
        }
       
        private int GetRowCount()
        {
            int recordCount = 0;
            using (var db = new EFCRUDContext())
            {
                var customerCount = (from c in db.Customers select c).Count();
                recordCount = db.Customers.Count();               
            }
            return recordCount;
        }

        private void NavigateForward()
        {
            int RowCount = GetRowCount();
            if (RowCount == 0)
            {
                MessageBox.Show("No records.");
                return;
            }
            else if (RowCount == -1)
            {
                return;
            }
            if (currentIndex >= 0 && currentIndex <= RowCount)
            {
                if (currentIndex == RowCount)
                {
                    currentIndex = 0;
                    BindData(currentIndex);
                }
                else
                {
                    BindData(currentIndex);
                }
                currentIndex++;
            }
            if (RowCount > 0)
            {
                textBox5.Text = Convert.ToString(currentIndex);
            }
        }

        private void NavigateBackward()
        {
            int RowCount = GetRowCount();
            if (RowCount == 0)
            {
                MessageBox.Show("No records.");
                return;
            }
            else if (RowCount == -1)
            {
                return;
            }
            if (currentIndex >= 0 && currentIndex <= RowCount)
            {
                if (currentIndex == 0)
                {
                    currentIndex = RowCount;
                    BindData(currentIndex - 1);
                }
                else if (currentIndex == 1)
                {
                    currentIndex = RowCount;
                    BindData(currentIndex - 1);
                }
                else
                {
                    currentIndex--;
                    BindData(currentIndex - 1);
                }
            }
            if (RowCount > 0)
            {
                textBox5.Text = Convert.ToString(currentIndex);
            }
        }

        private bool Insert(string fName, string lName, string syn)
        {
            bool isInserted = false;
            try
            {
                int rowsAffected = 0;

                using (var db = new EFCRUDContext())
                {
                    var customerRecord = new Customer { FirstName = fName, LastName = lName, Synonym = syn };
                    db.Customers.Add(customerRecord);
                    db.SaveChanges();
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
        
        private bool Update(int custId, string fName, string lName, string syn)
        {
            bool isUpdated = false;
            try
            {
                using (var db = new EFCRUDContext())
                {
                  
                    Customer customerRecord = (from c in db.Customers
                                                where c.CustomerId == custId
                                                select c).First();
                    customerRecord.FirstName = fName;
                    customerRecord.LastName = lName;
                    customerRecord.Synonym = syn;
                    db.SaveChanges();
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
                using (var db = new EFCRUDContext())
                {
                    var customerRecord = new Customer { CustomerId = custId};
                    db.Customers.Attach(customerRecord);
                    db.Customers.Remove(customerRecord);
                    db.SaveChanges();
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

            DialogResult ResultDialog = MessageBox.Show("Do you want to insert the values of the textboxes?", "Insert",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultDialog == DialogResult.Yes)
            {
                string fName = textBox2.Text.Trim();
                string lName = textBox3.Text.Trim();
                string syn = textBox4.Text.Trim();
                if (Insert(fName, lName, syn))
                {
                    MessageBox.Show("Insert success.");

                    int RowCount = GetRowCount();
                    int index = RowCount - 1;
                    BindData(index);
                    currentIndex = RowCount;
                    textBox5.Text = Convert.ToString(currentIndex);
                }
            }
            else if (ResultDialog == DialogResult.No)
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
            DialogResult ResultDialog = MessageBox.Show("Do you want to update?", "Update",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultDialog == DialogResult.Yes)
            {
                int custId = Convert.ToInt32(textBox1.Text.Trim());
                string fName = textBox2.Text.Trim();
                string lName = textBox3.Text.Trim();
                string syn= textBox4.Text.Trim();

                if (Update(custId, fName, lName, syn))
                {
                    MessageBox.Show("Update success.");

                    int index = currentIndex - 1;
                    BindData(index);
                    textBox5.Text = Convert.ToString(currentIndex);
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
            DialogResult ResultDialog = MessageBox.Show("Do you want to delete?", "Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultDialog == DialogResult.Yes)
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
                    currentIndex = RowCount;
                    if (RowCount > 0)
                    {
                        textBox5.Text = Convert.ToString(currentIndex);
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
                DataTable datTable = new DataTable();

                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    datTable = SelectRecord(textBox1.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    datTable = SelectRecord(textBox2.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                {
                    datTable = SelectRecord(textBox3.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
                {
                    datTable = SelectRecord(textBox4.Text.Trim());
                }

                if (datTable != null && datTable.Rows.Count > 0)
                {
                    datTable.PrimaryKey = new[] { datTable.Columns["CustomerId"] };

                    //Also
                    //DataRow[] datRows = datTable.Select();
                    //DataRow datRow = datRows[0];
                    DataRow datRow = datTable.Rows[0];

                    DataTable recordDataTable = SelectRecord();

                    if (recordDataTable != null && recordDataTable.Rows.Count > 0)
                    {
                        recordDataTable.PrimaryKey = new[] { recordDataTable.Columns["CustomerId"] };

                        DataRow primaryKeyDataRow = recordDataTable.Rows.Find(datRow["CustomerId"]);
                        int index = recordDataTable.Rows.IndexOf(primaryKeyDataRow);

                        //Also LINQ
                        DataRow linqDataRow = recordDataTable.AsEnumerable().FirstOrDefault(r => r["CustomerId"].Equals(datRow["CustomerId"]));
                        int linqIndex = recordDataTable.Rows.IndexOf(linqDataRow);

                        BindData(index);
                        currentIndex = index + 1;

                        textBox5.Text = Convert.ToString(currentIndex);
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
                else
                {
                    MessageBox.Show("No record found.");
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please enter First Name or Last Name or Synonym to retrieve the record.");
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
