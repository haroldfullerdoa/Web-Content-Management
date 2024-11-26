<%@ Page Language="VB" AutoEventWireup="false" %> 
<%@ Import Namespace="System.IO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<script runat="server" >
    Dim Cn As New OracleClient.OracleConnection
    Dim Cmd As New OracleClient.OracleCommand
    Dim par As OracleClient.OracleParameter
    Dim Fls As IO.FileStream
    
    Protected Sub ars(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Now I needed to open a connection to my Database:

        Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("DOAINT").ToString()
        Cn.Open()
        'Having done that I made my Command Object use the Connection and then constructed the parameter that should hold the BLOB.

        Cmd.Connection = Cn

        par = New OracleClient.OracleParameter
        par.OracleType = OracleClient.OracleType.Blob
        par.ParameterName = "i_FILE"
        'Now the FileStream is initialized, and is instructed to open the file:

        
        
        Dim iLength As Integer = CType(File1.PostedFile.InputStream.Length, Integer)
        If iLength = 0 Then Exit Sub 'not a valid file 
        Dim sContentType As String = File1.PostedFile.ContentType
        Dim sFileName As String
        Dim bytContent As Byte()
        ReDim bytContent(iLength) 'byte array, set to file size 


        sFileName = File1.PostedFile.FileName.Trim
        'Dim filename As String = Me.File1.Value '"D:\Documents and Settings\lichao00\My Documents\My Pictures\Funny pics\chinaCurrency_boy.gif"
        File1.PostedFile.InputStream.Read(bytContent, 0, iLength)

          
        
        'Fls = New FileStream(filename, FileMode.Open, FileAccess.Read)
        '    'After this I needed a Byte Array to store the bytes of the file in:

        'Dim bt As Byte()
        'ReDim bt(Fls.Length)
        'Fls.Read(bt, 0, System.Convert.ToInt32(Fls.Length))
        'Fls.Close()
        par.Value = bytContent 'bt '
            '       Now(I) 'm ready to insert the file using my Command Object:

        Cmd.CommandText = "Insert into CMS_COMPANY_FILE(COMPANY_ID,THEFILE, FILE_TYPE,FILE_FORMAT,FILE_CREATEDUSER) values(:i_Company_Id,:i_FILE,:i_FILE_TYPE,:i_FILE_FORMAT,:i_CREATED_USER)"
        Cmd.CommandType = CommandType.Text
        Cmd.Parameters.Add(par)
        Dim par1 As OracleClient.OracleParameter = New OracleClient.OracleParameter
        par1.OracleType = OracleClient.OracleType.Int32
        par1.ParameterName = "i_Company_ID"
        par1.Value = 1192
        Cmd.Parameters.Add(par1)
        Dim par2 As OracleClient.OracleParameter = New OracleClient.OracleParameter
        par2.OracleType = OracleClient.OracleType.VarChar
        par2.ParameterName = "i_FILE_TYPE"
        par2.Value = "test"
        Cmd.Parameters.Add(par2)
        Dim par3 As OracleClient.OracleParameter = New OracleClient.OracleParameter
        par3.OracleType = OracleClient.OracleType.VarChar
        par3.ParameterName = "i_FILE_FORMAT"
        par3.Value = sContentType
        Cmd.Parameters.Add(par3)
        Dim par4 As OracleClient.OracleParameter = New OracleClient.OracleParameter
        par4.OracleType = OracleClient.OracleType.VarChar
        par4.ParameterName = "i_CREATED_USER"
        par4.Value = "lichao00"
        Cmd.Parameters.Add(par4)
      

        Cmd.ExecuteNonQuery()
        Cmd.Dispose()
        Cn.Close()
            Me.Label1.Text = "image saved successfully!"
        viewImage(1192)
    End Sub

    Private Sub viewImage(ByVal intID)
        
        Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("DOAINT").ToString()
        Cn.Open()
        
        Dim strPath As String = "~/CMS/Images/photos/"
        Dim intFileID As Int32 = 0
        Dim intCompID As Int32 = 0
        Dim strType As String = ""
        Dim strExt As String = "gif"
        Dim strFileName = ""
        
        Cmd = New OracleClient.OracleCommand
        Cmd.Connection = Cn
        Cmd.CommandText = "Select * from CMS_COMPANY_FILE where COMPANY_ID = " & intID & " ORDER BY FILE_ID"
        Dim drdr As OracleClient.OracleDataReader
        drdr = Cmd.ExecuteReader()
        Dim bt() As Byte

        While drdr.Read
            intFileID = drdr.GetInt32(0)
            intCompID = drdr.GetInt32(1)
            bt = drdr.GetValue(2) ' drdr.Item(2)
            strType = drdr.GetString(4)
            
            Select Case strType
                Case "image/pjpeg"
                    strExt = "jpg"
                Case "image/gif"
                    strExt = "gif"
            End Select
            
            strFileName = intFileID.ToString() & "_" & intCompID.ToString() & "." & strExt
            
            Fls = New FileStream(MapPath(strPath) & strFileName, FileMode.Create)
            Fls.Write(bt, 0, bt.Length)
            Fls.Close()
        End While
        
        Me.Image1.ImageUrl = strPath & strFileName
        Me.Image1.Visible = True
        
        'Me.GridView1.DataSource = drdr
        'Me.GridView1.DataBind()
        
        Cn.Close()
    End Sub
    
Function CheckFileType(ByVal fName As String) As Boolean 
Dim ext As String = Path.GetExtension(fName) 

Select Case ext.ToLower() 
Case ".jpg"

Return True

Case ".jpeg"

Return True

Case ".bmp"

Return True

Case ".png"

Return True

Case ".tif"

Return True

Case ".gif"

Return True

Case Else

Return False

        End Select
    End Function


</script> 
 

 

 

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head id="Head1" runat="server">

<title>Untitled Page</title> 
</head>

<body>

<form id="form1" runat="server">

<div>

</div>

<asp:Label ID="Label1" runat="server" Text="FileName"></asp:Label>

<asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />

<input id="File1" type="file" runat="server" />

<br />
<asp:Button ID="Button1" runat="server" Text="Upload Image" />

<br />
    <asp:Image ID="Image1" runat="server" Visible="false" />
<br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</form> 

</body> 
</html>

