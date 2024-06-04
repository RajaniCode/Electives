using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void DrawShape()
    {
        System.Drawing.Bitmap BitMapObject = null;
        System.Drawing.Graphics g = null;
        BitMapObject = new Bitmap(300, 300);
        g = System.Drawing.Graphics.FromImage(BitMapObject);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        g.Clear(Color.Silver);

        if (DropDownList1.SelectedItem.Text == "Line")
        {
            CallDrawLine(g);
        }
        else if (DropDownList1.SelectedItem.Text == "Ellipse")
        {
            CallDrawEllipse(g);
        }
        else if (DropDownList1.SelectedItem.Text == "Rectangle")
        {
            CallDrawRectangle(g);
        }
        Response.ContentType = "image/jpeg";
        BitMapObject.Save(Response.OutputStream, ImageFormat.Jpeg);
        BitMapObject.Dispose();
        g.Dispose();
        Response.End();
    }
    private void CallDrawLine(System.Drawing.Graphics g)
    {
        Color cl = new Color();
        cl = ColorTranslator.FromHtml(DropDownList2.SelectedItem.Text);
        Pen RPen = new Pen(cl, 8F);
        Point p1 = new Point(95, 55);
        Point p2 = new Point(196, 55);
        Point[] joinPoints = { p1, p2 };
        g.DrawLines(RPen, joinPoints);
    }
    private void CallDrawRectangle(System.Drawing.Graphics g)
    {
        Pen RPen = new Pen(Color.Yellow, 15F);
        Rectangle rect = new Rectangle(95, 109, 100, 90);
        g.DrawRectangle(RPen, rect);
        Color cl = new Color();
        cl = ColorTranslator.FromHtml(DropDownList2.SelectedItem.Text);
        g.FillRectangle(new SolidBrush(cl), rect);
    }
    private void CallDrawEllipse(System.Drawing.Graphics g)
    {
        Pen RPen = new Pen(Color.Yellow, 15F);
        RectangleF rectF = new RectangleF(100F, 109F, 100F, 90F);
        g.DrawEllipse(RPen, rectF);
        Color cl = new Color();
        cl = ColorTranslator.FromHtml(DropDownList2.SelectedItem.Text);
        g.FillEllipse(new SolidBrush(cl), rectF);
    }

    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        DrawShape();
    }
}