using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        private int RowCount
        {
            get
            {
                return (int)ViewState["RowCount"];
            }
            set
            {
                ViewState["RowCount"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FetchData(10, 0);     
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl();
            }                       
        }

        private void FetchData(int take, int pageSize)
        {           
            using (NorthwindDataContext dc = new NorthwindDataContext())
            {
                var query = from p in dc.Customers
                                .OrderBy(o => o.ContactName)
                                .Take(take)
                                .Skip(pageSize)
                            select new
                            {
                                ID = p.CustomerID,
                                Name = p.ContactName,
                                Count = dc.Customers.Count()
                            };
                
                PagedDataSource page = new PagedDataSource();
                page.AllowCustomPaging = true;
                page.AllowPaging = true;
                page.DataSource = query;
                page.PageSize = 10;
                Repeater1.DataSource = page;
                Repeater1.DataBind();

                if (!IsPostBack)
                {
                    RowCount = query.First().Count;
                    CreatePagingControl();
                }
            }
        }

        private void CreatePagingControl()
        {   
            for (int i = 0; i < (RowCount / 10) + 1; i++)
            {
                LinkButton lnk = new LinkButton();                
                lnk.Click += new EventHandler(lbl_Click);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                plcPaging.Controls.Add(lnk);
                Label spacer = new Label();
                spacer.Text = "&nbsp;";
                plcPaging.Controls.Add(spacer);
            }
        }
       
        void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            int take = currentPage * 10;
            int skip = currentPage == 1 ? 0 : take - 10;  
            FetchData(take, skip);
        }
    }
}
