
Partial Class SummerIntern_ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim LastError As Exception
        Dim ErrorMessage As String
        LastError = Server.GetLastError()
        If LastError IsNot Nothing Then
            ErrorMessage = LastError.Message
            lblError.Text = ErrorMessage
        End If
        lblError.Text = Request.QueryString("error").ToString()
    End Sub
End Class
