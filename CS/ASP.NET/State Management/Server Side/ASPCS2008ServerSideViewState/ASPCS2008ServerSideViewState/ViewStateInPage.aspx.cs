using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ASPCS2008ServerSideViewState
{
    [PageStateAdapter.PageViewStateStorage(PageStateAdapter.StateStorageTypes.InPage)]
    public partial class ViewStateInPage : System.Web.UI.Page
    {
        public List<GVDataObject> GVData
        {
            get
            {
                if (ViewState["GVDATAOBJECT"] == null) ViewState["GVDATAOBJECT"] = new List<GVDataObject>();
                return ViewState["GVDATAOBJECT"] as List<GVDataObject>;
            }
            set { ViewState["GVDATAOBJECT"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 0; i < 3; i++)
                {
                    GVData.Add(new GVDataObject
                    {
                        Field1 = DateTime.Now.ToLongTimeString(),
                        Field2 = DateTime.Now.Ticks.ToString(),
                        Field3 = Path.GetRandomFileName()
                    });
                }
                BindGridView();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TextBox1.Text = time.ToLocalTime().ToString();
            GVData.Add(new GVDataObject
            {
                Field1 = time.ToLongTimeString(),
                Field2 = time.Ticks.ToString(),
                Field3 = Path.GetRandomFileName()
            });
            BindGridView();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            GVDataObject obj = e.Row.DataItem as GVDataObject;

            ((Literal)e.Row.FindControl("Field1")).Text = obj.Field1;
            ((Literal)e.Row.FindControl("Field2")).Text = obj.Field2;
            ((Literal)e.Row.FindControl("Field3")).Text = obj.Field3;
        }

        private void BindGridView()
        {
            GridView1.DataSource = GVData;
            GridView1.DataBind();
        }
    }
}
