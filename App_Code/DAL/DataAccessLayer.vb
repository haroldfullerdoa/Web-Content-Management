Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Collections.Specialized
Imports System.data.OracleClient
Imports HJAIA2008.BusinessLogicLayer

Public MustInherit Class DataAccessLayer
    Private _connectionString As String

    '** PROPERTIES **
    'Connection String
    Public ReadOnly Property ConnectionString() As String
        Get
            Dim str As String = System.Configuration.ConfigurationManager.ConnectionStrings("DOAINT").ToString()
            If str Is Nothing OrElse str.Length <= 0 Then
                Throw (New ApplicationException("ConnectionString configuration is missing from you web.config. It should contain <appSettings><add key=""ConnectionString"" value=""database=IssueTrackerStarterKit;server=localhost;Trusted_Connection=true"" /></appSettings> "))
            Else
                Return str
            End If
        End Get
        'Set(ByVal value As String)
        '    _connectionString = value
        'End Set
    End Property

    '** FUNCTIONS **
    Public MustOverride Function GetUserById(ByVal userId As Integer, Optional ByVal Module_Type As String = Nothing) As Users
    Public MustOverride Function GetContentByID(ByVal contentId As Integer, Optional ByVal Module_Type As String = Nothing) As CMS
    Public MustOverride Function GetCollectionsByID(ByVal contentId As Integer, Optional ByVal Module_Type As String = Nothing) As ContentCollection
    Public MustOverride Function User_Admin(ByVal user As Users) As String
    Public MustOverride Function Content_Admin(ByVal content As CMS) As Int32
    Public MustOverride Function Content_Delete(ByVal content As CMS) As Int32
    Public MustOverride Function Login_Verify(ByVal Email As String, ByVal division As String) As Boolean
    Protected Delegate Function GenerateCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase

    Protected Function GenerateLoginCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim userCollection As New UserCollection()
        While returnData.Read()
            Dim newUser As New Users(CInt(returnData("USERID")), DirectCast(returnData("USERNAME"), String), DirectCast(returnData("USER_EMAIL"), String), DirectCast(returnData("DIVISION"), String))
            userCollection.Add(newUser)
        End While
        Return (userCollection)
    End Function
    Protected Function GenerateParkingCollectionFromScalar(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim userCollection As New UserCollection()
        While returnData.Read()
            Dim newUser As New Users(DirectCast(returnData("LOT_NAME"), String), DirectCast(returnData("STATUS"), String))
            userCollection.Add(newUser)
        End While
        Return (userCollection)
    End Function
    Protected Function GeneratePressCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim userCollection As New UserCollection()
        While returnData.Read()
            Dim newUser As New Users(CInt(returnData("PRESS_REL_ID")), DirectCast(returnData("PRESS_REL_TITLE"), String), DirectCast(returnData("REL_DATE"), Date), DirectCast(returnData("DETAIL_ARTICLE"), String))
            userCollection.Add(newUser)
        End While
        Return (userCollection)
    End Function
    Protected Function GeneratePressNewsCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim userCollection As New UserCollection()
        While returnData.Read()
            Dim newUser As New Users(CInt(returnData("NEWS_ID")), DirectCast(returnData("NEWS_TITLE"), String), DirectCast(returnData("NEWS_DATE"), Date), DirectCast(returnData("NEWS_ARTICLE"), String))
            userCollection.Add(newUser)
        End While
        Return (userCollection)
    End Function
    Protected Function GenerateConcessionsCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim contentCollection As New ContentCollection()
        While returnData.Read()
            Dim newConcessions As New CMS
            newConcessions.Id = CInt(returnData("COMPANY_ID"))
            newConcessions.Company_Name = returnData("COMPANY_NAME").ToString()
            newConcessions.Company_Description = returnData("COMPANY_DESCRIPTION").ToString()
            'newConcessions.Seating_Available = DirectCast(returnData("nvl(SEATING_AVAIL,0)"), String)
            'newConcessions.Hours_Operation = DirectCast(returnData("nvl(OPEARTING_HOURS,0)"), String)
            'newConcessions.Close_Renovation = DirectCast(returnData("nvl(CLOSED_RENOVATION,'nothing')"), String)
            newConcessions.Company_Phone1 = returnData("PHONE_NUMBER1").ToString()
            newConcessions.Company_Phone2 = returnData("PHONE_NUMBER2").ToString()
            newConcessions.Store_Type_ID = CInt(returnData("STORE_TYPE_ID"))
            newConcessions.Store_Type = returnData("STORE_TYPE").ToString()
            newConcessions.Company_Website = returnData("COMPANY_WEBSITE").ToString()
            'newConcessions.Store_Logo_Location = DirectCast(returnData("STORE_LOGO_LOCATION"), String)
            contentCollection.Add(newConcessions)
        End While

        Return (contentCollection)
    End Function
    Protected Function GenerateStoresCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim contentCollection As New ContentCollection()
        While returnData.Read()
            Dim newStores As New CMS
            newStores.Id = Int32.Parse(returnData("STORE_ID").ToString)
            newStores.Store_Location = returnData("STORE_LOCATION").ToString()
            newStores.Store_Location_ID = Int32.Parse(returnData("STORE_LOCATION_ID").ToString())
            newStores.Store_Phone1 = returnData("STORE_PHONE1").ToString()
            newStores.Store_Phone2 = returnData("STORE_PHONE2").ToString()
            newStores.Seating_Available = returnData("SEATING_AVAIL").ToString()
            newStores.Hours_Operation = returnData("HOURS_OPERATION").ToString
            newStores.Closed_Renovation = returnData("CLOSED_RENOVATION").ToString()
            newStores.Awarded = returnData("Awarded").ToString()
            contentCollection.Add(newStores)
        End While

        Return (contentCollection)
    End Function

    Protected Function GenerateFilesCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase

        Dim contentCollection As New ContentCollection()
        While returnData.Read()
            Dim newFile As New CMS
            newFile.Id = returnData.GetInt32(0) '("FILE_ID")
            newFile.Company_ID = returnData.GetInt32(1) '"COMPANY_ID"
            If Not IsDBNull(returnData(2)) Then '"THEFILE"
                Dim buffer() As Byte
                ' Retrieve the length of the necessary byte array.
                Dim len As Long = returnData.GetBytes(2, 0, Nothing, 0, 0)
                ' Create a buffer to hold the bytes, and then 
                ' read the bytes from the DataTableReader.
                ReDim buffer(CInt(len))
                returnData.GetBytes(2, 0, buffer, 0, CInt(len))
                newFile.Company_File_Data = buffer
            End If
            newFile.Company_File_Name = returnData.GetString(3) '"File_Name"
            newFile.Company_File_Type = returnData.GetString(4) '"FILE_TYPE"
            newFile.Company_File_Format = returnData.GetString(5).ToLower().Trim()

            contentCollection.Add(newFile)
        End While

        Return (contentCollection)


        ''iniate the file path
        'Dim strPath As String = "../images/"
        '' Get the current context
        'Dim currentContext As System.Web.HttpContext = System.Web.HttpContext.Current

        'Dim contentCollection As New ContentCollection()
        'While returnData.Read()
        '    Dim newFile As New CMS
        '    newFile.Id = Int32.Parse(returnData.GetInt32(0)) '("FILE_ID")
        '    newFile.Company_ID = Int32.Parse(returnData("COMPANY_ID").ToString())
        '    newFile.Company_File_Type = returnData("FILE_TYPE").ToString()
        '    newFile.Company_File_Format = returnData.GetString(4).ToLower().Trim()

        '    Dim strExt As String = CMS.CheckFileType(newFile.Company_File_Type, newFile.Company_File_Format)
        '    If String.IsNullOrEmpty(strExt) Then strExt = "gif"

        '    '    intFileID = drdr.GetInt32(0)
        '    '    bt = drdr.GetValue(2) ' drdr.Item(2)
        '    '    strType = drdr.GetString(4).ToLower().Trim()




        '    newFile.Company_File_Name = strPath & newFile.Company_File_Type.ToString() & "/" & newFile.Company_ID.ToString() & "_" & newFile.Id.ToString() & "." & strExt

        '    Dim bt() As Byte
        '    bt = returnData("THEFILE")
        '    Dim Fls As System.IO.FileStream = New System.IO.FileStream(currentContext.Server.MapPath(newFile.Company_File_Name.ToString()), System.IO.FileMode.Create)
        '    Fls.Write(bt, 0, bt.Length)
        '    Fls.Close()

        '    contentCollection.Add(newFile)
        'End While

        'Return (contentCollection)
    End Function


    Protected Function GenerateAirsideFilesCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase

        Dim contentCollection As New ContentCollection()
        While returnData.Read()
            Dim newFile As New CMS
            newFile.Id = returnData.GetInt32(0) '("FILE_ID")

            If Not IsDBNull(returnData(1)) Then '"THEFILE"
                Dim buffer() As Byte
                ' Retrieve the length of the necessary byte array.
                Dim len As Long = returnData.GetBytes(1, 0, Nothing, 0, 0)
                ' Create a buffer to hold the bytes, and then 
                ' read the bytes from the DataTableReader.
                ReDim buffer(CInt(len))
                returnData.GetBytes(1, 0, buffer, 0, CInt(len))
                newFile.Company_File_Data = buffer
            End If
            newFile.Company_File_Name = returnData.GetString(2) '"File_Name"
            newFile.Company_File_Format = returnData.GetString(3).ToLower().Trim()
            newFile.Company_File_Type = returnData.GetString(4).ToLower().Trim()
            newFile.Company_File_Created_Date = returnData.GetString(5).ToLower().Trim()

            contentCollection.Add(newFile)
        End While

        Return (contentCollection)
    End Function


    Protected Function GenerateHRCollectionFromReader(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim userCollection As New UserCollection()
        While returnData.Read()
            Dim newUser As New Users(CInt(returnData("JOB_ID")), DirectCast(returnData("nvl(JOB_TITLE,0)"), String), DirectCast(returnData("nvl(SAL_RANGE,0)"), String), DirectCast(returnData("nvl(SAL_GRADE,0)"), String), _
           DirectCast(returnData("nvl(APP_ACC_FROM,0)"), String), DirectCast(returnData("nvl(APP_ACC_TO,0)"), String), DirectCast(returnData("nvl(JOB_DESCRIPTION,0)"), String), DirectCast(returnData("nvl(CONTACT_INFO,0)"), String), _
            DirectCast(returnData("nvl(NEO_ALREADYPOSTED,0)"), String), DirectCast(returnData("nvl(JOB_DES_URL,0)"), String), DirectCast(returnData("nvl(APPLY_URL,0)"), String))
            userCollection.Add(newUser)
        End While
        Return (userCollection)
    End Function
    Protected Function GenerateAlertsCollectionFromScalar(ByVal returnData As Data.IDataReader) As CollectionBase
        Dim userCollection As New UserCollection()
        While returnData.Read()
            Dim newAlert As New Users
            newAlert.Id = CInt(returnData("ALERT_ID"))
            newAlert.Alert_Title = DirectCast(returnData("TITLE"), String)
            newAlert.Alert_Enabled = DirectCast(returnData("ENABLED"), String)
            newAlert.Alert_Desc = DirectCast(returnData("DESCRIPTION"), String)
            newAlert.Alert_ImgTag = DirectCast(returnData("IMG_TAG"), String)
            newAlert.Alert_ImgUrl = DirectCast(returnData("IMG_URL"), String)
            newAlert.Alert_Link = DirectCast(returnData("LINK_TO"), String)
            userCollection.Add(newAlert)
        End While
        Return (userCollection)
    End Function
End Class
