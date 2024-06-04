using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EF6CodeFirstExistingSQLServer2014
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int recordNumber = 0;

        private void BindData(int index)
        {
            using (var db = new EF6CodeFirstExistingSQLServer2014Context())
            {
                var query = from c in db.Customers
                            select c;

                //var rowCount = (from c in db.Customers
                                //select c).Count();

                var rowCount = db.Customers.Count();   

                var customerList = query.ToList<Customer>();
                
                if (rowCount > 0)
                {
                    textBox1.Text = Convert.ToString(customerList[index].CustomerId);
                    textBox2.Text = Convert.ToString(customerList[index].FirstName);
                    textBox3.Text = Convert.ToString(customerList[index].LastName);
                    textBox4.Text = Convert.ToString(customerList[index].Technology);
                }
                
                /*
                var zxc = query.Select(c => c.CustomerId);
                var z = zxc.ToList();
                var zx = query.ToList<Customer>();
                
                DataTable datTable = new DataTable();
                datTable.Columns.Add("CustomerId", typeof(int));
                datTable.Columns.Add("FirstName", typeof(string));
                datTable.Columns.Add("LastName", typeof(string));
                datTable.Columns.Add("Technology", typeof(string));

                // IQueryable Top 
                var topNumberOfRecords = query.Take(index + 1);
                //var rowCount = topNumberOfRecords.Count();
                //var rowLongCount = topNumberOfRecords.LongCount();

                //foreach (var record in topNumberOfRecords)
                //{  
                //    textBox1.Text = record.CustomerId.ToString().Trim();
                //    textBox2.Text = record.FirstName.ToString().Trim();
                //    textBox3.Text = record.LastName.ToString().Trim();
                //    textBox4.Text = record.Technology.ToString().Trim();     
                //}

                foreach (var record in topNumberOfRecords)
                {
                    DataRow datRow = datTable.NewRow();
                    datRow["CustomerId"] = record.CustomerId.ToString().Trim();
                    datRow["FirstName"] = record.FirstName.ToString().Trim();
                    datRow["LastName"] = record.LastName.ToString().Trim();
                    datRow["Technology"] = record.Technology.ToString().Trim();
                    datTable.Rows.Add(datRow);
                }

                if (datTable.Rows.Count > 0)
                {
                    textBox1.Text = datTable.Rows[datTable.Rows.Count - 1]["CustomerId"].ToString().Trim();
                    textBox2.Text = datTable.Rows[datTable.Rows.Count - 1]["FirstName"].ToString().Trim();
                    textBox3.Text = datTable.Rows[datTable.Rows.Count - 1]["LastName"].ToString().Trim();
                    textBox4.Text = datTable.Rows[datTable.Rows.Count - 1]["Technology"].ToString().Trim();
                }*/
            }
        }

        private int GetRowCount()
        {
            int recordCount = 0;
            using (var db = new EF6CodeFirstExistingSQLServer2014Context())
            {
                //recordCount = (from c in db.Customers select c).Count();
                recordCount = db.Customers.Count();
            }
            return recordCount;
        }

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

        private bool Insert(string fName, string lName, string tech)
        {
            bool isInserted = false;
            try
            {
                using (var db = new EF6CodeFirstExistingSQLServer2014Context())
                {
                    var customerRecord = new Customer { FirstName = fName, LastName = lName, Technology = tech };
                    db.Customers.Add(customerRecord);
                    db.SaveChanges();
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
                using (var db = new EF6CodeFirstExistingSQLServer2014Context())
                {

                    Customer customerRecord = (from c in db.Customers
                                               where c.CustomerId == custId
                                               select c).First();
                    customerRecord.FirstName = fName;
                    customerRecord.LastName = lName;
                    customerRecord.Technology = tech;
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
                using (var db = new EF6CodeFirstExistingSQLServer2014Context())
                {
                    var customerRecord = new Customer { CustomerId = custId };
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
                using (var db = new EF6CodeFirstExistingSQLServer2014Context())
                {
                    if (db.Customers.Count() > 0)
                    {
                        IEnumerable<Customer> customers = db.Customers;

                        if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                        {
                            //Convert.ToInt32 cannot be part of Lambda
                            int custId = Convert.ToInt32(textBox1.Text.Trim());

                            IEnumerable<Customer> customerList = db.Customers.Where(c => c.CustomerId.Equals(custId));
                            //IQueryable<Customer> customerList = db.Customers.Where(c => c.CustomerId.Equals(custId));
                            //var custList = customerList.ToList<Customer>();
                                              
                            var firstOrDefaultCustomer = db.Customers.Where(c => c.CustomerId.Equals(custId)).FirstOrDefault();
                            //var cust = db.Customers.Where(c => c.CustomerId.Equals(custId));

                            if (customerList.Count() > 0)
                            {
                                textBox1.Text = Convert.ToString(firstOrDefaultCustomer.CustomerId);
                                textBox2.Text = firstOrDefaultCustomer.FirstName;
                                textBox3.Text = firstOrDefaultCustomer.LastName;
                                textBox4.Text = firstOrDefaultCustomer.Technology;

                                //OrderBy is optional
                                var selectCustomerIds = customers.Select((r, i) => new { Row = r, Index = i })
                                                .Where(x => x.Row.CustomerId == custId)
                                                .OrderBy(x => x.Row.CustomerId);

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
                            IEnumerable<Customer> customerList = db.Customers.Where(c => c.FirstName.Equals(textBox2.Text.Trim()));
                            //IQueryable<Customer> customerList = db.Customers.Where(c => c.FirstName.Equals(textBox2.Text.Trim()));
                            //var custList = customerList.ToList<Customer>();

                            var firstOrDefaultCustomer = db.Customers.Where(c => c.FirstName.Equals(textBox2.Text.Trim())).FirstOrDefault();
                            //var cust = db.Customers.Where(c => c.FirstName.Equals(textBox2.Text.Trim()));
                            
                            //Just for note, not the solution                    
                            ////var w = db.Customers.Where(c => c.FirstName.Equals(textBox2.Text.Trim())).Select((c, index) => index);
                            ////var tw = customerList.TakeWhile(c => c.FirstName != textBox2.Text.Trim()).Count();
                            ////Predicate<Customer> p = firstOrDefaultCustomer;
                            ////var fi = customerList.ToList<Customer>().FindIndex()
                            //http://geekswithblogs.net/BlackRabbitCoder/archive/2011/01/06/c.net-ndash-finding-an-itemrsquos-index-in-ienumerablelttgt.aspx

                            if (customerList.Count() > 0)
                            {
                                textBox1.Text = Convert.ToString(firstOrDefaultCustomer.CustomerId);
                                textBox2.Text = firstOrDefaultCustomer.FirstName;
                                textBox3.Text = firstOrDefaultCustomer.LastName;
                                textBox4.Text = firstOrDefaultCustomer.Technology;

                                //OrderBy is optional
                                var selecFirstNames = customers.Select((r, i) => new { Row = r, Index = i })
                                               .Where(x => x.Row.FirstName == textBox2.Text.Trim())
                                               .OrderBy(x => x.Row.CustomerId);

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
                            IEnumerable<Customer> customerList = db.Customers.Where(c => c.LastName.Equals(textBox3.Text.Trim()));                            
                            var firstOrDefaultCustomer = db.Customers.Where(c => c.LastName.Equals(textBox3.Text.Trim())).FirstOrDefault();

                            if (customerList.Count() > 0)
                            {
                                textBox1.Text = Convert.ToString(firstOrDefaultCustomer.CustomerId);
                                textBox2.Text = firstOrDefaultCustomer.FirstName;
                                textBox3.Text = firstOrDefaultCustomer.LastName;
                                textBox4.Text = firstOrDefaultCustomer.Technology;

                                //OrderBy is optional
                                var selectLastNames = customers.Select((r, i) => new { Row = r, Index = i })
                                               .Where(x => x.Row.LastName == textBox3.Text.Trim())
                                               .OrderBy(x => x.Row.CustomerId);

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
                            IEnumerable<Customer> customerList = db.Customers.Where(c => c.Technology.Equals(textBox4.Text.Trim()));
                            var firstOrDefaultCustomer = db.Customers.Where(c => c.Technology.Equals(textBox4.Text.Trim())).FirstOrDefault();
 
                            if (customerList.Count() > 0)
                            {
                                textBox1.Text = Convert.ToString(firstOrDefaultCustomer.CustomerId);
                                textBox2.Text = firstOrDefaultCustomer.FirstName;
                                textBox3.Text = firstOrDefaultCustomer.LastName;
                                textBox4.Text = firstOrDefaultCustomer.Technology;

                                //OrderBy is optional
                                var selectTechnologies = customers.Select((r, i) => new { Row = r, Index = i })
                                              .Where(x => x.Row.Technology== textBox4.Text.Trim())
                                              .OrderBy(x => x.Row.CustomerId);

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
