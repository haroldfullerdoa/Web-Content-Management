Imports HJAIA2008.BusinessLogicLayer
Imports System.IO

Partial Class CMS_Concessions_EditStore
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication

        If Not Page.IsPostBack Then
            Dim authCookie1 As HttpCookie = Session("Concession")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("default.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("default.aspx")
            End If

            'get from QueryString parameter
            Dim intCompID As Integer = 0
            If Not (Request.QueryString("comp_id") Is Nothing) Then
                If Not String.IsNullOrEmpty(Request.QueryString("comp_id")) And IsNumeric(Request.QueryString("comp_id")) Then
                    If Request.QueryString("comp_id") < Int32.MaxValue Then intCompID = Int32.Parse(Request.QueryString("comp_id").ToString())
                End If
            End If

            'set the company dropdwon list default value
            If intCompID > 0 Then
                dplCompanyName.SelectedValue = intCompID
            Else
                Response.Redirect("AddStore.aspx") 'if not a valid company ID then redirect to Add New page
            End If
        End If

    End Sub

    Protected Sub dplCompanyName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dplCompanyName.SelectedIndexChanged
        If dplCompanyName.SelectedValue IsNot Nothing Then
            If dplCompanyName.SelectedValue = 0 Then 'add new company then
                Response.Redirect("AddStore.aspx")
            Else
                Response.Redirect("EditStore.aspx?comp_id=" & dplCompanyName.SelectedValue.ToString())
            End If
        End If
    End Sub

    Protected Sub grdStores_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdStores.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            'change the status type color
            If e.Row.Cells(5).Text.ToString.ToUpper() = "YES" Then e.Row.Cells(5).ForeColor = Drawing.Color.Red

            'add Confirm Javascript to the delete buttons 
            If e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate Then 'exclude the Edit mode since there will be Cancel Button instead of Delete button
                Dim btnDel As Button = CType(e.Row.Cells(7).Controls(2), Button) ' index 0-Edit 2-Delete
                btnDel.Attributes.Add("onClick", "if(confirm('Are you sure to delete this store?')==0){return false;}") '1-OK, 0-Cancel
            End If
        End If
    End Sub

    Protected Sub grdPhoto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPhoto.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'add Confirm Javascript to the delete buttons 
            If e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate Then 'exclude the Edit mode since there will be Cancel Button instead of Delete button
                Dim btnDel As Button = CType(e.Row.Cells(3).Controls(0), Button) ' index 0-Edit 2-Delete
                btnDel.Attributes.Add("onClick", "if(confirm('Are you sure to delete this file?')==0){return false;}") '1-OK, 0-Cancel
            End If
        End If
    End Sub

    Protected Function Get_File_Name(ByVal pFile_ID As Int32, ByVal pFile_Data As Byte(), ByVal pFile_Name As String, ByVal pFile_Type As String) As String

        'iniate the file path
        Dim strPath As String = "../images/" & pFile_Type & "/"
        Dim strFileName As String = pFile_ID.ToString() & "_" & pFile_Name 'put the File_ID before theDim  file name to reduce the duplicates

        Dim Fls As System.IO.FileStream = New System.IO.FileStream(Server.MapPath(strPath & strFileName), System.IO.FileMode.Create)
        Fls.Write(pFile_Data, 0, pFile_Data.Length)
        Fls.Close()

        If String.Equals(pFile_Type, "photo") Or String.Equals(pFile_Type, "logo") Then
            Return "<img src='" & strPath & strFileName & "' style='width:400px;border-width:0px;' alt='click to view larger photo of " & pFile_Name & "' />"
        Else
            Return pFile_Name
        End If
    End Function

    Protected Function Get_File_URL(ByVal pFile_ID As Int32, ByVal pFile_Name As String, ByVal pFile_Type As String) As String

        Return "~/CMS/images/" & pFile_Type & "/" & pFile_ID.ToString() & "_" & pFile_Name

    End Function

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As FormViewCommandEventArgs) Handles FormView1.ItemCommand
        'initate the business object
        Dim Company As CMS

        Dim task As String = e.CommandName
        Dim row As FormViewRow = FormView1.Row
        Dim txtcompanyname As TextBox = CType(row.FindControl("txtCompanyName"), TextBox)
        Dim txtcompanydescription As TextBox = CType(row.FindControl("txtCompanyDescription"), TextBox)
        Dim dplcompanytype As DropDownList = CType(row.FindControl("dplCompanyType"), DropDownList)
        Dim txtcompanyphone1 As TextBox = CType(row.FindControl("txtPhone1"), TextBox)
        Dim txtcompanyphone2 As TextBox = CType(row.FindControl("txtPhone2"), TextBox)
        Dim txtcompanywebsite As TextBox = CType(row.FindControl("txtWebsite"), TextBox)

        Try

            lblMessage.Text = ""
            Select Case (task)
                Case "Edit"
                    FormView1.ChangeMode(FormViewMode.Edit)
                Case "Cancel"
                    FormView1.ChangeMode(FormViewMode.ReadOnly)
                Case Else ' "UPDATE" "DELETE"
                    Company = New CMS(Int32.Parse(dplCompanyName.SelectedValue), txtcompanyname.Text.ToString().Trim(), txtcompanydescription.Text.ToString().Trim(), _
                    Int32.Parse(dplcompanytype.SelectedValue), txtcompanyphone1.Text.ToString().Trim(), _
                    txtcompanyphone2.Text.ToString().Trim(), txtcompanywebsite.Text.ToString().Trim())

                    Company.Module_Type = DefaultValues.Concessions
                    Company.Admin_Action = task

                    Session.Add("CONTENT", Company)
            End Select


        Catch ex As System.Data.OracleClient.OracleException
            Dim strex As String = "System.Data.OracleClient.OracleException"
            'Response.Redirect("~/CMS/ErrorPage.aspx?error=" & strex, False)
            lblMessage.Text = strex & ": " & ex.Message.ToString()
        Catch ex As Exception
            ' Response.Redirect("~/CMS/ErrorPage.aspx?error=" & ex.Message().Replace("\n", ""))
            lblMessage.Text = "Unexpected system problem: " & ex.Message.ToString()
        Finally
            Company = Nothing
        End Try
    End Sub


    Protected Sub showModalPopup_Store(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowModalPopup_Store.Click
        'load the new store list
        Dim lbCompName As Label = CType(programmaticModalPopup_Store.FindControl("lblCompName"), Label)
        Dim lbMessage As Label = CType(programmaticModalPopup_Store.FindControl("lblStoreMessage"), Label)
        Dim txtStore_Phone1 As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone1"), TextBox)
        Dim txtStore_Phone1Ext As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone1Ext"), TextBox)
        Dim txtStore_Phone2 As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone2"), TextBox)
        Dim txtStore_Phone2Ext As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone2Ext"), TextBox)
        'display the company on Add New Store header
        lbCompName.Text = Me.dplCompanyName.SelectedItem.ToString()
        'clean up the message
        lbMessage.Text = String.Empty

        Dim lbPhone1 As Label = CType(FormView1.Row.FindControl("lbCompany_Phone1"), Label)
        Dim lbPhone2 As Label = CType(FormView1.Row.FindControl("lbCompany_Phone2"), Label)
        Dim txtPhone1 As TextBox = CType(FormView1.Row.FindControl("txtPhone1"), TextBox)
        Dim txtPhone2 As TextBox = CType(FormView1.Row.FindControl("txtPhone2"), TextBox)

        'separate the phone number and extension
        Dim strPhone As String = String.Empty
        Dim strPhoneMain As String = String.Empty
        Dim strPhoneExt As String = String.Empty
        Dim iPos As Int16 = 0
        Dim iLength As Int16 = 0

        'for the Store Phone Number 1
        If lbPhone1 Is Nothing Then
            If txtPhone1 IsNot Nothing Then
                If Not String.IsNullOrEmpty(txtPhone1.Text) Then strPhone = txtPhone1.Text.ToString()
            End If
        Else
            If Not String.IsNullOrEmpty(lbPhone1.Text) Then strPhone = lbPhone1.Text.ToString()
        End If

        If Not String.IsNullOrEmpty(strPhone) Then
            iPos = strPhone.IndexOf(DefaultValues.Extension.ToString())
            iLength = strPhone.Length
            If iPos > 0 Then
                strPhoneMain = strPhone.Substring(0, iPos).Trim()
                iPos += DefaultValues.Extension.ToString().Length()
                strPhoneExt = strPhone.Substring(iPos, iLength - iPos).Trim()
            Else
                strPhoneMain = strPhone
                strPhoneExt = String.Empty
            End If

            txtStore_Phone1.Text = strPhoneMain
            txtStore_Phone1Ext.Text = strPhoneExt
        End If

        'do the same for the Store Phone Number 2       
        If lbPhone2 Is Nothing Then
            If txtPhone2 IsNot Nothing Then
                If Not String.IsNullOrEmpty(txtPhone2.Text) Then strPhone = txtPhone2.Text.ToString()
            End If
        Else
            If Not String.IsNullOrEmpty(lbPhone2.Text) Then strPhone = lbPhone2.Text.ToString()
        End If

        If Not String.IsNullOrEmpty(strPhone) Then
            iPos = strPhone.IndexOf(DefaultValues.Extension.ToString())
            iLength = strPhone.Length
            If iPos > 0 Then
                strPhoneMain = strPhone.Substring(0, iPos).Trim()
                iPos += DefaultValues.Extension.ToString().Length()
                strPhoneExt = strPhone.Substring(iPos, iLength - iPos).Trim()
            Else
                strPhoneMain = strPhone
                strPhoneExt = String.Empty
            End If

            txtStore_Phone2.Text = strPhoneMain
            txtStore_Phone2Ext.Text = strPhoneExt
        End If


        Me.programmaticModalPopup_Store.Show()
    End Sub

    Protected Sub hideModalPopup_Store(ByVal sender As Object, ByVal e As System.EventArgs)
        'save the new store

        'initate the business object
        Dim Company As New CMS

        Dim drpStoreLocations As DropDownList = CType(programmaticModalPopup_Store.FindControl("drpStoreLocations"), DropDownList)
        Dim txtStore_Phone1 As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone1"), TextBox)
        Dim txtStore_Phone1Ext As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone1Ext"), TextBox)
        Dim txtStore_Phone2 As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone2"), TextBox)
        Dim txtStore_Phone2Ext As TextBox = CType(programmaticModalPopup_Store.FindControl("txtStore_Phone2Ext"), TextBox)
        Dim drpHours_Operation As DropDownList = CType(programmaticModalPopup_Store.FindControl("drpHours_Operation"), DropDownList)
        Dim ckSeating_Available As RadioButtonList = CType(programmaticModalPopup_Store.FindControl("ckSeating_Available"), RadioButtonList)
        Dim ckClosed_Renovation As CheckBox = CType(programmaticModalPopup_Store.FindControl("ckClosed_Renovation"), CheckBox)

        Dim lblStoreMessage As Label = CType(programmaticModalPopup_Store.FindControl("lblStoreMessage"), Label)
        If Not String.IsNullOrEmpty(drpStoreLocations.SelectedValue.ToString()) Then
            Try
                Dim module_type As String = DefaultValues.Concessions_Stores

                Company.Store_Location_ID = drpStoreLocations.SelectedValue
                Company.Company_ID = dplCompanyName.SelectedValue
                Company.Store_Phone1 = txtStore_Phone1.Text.Trim()
                If Not String.IsNullOrEmpty(txtStore_Phone1Ext.Text) Then Company.Store_Phone1 &= " " & DefaultValues.Extension.ToString() & " " & txtStore_Phone1Ext.Text.Trim()
                Company.Store_Phone2 = txtStore_Phone2.Text
                If Not String.IsNullOrEmpty(txtStore_Phone2Ext.Text) Then Company.Store_Phone2 &= " " & DefaultValues.Extension.ToString() & " " & txtStore_Phone2Ext.Text.Trim()
                Company.Hours_Operation = drpHours_Operation.SelectedValue.ToString().Trim()
                'On 2009-12-17 per user's request, add "N/A" as the default option, and keep YES and NO
                'If ckSeating_Available.Checked Then
                '    Company.Seating_Available = ckSeating_Available.Text.ToString().Trim().ToUpper() 'always use Upper Case
                'Else
                '    Company.Seating_Available = "NO"
                'End If

                Company.Seating_Available = ckSeating_Available.SelectedValue.ToString().Trim().ToUpper() 'always use Upper Case

                If ckClosed_Renovation.Checked Then
                    Company.Closed_Renovation = ckClosed_Renovation.Text.ToString().Trim().ToUpper()
                Else
                    Company.Closed_Renovation = "NO"
                End If

                Company.Module_Type = module_type
                Company.Admin_Action = "Add"
                Dim appCode As Int32 = Company.SaveNewContent(Company)

                If appCode > 0 Then '"True"
                    lblMessage.Text = "<strong>Store lcoation was added successfully!</strong>"
                    Me.programmaticModalPopup_Store.Hide()
                    Me.grdStores.DataBind() 'refresh the gridview of Store Locations with the new store
                Else
                    Select Case (appCode)
                        Case -1 ' "Exists"
                            lblStoreMessage.Text = "The same store location already exists in the system."
                        Case -100 ' "Error"
                            lblStoreMessage.Text = "Unexpected database problem occurred. Please contact Admin for the assistance."
                        Case Else
                            lblStoreMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."
                    End Select
                    Me.programmaticModalPopup_Store.Show()
                End If

            Catch ex As Exception
                lblMessage.Text = "Unexpected system problem(" & ex.Message & ") occurred. Please contact Admin for the assistance."
                'Display a client-side popup
                ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", ex.Message.Replace("'", "\'")), True)
            Finally
                ''clean up
                Company = Nothing
            End Try
        Else
            lblStoreMessage.Text = "Please select the Store Location first."
            Me.programmaticModalPopup_Store.Show()
        End If
    End Sub


    Protected Sub showModalPopup_File(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.programmaticModalPopup_File.Show()
    End Sub

    Protected Sub hideModalPopup_File(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Company_File As CMS
        Try
            'iniate the variables
            Dim lblFileMessage As Label = CType(programmaticModalPopup_File.FindControl("lbFileUpdateMessage"), Label)
            Dim rdlFileType As RadioButtonList = CType(programmaticModalPopup_File.FindControl("rblCategory"), RadioButtonList)
            Dim strFileType As String = rdlFileType.SelectedValue.ToString().ToLower().Trim()

            If String.IsNullOrEmpty(strFileType) Then
                lblFileMessage.Text = "Please select the File Upload Category first."
                Me.programmaticModalPopup_File.Show()
                Exit Sub 'not select the upload category
            End If

            Dim fileCompany As HtmlInputFile = CType(programmaticModalPopup_File.FindControl("fileCompany"), HtmlInputFile)
            Dim intLength As Int32 = Int32.Parse(fileCompany.PostedFile.InputStream.Length)

            If intLength = 0 Then
                lblFileMessage.Text = "Please select a valid file to Upload."
                Me.programmaticModalPopup_File.Show()
                Exit Sub 'a empty file 
            End If

            Dim strFileContentType As String = fileCompany.PostedFile.ContentType
            Dim strFileExt As String = String.Empty


            strFileExt = CMS.CheckFileType(strFileType, strFileContentType)

            If String.IsNullOrEmpty(strFileExt) Then
                lblFileMessage.Text = "Please select the correct file. <br/>For photograph, the file can be *.jpg *.gif *.bmp *.png; <br/>For menu, the file can be *.doc *.pdf *.tif."
                Me.programmaticModalPopup_File.Show()
                Exit Sub 'not a valid file 
            End If


            Select Case (strFileType)
                Case DefaultValues.File_Type_Photo
                    If intLength / Math.Pow(1024, 2) > 1 Then 'can not larger than 1MB
                        lblFileMessage.Text = "Your " & DefaultValues.File_Type_Photo & " file is too big (exceeded 1 MB)."
                        Me.programmaticModalPopup_File.Show()
                        Exit Sub 'not a valid file size
                    End If

                Case DefaultValues.File_Type_Menu
                    If intLength / Math.Pow(1024, 2) > 5 Then 'can not larger than 5MB
                        lblFileMessage.Text = "Your " & DefaultValues.File_Type_Menu & " file is too big (exceeded 5 MB)."
                        Me.programmaticModalPopup_File.Show()
                        Exit Sub 'not a valid file size
                    End If
            End Select


            Dim strFileName As String
            strFileName = Path.GetFileName(fileCompany.PostedFile.FileName.Trim)

            If Not Path.GetExtension(strFileName) = Nothing Then 'get file extenstion from the file name
                If Not String.IsNullOrEmpty(Path.GetExtension(strFileName)) Then strFileExt = Path.GetExtension(strFileName).Substring(0, 4) 'only the dot and 3 character of file extension
            End If

            If strFileName.Length > 50 Then
                strFileName = strFileName.Substring(0, 46) & strFileExt 'keep the full file name in 50 length limit
            End If


            Dim bytContent As Byte()
            ReDim bytContent(intLength) 'byte array, set to file size 
            fileCompany.PostedFile.InputStream.Read(bytContent, 0, intLength)

            'initate the business object
            Company_File = New CMS(dplCompanyName.SelectedValue, bytContent, strFileName, strFileType, strFileContentType)
            Company_File.Module_Type = DefaultValues.Company_Files
            Company_File.Admin_Action = "Add"

            Dim strAdmin_Name As String = String.Empty
            Dim authCookie1 As HttpCookie = Session("Concession")
            If (Not authCookie1 Is Nothing) Then
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                strAdmin_Name = authTicket1.UserData.ToString().ToUpper()
            End If
            Company_File.Admin_Name = strAdmin_Name
            Dim intAppCode As Int32 = Company_File.SaveNewContent(Company_File)

            If intAppCode = 0 Then '"True"
                Me.programmaticModalPopup_File.Hide()
                Me.grdPhoto.DataBind() 'refresh the gridview of Attachments with newly added file
                Me.lblMessage.Text = "<strong>File was uploaded successfully!</strong>"
            Else
                lblFileMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."
                Me.programmaticModalPopup_File.Show()
            End If
        Catch ex As Exception
            lblMessage.Text = "Unexpected system problem(" & ex.Message & ") occurred. Please contact Admin for the assistance."
            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", ex.Message.Replace("'", "\'")), True)
        Finally
            ''clean up
            Company_File = Nothing
        End Try
    End Sub

    Protected Sub ObjectDataSource_Company_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource_Company.Deleted
        Dim intAppCode As Int32 = Int32.Parse(e.ReturnValue)
        If intAppCode < 0 Then
            Select Case (intAppCode)
                Case (-1)
                    lblMessage.Text = "Company can not be deleted if it has been deleted before."
                Case (-2) ' "File Exists"
                    lblMessage.Text = "Company can not be deleted with attached photo or menu exists."
                Case (-3) ' "Store or Location"
                    lblMessage.Text = "Company can not be deleted with store location exists."
                Case Else
                    lblMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."
            End Select

            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", lblMessage.Text.ToString().Replace("'", "\'")), True)

            lblMessage.Text = "<strong>Error:</strong> " & lblMessage.Text
        Else
            dplCompanyName.Items.Clear()
            dplCompanyName.Items.Add(New ListItem(" -- select one --", ""))
            dplCompanyName.Items.Add(New ListItem(" [Add New Company] ", "0"))
            dplCompanyName.DataBind()
            dplCompanyName.SelectedValue = ""
            lblMessage.Text = "<strong>The company was deleted</strong>"
        End If
    End Sub

    Protected Sub ObjectDataSource_Company_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource_Company.Updated
        Dim intAppCode As Int32 = Int32.Parse(e.ReturnValue)
        If intAppCode < 0 Then
            If intAppCode = -2 Then ' "Location"
                lblMessage.Text = "Another company with the same Company Name already exists in the system."
            Else
                lblMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."
            End If

            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", lblMessage.Text.ToString().Replace("'", "\'")), True)
            lblMessage.Text = "<strong>Error:</strong> " & lblMessage.Text
        Else
            dplCompanyName.Items.Clear()
            dplCompanyName.Items.Add(New ListItem(" [Add New Company] ", "0"))
            dplCompanyName.DataBind()
            dplCompanyName.SelectedValue = Request.QueryString("comp_id").ToString()
            lblMessage.Text = "<strong><em>" & dplCompanyName.SelectedItem.Text & "</strong></em> was updated successfully"
        End If
    End Sub

    Protected Sub ObjectDataSource_Files_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource_Files.Deleted
        Dim intAppCode As Int32 = Int32.Parse(e.ReturnValue)
        If intAppCode < 0 Then
            If intAppCode = -1 Then
                lblMessage.Text = "File can not be deleted if it has been deleted before."
            Else
                lblMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."
            End If

            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", lblMessage.Text.ToString().Replace("'", "\'")), True)

            lblMessage.Text = "<strong>Error:</strong> " & lblMessage.Text
        Else
            lblMessage.Text = "<strong>File was deleted</strong>"
            Me.grdPhoto.DataBind()
        End If
    End Sub

    Protected Sub ObjectDataSource_Store_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource_Store.Deleted
        Dim intAppCode As Int32 = Int32.Parse(e.ReturnValue)
        If intAppCode < 0 Then
            If intAppCode = -1 Then
                lblMessage.Text = "Store Location can not be deleted if it has been deleted before."
            Else
                lblMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."
            End If

            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", lblMessage.Text.ToString().Replace("'", "\'")), True)

            lblMessage.Text = "<strong>Error:</strong> " & lblMessage.Text
        Else
            lblMessage.Text = "<strong>Store Location was deleted</strong>"
            Me.grdPhoto.DataBind()
        End If
    End Sub
End Class
