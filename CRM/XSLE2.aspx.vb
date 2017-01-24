Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient


Namespace CRM

Partial Class XSLE2
    Inherits System.Web.UI.Page
    Dim dts1 As New DataSet
    Dim oda1 As OdbcDataAdapter
    Dim sda1 As SqlDataAdapter
    Dim OCN1 As New OdbcConnection(Constants.OCN_MEDSD)
    Dim odr1 As OdbcDataReader
    Dim SCN1 As New SqlConnection(Constants.SCN_SQL)
    Dim SCN_SQL21 As New SqlConnection(Constants.SCN_SQL21)
    Dim DVLOC As DataView

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
            Session("LOG_NO") = "XSLE.aspx"
            Session("LOG_YES") = "XSLE2.aspx"
            If CType(Session("USR_ID"), String) = "" Then
                Response.Redirect("login.aspx")
            End If
            If CType(Session("USR_ID"), String) = "" Then
                Response.Redirect("XSLE.aspx")
            End If
            XUSR_NME.Text = CType(Session("USR_NME"), String)
            If XX_BY.Text = "" Then
                XX_BY.Text = CType(Session("USR_ID"), String)
            End If
            Cache.Remove("LOC")
            BindLOC()
            RN.Text = Session("RN")
            If RN.Text <> "" Then
                If Session("STS") <> "NEW" Then
                    execute_query2()
                Else
                    execute_query3()
                End If
            End If
        End If
    End Sub

    Private Sub BindLOC()
        GetDataSource2()
        With DFRM_LOC
            .DataTextField = "LOC_DES"
            .DataValueField = "LOC"
            .DataSource = DVLOC
            .DataBind()
        End With
        With DTO_LOC
            .DataTextField = "LOC_DES"
            .DataValueField = "LOC"
            .DataSource = DVLOC
            .DataBind()
        End With
    End Sub

    Private Sub GetDataSource2()
        If Not IsNothing(Cache("LOC")) Then
            DVLOC = CType(Cache("LOC"), DataView)
        Else
            DVLOC = CreateDataSet2().Tables(0).DefaultView
            Cache("LOC") = DVLOC
        End If

    End Sub

    Private Function CreateDataSet2() As DataSet
        Dim strSQL As String = _
            "SELECT LOC,LOC_DES from SLPLOCMS order by LOC_DES "
        Dim scmd As New SqlCommand(strSQL, SCN_SQL21)
        Dim sda As New SqlDataAdapter(scmd)

        Dim ds2 As New DataSet
        sda.Fill(ds2)

        Return ds2
    End Function
    Private Sub BFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFind.Click
        If Session("STS") <> "NEW" Then
            execute_query2()
        Else
            execute_query3()
        End If
    End Sub
    Sub execute_query2()
        Dim SQL As String
        SQL = "SELECT * "
        SQL &= "FROM CRMXSLE WHERE ROWID = " & Session("ROWID")
        Dim SDR2 As SqlDataReader
        Dim SCM2 As New SqlCommand(SQL, SCN1)
        If SCN1.State <> ConnectionState.Open Then
            SCN1.Open()
        End If
        SDR2 = SCM2.ExecuteReader()
        If SDR2.Read Then
            Rowid.Text = SDR2("rowid")
            RN.Text = SDR2("rn")
            NME.Text = SDR2("nme")
            Try
                DTE.Text = String.Format("{0:d}", SDR2("dte"))
            Catch E As Exception
            End Try
            Try
                upd_dte.Text = String.Format("{0:dd/MM/yyyy HH:mm}", SDR2("upd_dte"))
            Catch E As Exception
            End Try
            Try
                DFRM_LOC.SelectedValue = SDR2("FRM_LOC")
            Catch E As Exception
            End Try
            Try
                DTO_LOC.SelectedValue = SDR2("TO_LOC")
            Catch E As Exception
            End Try
            Try
                UPD_BY.Text = SDR2("UPD_BY")
            Catch E As Exception
            End Try
            Try
                XX_BY.Text = SDR2("X_BY")
            Catch E As Exception
            End Try
            XSTS.Text = SDR2("STS")
            Try
                nte.Text = SDR2("NTE")
            Catch E As Exception
            End Try
            Try
                XTEL_NTE.Text = SDR2("TEL_NTE")
            Catch E As Exception
            End Try
            Try
                XTEL.Text = SDR2("TEL")
            Catch E As Exception
            End Try
            Try
                RSL.Text = SDR2("RSL")
            Catch E As Exception
            End Try
        End If
        SDR2.Close()


        SCN1.Close()
    End Sub
    Sub execute_query3()
        Dim SQL As String
        SQL = "SELECT  papmi_name3, papmi_name, papmi_name2,PAPER_TELH "
        SQL &= "  FROM vw_patmas WHERE papmi_no = '" & RN.Text & "'"
        Dim ODR1 As OdbcDataReader
        Dim OCM1 As New OdbcCommand(SQL, OCN1)
        If OCN1.State <> ConnectionState.Open Then
            OCN1.Open()
        End If
        ODR1 = OCM1.ExecuteReader()
        If ODR1.Read Then
            Try
                NME.Text = ODR1.Item("papmi_name3") & " " & ODR1.Item("papmi_name") & " " & ODR1.Item("papmi_name2")

            Catch E As Exception
            End Try
            Try
                XTEL.Text = ODR1.Item("PAPER_TELH")
            Catch E As Exception
            End Try

            Try
                DTE.Text = Format(Today, "dd/MM/yyyy")
            Catch E As Exception
            End Try

            Try
                upd_dte.Text = String.Format("{0:dd/MM/yyyy HH:mm}", Now)
            Catch E As Exception
            End Try
        Else
            xmsg.Text = "Error Cannot find this patient "
        End If
        OCN1.Close()
        ODR1.Close()

        If NME.Text = "" Then
            xmsg.Text = " Invalid HN This patient never admitting"
            Session("ROWID") = ""
            Session("RN") = ""

        End If
    End Sub

    Private Sub BSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim SQL As String
        If NME.Text = "" Then
            xmsg.Text = " Invalid HN This patient never exist"
            Exit Sub
        End If
        Dim ycnt As Int16 = 0
        Dim xnum As Int16 = 0
        Dim xavg As Double = 0.0
        Dim xscr As Double = 0.0

        If Rowid.Text <> "" Then
            SQL = "UPDATE CRMXSLE SET rn = '" & RN.Text & "', dte = '" & DTE.Text & "' "

            SQL &= " ,  nme = '" & NME.Text & "' "
            If nte.Text <> "" Then
                SQL &= ",nte = '" & nte.Text & "' "
            Else
                SQL &= ",nte = null "
            End If
            If XTEL.Text <> "" Then
                SQL &= ",TEL = '" & XTEL.Text & "' "
            Else
                SQL &= ",TEL = null "
            End If
            If XTEL_NTE.Text <> "" Then
                SQL &= ",TEL_NTE = '" & XTEL_NTE.Text & "' "
            Else
                SQL &= ",TEL_NTE = null "
            End If
            If CType(Session("USR_ID"), String) <> "" Then
                SQL &= ",UPD_BY = '" & CType(Session("USR_ID"), String) & "' "
            End If
            If DFRM_LOC.SelectedValue <> "" Then
                SQL &= ",FRM_LOC = '" & DFRM_LOC.SelectedValue & "' "
            End If
            If DTO_LOC.SelectedValue <> "" Then
                SQL &= ",TO_LOC = '" & DTO_LOC.SelectedValue & "' "
            End If
            SQL &= ", upd_dte = '" & String.Format("{0:dd/MM/yyyy HH:mm}", Now) & "' "
            SQL &= " WHERE rowid = " & Rowid.Text
            Dim UPDCMD As SqlCommand
            UPDCMD = New SqlCommand(SQL, SCN1)
            If SCN1.State <> ConnectionState.Open Then
                SCN1.Open()
            End If
            UPDCMD.ExecuteNonQuery()
            'SQL = "DELETE FROM CRMXSLE WHERE rowid = " & Rowid.Text
            'Dim DELCMD As SqlCommand
            'DELCMD = New SqlCommand(SQL, SCN1)
            'If SCN1.State <> ConnectionState.Open Then
            '    SCN1.Open()
            'End If
            'DELCMD.ExecuteNonQuery()
        Else
            Dim SQL2 As String
            SQL = "INSERT INTO CRMXSLE (rn, nme,STS, "
            SQL2 = RN.Text & "','" & NME.Text & "','A', "
            If DTE.Text <> "" Then
                SQL &= "dte, "
                SQL2 &= " '" & DTE.Text & "', "
            End If
            If CType(Session("USR_ID"), String) <> "" Then
                SQL &= "X_BY, "
                SQL2 &= " '" & CType(Session("USR_ID"), String) & "', "
                SQL &= "UPD_BY, "
                SQL2 &= " '" & CType(Session("USR_ID"), String) & "', "
            End If
            If nte.Text <> "" Then
                SQL &= "nte, "
                SQL2 &= " '" & nte.Text & "', "
            End If
            If XTEL.Text <> "" Then
                SQL &= "TEL, "
                SQL2 &= " '" & XTEL.Text & "', "
            End If
            If XTEL_NTE.Text <> "" Then
                SQL &= "TEL_NTE, "
                SQL2 &= " '" & XTEL_NTE.Text & "', "
            End If
            If DFRM_LOC.SelectedValue <> "" Then
                SQL &= "FRM_LOC, "
                SQL2 &= " '" & DFRM_LOC.SelectedValue & "', "
            End If
            If DTO_LOC.SelectedValue <> "" Then
                SQL &= "TO_LOC, "
                SQL2 &= " '" & DTO_LOC.SelectedValue & "', "
            End If
            SQL &= "upd_dte) values ( '"
            SQL2 &= " '" & String.Format("{0:dd/MM/yyyy HH:mm}", Now) & "' ) "


            SQL &= SQL2
            Dim INSCMD As SqlCommand
            INSCMD = New SqlCommand(SQL, SCN1)
            If SCN1.State <> ConnectionState.Open Then
                SCN1.Open()
            End If
            INSCMD.ExecuteNonQuery()

            Dim XROWID As Double
            SQL = "SELECT MAX(ROWID) FROM  CRMXSLE  WHERE RN = '" & RN.Text & "'"
            Dim SCM2 As New SqlCommand(SQL, SCN1)
            If SCN1.State <> ConnectionState.Open Then
                SCN1.Open()
            End If
            XROWID = SCM2.ExecuteScalar
            Rowid.Text = XROWID
            Session("ROWID") = XROWID
            Session("STS") = "UPD"

        End If
        execute_query2()
        xmsg.Text = " Save Complete"
    End Sub

    Private Sub BExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExit.Click
        Response.Redirect("XSLE.aspx")
    End Sub


End Class

End Namespace
