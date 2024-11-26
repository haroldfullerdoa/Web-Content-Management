<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false"
    CodeFile="AddAlert.aspx.vb" Inherits="CMS_Airport_Alerts_AddAlert" Title="CMS-Add Airport Alert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tab" align="center" style="width: 100%">
        &nbsp;&nbsp;
        <asp:HyperLink ID="AddUser" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Airport_Alerts/AddAlert.aspx">Add Alert</asp:HyperLink>
        &nbsp;|&nbsp;
        <asp:HyperLink ID="HyperLink1" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Airport_Alerts/EditAlert.aspx">Edit/Delete Alert</asp:HyperLink>
    </div>
    <table width="490" border="0" align="center" cellpadding="2" cellspacing="10">
        <tr>
            <td colspan="2" align="center" style="height: 23px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle"></asp:Label>
            </td>
        </tr>
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
                <asp:TextBox ID="txtAlertTitle" runat="server" Width="175px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAlertTitle" runat="server" ErrorMessage="Alert Title"
                    ControlToValidate="txtAlertTitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Alert Description:</label></td>
            <td valign="middle" style="height: 47px">
                <asp:TextBox ID="txtAlertDesc" runat="server" Width="175px" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
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
                <asp:TextBox ID="txtImgTag" runat="server" Width="175px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReImgTag" runat="server" ErrorMessage="Image Tag"
                    ControlToValidate="txtImgTag">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Image URL:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtImgUrl" runat="server" Width="175px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReImgUrl" runat="server" ErrorMessage="Image URL"
                    ControlToValidate="txtImgUrl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Navigational Link:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtLink" runat="server" Width="175px" MaxLength="100"></asp:TextBox>
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
            <td colspan="2" align="center">
                <asp:Button ID="btnSumbit" CssClass="button" runat="server" Text="Add This Alert" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
