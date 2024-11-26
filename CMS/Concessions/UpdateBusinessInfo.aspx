<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/SiteMaster.master" AutoEventWireup="false" CodeFile="UpdateBusinessInfo.aspx.vb" Inherits="UpdateBusinessInfo" title="Concessions - Edit Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <div class="tab" style="width: 100%;text-align:center;">&nbsp;</div>


    <table style="width: 100%;">
        <tr align="center">
            <td align="center" colspan = "2" style="width: 100%">
                <asp:Label ID="Label1" runat="server" Text="Supplier Number:" Font-Bold="True" ></asp:Label>
                <asp:TextBox ID="tbSupplierNumber" runat="server" Width="191px">
                </asp:TextBox>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Go" CausesValidation="False"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan= "2" style="width: 100%"><hr /></td>
        </tr>
        <tr>
            <td align="right" ><asp:label ID="Label2" Font-Bold="True" runat="server">Business Type:</asp:label></td>   
            <td style="width: 60%"><asp:DropDownList ID="ddlCompanyType" runat="server" 
                    DataSourceID="SqlDataSourceConcession" DataTextField="category" 
                    DataValueField="BusinessTypeID" >
                <asp:ListItem Value="">-- select one --</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStoreType" runat="server" ErrorMessage="Store Type has not been seleted" ControlToValidate="ddlCompanyType">*</asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSourceConcession" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConcessionsConnectionString %>" 
                    SelectCommand="SELECT * FROM [BusinessType]">
               </asp:SqlDataSource>
            </td>
         </tr>
        <tr>
            <td align="right" style="width:40%;" class="LoginHeadings">
                <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                <asp:label ID="Label3" runat="server" Font-Bold="True">Company Name:</asp:label>
            </td>          
            <td style="width:60%;">
                <asp:TextBox ID="tbCompanyName" runat="server" 
                    Width="300px" MaxLength="100" AutoCompleteType="Company"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="Company Name is blank" ControlToValidate="tbCompanyName">*</asp:RequiredFieldValidator>
            </td>
          </tr>
  
          <tr>
            <td align="right" style="width:40%;" class="LoginHeadings"><label>Street Address:</label></td>
            <td style="width:60%;">
                <asp:TextBox ID="tbStreetAddress" runat="server" 
                    Width="531px" MaxLength="250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStreetAddress" runat="server" 
                    ErrorMessage="Street address is required" ControlToValidate="tbStreetAddress">*</asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td align="right" style="width:40%;" class="LoginHeadings"><label>City:</label></td>
            <td style="width:60%;">
                <asp:TextBox ID="tbCity" runat="server" 
                    Width="305px" MaxLength="250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                    ErrorMessage="City is required" ControlToValidate="tbCity">*</asp:RequiredFieldValidator>
            </td>
          </tr>
                    <tr>
            <td align="right" style="width:40%;" class="LoginHeadings">
                <asp:Label ID="lbState" runat="server" Text="State:"></asp:Label>
                &nbsp;</td>
            <td style="width:60%;">
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AK</asp:ListItem>
                    <asp:ListItem>AZ</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CO</asp:ListItem>
                    <asp:ListItem>CT</asp:ListItem>
                    <asp:ListItem>DE</asp:ListItem>
                    <asp:ListItem>DC</asp:ListItem>
                    <asp:ListItem>FM</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem Selected="True">GA</asp:ListItem>
                    <asp:ListItem>GU</asp:ListItem>
                    <asp:ListItem>HI</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>IL</asp:ListItem>
                    <asp:ListItem>IN</asp:ListItem>
                    <asp:ListItem>IA</asp:ListItem>
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>
                    <asp:ListItem>LA</asp:ListItem>
                    <asp:ListItem>ME</asp:ListItem>
                    <asp:ListItem>MH</asp:ListItem>
                    <asp:ListItem>MD</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MI</asp:ListItem>
                    <asp:ListItem>MN</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MO</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem>
                    <asp:ListItem>NV</asp:ListItem>
                    <asp:ListItem>NM</asp:ListItem>
                    <asp:ListItem>NY</asp:ListItem>
                    <asp:ListItem>NC</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>MP</asp:ListItem>
                    <asp:ListItem>OH</asp:ListItem>
                    <asp:ListItem>OK</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>RI</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SD</asp:ListItem>
                    <asp:ListItem>TN</asp:ListItem>
                    <asp:ListItem>UT</asp:ListItem>
                    <asp:ListItem>VT</asp:ListItem>
                    <asp:ListItem>VI</asp:ListItem>
                    <asp:ListItem>VA</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>WV</asp:ListItem>
                    <asp:ListItem>WI</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
                <td align="right" style="width:40%;" class="LoginHeadings">
                <asp:label ID="lbZipCode" runat="server">Zip Code:</asp:label>
            </td>
            <td style="width:60%;">
                <asp:TextBox ID="tbZipCode" runat="server" 
                    Width="114px" MaxLength="5" AutoCompleteType="BusinessZipCode"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" 
                    ErrorMessage="Zip Code is required" ControlToValidate="tbZipCode">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revZipCode" runat="server" 
                    ControlToValidate="tbZipCode" ErrorMessage="Valid 5 digital zip code only!" 
                    ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
            </td>
          </tr>
          <tr>
               <td align="right" class="LoginHeadings"><label>Business Email:</label></td>
               <td style="width: 60%">
                   <asp:TextBox ID="tbBusinessEmail" runat="server" Width="420px" MaxLength="150" AutoCompleteType="BusinessPhone" />  
                   <asp:RequiredFieldValidator ID="rfvBusinessEmail" runat="server" ErrorMessage="Business email is required!" ControlToValidate="tbBusinessEmail">*</asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="revBusinessEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Must be a valid email address!" ControlToValidate="tbBusinessEmail"></asp:RegularExpressionValidator>
            </td>
          </tr>  
          <tr>
               <td align="right" class="LoginHeadings"><label>Business Website:</label></td>
               <td style="width: 60%">
                   <asp:TextBox ID="tbIPAddress" runat="server" Width="431px" MaxLength="200" 
                       AutoCompleteType="BusinessUrl" ></asp:TextBox>
                   <asp:RegularExpressionValidator ID="revWebsite" runat="server" 
                       ErrorMessage="Not Valid url! i.e. http://mysite.com" 
                       ControlToValidate="tbIPAddress" 
                       ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
              </td>
          </tr>
          <tr>
               <td align="right" class="LoginHeadings"><label>Business Phone Number:</label></td>
               <td style="width: 60%"><asp:TextBox ID="tbBusinessPhone" runat="server" 
                       Width="175px" MaxLength="14" 
                       AutoCompleteType="BusinessPhone" />    
                   <asp:RequiredFieldValidator ID="rfvBusinessPhone" runat="server" ErrorMessage="Business phone is required" ControlToValidate="tbBusinessPhone">*</asp:RequiredFieldValidator>       
                   <asp:RegularExpressionValidator ID="revBusinessPhone" runat="server" 
                       ControlToValidate="tbBusinessPhone" ErrorMessage="xxx-xxx-xxxx" 
                       ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
               </td>
          </tr>  
          <tr>
            <td valign="top" align="right" class="LoginHeadings">
                <label>Business&nbsp; Description (Service or Productions Offered):</label></td>
            <td style="width: 60%">
                <asp:TextBox ID="txtBusinessDescription" runat="server" 
                    Width="553px" Rows="8" MaxLength="2000" TextMode="MultiLine" Wrap="False" 
                    CssClass="MultiLineTextBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revCompanyDescription" runat="server" ErrorMessage="Business description is required" ControlToValidate="txtBusinessDescription">*</asp:RequiredFieldValidator>
            </td>
          </tr>
            <tr>
               <td align="right" class="LoginHeadings"><label>Contact Full Name:</label></td>
               <td style="width: 60%"><asp:TextBox ID="tbContactName" runat="server" Width="250px" MaxLength="200" ></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ErrorMessage="Contact Person's Name is required!" ControlToValidate="tbContactName">*</asp:RequiredFieldValidator>
              </td>
            </tr> 
               <tr>
               <td align="right" class="LoginHeadings"><label>Contact Phone Number:</label></td>
               <td style="width: 60%"><asp:TextBox ID="tbContactNumber" runat="server" Width="250px" MaxLength="200" 
                       AutoCompleteType="HomePhone" ></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ErrorMessage="Contact phone Number is required!" ControlToValidate="tbContactNumber">*</asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="revContactPhone" runat="server" 
                       ControlToValidate="tbContactNumber" ErrorMessage="xxx-xxx-xxxx" 
                       ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
              </td>
            </tr>   
            <tr>
               <td align="right" class="LoginHeadings"><label>Contact Email Address:</label></td>
               <td style="width: 60%"><asp:TextBox ID="tbContactEmail" runat="server" Width="250px" MaxLength="200" 
                       AutoCompleteType="Email" ></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvContactEmail" runat="server" ErrorMessage="Contact person's email is required!" ControlToValidate="tbContactEmail">*</asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="revContactEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Must be a valid email address!" ControlToValidate="tbContactEmail"></asp:RegularExpressionValidator>
                   <br />
              </td>
            </tr>    
            <tr>
               <td align="right" class="LoginHeadings"><label>Are you a DBE?</label></td>
               <td class="style2" style="height: 41px">
                       <asp:CheckBox ID = "chkDBE" runat="server"></asp:CheckBox>
               </td>
            </tr>    
        <tr>
            <td align="right" class="LoginHeadings"><label>Active Status</label> </td>
            <td align="left"><asp:CheckBox ID="cbActiveStatus" runat="server" /> </td>
        </tr>
        <tr>
            <td align="center" class="LoginHeadings" colspan="2">
                <asp:Button ID="btnUpdate" runat="server" Text="Save" />
            &nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" />
            &nbsp;</td>
        </tr>
    </table>

</asp:Content>