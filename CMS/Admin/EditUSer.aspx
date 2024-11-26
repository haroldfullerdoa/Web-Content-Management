<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="EditUSer.aspx.vb" Inherits="CMS_Admin_EditUSer" title="Content Management System | Admin - Edit User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="tab" align="center" style="width: 100%" >&nbsp;&nbsp;
    <asp:HyperLink ID="AddUser" cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Admin/AddUser.aspx">Add User</asp:HyperLink>&nbsp;|&nbsp;
    <asp:HyperLink ID="HyperLink1"  cssclass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Admin/EditUSer.aspx">Edit/Delete User</asp:HyperLink>
</div>

    <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
        <tr><td colspan="2" align="center" style="height: 23px">&nbsp;</td></tr>
        <tr><td colspan="2" align="center">&nbsp;<asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" ></asp:Label></td></tr>
        <tr><td colspan="2" align="center" style="height: 23px">&nbsp;</td></tr>
        <tr><td align="right" class="LoginHeadings" width="40%"><label>Select User:</label></td>
            <td width="60%"><asp:DropDownList ID="dplName" runat="server" DataSourceID="SqlDataSource1" DataTextField="USERNAME" DataValueField="USERID" AppendDataBoundItems="True" AutoPostBack="True">
                                <asp:ListItem  Text="Select User--" Value="0"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:DOAINT %>"
                                ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" 
                                SelectCommand='SELECT "USERID", "USERNAME" FROM "CMS_BUSINESSUNITS_USERS" ORDER BY USERNAME'>
                                </asp:SqlDataSource>&nbsp;
            </td></tr>
        <tr><td colspan="2"><hr size="1" width="100%" /></td></tr>
    </table>
  
<div align="center">
    <asp:FormView ID="FormView1" runat="server" Width="425px" DataSourceID="ObjectDataSource1" >
        <RowStyle HorizontalAlign="Left" />
        <ItemTemplate>
          
        <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
 
    
            <tr ><td colspan="2" align="center"><asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" /></td></tr>
   
            <tr><td align="right" class="LoginHeadings" width="40%"><label> Name of the User:</label></td>
                <td width="60%"><asp:TextBox ID="txtName" runat="server"  Width="175px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Name")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReName" runat="server" ErrorMessage="Name" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td align="right" class="LoginHeadings" width="40%"><label> Network User Name:</label></td>
                <td width="60%"><asp:TextBox ID="txtEmail" runat="server" Width="175px" MaxLength="100" text='<%#DataBinder.Eval(Container.DataItem,"Admin_Email")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReEmail" runat="server" ErrorMessage="Email" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
      
                </td></tr>
            <tr><td colspan="2" align="center"><asp:Label ID="Label2" runat="server" Text="Note: Please enter HJAIA Network Username." Font-Italic="True" Font-Size="Smaller"></asp:Label></td></tr>
            <tr><td align="right"  valign="top" class="LoginHeadings" width="40%"><label> Select Business Unit:</label></td>
                <td width="60%" valign="top"><asp:RadioButtonList ID="RbtUnit" runat="server" RepeatLayout="Flow" Width="152px"    CssClass="text2">
                                                <asp:ListItem>Administration</asp:ListItem>
                                                <asp:ListItem>Human Resources</asp:ListItem>
                                                <asp:ListItem>Public Affairs</asp:ListItem>
                                                <asp:ListItem>Parking</asp:ListItem>
                                                <asp:ListItem>Concessions</asp:ListItem>
                                                <asp:ListItem>Airside</asp:ListItem>
                                                <asp:ListItem>Safety Management</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="ReBusinessUnit" runat="server" ErrorMessage="Business Unit" ControlToValidate="RbtUnit">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td colspan="2" align="center">&nbsp;</td></tr>
            <tr><td colspan="2" align="center"><asp:Label ID="Label1" runat="server" CssClass="pagetitle" ></asp:Label></td></tr>
            <tr><td  align="right"><asp:Button ID="btnEdit"   CommandName="Update" CssClass="button" runat="server" Text="Edit User"/>&nbsp;</td><td  align="left">&nbsp;<asp:Button ID="btnDelete" CommandName="Delete" CssClass="button" runat="server" Text="Delete User"/></td></tr>
            <tr><td colspan="2" align="center">&nbsp;</td></tr>
 
        </table>
        </ItemTemplate>


        <EditItemTemplate>
        <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">

            <tr><td colspan="2" align="center"><asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" /></td></tr>
   
            <tr><td align="right" class="LoginHeadings" width="40%"><label> Name of the User:</label></td>
                <td width="60%"><asp:TextBox ID="txtName" runat="server"  Width="175px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Name")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReName" runat="server" ErrorMessage="Name" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td align="right" class="LoginHeadings" width="40%"><label> Network User Name:</label></td>
                <td width="60%"><asp:TextBox ID="txtEmail" runat="server" Width="175px" MaxLength="100" text='<%#DataBinder.Eval(Container.DataItem,"Admin_Email")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReEmail" runat="server" ErrorMessage="Email" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td colspan="2" align = "center"><asp:Label ID="Label2" runat="server" Text="Note: Please enter HJAIA Network Username." Font-Italic="True" Font-Size="Smaller"></asp:Label></td></tr>
  
  
            <tr><td align="right"  valign="top" class="LoginHeadings" width="40%"><label> Select Business Unit:</label></td>
                <td width="60%" valign="top"><asp:RadioButtonList ID="RbtUnit" runat="server" RepeatLayout="Flow" Width="152px"    CssClass="text2">
                                                <asp:ListItem>Administration</asp:ListItem>
                                                <asp:ListItem>Human Resources</asp:ListItem>
                                                <asp:ListItem>Public Affairs</asp:ListItem>
                                                <asp:ListItem>Parking</asp:ListItem>
                                                <asp:ListItem>Concessions</asp:ListItem>
                                                <asp:ListItem>Airside</asp:ListItem>
                                                <asp:ListItem>Safety Management</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="ReBusinessUnit" runat="server" ErrorMessage="Business Unit" ControlToValidate="RbtUnit">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td colspan="2" align="center">&nbsp;</td></tr>
            <tr><td colspan="2" align="center"><asp:Label ID="Label1" runat="server" CssClass="pagetitle" ></asp:Label></td></tr>
            <tr><td  align="right"><asp:Button ID="btnEdit"  CommandName="Update"  CssClass="button" runat="server" Text="Edit User"/>&nbsp;</td>
                <td align="left">&nbsp;<asp:Button ID="btnDelete"  CommandName="Delete" CssClass="button" runat="server" Text="Delete User"/></td>
            </tr><tr><td colspan="2" align="center">&nbsp;</td></tr>
        </table>
        </EditItemTemplate>
    </asp:FormView>
</div>


<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserById" UpdateMethod="Savenewuser" DeleteMethod="Savenewuser" TypeName="Users" >
        
<SelectParameters><asp:ControlParameter ControlID="dplName" Name="userId" PropertyName="SelectedValue" Type="Int32" />
<asp:Parameter DefaultValue="Administration" Name="module_type" Type="String" />
</SelectParameters>
        
<UpdateParameters>
<asp:SessionParameter Name="User" SessionField="USER" Type="object" />
</UpdateParameters>
        
<DeleteParameters>
<asp:SessionParameter Name="User" SessionField="USER" Type="object" />
</DeleteParameters>
        
</asp:ObjectDataSource>

</asp:Content>

