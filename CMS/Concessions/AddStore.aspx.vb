Imports HJAIA2008.BusinessLogicLayer

Partial Class CMS_Concessions_AddStore
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Not Page.IsPostBack Then
            Dim authCookie1 As HttpCookie = Session("Concession")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True 'display Log Out link
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("default.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("default.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        'initate the business object
        Dim Company As New CMS(0, txtCompanyName.Text.Trim(), txtCompanyDescription.Text.Trim(), _
                                Int32.Parse(dplCompanyType.SelectedValue), txtPhone1.Text.Trim(), _
                                txtPhone2.Text.Trim(), txtWebsite.Text.Trim())
        'pass the variables
        If Not String.IsNullOrEmpty(txtPhone1Ext.Text) Then Company.Company_Phone1 &= " " & DefaultValues.Extension.ToString() & " " & txtPhone1Ext.Text.Trim()
        If Not String.IsNullOrEmpty(txtPhone2Ext.Text) Then Company.Company_Phone2 &= " " & DefaultValues.Extension.ToString() & " " & txtPhone2Ext.Text.Trim()
        Company.Module_Type = DefaultValues.Concessions
        Company.Admin_Action = "Add"

        Try

            Dim appCode As Int32 = Company.SaveNewContent(Company)

            If appCode > 0 Then '"True"

                lblMessage.Text = "Company, " & txtCompanyName.Text & ", was added successfully!"
                'Display a client-side popup, explaining that the company was added
                'And Redirect to edit store page
                ClientScript.RegisterStartupScript(Me.GetType(), "ISDRocks!", String.Format("alert('{0}');window.location='EditStore.aspx?comp_id={1}#location';", lblMessage.Text.ToString().Replace("'", "\'"), appCode), True)

            Else
                Select Case (appCode)
                    Case -1 ' "Exists"
                        lblMessage.Text &= "Company already exists in the system."
                    Case -2 ' "Name"
                        lblMessage.Text &= "Another company with the same Company Name already exists in the system."
                    Case -3 ' "Location"
                        lblMessage.Text &= "Company can not be deleted with store location exists."
                    Case -100 ' "Error"
                        lblMessage.Text &= "Unexpected database problem occurred. Please contact Admin for the assitance."
                    Case Else
                        lblMessage.Text &= "Unexpected system problem occurred. Please contact Admin for the assitance."
                End Select
                'Display a client-side popup
                ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", lblMessage.Text.ToString().Replace("'", "\'")), True)

                lblMessage.Text = "<strong>Error:</strong> " & lblMessage.Text
            End If

        Catch ex As Exception
            lblMessage.Text = "Unexpected system problem(" & ex.Message & ") occurred. Please contact Admin for the assitance."
            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", ex.Message.Replace("'", "\'")), True)

            lblMessage.Text = "<strong>Error:</strong> " & lblMessage.Text
        Finally
            'clean up
            Company = Nothing
        End Try
    End Sub

End Class
