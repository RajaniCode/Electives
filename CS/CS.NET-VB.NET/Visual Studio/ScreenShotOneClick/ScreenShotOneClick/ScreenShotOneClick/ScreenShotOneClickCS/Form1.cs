using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenShotOneClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void grabScreenShotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmpSS = null;
            Graphics gfxSS = null;

            try
            {
                bmpSS = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                       Screen.PrimaryScreen.Bounds.Height,
                       PixelFormat.Format32bppArgb);

                gfxSS = Graphics.FromImage(bmpSS);

                gfxSS.CopyFromScreen(
                    Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0,
                    0,
                    Screen.PrimaryScreen.Bounds.Size,
                    CopyPixelOperation.SourceCopy);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "JPeg Image|*.jpg";
                saveDialog.Title = "Save Image as";
                saveDialog.ShowDialog();
                if (saveDialog.FileName != string.Empty)
                    bmpSS.Save(saveDialog.FileName, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }
    }
}
