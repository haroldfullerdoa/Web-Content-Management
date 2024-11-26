
Partial Class CMS_MasterScreens_SiteMaster
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("Student_Id") = Nothing Then
        '    Response.Redirect("../LoginUser.aspx")

        'End If

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

