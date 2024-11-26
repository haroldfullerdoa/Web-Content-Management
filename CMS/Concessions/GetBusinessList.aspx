<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="GetBusinessList.aspx.vb" Inherits="GetBusinessList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <div class="tab" style="width: 100%;text-align:center;"><h2>Concession List</h2></div>

    <table style="width: 100%;">
        <tr>
            <td align="center" style="width: 50%">
                <asp:Label ID="Label1" runat="server" Text="Business Type:"></asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
            </td>
            <td  align="left" style="width: 50%">
                <asp:RadioButtonList ID="rbActiveStatus" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="2">Both</asp:ListItem>
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RadioButtonList ID="rbDBE" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="2">Both</asp:ListItem>
                    <asp:ListItem Value="1" >DBE</asp:ListItem>
                    <asp:ListItem Value="0" >Not DBE</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 50%">
                <asp:Label ID="lbCompanyName" runat="server" Text="CompanyName"></asp:Label>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            </td>
            <td align="left" style="width: 50%">
                <asp:Label ID="lbPersonName" runat="server" Text="Contact Person Name"></asp:Label>
                <asp:TextBox ID="txtPersonName" runat="server"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 50%">
               <asp:Label ID="lbStartDate" runat="server" Text="Start Date"></asp:Label>
               <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox> 
               <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif" class="image" runat="server" />
               <br />
             </td>
            <td align="left" style="width: 50%">
               <asp:Label ID="lbEndDate" runat="server" Text="End Date"></asp:Label>
               <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox> 
               <img id="img2" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif" class="image" runat="server" />
               <br />
             </td>
        </tr>

        <tr>
             <td colspan="2" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Search Record" /> 
            &nbsp;
                 <asp:Button ID="btnAddReord" runat="server" CausesValidation="False" 
                     PostBackUrl="~/CMS/Concessions/AddBusiness.aspx" Text="Add Record" />
            &nbsp;
                 <asp:Button ID="btnEmailOnly" runat="server" Text="Email Only" />
&nbsp;
                 <asp:Button ID="btnExportData" runat="server" Text="Export Data" />
            </td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr align="center">
            <td colspan="2"> 
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" 
                    EmptyDataText="No Data" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="category" HeaderText="Category" 
                            SortExpression="category" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" 
                            SortExpression="CompanyName" />
                        <asp:BoundField DataField="BusinessEmail" HeaderText="Business Email" 
                            SortExpression="BusinessEmail" />
                        <asp:BoundField DataField="ContactEmail" HeaderText="Contact Email" 
                            SortExpression="ContactEmail" />
                        <asp:HyperLinkField DataNavigateUrlFields="SupplierNumber" DataNavigateUrlFormatString="UpdateBusinessInfo.aspx?SupplierNumber={0}"
                            
                            DataTextFormatString="{0:d}" Target="_blank" Text="Select" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConcessionsConnectionString %>" 
                    SelectCommand="sp_GetBusinessList" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCategory" DefaultValue="0" 
                            Name="BusinessTypeID" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="rbActiveStatus" Name="ActiveStatus" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="rbDBE" DefaultValue="" Name="DBE" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="txtCompanyName" Name="CompanyName" 
                            PropertyName="Text" Type="String" DefaultValue="%%" />
                        <asp:ControlParameter ControlID="txtPersonName" Name="ContactFullName" 
                            PropertyName="Text" Type="String" DefaultValue="%%" />
                        <asp:ControlParameter ControlID="txtStartDate" DbType="String" 
                             Name="StartDate" PropertyName="Text" DefaultValue="1/1/1900" />
                        <asp:ControlParameter ControlID="txtEndDate" DbType="String" 
                             Name="EndDate" PropertyName="Text" DefaultValue="1/1/2100" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
    </table>

    </asp:Content>