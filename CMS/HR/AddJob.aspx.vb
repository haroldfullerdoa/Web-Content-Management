
Partial Class Summer_Intern_Admin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("HR")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                If Context.Items("HR") IsNot Nothing Then
                    BindFields()
                End If
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("HR.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("HR.aspx")
            End If
        End If
        img1.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtAppFrom.ClientID + ");")
        img2.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtAppUntil.ClientID + ");")
        lblMessage.Text = ""
    End Sub

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Try

            Dim Hr As New Users
            Dim module_type As String = DefaultValues.HR

            If rbtLink.SelectedValue = "Yes" And (txtJobDescUrl.Text = "" Or txtApplyLink.Text = "") Then
                If txtJobDescUrl.Text = "" And txtApplyLink.Text = "" Then
                    lblMessage.Text = "Please Enter Job Description URL and 'Apply Link' URL"
                    Exit Sub
                ElseIf txtApplyLink.Text = "" Then
                    lblMessage.Text = "Please Enter URL for 'Apply Link'"
                    Exit Sub
                ElseIf txtJobDescUrl.Text = "" Then
                    lblMessage.Text = "Please Enter Job Description URL"
                    Exit Sub
                End If
            End If

               
            Hr.Job_Ttle = txtJobTitle.Text
            Hr.Salary_Range = txtSalaryRange.Text
            Hr.salary_Grade = ""
            Hr.App_Date_From = txtAppFrom.Text
            Hr.App_Date_To = txtAppUntil.Text
            Hr.Job_Description = txtJobReq.Text
            Hr.Contact_Information = txtContactinfo.Text
            Hr.Job_Alreadyposted = rbtLink.SelectedValue
            Hr.JobDesc_URL = txtJobDescUrl.Text
            Hr.JobApply_URL = txtApplyLink.Text
            Hr.Module_Type = module_type

            Hr.Admin_Action = "Add"
            Dim message As String = Hr.Savenewuser(Hr)
            If message = "True" Then
                lblMessage.Text = "Job '" & txtJobTitle.Text & "' is Added"
                txtJobTitle.Text = ""
                txtSalaryRange.Text = ""
                txtAppFrom.Text = ""
                txtAppUntil.Text = ""
                txtJobReq.Text = ""
                txtContactinfo.Text = ""
                rbtLink.SelectedValue = Nothing
                txtJobDescUrl.Text = ""
                txtApplyLink.Text = ""
            ElseIf message = "Problem" Then
                lblMessage.Text = "There is database problem. Please contact Admin"
            ElseIf message = "Exist" Then
                lblMessage.Text = "Job Title Already Exists"
            End If

        Catch ex As Exception
        Finally
        End Try
    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
       
        Dim Hr As New Users
        Dim module_type As String = DefaultValues.HR

        If rbtLink.SelectedValue = "Yes" And (txtJobDescUrl.Text = "" Or txtApplyLink.Text = "") Then
            If txtJobDescUrl.Text = "" And txtApplyLink.Text = "" Then
                lblMessage.Text = "Please Enter Job Description URL and 'Apply Link' URL"
                Exit Sub
            ElseIf txtApplyLink.Text = "" Then
                lblMessage.Text = "Please Enter URL for 'Apply Link'"
                Exit Sub
            ElseIf txtJobDescUrl.Text = "" Then
                lblMessage.Text = "Please Enter Job Description URL"
                Exit Sub
            End If
        End If

        Hr.Job_Ttle = txtJobTitle.Text
        Hr.Salary_Range = txtSalaryRange.Text
        Hr.salary_Grade = ""
        Hr.App_Date_From = txtAppFrom.Text
        Hr.App_Date_To = txtAppUntil.Text
        Hr.Job_Description = txtJobReq.Text
        Hr.Contact_Information = txtContactinfo.Text
        Hr.Job_Alreadyposted = rbtLink.SelectedValue
        Hr.JobDesc_URL = txtJobDescUrl.Text
        Hr.JobApply_URL = txtApplyLink.Text
        Hr.Module_Type = module_type
        Hr.Admin_Action = "Add"
        Context.Items("HR") = Hr
        Server.Transfer("PreviewHR.aspx")

    End Sub
    Public Sub BindFields()
        If Page.PreviousPage IsNot Nothing Then

            Dim HR As New Users
            HR = Context.Items("HR")
            txtJobTitle.Text = HR.Job_Ttle
            txtSalaryRange.Text = HR.Salary_Range
            txtAppFrom.Text = HR.App_Date_From
            txtAppUntil.Text = HR.App_Date_To
            txtJobReq.Text = HR.Job_Description
            txtContactinfo.Text = HR.Contact_Information
            rbtLink.SelectedValue = HR.Job_Alreadyposted
            txtJobDescUrl.Text = HR.JobDesc_URL
            txtApplyLink.Text = HR.JobApply_URL

        End If

    End Sub
    Protected Sub rbtLink_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtLink.SelectedIndexChanged
        If rbtLink.SelectedValue = "Yes" Then
            Panel1.Visible = True
        End If
        If rbtLink.SelectedValue = "No" Then
            Panel1.Visible = False
        End If
    End Sub
End Class
