Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Web


Namespace HJAIA2008.BusinessLogicLayer
    Public Class Util

#Region "Email"

        ''' <summary>
        ''' This function is a utility to send emails obtaining the smtp server from configuration file
        '''</summary>
        Public Shared Sub SendMail(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strMessage As String, Optional ByVal strCC As String = "", Optional ByVal IsBodyHtml As Boolean = False)
            '(0)get the email addresses and set the defaul values  
            If strFrom Is Nothing Or String.IsNullOrEmpty(strFrom) Then strFrom = System.Configuration.ConfigurationManager.AppSettings("SiteWebmasterEmail")
            If strTo Is Nothing Or String.IsNullOrEmpty(strTo) Then strTo = System.Configuration.ConfigurationManager.AppSettings("SiteWebmasterEmail")
            If strSubject Is Nothing Or String.IsNullOrEmpty(strSubject) Then strSubject = "One Email from Website User"

            '(1) Create the MailMessage instance
            Dim mm As New MailMessage(strFrom, strTo)

            '(2) Assign the MailMessage's properties
            mm.Subject = strSubject

            'add Carbon Copy recipents
            If strCC IsNot Nothing And Not String.IsNullOrEmpty(strCC) Then mm.CC.Add(strCC)

            'to detect whether we should use the HTML format
            mm.IsBodyHtml = IsBodyHtml
            If IsBodyHtml Then
                Dim myUtil As New Util
                strMessage = myUtil.EmailHeader() & strMessage & myUtil.EmailFooter()
            End If
            mm.Body = strMessage


            '(3) Create the SmtpClient object and use Web.config's settings
            Dim smtp As New SmtpClient
            'add authentication info
            smtp.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
            'smtp.Host = System.Configuration.ConfigurationManager.AppSettings("SmtpServer").ToString() '"localhost"
            '(4) Send the MailMessage
            smtp.Send(mm)

        End Sub

        Public Shared Function UserInformation(ByVal ClientIP As String, ByVal ClientBrowser As String, ByVal UrlReferrer As String) As String
            Dim StrMessage As String = "<br/><br/><hr/>"
            StrMessage &= "<h5>User Information:</h5> "
            StrMessage &= "<b>IP:</b> " & ClientIP & "<br/>"
            StrMessage &= "<b>Client Browser:</b> " & ClientBrowser & "<br/>"
            StrMessage &= "<b>URL Referrer:</b> " & UrlReferrer & "<br/>"
            Return StrMessage
        End Function

        Protected Function EmailHeader() As String
            Dim header As String = ""
            header = "<html><head><title>" + System.Web.Configuration.WebConfigurationManager.AppSettings("SiteTitle") + "</title>"
            header &= "<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1""></head><body><br>"
            header &= "<table width=""600"" align=""center"" style=""border:1px solid #CCCCCC; font-family:Arial, Helvetica, sans-serif; font-size:12px"" cellpadding=""0"" cellspacing=""5"">"
            header &= "<tr><td><h2 style='background-color:#C3C3C3'>Hartsfield-Jackson Atlanta International Airport</h2></td></tr><tr><td>"
            Return header
        End Function

        Protected Function EmailFooter() As String
            Dim footer As String = ""
            footer = "</td></tr><tr>"
            footer &= "<td height=""20""></td></tr><tr><td>Thank-you!<br><br>"
            footer &= "<tr><td style=""color: #999;"">This is an automated message. Please do not reply. Contact " + System.Web.Configuration.WebConfigurationManager.AppSettings("ContactUs") + " for further assistance.</td></tr>"
            footer &= "<tr><td height=""10""></td></tr></table></body></html>"
            Return footer
        End Function

#End Region


#Region "VerificationCode"

        Public Shared Function generateVCode(ByVal CodeLength As Integer) As String
            Dim strArray As String = "2346789ABDEFGHJLMNQRTYabdefghjmnpqrty"
            Dim VCode As String = String.Empty
            Dim randObj As New Random()
            Dim l As Integer = (strArray.Length() - 1)
            Dim c As Integer = 0
            For i As Byte = 1 To CodeLength
                c = randObj.Next(l) '61 is the max range
                VCode += strArray.Substring(c, 1)
            Next
            Return VCode
        End Function

        Public Shared Function generateHatchStyle() As Drawing.Drawing2D.HatchStyle
            Dim slist As New ArrayList
            For Each style As Drawing.Drawing2D.HatchStyle In System.Enum.GetValues(GetType(Drawing.Drawing2D.HatchStyle))
                slist.Add(style)
            Next

            Dim randObj As New Random()
            Dim index As Integer = randObj.Next(slist.Count - 1)

            Return CType(slist(index), Drawing.Drawing2D.HatchStyle)
        End Function

        'Public Property verificationCode()
        '    Get
        '        Return Session("VCode")
        '    End Get
        '    Set(ByVal value)
        '        Session.Add("VCode", value)
        '    End Set
        'End Property
#End Region

    End Class
End Namespace