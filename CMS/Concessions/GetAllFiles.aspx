<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GetAllFiles.aspx.vb" Inherits="CMS_Concessions_GetAllFiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <asp:Label runat="server" ID="lblMessage" Text="" ForeColor="red" BackColor="yellow" Width="90%" Visible="false"  />
 
    <asp:DataList ID="DataList_Attachment" DataSourceID="SqlDataSource_FILES" runat="server" 
            RepeatColumns="1">
    <ItemTemplate>
    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Get_File_Name(DataBinder.Eval(Container.DataItem,"FILE_ID"),DataBinder.Eval(Container.DataItem,"THEFILE"),DataBinder.Eval(Container.DataItem,"File_Name"),DataBinder.Eval(Container.DataItem,"File_Type"))%>' NavigateUrl='<%#Get_File_URL(DataBinder.Eval(Container.DataItem,"FILE_ID"),DataBinder.Eval(Container.DataItem,"File_Name"),DataBinder.Eval(Container.DataItem,"File_Type"))%>' Target="_blank" ToolTip="Click to download or open in a new window"></asp:HyperLink>
    </ItemTemplate>
    </asp:DataList> 
        <asp:SqlDataSource ID="SqlDataSource_FILES" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DOAINT %>" 
            ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" 
            SelectCommand="SELECT C.COMPANY_NAME, F.* FROM ATLWEB_OWNER.CMS_COMPANY C, ATLWEB_OWNER.CMS_COMPANY_FILE F
WHERE C.COMPANY_ID = F.company_id
ORDER BY FILE_TYPE, C.COMPANY_NAME DESC">
        </asp:SqlDataSource></asp:SqlDataSource>
<br />

        <p><br /></p>

    </div>
    </form>
</body>
</html>
