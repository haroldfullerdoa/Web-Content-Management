
Partial Class CMS_Admin_EditUSer
    Inherits System.Web.UI.Page
    Dim newuser As Users

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("Admin")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("Admin.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("Admin.aspx")

            End If
        End If
        lblMessage.Text = ""

    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        Dim task As String = e.CommandName
        FormView1.ChangeMode(FormViewMode.Edit)
        Dim row As FormViewRow = FormView1.Row
        Dim txtName As TextBox = CType(row.FindControl("txtName"), TextBox)
        Dim txtEmail As TextBox = CType(row.FindControl("txtEmail"), TextBox)
        Dim rbtUnit As RadioButtonList = CType(row.FindControl("rbtUnit"), RadioButtonList)

        Try
            newuser = New Users(dplName.SelectedValue, txtName.Text, txtEmail.Text, rbtUnit.SelectedValue, task, DefaultValues.Admin)
            Session.Add("USER", newuser)
        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))


        Finally
            If task = "Update" Then
                lblMessage.Text = "User '" & dplName.SelectedItem.Text & "' Details Are Updated"

            Else
                lblMessage.Text = "User '" & txtName.Text & "' is deleted from '" & rbtUnit.SelectedValue & "'"

            End If
        End Try
    End Sub

    Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
        dplName.Items.Clear()
        Dim dplitem As New ListItem("Select User--", "0")
        dplName.Items.Add(dplitem)
        dplName.SelectedValue = "0"
        dplName.DataBind()
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        dplName.Items.Clear()
        Dim dplitem As New ListItem("Select User--", "0")
        dplName.Items.Add(dplitem)
        dplName.SelectedValue = "0"
        dplName.DataBind()
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        Try
            Dim radiolist As New RadioButtonList
            radiolist = CType(FormView1.FindControl("RbtUnit"), RadioButtonList)
            If Page.IsPostBack = True And dplName.SelectedValue <> "0" Then
                radiolist.SelectedValue = DataBinder.Eval(FormView1.DataItem, "Admin_Unit")
            End If
        Catch ex As NullReferenceException

        End Try

    End Sub
End Class
