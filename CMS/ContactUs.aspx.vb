Imports HJAIA2008.BusinessLogicLayer

Partial Class Summer_Intern_ContactUs
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblMessage.Text = ""
        Dim strName As String = txtYourName.Text.ToString().Trim()
        Dim strEmail As String = txtYourEmail.Text.ToString().Trim()
        If strEmail = "" Then
            strEmail = "webmaster@atlanta-airport.com"
        End If
        Dim strSubject As String = txtSubject.Text.ToString().Trim()
        Dim strMessage As String = txtMessage.Text.ToString().Trim() & "<br/> " & strName
        Util.SendMail(strEmail,System.Configuration.ConfigurationManager.AppSettings("MailFrom").ToString(), strSubject, strMessage,,True)
        lblMessage.Text = "Your Message has been sent."
        txtYourName.Text = ""
        txtYourEmail.Text = ""
        txtSubject.Text = ""
        txtMessage.Text = ""



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = ""
        Me.btnCancel.Attributes.Add("onclick", "javascript:window.close();")

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<script language='javascript'> { self.close() }</script>")
    End Sub
End Class
