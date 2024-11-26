<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="AddStore.aspx.vb" Inherits="CMS_Concessions_AddStore" title="Concessions - Add Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<div class="tab" style="width: 100%;text-align:center;">&nbsp;</div>

<table width="90%" border="0" cellpadding="2" cellspacing="10" id="TABLE1">
   <tr>
    <td colspan="2" align="center">
     &nbsp;
    <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" >Add New Company</asp:Label>  
    </td>
    </tr>
    
   <tr>
        <td colspan="2"><asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please fix the following error(s):" Font-Bold="true" />
        </td>
   </tr>
 
  <tr>
    <td align="right" style="width:40%;" class="LoginHeadings"><label>Company Name:</label></td>
    <td style="width:60%;"><asp:TextBox ID="txtCompanyName" runat="server" Width="300px" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReCompanyName" runat="server" ErrorMessage="Company Name is blank" ControlToValidate="txtCompanyName">*</asp:RequiredFieldValidator>
    </td>
  </tr>
  
  <tr>
    <td valign="top" align="right" class="LoginHeadings"><label>Company Description:</label></td>
    <td><asp:TextBox ID="txtCompanyDescription" runat="server" Width="300px" Rows="8" MaxLength="2000" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReCompanyDescription" runat="server" ErrorMessage="Company Description is blank" ControlToValidate="txtCompanyDescription">*</asp:RequiredFieldValidator>
    </td>
  </tr>
    
  <tr>
    <td align="right" class="LoginHeadings"><label>Store Type:</label></td>   
    <td><asp:DropDownList ID="dplCompanyType" runat="server" DataSourceID="sqlDataSource1" DataTextField ="STORE_TYPE" DataValueField="STORE_TYPE_ID" AppendDataBoundItems='true'>
        <asp:ListItem Value="">-- select one --</asp:ListItem>
        </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
                     ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand="SELECT * FROM CMS_TYPES ORDER BY STORE_TYPE">
                </asp:SqlDataSource>
        <asp:RequiredFieldValidator ID="ReqStoreTyep" runat="server" ErrorMessage="Store Type has not been seleted" ControlToValidate="dplCompanyType">*</asp:RequiredFieldValidator>
    </td>
   </tr>
  
    <tr>
       <td align="right" class="LoginHeadings"><label>Company Contact Number:</label></td>
       <td><asp:TextBox ID="txtPhone1" runat="server" Width="175px" MaxLength="14" /> ext. <asp:TextBox ID="txtPhone1Ext" runat="server" Width="35px" MaxLength="5" />          
    </td>
    </tr>

    <tr>
       <td align="right" class="LoginHeadings"><label>Alternative Phone Number:</label></td>
       <td><asp:TextBox ID="txtPhone2" runat="server" Width="175px" MaxLength="14" /> ext. <asp:TextBox ID="txtPhone2Ext" runat="server" Width="35px" MaxLength="5" /> 
      </td>
    </tr>  
      
    <tr>
       <td align="right" class="LoginHeadings"><label>Company Web site:</label></td>
       <td><asp:TextBox ID="txtWebsite" runat="server" Width="250px" MaxLength="200" ></asp:TextBox>
      </td>
    </tr>    
   
  <tr>
    <td colspan="2" align="center">
     <asp:Button ID="btnSumbit"  CssClass="button" runat="server" Text="Add Company"/>
      &nbsp;&nbsp;
   <%-- <asp:Button  ID="btnPreview"  CssClass="button" runat="server" Text="Preview"/>
        &nbsp;--%>
      <input type="reset" name="btnReset" value="Clear Form" />  
      </td>
  </tr>

</table>

</asp:Content>

