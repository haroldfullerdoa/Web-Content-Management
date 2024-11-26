
Partial Class CMS_Admin_EditUSer
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("HR")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("HR.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("HR.aspx")
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        Dim task As String = e.CommandName
        FormView1.ChangeMode(FormViewMode.Edit)

        Dim row As FormViewRow = FormView1.Row
        Dim txtJobTitle As TextBox = CType(row.FindControl("txtJobTitle"), TextBox)
        Dim txtSalaryRange As TextBox = CType(row.FindControl("txtSalaryRange"), TextBox)
        'Dim txtSalaryGrade As TextBox = CType(row.FindControl("txtSalaryGrade"), TextBox)

        Dim txtAppFrom As TextBox = CType(row.FindControl("txtAppFrom"), TextBox)
        Dim txtAppUntil As TextBox = CType(row.FindControl("txtAppUntil"), TextBox)
        Dim txtJobReq As TextBox = CType(row.FindControl("txtJobReq"), TextBox)

        Dim txtContactinfo As TextBox = CType(row.FindControl("txtContactinfo"), TextBox)
        Dim rbtLink As RadioButtonList = CType(row.FindControl("rbtLink"), RadioButtonList)
        Dim txtJobDescUrl As TextBox = CType(row.FindControl("txtJobDescUrl"), TextBox)
        Dim txtApplyLink As TextBox = CType(row.FindControl("txtApplyLink"), TextBox)
        Dim HR As New Users
        Try

            HR.Id = dplJobtitle.SelectedValue
            HR.Job_Ttle = txtJobTitle.Text
            HR.Salary_Range = txtSalaryRange.Text
            HR.salary_Grade = ""
            HR.App_Date_From = txtAppFrom.Text
            HR.App_Date_To = txtAppUntil.Text
            HR.Job_Description = txtJobReq.Text
            HR.Contact_Information = txtContactinfo.Text
            HR.Job_Alreadyposted = rbtLink.SelectedValue
            HR.JobDesc_URL = txtJobDescUrl.Text
            HR.JobApply_URL = txtApplyLink.Text
            HR.Module_Type = DefaultValues.HR
            HR.Admin_Action = e.CommandName
            Session.Add("USER", HR)

       

        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))


        Finally

            If task = "Update" Then
                Dim message As String = HR.Savenewuser(HR)
                If message = "True" Then
                    lblMessage.Text = "Job '" & dplJobtitle.SelectedItem.Text & "' Details Are Updated"
               
                ElseIf message = "Problem" Then
                    lblMessage.Text = "There is database problem. Please contact Admin"
                ElseIf message = "Exist" Then
                    lblMessage.Text = "Job Title Already Exists"
                End If

                'lblMessage.Text = "Job '" & dplJobtitle.SelectedItem.Text & "' Details Are Updated"

            Else
                lblMessage.Text = "Job  '" & dplJobtitle.SelectedItem.Text & "' is deleted"

            End If
        End Try
    End Sub
    Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
        dplJobtitle.Items.Clear()
        Dim dplitem As New ListItem("Select News Story --", "0")
        dplJobtitle.Items.Add(dplitem)
        dplJobtitle.SelectedValue = "0"
        dplJobtitle.DataBind()
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        dplJobtitle.Items.Clear()
        Dim dplitem As New ListItem("Select News Story --", "0")
        dplJobtitle.Items.Add(dplitem)
        dplJobtitle.SelectedValue = "0"
        dplJobtitle.DataBind()
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        Try
            If FormView1.DataItemCount <> Nothing Then
                Dim row As FormViewRow = FormView1.Row
                Dim img1 As HtmlImage = CType(row.FindControl("img1"), HtmlImage)
                Dim img2 As HtmlImage = CType(row.FindControl("img2"), HtmlImage)
                Dim txtAppFrom As TextBox = CType(row.FindControl("txtAppFrom"), TextBox)
                Dim txtAppUntil As TextBox = CType(row.FindControl("txtAppUntil"), TextBox)

                img1.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtAppFrom.ClientID + ");")
                img2.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtAppUntil.ClientID + ");")
                Dim rbtLink As RadioButtonList = CType(row.FindControl("rbtLink"), RadioButtonList)
                rbtLink.SelectedValue = DataBinder.Eval(FormView1.DataItem, "Job_Alreadyposted")

            End If
        Catch ex As NullReferenceException


        End Try

    End Sub
End Class
