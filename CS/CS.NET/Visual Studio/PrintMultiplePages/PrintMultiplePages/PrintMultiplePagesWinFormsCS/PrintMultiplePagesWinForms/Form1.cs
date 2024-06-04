using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrintMultiplePagesWinForms
{
    public partial class Form1 : Form
    {
        PrintDocument pd = new PrintDocument();      
        string strPrint;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Displays the document name in the print status or queue
            pd.DocumentName = txtFileNm.Text;
            // Associate PrintPage method with its event handler
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            // Open the document
            using (FileStream fs = new FileStream(pd.DocumentName, FileMode.Open))
            // Read the contents of the document in a stream reader object
            using (StreamReader sr = new StreamReader(fs))
            {
                strPrint = sr.ReadToEnd();
            }
            // Calling this method invokes the PrintPage event
            pd.Print();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileNm.Text = openFileDialog1.FileName;
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charCount = 0;
            int lineCount = 0;

            // Measure the specified string 'strPrint'
            // Calculate characters per line 'charCount'
            // Calcuate lines per page that will fit within 
            // the bounds of the page 'lineCount'
            e.Graphics.MeasureString(strPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charCount, out lineCount);

            // Determine the page bound and draw the string accordingly
            e.Graphics.DrawString(strPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Now remove that part of the string that has been printed.
            strPrint = strPrint.Substring(charCount);

            // Check if any more pages left for printing
            if (strPrint.Length > 0)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
    }
}