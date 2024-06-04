<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
    DataTable GetData()
    {
        // This method creates a DataTable with four rows.  Each row has the
        // following schema:
        //   PictureID      int
        //   PictureURL     string
        //   Title          string
        //   DateAdded      datetime

        DataTable dt = new DataTable();

        // define the table's schema
        dt.Columns.Add(new DataColumn("PictureID", typeof(int)));
        dt.Columns.Add(new DataColumn("PictureURL", typeof(string)));
        dt.Columns.Add(new DataColumn("Title", typeof(string)));
        dt.Columns.Add(new DataColumn("DateAdded", typeof(DateTime)));

        // Create the four records
        DataRow dr = dt.NewRow();
        dr["PictureID"] = 1;
        dr["PictureURL"] = ResolveUrl("~/DisplayingImages/Images/Blue hills.jpg");
        dr["Title"] = "Blue Hills";
        dr["DateAdded"] = new DateTime(2005, 1, 15);
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["PictureID"] = 2;
        dr["PictureURL"] = ResolveUrl("~/DisplayingImages/Images/Sunset.jpg");
        dr["Title"] = "Sunset";
        dr["DateAdded"] = new DateTime(2005, 1, 21);
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["PictureID"] = 3;
        dr["PictureURL"] = ResolveUrl("~/DisplayingImages/Images/Water lilies.jpg");
        dr["Title"] = "Water Lilies";
        dr["DateAdded"] = new DateTime(2005, 2, 1);
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["PictureID"] = 4;
        dr["PictureURL"] = ResolveUrl("~/DisplayingImages/Images/Winter.jpg");
        dr["Title"] = "Winter";
        dr["DateAdded"] = new DateTime(2005, 2, 18);
        dt.Rows.Add(dr);

        return dt;
    }

    void Page_Load(object sender, EventArgs e)
    {
        Page.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" Runat="server" DataSource='<%# GetData() %>' AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" CellPadding="3" BorderStyle="None" BorderColor="#CCCCCC" Font-Names="Arial">
            <FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#006699"></HeaderStyle>
            <Columns>
                <asp:BoundField HeaderText="Picutre ID" DataField="PictureID">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Title" DataField="Title"></asp:BoundField>
                <asp:BoundField HeaderText="Date Added" DataField="DateAdded" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="PictureURL"></asp:ImageField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#669999"></SelectedRowStyle>
            <RowStyle ForeColor="#000066"></RowStyle>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
