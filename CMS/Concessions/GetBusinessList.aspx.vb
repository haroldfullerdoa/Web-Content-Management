Imports HJAIA2008.BusinessLogicLayer
Imports System.Data.SqlClient
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel.XlMSApplication



Partial Class GetBusinessList
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verify authentication
        If Not Page.IsPostBack Then
            Dim authCookie1 As HttpCookie = Session("Concession")
            If (Not authCookie1 Is Nothing) Then
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = True 'display Log Out link
                Dim authTicket1 As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie1.Value)
                If authTicket1.Expired = True Then
                    Response.Redirect("default.aspx")
                End If
            Else
                CType(Me.Master, CMS_MasterScreens_SiteMaster).VisiblLogOut = False
                Response.Redirect("default.aspx")
            End If

            Dim newListItem As ListItem

            newListItem = New ListItem("--Select All--", "0")

            newListItem.Selected = True
            ddlCategory.Items.Add(newListItem)

            Dim strConnection As String
            Dim dr As SqlDataReader

            strConnection = ConfigurationManager.ConnectionStrings("ConcessionsConnectionString").ToString()

            Dim sqlStr As String

            sqlStr = "SELECT BusinessTypeID, category FROM BusinessType "

            Using cn As New SqlConnection(strConnection)

                Dim cmd As New SqlCommand()
                cmd = cn.CreateCommand()
                cmd.CommandText = sqlStr
                cn.Open()
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    Do While dr.Read()
                        newListItem = New ListItem(dr("category").ToString(), dr("BusinessTypeID").ToString())
                        ddlCategory.Items.Add(newListItem)
                    Loop
                End If

                dr.Close()
                cn.Close()

            End Using

            GridView1.DataSource = Nothing
            GridView1.DataSourceID = Nothing
            GridView1.DataBind()

            GridView1.Visible = False
        End If
        img1.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtStartDate.ClientID + ");")
        img2.Attributes.Add("onclick", "javascript:return showCalendarControl(" + txtEndDate.ClientID + ");")
    End Sub


    Protected Sub btnEmailOnly_Click(sender As Object, e As System.EventArgs) Handles btnEmailOnly.Click
        If btnEmailOnly.Text = "Email Only" Then
            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Visible = False
            GridView1.Columns(2).Visible = False
            GridView1.Columns(4).Visible = False
            btnEmailOnly.Text = "Display All"
            GridView1.ShowHeader = False
        Else
            GridView1.Columns(0).Visible = True
            GridView1.Columns(1).Visible = True
            GridView1.Columns(2).Visible = True
            GridView1.Columns(4).Visible = True
            btnEmailOnly.Text = "Email Only"
            GridView1.ShowHeader = True
        End If
    End Sub

    Protected Sub btnExportData_Click(sender As Object, e As System.EventArgs) Handles btnExportData.Click
        'Export DataGridView to Excel
        'Dim xlapp As Application
        'Dim xlworkbook As Workbook
        'Dim xlworksheet As Worksheet
        'Dim misvalue As Object = System.Reflection.Missing.Value
        'Dim i As Integer
        'Dim j As Integer
        'xlapp = New Application
        'xlworkbook = xlapp.Workbooks.Add(misvalue)
        'xlworksheet = xlworkbook.Sheets("Sheet1")

        'For i = 0 To GridView1.Columns.Count - 1
        '    xlworksheet.Cells(1, i + 1).Value = GridView1.Columns(i).HeaderText
        '    xlworksheet.Cells(1, i + 1).font.bold = True
        'Next


        'For i = 0 To GridView1.Rows.Count - 1
        '    For j = 0 To GridView1.Columns.Count - 2
        '        If j = GridView1.Columns.Count - 2 Then
        '            xlworksheet.Cells(i + 2, j + 1) = Replace(GridView1.Rows(i).Cells(j).Text.Trim(), "&amp;", "&") & ";"
        '        Else
        '            xlworksheet.Cells(i + 2, j + 1) = Replace(GridView1.Rows(i).Cells(j).Text.Trim(), "&amp;", "&")
        '        End If
        '    Next
        'Next

        'Try
        '    'xlworksheet.SaveAs("E:WebDocs\ATLWeb_Admin\CMS\Concessions\Concession.xlsx")
        '    xlworksheet.SaveAs("Concession.xlsx")
        'Catch exerr As Exception
        'End Try

        'xlworkbook.Close()
        'xlapp.Quit()

        If GridView1.Rows.Count > 0 Then
            Dim dataTable As New DataTable

            For i = 0 To GridView1.Columns.Count - 2
                dataTable.Columns.Add(GridView1.Columns(i).HeaderText, GetType(String))
            Next

            For Each gvr As GridViewRow In GridView1.Rows
                Dim row As DataRow = dataTable.NewRow()
                For i = 0 To GridView1.Columns.Count - 2
                    If i = GridView1.Columns.Count - 2 Then
                        row.Item(GridView1.Columns(i).HeaderText) = Replace(gvr.Cells(i).Text.Trim(), "&amp;", "&") & ";"
                    Else
                        row.Item(GridView1.Columns(i).HeaderText) = Replace(gvr.Cells(i).Text.Trim(), "&amp;", "&")
                    End If
                Next
                dataTable.Rows.Add(row)
            Next

            ExporttoExcel(dataTable)
            dataTable.Clear()
        End If
    End Sub

    Sub ExporttoExcel(ByVal Dtt_Catted1 As DataTable)
        Dim stwWriter As System.IO.StringWriter = New System.IO.StringWriter
        Dim htwWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stwWriter)
        Dim dgGrid As DataGrid = New DataGrid
        dgGrid.DataSource = Dtt_Catted1
        dgGrid.HeaderStyle.Font.Bold = True
        dgGrid.Caption = "Concession Data"
        dgGrid.DataBind()
        dgGrid.RenderControl(htwWriter)

        Response.Clear()
        ' Clear the content of the response
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Response.Buffer = True

        Response.AddHeader("Content-Concession", "attachment; filename=Concession_Data" & "_" & Now() & ".xlsx")
        Response.ContentType = "application/vnd.ms-excel"
        'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Me.EnableViewState = False

        Response.Write(stwWriter.ToString)
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        GridView1.Visible = True
        GridView1.DataSourceID = SqlDataSource1.ID.ToString()
    End Sub
End Class
