Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient


Namespace CRM

Partial Class CRMADR
    Inherits System.Web.UI.Page
    Dim dts1 As New DataSet
    Dim oda1 As OdbcDataAdapter
    Dim sda1 As SqlDataAdapter
    Dim OCN1 As New OdbcConnection(Constants.OCN_MEDSD)
    Dim odr1 As OdbcDataReader
    Dim SCN24 As New SqlConnection(Constants.SCN_SQL24)
    Dim xnew_flg As String = "N"
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Sub execute_query1()
        Dim SQL As String
        Dim sql2 As String
        xmsg.Text = ""
        If XADR.Text <> "" Then
            SQL = "select *,datediff(year,PAPER_Dob,getdate()) AGE from PA_PATDTL WHERE PAPER_STNAMELINE1 LIKE '%" & XADR.Text & "%'"
        Else
            xmsg.Text = "Please enter part of Address to search"
            Exit Sub
        End If
        sda1 = New SqlDataAdapter(SQL, SCN24)
        dts1.Clear()
        sda1.Fill(dts1, "PA_PATDTL")
        If dts1.Tables(0).Columns("xpt_nme") Is Nothing Then
            Dim xpt_nme As DataColumn = New DataColumn("xpt_nme")
            xpt_nme.DataType = System.Type.GetType("System.String")
            dts1.Tables(0).Columns.Add(xpt_nme)
        End If
        DataGrid1.DataSource = dts1
        DataGrid1.DataBind()
        Session("PA_PATDTL") = dts1
        SCN24.Close()
        'dts1 = Nothing
        If dts1.Tables(0).Rows.Count = 0 Then
            xmsg.Text = "Not found any matcing Data"
        End If
    End Sub
    'Private Sub xrn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If xrn.Text.Length >= 6 Then
    '        If xrn.Text.Substring(2, 1) <> "-" Then
    '            xrn.Text = xrn.Text.Substring(0, 2) & "-" & xrn.Text.Substring(2)
    '        End If
    '        If xrn.Text.Substring(5, 1) <> "-" Then
    '            xrn.Text = xrn.Text.Substring(0, 5) & "-" & xrn.Text.Substring(5)
    '        End If
    '    End If
    'End Sub

    Sub DTL(ByVal o As Object, ByVal e As DataGridCommandEventArgs)
        'Dim XIDX As Double
        Dim XRN As String
        Dim XNME As String
        Dim xtmp As DataGridItem
        xtmp = DataGrid1.Items.Item(e.Item.ItemIndex)
        xtmp.BackColor = Color.LightCyan

        ''XIDX = DataGrid1.DataKeys(e.Item.ItemIndex)
        'dts1 = Session("PA_PATDTL")
        'XRN = dts1.Tables(0).Rows(e.Item.ItemIndex)(0)
        ''XNME = dts1.Tables(0).Rows(e.Item.ItemIndex)(1)
        'Session("RN") = XRN
        'Response.Redirect("CRM1.aspx?RN=" & XRN)
    End Sub
    Sub DEL(ByVal o As Object, ByVal e As DataGridCommandEventArgs)
        Dim XIDX As Double
        Dim XTMP2 As String
        Dim DCMD As SqlCommand
        dts1 = Session("PA_PATDTL")
        'XIDX = DataGrid1.DataKeys(e.Item.ItemIndex)
        dts1.Tables(0).Rows.RemoveAt(e.Item.ItemIndex)
        DataGrid1.DataSource = dts1
        DataGrid1.DataBind()
    End Sub

    Private Sub BFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFind.Click
        execute_query1()
    End Sub

    Private Sub BName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BName.Click
        Dim sql As String
        dts1 = CType(Session("PA_PATDTL"), DataSet)
        Dim xcnt As Int16 = 0
        Dim xtot As Integer = dts1.Tables(0).Rows.Count
        If SCN24.State <> ConnectionState.Open Then
            SCN24.Open()
        End If
        While (xcnt + 1) <= xtot
            Dim xsql2 As String
            Dim xrn As String
            Dim xnme As String
            xrn = dts1.Tables(0).Rows(xcnt)("RN")
            xsql2 = " SELECT TTL + ' '+ FST_NME + ' ' + LST_NME FROM PA_PATMAS WHERE RN = '" & xrn & "'"
            Dim SCM11 As New SqlCommand(xsql2, SCN24)
            Try
                xnme = SCM11.ExecuteScalar()
                Try
                    dts1.Tables(0).Rows(xcnt)("xpt_nme") = xnme
                Catch ex2 As Exception
                End Try
            Catch ex As Exception
            End Try

            xcnt += 1
        End While
        DataGrid1.Columns(2).Visible = True
        Session("PA_PATDTL") = dts1
        DataGrid1.DataSource = dts1
        DataGrid1.DataBind()
    End Sub
End Class

End Namespace
