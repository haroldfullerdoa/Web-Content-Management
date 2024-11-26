<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false"
   ValidateRequest="false" CodeFile="EditJob.aspx.vb" Inherits="CMS_Admin_EditUSer" Title="Content Management System – HR - Edit Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../JScripts/CalendarControl.js" type="text/javascript"></script>

    <div class="tab" align="center" style="width: 100%">
        &nbsp;&nbsp;
        <asp:HyperLink ID="AddUser" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/AddJob.aspx">Add Job</asp:HyperLink>
        &nbsp;|&nbsp;
        <asp:HyperLink ID="HyperLink1" CssClass="tabhyperlink" runat="server" NavigateUrl="~/CMS/HR/EditJob.aspx">Edit/Delete Job</asp:HyperLink>
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
            <td colspan="2" align="center" style="height: 23px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" class="LoginHeadings" valign="middle">
                <label>
                    Job Title:</label></td>
            <td valign="middle">
                <asp:DropDownList ID="dplJobtitle" runat="server" Width="200px" DataSourceID="SqlDataSource1"
                    DataTextField="JOB_TITLE" DataValueField="JOB_ID" AppendDataBoundItems="True"
                    AutoPostBack="True">
                    <asp:ListItem Text="Select Job Title--" Value="0"></asp:ListItem>
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DOAINT %>"
                    ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>" SelectCommand='SELECT "JOB_ID", "JOB_TITLE" FROM "CMS_JOBS" ORDER BY "JOB_TITLE"'>
                </asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="ReJobTitle" runat="server" ErrorMessage="Job Title"
                    ControlToValidate="dplJobtitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr size="1" width="100%" />
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:FormView ID="FormView1" runat="server" Width="425px" DataSourceID="ObjectDataSource1">
            <RowStyle HorizontalAlign="Left" />
            <ItemTemplate>
                <table width="500" border="0" align="center" cellpadding="2" cellspacing="10">
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
                            <asp:TextBox ID="txtJobTitle" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Job_Ttle")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReJobTitle" runat="server" ErrorMessage="Job Title"
                                ControlToValidate="txtJobTitle">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Salary Range:</label></td>
                        <td valign="middle" style="height: 47px">
                            <asp:TextBox ID="txtSalaryRange" runat="server" Width="200px" MaxLength="100" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"Salary_Range"))= "0"),"",(DataBinder.Eval(Container.DataItem,"Salary_Range")))%>'> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReSalaryRange" runat="server" ErrorMessage="Salary Range"
                                ControlToValidate="txtSalaryRange">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
  <td align="right" width="50%" class="LoginHeadings"  valign="middle"><label> Salary Grade:</label></td>
   
     <td  valign="middle"> <asp:TextBox ID="txtSalaryGrade" runat="server" Width="200px" MaxLength="100" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"salary_Grade"))= "0"),"",(DataBinder.Eval(Container.DataItem,"salary_Grade")))%>'></asp:TextBox>
    </td>
    </tr>
    --%>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Applications Accepted From:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtAppFrom" runat="server" Width="175px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"App_Date_From")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReAppFrom" runat="server" ErrorMessage="Applications Accepted From"
                                ControlToValidate="txtAppFrom">*</asp:RequiredFieldValidator>
                            <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Applications Accepted Until:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtAppUntil" runat="server" Width="175px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"App_Date_To")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReAppUntil" runat="server" ErrorMessage="Applications Accepted To"
                                ControlToValidate="txtAppUntil">*</asp:RequiredFieldValidator>
                            <img id="img2" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Job Description:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtJobReq" runat="server" Width="200px" Height="175px" MaxLength="1000"
                                TextMode="MultiLine" Text='<%#DataBinder.Eval(Container.DataItem,"Job_Description")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReJobReq" runat="server" ErrorMessage="Job Requirements"
                                ControlToValidate="txtJobReq">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="ReeJobReq" ControlToValidate="txtJobReq" ErrorMessage="Can't exceed 2000 characters"
                                ValidationExpression="^[\s\S]{0,2000}$" runat="server" SetFocusOnError="true">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Contact Information:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtContactinfo" runat="server" Width="200px" MaxLength="1000" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"contact_information"))= "0"),"",(DataBinder.Eval(Container.DataItem,"contact_information")))%>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Is this job already posted on the NEO.gov Website?</label></td>
                        <td valign="middle">
                            <asp:RadioButtonList ID="rbtLink" CssClass="text2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList><asp:RequiredFieldValidator ID="Rerbtlink" runat="server" ErrorMessage="Link to the NEO.gov Website"
                                ControlToValidate="rbtLink">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="text2" valign="middle">
                            <label>
                                If yes, Full Job Description URL:<br />
                                (Government Jobs Link)</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtJobDescUrl" runat="server" Width="200px" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"JobDesc_URL"))= "0"),"",(DataBinder.Eval(Container.DataItem,"JobDesc_URL")))%>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="text2" valign="middle">
                            <label>
                                URL for "Apply Here" Link:<br />
                                (neo.gov link)</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtApplyLink" runat="server" Width="200px" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"JobApply_URL"))= "0"),"",(DataBinder.Eval(Container.DataItem,"JobApply_URL")))%>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnUpdate" CommandName="Update" CssClass="button" runat="server"
                                Text="Update this job" />&nbsp;
                        </td>
                        <td align="left">
                            &nbsp;<asp:Button ID="btnDelete" CommandName="Delete" CssClass="button" runat="server"
                                Text="Delete this job" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table width="500" border="0" align="center" cellpadding="2" cellspacing="10">
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
                            <asp:TextBox ID="txtJobTitle" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Job_Ttle")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReJobTitle" runat="server" ErrorMessage="Job Title"
                                ControlToValidate="txtJobTitle">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Salary Range:</label></td>
                        <td valign="middle" style="height: 47px">
                            <asp:TextBox ID="txtSalaryRange" runat="server" Width="200px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"Salary_Range")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReSalaryRange" runat="server" ErrorMessage="Salary Range"
                                ControlToValidate="txtSalaryRange">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%-- <tr>
  <td align="right" width="50%" class="LoginHeadings"  valign="middle"><label> Salary Grade:</label></td>
   
     <td  valign="middle"> <asp:TextBox ID="txtSalaryGrade" runat="server" Width="200px" MaxLength="100" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"salary_Grade"))= "0"),"",(DataBinder.Eval(Container.DataItem,"salary_Grade")))%>'></asp:TextBox>
    </td>
    </tr>--%>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Applications Accepted From:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtAppFrom" runat="server" Width="175px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"App_Date_From")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReAppFrom" runat="server" ErrorMessage="Applications Accepted From"
                                ControlToValidate="txtAppFrom">*</asp:RequiredFieldValidator>
                            <img id="img1" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Applications Accepted Until:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtAppUntil" runat="server" Width="175px" MaxLength="100" Text='<%#DataBinder.Eval(Container.DataItem,"App_Date_To")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReAppUntil" runat="server" ErrorMessage="Applications Accepted To"
                                ControlToValidate="txtAppUntil">*</asp:RequiredFieldValidator>
                            <img id="img2" style="width: 20px;" alt="Pick Date" src="../Images/datePickerPopup.gif"
                                class="image" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Job Description:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtJobReq" runat="server" Width="200px" Height="175px" MaxLength="1000"
                                TextMode="MultiLine" Text='<%#DataBinder.Eval(Container.DataItem,"Job_Description")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReJobReq" runat="server" ErrorMessage="Job Requirements"
                                ControlToValidate="txtJobReq">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="ReeJobReq" ControlToValidate="txtJobReq" ErrorMessage="Can't exceed 2000 characters"
                                ValidationExpression="^[\s\S]{0,2000}$" runat="server" SetFocusOnError="true">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Contact Information:</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtContactinfo" runat="server" Width="200px" MaxLength="1000" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"contact_information"))= "0"),"",(DataBinder.Eval(Container.DataItem,"contact_information")))%>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="LoginHeadings" valign="middle">
                            <label>
                                Is this job already posted on the NEO.gov Website?</label></td>
                        <td valign="middle">
                            <asp:RadioButtonList ID="rbtLink" CssClass="text2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList><asp:RequiredFieldValidator ID="Rerbtlink" runat="server" ErrorMessage="Link to the NEO.gov Website"
                                ControlToValidate="rbtLink">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="text2" valign="middle">
                            <label>
                                If yes, Full Job Description URL:<br />
                                (Government Jobs Link)</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtJobDescUrl" runat="server" Width="200px" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"JobDesc_URL"))= "0"),"",(DataBinder.Eval(Container.DataItem,"JobDesc_URL")))%>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%" class="text2" valign="middle">
                            <label>
                                URL for "Apply Here" Link:<br />
                                (neo.gov link)</label></td>
                        <td valign="middle">
                            <asp:TextBox ID="txtApplyLink" runat="server" Width="200px" Text='<%# IIF((convert.ToString(DataBinder.Eval(Container.DataItem,"JobApply_URL"))= "0"),"",(DataBinder.Eval(Container.DataItem,"JobApply_URL")))%>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnUpdate" CommandName="Update" CssClass="button" runat="server"
                                Text="Update this job" />&nbsp;
                        </td>
                        <td align="left">
                            &nbsp;<asp:Button ID="btnDelete" CommandName="Delete" CssClass="button" runat="server"
                                Text="Delete this job" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserById"
            UpdateMethod="Savenewuser" DeleteMethod="Savenewuser" TypeName="Users">
            <SelectParameters>
                <asp:ControlParameter ControlID="dplJobtitle" Name="userId" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter DefaultValue="Human Resources" Name="module_type" Type="String" />
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
