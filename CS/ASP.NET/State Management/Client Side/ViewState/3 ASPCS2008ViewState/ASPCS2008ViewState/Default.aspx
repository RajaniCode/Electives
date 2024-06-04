<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ViewState._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  // Sample ArrayList for the page.
  ArrayList PageArrayList;

  ArrayList CreateArray()
  {
    // Create a sample ArrayList.
    ArrayList result = new ArrayList(4);
    result.Add("item 1");
    result.Add("item 2");
    result.Add("item 3");
    result.Add("item 4");
    return result;
  }

  void Page_Load(object sender, EventArgs e)
  {
    if (ViewState["arrayListInViewState"] != null)
    {
      PageArrayList = (ArrayList)ViewState["arrayListInViewState"];
    }
    else
    {
      // ArrayList isn't in view state, so it must be created and populated.
      PageArrayList = CreateArray();
    }
    // Code that uses PageArrayList.
  }
    
  void Page_PreRender(object sender, EventArgs e)
  {
    // Save PageArrayList before the page is rendered.
    ViewState.Add("arrayListInViewState", PageArrayList);
  }

  void Button1_Click(object sender, EventArgs e)
  {
      ArrayList arrayList = new ArrayList();
      arrayList = (ArrayList)ViewState["arrayListInViewState"];

      this.GridView1.DataSource = arrayList;
      this.GridView1.DataBind();

  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>View state sample</title>
</head>
<body>
    <form id="form1" runat="server">    
    
    <div>
     <asp:GridView ID="GridView1" runat="server">
     </asp:GridView>
     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="ViewState" />
    </div>   

    </form>
</body>
</html>
