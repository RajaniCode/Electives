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

        Bitmap bmp = null;
        Graphics graphics = null;

        private void grabScreenShotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                       Screen.PrimaryScreen.Bounds.Height,
                       PixelFormat.Format32bppArgb);

                graphics = Graphics.FromImage(bmp);

                graphics.CopyFromScreen(
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
                    bmp.Save(saveDialog.FileName, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                graphics.Dispose();
                bmp.Dispose();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void selectAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(this.Size.Width,
                                       this.Size.Height,
                                       PixelFormat.Format32bppArgb);
                graphics = Graphics.FromImage(bmp);
                

                graphics.CopyFromScreen(this.Location.X,
                                            this.Location.Y,
                                            0,
                                            0,
                                            Screen.PrimaryScreen.Bounds.Size,
                                            CopyPixelOperation.SourceCopy);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "JPeg Image|*.jpg";
                saveDialog.Title = "Save Image as";
                saveDialog.ShowDialog();
                if (saveDialog.FileName != string.Empty)
                    bmp.Save(saveDialog.FileName, ImageFormat.Jpeg);
                graphics.Dispose();
                bmp.Dispose();
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                

            }
            catch
            {

            }
            finally
            {
                graphics.Dispose();
                bmp.Dispose();
            }

        }
    }
}
