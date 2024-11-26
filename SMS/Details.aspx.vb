Imports HJAIA2008.BusinessLogicLayer
Partial Class Airport_SafetyManagement_admin_Details
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'verify authentication
        If Page.IsPostBack = False Then

            Dim strTID As String = Request.QueryString("tid")
            If String.IsNullOrEmpty(strTID) Then
                lbTitle.Text = "Please select an event report to view this page"
                lbTitle.ForeColor = Drawing.Color.Red
                btnBack.PostBackUrl = "Default.aspx"
            Else
                lbTitle.Text &= strTID
                lbTitle.ForeColor = Drawing.Color.Black
                btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;")
            End If


            Dim authCookie1 As HttpCookie = Session("SMS")
            If (Not authCookie1 Is Nothing) Then
                Me.VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("~/SMS/Login.aspx")
                End If
            Else
                Me.VisiblLogOut = False
                Response.Redirect("~/SMS/Login.aspx")
            End If
        End If

        lblMessage.Text = ""

    End Sub

    Public WriteOnly Property VisiblLogOut() As Boolean
        Set(ByVal value As Boolean)
            lnkLogOut.Visible = value
        End Set
    End Property

    Protected Sub lnkLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Session.Abandon()
        Session.Clear()
        Response.Redirect("~/Default.aspx")
        lnkLogout.Visible = False
    End Sub
End Class