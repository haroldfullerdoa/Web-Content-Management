
Partial Class CMS_Admin_PreviewAdmin
    Inherits System.Web.UI.Page
    Dim newuser As New Users

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            newuser = Context.Items("AddUser")
            lblName.Text = newuser.Admin_Name
            lblEmail.Text = newuser.Admin_Email
            lblBUnit.Text = newuser.Admin_Unit

        End If
    End Sub
    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Dim module_type As String = DefaultValues.Admin
        Dim task As String = "Add"
        Dim newuser As New Users(0, lblName.Text, lblEmail.Text, lblBUnit.Text, task, module_type)

        Dim message As String = newuser.Savenewuser(newuser)
        If (message = "True") Then
            lblMessage.Text = "User '" & newuser.Admin_Name & "' is Added to " & newuser.Admin_Unit
            btnCancel.Visible = False
            btnSumbit.Visible = False

        ElseIf message = "Problem" Then
            lblMessage.Text = "There is database problem. Please contact Admin"
        ElseIf message = "Exist" Then
            lblMessage.Text = "User '" & newuser.Admin_Name & "' Already Exists"
        End If

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        newuser.Admin_Name = lblName.Text
        newuser.Admin_Email = lblEmail.Text
        newuser.Admin_Unit = lblBUnit.Text
        Context.Items("AddUser") = newuser
        Server.Transfer("AddUser.aspx")

    End Sub
End Class
