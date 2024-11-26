Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Collections.Specialized
Imports HJAIA2008.BusinessLogicLayer

Public Class ContentCollection
    Inherits CollectionBase

    Public Sub New()
    End Sub

    Public Enum UserFields
        InitValue
        Username
        DisplayName
        RoleId
        RoleName
    End Enum


    Public Sub Sort(ByVal sortField As UserFields, ByVal isAscending As Boolean)
        Select Case sortField
            Case UserFields.Username
                InnerList.Sort()
                Exit Select
        End Select
        If Not isAscending Then
            InnerList.Reverse()
        End If
    End Sub


    Default Public Property Item(ByVal index As Integer) As CMS
        Get
            Return DirectCast(List(index), CMS)
        End Get
        Set(ByVal value As CMS)
            List(index) = value
        End Set
    End Property

    Public Function Add(ByVal value As CMS) As Integer
        Return (List.Add(value))
    End Function

    Public Function IndexOf(ByVal value As CMS) As Integer
        Return (List.IndexOf(value))
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As CMS)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As CMS)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal value As CMS) As Boolean
        ' If value is not of type CMS, this will return false.
        Return (List.Contains(value))
    End Function

    Protected Overloads Overrides Sub OnInsert(ByVal index As Integer, ByVal value As Object)
        If Not value.[GetType]() Is Type.[GetType]("HJAIA2008.BusinessLogicLayer.CMS") Then
            Throw New ArgumentException("value must be of type CMS.", "value")
        End If
    End Sub

    Protected Overloads Overrides Sub OnRemove(ByVal index As Integer, ByVal value As Object)
        If Not value.[GetType]() Is Type.[GetType]("HJAIA2008.BusinessLogicLayer.CMS") Then
            Throw New ArgumentException("value must be of type CMS.", "value")
        End If
    End Sub

    Protected Overloads Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
        If Not newValue.[GetType]() Is Type.[GetType]("HJAIA2008.BusinessLogicLayer.CMS") Then
            Throw New ArgumentException("newValue must be of type CMS.", "newValue")
        End If
    End Sub

    Protected Overloads Overrides Sub OnValidate(ByVal value As Object)
        If Not value.[GetType]() Is Type.[GetType]("HJAIA2008.BusinessLogicLayer.CMS") Then
            Throw New ArgumentException("value must be of type CMS.")
        End If
    End Sub
End Class
