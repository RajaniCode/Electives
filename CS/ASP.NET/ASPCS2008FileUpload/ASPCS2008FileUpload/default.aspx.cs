using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace FileUpload
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		private const string MDBFILE = "FileUpload.mdb";

		protected Label lblFile;
		protected HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Button cmdSend;
		protected System.Web.UI.WebControls.Image imgFile;
		protected System.Web.UI.WebControls.Image imgDB;
		protected System.Web.UI.WebControls.Label lblText1;
		protected System.Web.UI.WebControls.Label lblText2;
	
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}

		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Check if FileID was passed to this page as a parameter
			if( Request.QueryString["FileID"] != null )
			{
				// Get the file out of database and return it to requesting client
				ShowTheFile(Convert.ToInt32(Request.QueryString["FileID"]));
			}
			
		}

		// Processes click on our cmdSend button
		private void cmdSend_Click(object sender, System.EventArgs e)
		{
			// Check to see if file was uploaded
			if( filMyFile.PostedFile != null )
			{
				// Get a reference to PostedFile object
				HttpPostedFile myFile = filMyFile.PostedFile;

				// Get size of uploaded file
				int nFileLen = myFile.ContentLength; 

				// make sure the size of the file is > 0
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					string strFilename = Path.GetFileName(myFile.FileName);

					// Write data into a file
					WriteToFile(Server.MapPath(strFilename), ref myData);

					// Store it in database
					int nFileID = WriteToDB(strFilename, myFile.ContentType, ref myData);

					// Set label's text
					lblInfo.Text = 
						"Filename: " + strFilename + "<br>" + 
						"Size: " + nFileLen.ToString() + "<p>";
						

					// Set URL of the the object to point to the file we've just saved
					imgFile.ImageUrl = strFilename;
					imgFile.ToolTip = "This file was stored to as file.";
					lblText1.Text = imgFile.ImageUrl;

					// Set URL of the the object to point to the this script with ID of the file
					// that will retreive file out the database
					imgDB.ImageUrl = GetMyName() + "?FileID=" + nFileID.ToString();
					imgDB.ToolTip = "This file was stored in database.";
					lblText2.Text = imgDB.ImageUrl;
					
					// show the images and text
					imgFile.Visible = true;
					imgDB.Visible = true;
					lblText1.Visible = true;
					lblText2.Visible = true;
				}
			}
		}

		// Writes file to current folder
		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			// Create a file
			FileStream newFile = new FileStream(strPath, FileMode.Create);

			// Write data to the file
			newFile.Write(Buffer, 0, Buffer.Length);

			// Close file
			newFile.Close();
		}

		// Generates database connection string
		private string GetConnectionString()
		{
			return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(MDBFILE) + ";";
		}

		// Writes file to the database
		private int WriteToDB(string strName, string strType, ref byte[] Buffer)
		{
			int nFileID = 0;

			// Create connection
			OleDbConnection dbConn = new OleDbConnection(GetConnectionString());

			// Create Adapter
			OleDbDataAdapter dbAdapt = new OleDbDataAdapter("SELECT * FROM tblFile", dbConn);
			
			// We need this to get an ID back from the database
			dbAdapt.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			
			// Create and initialize CommandBuilder
			OleDbCommandBuilder dbCB = new OleDbCommandBuilder(dbAdapt);

			// Open Connection
			dbConn.Open();
					
			// New DataSet
			DataSet dbSet = new DataSet();
					
			// Populate DataSet with data
			dbAdapt.Fill(dbSet, "tblFile");

			// Get reference to our table
			DataTable dbTable = dbSet.Tables["tblFile"];

			// Create new row
			DataRow dbRow = dbTable.NewRow();

			// Store data in the row
			dbRow["FileName"] = strName;
			dbRow["FileSize"] = Buffer.Length;
			dbRow["ContentType"] = strType;
			dbRow["FileData"] = Buffer;

			// Add row back to table
			dbTable.Rows.Add(dbRow);

			// Update data source
			dbAdapt.Update(dbSet, "tblFile");

			// Get newFileID
			if( !dbRow.IsNull("FileID") )
				nFileID = (int)dbRow["FileID"];
			
			// Close connection
			dbConn.Close();

			// Return FileID
			return nFileID;
		}

		// Read file out of the database and returns it to client
		private void ShowTheFile(int FileID)
		{
			// Define SQL select statement
			string SQL = "SELECT FileSize, FileData, ContentType FROM tblFile WHERE FileID = " 
						+ FileID.ToString();

			// Create Connection object
			OleDbConnection dbConn = new OleDbConnection(GetConnectionString());

			// Create Command Object
			OleDbCommand dbComm = new OleDbCommand(SQL, dbConn);

			// Open Connection
			dbConn.Open();

			// Execute command and receive DataReader
			OleDbDataReader dbRead = dbComm.ExecuteReader();

			// Read row
			dbRead.Read();

			// Clear Response buffer
			Response.Clear();

			// Set ContentType to the ContentType of our file
			Response.ContentType = (string)dbRead["ContentType"];

			// Write data out of database into Output Stream
			Response.OutputStream.Write((byte[])dbRead["FileData"], 0, (int)dbRead["FileSize"]);

			// Close database connection
			dbConn.Close();

			// End the page
			Response.End();
		}

		// Reads the name of current web page
		private string GetMyName()
		{
			// Get the script name
			string strScript = Request.ServerVariables["SCRIPT_NAME"];

			// Get position of last slash
			int nPos = strScript.LastIndexOf("/");

			// Get everything after slash
			if( nPos > -1 )
				strScript = strScript.Substring(nPos + 1);

			return strScript;
		}
	}
}
