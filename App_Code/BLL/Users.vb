Imports Microsoft.VisualBasic
Imports System.Data.OracleClient

Public Class Users
    'Inherits System.Web.UI.Page

    Private _Id As Integer
    Private _Admin_Name As String = [String].Empty
    Private _Admin_Email As String = [String].Empty
    Private _Admin_Unit As String = [String].Empty
    Private _Admin_Action As String = [String].Empty
    Private _Press_Type As String = [String].Empty
    Private _Module_Type As String = [String].Empty

    Private _Prking_Lot_Name As String = [String].Empty
    Private _Parking_Status As String = [String].Empty

    Private _Store_Name As String = [String].Empty
    Private _Store_Description As String = [String].Empty
    Private _Store_Type As String = [String].Empty
    Private _Seating_Available As String = [String].Empty
    Private _Hours_Operation As String = [String].Empty
    Private _Close_Renovation As String = [String].Empty
    Private _Logo_File_Name As String = [String].Empty
    Private _Logo_File_Size As Integer = Nothing
    Private _Logo_File_Data As Byte() = {0}
    Private _Logo_File_Content As String = [String].Empty
    Private _Store_Phone As String = [String].Empty
    Private _Store_Locations As String = [String].Empty
    Private _Store_logo_Location As String = [String].Empty

    Private _Job_Ttle As String = [String].Empty
    Private _Salary_Range As String = [String].Empty
    Private _salary_Grade As String = [String].Empty
    Private _App_Date_From As String = [String].Empty
    Private _App_Date_To As String = [String].Empty
    Private _Job_Description As String = [String].Empty
    Private _Contact_Information As String = [String].Empty
    Private _Job_Alreadyposted As String = [String].Empty
    Private _JobDesc_URL As String = [String].Empty
    Private _JobApply_URL As String = [String].Empty

    Private _Alert_Title As String = [String].Empty
    Private _Alert_Desc As String = [String].Empty
    Private _Alert_Enabled As String = [String].Empty
    Private _Alert_ImgTag As String = [String].Empty
    Private _Alert_ImgUrl As String = [String].Empty
    Private _Alert_Link As String = [String].Empty
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
    Public Sub New(ByVal Id As Integer, ByVal Name As String, ByVal Email As String, ByVal BusinessUnit As String, Optional ByVal Action As String = Nothing, Optional ByVal module_type As String = Nothing, Optional ByVal Press_Type As String = Nothing)
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
    Public Sub New(ByVal store_id As Integer, ByVal store_name As String, ByVal store_Desc As String, ByVal store_type As String, ByVal seating As String, ByVal hours_open As String, ByVal close_renov As String, ByVal logofile_name As String, ByVal logofile_size As Integer, ByVal logofile_data As Byte() _
                    , ByVal logofile_content As String, ByVal phone_number As String, Optional ByVal store_locations As String = Nothing)
        _Id = store_id
        _Store_Name = store_name
        _Store_Description = store_Desc
        _Store_Type = store_type
        _Seating_Available = seating
        _Hours_Operation = hours_open
        _Close_Renovation = close_renov
        _Logo_File_Name = logofile_name
        _Logo_File_Size = logofile_size
        _Logo_File_Data = logofile_data
        _Logo_File_Content = logofile_content
        _Store_Phone = phone_number
        _Store_Locations = store_locations
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

    Public Property Store_Name() As String
        Get
            Return _Store_Name
        End Get
        Set(ByVal value As String)
            _Store_Name = value
        End Set
    End Property

    Public Property Store_Description() As String
        Get
            Return _Store_Description
        End Get
        Set(ByVal value As String)
            _Store_Description = value
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
    Public Property Close_Renovation() As String
        Get
            Return _Close_Renovation
        End Get
        Set(ByVal value As String)
            _Close_Renovation = value
        End Set
    End Property
    Public Property Logo_File_Name() As String
        Get
            Return _Logo_File_Name
        End Get
        Set(ByVal value As String)
            _Logo_File_Name = value
        End Set
    End Property
    Public Property Logo_File_Size() As Integer
        Get
            Return _Logo_File_Size
        End Get
        Set(ByVal value As Integer)
            _Logo_File_Size = value
        End Set
    End Property
    Public Property Logo_File_Data() As Byte()

        Get
            Return _Logo_File_Data
        End Get
        Set(ByVal value As Byte())
       
            _Logo_File_Data = value

        End Set
    End Property
    Public Property Logo_File_Content() As String
        Get
            Return _Logo_File_Content
        End Get
        Set(ByVal value As String)
            _Logo_File_Content = value
        End Set
    End Property
    Public Property Store_Phone() As String
        Get
            Return _Store_Phone
        End Get
        Set(ByVal value As String)
            _Store_Phone = value
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
    Public Property Store_Logo_Location() As String
        Get
            Return _Store_logo_Location
        End Get
        Set(ByVal value As String)
            _Store_logo_Location = value
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
    Public Function Savenewuser(ByVal user As Users) As String
        Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
        Return DBLayer.User_Admin(user)
    End Function
 
    'Public Sub SendMail()
    '    Dim DBLayer As DataAccessLayer = DBHelper.GetDataAccessLayer()
    '    DBLayer.Sendmail(Me.UserEmail, Me.Password)
    'End Sub
End Class
