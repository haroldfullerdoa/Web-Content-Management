<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="CMS_Concessions_default" title="Concessions - Content Management System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="tab" style="width: 100%;text-align:center;">
</div>

    <asp:Panel ID="plLogon" runat="server">
    <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    
  <tr>
    <td colspan="2" align="center" >
       <h2 class="Headings">Concessions Login</h2><hr size="1" width="100%" />               
       </td>
  </tr>
    
    
   <tr >
        <td colspan="2" align="center">
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
    </asp:Panel>
    
    <asp:Panel ID="plCompany" runat="server" Visible="false">
    <table width="490" border="0" align="center" cellpadding="2" cellspacing="10" >
  <tr>
  <td colspan="2" align="center" style="width:100%;">
  <div class="PageTitle">Welcome to the ATL Web CMS Concessions page. </div>
  </td>
 </tr>
 
  <tr>
    <td colspan="2" align="left">
    <p><strong>From here, you can add new concession stores, or modify the existing ones.</strong></p>
    <ul><li>To add new concession company, please click <a href="AddStore.aspx">Add New Company</a> link.</li>
    <li>To modify the existing concessions, please proceed to the <strong>Edit Page</strong> by selecting the company from the dropdown list below.</li></ul>
     </td>
    </tr>
        

  <tr>
    <td align="right" style="width:30%;" class="LoginHeadings"  valign="middle" ><label>Company Name:</label></td>
    <td valign="middle" style="width:70%">
    <asp:DropDownList ID="dplCompanyName" runat="server" DataSourceID="SqlDataSource1" DataTextField="COMPANY_NAME" DataValueField="COMPANY_ID" AppendDataBoundItems="True" AutoPostBack="True">
       <asp:ListItem  Text=" -- select one --" Value=""></asp:ListItem>
       <asp:ListItem  Text=" [Add New Company] " Value="0"></asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
        ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand='SELECT COMPANY_ID, COMPANY_NAME FROM CMS_COMPANY ORDER BY COMPANY_NAME'>
    </asp:SqlDataSource>
    </td>
  </tr>

  </table>
    </asp:Panel>
</asp:Content>

