<%@ Page ValidateRequest="false" Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master"
    AutoEventWireup="false" CodeFile="PreviewNews.aspx.vb" Inherits="CMS_Concessions_PreviewConcessions"
    Title="CMS-Preview Public Affairs-Add News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tab" align="center" style="width: 100%">
        &nbsp;&nbsp;
        <asp:HyperLink ID="AddUser" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Public_Affairs/AddPressRelease.aspx">Add Press Release</asp:HyperLink>
        &nbsp;|&nbsp;
        <asp:HyperLink ID="HyperLink2" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/Public_Affairs/AddNews.aspx">Add Airport News Story</asp:HyperLink>
        &nbsp;|&nbsp; Preview News Details
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <table width="425" border="0" align="center" cellpadding="2" cellspacing="4">
            <tr>
                <td colspan="2" align="center" style="height: 23px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
                </td>
            </tr>
            <tr>
                <td align="right" class="LoginHeadings" width="40%">
                    <label runat="server" id="lblNews">
                    </label>
                </td>
                <td width="60%">
                    <asp:Label CssClass="text3" ID="txtPressTitle" runat="server" Width="175px"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="LoginHeadings" width="40%">
                    <label>
                        Date:</label></td>
                <td width="60%">
                    <asp:Label CssClass="text3" ID="txtDate" runat="server" Width="175px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="LoginHeadings" width="40%">
                    <label>
                        Detailed Article:</label></td>
                <td width="60%">
                    <asp:TextBox CssClass="text3" ID="txtArticle" runat="server" TextMode="multiLine"
                        ReadOnly="true" Width="175px" MaxLength="1000" Height="80px"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="true">
        <table align="center" width="95%">
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
        </table>
        <table align="center" width="95%" class="employment">
            <tr>
                <td colspan="2" align="center" style="height: 23px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="100%" align="center">
                    <div class="GWHeader">
                        <asp:Label runat="server" ID="lblTitle"></asp:Label>
                    </div>
                    <table width="100%" align="center">
                        <tr>
                            <td align="center">
                                <b>
                                    <asp:Label runat="server" ID="lblRelDate"></asp:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="100%" runat="server" id="article">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSumbit" CssClass="button" runat="server" Text="Publish this News Story" />
                                &nbsp;
                                <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
