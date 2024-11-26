Imports HJAIA2008.BusinessLogicLayer

Partial Class Airport_SafetyManagement_admin_Default
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'verify authentication
            If Page.IsPostBack = False Then
                Dim authCookie1 As HttpCookie = Session("SMS")
                If (Not authCookie1 Is Nothing) Then
                    Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                    If authTicket1.Expired = True Then
                        Response.Redirect("~/SMS/Login.aspx")
                    End If
                Else
                    Response.Redirect("~/SMS/Login.aspx")
                End If
            End If


        End Sub
    End Class

