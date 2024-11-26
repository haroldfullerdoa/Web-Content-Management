<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false"
    CodeFile="Attachments.aspx.vb" Inherits="CMS_Airside_Engine_Runs_Attachments"
    Title="Airside Engine Runs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function btnHideModalPopup_file_onclick() {

}

// ]]>
    </script>

    <div class="tab" style="width: 100%; text-align: center;">
        Airside Documents</div>
    <table align="center" width="90%" border="0" cellpadding="2" cellspacing="4" >
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" width="50%">
                <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="LoginHeadings"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" width="50%">
                <asp:Label ID="lbFile" runat="server" Text="Choose File: " CssClass="LoginHeadings"></asp:Label>
            </td>
            <td>
                <input id="fileCompany" type="file" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            <br />
                <asp:Button runat="server" ID="btnNewFile" Text="Upload" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbFileUpdateMessage" runat="server" Font-Bold="true" ForeColor="red"
                    Text="" EnableViewState="false" /></td>
        </tr>
    </table>
    <asp:GridView ID="grdFiles" runat="server" DataSourceID="objectdatasource_files"
        HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px"
        DataKeyNames="ID" Width="90%" AllowPaging="True" EmptyDataText="No Files Found"
        GridLines="None">
        <Columns>
            <asp:TemplateField HeaderText="File">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Get_File_Name(DataBinder.Eval(Container.DataItem,"ID"),DataBinder.Eval(Container.DataItem,"Company_File_Data"),DataBinder.Eval(Container.DataItem,"Company_File_Name"))%>'
                        NavigateUrl='<%#Get_File_URL(DataBinder.Eval(Container.DataItem,"ID"),DataBinder.Eval(Container.DataItem,"Company_File_Name"))%>'
                        Target="_blank" ToolTip="Click to open in a new window"></asp:HyperLink>
                </ItemTemplate>
                <%--<ControlStyle Width="400px" />--%>
            </asp:TemplateField>
            <asp:BoundField DataField="Company_File_Name" HeaderText="File Name" />
            <asp:BoundField DataField="Company_File_Type" HeaderText="Title" />
            <asp:BoundField DataField="Company_File_Created_Date" HeaderText="Created Date" />
            <asp:BoundField DataField="ID" Visible="false" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle CssClass="color1" HorizontalAlign="Center" VerticalAlign="Middle" />
        <AlternatingRowStyle CssClass="color2" HorizontalAlign="Center" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource_Files" runat="server" SelectMethod="GetCollectionsByID"
        TypeName="HJAIA2008.BusinessLogicLayer.CMS" DeleteMethod="DeleteContentByID">
        <SelectParameters>
            <asp:Parameter Name="contentId" Type="Int32" />
            <asp:Parameter DefaultValue="Airside" Name="module_type" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter DefaultValue="Airside" Name="module_type" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
