<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false"
    ValidateRequest="false"  CodeFile="AddJob.aspx.vb" Inherits="Summer_Intern_Admin" Title="Content Management System – HR - Add Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../JScripts/CalendarControl.js" type="text/javascript"></script>

    <div class="tab" align="center" style="width: 100%">
        &nbsp;&nbsp;
        <asp:HyperLink ID="AddUser" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/AddJob.aspx">Add Job</asp:HyperLink>
        &nbsp;|&nbsp;
        <asp:HyperLink ID="HyperLink1" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/EditJob.aspx">Edit/Delete Job</asp:HyperLink>
    </div>
    <table width="100%" border="0" align="center" cellpadding="2" cellspacing="5">
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
                    * Job Title:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtJobTitle" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReJobTitle" runat="server" ErrorMessage="Job Title"
                    ControlToValidate="txtJobTitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    * Salary Range:</label></td>
            <td valign="middle" style="height: 47px">
                <asp:TextBox ID="txtSalaryRange" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReSalaryRange" runat="server" ErrorMessage="Salary Range"
                    ControlToValidate="txtSalaryRange">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
  <td align="right" width="50%" class="LoginHeadings"  valign="middle"><label> Salary Grade:</label></td>
   
     <td  valign="middle"> <asp:TextBox ID="txtSalaryGrade" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
    </td>
    </tr>--%>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle" style="height: 52px">
                <label>
                    * Applications Accepted From:</label></td>
            <td valign="middle" style="height: 52px">
                <asp:TextBox ID="txtAppFrom" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAppFrom" runat="server" ErrorMessage="Applications Accepted From"
                    ControlToValidate="txtAppFrom">*</asp:RequiredFieldValidator>
                <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAppFrom">
         </cc1:CalendarExtender>--%>
                <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                    class="image" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle" style="height: 52px">
                <label>
                    * Applications Accepted Until:</label></td>
            <td valign="middle" style="height: 52px">
                <asp:TextBox ID="txtAppUntil" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReAppUntil" runat="server" ErrorMessage="Applications Accepted To"
                    ControlToValidate="txtAppUntil">*</asp:RequiredFieldValidator>
                <img id="img2" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                    class="image" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    * Job Description:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtJobReq" runat="server" Width="200px" MaxLength="1000" TextMode="MultiLine"
                    Height="175px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReJobReq" runat="server" ErrorMessage="Job Requirements"
                    ControlToValidate="txtJobReq">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="ReeJobReq" ControlToValidate="txtJobReq"
                    ErrorMessage="Can't exceed 2000 characters" ValidationExpression="^[\s\S]{0,2000}$"
                    runat="server" SetFocusOnError="true">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Contact Information:</label></td>
            <td valign="middle">
                <asp:TextBox ID="txtContactinfo" runat="server" Width="200px" MaxLength="1000"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    * Is this job already posted on the NEO.gov Website?</label></td>
            <td valign="Top">
                <br />
                <asp:RadioButtonList ID="rbtLink" AutoPostBack="true" CssClass="text2" runat="server"
                    RepeatDirection="Horizontal" Width="80px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList><asp:RequiredFieldValidator ID="Rerbtlink" runat="server" ErrorMessage="Link to the NEO.gov Website"
                    ControlToValidate="rbtLink">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <tr>
                <td align="right" width="50%" class="text2" valign="middle">
                    <label>
                        If yes, Full Job Description URL:<br />
                        (Government Jobs Link)</label></td>
                <td valign="middle">
                    <asp:TextBox ID="txtJobDescUrl" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%" class="text2" valign="middle">
                    <label>
                        URL for "Apply Here" Link:<br />
                        (neo.gov link)</label></td>
                <td valign="middle">
                    <asp:TextBox ID="txtApplyLink"   Text="https://www.governmentjobs.com/js_login.cfm?&JobRequested=174153&TopHeader=atlanta&" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSumbit" CssClass="button" runat="server" Text="Add This Job" />
                &nbsp;
                <asp:Button ID="btnPreview" CssClass="button" runat="server" Text="Preview" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
