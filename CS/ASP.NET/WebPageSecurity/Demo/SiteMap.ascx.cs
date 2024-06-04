namespace SampleSecurity
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.IO;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for SiteMap.
	/// </summary>
	public partial class SiteMap : System.Web.UI.UserControl
	{
		protected string applicationRoot;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				// Get the application's root virtual path (with a trailing "/")
				applicationRoot = Request.ApplicationPath;
				if (applicationRoot != "/")
					applicationRoot += "/";

				// Get a list of the files and directories in this site
				DirectoryInfo RootDir = new DirectoryInfo(Server.MapPath(Request.ApplicationPath));
				OutputDirectoryContents(RootDir, 0, "/");
			}
		}

		// Outputs the contents of the specified directory into tblSiteMap
		private void OutputDirectoryContents(DirectoryInfo directory, int indent, string currentPath)
		{
			// Get the directories and files in this directory
			DirectoryInfo[] SubDirectories = directory.GetDirectories();
			FileInfo[] Files = directory.GetFiles("*.aspx");

			if (SubDirectories.Length > 0 || Files.Length > 0)
			{
				// Output this directory's name
				if (currentPath == "/")
				{
					// Use "Application Root" as the text to output
					AddTableRowWithIndent(tblSiteMap, indent, string.Empty, "Application Root");

					// Set the root path appropriately (virtuals differ from sites)
					if (Request.ApplicationPath != "/")
						currentPath = Request.ApplicationPath;
				}
				else
				{
					// Use the directory name
					AddTableRowWithIndent(tblSiteMap, indent, string.Empty, directory.Name);

					// Append the directory to the currentPath variable
					currentPath += "/" + directory.Name;
				}

				// Increment the indent
				indent++;

				// Files
				foreach (FileInfo File in Files)
				{
					// Output this file's name
					AddTableRowWithIndent(tblSiteMap, indent, currentPath, File.Name);
				}

				// Sub-directories
				foreach (DirectoryInfo SubDirectory in SubDirectories)
				{
					OutputDirectoryContents(SubDirectory, indent, currentPath);
				}
			}
		}

		// Adds a TableRow to the specified table with the given text and indented as requested
		private void AddTableRowWithIndent(Table table, int indent, string filePath, string text)
		{
			// Initialize
			TableRow Row;
			TableCell Cell;
			
			// Create the new row
			Row = new TableRow();

			// Create a cell for the indent, if needed
			for (int i = 1; i <= indent; i++)
			{
				Cell = new TableCell();
				Cell.Text = "&nbsp;";
				Row.Cells.Add(Cell);
			}
			
			// Create a cell for the text
			Cell = new TableCell();
			Cell.ColumnSpan = 20 - indent;

			// Is this a file?
			if (filePath.Length > 0)
			{
				string ImageName = string.Empty;
				string ImageAlt = string.Empty;

				// Determine if this is the file currently requested
				// Set the CSS class and image info
				if (Request.FilePath.ToLower() == string.Concat(filePath, "/", text).ToLower())
				{
					Cell.CssClass = "CurrentFile";

					// Check if the current request is secure
					if (Request.IsSecureConnection)
					{
						ImageName = "Secure.gif";
						ImageAlt = "Secure Connection";
					}
					else
					{
						ImageName = "Unsecure.gif";
						ImageAlt = "Unsecure Connection";
					}
				}
				else
				{
					Cell.CssClass = "File";
				}

				// Create an anchor to the file
				Cell.Text += string.Format("<a href=\"{0}/{1}\">{1}</a>", filePath, text);

				// Check for an image
				if (ImageName.Length > 0)
					Cell.Text += string.Format("<img src=\"{0}images/{1}\" alt=\"{2}\" border=\"0\" align=\"absmiddle\">", applicationRoot, ImageName, ImageAlt);
			}
			else
			{
				// Set the CSS class and text
				Cell.CssClass = "Folder";
				Cell.Text = text;
			}
			
			// Add the cell to the row
			Row.Cells.Add(Cell);

			// Add the row to the table
			table.Rows.Add(Row);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
