Imports HJAIA2008.BusinessLogicLayer
Imports System.Data



Partial Class Airport_SafetyManagement_admin_Excel
    Inherits System.Web.UI.Page

    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Dim stwWriter As New System.IO.StringWriter
    '    Dim htwWriter As New System.Web.UI.HtmlTextWriter(stwWriter)
    '    Dim gdvSMS As DataGrid = New DataGrid
    '    gdvSMS.DataBind()
    '    gdvSMS.RenderControl(htwWriter)

    '    Response.Clear()
    '    Response.ClearContent()
    '    Response.ClearHeaders()
    '    Response.Charset = ""
    '    Response.Buffer = True

    '    Response.AddHeader("Content-Disposition", "attachment; filename=SMS_Data" & "_" & Now() & ".xls")
    '    Response.ContentType = "application/vnd.ms-excel"
    '    Me.EnableViewState = False

    '    Response.Write(stwWriter.ToString)
    '    Response.Flush()
    '    Response.End()
    'End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim Training_ID As Int16 = 0
        'If Not Page.IsPostBack Then
        '    If Not Request.QueryString("tid") Is Nothing Then
        '        If Not String.IsNullOrEmpty(Request.QueryString("tid")) Then
        '            If IsNumeric(Request.QueryString("tid")) Then
        '                Training_ID = Request.QueryString("tid")
        '            End If
        '        End If
        '    End If
        Dim tid As String
        Dim sDate As String
        Dim eDate As String

        sDate = Request.QueryString("sDate")
        eDate = Request.QueryString("eDate")

        '  If Training_ID > 0 Then
        Dim myCmd As New System.Data.OracleClient.OracleCommand
      
        Dim txtSQL As String
        txtSQL = "SELECT DISTINCT * FROM SMS_DATA WHERE EVENT_DATE > To_Date ('" & sDate & "', 'mm/dd/yyyy') AND EVENT_DATE < TO_DATE('" & eDate & "', 'mm/dd/yyyy') ORDER BY REPORT_DATE, EVENT_DATE"
        'txtSQL = "SELECT DISTINCT * FROM ATLWEB_OWNER.SMS_DATA "

        Dim DAL As New OracleDataAccessLayer

        DAL.SetCommandType(myCmd, CommandType.Text, txtSQL)

        Dim dtUsers As New DataTable
        dtUsers = DAL.GetDataTable(myCmd)
        If dtUsers.Rows.Count > 0 Then
            ExporttoExcel(dtUsers)
        Else
            Response.Write("No data found!")
        End If
        'Else
        'Response.Write("Not valid course ID, try again.")
        ' End If

        'End If
    End Sub

    Sub ExporttoExcel(ByVal Dtt_Catted1 As DataTable)
        Dim stwWriter As System.IO.StringWriter = New System.IO.StringWriter
        Dim htwWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stwWriter)
        Dim dgGrid As DataGrid = New DataGrid
        dgGrid.DataSource = Dtt_Catted1
        dgGrid.HeaderStyle.Font.Bold = True
        dgGrid.Caption = "SMS Data"
        dgGrid.DataBind()
        dgGrid.RenderControl(htwWriter)

        Response.Clear()
        ' Clear the content of the response
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Response.Buffer = True

        Response.AddHeader("Content-Disposition", "attachment; filename=SMS_Data" & "_" & Now() & ".xls")
        Response.ContentType = "application/vnd.ms-excel"
        'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Me.EnableViewState = False

        Response.Write(stwWriter.ToString)
        Response.Flush()
        Response.End()

    End Sub

End Class

