<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void Page_PreRender()
    {
        lblFirstname.Text = Profile.FirstName;
        lblLastName.Text = Profile.LastName;

        Profile.NumberOfVisits++;
        lblNumberOfVisits.Text = Profile.NumberOfVisits.ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Profile.FirstName = txtNewFirstName.Text;
        Profile.LastName = txtNewLastName.Text;
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Show Profile</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    First Name:
    <asp:Label
        id="lblFirstname"
        Runat="server" />
    <br /><br />
    Last Name:
    <asp:Label
        id="lblLastName"
        Runat="server" />
    <br /><br />
    Number of Visits:
    <asp:Label
        id="lblNumberOfVisits"
        Runat="server" />
        
    <hr />
    
    <asp:Label
        id="lblNewFirstName"
        Text="New First Name:"
        AssociatedControlID="txtNewFirstName"
        Runat="server" />
    <asp:TextBox
        id="txtNewFirstName"
        Runat="server" />
    <br /><br />
    <asp:Label
        id="lblNewLastName"
        Text="New Last Name:"
        AssociatedControlID="txtNewLastName"
        Runat="server" />
    <asp:TextBox
        id="txtNewLastName"
        Runat="server" />
    <br /><br />    
    <asp:Button
        id="btnUpdate"
        Text="Update Profile"
        OnClick="btnUpdate_Click" 
        Runat="server" />
    
    </div>
    </form>
</body>
</html>
