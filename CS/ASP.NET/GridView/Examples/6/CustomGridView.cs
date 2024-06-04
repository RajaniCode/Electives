using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace CustomControls
{
    [ToolboxData(@"<{0}:CustomGridView runat=""server"" \>")]
    public class CustomGridView : GridView
    {
        Color _MouseOverColor = Color.Navy;
        Color _TextOverColor = Color.White;
        Color _SelectedRowColor = Color.Red;
        Color _SelectedRowTextColor = Color.White;

        #region Properties

        public Color MouseOverColor
        {
            get { return _MouseOverColor; }
            set { _MouseOverColor = value; }
        }

        public Color TextOverColor
        {
            get { return _TextOverColor; }
            set { _TextOverColor = value; }
        }

        public Color SelectedRowColor
        {
            get { return _SelectedRowColor; }
            set { _SelectedRowColor = value; }
        }

        public Color SelectedRowTextColor
        {
            get { return _SelectedRowTextColor; }
            set { _SelectedRowTextColor = value; }
        }

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string resourceName = "CustomControls.GridViewScript.js";

            ClientScriptManager cs = this.Page.ClientScript;
            cs.RegisterClientScriptResource(typeof(CustomControls.CustomGridView), resourceName);
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
            GridViewRow row = e.Row;
            Color bgColor = Color.Empty;
            Color color = Color.Empty;

            if (row.RowIndex % 2 == 0)
            {
                bgColor = (this.RowStyle.BackColor == Color.Empty) ? Color.White : this.RowStyle.BackColor;
                color = (this.RowStyle.ForeColor == Color.Empty) ? Color.Black : this.RowStyle.ForeColor;
            }
            else
            {
                bgColor = (this.AlternatingRowStyle.BackColor == Color.Empty) ? Color.White : this.AlternatingRowStyle.BackColor;
                color = (this.AlternatingRowStyle.ForeColor == Color.Empty) ? Color.Black : this.AlternatingRowStyle.ForeColor;
            }
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes.Add("onmouseover", String.Format("MouseEnter(this,'{0}','{1}')",
                    ColorTranslator.ToHtml(this.MouseOverColor),
                    ColorTranslator.ToHtml(this.TextOverColor)));
                row.Attributes.Add("onmouseout", "MouseLeave(this)");
                row.Attributes.Add("onmousedown", String.Format("MouseDown(this,'{0}','{1}')",
                    ColorTranslator.ToHtml(this.SelectedRowColor),
                    ColorTranslator.ToHtml(this.SelectedRowTextColor)));
                row.Attributes.Add("OriginalColor", ColorTranslator.ToHtml(bgColor));
                row.Attributes.Add("OriginalTextColor", ColorTranslator.ToHtml(color));
            }
        }
    }
}
