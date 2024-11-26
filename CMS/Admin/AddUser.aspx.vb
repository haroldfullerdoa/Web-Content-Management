
Partial Class Summer_Intern_Admin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Page.IsPostBack = False Then

            'Dim script As String = "  var name; name = document.getElementById('{0}').value; alert (name);return false;"
            'string = "asda?name="+Server.HtmlEncode(fgdg)
            ''0 create function parameter array of controls to verify
            ''1 create a function parameter value
            ''2 get the value
            ''3 set in array
            ''4 create a query string
            'btnPreview.Attributes.Add("onclick", String.Format(script, RbtUnit.ClientID))
            Dim authCookie1 As HttpCookie = Session("Admin")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                If Context.Items("AddUser") IsNot Nothing Then
                    BindFields()
                End If
                'If Page.PreviousPage IsNot Nothing Then
                '    BindFields()
                'End If
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

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Try
            Dim module_type As String = DefaultValues.Admin
            Dim task As String = "Add"
            Dim newuser As New Users(0, txtName.Text, txtEmail.Text, RbtUnit.SelectedValue, task, module_type)
            Dim message As String = newuser.Savenewuser(newuser)
            If (message = "True") Then
                lblMessage.Text = "User '" & txtName.Text & "' is Added to " & RbtUnit.SelectedValue

            ElseIf message = "Problem" Then
                lblMessage.Text = "There is database problem. Please contact Admin"
            ElseIf message = "Exist" Then
                lblMessage.Text = "User '" & txtName.Text & "' Already Exists"
            End If

        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))


        Finally
            txtName.Text = ""
            txtEmail.Text = ""
            RbtUnit.SelectedValue = Nothing
        End Try


    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim module_type As String = DefaultValues.Admin
        Dim task As String = "Add"
        Dim newuser As New Users(0, txtName.Text, txtEmail.Text, RbtUnit.SelectedValue, task, module_type)
        Context.Items("AddUser") = newuser
        Server.Transfer("PreviewAdmin.aspx")


    End Sub

    Public Sub BindFields()
        If Page.PreviousPage IsNot Nothing Then
            'Dim data As New Users
            'Dim txtname As TextBox = CType(PreviousPage.Form.FindControl("txtName"), TextBox)
            'Dim txtEmail As TextBox = CType(PreviousPage.FindControl("txtEmail"), TextBox)
            'Dim txtBunit As TextBox = CType(PreviousPage.FindControl("txtBUnit"), TextBox)

            Dim data As New Users
            data = Context.Items("AddUser")
            txtName.Text = data.Admin_Name
            txtEmail.Text = data.Admin_Email
            RbtUnit.SelectedValue = data.Admin_Unit

        End If

    End Sub


End Class
