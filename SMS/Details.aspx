<%@ Page Language="VB" Theme="AdminPages" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Airport_SafetyManagement_admin_Details" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <AspAjax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </AspAjax:ToolkitScriptManager>
<!-- Main Container -->
    <div class="adminContainer">
        <div class="row">
            <div class="twelve columns">
                <asp:Button ID="lnkLogout" runat="server" CssClass="date-button left" CausesValidation="False" Visible="False" Text="Logout" />
                <h2 class="text-center">Safety Management System (SMS) - <asp:Label ID="lbTitle" runat="server" ForeColor="Blue" /></h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" ></asp:Label>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="twelve columns">
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnBack" />
            </div>
        </div>
        <div class="row">
            <div class="twelve columns">

                <asp:DetailsView ID="adminDetails" runat="server" 
                    AutoGenerateRows="False" DataKeyNames="TRACKING_NUMBER" 
                    DataSourceID="SqlDataSourceSMS" EnableModelValidation="True">
                    <Fields>
                        <asp:BoundField DataField="TRACKING_NUMBER" HeaderText="Tracking Number: " ReadOnly="True" SortExpression="TRACKING_NUMBER" />
                        <asp:BoundField DataField="REPORT_DATE" HeaderText="Report Date: " SortExpression="REPORT_DATE" DataFormatString="{0:g}" />
                        <asp:BoundField DataField="CONTACT_TYPE" HeaderText="Contact Type: " SortExpression="CONTACT_TYPE" />
                        <asp:BoundField DataField="EVENT_DATE" HeaderText="Event Date: " SortExpression="EVENT_DATE" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="EVENT_TIME" HeaderText="Event Time: " SortExpression="EVENT_TIME"  />
                        <asp:BoundField DataField="EMPLOYEE_TYPE" HeaderText="Employee Type: " SortExpression="EMPLOYEE_TYPE" />
                        <asp:BoundField DataField="EVENT_TYPE" HeaderText="Event Type: " SortExpression="EVENT_TYPE" />
                        <asp:BoundField DataField="EVENT_LOCATION" HeaderText="Event Location: " SortExpression="EVENT_LOCATION" />
                        <asp:BoundField DataField="ITEMS_INVOLVED" HeaderText="Items Involved: " />
                        <asp:BoundField DataField="VISIBILITY" HeaderText="Visibility: " SortExpression="VISIBILITY" />
                        <asp:BoundField DataField="WEATHER_CONDITION" HeaderText="Weather Conditions: " SortExpression="WEATHER_CONDITION" />
                        <asp:BoundField DataField="EVENT_DESCRIPTION" HeaderText="Event Description: " />
                        <asp:BoundField DataField="EVENT_RECOMMENDATIONS" HeaderText="Event Recommendation: " />
                        <asp:BoundField DataField="REPORTER_NAME" HeaderText="Reporter's Name: " SortExpression="REPORTER_NAME" />
                        <asp:BoundField DataField="REPORTER_ORGANIZATION" HeaderText="Reporter's Organization: " />
                        <asp:BoundField DataField="REPORTER_POSITION" HeaderText="Reporter's Position: " />
                        <asp:BoundField DataField="REPORTER_ADDRESS" HeaderText="Reporter's Address: " />
                        <asp:BoundField DataField="REPORTER_CITY" HeaderText="Reporter's City: " />
                        <asp:BoundField DataField="REPORTER_STATE" HeaderText="Reporter's State: " />
                        <asp:BoundField DataField="REPORTER_ZIP" HeaderText="Reporter's Zip: " />
                        <asp:BoundField DataField="REPORTER_EMAIL" HeaderText="Reporter's Email: " />
                        <asp:BoundField DataField="REPORTER_PHONE1" HeaderText="Reporter's PhoneA: " />
                        <asp:BoundField DataField="REPORTER_PHONE2" HeaderText="Reporter's PhoneB: " />
                    </Fields>
                </asp:DetailsView>

                <asp:SqlDataSource ID="SqlDataSourceSMS" runat="server" 
                    SelectCommand="SELECT * FROM &quot;SMS_DATA&quot; WHERE (&quot;TRACKING_NUMBER&quot; = :TRACKING_NUMBER)" 
                    ConnectionString="<%$ ConnectionStrings:DOAINT %>" 
                    ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="TRACKING_NUMBER" QueryStringField="tid" 
                            Type="String" />
                    </SelectParameters>
                
                </asp:SqlDataSource>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
