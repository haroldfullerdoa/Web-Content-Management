<%@ Page Language="VB" Theme="AdminPages" AutoEventWireup="false" CodeFile="Reports.aspx.vb" Inherits="Airport_SafetyManagement_admin_Default" %>
<!DOCTYPE html>
<!-- paulirish.com/2008/conditional-stylesheets-vs-css-hacks-answer-neither/ -->
<!--[if lt IE 7]> <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]>    <html class="no-js lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]>    <html class="no-js lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js" lang="en"> <!--<![endif]-->
<head runat="server">
    <title>Safety Management System Reports Panel</title>

</head>
<body>
    <form id="form1" runat="server">
        <AspAjax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </AspAjax:ToolkitScriptManager>
<!-- Main Container -->
    <div class="adminContainer">
        <div class="row">
            <div class="twelve columns">
                <asp:Button ID="lnkClose" runat="server" CssClass="date-button left" CausesValidation="False" Text="Close"  OnClientClick="javascript:window.close();" />
                <h2 class="text-center">Safety Management System (SMS) - Reports Panel</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle" ></asp:Label>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="twelve columns">
                <div style="margin-left: 35%;">
                    <div style="display:inline-block;float:left;">
                        <asp:Label ID="lblFromDate" runat="server" Text="From Date:" CssClass="label"></asp:Label>
                        <asp:TextBox ID="txtFromDate" runat="server" Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="imgCalFrom" runat="server" CssClass="cal-image" ImageUrl="~/Images/datePickerPopup.gif" />
                        <AspAjax:CalendarExtender ID="calFromDate" runat="server" TargetControlID="txtFromDate" Format="MM/dd/yyyy" PopupButtonID="imgCalFrom" PopupPosition="BottomLeft" ></AspAjax:CalendarExtender>
                    </div>
                    <div style="display:inline-block;float:left;">
                        <asp:Label ID="lblToDate" runat="server" Text="To Date:" CssClass="label"></asp:Label>
                        <asp:TextBox ID="txtToDate" runat="server" Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="imgCalTo" runat="server" CssClass="cal-image" ImageUrl="~/Images/datePickerPopup.gif"  />
                        <AspAjax:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate" Format="MM/dd/yyyy" PopupButtonID="imgCalTo" PopupPosition="BottomLeft"></AspAjax:CalendarExtender>
                    </div>
                    <div style="display:inline-block;float:left;">
                        <asp:Button ID="btnDateQuery" runat="server" Text="Submit" CssClass="date-button" />
                        <asp:Button ID="btnExcel" runat="server" Text="Download Data" Visible="false" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="twelve columns" style="padding-top:20px;">
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="twelve columns">
                <asp:GridView ID="gdvSMS" runat="server" DataKeyNames="TRACKING_NUMBER" 
                    DataSourceID="sqlDataSourceSMS" AllowSorting="True" 
                    AllowPaging="True" PageSize="50" AutoGenerateColumns="False" 
                    EnableModelValidation="True" CssClass="gvMain" 
                    GridLines="None">

<AlternatingRowStyle CssClass="gvAlternatingRow"></AlternatingRowStyle>

                    <Columns>
                        <asp:BoundField DataField="TRACKING_NUMBER" HeaderText="Tracking#" ReadOnly="True" SortExpression="TRACKING_NUMBER" />
                        <asp:BoundField DataField="EVENT_DATE" HeaderText="Date" SortExpression="EVENT_DATE" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="EVENT_TIME" HeaderText="Time" SortExpression="EVENT_TIME"  />
                        <asp:BoundField DataField="CONTACT_TYPE" HeaderText="Contact" SortExpression="CONTACT_TYPE" />
                        <asp:BoundField DataField="EMPLOYEE_TYPE" HeaderText="Employee" SortExpression="EMPLOYEE_TYPE" />
                        <asp:BoundField DataField="EVENT_TYPE" HeaderText="Type" SortExpression="EVENT_TYPE" />
                        <asp:BoundField DataField="EVENT_LOCATION" HeaderText="Location" SortExpression="EVENT_LOCATION" />
                        <asp:BoundField DataField="VISIBILITY" HeaderText="Visibility" SortExpression="VISIBILITY" />
                        <asp:BoundField DataField="WEATHER_CONDITION" HeaderText="Weather" SortExpression="WEATHER_CONDITION" />
                        <asp:BoundField DataField="REPORTER_NAME" HeaderText="Name" SortExpression="REPORTER_NAME" />
                        <asp:BoundField DataField="REPORT_DATE" HeaderText="Report Date" SortExpression="REPORT_DATE" DataFormatString="{0:g}" />
                        <asp:HyperLinkField DataNavigateUrlFields="TRACKING_NUMBER" 
                            DataNavigateUrlFormatString="Details.aspx?tid={0}" HeaderText="Details" 
                            NavigateUrl="Details.aspx?id=" Text="View details..." />
                    </Columns>

                    <EditRowStyle CssClass="gvEditRow" />

<EmptyDataRowStyle CssClass="gvEmptyRow"></EmptyDataRowStyle>
                        <EmptyDataTemplate>
                            There is no information matching your query.
                        </EmptyDataTemplate>
                    <FooterStyle CssClass="gvFooter" />
                    <HeaderStyle CssClass="gvHeader" />
                    <PagerStyle CssClass="gvPager" />
                    <RowStyle CssClass="gvRow" />
                    <SelectedRowStyle CssClass="gvSelectedRow" />
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSourceSMS" runat="server" 
                    SelectCommand="SELECT TRACKING_NUMBER, REPORT_DATE, CONTACT_TYPE, EVENT_DATE, EVENT_TIME, EMPLOYEE_TYPE, EVENT_TYPE, EVENT_LOCATION, VISIBILITY, WEATHER_CONDITION, REPORTER_NAME FROM SMS_DATA WHERE ((&quot;EVENT_DATE&quot; &gt; :EVENT_DATE) AND (&quot;EVENT_DATE&quot; &lt; :EVENT_DATE2)) ORDER BY EVENT_DATE, EVENT_TIME" 
                    ConnectionString="<%$ ConnectionStrings:DOAINT %>" 
                    ProviderName="<%$ ConnectionStrings:DOAINT.ProviderName %>">
                
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtFromDate" Name="EVENT_DATE" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtToDate" Name="EVENT_DATE2" PropertyName="Text" Type="DateTime" />
                    </SelectParameters>
                
                </asp:SqlDataSource>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
