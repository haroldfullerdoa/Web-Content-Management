Imports HJAIA2008.BusinessLogicLayer
Imports System.IO
Partial Class CMS_Airside_Engine_Runs_Attachments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Not Page.IsPostBack Then
            Dim authCookie1 As HttpCookie = Session("Airside")
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
    Protected Sub Upload_File(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewFile.Click


        Dim Company_File As CMS
        Try
            'iniate the variables

            Dim strFileType As String = "PDF File"

            Dim intLength As Int32 = Int32.Parse(fileCompany.PostedFile.InputStream.Length)

            If intLength = 0 Then
                lblMessage.Text = "Please select a valid file to Upload."
                Exit Sub 'a empty file 
            End If

            Dim strFileContentType As String = fileCompany.PostedFile.ContentType
            Dim strFileExt As String = String.Empty


            If intLength / Math.Pow(1024, 2) > 5 Then 'can not larger than 5MB
                lblMessage.Text = "Your file is too big (exceeded 5 MB)."
                Exit Sub 'not a valid file size
            End If


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
            Company_File = New CMS(txtTitle.Text, bytContent, strFileName, strFileContentType)
            Company_File.Module_Type = DefaultValues.Airside
            Company_File.Admin_Action = "Add"

            Dim strAdmin_Name As String = String.Empty
            Dim authCookie1 As HttpCookie = Session("Airside")
            If (Not authCookie1 Is Nothing) Then
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                strAdmin_Name = authTicket1.UserData.ToString().ToUpper()
            End If
            Company_File.Admin_Name = strAdmin_Name
            Dim intAppCode As Int32 = Company_File.SaveNewContent(Company_File)

            If intAppCode = 0 Then '"True"
                'refresh the gridview of Attachments with newly added file
                Me.grdFiles.DataBind()
                Me.lblMessage.Text = "<strong>File was uploaded successfully!</strong>"
            Else
                lblMessage.Text = "Unexpected system problem occurred. Please contact Admin for the assistance."

            End If
        Catch ex As Exception
            lblMessage.Text = "Unexpected system problem(" & ex.Message & ") occurred. Please contact Admin for the assistance."
            'Display a client-side popup
            ClientScript.RegisterStartupScript(Me.GetType(), "ISDErr!", String.Format("alert('Error: {0}');", ex.Message.Replace("'", "\'")), True)
        Finally
            ''clean up
            Company_File = Nothing
            txtTitle.Text = ""
        End Try
    End Sub
    Protected Function Get_File_Name(ByVal pFile_ID As Int32, ByVal pFile_Data As Byte(), ByVal pFile_Name As String) As String

        'iniate the file path
        Dim strPath As String = "../Airside_Engine_Runs/Documents/"
        Dim strFileName As String = pFile_ID.ToString() & "_" & pFile_Name 'put the File_ID before theDim  file name to reduce the duplicates

        Dim Fls As System.IO.FileStream = New System.IO.FileStream(Server.MapPath(strPath & strFileName), System.IO.FileMode.Create)
        Fls.Write(pFile_Data, 0, pFile_Data.Length)
        Fls.Close()

        Return pFile_Name

    End Function

    Protected Function Get_File_URL(ByVal pFile_ID As Int32, ByVal pFile_Name As String) As String

        Return "~/CMS/Airside_Engine_Runs/Documents/" & pFile_ID.ToString() & "_" & pFile_Name

    End Function
    
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
            Me.grdFiles.DataBind()
        End If
    End Sub
End Class
