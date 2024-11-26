Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports system.web

Namespace HJAIA2008.BusinessLogicLayer

    Public Class CMS
        ' Inherits System.Web.UI.Page

        Private _Id As Integer
        Private _Module_Type As String = String.Empty

        Private _Admin_Name As String = String.Empty
        Private _Admin_Email As String = String.Empty
        Private _Admin_Unit As String = String.Empty
        Private _Admin_Action As String = String.Empty
        Private _Press_Type As String = String.Empty

        Private _Prking_Lot_Name As String = String.Empty
        Private _Parking_Status As String = String.Empty

        Private _Company_ID As Int32 = 0
        Private _Company_Name As String = String.Empty
        Private _Company_Description As String = String.Empty
        Private _Company_Phone1 As String = String.Empty
        Private _Company_Phone2 As String = String.Empty
        Private _Company_Website As String = String.Empty
        Private _Company_File_Name As String = String.Empty
        Private _Company_File_Type As String = String.Empty
        Private _Company_File_Format As String = String.Empty
        Private _Company_File_Data As Byte() = {0}
        Private _Company_File_Created_Date As String = String.Empty

        Private _Store_Type_ID As Integer = Nothing
        Private _Store_Type As String = String.Empty
        Private _Seating_Available As String = String.Empty
        Private _Hours_Operation As String = String.Empty
        Private _Closed_Renovation As String = String.Empty
        Private _Store_Phone1 As String = String.Empty
        Private _Store_Phone2 As String = String.Empty
        Private _Store_Location As String = String.Empty
        Private _Store_Location_ID As Integer = 0
        Private _Store_Locations As String = String.Empty
        Private _Awarded As String = String.Empty

        Private _Job_Ttle As String = String.Empty
        Private _Salary_Range As String = String.Empty
        Private _salary_Grade As String = String.Empty
        Private _App_Date_From As String = String.Empty
        Private _App_Date_To As String = String.Empty
        Private _Job_Description As String = String.Empty
        Private _Contact_Information As String = String.Empty
        Private _Job_Alreadyposted As String = String.Empty
        Private _JobDesc_URL As String = String.Empty
        Private _JobApply_URL As String = String.Empty

        Private _Alert_Title As String = String.Empty
        Private _Alert_Desc As String = String.Empty
        Private _Alert_Enabled As String = String.Empty
        Private _Alert_ImgTag As String = String.Empty
        Private _Alert_ImgUrl As String = String.Empty
        Private _Alert_Link As String = String.Empty
        Public Sub New()
            '
            ' TODO: Add constructor logic here
            '
        End Sub
        'Public Sub New(ByVal Id As Integer, ByVal Alert_Ttle As String, ByVal Alert_Desc As String, ByVal Alert_Enabled As String, ByVal Alert_ImgTag As String, ByVal Alert_ImgUrl As String, ByVal Alert_Link As String)
        '    _Id = Id
        '    _Alert_Ttle = Alert_Ttle
        '    _Alert_Desc = Alert_Desc
        '    _Alert_Enabled = Alert_Enabled
        '    _Alert_ImgTag = Alert_ImgTag
        '    _Alert_ImgUrl = Alert_ImgUrl
        '    _Alert_Link = Alert_Link
        'End Sub
        'for the deletion
        Public Sub New(ByVal Id As Integer, ByVal Module_Type As String)
            _Id = Id
            _Module_Type = Module_Type
        End Sub
        Public Sub New(ByVal Id As Integer, ByVal Name As String, ByVal Email As String, ByVal BusinessUnit As String, _
        Optional ByVal Action As String = Nothing, Optional ByVal module_type As String = Nothing, _
        Optional ByVal Press_Type As String = Nothing)
            _Id = Id
            _Admin_Name = Name
            _Admin_Email = Email
            _Admin_Unit = BusinessUnit
            _Admin_Action = Action
            _Press_Type = Press_Type
            _Module_Type = module_type
        End Sub
        Public Sub New(ByVal LotName As String, ByVal Status As String)
            _Prking_Lot_Name = LotName
            _Parking_Status = Status
        End Sub
        'for company
        Public Sub New(ByVal company_id As Integer, ByVal company_name As String, ByVal company_Desc As String, ByVal store_type_id As Int32, _
        ByVal phone_number1 As String, ByVal phone_number2 As String, ByVal company_website As String)
            _Id = company_id
            _Company_Name = company_name
            _Company_Description = company_Desc
            _Store_Type_ID = store_type_id
            _Company_Phone1 = phone_number1
            _Company_Phone2 = phone_number2
            _Company_Website = company_website
        End Sub
        'for company file
        Public Sub New(ByVal company_id As Integer, ByVal company_file_data As Byte(), ByVal company_file_name As String, ByVal company_file_Type As String, ByVal company_file_format As String)
            _Company_ID = company_id
            _Company_File_Data = company_file_data
            _Company_File_Name = company_file_name
            _Company_File_Type = company_file_Type
            _Company_File_Format = company_file_format
        End Sub
        'for Airside Engine Run-up  file
        Public Sub New(ByVal Title As String, ByVal company_file_data As Byte(), ByVal company_file_name As String, ByVal company_file_format As String)
            _Company_File_Type = Title
            _Company_File_Data = company_file_data
            _Company_File_Name = company_file_name
            _Company_File_Format = company_file_format
        End Sub
        Public Sub New(ByVal store_id As Integer, ByVal company_id As Integer, ByVal store_location_id As Integer, ByVal seating As String, ByVal hours_open As String, ByVal close_renov As String, ByVal phone_number1 As String, ByVal phone_number2 As String)
            _Id = store_id
            _Company_ID = company_id
            _Store_Phone1 = phone_number1
            _Store_Phone2 = phone_number2
            _Store_Location_ID = store_location_id
            _Seating_Available = seating
            _Hours_Operation = hours_open
            _Closed_Renovation = close_renov
        End Sub
        Public Sub New(ByVal Job_id As Integer, ByVal Job_Ttle As String, ByVal Salary_Range As String, ByVal salary_Grade As String, ByVal App_Date_From As String, ByVal App_Date_To As String, ByVal Job_Description As String, ByVal Contact_Information As String, ByVal Job_Alreadyposted As String, ByVal JobDesc_URL As String, ByVal JobApply_URL As String)
            _Id = Job_id
            _Job_Ttle = Job_Ttle
            _Salary_Range = Salary_Range
            _salary_Grade = salary_Grade
            _App_Date_From = App_Date_From
            _App_Date_To = App_Date_To
            _Job_Description = Job_Description
            _Contact_Information = Contact_Information
            _Job_Alreadyposted = Job_Alreadyposted
            _JobDesc_URL = JobDesc_URL
            _JobApply_URL = JobApply_URL
        End Sub
        Public Property Id() As Integer
            '* PROPERTIES *
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value

            End Set
        End Property
        Public Property Admin_Name() As String
            Get
                Return _Admin_Name
            End Get
            Set(ByVal value As String)
                _Admin_Name = value
            End Set
        End Property
        Public Property Admin_Email() As String
            Get
                Return _Admin_Email
            End Get
            Set(ByVal value As String)
                _Admin_Email = value
            End Set
        End Property
        Public Property Admin_Unit() As String
            Get
                Return _Admin_Unit
            End Get
            Set(ByVal value As String)
                _Admin_Unit = value
            End Set
        End Property

        Public Property Admin_Action() As String
            Get
                Return _Admin_Action
            End Get
            Set(ByVal value As String)
                _Admin_Action = value
            End Set
        End Property
        Public Property Prking_Lot_Name() As String
            Get
                Return _Prking_Lot_Name
            End Get
            Set(ByVal value As String)
                _Prking_Lot_Name = value
            End Set
        End Property
        Public Property ParkingStatus() As String
            Get
                Return _Parking_Status
            End Get
            Set(ByVal value As String)
                _Parking_Status = value
            End Set
        End Property
        Public Property Press_Type() As String
            Get
                Return _Press_Type
            End Get
            Set(ByVal value As String)
                _Press_Type = value
            End Set
        End Property
        Public Property Module_Type() As String
            Get
                Return _Module_Type
            End Get
            Set(ByVal value As String)
                _Module_Type = value
            End Set
        End Property

        Public Property Company_ID() As Int32
            Get
                Return _Company_ID
            End Get
            Set(ByVal value As Int32)
                _Company_ID = value
            End Set
        End Property
        Public Property Company_Name() As String
            Get
                Return _Company_Name
            End Get
            Set(ByVal value As String)
                _Company_Name = value
            End Set
        End Property

        Public Property Company_Description() As String
            Get
                Return _Company_Description
            End Get
            Set(ByVal value As String)
                _Company_Description = value
            End Set
        End Property

        Public Property Seating_Available() As String
            Get
                Return _Seating_Available
            End Get
            Set(ByVal value As String)
                _Seating_Available = value
            End Set
        End Property

        Public Property Hours_Operation() As String
            Get
                Return _Hours_Operation
            End Get
            Set(ByVal value As String)
                _Hours_Operation = value
            End Set
        End Property
        Public Property Closed_Renovation() As String
            Get
                Return _Closed_Renovation
            End Get
            Set(ByVal value As String)
                _Closed_Renovation = value
            End Set
        End Property
        Public Property Company_Phone1() As String
            Get
                Return _Company_Phone1
            End Get
            Set(ByVal value As String)
                _Company_Phone1 = value
            End Set
        End Property
        Public Property Company_Phone2() As String
            Get
                Return _Company_Phone2
            End Get
            Set(ByVal value As String)
                _Company_Phone2 = value
            End Set
        End Property

        Public Property Store_Type_ID() As Integer
            Get
                Return _Store_Type_ID
            End Get
            Set(ByVal value As Integer)
                _Store_Type_ID = value
            End Set
        End Property
        Public Property Store_Type() As String
            Get
                Return _Store_Type
            End Get
            Set(ByVal value As String)
                _Store_Type = value
            End Set
        End Property
        Public Property Company_Website() As String
            Get
                Return _Company_Website
            End Get
            Set(ByVal value As String)
                _Company_Website = value
            End Set
        End Property
        Public Property Company_File_Name() As String
            Get
                Return _Company_File_Name
            End Get
            Set(ByVal value As String)
                _Company_File_Name = value
            End Set
        End Property

        Public Property Company_File_Data() As Byte()

            Get
                Return _Company_File_Data
            End Get
            Set(ByVal value As Byte())

                _Company_File_Data = value

            End Set
        End Property
        Public Property Company_File_Type() As String
            Get
                Return _Company_File_Type
            End Get
            Set(ByVal value As String)
                _Company_File_Type = value
            End Set
        End Property
        Public Property Company_File_Format() As String
            Get
                Return _Company_File_Format
            End Get
            Set(ByVal value As String)
                _Company_File_Format = value
            End Set
        End Property
        Public Property Company_File_Created_Date() As String
            Get
                Return _Company_File_Created_Date
            End Get
            Set(ByVal value As String)
                _Company_File_Created_Date = value
            End Set
        End Property
        Public Property Store_Phone1() As String
            Get
                Return _Store_Phone1
            End Get
            Set(ByVal value As String)
                _Store_Phone1 = value
            End Set
        End Property
        Public Property Store_Phone2() As String
            Get
                Return _Store_Phone2
            End Get
            Set(ByVal value As String)
                _Store_Phone2 = value
            End Set
        End Property
        Public Property Store_Location() As String
            Get
                Return _Store_Location
            End Get
            Set(ByVal value As String)
                _Store_Location = value
            End Set
        End Property
        Public Property Store_Location_ID() As Integer
            Get
                Return _Store_Location_ID
            End Get
            Set(ByVal value As Integer)
                _Store_Location_ID = value
            End Set
        End Property
        Public Property Store_Locations() As String
            Get
                Return _Store_Locations
            End Get
            Set(ByVal value As String)
                _Store_Locations = value
            End Set
        End Property
        Public Property Awarded() As String
            Get
                Return _Awarded
            End Get
            Set(ByVal value As String)
                _Awarded = value
            End Set
        End Property

        Public Property Job_Ttle() As String
            Get
                Return _Job_Ttle
            End Get
            Set(ByVal value As String)
                _Job_Ttle = value
            End Set
        End Property

        Public Property Salary_Range() As String
            Get
                Return _Salary_Range
            End Get
            Set(ByVal value As String)
                _Salary_Range = value
            End Set
        End Property
        Public Property salary_Grade() As String
            Get
                Return _salary_Grade
            End Get
            Set(ByVal value As String)
                _salary_Grade = value
            End Set
        End Property
        Public Property App_Date_From() As String
            Get
                Return _App_Date_From
            End Get
            Set(ByVal value As String)
                _App_Date_From = value
            End Set
        End Property
        Public Property App_Date_To() As String
            Get
                Return _App_Date_To
            End Get
            Set(ByVal value As String)
                _App_Date_To = value
            End Set
        End Property
        Public Property Job_Description() As String
            Get
                Return _Job_Description
            End Get
            Set(ByVal value As String)
                _Job_Description = value
            End Set
        End Property
        Public Property Contact_Information() As String
            Get
                Return _Contact_Information
            End Get
            Set(ByVal value As String)
                _Contact_Information = value
            End Set
        End Property
        Public Property Job_Alreadyposted() As String
            Get
                Return _Job_Alreadyposted
            End Get
            Set(ByVal value As String)
                _Job_Alreadyposted = value
            End Set
        End Property
        Public Property JobDesc_URL() As String
            Get
                Return _JobDesc_URL
            End Get
            Set(ByVal value As String)
                _JobDesc_URL = value
            End Set
        End Property
        Public Property JobApply_URL() As String
            Get
                Return _JobApply_URL
            End Get
            Set(ByVal value As String)
                _JobApply_URL = value
            End Set
        End Property
        Public Property Alert_Title() As String
            Get
                Return _Alert_Title
            End Get
            Set(ByVal value As String)
                _Alert_Title = value
            End Set
        End Property
        Public Property Alert_Desc() As String
            Get
                Return _Alert_Desc
            End Get
            Set(ByVal value As String)
                _Alert_Desc = value
            End Set
        End Property
        Public Property Alert_Enabled() As String
            Get
                Return _Alert_Enabled
            End Get
            Set(ByVal value As String)
                _Alert_Enabled = value
            End Set
        End Property
        Public Property Alert_ImgTag() As String
            Get
                Return _Alert_ImgTag
            End Get
            Set(ByVal value As String)
                _Alert_ImgTag = value
            End Set
        End Property
        Public Property Alert_ImgUrl() As String
            Get
                Return _Alert_ImgUrl
            End Get
            Set(ByVal value As String)
                _Alert_ImgUrl = value
            End Set
        End Property
        Public Property Alert_Link() As String
            Get
                Return _Alert_Link
            End Get
            Set(ByVal value As String)
                _Alert_Link = value
            End Set
        End Property

        Public Shared Function Login_Verify(ByVal userId As String, ByVal division As String) As Boolean
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return (DBLayer.Login_Verify(userId, division))

        End Function

        Public Shared Function GetUserById(ByVal userId As Integer, Optional ByVal module_type As String = Nothing) As Users
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return (DBLayer.GetUserById(userId, module_type))

        End Function

        Public Shared Function GetContentByID(ByVal contentId As Integer, Optional ByVal module_type As String = Nothing) As CMS
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return (DBLayer.GetContentByID(contentId, module_type))
        End Function

        Public Shared Function GetCollectionsByID(ByVal contentId As Integer, Optional ByVal module_type As String = Nothing) As ContentCollection
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return (DBLayer.GetCollectionsByID(contentId, module_type))
        End Function


        Public Function Savenewuser(ByVal user As Users) As String
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return DBLayer.User_Admin(user)
        End Function

        Public Function SaveNewContent(ByVal content As CMS) As Int32
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return DBLayer.Content_Admin(content)
        End Function

        Public Function DeleteContent(ByVal content As CMS) As Int32
            Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
            Return DBLayer.Content_Delete(content)
        End Function

        Public Function UpdateStoreLocation(ByVal ID As Int32, ByVal Store_Phone1 As String, ByVal Store_Phone2 As String, ByVal Store_Location_ID As Int32, ByVal Hours_Operation As String, ByVal Seating_Available As String, ByVal Closed_Renovation As String, ByVal Awarded As String) As Int32
            Dim content As New CMS
            content.Id = ID
            content.Admin_Action = "Update"
            content.Module_Type = DefaultValues.Concessions_Stores

            'donot trust user input, always check the null and length according to db setup
            If Store_Phone1 IsNot Nothing Then
                content.Store_Phone1 = Store_Phone1.Trim()
                If content.Store_Phone1.Length > 30 Then content.Store_Phone1 = content.Store_Phone1.Substring(0, 30)
            End If

            If Store_Phone2 IsNot Nothing Then
                content.Store_Phone2 = Store_Phone2.Trim()
                If content.Store_Phone2.Length > 30 Then content.Store_Phone2 = content.Store_Phone2.Substring(0, 30)
            End If
            content.Store_Location_ID = Int32.Parse(Store_Location_ID)

            If Seating_Available IsNot Nothing Then
                'If Seating_Available.Trim().Length > 3 Then Seating_Available = Seating_Available.Trim().Substring(0, 3)
                If String.Equals(Seating_Available.Trim.Substring(0, 1).ToUpper(), "Y") Or String.Equals(Seating_Available.Trim.Substring(0, 1).ToUpper(), "T") Then
                    content.Seating_Available = "YES"
                Else
                    content.Seating_Available = "N/A"
                End If
            End If

            If Closed_Renovation IsNot Nothing Then
                ' If Closed_Renovation.Trim().Length > 3 Then Closed_Renovation = Closed_Renovation.Trim().Substring(0, 3)
                If String.Equals(Closed_Renovation.Trim.Substring(0, 1).ToUpper(), "Y") Or String.Equals(Closed_Renovation.Trim.Substring(0, 1).ToUpper(), "T") Then
                    content.Closed_Renovation = "YES"
                Else
                    content.Closed_Renovation = "NO"
                End If
            End If


            If Awarded IsNot Nothing Then

                If String.Equals(Awarded.Trim.Substring(0, 1).ToUpper(), "Y") Or String.Equals(Awarded.Trim.Substring(0, 1).ToUpper(), "T") Then
                    content.Awarded = "YES"
                Else
                    content.Awarded = "NO"
                End If
            End If

            content.Hours_Operation = Hours_Operation

            Return SaveNewContent(content)

        End Function

        Public Function DeleteContentByID(ByVal ID As Int32, ByVal Module_Type As String) As Int32
            Dim content As New CMS(ID, Module_Type)

            Return DeleteContent(content)

        End Function


        Public Shared Function CheckFileType(ByVal fType As String, ByVal fFormat As String) As String
            Dim strExt As String = String.Empty

            If String.Equals(fType, DefaultValues.File_Type_Photo) Then
                Select Case fFormat.ToLower()
                    Case "image/pjpeg"
                        strExt = "jpg"
                    Case "image/gif"
                        strExt = "gif"
                    Case "image/x-png"
                        strExt = "png"
                    Case "image/bmp"
                        strExt = "bmp"
                    Case Else
                        strExt = ""
                End Select

            ElseIf String.Equals(fType, DefaultValues.File_Type_Menu) Then
                Select Case fFormat.ToLower()
                    Case "image/pjpeg"
                        strExt = "jpg"
                    Case "image/gif"
                        strExt = "gif"
                    Case "image/x-png"
                        strExt = "png"
                    Case "image/tiff"
                        strExt = "tif"
                    Case "image/bmp"
                        strExt = "bmp"
                    Case "application/msword"
                        strExt = "doc"
                    Case "application/pdf"
                        strExt = "pdf"
                    Case "text/html"
                        strExt = "htm"
                    Case "application/x-zip-compressed"
                        strExt = "zip"
                    Case Else
                        strExt = ""
                End Select

            ElseIf String.Equals(fType, DefaultValues.File_Type_logo) Then
                Select Case fFormat.ToLower()
                    Case "image/pjpeg"
                        strExt = "jpg"
                    Case "image/gif"
                        strExt = "gif"
                    Case "image/x-png"
                        strExt = "png"
                    Case "image/bmp"
                        strExt = "bmp"
                    Case Else
                        strExt = ""
                End Select


            ElseIf String.Equals(fType, DefaultValues.File_Type_Offer) Then
                Select Case fFormat.ToLower()
                    Case "image/pjpeg"
                        strExt = "jpg"
                    Case "image/gif"
                        strExt = "gif"
                    Case "image/x-png"
                        strExt = "png"
                    Case "image/tiff"
                        strExt = "tif"
                    Case "image/bmp"
                        strExt = "bmp"
                    Case "application/msword"
                        strExt = "doc"
                    Case "application/pdf"
                        strExt = "pdf"
                    Case "text/html"
                        strExt = "htm"
                    Case "application/x-zip-compressed"
                        strExt = "zip"
                    Case Else
                        strExt = ""
                End Select

            End If

            Return strExt

        End Function

    End Class

End Namespace