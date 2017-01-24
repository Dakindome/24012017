Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient


Namespace CRM

Partial Class XSLE
    Inherits System.Web.UI.Page
    Dim dts1 As New DataSet
    Dim oda1 As OdbcDataAdapter
    Dim sda1 As SqlDataAdapter
    Dim OCN1 As New OdbcConnection(Constants.OCN_MEDSD)
    Dim odr1 As OdbcDataReader
    Dim SCN1 As New SqlConnection(Constants.SCN_SQL)
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
        If Not IsPostBack Then
            FDTE.Text = Format(Today, "dd/MM/yyyy")
            TDTE.Text = FDTE.Text
            If Request.Item("RN") <> "" Then
                Session("RN") = Request.Item("RN")
            End If
            xrn.Text = Session("RN")
        Else
            If xrn.Text.Length >= 6 Then
                If xrn.Text.Substring(2, 1) <> "-" Then
                    xrn.Text = xrn.Text.Substring(0, 2) & "-" & xrn.Text.Substring(2)
                End If
                If xrn.Text.Substring(5, 1) <> "-" Then
                    xrn.Text = xrn.Text.Substring(0, 5) & "-" & xrn.Text.Substring(5)
                End If
            End If
        End If
        execute_query1()
    End Sub

    Sub execute_query1()
        If TDTE.Text = "" Then
            TDTE.Text = FDTE.Text
        End If
        Dim SQL As String
        Dim sql2 As String
        xmsg.Text = ""
        sql2 = ""
        SQL = "SELECT * "
        SQL &= "FROM CRMXSLE  "
        If FDTE.Text <> "" AndAlso TDTE.Text <> "" Then
            sql2 = " where dte BETWEEN '" & FDTE.Text & "' AND '" & TDTE.Text & "' "
        End If
        If xrn.Text <> "" Then
            If sql2 = "" Then
                sql2 = " where "
            Else
                sql2 &= " and "
            End If
            sql2 &= " rn LIKE '" & xrn.Text & "%' "
        End If
        If DDLSTS.SelectedItem.Text <> "" AndAlso DDLSTS.SelectedValue <> "%" Then
            If sql2 = "" Then
                sql2 = " where "
            Else
                sql2 &= " and "
            End If
            sql2 &= " STS = '" & DDLSTS.SelectedValue & "' "
        End If
        If XFRM_LOC.Text <> "" Then
            If sql2 = "" Then
                sql2 = " where "
            Else
                sql2 &= " and "
            End If
            sql2 &= " FRM_LOC LIKE '" & XFRM_LOC.Text & "%' "
        End If
        If XTO_LOC.Text <> "" Then
            If sql2 = "" Then
                sql2 = " where "
            Else
                sql2 &= " and "
            End If
            sql2 &= " TO_LOC LIKE '" & XTO_LOC.Text & "%' "
        End If
        If XX_BY.Text <> "" Then
            If sql2 = "" Then
                sql2 = " where "
            Else
                sql2 &= " and "
            End If
            sql2 &= " X_BY = '" & XX_BY.Text & "' "
        End If
        If sql2 = "" Then
            sql2 = " where "
            sql2 &= " STS <> 'D' "
        Else
            sql2 &= " and "
            sql2 &= " STS <> 'D' "
        End If
        SQL &= sql2 & " ORDER BY rowid DESC"
        sda1 = New SqlDataAdapter(SQL, SCN1)
        dts1.Clear()
        sda1.Fill(dts1, "XSLE")
        DataGrid1.DataSource = dts1
        DataGrid1.DataBind()
        Session("XSLE") = dts1
        SCN1.Close()
        'dts1 = Nothing
        If dts1.Tables(0).Rows.Count = 0 Then
            xmsg.Text = "Not found please Enter Rn and  click New to enter Data"
        End If
    End Sub
    Private Sub xrn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xrn.TextChanged
        If xrn.Text.Length >= 6 Then
            If xrn.Text.Substring(2, 1) <> "-" Then
                xrn.Text = xrn.Text.Substring(0, 2) & "-" & xrn.Text.Substring(2)
            End If
            If xrn.Text.Substring(5, 1) <> "-" Then
                xrn.Text = xrn.Text.Substring(0, 5) & "-" & xrn.Text.Substring(5)
            End If
        End If
    End Sub

    Sub DTL(ByVal o As Object, ByVal e As DataGridCommandEventArgs)
        Dim XIDX As Double
        Dim XRN As String
        Dim XNME As String
        XIDX = DataGrid1.DataKeys(e.Item.ItemIndex)
        dts1 = Session("XSLE")
        XRN = dts1.Tables(0).Rows(e.Item.ItemIndex)(0)
        XNME = dts1.Tables(0).Rows(e.Item.ItemIndex)(1)
        Session("ROWID") = XIDX
        Session("STS") = "UPD"
        Session("RN") = XRN
        Response.Redirect("XSLE2.aspx?Rowid=" & XIDX)
    End Sub
    Sub DEL(ByVal o As Object, ByVal e As DataGridCommandEventArgs)
        Dim XIDX As Double
        Dim XTMP2 As String
        Dim DCMD As SqlCommand
        XIDX = DataGrid1.DataKeys(e.Item.ItemIndex)
        Dim DSQL As String = "UPDATE CRMXSLE SET STS = 'D' WHERE ROWID = " & XIDX
        DCMD = New SqlCommand(DSQL, SCN1)
        If SCN1.State <> ConnectionState.Open Then
            SCN1.Open()
        End If
        DCMD.ExecuteNonQuery()
        execute_query1()
    End Sub

    Private Sub BNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNew.Click
        If xrn.Text <> "" Then
            Session("ROWID") = ""
            Session("RN") = xrn.Text
            Session("STS") = "NEW"
            Response.Redirect("XSLE2.aspx")
        Else
            xmsg.Text = "HN must be Enter"
        End If
    End Sub

    Private Sub BFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xrn.TextChanged, BFind.Click
        execute_query1()
    End Sub

    Private Sub DDLSTS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDLSTS.SelectedIndexChanged
        execute_query1()
    End Sub
End Class

End Namespace
