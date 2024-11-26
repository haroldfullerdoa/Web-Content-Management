
Partial Class CMS_Admin_EditUSer
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'verify authentication
        If Page.IsPostBack = False Then
            Dim authCookie1 As HttpCookie = Session("Parking")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("Parking.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("Parking.aspx")
            End If
        End If

        lblMessage.Text = ""

    End Sub
   
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        Try

            Dim radiolist As New RadioButtonList
            radiolist = CType(FormView1.FindControl("RbtParking"), RadioButtonList)
            If Page.IsPostBack = True And dplParking.SelectedValue <> "0" Then
                radiolist.SelectedValue = DataBinder.Eval(FormView1.DataItem, "ParkingStatus")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        Dim task As String = e.CommandName
        FormView1.ChangeMode(FormViewMode.Edit)
        Dim row As FormViewRow = FormView1.Row
        Dim rbtParking As RadioButtonList = CType(row.FindControl("RbtParking"), RadioButtonList)
        Dim parking As New Users

        parking.Module_Type = DefaultValues.Parking
        parking.Id = dplParking.SelectedValue
        parking.Prking_Lot_Name = dplParking.SelectedItem.Text
        parking.ParkingStatus = rbtParking.SelectedValue
        Session.Add("USER", parking)
        Try

        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" + strex, False)
        Catch ex As Exception
            Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))

        End Try
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated

        Dim row As FormViewRow = FormView1.Row
        Dim rbtParking As RadioButtonList = CType(row.FindControl("RbtParking"), RadioButtonList)
        lblMessage.Text = " Status of  '" & dplParking.SelectedItem.Text & "'  is Updated to  '" & rbtParking.SelectedValue & "'"
        dplParking.SelectedValue = "0"
    End Sub

  
End Class
