<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false"
    ValidateRequest="false" CodeFile="PreviewHR.aspx.vb" Inherits="CMS_Concessions_PreviewConcessions" Title="CMS-Preview HR-Add Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../JScripts/CalendarControl.js" type="text/javascript"></script>

    <div class="tab" align="center" style="width: 100%">
        &nbsp;&nbsp;
        <asp:HyperLink ID="AddUser" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/AddJob.aspx">Add Job</asp:HyperLink>
        &nbsp;|&nbsp; Preview Job Details
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <table width="490" border="0" align="center" cellpadding="2" cellspacing="10">
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
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Job Title:</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtJobTitle" runat="server" Width="175px"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Salary Range:</label></td>
                <td valign="middle" style="height: 47px">
                    <asp:Label CssClass="text3" ID="txtSalaryRange" runat="server" Width="175px"></asp:Label>&nbsp;
                </td>
            </tr>
            <%--    <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Salary Grade:</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtSalaryGrade" runat="server" Width="175px"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Applications Accepted From:</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtAppFrom" runat="server" Width="175px"></asp:Label>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Applications Accepted Until:</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtAppUntil" runat="server" Width="175px"></asp:Label>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Job Description:</label></td>
                <td valign="middle">
                    <asp:TextBox ID="txtJobReq" CssClass="text3" runat="server" Width="175px" MaxLength="1000"
                        TextMode="MultiLine" ReadOnly="true" Height="80px"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Contact Information:</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtContactinfo" runat="server" Width="175px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="LoginHeadings" valign="middle">
                    <label>
                        Is this job already posted on the NEO.gov Website?</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="lbljobalready" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="text2" valign="middle">
                    <label>
                        If yes, Full Job Description URL:<br />
                        (Government Jobs Link)</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtJobDescUrl" runat="server" Width="175px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="text2" valign="middle">
                    <label>
                        URL for "Apply Here" Link:<br />
                        (neo.gov link)</label></td>
                <td valign="middle">
                    <asp:Label CssClass="text3" ID="txtApplyLink" runat="server" Width="175px"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <table width="90%" align="center">
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
                <td colspan="2" align="center" style="height: 23px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td id="employment" class="employment">
                    <p>
                        <b>Job Title: </b>
                        <asp:Label ID="lblJobTitle" runat="server"></asp:Label><br />
                        <b>Salary Range:</b><asp:Label ID="lblSalRange" runat="server"></asp:Label><br />
                        <br />
                    </p>
                    <p>
                        <asp:Label ID="lblJobDesc" runat="server"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:HyperLink ID="hypJobdescUrl" Style="font: small-caption" runat="server" Target="_blank">Read More...</asp:HyperLink>
                        <%-- <a runat="server"  id=""  target="_blank">
                            </a>--%>
                    </p>
                    <p>
                        <asp:HyperLink ID="hypJobApplyUrl" runat="server" Target="_blank">Apply Here</asp:HyperLink>
                    </p>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnSumbit" CssClass="button" runat="server" Text="Add This Job" />
                    &nbsp;
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
