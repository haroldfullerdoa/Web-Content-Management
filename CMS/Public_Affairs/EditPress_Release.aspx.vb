Imports System.Web.UI.Control
Partial Class CMS_Admin_EditUSer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("PublicAffairs")
            Dim time As Integer = Session.Timeout
            Dim mode As String = Session.Mode
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("Public_Affairs.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("Public_Affairs.aspx")
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        Dim task As String = e.CommandName
        FormView1.ChangeMode(FormViewMode.Edit)
        Dim row As FormViewRow = FormView1.Row
        Dim txtPressTitle As TextBox = CType(row.FindControl("txtPressTitle"), TextBox)
        Dim txtDate As TextBox = CType(row.FindControl("txtDate"), TextBox)
        Dim txtArticle As TextBox = CType(row.FindControl("txtArticle"), TextBox)

        Try
            Dim newuser As Users
            newuser = New Users(dplPressTitle.SelectedValue, txtPressTitle.Text, txtDate.Text, txtArticle.Text, task, DefaultValues.Press_News, "Press_Release")
            Session.Add("USER", newuser)
        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))


        Finally
            If task = "Update" Then
                lblMessage.Text = "Press Note is updated"

            Else
                lblMessage.Text = "Press Note is Deleted"

            End If
        End Try
    End Sub
    Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
        dplPressTitle.Items.Clear()
        Dim dplitem As New ListItem("Select Press Title--", "0")
        dplPressTitle.Items.Add(dplitem)
        dplPressTitle.SelectedValue = "0"
        dplPressTitle.DataBind()
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        dplPressTitle.Items.Clear()
        Dim dplitem As New ListItem("Select Press Title--", "0")
        dplPressTitle.Items.Add(dplitem)
        dplPressTitle.SelectedValue = "0"
        dplPressTitle.DataBind()
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        Try
            If FormView1.DataItemCount <> Nothing Then
                Dim row As FormViewRow = FormView1.Row
                Dim img2 As HtmlImage = CType(row.FindControl("img1"), HtmlImage)
                Dim txtdate As TextBox = CType(row.FindControl("txtDate"), TextBox)
                img2.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtdate.ClientID + ");")
            End If
        Catch ex As NullReferenceException


        End Try

    End Sub
End Class
