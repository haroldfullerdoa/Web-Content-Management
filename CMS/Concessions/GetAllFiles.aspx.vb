Imports HJAIA2008.BusinessLogicLayer
Imports System.Data.OracleClient
Imports System.Data

Partial Class CMS_Concessions_GetAllFiles
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Function Get_File_Name(ByVal pFile_ID As Int32, ByVal pFile_Data As Byte(), ByVal pFile_Name As String, ByVal pFile_Type As String) As String

        'iniate the file path

        'If pFile_Type = "logo" Then
        '    Return Nothing
        '    Exit Function
        'End If

        Dim strPath As String = "../Images/" & pFile_Type & "/"
        Dim strFileName As String = pFile_ID.ToString() & "_" & pFile_Name 'put the File_ID before theDim  file name to reduce the duplicates

        Dim Fls As System.IO.FileStream = New System.IO.FileStream(Server.MapPath(strPath & strFileName), System.IO.FileMode.Create)
        Fls.Write(pFile_Data, 0, pFile_Data.Length)
        Fls.Close()

        If  String.Equals(pFile_Type, "offer") Then
            Return "<img src='../images/attach.gif' alt='Attach' width='13' height='12' class='alignLeft' />Download Offer - " & pFile_Name
        ElseIf String.Equals(pFile_Type, "menu") Then
            Return "<img src='../images/attach.gif' alt='Attach' width='13' height='12' class='alignLeft' />Download restaurant menu - " & pFile_Name
        Else
            Return "<img src='" & strPath & strFileName & "' style='width:400px;border-width:0px;' alt='click to view larger photo of " & pFile_Name & "' />"
        End If
    End Function

    Protected Function Get_File_URL(ByVal pFile_ID As Int32, ByVal pFile_Name As String, ByVal pFile_Type As String) As String

        Return "../Images/" & pFile_Type & "/" & pFile_ID.ToString() & "_" & pFile_Name

    End Function

    Public Function Get_Store_Seating(ByVal seating As String) As String
        If Not String.IsNullOrEmpty(seating) Then
            If String.Equals(seating.ToUpper(), "YES") Then
                Return "<span style='color:green;font-weight:bold;'>Yes</span>"
            Else
                Return "No"
            End If
        Else
            Return "No"
        End If
    End Function

End Class
