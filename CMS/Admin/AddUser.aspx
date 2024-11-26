<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="AddUser.aspx.vb" Inherits="Summer_Intern_Admin" title="Content Management System – Admin - Add User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="tab" align="center" style="width: 100%" >
&nbsp;&nbsp;
    <asp:HyperLink ID="AddUser" cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Admin/AddUser.aspx">Add User</asp:HyperLink>
&nbsp;|&nbsp;
<asp:HyperLink ID="HyperLink1"  cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Admin/EditUSer.aspx">Edit/Delete User</asp:HyperLink>
</div>


<table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
 <tr>
  <td colspan="2" align="center" style="height: 23px">
   &nbsp;
  </td>
 </tr>
 
  <tr>
    <td colspan="2" align="center">
     &nbsp;
    <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" ></asp:Label>
  
    </td>
    </tr>

   <tr >
        <td colspan="2" align="center">
    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
        </td>
   </tr>
 
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Name of the User:</label></td>
    <td width="60%"><asp:TextBox ID="txtName" runat="server"  Width="175px" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReName" runat="server" ErrorMessage="Name"
                    ControlToValidate="txtName">*</asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Network User Name:</label></td>
    <td width="60%"> <asp:TextBox ID="txtEmail" runat="server" Width="175px" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReEmail" runat="server" ErrorMessage="Email"
                    ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>&nbsp;
    
     </td>
  </tr>
  
  <tr>
  <td colspan="2" align="center">
      <asp:Label ID="Label1" runat="server" Text="Note: Please enter HJAIA Network Username." Font-Italic="True" Font-Size="Small"></asp:Label>&nbsp;
  </td>
  </tr>
  
  
  <tr>
  <td align="right"  valign="top" class="LoginHeadings" width="40%"><label> Select Business Unit:</label></td>
    <td width="60%" valign="top">
      <asp:RadioButtonList ID="RbtUnit" runat="server" RepeatLayout="Flow" Width="152px" CssClass="text2">
            <asp:ListItem>Administration</asp:ListItem>
            <asp:ListItem>Human Resources</asp:ListItem>
            <asp:ListItem>Public Affairs</asp:ListItem>
            <asp:ListItem>Parking</asp:ListItem>
            <asp:ListItem>Concessions</asp:ListItem>
            <asp:ListItem>Airside</asp:ListItem>
            <asp:ListItem>Safety Management</asp:ListItem>
            </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="ReBusinessUnit" runat="server" ErrorMessage="Business Unit"
                    ControlToValidate="RbtUnit">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td colspan="2" align="center" style="height: 28px">
     <asp:Button ID="btnSumbit"  CssClass="button" runat="server" Text="Add This User"/> &nbsp;



<asp:Button  ID="btnPreview"  CssClass="button" runat="server" Text="Preview"/>
        &nbsp;
      </td>
  </tr>
  
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  
</table>
</asp:Content>

