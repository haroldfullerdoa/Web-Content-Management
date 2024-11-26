<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="CMS_Admin_AddUser" title="Content Management System – Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="tab" align="center" style="width: 100%" >
&nbsp;
</div>

    
    <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    
  <tr>
    <td colspan="2" align="center" >
       <h2 class="Headings">Admin Login</h2><hr size="1" width="100%" />               
       </td>
  </tr>
    
    
   <tr >
        <td colspan="2" align="center" >
    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
        </td>
   </tr>
   
 
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> User Name:</label></td>
    <td width="60%"><asp:TextBox ID="txtUserName" runat="server"  Width="175px" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReName" runat="server" ErrorMessage="User Name"
                    ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Password:</label></td>
    <td width="60%"> <asp:TextBox ID="txtPassword" runat="server" Width="175px" MaxLength="100" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RePassword" runat="server" ErrorMessage="Password"
                    ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
    </td>
  </tr>
  
  
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td colspan="2" align="center">
     <asp:Button ID="btnSumbit"  CssClass="button" runat="server" Text="Login"/>
      </td>
  </tr>
  
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td colspan="2" align="center">
  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
  </td>
  </tr>
</table>
</asp:Content>

