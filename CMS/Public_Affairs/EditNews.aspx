<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="EditNews.aspx.vb" Inherits="CMS_Public_Affairs_EditNews" title="Content Management System – Public Affairs - Edit News Story" %>
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
    <td align="right" class="LoginHeadings" width="50%"><label> Select Airport News Story Title:</label></td>
    <td width="50%"><asp:DropDownList ID="dplPressTitle" runat="server" DataSourceID="SqlDataSource1" DataTextField="NEWS_TITLE" DataValueField="NEWS_ID" AutoPostBack="true" AppendDataBoundItems="true">
     <asp:ListItem  Text="Select Press Title--" Value="0"></asp:ListItem>
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
        ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand='SELECT "NEWS_ID", "NEWS_TITLE" FROM "CMS_ATL_NEWS" ORDER BY "NEWS_TITLE"'>
    </asp:SqlDataSource>
    <asp:RequiredFieldValidator ID="RePressTitle" runat="server" ErrorMessage="Press Release Title"
                    ControlToValidate="dplPressTitle">*</asp:RequiredFieldValidator>
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
    <table width="500" border="0" align="center" cellpadding="2" cellspacing="4">
    
   <tr >
        <td colspan="2" align="center">
    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
        </td>
   </tr>
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Airport News Story Title:</label></td>
    <td width="60%"> <asp:TextBox ID="txtPressTitle" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Name")%>'></asp:TextBox>
     <asp:RequiredFieldValidator ID="ReTitle" runat="server" ErrorMessage="Title"
                    ControlToValidate="txtPressTitle">*</asp:RequiredFieldValidator>
     </td>
  </tr>
 
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Date:</label></td>
    <td width="60%"> <asp:TextBox ID="txtDate" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Email")%>'></asp:TextBox>
     <asp:RequiredFieldValidator ID="ReDate" runat="server" ErrorMessage="Date"
                    ControlToValidate="txtDate">*</asp:RequiredFieldValidator>
      <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" />
      <%--<asp:Image  ID="img1"  style="width: 20px;"   ToolTip="Pick Date"  ImageUrl="../Images/datePickerPopup.gif"  CssClass="image" runat="server" />    --%>                    
     </td>
  </tr>
  
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Detailed Article:</label></td>
    <td width="60%"><asp:TextBox ID="txtArticle" runat="server"   TextMode="multiLine" Height="175px" Width="200px" MaxLength="1000" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Unit")%>'></asp:TextBox>
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
    <td align="right">
     <asp:Button ID="btnUpdate"  CommandName="Update" CssClass="button" runat="server" Text="Update Press Release"/>&nbsp;
      </td>
        <td align="left">
     &nbsp;<asp:Button ID="btnDelete"    CommandName="Delete" CssClass="button" runat="server" Text="Delete Press Release"/>
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
     <table width="500" border="0" align="center" cellpadding="2" cellspacing="4">
    
   <tr >
        <td colspan="2" align="center">
    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
        </td>
   </tr>
 
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Press Release Title:</label></td>
    <td width="60%"> <asp:TextBox ID="txtPressTitle" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Name")%>'></asp:TextBox>
     <asp:RequiredFieldValidator ID="ReTitle" runat="server" ErrorMessage="Title"
                    ControlToValidate="txtPressTitle">*</asp:RequiredFieldValidator>
     </td>
  </tr>
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Date:</label></td>
    <td width="60%"> <asp:TextBox ID="txtDate" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Email")%>'></asp:TextBox>
     <asp:RequiredFieldValidator ID="ReDate" runat="server" ErrorMessage="Date"
                    ControlToValidate="txtDate">*</asp:RequiredFieldValidator>
         <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" /> 
    <%--  <asp:Image  ID="img1"  style="width: 20px;"   ToolTip="Pick Date"  ImageUrl="../Images/datePickerPopup.gif"  CssClass="image" runat="server" />                        --%>
     </td>
  </tr>
  
  <tr>
    <td align="right" class="LoginHeadings" width="40%"><label> Detailed Article:</label></td>
    <td width="60%"><asp:TextBox ID="txtArticle" runat="server"   TextMode="multiLine"  Height="175px" Width="200px" MaxLength="1000" Text='<%#DataBinder.Eval(Container.DataItem,"Admin_Unit")%>'></asp:TextBox>
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
    <td align="Right">
     <asp:Button ID="btnUpdate"  CommandName="Update" CssClass="button" runat="server" Text="Update Press Release"/>&nbsp;
      </td>
        <td align="Left">
     &nbsp;<asp:Button ID="btnDelete"    CommandName="Delete" CssClass="button" runat="server" Text="Delete Press Release"/>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserById" UpdateMethod="Savenewuser" DeleteMethod="Savenewuser"
            TypeName="Users">
            <SelectParameters>
                <asp:ControlParameter ControlID="dplPressTitle" Name="userId" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter DefaultValue="News" Name="module_type" Type="String" />
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

