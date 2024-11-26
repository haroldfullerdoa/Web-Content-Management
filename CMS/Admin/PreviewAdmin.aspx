<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="PreviewAdmin.aspx.vb" Inherits="CMS_Admin_PreviewAdmin" title="CMS-Preview Admin-Add User"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="tab" align="center" style="width: 100%" >
&nbsp;&nbsp;
    <asp:HyperLink ID="AddUser" cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Admin/AddUser.aspx">Add User</asp:HyperLink>
&nbsp;|&nbsp;
Preview User Details
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
            &nbsp;</td>
   </tr>
 
  <tr>
    <td align="right" class="LoginHeadings" width="40%" style="height: 23px"><label> Name of the User:</label></td>
    <td width="60%" style="height: 23px">
       <asp:Label ID="lblName" CssClass="text3" runat="server"  Width="175px" ></asp:Label>&nbsp;
<%--    <asp:TextBox ID="txtName" runat="server"  Width="175px" MaxLength="100"></asp:TextBox>--%>
    </td>
   
  </tr>
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Network User Name:</label></td>
    <td width="60%"> <asp:Label CssClass="text3" ID="lblEmail" runat="server" Width="175px"></asp:Label>
        &nbsp;
    
     </td>
  </tr>
    
  <tr>
  <td align="right"  valign="top" class="LoginHeadings" width="40%"><label> Select Business Unit:</label></td>
    <td width="60%" valign="top">
        <asp:Label CssClass="text3" ID="lblBUnit" runat="server" Width="175px"></asp:Label>

    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td align="center" colspan="2">
     <asp:Button ID="btnSumbit"  CssClass="button" runat="server" Text="Add This User"/>
    &nbsp;

     <asp:Button ID="btnCancel"  CssClass="button" runat="server" Text="Cancel"/>
      </td>
  </tr>
  
  
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  
</table>
</asp:Content>

