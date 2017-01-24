Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient


Namespace CRM


Partial Class CRM1
    Inherits System.Web.UI.Page
    Dim dts1 As DataSet
    Dim oda1 As OdbcDataAdapter
    Dim OCN1 As New OdbcConnection(Constants.OCN_MEDSD)
    Dim SCN1 As New SqlConnection(Constants.SCN_SQL)
    Dim SCN2 As New SqlConnection(Constants.SCN_SQL)
    Dim SCN_SQL3 As New SqlConnection(Constants.SCN_SQL3)
    Protected WithEvents Promotion As System.Web.UI.WebControls.HyperLink
    Protected WithEvents CrossSale As System.Web.UI.WebControls.HyperLink
    Dim XVST_FLG As String = "N"


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
            If Request.Item("RN") <> "" Then
                Session("RN") = Request.Item("RN")
            End If
            xrn.Text = Session("RN")
            execute_query1()
        Else

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
            execute_query1()
        End If
    End Sub
    Sub execute_query1()
        datafill()
        SHOW()
        clear()
    End Sub

    Sub datafill()
        Dim sql_pt As String
        Dim SQL_CMM As String
        Dim SQL_RN As String
        Dim SQL_NME As String
        Dim SQL_LST_NME As String
        Dim SQL_LST_NME2 As String
        SQL_CMM = "SELECT  PAPMI_RowId,PAPMI_NO,PAPMI_ID, PAPMI_NAME, PAPMI_NAME2, PAPMI_NAME3, PAPMI_DOB, CTSEX_CODE, PAPER_STNAMELINE1, PAPER_TELH, PAPER_TELO, " & _
        " PROV_CODE, PROV_DESC, CTZIP_CODE, CTNAT_CODE, CTNAT_DESC, CITAREA_DESC, CTCIT_DESC  , PAPMI_Deceased_Date ,PCAT_Desc   FROM vw_patmas "
        SQL_RN = " WHERE PAPMI_NO =  "
        SQL_NME = " WHERE PAPMI_NAME LIKE  "
        SQL_LST_NME = " AND PAPMI_NAME2 LIKE "
        SQL_LST_NME2 = "  WHERE PAPMI_NAME2 LIKE "
        sql_pt = SQL_CMM
        If xrn.Text <> "" Then
            sql_pt &= SQL_RN & "'" & xrn.Text & "' "
            Session("RN") = xrn.Text   
        Else
        If xnme.Text <> "" Then
            SQL_NME &= "'" & xnme.Text & "%'"
            sql_pt &= SQL_NME
            If xlst_nme.Text <> "" Then
                SQL_LST_NME &= "'" & xlst_nme.Text & "%'"
                sql_pt &= SQL_LST_NME
            End If
        Else
            If xlst_nme.Text <> "" Then
                SQL_LST_NME2 &= " '" & xlst_nme.Text & "%'"
                sql_pt &= SQL_LST_NME2
            Else
                Exit Sub
            End If
        End If
        End If
If sql_pt.IndexOf("WHERE") >= 0 Then
                sql_pt &= " and PAPMI_NO <> '' "
            Else
                sql_pt &= " where PAPMI_NO <> '' "
            End If
        If OCN1.State <> ConnectionState.Open Then
            OCN1.Open()
        End If
            oda1 = New OdbcDataAdapter(sql_pt, OCN1)
            dts1 = New DataSet

            oda1.Fill(dts1, "VW_PATMAS_AA")
        Dim NME As DataColumn = New DataColumn("NME")
        NME.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(NME)

        Dim AGE As DataColumn = New DataColumn("AGE")
        AGE.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(AGE)

        Dim STATUS As DataColumn = New DataColumn("STATUS")
        STATUS.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(STATUS)

        Dim MSG As DataColumn = New DataColumn("MSG")
        MSG.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(MSG)

        Dim IPD_VST As DataColumn = New DataColumn("IPD_VST")
        IPD_VST.DataType = System.Type.GetType("System.Int16")
        dts1.Tables(0).Columns.Add(IPD_VST)

        Dim TOT_VST As DataColumn = New DataColumn("TOT_VST")
        TOT_VST.DataType = System.Type.GetType("System.Int16")
        dts1.Tables(0).Columns.Add(TOT_VST)

        Dim NET_OPD As DataColumn = New DataColumn("NET_OPD")
        NET_OPD.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(NET_OPD)

        Dim NET_IPD As DataColumn = New DataColumn("NET_IPD")
        NET_IPD.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(NET_IPD)

        Dim VST As DataColumn = New DataColumn("VST")
        VST.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(VST)
        Dim HAB As DataColumn = New DataColumn("HAB")
        HAB.DataType = System.Type.GetType("System.String")
        dts1.Tables(0).Columns.Add(HAB)

        Dim xtot As Int16
        Dim xcnt As Int16
        xtot = dts1.Tables(0).Rows.Count
        If xtot > 0 Then
            xcnt = 0
            If OCN1.State <> ConnectionState.Open Then
                OCN1.Open()
            End If
            If SCN_SQL3.State <> ConnectionState.Open Then
                SCN_SQL3.Open()
            End If
            If SCN1.State <> ConnectionState.Open Then
                SCN1.Open()
            End If
            Dim SDR2 As OdbcDataReader
            Dim SDR3 As SqlDataReader
            Dim SDR4 As SqlDataReader
            While (xcnt + 1) <= xtot

                    dts1.Tables(0).Rows(xcnt)("NME") = dts1.Tables(0).Rows(xcnt)("PAPMI_Name3") & " " & _
                    dts1.Tables(0).Rows(xcnt)("PAPMI_Name") & " " & _
                    dts1.Tables(0).Rows(xcnt)("PAPMI_Name2")

                    If IsDBNull(dts1.Tables(0).Rows(xcnt)("PCAT_Desc")) Then
                        dts1.Tables(0).Rows(xcnt)("STATUS") = "<center>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</center>"
                    Else

                        dts1.Tables(0).Rows(xcnt)("STATUS") = dts1.Tables(0).Rows(xcnt)("PCAT_Desc")
                    End If
                    Try
                        dts1.Tables(0).Rows(xcnt)("AGE") = DateDiff(DateInterval.Year, dts1.Tables(0).Rows(xcnt)("PAPMI_DOB"), Today()).ToString
                    Catch
                    End Try
                    If Not IsDBNull(dts1.Tables(0).Rows(xcnt)("PAPMI_Deceased_Date")) Then
                        dts1.Tables(0).Rows(xcnt)("STATUS") &= "Deceased " & String.Format("{0:d}", dts1.Tables(0).Rows(xcnt)("PAPMI_Deceased_Date"))
                    End If

                    Dim XPAPMI_ROWID As Int64
                    Dim XPAPMI_NO As String
                    Dim XSQL2 As String
                    XPAPMI_ROWID = dts1.Tables(0).Rows(xcnt)("PAPMI_RowId")
                    If Not IsDBNull(dts1.Tables(0).Rows(xcnt)("PAPMI_NO")) Then
                        XPAPMI_NO = dts1.Tables(0).Rows(xcnt)("PAPMI_NO")
                    End If
                    XSQL2 = "select ALM_Message as ALM_MESS_1,ALM_CREATEDATE from pa_alertmsg where alm_papmi_parref = " & XPAPMI_ROWID.ToString & " and  (ALM_ClosedFlag <> 'Y' or ALM_ClosedFlag is null)"
                    Dim SCM2 As New OdbcCommand(XSQL2, OCN1)
                    Try
                        SDR2 = SCM2.ExecuteReader()
                        While SDR2.Read()
                            Try
                                dts1.Tables(0).Rows(xcnt)("MSG") &= SDR2.Item("ALM_MESS_1") & "  " & String.Format("{0:d}", SDR2.Item("ALM_CREATEDATE")) & "<Br>"
                            Catch ex As Exception
                            End Try
                        End While
                    Catch ex As Exception
                    End Try
                    XSQL2 = "select count(distinct paadm_rowid) from ipdadm where papmi_no = '" & XPAPMI_NO & "'"
                    Dim SCM3 As New SqlCommand(XSQL2, SCN_SQL3)
                    Dim XVST_CNT As Int16
                    Dim XNET_IPD As Decimal
                    Dim XNET_OPD As Decimal
                    Try
                        XVST_CNT = SCM3.ExecuteScalar()
                        Try
                            dts1.Tables(0).Rows(xcnt)("IPD_VST") = XVST_CNT
                        Catch e As Exception
                        End Try
                    Catch ex As Exception
                    End Try
                    If XPAPMI_NO <> "" Then
                        XSQL2 = "select count(distinct paadm_rowid) from opdvisit where papmi_row_id = " & XPAPMI_ROWID.ToString
                        Dim SCM4 As New SqlCommand(XSQL2, SCN_SQL3)
                        Try
                            XVST_CNT = SCM4.ExecuteScalar()
                            Try
                                dts1.Tables(0).Rows(xcnt)("TOT_VST") = XVST_CNT
                            Catch e As Exception
                            End Try
                        Catch ex As Exception
                        End Try
                    End If
                    XSQL2 = "select SUM(NET_AMT) from opdvisit where papmi_row_id = " & XPAPMI_ROWID.ToString & " and paadm_admno NOT LIKE 'I%'"
                    XNET_OPD = 0
                    Dim SCM5 As New SqlCommand(XSQL2, SCN_SQL3)
                    Try
                        XNET_OPD = SCM5.ExecuteScalar()
                    Catch ex As Exception
                    End Try
                    If XPAPMI_NO <> "" Then
                        XSQL2 = "select SUM(NET_AMT) from ipdvisit where papmi_no = '" & XPAPMI_NO & "'"
                        XNET_IPD = 0
                        Dim SCM52 As New SqlCommand(XSQL2, SCN_SQL3)
                        Try
                            XNET_IPD = SCM52.ExecuteScalar()
                        Catch ex As Exception
                        End Try
                    End If
                    Try
                        Dim znet As Int64
                        znet = Math.Ceiling(Decimal.Truncate(XNET_OPD) / 10000)
                        dts1.Tables(0).Rows(xcnt)("NET_OPD") = " ".PadRight(znet, "_") & znet.ToString
                        znet = Math.Ceiling(Decimal.Truncate(XNET_IPD) / 10000)
                        dts1.Tables(0).Rows(xcnt)("NET_IPD") = " ".PadRight(znet, "_") & znet.ToString
                    Catch e As Exception
                    End Try

                    If XVST_FLG = "Y" Then
                        XSQL2 = "select TOP 10 CTLOC_CODE,PAADM_ADMDATE,CAREPROVIDERNAME, PAYORDESC,EPISODE_TYPE ,PLANDESC, NET_AMT"
                        XSQL2 &= " from opdvisit,PAYOR_INST,AUXIT, CT_CAREPROV where papmi_row_id = " & XPAPMI_ROWID.ToString
                        XSQL2 &= " AND OPDVISIT.INST_ROWID = PAYOR_INST.PAYOR_DR "
                        XSQL2 &= " AND OPDVISIT.AUXIT_ROWID = AUXIT.PLAN_DR AND OPDVISIT.CTPCP_CODE = CT_CAREPROV.CAREPROVIDERCODE "
                        XSQL2 &= " ORDER BY PAADM_ADMDATE DESC "
                        Dim SCM6 As New SqlCommand(XSQL2, SCN_SQL3)
                        Dim XVST As String
                        Try
                            SDR3 = SCM6.ExecuteReader()
                            While SDR3.Read()
                                Try
                                    XVST = "<tr><td>" & String.Format("{0:d}", SDR3.Item("PAADM_ADMDATE")) & "</td>"
                                    XVST &= "<td>" & SDR3.Item("EPISODE_TYPE") & "</td>"
                                    XVST &= "<td>" & SDR3.Item("CTLOC_CODE") & "</td>"
                                    XVST &= "<td>" & SDR3.Item("CAREPROVIDERNAME") & "</td>"
                                    XVST &= "<td>" & SDR3.Item("PAYORDESC") & "</td>"
                                    XVST &= "<td>" & SDR3.Item("PLANDESC") & "</td>"
                                    XVST &= "<td align=right>" & SDR3.Item("NET_AMT") & "</td>"
                                    XVST &= "</tr>"
                                    dts1.Tables(0).Rows(xcnt)("VST") &= XVST
                                Catch ex As Exception
                                End Try
                            End While
                            SDR3.Close()
                            If Not IsDBNull(dts1.Tables(0).Rows(xcnt)("VST")) Then
                                dts1.Tables(0).Rows(xcnt)("VST") = "<TABLE style='FONT-WEIGHT: bold; FONT-SIZE: x-small; FONT-FAMILY: Tahoma'  cellpadding='3px' border='1px'>" & dts1.Tables(0).Rows(xcnt)("VST") & "</TABLE>"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                    '-----------------------------------------------------------------
                    Try
                        Dim XRN2 As String
                        XRN2 = dts1.Tables(0).Rows(xcnt)("PAPMI_NO")

                        XSQL2 = "SELECT CRM_TYP, CRM_CDE,CRM_SUF,CRM_NTE FROM CRMTRA  WHERE RN = '" & XRN2 & "' "
                        XSQL2 &= " ORDER BY CRM_CDE,CRM_SUF "

                        Dim SCM7 As New SqlCommand(XSQL2, SCN1)
                        Dim XHAB As String
                        Dim XCRM_TYP As String
                        Dim XCRM_CDE As String
                        Dim XCRM_SUF As String
                        Dim XSQL3 As String
                        Try
                            SDR4 = SCM7.ExecuteReader()
                            SCN2.Open()
                            While SDR4.Read()

                                Try
                                    XCRM_TYP = SDR4.Item("CRM_TYP")
                                    XCRM_CDE = SDR4.Item("CRM_CDE")
                                    XCRM_SUF = SDR4.Item("CRM_SUF")

                                    XSQL3 = "select CRM_DES from CRMMASH where CRM_TYP = '" & XCRM_TYP & "' AND CRM_CDE = '" & XCRM_CDE & "' "
                                    Dim SCM11 As New SqlCommand(XSQL3, SCN2)
                                    Dim XCRM_DES As String
                                    Try
                                        XCRM_DES = SCM11.ExecuteScalar()
                                    Catch ex As Exception
                                    End Try

                                    XSQL3 = "select CRM_SUF_DES from CRMMASD where CRM_TYP = '" & XCRM_TYP & "' AND CRM_CDE = '" & XCRM_CDE & "'  AND CRM_SUF = '" & XCRM_SUF & "' "
                                    Dim SCM12 As New SqlCommand(XSQL3, SCN2)
                                    Dim XCRM_SUF_DES As String
                                    Try
                                        XCRM_SUF_DES = SCM12.ExecuteScalar()
                                        If XCRM_CDE = "0001" Then
                                            dts1.Tables(0).Rows(xcnt)("STATUS") &= " " & XCRM_SUF_DES
                                        End If
                                    Catch ex As Exception
                                    End Try

                                    XHAB = "<tr><td>" & XCRM_DES & "</td>"
                                    XHAB &= "<td>" & XCRM_SUF_DES & "&nbsp;&nbsp;"
                                    If XCRM_DES = "Document" Then
                                        'XHAB &= "<a href='" & SDR4.Item("CRM_NTE") & "' target='New'>" & SDR4.Item("CRM_NTE") & " </a></td>"
                                        XHAB &= "<a href='http://tsv/CRM/" & SDR4.Item("CRM_NTE") & "' target='New'>" & SDR4.Item("CRM_NTE") & " </a></td>"
                                    Else
                                        XHAB &= SDR4.Item("CRM_NTE") & "</td>"
                                    End If

                                    XHAB &= "</tr>"
                                    dts1.Tables(0).Rows(xcnt)("HAB") &= XHAB
                                Catch ex As Exception
                                End Try
                            End While
                            SDR4.Close()
                            SCN2.Close()
                            If Not IsDBNull(dts1.Tables(0).Rows(xcnt)("HAB")) Then
                                dts1.Tables(0).Rows(xcnt)("HAB") = "<TABLE style='FONT-WEIGHT: bold; FONT-SIZE: x-small; FONT-FAMILY: Tahoma'  cellpadding='3px' border='1px'>" & dts1.Tables(0).Rows(xcnt)("HAB") & "</TABLE>"
                            End If
                        Catch ex As Exception
                        End Try
                    Catch e As Exception
                    End Try
                    '----------------------------------------------------------
                    xcnt += 1
                End While
        End If
    End Sub

    Sub SHOW()
        Gfrq.DataSource = dts1
        Gfrq.DataBind()
    End Sub
    Sub clear()
        oda1 = Nothing
        dts1 = Nothing
        OCN1.Close()
        SCN_SQL3.Close()
    End Sub
    Sub EDT(ByVal o As Object, ByVal e As DataListCommandEventArgs)
        Dim XTMP As String
        Dim XTMP2 As String
        XTMP = CType(e.Item.FindControl("PAPMI_NO"), Label).Text
        XTMP2 = CType(e.Item.FindControl("NME"), Label).Text
        Session("NME") = XTMP2
        Session("RN") = XTMP
        Response.Redirect("CRM2.aspx?RN=" & XTMP)
    End Sub
    Sub Uppic(ByVal o As Object, ByVal e As DataListCommandEventArgs)
        Dim XTMP As String
        Dim XTMP2 As String
        XTMP = CType(e.Item.FindControl("PAPMI_NO"), Label).Text
        XTMP2 = CType(e.Item.FindControl("NME"), Label).Text
        Session("NME") = XTMP2
        Session("RN") = XTMP
        Response.Redirect("CRMUpl.aspx?RN=" & XTMP)
    End Sub
    Sub BLDGRP(ByVal o As Object, ByVal e As DataListCommandEventArgs)
        Dim XTMP As String
        XTMP = CType(e.Item.FindControl("PAPMI_NO"), Label).Text
        Response.Redirect("http://tsv/Lab/LabRsl.aspx?BLD_GRP=Y&RN=" & XTMP)
    End Sub
    Sub VST(ByVal o As Object, ByVal e As DataListCommandEventArgs)
        XVST_FLG = "Y"
        xrn.Text = e.CommandArgument
        xnme.Text = ""
        xlst_nme.Text = ""
        execute_query1()
        XVST_FLG = "N"
    End Sub

    Private Sub BFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFind.Click
        execute_query1()
    End Sub

    Private Sub Gfrq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gfrq.SelectedIndexChanged

    End Sub
End Class

End Namespace
