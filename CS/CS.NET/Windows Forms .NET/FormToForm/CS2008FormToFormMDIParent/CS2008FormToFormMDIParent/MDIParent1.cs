using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2008FormToFormMDIParent
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        FormA formA;
        FormB formB;
        FormC formC;
        
        void formA_ButtonClicked(object sender, MyEventArgs e)
        {
            this.formB.UpdateUI_TextBox1(e);
            return;
        }

        void formB_ButtonClicked(object sender, MyEventArgs e)
        {
            this.formC.UpdateUI_TextBox1(e);
            return;
        }

        void formC_ButtonClicked(object sender, MyEventArgs e)
        {
            this.formA.UpdateUI_TextBox1(e);
            return;
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            formA = new FormA();
            formB = new FormB();
            formC = new FormC();
            //
            formA.Text = "FormA";
            formB.Text = "FormB";
            formC.Text = "FormC";
            //
            formA.MdiParent = this;
            formB.MdiParent = this;
            formC.MdiParent = this;
            //
            formA.ButtonClicked += new Form1.MyEventHandler(formA_ButtonClicked);
            formB.ButtonClicked += new Form1.MyEventHandler(formB_ButtonClicked);
            formC.ButtonClicked += new Form1.MyEventHandler(formC_ButtonClicked);
            //
            formC.Show();           
            formB.Show();
            formA.Show();
            //
            this.Shown += new EventHandler(MDIParent1_Shown);
        }

        private void MDIParent1_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}
