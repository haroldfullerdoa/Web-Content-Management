Imports HJAIA2008.BusinessLogicLayer
Imports System.Data.SqlClient

Partial Class AddBusiness
    Inherits System.Web.UI.Page

    Dim ActiveStatus As Integer = 1

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


    Protected Function clearFields() As Nullable
        tbCompanyName.Text = ""
        tbStreetAddress.Text = ""
        tbCity.Text = ""
        tbZipCode.Text = ""
        tbIPAddress.Text = ""
        tbBusinessPhone.Text = ""
        txtBusinessDescription.Text = ""
        ddlCompanyType.SelectedIndex = 0
        'cbActiveStatus.Checked = False
        tbBusinessEmail.Text = ""
        tbContactName.Text = ""
        tbContactEmail.Text = ""
        tbContactNumber.Text = ""
        chkDBE.Checked = False
        Return Nothing
    End Function


    Protected Sub btnInsert_Click(sender As Object, e As System.EventArgs) Handles btnInsert.Click
        Dim strConnection As String
        Dim company As String
        Dim sqlStr As String
        Dim dr As SqlDataReader

        strConnection = ConfigurationManager.ConnectionStrings("ConcessionsConnectionString").ToString()

        sqlStr = "SELECT CompanyName FROM Company WHERE SupplierNumber = '" & tbSupplierNumber.Text & "'"

        Using cn As New SqlConnection(strConnection)
            Dim cmd As New SqlCommand()
            cmd = cn.CreateCommand()
            cmd.CommandText = sqlStr
            cn.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                ClientScript.RegisterStartupScript(Me.GetType(), "AlertScript", "alert('The iSupply number you entered is already " & _
                    "in this database. Please verify your number and re-enter or use the record update choice.');", True)
                dr.Close()
                Exit Sub
            Else
                dr.Close()
            End If
            cn.Close()
        End Using

        Using cn As New SqlConnection(strConnection)

            Dim insertCMD As SqlCommand = New SqlCommand("sp_InsertCompany", cn)
            insertCMD.CommandType = Data.CommandType.StoredProcedure

            insertCMD.Parameters.AddWithValue("@CompanyName", tbCompanyName.Text.Trim())
            insertCMD.Parameters.AddWithValue("@StreetAddress", tbStreetAddress.Text.Trim())
            insertCMD.Parameters.AddWithValue("@City", tbCity.Text.Trim())
            insertCMD.Parameters.AddWithValue("@State", ddlState.SelectedValue)
            insertCMD.Parameters.AddWithValue("@Zipcode", tbZipCode.Text.Trim())
            insertCMD.Parameters.AddWithValue("@BusinessPhoneNumber ", tbBusinessPhone.Text.Trim())
            insertCMD.Parameters.AddWithValue("@BusinessDescription", txtBusinessDescription.Text.Trim())
            insertCMD.Parameters.AddWithValue("@BusinessTypeID", ddlCompanyType.SelectedValue)
            insertCMD.Parameters.AddWithValue("@IPAddress", tbIPAddress.Text.Trim())
            insertCMD.Parameters.AddWithValue("@ActiveStatus", ActiveStatus)
            insertCMD.Parameters.AddWithValue("@BusinessEmail", tbBusinessEmail.Text.Trim())
            insertCMD.Parameters.AddWithValue("@ContactFullName", tbContactName.Text.Trim())
            insertCMD.Parameters.AddWithValue("@ContactEmail", tbContactEmail.Text.Trim())
            insertCMD.Parameters.AddWithValue("@ContactPhone", tbContactNumber.Text.Trim())
            insertCMD.Parameters.AddWithValue("@SupplierNumber", tbSupplierNumber.Text.Trim())
            insertCMD.Parameters.AddWithValue("@DBE", chkDBE.Checked)
            insertCMD.Parameters.AddWithValue("@InsertDate", Date.Today)

            cn.Open()
            insertCMD.ExecuteNonQuery()
            cn.Close()

        End Using

        company = tbCompanyName.Text
        clearFields()
        Response.Redirect("SuccessfullyChanged.aspx?company=" & company & "&change=inserted")
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click
        clearFields()
    End Sub
End Class
