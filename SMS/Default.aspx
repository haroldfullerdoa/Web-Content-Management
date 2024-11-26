<%@ Page Language="VB" Theme="AdminPages" MasterPageFile="../CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Airport_SafetyManagement_admin_Default" title="Content Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="adminContainer">
        <div class="row">
            <div class="twelve columns">
                <asp:Button ID="lnkLogout" runat="server" CssClass="date-button left" CausesValidation="False" Visible="False" Text="Logout" />
                <h2 class="text-center">Safety Management System (SMS) - Admin Panel</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" ></asp:Label>
                <hr />
            </div>
        </div>

        <div class="row">
            <div  class="twelve columns">
                <table style="vertical-align:middle">
                    <tr>
                        <td>
                           <asp:HyperLink ID="hlReport" Target="_blank" NavigateUrl="~/SMS/Reports.aspx" runat="server">Reports Panel</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="hlForm" Target="_blank" NavigateUrl="http://www.atlanta-airport.com/airport/safetymanagement/sms-form.aspx" runat="server">Forms</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="hlSMSDoc" Target="_blank" NavigateUrl="http://intranet/PublicSafetyandSecurity/SafetyManagementSystem/default.aspx" runat="server">SMS Meeting Documents</asp:HyperLink>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
        <div class="row">
            <div class="twelve columns" style="padding-top:20px;">
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="twelve columns">
                


            </div>
        </div>
    </div>

</asp:Content>