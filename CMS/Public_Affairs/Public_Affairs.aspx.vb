Imports UserAuthentication
Partial Class CMS_Admin_AddUser
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify Session
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("PublicAffairs")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = False Then
                    Response.Redirect("AddPressRelease.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
            End If
        End If

        lblMessage.Text = ""
    End Sub

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Try
            Dim domain As String = ConfigurationManager.AppSettings("Domain")

            If (Users.Login_Verify(txtUserName.Text, DefaultValues.Press_News) = True) Then
                If Me.AutenticateUser(domain, txtUserName.Text, txtPassword.Text) = True Then
                    Response.Redirect("AddPressRelease.aspx")
                End If
            Else
                lblMessage.Text = "User does not exist in the '" & DefaultValues.Press_News & "' Group. Please Contact Administrator"
            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message
            lblMessage.Visible = True
        End Try
    End Sub
    Private Function AutenticateUser(ByVal domainName As String, ByVal userName As String, ByVal password As String) As Boolean
        ' Path to you LDAP directory server.
        ' Contact your network administrator to obtain a valid path.


        Dim adPath As String = "LDAP://" + System.Configuration.ConfigurationManager.AppSettings("DefaultActiveDirectoryServer")


        Dim adAuth As New ActiveDirectoryValidator(adPath)
        If True = adAuth.IsAuthenticated(domainName, userName, password) Then
            ' Create the authetication ticket
            Dim authTicket As New FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(120), False, "")
            ' Now encrypt the ticket.
            Dim encryptedTicket As String = FormsAuthentication.Encrypt(authTicket)
            ' Create a cookie and add the encrypted ticket to the
            ' cookie as data.
            Dim authCookie As New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)

            ' Add the cookie to the outgoing cookies collection.
            Session.Add("PublicAffairs", authCookie)
            Return True
        Else
            Return False
        End If



    End Function

End Class
