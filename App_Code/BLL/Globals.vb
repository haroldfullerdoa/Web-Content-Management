Imports Microsoft.VisualBasic

Public Class Globals
    Public Shared columnSeperator As String = "y7~^}>!k"
    Public Shared rowSeperator As String = "k!>}^~7y"
    Public Shared strHomeUrl As String = "~/Default.aspx"
    Public Shared ReadOnly Property DataAccessType() As String
        Get
            Dim str As String = ConfigurationManager.AppSettings("DataAccessType")
            If str Is Nothing OrElse str = [String].Empty Then
                Throw (New ApplicationException("DataAccessType configuration is missing from you web.config. It should contain <appSettings><add key=""DataAccessType"" value=""data access type"" /></appSettings> "))
            Else
                Return (str)
            End If
        End Get
    End Property
    Public Shared ReadOnly Property SmtpServer() As String
        Get
            Dim str As String = ConfigurationManager.AppSettings("SmtpServer")
            If str Is Nothing OrElse str = [String].Empty Then
                Throw (New ApplicationException("SmtpServer configuration is missing from you web.config. It should contain <appSettings><add key=""SmtpServer"" value=""localhost"" /></appSettings> "))
            Else
                Return (str)
            End If
        End Get
    End Property
End Class
