<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="SuccessfullyChanged.aspx.vb" Inherits="SuccessfullyChanged" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <div class="tab" style="width: 100%;text-align:center;">&nbsp;</div>

        <table width="90%" border="0" cellpadding="2" cellspacing="10" id="TABLE1">
           <tr>
            <td colspan="2" align="center">
             &nbsp;
            <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" ><h2>Update Company Information</h2></asp:Label>  
            </td>
            </tr>
    
           <tr>
                <td colspan="2"><asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please fix the following error(s):" Font-Bold="true" />
                </td>
           </tr>
 
          <tr>
            <td align="right" style="width:40%;" class="LoginHeadings">&nbsp;</td>
            <td style="width:60%;">&nbsp;</td>
          </tr>
  
          <tr>
            <td valign="top" align="right" class="LoginHeadings">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
    
          <tr>
            <td align="right" class="LoginHeadings">&nbsp;</td>   
              <%--            <td><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqlDataSource1" DataTextField ="STORE_TYPE" DataValueField="STORE_TYPE_ID" AppendDataBoundItems='true'>
                <asp:ListItem Value="">-- select one --</asp:ListItem>--%>
            <td>&nbsp;</td>
           </tr>
        </table>
</asp:Content>

