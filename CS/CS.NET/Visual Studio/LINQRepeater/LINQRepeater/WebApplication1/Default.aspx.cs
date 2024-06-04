using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<People> people = new List<People>();
                people.Add(new People()
                {
                    GivenName = "Malcolm",
                    Surname = "Sheridan",
                    Age = 32,
                    Height = 185,
                    ShoeSize = 13,
                    UniqueId = 1
                });
                people.Add(new People()
                {
                    GivenName = "Suprotim",
                    Surname = "Argawal",
                    Age = 28,
                    Height = 175,
                    ShoeSize = 10,
                    UniqueId = 2
                });
                rptPeople.DataSource = people;
                rptPeople.DataBind();
            }            
        }

        protected void rptPeople_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }
            RadioButton rdo = e.Item.FindControl("rdoSelected") as RadioButton;
            string script = "SetUniqueRadioButton('rptPeople.*Person',this)";
            rdo.Attributes.Add("onclick", script);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var query = (from p in rptPeople.Items.OfType<RepeaterItem>()
                        let o = p.Controls[1] as RadioButton
                        let hid = p.Controls[3] as HiddenField
                        where o.Checked
                        select new
                        {
                            GivenName = o.Text,
                            UniqueId = hid.Value
                        }).Single();
            Response.Write(query.UniqueId);
        }       
    }
}
