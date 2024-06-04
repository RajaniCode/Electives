using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        private int Count { get; set; }  
        protected void Page_Load(object sender, EventArgs e)
        {            
            GetControl(this);
            FindDropDownList(this);
            FindDropDownListAll(this);
        }

        private void GetControl(Control parent)
        {   
            Count += (from p in parent.Controls.Cast<Control>()
                      let txt = p as TextBox 
                      where (txt != null && txt.Enabled)
                      select p).Count();           

            foreach (Control item in parent.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    GetControl(item);                   
                }                
            }
        }

        private void FindDropDownList(Control parent)
        {
            Count += (from p in parent.Controls.Cast<Control>()
                      let txt = p as DropDownList
                      where (txt != null && txt.Items.Cast<ListItem>().Any(o => o.Text.Length > 10))
                      select p).Count();

            foreach (Control item in parent.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    FindDropDownList(item);
                }
            }
        }

        private static void FindDropDownListAll(Control parent)
        {
            var query = (from p in parent.Controls.Cast<Control>()
                         let txt = p as DropDownList
                         where (txt != null && txt.Items.Cast<ListItem>().Any(o => o.Text.Length > 10))
                         select new
                         {
                             Name = p.ClientID,
                             Items = txt.Items.Cast<ListItem>().Where(o => o.Text.Length > 10).ToList()
                         });
            
            foreach (var item in query)
            {
                List<ListItem> txt = item.Items;
            }
        }   
    }
}
