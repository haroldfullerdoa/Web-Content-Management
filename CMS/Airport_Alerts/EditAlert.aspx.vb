
Partial Class CMS_Airport_Alerts_EditAlert
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("Admin")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("Alert_login.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("Alert_login.aspx")
            End If
        End If
    End Sub
    Protected Sub frmViewAlert_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles frmViewAlert.ItemCommand
        Dim task As String = e.CommandName
        frmViewAlert.ChangeMode(FormViewMode.Edit)

        Dim row As FormViewRow = frmViewAlert.Row
        Dim txtAlertTitle As TextBox = CType(row.FindControl("txtAlertTitle"), TextBox)
        Dim txtAlertDesc As TextBox = CType(row.FindControl("txtAlertDesc"), TextBox)
        Dim txtImgTag As TextBox = CType(row.FindControl("txtImgTag"), TextBox)
        Dim txtImgUrl As TextBox = CType(row.FindControl("txtImgUrl"), TextBox)
        Dim txtLink As TextBox = CType(row.FindControl("txtLink"), TextBox)
        Dim rbtAlertEnbl As RadioButtonList = CType(row.FindControl("rbtAlertEnbl"), RadioButtonList)
        

        Try


            Dim Alert As New Users
            Dim module_type As String = DefaultValues.AirportAlert

            Alert.Id = dplAlertTitle.SelectedValue
            Alert.Alert_Title = txtAlertTitle.Text
            Alert.Alert_Desc = txtAlertDesc.Text
            Alert.Alert_Enabled = rbtAlertEnbl.SelectedValue
            Alert.Alert_ImgTag = txtImgTag.Text
            Alert.Alert_ImgUrl = txtImgUrl.Text
            Alert.Alert_Link = txtLink.Text
            Alert.Module_Type = module_type
            Alert.Admin_Action = e.CommandName
            Session.Add("USER", Alert)

        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))


        Finally
            If task = "Update" Then
                lblMessage.Text = "Alert '" & dplAlertTitle.SelectedItem.Text & "' Details Are Updated"

            Else
                lblMessage.Text = "Alert  '" & dplAlertTitle.SelectedItem.Text & "' is deleted"

            End If
        End Try
    End Sub
    Protected Sub frmViewAlert_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles frmViewAlert.ItemDeleted
        dplAlertTitle.Items.Clear()
        Dim dplitem As New ListItem("Select Alert Title --", "0")
        dplAlertTitle.Items.Add(dplitem)
        dplAlertTitle.SelectedValue = "0"
        dplAlertTitle.DataBind()
    End Sub

    Protected Sub frmViewAlert_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles frmViewAlert.ItemUpdated
        dplAlertTitle.Items.Clear()
        Dim dplitem As New ListItem("Select Alert Title --", "0")
        dplAlertTitle.Items.Add(dplitem)
        dplAlertTitle.SelectedValue = "0"
        dplAlertTitle.DataBind()
    End Sub
    Protected Sub frmViewAlert_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmViewAlert.DataBound
        Try
            If frmViewAlert.DataItemCount <> Nothing Then
                Dim row As FormViewRow = frmViewAlert.Row
                Dim rbtAlertEnbl As RadioButtonList = CType(row.FindControl("rbtAlertEnbl"), RadioButtonList)
                rbtAlertEnbl.SelectedValue = DataBinder.Eval(frmViewAlert.DataItem, "Alert_Enabled")

            End If
        Catch ex As NullReferenceException
        End Try

    End Sub

  
End Class
