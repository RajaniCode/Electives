<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ICollection CreateDataSource( )
  {
    System.Data.DataTable dt = new System.Data.DataTable();
    System.Data.DataRow dr;
    dt.Columns.Add(new System.Data.DataColumn("A", typeof(System.String)));
    dt.Columns.Add(new System.Data.DataColumn("B", typeof(System.String)));
    dt.Columns.Add(new System.Data.DataColumn("C", typeof(System.Decimal)));
    dt.Columns.Add(new System.Data.DataColumn("D", typeof(System.Decimal)));
    dt.Columns.Add(new System.Data.DataColumn("E", typeof(System.Decimal)));
    dt.Columns.Add(new System.Data.DataColumn("F", typeof(System.Decimal)));

    for (int i = 0; i < 50; i++)
    {
      System.Random rd = new System.Random(Environment.TickCount * i); ;
      dr = dt.NewRow();
      dr[0] = "A" + i.ToString();
      dr[1] = "B" + i.ToString();
      dr[2] = System.Math.Round(rd.NextDouble() * 100, 2);
      dr[3] = System.Math.Round(rd.NextDouble() * 100, 2);
      dr[4] = System.Math.Round(rd.NextDouble() * 100, 2);
      dr[5] = System.Math.Round(rd.NextDouble() * 100, 2);
      dt.Rows.Add(dr);
    }
    System.Data.DataView dv = new System.Data.DataView(dt);
    return dv;
  }

  protected void Page_Load( object sender, EventArgs e )
  {
    if (!IsPostBack)
    {
      GridView1.Attributes.Add("style", "table-layout:fixed");
      GridView1.DataSource = CreateDataSource();
      GridView1.DataBind();
    }
  }
  
</script>

<script type="text/javascript">
function s()
{
 var t = document.getElementById("<%=GridView1.ClientID%>");
 var t2 = t.cloneNode(true)
 for(i = t2.rows.length -1;i > 0;i--)
 t2.deleteRow(i)  
 t.deleteRow(0)  
 a.appendChild(t2) 
}
window.onload = s
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title>Scrollable GridView</title>
</head>
<body>
  <form id="Form1" runat="server">
    <table>
      <tr>
        <td>
          <div id="a">
          </div>
          <div style="overflow-y: scroll; height: 200px">
            <asp:GridView ID="GridView1" runat="server" Font-Size="12px" BackColor="#FFFFFF"
              GridLines="Both" CellPadding="4" Width="560">
              <HeaderStyle BackColor="#EDEDED" Height="26px" />
            </asp:GridView>
          </div>
        </td>
      </tr>
    </table>
  </form>
</body>
</html>

