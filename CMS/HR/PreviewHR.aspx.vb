
Partial Class CMS_Concessions_PreviewConcessions
    Inherits System.Web.UI.Page
    Dim HR As New Users

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            HR = Context.Items("HR")

            lblJobTitle.Text = HR.Job_Ttle
            lblSalRange.Text = HR.Salary_Range
            'lblSalGrade.Text = HR.salary_Grade
            lblJobDesc.Text = HR.Job_Description
            hypJobdescUrl.NavigateUrl = HR.JobDesc_URL
            hypJobApplyUrl.NavigateUrl = HR.JobApply_URL


            txtJobTitle.Text = HR.Job_Ttle
            txtSalaryRange.Text = HR.Salary_Range
            'txtSalaryGrade.Text = HR.salary_Grade
            txtAppFrom.Text = HR.App_Date_From
            txtAppUntil.Text = HR.App_Date_To
            txtJobReq.Text = HR.Job_Description
            txtContactinfo.Text = HR.Contact_Information
            lbljobalready.Text = HR.Job_Alreadyposted
            txtJobDescUrl.Text = HR.JobDesc_URL
            txtApplyLink.Text = HR.JobApply_URL
        End If
      
    End Sub
    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click

        Dim module_type As String = DefaultValues.HR
        HR.Job_Ttle = txtJobTitle.Text
        HR.Salary_Range = txtSalaryRange.Text
        HR.salary_Grade = ""
        HR.App_Date_From = txtAppFrom.Text
        HR.App_Date_To = txtAppUntil.Text
        HR.Job_Description = txtJobReq.Text
        HR.Contact_Information = txtContactinfo.Text
        HR.Job_Alreadyposted = lbljobalready.Text
        HR.JobDesc_URL = txtJobDescUrl.Text
        HR.JobApply_URL = txtApplyLink.Text
        HR.Module_Type = module_type

        HR.Admin_Action = "Add"


        Dim message As String = HR.Savenewuser(HR)
        If message = "True" Then
            lblMessage.Text = "Job '" & txtJobTitle.Text & "' is Added"
            btnCancel.Visible = False
            btnSumbit.Visible = False
        ElseIf message = "Problem" Then
            lblMessage.Text = "There is database problem. Please contact Admin"
        ElseIf message = "Exist" Then
            lblMessage.Text = "Job Title Already Exists"
        End If

      
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        HR.Job_Ttle = txtJobTitle.Text
        HR.Salary_Range = txtSalaryRange.Text
        HR.salary_Grade = ""
        HR.App_Date_From = txtAppFrom.Text
        HR.App_Date_To = txtAppUntil.Text
        HR.Job_Description = txtJobReq.Text
        HR.Contact_Information = txtContactinfo.Text
        HR.Job_Alreadyposted = lbljobalready.Text
        HR.JobDesc_URL = txtJobDescUrl.Text
        HR.JobApply_URL = txtApplyLink.Text
        Context.Items("HR") = HR
        Server.Transfer("AddJob.aspx")


    End Sub

End Class
