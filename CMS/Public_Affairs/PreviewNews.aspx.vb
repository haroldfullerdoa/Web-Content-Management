
Partial Class CMS_Concessions_PreviewConcessions
    Inherits System.Web.UI.Page
    Dim News As New Users
    Dim press_type As String

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'Just before the page loads and after all other processing is done (which may have changed)
        'our press_type variable value, we make sure that it gets put back into the ViewState variable
        ViewState("FormStatus") = press_type
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            News = Context.Items("News")

            lblTitle.Text = News.Admin_Name
            lblRelDate.Text = Convert.ToDateTime(News.Admin_Email).ToString("MMM, dd yyyy")
            article.InnerHtml = News.Admin_Unit

            txtPressTitle.Text = News.Admin_Name
            txtDate.Text = News.Admin_Email
            txtArticle.Text = News.Admin_Unit
            press_type = News.Press_Type.ToString()
        Else
            press_type = ViewState("FormStatus")

        End If
        If press_type = "Press_News" Then
            lblNews.InnerText = "Airport News Story Title:"
        Else
            lblNews.InnerText = "Press Release Title:"

        End If


    End Sub
    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click

        Try
            Dim task As String = "Add"
            Dim newuser As New Users(0, txtPressTitle.Text, txtDate.Text, txtArticle.Text, task, DefaultValues.Press_News, press_type)


            Dim message As String = newuser.Savenewuser(newuser)
            If message = "True" Then
                lblMessage.Text = "Title is added"
                btnCancel.Visible = False
                btnSumbit.Visible = False
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

        Finally
           
        End Try

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Dim news As New Users(0, txtPressTitle.Text, txtDate.Text, txtArticle.Text, "Add", DefaultValues.Press_News, press_type)
        Context.Items("News") = news
        If press_type = "Press_News" Then
            Server.Transfer("AddNews.aspx")
        Else
            Server.Transfer("AddPressRelease.aspx")

        End If
    End Sub

    
End Class
