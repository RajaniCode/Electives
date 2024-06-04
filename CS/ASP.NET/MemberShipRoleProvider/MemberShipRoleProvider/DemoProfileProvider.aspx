<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DemoProfileProvider.aspx.cs" Inherits="DemoProfileProvider" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style type ="text/css">
#wizard
{
    background-color:#A4C0E8;
    border:1px solid Grey;
    color:Black;
    width:100%;
}
.DivTitle
{
    width:250px;
    border-style:outset;    
    background-color:Gray;
}
</style>

<script type ="text/javascript">
// stores the div id in an array.
 var divlist = ["SignUp","BasicInfo","ProfessionalProfile","MyProfile"];
 //Declare Variables
 var i=0;var  j; var btnprevious; var btnnext;var btnfinish;
 var txtusername,txtemailid,txtname,txtdateofbirth,txtplace,txtlanguages,txtaboutme,txtemployer,txtproject,txtdesignation,txtcollege;
 var lblusername,lblemailid,lblname,lbldateofbirth,lblplace,lbllanguages,lblaboutme,lblemployer,lblproject,lbldesignation,lblcollege;
 // function to display next wizard.
 function Next()
 {
            //increment the array index value. 
            HideAll();
            // loop through the array and display the current div.
            i++;
            btnprevious.style.display = '';
            document.getElementById(divlist[i]).style.display = '';
            if(divlist[i] == "MyProfile")
            {
              DisplayValues();
            }
            // check for the length of the array and hide the next button.
            if (i == divlist.length-1 )
            {
                 btnnext.style.display = 'none'
                 btnfinish.style.display = '';
            }
            return false;
 }
 // function to display previous wizard.
 function Previous()
 { 
             //decrement the array index value.
            btnfinish.style.display = 'none';
            btnnext.style.display = ''
            HideAll();
            i--;
           //loop through the array to display the current div and hide others.
            btnnext.Text = "Next";
            btnnext.style.display = '';
            document.getElementById(divlist[i]).style.display = '';
            if (i == 0)
            {
                btnprevious.style.display = 'none';
            } 
            return false;
 }
 function HideAll()
 {
    document.getElementById(divlist[0]).style.display = 'none';
    document.getElementById(divlist[1]).style.display = 'none';
    document.getElementById(divlist[2]).style.display = 'none';
    document.getElementById("MyProfile").style.display = 'none';
 }
 function InitializeContent()
 {
  HideAll();
  btnprevious = document.getElementById('<%= btnprevious.ClientID %>');
  btnnext = document.getElementById('<%= btnnext.ClientID %>');
  btnfinish = document.getElementById('<%=btnfinish.ClientID %>');
  btnprevious.style.display = 'none';
  btnfinish.style.display = 'none';
  document.getElementById(divlist[0]).style.display = '';
   txtusername = document.getElementById('<%=txtusername.ClientID %>');
  txtemailid = document.getElementById('<%=txtemailid.ClientID %>');
  txtname = document.getElementById('<%=txtfullname.ClientID %>');
  txtdateofbirth = document.getElementById('<%=txtdateofbirth.ClientID %>');
  txtplace = document.getElementById('<%=txtplace.ClientID %>');
  txtlanguages = document.getElementById('<%=txtlanguages.ClientID %>');
  txtaboutme = document.getElementById('<%=txtaboutme.ClientID %>');
  txtemployer = document.getElementById('<%=txtemployer.ClientID %>');
  txtproject = document.getElementById('<%=txtproject.ClientID %>');
  txtdesignation = document.getElementById('<%=txtdesignation.ClientID %>');
  txtcollege = document.getElementById('<%=txtcollege.ClientID %>');
  lblusername = document.getElementById('<%=lblusername.ClientID %>');
  lblemailid = document.getElementById('<%=lblemail.ClientID  %>');
  lblname = document.getElementById('<%=lblname.ClientID  %>');
  lbldateofbirth = document.getElementById('<%=lbldateofbirth.ClientID  %>');
  lblplace = document.getElementById('<%=lblplace.ClientID  %>');
  lbllanguages = document.getElementById('<%=lbllanguages.ClientID  %>');
  lblaboutme = document.getElementById('<%=lblaboutme.ClientID  %>');
  lblemployer = document.getElementById('<%=lblemployer.ClientID  %>');
  lblproject = document.getElementById('<%=lblproject.ClientID  %>');
  lbldesignation = document.getElementById('<%=lbldesignation.ClientID  %>');
  lblcollege = document.getElementById('<%=lblcollege.ClientID %>');
  lblaboutme.value ="";
  lblcollege.value ="";
  lbldateofbirth.value ="";
  lbldesignation.value ="";
  lblemailid.value ="";
  lblemployer.value ="";
  lbllanguages.value ="";
  lblname.value ="";
  lblplace.value ="";
  lblproject.value ="";
  lblusername.value="";
  
 }
 function Submit()
 {
 
  if(confirm("Are You Sure You Want Submit?") == false)
  {
   return false;
  }
  else
  { 
     HideAll();
     btnprevious.style.display = 'none';
     btnnext.style.display = 'none';
     btnfinish.style.display = 'none';
     document.getElementById("MyProfile").style.display = '';
     alert("Submitted Succesfully");
     
  }
 }
 function DisplayValues()
 {

   lblusername.innerHTML = txtusername.value;
   lblemailid.innerHTML = txtemailid.value;
   lblname.innerHTML = txtname.value;
   lblaboutme.innerHTML = txtaboutme.value;
   lblcollege.innerHTML = txtcollege.value;
   lbldateofbirth.innerHTML = txtdateofbirth.value;
   lbldesignation.innerHTML = txtdesignation.value;
   lblemployer.innerHTML = txtemployer.value;
   lbllanguages.innerHTML = txtlanguages.value;
   lblplace.innerHTML = txtplace.value;
   lbldateofbirth.innerHTML = txtdateofbirth.value;
   lblproject.innerHTML = txtproject.value;
   return false;
 }
 window.onload = InitializeContent;
</script>

<font style="font-weight:bolder;font-size:18px;">New User Registration Page:</font>
<div id ="wizard">
<div id ="SignUp" >
<h3 class ="DivTitle">Sign Up:</h3> 
<table>
<tr>
<td>UserName:</td>
<td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Password:</td>
<td><asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td>Confirm Password:</td>
<td><asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td>E-mail:</td>
<td><asp:TextBox ID="txtemailid" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Secuirty Question:</td>
<td><asp:TextBox ID="txtsecurityquestion" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Secuirty Answer:</td>
<td><asp:TextBox ID="txtsecurityanswer" runat="server"></asp:TextBox></td>
</tr>
</table>
</div>
<div id ="BasicInfo">
<h3 class ="DivTitle"> Basic Information:</h3>
<table>
<tr>
<td style="width: 115px">Name:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtfullname" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 115px">Date of Birth:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtdateofbirth" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 115px">Birth Place:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtplace" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 115px">Currently Living in:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtlivesin" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 115px">Languages:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtlanguages" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 115px">About Me:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtaboutme" runat="server"></asp:TextBox></td>
</tr>
</table>
</div>
<div id ="ProfessionalProfile">
<h3 class ="DivTitle">Professional Profile</h3>
<table>
<tr>
<td style="width: 117px">Employer:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtemployer" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 117px; height: 26px">Project:</td>
<td style="width: 3px; height: 26px">
    <asp:TextBox ID="txtproject" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 117px; height: 35px;">Designation:</td>
<td style="width: 3px; height: 35px;">
    <asp:TextBox ID="txtdesignation" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="width: 117px">College/University:</td>
<td style="width: 3px">
    <asp:TextBox ID="txtcollege" runat="server"></asp:TextBox></td>
</tr>
</table>
</div>
<div id ="MyProfile">
<h3 class ="DivTitle">My Profile</h3>
<table>
<tr>
<td style="height: 11px">UserName:</td>
<td style="height: 11px">
    <asp:Label ID="lblusername" runat="server"></asp:Label></td>
</tr>
<tr>
<td>E-mail:</td>
<td>
    <asp:Label ID="lblemail" runat="server"></asp:Label></td>
</tr>
</table>
<table>
<tr>
<td style="width: 115px; height: 29px;">Name:</td>
<td style="width: 3px; height: 29px;">
    <asp:Label ID="lblname" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 115px">Date of Birth:</td>
<td style="width: 3px">
    <asp:Label ID="lbldateofbirth" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 115px; height: 21px;">Place:</td>
<td style="width: 3px; height: 21px;">
    <asp:Label ID="lblplace" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 115px; height: 19px;">Languages:</td>
<td style="width: 3px; height: 19px;">
    <asp:Label ID="lbllanguages" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 115px">About Me:</td>
<td style="width: 3px">
    <asp:Label ID="lblaboutme" runat="server"></asp:Label></td>
</tr>
</table>
<table>
<tr>
<td style="width: 117px">Employer:</td>
<td style="width: 3px">
    <asp:Label ID="lblemployer" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 117px; height: 26px">Project:</td>
<td style="width: 3px; height: 26px">
    <asp:Label ID="lblproject" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 117px">Designation:</td>
<td style="width: 3px">
    <asp:Label ID="lbldesignation" runat="server"></asp:Label></td>
</tr>
<tr>
<td style="width: 117px">College/University:</td>
<td style="width: 3px">
    <asp:Label ID="lblcollege" runat="server"></asp:Label></td>
</tr>
</table>
</div>
<div id ="Buttons">
<table>
<tr>
<td><asp:Button ID="btnprevious" runat="server" Text="Previous" OnClientClick ="return Previous();" /></td>
<td style="width: 63px"><asp:Button ID="btnnext" runat="server" Text="Next" OnClientClick ="return Next();" Height="26px" Width="60px" /></td>
<td style="width: 63px"><asp:Button ID="btnfinish" runat="server" Text="Finish" Height="26px" Width="60px" OnClientClick="return Submit();" OnClick="btnfinish_Click" /></td>
</tr>
</table>
</div>
</div>
</asp:Content>

