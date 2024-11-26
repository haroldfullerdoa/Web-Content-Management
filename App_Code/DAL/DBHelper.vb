Imports Microsoft.VisualBasic

Public Class DBHelper
    Public Sub New()
    End Sub
    Public Shared Function GetDataAccessLayer() As DataAccessLayer

        'Following line has been commented out and new code added replacing 'Type.GetType' with 'BuildManager.GetType'
        'Type trp = Type.GetType(Globals.DataAccessType, true);
        Dim trp As Type = System.Web.Compilation.BuildManager.[GetType](Globals.DataAccessType, True)

        If Not trp.BaseType Is Type.[GetType]("DataAccessLayer") Then
            Throw New Exception("Data Access Layer does not inherit DataAccessLayer!")
        End If
        Dim dc As DataAccessLayer = DirectCast(Activator.CreateInstance(trp), DataAccessLayer)
        Return (dc)
    End Function
End Class
