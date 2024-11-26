
Partial Class Summer_Intern_Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("PublicAffairs")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                If Context.Items("News") IsNot Nothing Then
                    BindFields()
                End If
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("Public_Affairs.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("Public_Affairs.aspx")
            End If
        End If

        img1.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtDate.ClientID + ");")
        lblMessage.Text = ""
    End Sub

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Try
            Dim task As String = "Add"
            Dim newuser As New Users(0, txtPressTitle.Text, txtDate.Text, txtArticle.Text, task, DefaultValues.Press_News, "Press_Release")
           

            Dim message As String = newuser.Savenewuser(newuser)
            If message = "True" Then
                lblMessage.Text = "Title is added"
                txtPressTitle.Text = ""
                txtDate.Text = ""
                txtArticle.Text = ""
            ElseIf message = "Problem" Then
                lblMessage.Text = "There is database problem. Please contact Admin"
            ElseIf message = "Exist" Then
                lblMessage.Text = "Title Already Exists"
            End If



        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))

        End Try

    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim task As String = "Add"
        Dim newuser As New Users(0, txtPressTitle.Text, txtDate.Text, txtArticle.Text, task, DefaultValues.Press_News, "Press_Release")

        Context.Items("News") = newuser
        Server.Transfer("PreviewNews.aspx")

    End Sub
    Public Sub BindFields()
        If Page.PreviousPage IsNot Nothing Then

            Dim News As New Users
            News = Context.Items("News")
            txtPressTitle.Text = News.Admin_Name
            txtDate.Text = News.Admin_Email
            txtArticle.Text = News.Admin_Unit

        End If

    End Sub

End Class
