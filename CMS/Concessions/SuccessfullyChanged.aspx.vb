Imports HJAIA2008.BusinessLogicLayer

Partial Class SuccessfullyChanged
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Not Page.IsPostBack Then
            Dim authCookie1 As HttpCookie = Session("Concession")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True 'display Log Out link
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("default.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("default.aspx")
            End If

            lblMessage.Text = Request.QueryString("company") & " has been successfully " & Request.QueryString("change") & "."
        End If
    End Sub

End Class
