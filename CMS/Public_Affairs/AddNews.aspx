<%@ Page  ValidateRequest="false" Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="AddNews.aspx.vb" Inherits="CMS_Public_Affairs_AddNews" title="Content Management System – Public Affairs - Add News Story" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="../JScripts/CalendarControl.js" type="text/javascript"></script>

<div class="tab" align="center" style="width: 100%" >
&nbsp;&nbsp;
    <asp:HyperLink ID="AddUser" cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Public_Affairs/AddPressRelease.aspx">Add Press Release</asp:HyperLink>
&nbsp;|&nbsp;
<asp:HyperLink ID="HyperLink1"  cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Public_Affairs/EditPress_Release.aspx">Edit/Delete Press Release</asp:HyperLink>
&nbsp;|&nbsp;
<asp:HyperLink ID="HyperLink2" cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Public_Affairs/AddNews.aspx">Add Airport News Story</asp:HyperLink>
&nbsp;|&nbsp;
<asp:HyperLink ID="HyperLink3"  cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Public_Affairs/EditNews.aspx">Edit/Delete Airport News Story</asp:HyperLink>
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
    <td align="right" class="LoginHeadings" width="40%"><label> Airport News Story Title:</label></td>
    <td width="60%"><asp:TextBox ID="txtPressTitle" runat="server"  Width="200px" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RePressTitle" runat="server" ErrorMessage="Press Release Title"
                    ControlToValidate="txtPressTitle">*</asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Date:</label></td>
    <td width="60%"> <asp:TextBox ID="txtDate" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
     <asp:RequiredFieldValidator ID="ReDate" runat="server" ErrorMessage="Date"
                    ControlToValidate="txtDate">*</asp:RequiredFieldValidator>
      <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" />
     </td>
  </tr>
  
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Detailed Article:</label></td>
    <td width="60%"><asp:TextBox ID="txtArticle" runat="server"   TextMode="multiLine" Width="200px" MaxLength="1000" Height="175px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReArticle" runat="server" ErrorMessage="Detailed Article"
                    ControlToValidate="txtArticle">*</asp:RequiredFieldValidator>
    </td>
  </tr>
  
 
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td colspan="2" align="center">
     <asp:Button ID="btnSumbit"  CssClass="button" runat="server" Text="Publish this News Story"/>
      &nbsp;
<asp:Button  ID="btnPreview"  CssClass="button" runat="server" Text="Preview"/>
        &nbsp;
      </td>
  </tr>
  
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td colspan="2" align="center">
  
  </td>
  </tr>
</table>


</asp:Content>

