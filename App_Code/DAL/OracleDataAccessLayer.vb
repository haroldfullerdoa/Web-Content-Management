Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OracleClient
Imports System.Collections
Imports System.Collections.Specialized
Imports HJAIA2008.BusinessLogicLayer

Public Class OracleDataAccessLayer
    Inherits DataAccessLayer

    Public Overrides Function Login_Verify(ByVal Email As String, ByVal division As String) As Boolean
        If Email Is Nothing Then
            Throw (New ArgumentNullException("Email"))
        End If
        Dim oracleCmd As New OracleCommand()
        AddParamTooracleCmd(oracleCmd, "i_UserNAME", OracleType.VarChar, ParameterDirection.Input, Email)
        AddParamTooracleCmd(oracleCmd, "i_Division", OracleType.VarChar, ParameterDirection.Input, division)
        AddParamTooracleCmd(oracleCmd, "return_value", OracleType.Number, ParameterDirection.ReturnValue, Nothing)
        SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.CkLogon")
        ExecuteScalarCmd(oracleCmd)
        If oracleCmd.Parameters("return_value").Value = 1 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Overrides Function GetUserById(ByVal userId As Integer, Optional ByVal Module_Type As String = Nothing) As Users
        Dim oracleCmd As New OracleCommand()
        ' If it is Admin module
        If Module_Type = DefaultValues.Admin Then

            AddParamTooracleCmd(oracleCmd, "i_UserId", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_usercur", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetUserbyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateLoginCollectionFromReader)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If
            'If it is Airport News Story module
        ElseIf Module_Type = "News" Then
            AddParamTooracleCmd(oracleCmd, "i_module_type", OracleType.VarChar, ParameterDirection.Input, Module_Type)
            AddParamTooracleCmd(oracleCmd, "i_NewsId", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_NewsCurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetPressDetailsById")
            Dim test As New GenerateCollectionFromReader(AddressOf GeneratePressNewsCollectionFromReader)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If
            'If it is Press Release module 
        ElseIf Module_Type = "Press" Then
            AddParamTooracleCmd(oracleCmd, "i_module_type", OracleType.VarChar, ParameterDirection.Input, Module_Type)
            AddParamTooracleCmd(oracleCmd, "i_NewsId", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_NewsCurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetPressDetailsById")
            Dim test As New GenerateCollectionFromReader(AddressOf GeneratePressCollectionFromReader)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If
            'If it is Concessions module 
        ElseIf Module_Type = DefaultValues.Concessions Then
            AddParamTooracleCmd(oracleCmd, "i_Storeid", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_store_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetStorebyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateConcessionsCollectionFromReader)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If

            ' If it is HR module 

        ElseIf Module_Type = DefaultValues.HR Then
            AddParamTooracleCmd(oracleCmd, "i_JobId", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_Jobcurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetJobbyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateHRCollectionFromReader)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If

            'If it is Parking Module
        ElseIf Module_Type = DefaultValues.Parking Then
            AddParamTooracleCmd(oracleCmd, "i_Lotid", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_StatusCur", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetParkingStatusbyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateParkingCollectionFromScalar)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If

            'If it is Airport Alerts 

        ElseIf Module_Type = DefaultValues.AirportAlert Then
            AddParamTooracleCmd(oracleCmd, "i_AlertId", OracleType.Number, ParameterDirection.Input, Int16.Parse(userId))
            AddParamTooracleCmd(oracleCmd, "o_Alert", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetAirportAlertById")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateAlertsCollectionFromScalar)
            Dim userCollection As UserCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), UserCollection)
            If userCollection.Count > 0 Then
                Return userCollection(0)
            Else
                Return Nothing
            End If


        Else
            Return Nothing
        End If

    End Function

    Public Overrides Function GetContentByID(ByVal contentId As Integer, Optional ByVal Module_Type As String = Nothing) As CMS
        Dim oracleCmd As New OracleCommand()
        ' If it is Admin module
        If Module_Type = DefaultValues.Admin Then

            AddParamTooracleCmd(oracleCmd, "i_userID", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_usercur", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetUserbyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateLoginCollectionFromReader)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If
            'If it is Airport News Story module
        ElseIf Module_Type = "News" Then
            AddParamTooracleCmd(oracleCmd, "i_module_type", OracleType.VarChar, ParameterDirection.Input, Module_Type)
            AddParamTooracleCmd(oracleCmd, "i_NewsId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_NewsCurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetPressDetailsById")
            Dim test As New GenerateCollectionFromReader(AddressOf GeneratePressNewsCollectionFromReader)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If
            'If it is Press Release module 
        ElseIf Module_Type = "Press" Then
            AddParamTooracleCmd(oracleCmd, "i_module_type", OracleType.VarChar, ParameterDirection.Input, Module_Type)
            AddParamTooracleCmd(oracleCmd, "i_NewsId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_NewsCurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetPressDetailsById")
            Dim test As New GenerateCollectionFromReader(AddressOf GeneratePressCollectionFromReader)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If
            'If it is Concessions module 
        ElseIf Module_Type = DefaultValues.Concessions Then
            AddParamTooracleCmd(oracleCmd, "i_company_id", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_company_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetCompanyByID")
            Dim drCollection As New GenerateCollectionFromReader(AddressOf GenerateConcessionsCollectionFromReader)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, drCollection), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If

            'If it is Concessions Store module 
        ElseIf Module_Type = DefaultValues.Concessions_Stores Then
            AddParamTooracleCmd(oracleCmd, "i_company_id", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_stores_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetStoresByCompID")
            Dim drCollection As New GenerateCollectionFromReader(AddressOf GenerateStoresCollectionFromReader)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, drCollection), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If

            ' If it is HR module 

        ElseIf Module_Type = DefaultValues.HR Then
            AddParamTooracleCmd(oracleCmd, "i_JobId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_Jobcurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetJobbyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateHRCollectionFromReader)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If

            'If it is Parking Module
        ElseIf Module_Type = DefaultValues.Parking Then
            AddParamTooracleCmd(oracleCmd, "i_Lotid", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_StatusCur", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetParkingStatusbyId")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateParkingCollectionFromScalar)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If

            'If it is Airport Alerts 

        ElseIf Module_Type = DefaultValues.AirportAlert Then
            AddParamTooracleCmd(oracleCmd, "i_AlertId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
            AddParamTooracleCmd(oracleCmd, "o_Alert", OracleType.Cursor, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetAirportAlertById")
            Dim test As New GenerateCollectionFromReader(AddressOf GenerateAlertsCollectionFromScalar)
            Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
            If contentCollection.Count > 0 Then
                Return contentCollection(0)
            Else
                Return Nothing
            End If


        Else
            Return Nothing
        End If

    End Function

    Public Overrides Function GetCollectionsByID(ByVal contentId As Integer, Optional ByVal Module_Type As String = Nothing) As ContentCollection
        Dim oracleCmd As New OracleCommand()
        Select Case (Module_Type)
            ''If it is Concessions Store module 
            Case DefaultValues.Concessions_Stores
                AddParamTooracleCmd(oracleCmd, "i_company_id", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
                AddParamTooracleCmd(oracleCmd, "o_stores_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
                SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetStoresByCompID")
                Dim drCollection As New GenerateCollectionFromReader(AddressOf GenerateStoresCollectionFromReader)
                Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, drCollection), ContentCollection)
                If contentCollection.Count > 0 Then
                    Return contentCollection
                Else
                    Return Nothing
                End If
            Case DefaultValues.Company_Files.ToString()
                AddParamTooracleCmd(oracleCmd, "i_company_id", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
                AddParamTooracleCmd(oracleCmd, "o_company_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
                SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetFilesByCompID")
                Dim drCollection As New GenerateCollectionFromReader(AddressOf GenerateFilesCollectionFromReader)
                Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, drCollection), ContentCollection)
                If contentCollection.Count > 0 Then
                    Return contentCollection
                Else
                    Return Nothing
                End If

            Case DefaultValues.Airside.ToString()
                AddParamTooracleCmd(oracleCmd, "o_company_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
                SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetAirsideFilesByCompID")
                Dim drCollection As New GenerateCollectionFromReader(AddressOf GenerateAirsideFilesCollectionFromReader)
                Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, drCollection), ContentCollection)
                If contentCollection.Count > 0 Then
                    Return contentCollection
                Else
                    Return Nothing
                End If


        End Select

        '' If it is Admin module
        'If Module_Type = DefaultValues.Admin Then

        '    'AddParamTooracleCmd(oracleCmd, "i_userID", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_usercur", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetUserbyId")
        '    'Dim test As New GenerateCollectionFromReader(AddressOf GenerateLoginCollectionFromReader)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If
        '    ''If it is Airport News Story module
        'ElseIf Module_Type = "News" Then
        '    'AddParamTooracleCmd(oracleCmd, "i_module_type", OracleType.VarChar, ParameterDirection.Input, Module_Type)
        '    'AddParamTooracleCmd(oracleCmd, "i_NewsId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_NewsCurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetPressDetailsById")
        '    'Dim test As New GenerateCollectionFromReader(AddressOf GeneratePressNewsCollectionFromReader)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If
        '    ''If it is Press Release module 
        'ElseIf Module_Type = "Press" Then
        '    'AddParamTooracleCmd(oracleCmd, "i_module_type", OracleType.VarChar, ParameterDirection.Input, Module_Type)
        '    'AddParamTooracleCmd(oracleCmd, "i_NewsId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_NewsCurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetPressDetailsById")
        '    'Dim test As New GenerateCollectionFromReader(AddressOf GeneratePressCollectionFromReader)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If
        '    ''If it is Concessions module 
        'ElseIf Module_Type = DefaultValues.Concessions Then
        '    'AddParamTooracleCmd(oracleCmd, "i_company_id", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_company_curr", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetCompanyByID")
        '    'Dim drCollection As New GenerateCollectionFromReader(AddressOf GenerateConcessionsCollectionFromReader)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, drCollection), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If


        'ElseIf Module_Type = DefaultValues.Concessions_Stores Then

        '    ' If it is HR module 

        'ElseIf Module_Type = DefaultValues.HR Then
        '    'AddParamTooracleCmd(oracleCmd, "i_JobId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_Jobcurr", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetJobbyId")
        '    'Dim test As New GenerateCollectionFromReader(AddressOf GenerateHRCollectionFromReader)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If

        '    ''If it is Parking Module
        'ElseIf Module_Type = DefaultValues.Parking Then
        '    'AddParamTooracleCmd(oracleCmd, "i_Lotid", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_StatusCur", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetParkingStatusbyId")
        '    'Dim test As New GenerateCollectionFromReader(AddressOf GenerateParkingCollectionFromScalar)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If

        '    ''If it is Airport Alerts 

        'ElseIf Module_Type = DefaultValues.AirportAlert Then
        '    'AddParamTooracleCmd(oracleCmd, "i_AlertId", OracleType.Number, ParameterDirection.Input, Int16.Parse(contentId))
        '    'AddParamTooracleCmd(oracleCmd, "o_Alert", OracleType.Cursor, ParameterDirection.Output, Nothing)
        '    'SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.GetAirportAlertById")
        '    'Dim test As New GenerateCollectionFromReader(AddressOf GenerateAlertsCollectionFromScalar)
        '    'Dim contentCollection As ContentCollection = DirectCast(ExecuteReaderCmd(oracleCmd, test), ContentCollection)
        '    'If contentCollection.Count > 0 Then
        '    '    Return contentCollection(0)
        '    'Else
        '    Return Nothing
        '    'End If


        'Else
        '    Return Nothing
        'End If
        Return Nothing
    End Function

    Public Overrides Function User_Admin(ByVal newUser As Users) As String

        If newUser Is Nothing Then
            Throw (New ArgumentNullException("newUser"))
        End If

        Dim oracleCmd As New OracleCommand()
        oracleCmd = New OracleCommand()
        If newUser.Module_Type = DefaultValues.Admin Then
            AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Action)
            AddParamTooracleCmd(oracleCmd, "i_UserName", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Name)
            AddParamTooracleCmd(oracleCmd, "i_UserEmail", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Email)
            AddParamTooracleCmd(oracleCmd, "i_Division", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Unit)
            AddParamTooracleCmd(oracleCmd, "i_UserID", OracleType.Number, ParameterDirection.Input, Int16.Parse(newUser.Id))
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Number, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_ADMIN")
        ElseIf newUser.Module_Type = DefaultValues.Press_News Then
            AddParamTooracleCmd(oracleCmd, "i_Press_Type", OracleType.VarChar, ParameterDirection.Input, newUser.Press_Type)
            AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Action)
            AddParamTooracleCmd(oracleCmd, "i_News_Id", OracleType.Number, ParameterDirection.Input, Int16.Parse(newUser.Id))
            AddParamTooracleCmd(oracleCmd, "i_News_Title", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Name)
            AddParamTooracleCmd(oracleCmd, "i_News_Date", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Email)
            AddParamTooracleCmd(oracleCmd, "i_News_Article", OracleType.Clob, ParameterDirection.Input, newUser.Admin_Unit)
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_PRESS")
        ElseIf newUser.Module_Type = DefaultValues.Concessions Then
            AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Action)
            AddParamTooracleCmd(oracleCmd, "i_Store_Id", OracleType.Number, ParameterDirection.Input, Int16.Parse(newUser.Id))
            AddParamTooracleCmd(oracleCmd, "i_Store_Name", OracleType.VarChar, ParameterDirection.Input, newUser.Store_Name)
            AddParamTooracleCmd(oracleCmd, "i_Store_Desc", OracleType.VarChar, ParameterDirection.Input, newUser.Store_Description)
            AddParamTooracleCmd(oracleCmd, "i_Store_Type", OracleType.VarChar, ParameterDirection.Input, newUser.Store_Type)
            AddParamTooracleCmd(oracleCmd, "i_Seat_Avl", OracleType.VarChar, ParameterDirection.Input, newUser.Seating_Available)
            AddParamTooracleCmd(oracleCmd, "i_Open_Time", OracleType.VarChar, ParameterDirection.Input, newUser.Hours_Operation)
            AddParamTooracleCmd(oracleCmd, "i_Close_Renv", OracleType.VarChar, ParameterDirection.Input, newUser.Close_Renovation)
            AddParamTooracleCmd(oracleCmd, "i_Phone", OracleType.VarChar, ParameterDirection.Input, newUser.Store_Phone)
            AddParamTooracleCmd(oracleCmd, "i_Store_Logo_Location", OracleType.VarChar, ParameterDirection.Input, newUser.Store_Logo_Location)
            AddParamTooracleCmd(oracleCmd, "i_store_locations", OracleType.VarChar, ParameterDirection.Input, newUser.Store_Locations)
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_STORES")

        ElseIf newUser.Module_Type = DefaultValues.HR Then
            AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Action)
            AddParamTooracleCmd(oracleCmd, "i_JobID", OracleType.Number, ParameterDirection.Input, Int16.Parse(newUser.Id))
            AddParamTooracleCmd(oracleCmd, "i_JobTitle", OracleType.VarChar, ParameterDirection.Input, newUser.Job_Ttle)
            AddParamTooracleCmd(oracleCmd, "i_Salary_Range", OracleType.VarChar, ParameterDirection.Input, newUser.Salary_Range)
            AddParamTooracleCmd(oracleCmd, "i_Salary_Grade", OracleType.VarChar, ParameterDirection.Input, newUser.salary_Grade)
            AddParamTooracleCmd(oracleCmd, "i_App_From", OracleType.VarChar, ParameterDirection.Input, newUser.App_Date_From)
            AddParamTooracleCmd(oracleCmd, "i_App_To", OracleType.VarChar, ParameterDirection.Input, newUser.App_Date_To)
            AddParamTooracleCmd(oracleCmd, "i_Job_Description", OracleType.VarChar, ParameterDirection.Input, newUser.Job_Description)
            AddParamTooracleCmd(oracleCmd, "i_Contactinfo", OracleType.VarChar, ParameterDirection.Input, newUser.Contact_Information)
            AddParamTooracleCmd(oracleCmd, "i_Job_AlreadyPosted", OracleType.VarChar, ParameterDirection.Input, newUser.Job_Alreadyposted)
            AddParamTooracleCmd(oracleCmd, "i_JobDes_URL", OracleType.VarChar, ParameterDirection.Input, newUser.JobDesc_URL)
            AddParamTooracleCmd(oracleCmd, "i_Apply_Link", OracleType.VarChar, ParameterDirection.Input, newUser.JobApply_URL)
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_JOBS")

        ElseIf newUser.Module_Type = DefaultValues.Parking Then
            AddParamTooracleCmd(oracleCmd, "i_Lotid", OracleType.Number, ParameterDirection.Input, Int16.Parse(newUser.Id))
            AddParamTooracleCmd(oracleCmd, "i_Lot_Name", OracleType.VarChar, ParameterDirection.Input, newUser.Prking_Lot_Name)
            AddParamTooracleCmd(oracleCmd, "i_Lot_Status", OracleType.VarChar, ParameterDirection.Input, newUser.ParkingStatus)
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_PARKING_LOT")

        ElseIf newUser.Module_Type = DefaultValues.AirportAlert Then
            AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newUser.Admin_Action)
            AddParamTooracleCmd(oracleCmd, "i_AlertId", OracleType.Number, ParameterDirection.Input, Int16.Parse(newUser.Id))
            AddParamTooracleCmd(oracleCmd, "i_enabled", OracleType.VarChar, ParameterDirection.Input, newUser.Alert_Enabled)
            AddParamTooracleCmd(oracleCmd, "i_title", OracleType.VarChar, ParameterDirection.Input, newUser.Alert_Title)
            AddParamTooracleCmd(oracleCmd, "i_desc", OracleType.VarChar, ParameterDirection.Input, newUser.Alert_Desc)
            AddParamTooracleCmd(oracleCmd, "i_img_tag", OracleType.VarChar, ParameterDirection.Input, newUser.Alert_ImgTag)
            AddParamTooracleCmd(oracleCmd, "i_img_url", OracleType.VarChar, ParameterDirection.Input, newUser.Alert_ImgUrl)
            AddParamTooracleCmd(oracleCmd, "i_link_to", OracleType.VarChar, ParameterDirection.Input, newUser.Alert_Link)
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_ALERTS")
        End If



        ExecuteScalarCmd(oracleCmd)
        Dim errorcode As Integer = CInt(oracleCmd.Parameters("o_errorcode").Value)
        If CInt(oracleCmd.Parameters("o_errorcode").Value) = 1 Then
            Return "Exist"
        ElseIf CInt(oracleCmd.Parameters("o_errorcode").Value) = 2 Then
            Return "Problem"
        Else
            Return "True"
        End If


    End Function

    Public Overrides Function Content_Admin(ByVal newContent As CMS) As Int32

        If newContent Is Nothing Then
            Throw (New ArgumentNullException("newContent"))
        Else
            Dim oracleCmd As OracleCommand = New OracleCommand()

            Select Case (newContent.Module_Type)

                Case DefaultValues.Admin
                    AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    AddParamTooracleCmd(oracleCmd, "i_UserName", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Name)
                    AddParamTooracleCmd(oracleCmd, "i_UserEmail", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Email)
                    AddParamTooracleCmd(oracleCmd, "i_Division", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Unit)
                    AddParamTooracleCmd(oracleCmd, "i_UserID", OracleType.Number, ParameterDirection.Input, Int16.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Number, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_ADMIN")

                Case DefaultValues.Press_News
                    AddParamTooracleCmd(oracleCmd, "i_Press_Type", OracleType.VarChar, ParameterDirection.Input, newContent.Press_Type)
                    AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    AddParamTooracleCmd(oracleCmd, "i_News_Id", OracleType.Number, ParameterDirection.Input, Int16.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "i_News_Title", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Name)
                    AddParamTooracleCmd(oracleCmd, "i_News_Date", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Email)
                    AddParamTooracleCmd(oracleCmd, "i_News_Article", OracleType.Clob, ParameterDirection.Input, newContent.Admin_Unit)
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_PRESS")

                Case DefaultValues.Concessions
                    AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    AddParamTooracleCmd(oracleCmd, "i_Company_Id", OracleType.Number, ParameterDirection.Input, Int32.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "i_Company_Name", OracleType.VarChar, ParameterDirection.Input, newContent.Company_Name)
                    AddParamTooracleCmd(oracleCmd, "i_Company_Desc", OracleType.VarChar, ParameterDirection.Input, newContent.Company_Description)
                    AddParamTooracleCmd(oracleCmd, "i_Company_Phone1", OracleType.VarChar, ParameterDirection.Input, newContent.Company_Phone1)
                    AddParamTooracleCmd(oracleCmd, "i_Company_Phone2", OracleType.VarChar, ParameterDirection.Input, newContent.Company_Phone2)
                    AddParamTooracleCmd(oracleCmd, "i_Store_Type_ID", OracleType.Number, ParameterDirection.Input, Int16.Parse(newContent.Store_Type_ID))
                    AddParamTooracleCmd(oracleCmd, "i_Company_Website", OracleType.VarChar, ParameterDirection.Input, newContent.Company_Website)
                    'AddParamTooracleCmd(oracleCmd, "i_Store_Logo_Location", OracleType.VarChar, ParameterDirection.Input, newContent.Store_Logo_Location)
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int32, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_Company")

                Case DefaultValues.Concessions_Stores
                    AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    AddParamTooracleCmd(oracleCmd, "i_store_id", OracleType.Number, ParameterDirection.Input, Int32.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "i_company_id", OracleType.Number, ParameterDirection.Input, Int32.Parse(newContent.Company_ID))
                    AddParamTooracleCmd(oracleCmd, "i_store_location_id", OracleType.Number, ParameterDirection.Input, Int32.Parse(newContent.Store_Location_ID))
                    AddParamTooracleCmd(oracleCmd, "i_store_Phone1", OracleType.VarChar, ParameterDirection.Input, newContent.Store_Phone1)
                    AddParamTooracleCmd(oracleCmd, "i_store_Phone2", OracleType.VarChar, ParameterDirection.Input, newContent.Store_Phone2)
                    AddParamTooracleCmd(oracleCmd, "i_seating_available", OracleType.VarChar, ParameterDirection.Input, newContent.Seating_Available)
                    AddParamTooracleCmd(oracleCmd, "i_hours_operation", OracleType.VarChar, ParameterDirection.Input, newContent.Hours_Operation)
                    AddParamTooracleCmd(oracleCmd, "i_closed_renovation", OracleType.VarChar, ParameterDirection.Input, newContent.Closed_Renovation)
                    AddParamTooracleCmd(oracleCmd, "i_Awarded", OracleType.VarChar, ParameterDirection.Input, newContent.Awarded)
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int32, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_Stores")

                Case DefaultValues.Company_Files
                    Dim strCmd As String = "INSERT INTO CMS_COMPANY_FILE(COMPANY_ID,THEFILE, FILE_NAME,FILE_TYPE,FILE_FORMAT,FILE_CREATEDUSER)" _
                    & " VALUES(:i_Company_Id,:i_FILE,:i_File_Name,:i_FILE_TYPE,:i_FILE_FORMAT,:i_CREATED_USER)"
                    AddParamTooracleCmd(oracleCmd, "i_Company_id", OracleType.Number, ParameterDirection.Input, Int32.Parse(newContent.Company_ID))
                    AddParamTooracleCmd(oracleCmd, "i_FILE", OracleClient.OracleType.Blob, ParameterDirection.Input, newContent.Company_File_Data)
                    AddParamTooracleCmd(oracleCmd, "i_File_Name", OracleType.VarChar, ParameterDirection.Input, newContent.Company_File_Name)
                    AddParamTooracleCmd(oracleCmd, "i_FILE_TYPE", OracleType.VarChar, ParameterDirection.Input, newContent.Company_File_Type)
                    AddParamTooracleCmd(oracleCmd, "i_FILE_FORMAT", OracleType.VarChar, ParameterDirection.Input, newContent.Company_File_Format)
                    AddParamTooracleCmd(oracleCmd, "i_CREATED_USER", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Name)
                    'AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    'AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int32, ParameterDirection.Output, 0)
                    SetCommandType(oracleCmd, CommandType.Text, strCmd)

                Case DefaultValues.HR
                    AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    AddParamTooracleCmd(oracleCmd, "i_JobID", OracleType.Number, ParameterDirection.Input, Int16.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "i_JobTitle", OracleType.VarChar, ParameterDirection.Input, newContent.Job_Ttle)
                    AddParamTooracleCmd(oracleCmd, "i_Salary_Range", OracleType.VarChar, ParameterDirection.Input, newContent.Salary_Range)
                    AddParamTooracleCmd(oracleCmd, "i_Salary_Grade", OracleType.VarChar, ParameterDirection.Input, newContent.salary_Grade)
                    AddParamTooracleCmd(oracleCmd, "i_App_From", OracleType.VarChar, ParameterDirection.Input, newContent.App_Date_From)
                    AddParamTooracleCmd(oracleCmd, "i_App_To", OracleType.VarChar, ParameterDirection.Input, newContent.App_Date_To)
                    AddParamTooracleCmd(oracleCmd, "i_Job_Description", OracleType.VarChar, ParameterDirection.Input, newContent.Job_Description)
                    AddParamTooracleCmd(oracleCmd, "i_Contactinfo", OracleType.VarChar, ParameterDirection.Input, newContent.Contact_Information)
                    AddParamTooracleCmd(oracleCmd, "i_Job_AlreadyPosted", OracleType.VarChar, ParameterDirection.Input, newContent.Job_Alreadyposted)
                    AddParamTooracleCmd(oracleCmd, "i_JobDes_URL", OracleType.VarChar, ParameterDirection.Input, newContent.JobDesc_URL)
                    AddParamTooracleCmd(oracleCmd, "i_Apply_Link", OracleType.VarChar, ParameterDirection.Input, newContent.JobApply_URL)
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_JOBS")

                Case DefaultValues.Parking
                    AddParamTooracleCmd(oracleCmd, "i_Lotid", OracleType.Number, ParameterDirection.Input, Int16.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "i_Lot_Name", OracleType.VarChar, ParameterDirection.Input, newContent.Prking_Lot_Name)
                    AddParamTooracleCmd(oracleCmd, "i_Lot_Status", OracleType.VarChar, ParameterDirection.Input, newContent.ParkingStatus)
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int16, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_PARKING_LOT")

                Case DefaultValues.AirportAlert
                    AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    AddParamTooracleCmd(oracleCmd, "i_AlertId", OracleType.Number, ParameterDirection.Input, Int16.Parse(newContent.Id))
                    AddParamTooracleCmd(oracleCmd, "i_enabled", OracleType.VarChar, ParameterDirection.Input, newContent.Alert_Enabled)
                    AddParamTooracleCmd(oracleCmd, "i_title", OracleType.VarChar, ParameterDirection.Input, newContent.Alert_Title)
                    AddParamTooracleCmd(oracleCmd, "i_desc", OracleType.VarChar, ParameterDirection.Input, newContent.Alert_Desc)
                    AddParamTooracleCmd(oracleCmd, "i_img_tag", OracleType.VarChar, ParameterDirection.Input, newContent.Alert_ImgTag)
                    AddParamTooracleCmd(oracleCmd, "i_img_url", OracleType.VarChar, ParameterDirection.Input, newContent.Alert_ImgUrl)
                    AddParamTooracleCmd(oracleCmd, "i_link_to", OracleType.VarChar, ParameterDirection.Input, newContent.Alert_Link)
                    AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int32, ParameterDirection.Output, Nothing)
                    SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_ALERTS")

                Case DefaultValues.Airside
                    Dim strCmd As String = "INSERT INTO CMS_Airside_EngineRuns(TITLE,THEFILE, FILE_NAME, FILE_FORMAT, FILE_CREATEDUSER)" _
                    & " VALUES(:i_Title,:i_FILE,:i_File_Name,:i_FILE_FORMAT,:i_CREATED_USER)"
                    AddParamTooracleCmd(oracleCmd, "i_Title", OracleType.VarChar, ParameterDirection.Input, newContent.Company_File_Type)
                    AddParamTooracleCmd(oracleCmd, "i_FILE", OracleClient.OracleType.Blob, ParameterDirection.Input, newContent.Company_File_Data)
                    AddParamTooracleCmd(oracleCmd, "i_File_Name", OracleType.VarChar, ParameterDirection.Input, newContent.Company_File_Name)
                    AddParamTooracleCmd(oracleCmd, "i_FILE_FORMAT", OracleType.VarChar, ParameterDirection.Input, newContent.Company_File_Format)
                    AddParamTooracleCmd(oracleCmd, "i_CREATED_USER", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Name)
                    'AddParamTooracleCmd(oracleCmd, "i_Task", OracleType.VarChar, ParameterDirection.Input, newContent.Admin_Action)
                    'AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int32, ParameterDirection.Output, 0)
                    SetCommandType(oracleCmd, CommandType.Text, strCmd)

            End Select

            ExecuteScalarCmd(oracleCmd)
            Dim errorcode As Int32
            Select Case (newContent.Module_Type)
                Case DefaultValues.Company_Files 'since we can not get output parameter from the text type command
                    errorcode = 0
                Case DefaultValues.Airside 'since we can not get output parameter from the text type command
                    errorcode = 0
                Case Else
                    errorcode = Int32.Parse((oracleCmd.Parameters("o_errorcode").Value))
            End Select

            Return errorcode
        End If
    End Function

    Public Overrides Function Content_Delete(ByVal newContent As CMS) As Int32

        If newContent Is Nothing Then
            Throw (New ArgumentNullException("newContent"))
        Else
            Dim oracleCmd As OracleCommand = New OracleCommand()

            AddParamTooracleCmd(oracleCmd, "i_id", OracleType.Number, ParameterDirection.Input, Int32.Parse(newContent.Id))
            AddParamTooracleCmd(oracleCmd, "i_Module_Type", OracleType.VarChar, ParameterDirection.Input, newContent.Module_Type)
            AddParamTooracleCmd(oracleCmd, "o_errorcode", OracleType.Int32, ParameterDirection.Output, Nothing)
            SetCommandType(oracleCmd, CommandType.StoredProcedure, "CMS_BUSINESS_UNITS_PKG.SP_CMS_DeleteContentByID")

            ExecuteScalarCmd(oracleCmd)

            Dim errorcode As Int32 = Int32.Parse(oracleCmd.Parameters("o_errorcode").Value)
            Return errorcode
        End If
    End Function


    Private Sub AddParamTooracleCmd(ByVal oracleCmd As OracleCommand, ByVal paramId As String, ByVal oracleType As OracleType, ByVal paramDirection As ParameterDirection, ByVal paramvalue As Object)
        ' Validate Parameter Properties
        If oracleCmd Is Nothing Then
            Throw (New ArgumentNullException("oracleCmd"))
        End If
        If paramId = String.Empty Then
            Throw (New ArgumentOutOfRangeException("paramId"))
        End If

        ' Add Parameter
        Dim neworacleParam As New OracleParameter()
        neworacleParam.ParameterName = paramId
        neworacleParam.OracleType = oracleType
        neworacleParam.Direction = paramDirection

        'If paramSize > 0 Then
        '    neworacleParam.Size = paramSize
        'End If

        If paramvalue IsNot Nothing Then
            neworacleParam.Value = paramvalue
        End If

        oracleCmd.Parameters.Add(neworacleParam)
    End Sub

    Private Function ExecuteScalarCmd(ByVal oracleCmd As OracleCommand) As Object
        ' Validate Command Properties
        Dim result As Object = Nothing
        Try
            If ConnectionString = String.Empty Then
                Throw (New ArgumentOutOfRangeException("ConnectionString"))
            End If

            If oracleCmd Is Nothing Then
                Throw (New ArgumentNullException("oracleCmd"))
            End If


            Using cn As New OracleConnection(Me.ConnectionString)
                oracleCmd.Connection = cn
                cn.Open()
                result = oracleCmd.ExecuteScalar()
                cn.Close()
            End Using

        Catch ex As System.Data.OracleClient.OracleException
            Throw ex
        End Try
        Return result
    End Function
    Private Function ExecuteReaderCmd(ByVal oracleCmd As OracleCommand, ByVal gcfr As GenerateCollectionFromReader) As CollectionBase
        If ConnectionString = String.Empty Then
            Throw (New ArgumentOutOfRangeException("ConnectionString"))
        End If

        If oracleCmd Is Nothing Then
            Throw (New ArgumentNullException("oracleCmd"))
        End If

        Using cn As New OracleConnection(Me.ConnectionString)
            oracleCmd.Connection = cn
            cn.Open()
            Dim temp As CollectionBase = gcfr(oracleCmd.ExecuteReader())
            Return (temp)
            cn.Close()
        End Using
    End Function
    Public Function ExecuteScalarCmdWithOutValue(ByVal oracleCmd As OracleCommand) As Int16


        ' Validate Command Properties
        If ConnectionString = String.Empty Then
            Throw (New ArgumentOutOfRangeException("ConnectionString"))
        End If

        If oracleCmd Is Nothing Then
            Throw (New ArgumentNullException("oracleCmd"))
        End If

        Dim result As Int16 = Nothing
        Using cn As New OracleConnection(Me.ConnectionString)
            oracleCmd.Connection = cn
            cn.Open()
            oracleCmd.ExecuteNonQuery()
            result = oracleCmd.Parameters.Item("o_Store_Id").Value
            cn.Close()
        End Using
        Return result


    End Function

    Public Function GetDataTable(ByVal oracleCmd As OracleCommand) As DataTable

        Dim datatable As New DataTable

        ' Validate Command Properties
        If ConnectionString = String.Empty Then
            Throw (New ArgumentOutOfRangeException("ConnectionString"))
        End If

        If oracleCmd Is Nothing Then
            Throw (New ArgumentNullException("oracleCmd contains nothing"))
        End If

        Try
            Using cn As New OracleConnection(Me.ConnectionString)
                oracleCmd.Connection = cn
                cn.Open()
                Dim datareader As OracleDataReader = oracleCmd.ExecuteReader
                datatable.Load(datareader, LoadOption.OverwriteChanges)
                cn.Close()
            End Using

            'Dim orlDataAdapter As New OracleDataAdapter
            'orlDataAdapter.SelectCommand = oracleCmd
            'orlDataAdapter.Fill(datatable)
            'Return datatable
            'Catch ex As System.Data.OracleClient.OracleException
            'TO-DO
            'Throw ex
        Catch ex As Exception
            'Throw ex
        Finally
            'If oracleCmd.Connection.State = ConnectionState.Open Then
            '    oracleCmd.Connection.Close()
            '    'Added by Suneela 
            '    oracleCmd.Connection.Dispose()
            'End If
            ''Added by Suneela 
            oracleCmd.Dispose()
        End Try

        Return datatable

    End Function

    Public Sub SetCommandType(ByVal oracleCmd As OracleCommand, ByVal cmdType As CommandType, ByVal cmdText As String)
        oracleCmd.CommandType = cmdType
        oracleCmd.CommandText = cmdText
    End Sub

End Class
