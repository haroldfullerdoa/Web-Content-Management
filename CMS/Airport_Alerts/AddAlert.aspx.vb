
Partial Class CMS_Airport_Alerts_AddAlert
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
        lblMessage.Text = ""
    End Sub

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Try

            Dim Alert As New Users
            Dim module_type As String = DefaultValues.AirportAlert

            Alert.Alert_Title = txtAlertTitle.Text
            Alert.Alert_Desc = txtAlertDesc.Text
            Alert.Alert_Enabled = rbtAlertEnbl.SelectedValue
            Alert.Alert_ImgTag = txtImgTag.Text
            Alert.Alert_ImgUrl = txtImgUrl.Text
            Alert.Alert_Link = txtLink.Text
            Alert.Module_Type = module_type
            Alert.Admin_Action = "Add"

            If Alert.Savenewuser(Alert) = True Then
                lblMessage.Text = "Alert '" & txtAlertTitle.Text & "' is Added"

                txtAlertTitle.Text = ""
                txtAlertDesc.Text = ""
                rbtAlertEnbl.SelectedValue = Nothing
                txtImgTag.Text = ""
                txtImgUrl.Text = ""
                txtLink.Text = ""

            Else
                lblMessage.Text = "Alert Title Already Exists"
            End If

        Catch ex As Exception
        Finally
        End Try
    End Sub

  

End Class
