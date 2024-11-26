<%@ Page Language="VB" MasterPageFile="~/CMS/MasterScreens/login.master" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="Summer_Intern_ContactUs" 
title="Hartsfield-Jackson Atlanta International Airport-Contact Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 37%;">
        <tr align="center">
        <td  style="height: 6%" align="right">
                <asp:Image ID="imgLogo" ImageUrl="~/CMS/Images/haia_logo_trans.gif" runat="server" />&nbsp;
            </td>
          <td  style="font-size:larger; height: 20px;" align="left"  valign="middle">
              &nbsp;<b>Contact Us</b> 
                       
            </td>
                   
        </tr>
          <tr>
            <td colspan="2" style="height: 6%">
                <hr />
            </td>
        </tr>
       
        </table>
           <table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 37%;"> 
           <tr><td align="left">
           <table border="0" align="left" cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr >
            <td align="center" colspan="2">
                <asp:ValidationSummary ID="vSummary" runat="server" HeaderText="Please enter the following details" />
            </td>
            </tr> 
            
       
         <tr>
            <td align="right"  >
                <b>Your Name:</b>&nbsp;
            </td>
            <td align="left" style="width: 200px"  >
                <asp:TextBox ID="txtYourName" runat="server" Width="175px" MaxLength="100" EnableViewState="False"></asp:TextBox><asp:RequiredFieldValidator ID="ReName" runat="server" ErrorMessage="Your Name"
                    ControlToValidate="txtYourName">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
         <tr>
            <td colspan="2" style="height: 6%">
                &nbsp;
            </td>
        </tr>
        
        <tr>
            <td align="right" class="SideHeading" >
                <b>Your E-mail:</b>&nbsp;
            </td>
            <td align="left" style="width: 200px" >
                <asp:TextBox ID="txtYourEmail" runat="server" Width="175px" MaxLength="100" EnableViewState="False"></asp:TextBox><asp:RegularExpressionValidator
                    ID="REEEMail" runat="server" ErrorMessage="Check the format" ControlToValidate="txtYourEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>&nbsp;
            </td>
        </tr>
        
         <tr>
            <td colspan="2" style="height: 6%">
                &nbsp;
            </td>
        </tr>
        
         <tr>
            <td align="right" class="SideHeading" >
               <b> Subject:</b>&nbsp;
            </td>
            <td align="left" style="width: 200px" >
                <asp:TextBox ID="txtSubject" runat="server" Width="175px" MaxLength="100" EnableViewState="False"></asp:TextBox>&nbsp;
            </td>
        </tr>
        
         <tr>
            <td colspan="2" style="height: 6%">
                &nbsp;
            </td>
        </tr>
        
        <tr>
            <td align="right" class="SideHeading" >
               <b> Message:</b>&nbsp;
            </td>
            <td align="left" style="width: 200px" >
                <asp:TextBox ID="txtMessage" runat="server" Width="175px" TextMode="MultiLine" MaxLength="1000" EnableViewState="False"></asp:TextBox><asp:RequiredFieldValidator ID="ReMessage" runat="server" ErrorMessage="Message" ControlToValidate="txtMessage">*</asp:RequiredFieldValidator>&nbsp;
            </td>
        </tr>
         <tr>
            <td colspan="2" style="height: 6%">
                &nbsp;
            </td>
        </tr>
       
         <tr>
            <td colspan="2" class="signup" align="center">
                <asp:Label ID="lblMessage" runat="server" CssClass="PageTitle"></asp:Label>
            </td>
        </tr>
        
         <tr>
            <td colspan="2" class="signup">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td  align="right"  >
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" />&nbsp;
            </td>
           <td  align="left"  >
               &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        </table>
        </td></tr>
    </table>
</asp:Content>

