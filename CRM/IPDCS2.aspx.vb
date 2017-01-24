Imports System.Data.SqlClient
Public Class IPDCS2

    Inherits System.Web.UI.Page
    Dim dtv As New DataView
    Dim scn_sql As String = Constants.SCN_SQL3

    Dim scn1 As New SqlConnection(scn_sql)

    Protected WithEvents xrn As System.Web.UI.WebControls.TextBox
    Protected WithEvents xNew As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Xold As System.Web.UI.WebControls.CheckBox
    Protected WithEvents RSVH As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RSNH As System.Web.UI.WebControls.RadioButton
    Protected WithEvents xtot_epi As System.Web.UI.WebControls.Label
    Protected WithEvents Bget_nme As System.Web.UI.WebControls.Button
    Dim zdte As Date
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents xdte As System.Web.UI.WebControls.TextBox
    Protected WithEvents GWTE As System.Web.UI.WebControls.DataGrid
    Protected WithEvents BFind As System.Web.UI.WebControls.Button
    Protected WithEvents xloc As System.Web.UI.WebControls.TextBox
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not IsPostBack Then
            Session("dte") = Request("Dte")
            If Session("dte") = "" Then
                Session("dte") = Format(DateAdd(DateInterval.Day, -1, Today), "dd/MM/yyyy")
            End If
            If Session("Hos_ID") = "" Then
                Session("Hos_ID") = "SVH"
            End If
            If Session("Hos_ID") = "SVH" Then
                RSVH.Checked = True
            Else
                RSNH.Checked = True
            End If
            xdte.Text = Session("dte")
            execute_query()
        Else
            dtv.Table = CType(Session("data"), DataSet).Tables(0)
        End If

    End Sub

    Sub execute_query()
        Dim sql As String
        Dim dts21 As New DataSet
        sql = "select paadm_admdate,paadm_admno,papmi_no,paadm_type, " & _
"ctloc_code,ctpcp_code,oi_dr,bu_id,Age, Net_amt, LOS,DISCHARGEDATE from ipdvisit" & _
" WHERE (DISCHARGEdate = @DISCHARGEDATE) ORDER BY ctloc_code, papmi_no"
        'SDA1 = New System.Data.SqlClient.SqlDataAdapter
        SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand(sql, scn1)
        SqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DISCHARGEDATE", System.Data.SqlDbType.DateTime, 8, "DISCHARGEDATE"))
        Dim SDA1 As New System.Data.SqlClient.SqlDataAdapter(SqlSelectCommand1)
        If scn1.State <> ConnectionState.Open Then
            scn1.Open()
        End If
        SDA1.SelectCommand.Parameters("@DISCHARGEDATE").Value = "#" & xdte.Text & "#"
        dts21.Clear()
        SDA1.Fill(dts21)
        Dim xpt_nme As DataColumn = New DataColumn("xpt_nme")
        xpt_nme.DataType = System.Type.GetType("System.String")
        dts21.Tables(0).Columns.Add(xpt_nme)

        Dim xdr_nme As DataColumn = New DataColumn("xdr_nme")
        xdr_nme.DataType = System.Type.GetType("System.String")
        dts21.Tables(0).Columns.Add(xdr_nme)

        Dim xcnt As DataColumn = New DataColumn("xcnt")
        xcnt.DataType = System.Type.GetType("System.Int32")
        dts21.Tables(0).Columns.Add(xcnt)

        Session("data") = dts21
        bindgrid()
    End Sub
    Sub bindgrid()
        Dim xfil As String = ""
        dtv.Table = CType(Session("data"), DataSet).Tables(0)
        If xloc.Text <> "" Then
            If xfil <> "" Then
                xfil &= " and "
            End If
            xfil &= " ctloc_code like '" & xloc.Text & "%'"
        End If
        If RSVH.Checked = True Then
            If xfil <> "" Then
                xfil &= " and "
            End If
            xfil &= " bu_id = '011'"
        Else
            If xfil <> "" Then
                xfil &= " and "
            End If
            xfil &= " bu_id = '012'"
        End If
        If xNew.Checked = True Then
            If xfil <> "" Then
                xfil &= " and "
            End If
            xfil &= " oi_dr = '1' "
        End If
        If Xold.Checked = True Then
            If xfil <> "" Then
                xfil &= " and "
            End If
            xfil &= " oi_dr = '0' "
        End If
        If xrn.Text <> "" Then
            If xfil <> "" Then
                xfil &= " and "
            End If
            xfil &= " papmi_no = '" & xrn.Text & "' "
        End If

        If xfil <> "" Then
            dtv.RowFilter = xfil
        End If
        xtot_epi.Text = dtv.Count().ToString

        GWTE.DataSource = dtv
        GWTE.DataBind()

    End Sub

    Private Sub BFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFind.Click
        bindgrid()
    End Sub


    Private Sub xdte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xdte.TextChanged
        execute_query()
    End Sub

    Private Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Session.Remove("data")
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
        bindgrid()
    End Sub

    Private Sub CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RSVH.CheckedChanged, RSNH.CheckedChanged, Xold.CheckedChanged, xNew.CheckedChanged
        bindgrid()
    End Sub

    Private Sub Bget_nme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bget_nme.Click
        Dim sql As String
        Dim dts21 As New DataSet
        dts21 = CType(Session("data"), DataSet)
        Dim xcnt As Int16 = 0
        Dim xtot As Integer = dtv.Count()
        If scn1.State <> ConnectionState.Open Then
            scn1.Open()
        End If
        While (xcnt + 1) <= xtot
            Dim xsql2 As String
            Dim xrn As String
            Dim xnme As String
            xrn = dts21.Tables(0).Rows(xcnt)("papmi_no")
            xsql2 = " SELECT TTL + ' '+ FST_NME + ' ' + LST_NME FROM PA_PATMAS WHERE RN = '" & xrn & "'"
            Dim SCM11 As New SqlCommand(xsql2, scn1)
            Try
                xnme = SCM11.ExecuteScalar()
                Try
                    dts21.Tables(0).Rows(xcnt)("xpt_nme") = xnme
                Catch ex2 As Exception
                End Try
            Catch ex As Exception
            End Try
            xrn = dts21.Tables(0).Rows(xcnt)("CTPCP_CODE")
            xsql2 = " SELECT CAREPROVIDERNAME  FROM CT_CAREPROV WHERE CAREPROVIDERCODE = '" & xrn & "'"
            Dim SCM12 As New SqlCommand(xsql2, scn1)
            Try
                xnme = SCM12.ExecuteScalar()
                Try
                    dts21.Tables(0).Rows(xcnt)("xdr_nme") = xnme
                Catch ex2 As Exception
                End Try
            Catch ex As Exception
            End Try


            '    If Not IsDBNull(dts21.Tables(0).Rows(xcnt)("WTE_TOT")) Then
            '        XWTE = dts21.Tables(0).Rows(xcnt)("WTE_TOT")
            '        dts21.Tables(0).Rows(xcnt)("XWTE_TOT") = XWTE.Truncate(XWTE / 60) + (XWTE.Remainder(XWTE, 60) * 0.01)
            '    End If
            'if :oi_dr = '1' then
            '	display_item('oi_dr','yellow_on_red');
            'end if;
            'if :papmi_no is not null then
            'DECLARE 
            '	XTTL VARCHAR2(80);
            '	XFST_NME VARCHAR2(80);
            '	XLST_NME VARCHAR2(80);
            '                BEGIN()
            '	SELECT TTL,FST_NME,LST_NME INTO XTTL,XFST_NME,XLST_NME
            '	 FROM PA_PATMAS WHERE RN = :PAPMI_NO;
            '	:XNME := XTTL ||' '||XFST_NME||' '||XLST_NME ;
            'EXCEPTION
            '	WHEN OTHERS THEN NULL;
            'END;
            'BEGIN
            '	SELECT CAREPROVIDERNAME INTO :Xdr
            '	 FROM CT_CAREPROV WHERE CAREPROVIDERCODE = :CTPCP_CODE;
            'EXCEPTION
            '	WHEN OTHERS THEN NULL;
            'END;
            'end if;
            xcnt += 1
        End While
        Session("data") = dts21
        bindgrid()
    End Sub


End Class
