<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="EditAlert.aspx.vb" Inherits="CMS_Airport_Alerts_EditAlert" title="CMS-Edit Airport Alert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="tab" align="center" style="width: 100%" >
&nbsp;&nbsp;
    <asp:HyperLink ID="AddUser" cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/AddJob.aspx">Add Job</asp:HyperLink>
&nbsp;|&nbsp;
<asp:HyperLink ID="HyperLink1"  cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/EditJob.aspx">Edit/Delete Job</asp:HyperLink>
</div>


<table width="490" border="0" align="center" cellpadding="2" cellspacing="10" >
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
    
    
 <tr>
  <td colspan="2" align="center" style="height: 23px">
   &nbsp;
  </td>
 </tr>
   
  <tr>
    <td align="right"  width="50%" class="LoginHeadings"  valign="middle" ><label> Alert Title:</label></td>
    <td  valign="middle"><asp:DropDownList ID="dplAlertTitle" runat="server" DataSourceID="SqlDataSource1" DataTextField="TITLE" DataValueField="ALERT_ID" AppendDataBoundItems="True" AutoPostBack="True">
        <asp:ListItem  Text="Select Alert Title--" Value="0"></asp:ListItem>
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
        ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand='SELECT "ALERT_ID", "TITLE" FROM "CMS_AIRPORT_ALERT" ORDER BY "TITLE"'>
    </asp:SqlDataSource>
 
    </td>
  </tr>
  
   <tr>
  <td  colspan="2">  
 <hr size="1" width="100%" />
  </td>
  </tr>
    
    </table>
    
  <div align="center">
   <asp:FormView ID="frmViewAlert" runat="server" Width="425px" DataSourceID="ObjectDataSource1" >
     <RowStyle HorizontalAlign="Left" />
      <ItemTemplate> 
      <table width="490" border="0" align="center" cellpadding="2" cellspacing="10">
       
        <tr>
            <td colspan="2" align="center">
                <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Alert Title:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtAlertTitle" runat="server" Width="175px" Text='<%#DataBinder.Eval(Container.DataItem,"Alert_Title")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAlertTitle" runat="server" ErrorMessage="Alert Title"
                    ControlToValidate="txtAlertTitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Alert Description:</label></td>
            <td valign="middle" style="height: 47px">
                <asp:TextBox ID="txtAlertDesc" runat="server" Width="175px" MaxLength="1000"  Text='<%#DataBinder.Eval(Container.DataItem,"Alert_Desc")%>' TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAlertDesc" runat="server" ErrorMessage="Alert Description"
                    ControlToValidate="txtAlertDesc">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Is Enable:</label></td>
            <td valign="middle">
                <asp:RadioButtonList ID="rbtAlertEnbl" runat="server" RepeatDirection="Horizontal" Width="64px">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="ReAlertEnbl" runat="server" ErrorMessage="Is Enable"
                    ControlToValidate="rbtAlertEnbl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Image Tag:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtImgTag" runat="server" Width="175px" Text='<%#DataBinder.Eval(Container.DataItem,"Alert_ImgTag")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReImgTag" runat="server" ErrorMessage="Image Tag"
                    ControlToValidate="txtImgTag">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Image URL:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtImgUrl" runat="server" Width="175px"  Text='<%#DataBinder.Eval(Container.DataItem,"Alert_ImgUrl")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReImgUrl" runat="server" ErrorMessage="Image URL"
                    ControlToValidate="txtImgUrl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Navigational Link:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtLink" runat="server" Width="175px"  Text='<%#DataBinder.Eval(Container.DataItem,"Alert_Link")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Relink" runat="server" ErrorMessage="Navigational Link"
                    ControlToValidate="txtLink">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
       <tr>
    <td  align="right">
     <asp:Button ID="btnUpdate"  CommandName="Update" CssClass="button" runat="server" Text="Update this Alert"/>&nbsp;
      </td>
      <td  align="left">
     &nbsp;<asp:Button ID="btnDelete"    CommandName="Delete" CssClass="button" runat="server" Text="Delete this Alert"/>
      </td>
  </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
    </table>
      
      </ItemTemplate>
      
      
      
      <EditItemTemplate>
      
      <table width="490" border="0" align="center" cellpadding="2" cellspacing="10">
        
        <tr>
            <td colspan="2" align="center">
                <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Alert Title:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtAlertTitle" runat="server" Width="175px" Text='<%#DataBinder.Eval(Container.DataItem,"Alert_Title")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAlertTitle" runat="server" ErrorMessage="Alert Title"
                    ControlToValidate="txtAlertTitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Alert Description:</label></td>
            <td valign="middle" style="height: 47px">
                <asp:TextBox ID="txtAlertDesc" runat="server" Width="175px" MaxLength="1000"  Text='<%#DataBinder.Eval(Container.DataItem,"Alert_Desc")%>' TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAlertDesc" runat="server" ErrorMessage="Alert Description"
                    ControlToValidate="txtAlertDesc">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Is Enable:</label></td>
            <td valign="middle">
                <asp:RadioButtonList ID="rbtAlertEnbl" runat="server" RepeatDirection="Horizontal" Width="64px">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="ReAlertEnbl" runat="server" ErrorMessage="Is Enable"
                    ControlToValidate="rbtAlertEnbl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Image Tag:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtImgTag" runat="server" Width="175px" Text='<%#DataBinder.Eval(Container.DataItem,"Alert_ImgTag")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReImgTag" runat="server" ErrorMessage="Image Tag"
                    ControlToValidate="txtImgTag">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Image URL:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtImgUrl" runat="server" Width="175px"  Text='<%#DataBinder.Eval(Container.DataItem,"Alert_ImgUrl")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReImgUrl" runat="server" ErrorMessage="Image URL"
                    ControlToValidate="txtImgUrl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Navigational Link:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtLink" runat="server" Width="175px"  Text='<%#DataBinder.Eval(Container.DataItem,"Alert_Link")%>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Relink" runat="server" ErrorMessage="Navigational Link"
                    ControlToValidate="txtLink">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
      <tr>
    <td  align="right">
     <asp:Button ID="btnUpdate"  CommandName="Update" CssClass="button" runat="server" Text="Update this Alert"/>&nbsp;
      </td>
      <td  align="left">
     &nbsp;<asp:Button ID="btnDelete"    CommandName="Delete" CssClass="button" runat="server" Text="Delete this Alert"/>
      </td>
  </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
    </table>
      
      </EditItemTemplate>
      
      
      </asp:FormView>
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserById" UpdateMethod="Savenewuser" DeleteMethod="Savenewuser"
          TypeName="Users">
          <SelectParameters>
              <asp:ControlParameter ControlID="dplAlertTitle" Name="userId" PropertyName="SelectedValue"
                  Type="Int32" />
              <asp:Parameter DefaultValue="AirportAlert" Name="module_type" Type="String" />
          </SelectParameters>
            <UpdateParameters>
        <asp:SessionParameter Name="User" SessionField="USER" Type="object" />
        </UpdateParameters>
        
        <DeleteParameters>
        <asp:SessionParameter Name="User" SessionField="USER" Type="object" />
        </DeleteParameters>
        
          
          
      </asp:ObjectDataSource>
</div>

</asp:Content>

