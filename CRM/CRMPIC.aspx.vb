Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient


Namespace CRM


Partial Class CRMPIC
    Inherits System.Web.UI.Page
    Dim dts1 As DataSet
    Dim oda1 As OdbcDataAdapter
    Dim OCN1 As New OdbcConnection(Constants.OCN_MEDSD)
    Dim SCN1 As New SqlConnection(Constants.SCN_SQL)

    Dim SCN_SQL3 As New SqlConnection(Constants.SCN_SQL3)



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
        xrn.Text = xrn.Text.Trim
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
        If xrn.Text = "" Then
            Exit Sub
        End If
        datafill()

    End Sub

    Sub datafill()
        Dim SDR4 As SqlDataReader
        Dim XSQL2 As String
        Dim XHAB As String
        '-----------------------------------------------------------------
        Try

            XSQL2 = "SELECT CRM_TYP, CRM_CDE,CRM_SUF,CRM_NTE,UPD_DTE FROM CRMTRA  WHERE RN = '" & xrn.Text & "' AND CRM_TYP = 'PIC' "
            XSQL2 &= " ORDER BY ROWID DESC "

            Dim SCM7 As New SqlCommand(XSQL2, SCN1)

            Dim XCRM_TYP As String
            Dim XCRM_DTE As String = ""
            Dim XSQL3 As String
            If SCN1.State <> ConnectionState.Open Then
                SCN1.Open()
            End If
            Try
                SDR4 = SCM7.ExecuteReader()
                XHAB = ""
                While SDR4.Read()

                    Try
                        If Not IsDBNull(SDR4.Item("UPD_DTE")) Then
                            XCRM_DTE = Format(SDR4.Item("UPD_DTE"), "dd/MM/yyyy")
                        End If


                        XHAB &= "<tr><td>" & XCRM_DTE & "</td>"
                        XHAB &= "<td>" & "&nbsp;&nbsp;"

                        XHAB &= "<a href='" & SDR4.Item("CRM_NTE") & "' target='New'>" & SDR4.Item("CRM_NTE") & " </a></td>"

                        XHAB &= "</tr>"
                    Catch ex As Exception
                    End Try
                End While
                SDR4.Close()
                SCN1.Close()
                If XHAB <> "" Then
                    XHAB = "<TABLE style='FONT-WEIGHT: bold; FONT-SIZE: x-small; FONT-FAMILY: Tahoma'  cellpadding='3px' border='1px'>" & XHAB & "</TABLE>"
                End If
            Catch ex As Exception
            End Try
        Catch e As Exception
        End Try
        XPIC.Text = XHAB
        '----------------------------------------------------------

    End Sub



    Private Sub BFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFind.Click
        execute_query1()
    End Sub

End Class

End Namespace
