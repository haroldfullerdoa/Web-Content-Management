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

        lblMessage.Text = ""

    End Sub


    Protected Sub btnDateQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDateQuery.Click
        gdvSMS.DataBind()
        If gdvSMS.Rows.Count > 0 Then
            btnExcel.Visible = True
        Else
            btnExcel.Visible = False
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Response.Redirect("Excel.aspx?sDate=" & txtFromDate.Text & "&eDate=" & txtToDate.Text, False)
    End Sub

    'Protected Sub hypForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hypForm.Click
    '    Response.Redirect("http://haiatest/Airport/SafetyManagement/SMS-Form.aspx")
    '    'Response.Redirect("http://www.atlanta-airport.com/Airport/SafetyManagement/SMS-Form.aspx")
    'End Sub

End Class
