<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="EditStatus.aspx.vb" Inherits="CMS_Admin_EditUSer" title="Content Management System – Parking - Edit Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="tab" align="center" style="width: 100%" >

    <asp:Label ID="lblParking" runat="server" Text="Update Parking Lot"></asp:Label>
</div>


<table width="500" border="0" align="center" cellpadding="2" cellspacing="4">
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
    <td align="right" class="LoginHeadings" width="40%"><label> Select a Parking Lot:</label></td>
    <td width="60%"><asp:DropDownList ID="dplParking" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="LOT_NAME" DataValueField="LOT_ID">
        <asp:ListItem  Text="Select Parking Lot--" Value="0"></asp:ListItem>
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
        ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand='SELECT "LOT_NAME", "LOT_ID" FROM "CMS_PARKING_LOT" ORDER BY "LOT_NAME"'>
    </asp:SqlDataSource>
    <asp:RequiredFieldValidator ID="ReParking" runat="server" ErrorMessage="Select a Parking Lot"
                    ControlToValidate="dplParking">*</asp:RequiredFieldValidator>
    </td>
  </tr>  
    <tr>
  <td  colspan="2">  
 <hr size="1" width="100%" />
  </td>
  </tr>
   
   </table>
    <div align="center">
   <asp:FormView ID="FormView1" runat="server" Width="425px" DataSourceID="ObjectDataSource1" >
        <RowStyle HorizontalAlign="Left" />
          <ItemTemplate>
  <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
  <tr >
        <td colspan="2" align="center">
    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
        </td>
   </tr>

  <tr>
  <td align="right"  valign="top" class="LoginHeadings" width="40%"><label> Parking Lot Status:</label></td>
    <td width="60%" valign="top">
      <asp:RadioButtonList ID="RbtParking" runat="server" RepeatLayout="Flow" Width="152px" CssClass="text2" >
          <asp:ListItem>Full</asp:ListItem>
          <asp:ListItem>Open</asp:ListItem>
          <asp:ListItem>Temporarily Closed</asp:ListItem>
         </asp:RadioButtonList>
          <asp:RequiredFieldValidator ID="ReRbtParking" runat="server" ErrorMessage="Parking Lot Status"
                    ControlToValidate="RbtParking">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td   colspan="2" align="Center">
     <asp:Button ID="btnUpdate" CommandName="Update" CssClass="button" runat="server" Text="Update Status"/>  &nbsp;
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
</ItemTemplate>
<EditItemTemplate>
<table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
  <tr >
        <td colspan="2" align="center">
    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
        </td>
   </tr>

  <tr>
  <td align="right"  valign="top" class="LoginHeadings" width="40%"><label> Parking Lot Status:</label></td>
    <td width="60%" valign="top">
      <asp:RadioButtonList ID="RbtParking" runat="server" RepeatLayout="Flow" Width="152px" CssClass="text2" >
          <asp:ListItem>Full</asp:ListItem>
          <asp:ListItem>Open</asp:ListItem>
          <asp:ListItem>Temporarily Closed</asp:ListItem>
         </asp:RadioButtonList>
          <asp:RequiredFieldValidator ID="ReRbtParking" runat="server" ErrorMessage="Parking Lot Status"
                    ControlToValidate="RbtParking">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
    &nbsp;
    </td>
    </tr>
  <tr>
    <td   colspan="2" align="Center">
     <asp:Button ID="btnUpdate" CommandName="Update" CssClass="button" runat="server" Text="Update Status"/>  &nbsp;
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
</EditItemTemplate>
</asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserById" UpdateMethod="Savenewuser" 
            TypeName="Users">
            <SelectParameters>
                <asp:ControlParameter ControlID="dplParking" Name="userId" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter DefaultValue="Parking" Name="module_type" Type="String" />
            </SelectParameters>
            
               <UpdateParameters>
        <asp:SessionParameter Name="User" SessionField="USER" Type="object" />
        </UpdateParameters>
        </asp:ObjectDataSource>
</div>

</asp:Content>

