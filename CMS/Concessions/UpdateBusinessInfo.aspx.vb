Imports HJAIA2008.BusinessLogicLayer
Imports System.Data.SqlClient

Partial Class UpdateBusinessInfo
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

                Try
                    tbSupplierNumber.Text = Request.QueryString("SupplierNumber")
                    If tbSupplierNumber.Text <> "" Then
                        search()
                    End If
                Catch
                    clearFields()
                End Try

            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("default.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Protected Sub search()
        Dim strConnection As String
        Dim dr As SqlDataReader

        strConnection = ConfigurationManager.ConnectionStrings("ConcessionsConnectionString").ToString()

        Dim sqlStr As String

        sqlStr = "SELECT Company.BusinessID, CompanyName, StreetAddress, City, State, Zipcode, IPAddress, BusinessPhoneNumber, BusinessDescription, " & _
                 "BusinessTypeID, ActiveStatus, BusinessEmail, ContactFullName, ContactEmail, ContactPhone, SupplierNumber, DBE " & _
                 "FROM Company INNER JOIN Address ON Company.BusinessID = Address.BusinessID " & _
                 "WHERE SupplierNumber = '" & tbSupplierNumber.Text.Trim() & "'"

        Using cn As New SqlConnection(strConnection)

            Dim cmd As New SqlCommand()
            cmd = cn.CreateCommand()
            cmd.CommandText = sqlStr
            cn.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                Do While dr.Read()
                    lbID.Text = dr.GetValue(0).ToString().Trim()
                    tbCompanyName.Text = dr.GetValue(1).ToString().Trim()
                    tbStreetAddress.Text = dr.GetValue(2).ToString().Trim()
                    tbCity.Text = dr.GetValue(3).ToString().Trim()
                    ddlState.SelectedValue = dr.GetValue(4)
                    tbZipCode.Text = dr.GetValue(5).ToString().Trim()
                    tbIPAddress.Text = dr.GetValue(6).ToString().Trim()
                    tbBusinessPhone.Text = dr.GetValue(7).ToString().Trim()
                    txtBusinessDescription.Text = dr.GetValue(8).ToString().Trim()
                    ddlCompanyType.SelectedValue = dr.GetValue(9)
                    cbActiveStatus.Checked = dr.GetValue(10)
                    tbBusinessEmail.Text = dr.GetValue(11).ToString().Trim()
                    tbContactName.Text = dr.GetValue(12).ToString().Trim()
                    tbContactEmail.Text = dr.GetValue(13).ToString().Trim()
                    tbContactNumber.Text = dr.GetValue(14).ToString().Trim()
                    tbSupplierNumber.Text = dr.GetValue(15).ToString().Trim()
                    chkDBE.Checked = dr.GetValue(16)
                Loop
            Else
                clearFields()
            End If

            dr.Close()
            cn.Close()
        End Using
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click

        Dim strConnection As String
        Dim company As String

        strConnection = ConfigurationManager.ConnectionStrings("ConcessionsConnectionString").ToString()

        Using cn As New SqlConnection(strConnection)

            Dim UpdateCMD As SqlCommand = New SqlCommand("sp_UpdateCompany", cn)
            UpdateCMD.CommandType = Data.CommandType.StoredProcedure

            UpdateCMD.Parameters.AddWithValue("@BusinessID", CType(lbID.Text, Integer))
            UpdateCMD.Parameters.AddWithValue("@CompanyName", tbCompanyName.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@BusinessPhoneNumber ", tbBusinessPhone.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@BusinessDescription", txtBusinessDescription.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@BusinessTypeID", ddlCompanyType.SelectedValue)
            UpdateCMD.Parameters.AddWithValue("@IPAddress", tbIPAddress.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@ActiveStatus", CType(cbActiveStatus.Checked, Single))
            UpdateCMD.Parameters.AddWithValue("@BusinessEmail", tbBusinessEmail.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@ContactFullName", tbContactName.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@ContactEmail", tbContactEmail.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@ContactPhone", tbContactNumber.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@DBE", chkDBE.Checked)
            UpdateCMD.Parameters.AddWithValue("@StreetAddress", tbStreetAddress.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@City", tbCity.Text.Trim())
            UpdateCMD.Parameters.AddWithValue("@State", ddlState.SelectedValue)
            UpdateCMD.Parameters.AddWithValue("@Zipcode", tbZipCode.Text.Trim())

            cn.Open()
            UpdateCMD.ExecuteNonQuery()
            cn.Close()

        End Using

        company = tbCompanyName.Text
        clearFields()
        Response.Redirect("SuccessfullyChanged.aspx?company=" & company & "&change=updated")
    End Sub

    Protected Function clearFields() As Nullable
        lbID.Text = ""
        tbCompanyName.Text = ""
        tbStreetAddress.Text = ""
        tbCity.Text = ""
        tbZipCode.Text = ""
        tbIPAddress.Text = ""
        tbBusinessPhone.Text = ""
        txtBusinessDescription.Text = ""
        ddlCompanyType.SelectedIndex = 0
        cbActiveStatus.Checked = False
        tbBusinessEmail.Text = ""
        tbContactName.Text = ""
        tbContactEmail.Text = ""
        tbContactNumber.Text = ""
        chkDBE.Checked = False
        cbActiveStatus.Checked = False
        Return Nothing
    End Function

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Dim strConnection As String
        Dim company As String

        strConnection = ConfigurationManager.ConnectionStrings("ConcessionsConnectionString").ToString()

        Dim sqlStr As String
        sqlStr = "DELETE Company WHERE BusinessID = " & CType(lbID.Text, Integer)

        Using cn As New SqlConnection(strConnection)

            Dim cmd As New SqlCommand()
            cmd = cn.CreateCommand()
            cmd.CommandText = sqlStr
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        End Using

        company = tbCompanyName.Text
        clearFields()
        Response.Redirect("SuccessfullyChanged.aspx?company=" & company & "&change=deleted")
    End Sub

 
End Class
