using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AddressBookBO;
namespace WindowsAddressBook
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmAddress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dgAddresses;
		
		// create addressbook object
		private AddressBook objAddressBook = new AddressBook();
		// create addressbook collection object
		private AddressBooks objAddressBooks = new AddressBooks();

		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label lblPhoneNumber;
		private System.Windows.Forms.TextBox txtPhoneNumber;
		private System.Windows.Forms.Button cmdUpdate;
		private System.Windows.Forms.Button cmdCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.dgAddresses = new System.Windows.Forms.DataGrid();
			this.lblAddress = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.lblPhoneNumber = new System.Windows.Forms.Label();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgAddresses)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(72, 8);
			this.txtName.Name = "txtName";
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// dgAddresses
			// 
			this.dgAddresses.DataMember = "";
			this.dgAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAddresses.Location = new System.Drawing.Point(16, 104);
			this.dgAddresses.Name = "dgAddresses";
			this.dgAddresses.Size = new System.Drawing.Size(560, 240);
			this.dgAddresses.TabIndex = 8;
			this.dgAddresses.Click += new System.EventHandler(this.loadAddressinUI);
			
			// 
			// lblAddress
			// 
			this.lblAddress.Location = new System.Drawing.Point(184, 8);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(48, 16);
			this.lblAddress.TabIndex = 2;
			this.lblAddress.Text = "Address";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(240, 8);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(352, 20);
			this.txtAddress.TabIndex = 3;
			this.txtAddress.Text = "";
			// 
			// lblPhoneNumber
			// 
			this.lblPhoneNumber.Location = new System.Drawing.Point(8, 40);
			this.lblPhoneNumber.Name = "lblPhoneNumber";
			this.lblPhoneNumber.Size = new System.Drawing.Size(80, 24);
			this.lblPhoneNumber.TabIndex = 4;
			this.lblPhoneNumber.Text = "PhoneNumber";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(104, 40);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.TabIndex = 5;
			this.txtPhoneNumber.Text = "";
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.Location = new System.Drawing.Point(24, 72);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 6;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(112, 72);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmAddress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 357);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdUpdate);
			this.Controls.Add(this.txtPhoneNumber);
			this.Controls.Add(this.lblPhoneNumber);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.lblAddress);
			this.Controls.Add(this.dgAddresses);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Name = "frmAddress";
			this.Text = "Addressbook";
			this.Load += new System.EventHandler(this.frmAddress_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgAddresses)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmAddress());
		}

		private void frmAddress_Load(object sender, System.EventArgs e)
		{
			loadAddress();
			
			
		}
		/// <summary>
		/// This method loads all the addresses in the address collection
		/// and binds it to the grid
		/// </summary>
		private void loadAddress()
		{
			try
			{
				objAddressBooks.loadAddress();
				dgAddresses.DataSource = null;
				dgAddresses.DataSource = objAddressBooks;
				dgAddresses.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		
		/// <summary>
		/// This method will load the address object
		/// in the UI
		/// </summary>
		public void loadAddressinUI(int intAddressId)
		{
			AddressBooks objAddressBooks = new AddressBooks();
			objAddressBooks.loadAddress(intAddressId);
			if (objAddressBooks.Count > 0)
			{
				objAddressBook = objAddressBooks[0];
			}
			
			
			txtName.Text = objAddressBook.Name;
			txtAddress.Text = objAddressBook.Address;
			txtPhoneNumber.Text = objAddressBook.PhoneNumber;

		}
		/// <summary>
		/// This command button cancels and clears the UI and loads
		/// the flexgrid again
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			try
			{
				objAddressBook = new AddressBook();
				clearUI();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		
		
		
		/// <summary>
		/// This method adds to the database. creates a new object of the address class
		/// and clears the textboxes and loads the datagrid with new values
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				setValueFromUI();
				objAddressBook.addAddress();
				objAddressBook = new AddressBook();
				clearUI();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		/// <summary>
		/// Sets the value from the UI to the Address object
		/// </summary>
		private void setValueFromUI()
		{
			objAddressBook.Name = txtName.Text;
			objAddressBook.PhoneNumber = txtPhoneNumber.Text;
			objAddressBook.Address = txtAddress.Text;
		}
		/// <summary>
		/// ClearUI clears all the textboxes
		/// </summary>
		private void clearUI()
		{
			try
			{
				txtName.Text = "";
				txtPhoneNumber.Text = "";
				txtAddress.Text = "";
				loadAddress();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		

		/// <summary>
		/// This method load calls the loadAddressinUI and passes the
		/// selected datagrid selected value to load the selected address
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loadAddressinUI(object sender, System.EventArgs e)
		{
			
			try
			{
				// if there is nothing selected just quit from the method
				if (dgAddresses.CurrentRowIndex == -1)
				{
					return;
				}
				loadAddressinUI((int)dgAddresses[dgAddresses.CurrentRowIndex,0]);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		

		


		
	}
}
