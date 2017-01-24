Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient


Namespace CRM

Partial Class CRM2
    Inherits System.Web.UI.Page

    Private WithEvents mds, MDS2 As DataSet
    Dim SCN1 As New SqlConnection(Constants.SCN_SQL)
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
        If Not Page.IsPostBack Then

            SRN.Text = Request("RN")
            SNME.Text = Session("NME")
            mds = New DataSet
            MDS2 = New DataSet
            Dim da As New SqlClient.SqlDataAdapter( _
              "SELECT CRM_TYP, CRM_CDE,CRM_DES FROM CRMMASH WHERE CRM_TYP = 'SOC';", SCN1)
            Dim da2 As New SqlClient.SqlDataAdapter( _
              "SELECT ROWID,RN, CRM_TYP, CRM_CDE,CRM_SUF,CRM_NTE FROM CRMTRA  WHERE RN = '" & SRN.Text & "' AND CRM_TYP = 'SOC';", SCN1)
            If SRN.Text <> "" Then
                Try
                    da2.Fill(MDS2, "CRMTRA")
                    Dim CCRM_DES As DataColumn = New DataColumn("CCRM_DES")
                    CCRM_DES.DataType = System.Type.GetType("System.String")
                    MDS2.Tables(0).Columns.Add(CCRM_DES)

                    Dim CCRM_SUF_DES As DataColumn = New DataColumn("CCRM_SUF_DES")
                    CCRM_SUF_DES.DataType = System.Type.GetType("System.String")
                    MDS2.Tables(0).Columns.Add(CCRM_SUF_DES)
                    Dim xtot As Int16
                    Dim xcnt As Int16
                    xtot = MDS2.Tables(0).Rows.Count
                    If xtot > 0 Then
                        xcnt = 0
                        If SCN1.State <> ConnectionState.Open Then
                            SCN1.Open()
                        End If
                        Dim SDR3 As SqlDataReader
                        Dim XSQL2 As String
                        Dim XCRM_TYP As String
                        Dim XCRM_CDE As String
                        Dim XCRM_SUF As String

                        While (xcnt + 1) <= xtot
                            XCRM_TYP = MDS2.Tables(0).Rows(xcnt)("CRM_TYP")
                            XCRM_CDE = MDS2.Tables(0).Rows(xcnt)("CRM_CDE")
                            XCRM_SUF = MDS2.Tables(0).Rows(xcnt)("CRM_SUF")

                            XSQL2 = "select CRM_DES from CRMMASH where CRM_TYP = '" & XCRM_TYP & "' AND CRM_CDE = '" & XCRM_CDE & "' "
                            Dim SCM2 As New SqlCommand(XSQL2, SCN1)
                            Dim XCRM_DES As String
                            Try
                                XCRM_DES = SCM2.ExecuteScalar()
                                Try
                                    MDS2.Tables(0).Rows(xcnt)("CCRM_DES") = XCRM_DES
                                Catch eY As Exception
                                End Try
                            Catch ex As Exception
                            End Try

                            XSQL2 = "select CRM_SUF_DES from CRMMASD where CRM_TYP = '" & XCRM_TYP & "' AND CRM_CDE = '" & XCRM_CDE & "'  AND CRM_SUF = '" & XCRM_SUF & "' "
                            Dim SCM3 As New SqlCommand(XSQL2, SCN1)
                            Dim XCRM_SUF_DES As String
                            Try
                                XCRM_SUF_DES = SCM3.ExecuteScalar()
                                Try
                                    MDS2.Tables(0).Rows(xcnt)("CCRM_SUF_DES") = XCRM_SUF_DES
                                Catch eY As Exception
                                End Try
                            Catch ex As Exception
                            End Try
                            xcnt += 1
                        End While
                    End If
                    Session("mds2") = MDS2
                    REFRESH_CRMTRA()

                    da.Fill(mds, "CRMMASH")
                    da.SelectCommand.CommandText = _
                      "SELECT CRM_TYP, CRM_CDE, CRM_SUF, CRM_SUF_DES FROM CRMMASD WHERE CRM_TYP = 'SOC' ORDER BY CRM_SUF ;"
                    da.Fill(mds, "CRMMASD")
                    da.Dispose()

                    Dim XC As DataColumn
                    Dim parentCols(1) As DataColumn

                    Dim childCols(1) As DataColumn

                    parentCols(0) = mds.Tables("CRMMASH").Columns("CRM_TYP")
                    parentCols(1) = mds.Tables("CRMMASH").Columns("CRM_CDE")

                    childCols(0) = mds.Tables("CRMMASD").Columns("CRM_TYP")
                    childCols(1) = mds.Tables("CRMMASD").Columns("CRM_CDE")

                    Dim CRMRel As DataRelation
                    CRMRel = New DataRelation("CRMRel", parentCols, childCols)
                    ' Add the relation to the DataSet.
                    mds.Relations.Add(CRMRel)

                    Session("mds") = mds

                    ' Fill the dropdown Category list
                    cboCRMH.DataTextField = "CRM_DES"
                    cboCRMH.DataValueField = "CRM_CDE"
                    cboCRMH.DataSource = mds.Tables("CRMMASH")
                    cboCRMH.DataBind()

                    ' Fill the Products list
                    RefreshCRMDLIST()
                    ' Select the first item on the list
                    lboCRMD.SelectedIndex = 0

                    lblError.Text = String.Empty
                Catch ex As Exception
                    lblError.Text = ex.ToString
                Finally
                    da.Dispose()
                End Try
            End If
        Else

            mds = CType(Session("mds"), DataSet)
            MDS2 = CType(Session("mds2"), DataSet)
        End If

    End Sub

    Private Sub RefreshCRMDLIST()
        ' Clear out the current list
        lboCRMD.Items.Clear()

        Dim rowCRMH As DataRow = _
          mds.Tables("CRMMASH").Select("CRM_CDE= '" & cboCRMH.SelectedItem.Value & "' ")(0)
        Dim rowCRMD As DataRow
        Dim li As ListItem
        For Each rowCRMD In rowCRMH.GetChildRows(mds.Relations("CRMrel"))
            li = New ListItem(text:=rowCRMD("CRM_SUF_DES"), value:=rowCRMD("CRM_SUF"))
            lboCRMD.Items.Add(li)
        Next

        lblError.Text = String.Empty
    End Sub
    Sub REFRESH_CRMTRA()
        Gfrq.DataSource = MDS2
        Gfrq.DataBind()
    End Sub
    Sub DEL(ByVal o As Object, ByVal e As DataListCommandEventArgs)
     
        'Dim rowdel As DataRow
        'rowdel = MDS2.Tables("CRMTRA").Rows(e.Item.ItemIndex)

        MDS2.Tables(0).Rows(e.Item.ItemIndex).Delete()
        REFRESH_CRMTRA()
    End Sub

    Private Sub cboCRMH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCRMH.SelectedIndexChanged
        Try
            RefreshCRMDLIST()
            lboCRMD.SelectedIndex = 0
            ' RefreshProductDetails(lboProducts.SelectedItem.Text)
        Catch ex As Exception
            lblError.Text = ex.ToString
        End Try

    End Sub

    Private Sub BLEFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLEFT.Click
        Dim rowNew As DataRow
        rowNew = MDS2.Tables("CRMTRA").NewRow
        rowNew("RN") = SRN.Text
        rowNew("CRM_TYP") = "SOC"
        rowNew("CRM_CDE") = cboCRMH.SelectedValue
        rowNew("CCRM_DES") = cboCRMH.SelectedItem

        rowNew("CRM_SUF") = lboCRMD.SelectedValue
        rowNew("CCRM_SUF_DES") = lboCRMD.SelectedItem
        rowNew("CRM_NTE") = XNTE.Text

        MDS2.Tables(0).Rows.Add(rowNew)
        REFRESH_CRMTRA()
        XNTE.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim da As New SqlClient.SqlDataAdapter
        Dim cnn As New SqlClient.SqlConnection(Constants.SCN_SQL)

        Dim cmdDelete As New SqlClient.SqlCommand( _
        "DELETE FROM  CRMTRA  WHERE ROWID = @ROWID")
        cmdDelete.Connection = cnn
        With cmdDelete.Parameters
            .Add("@ROWID", SqlDbType.Float, 18, "ROWID")
        End With
        'Dim prmD As SqlClient.SqlParameter = _
        '  cmdDelete.Parameters.Add( _
        '  "@ROWID", SqlDbType.Float, 18, "ROWID")
        ' prmD.SourceVersion = DataRowVersion.Original

        Dim cmdUpdate As New SqlClient.SqlCommand( _
        "UPDATE CRMTRA Set  CRM_NTE = @CRM_NTE WHERE ROWID = @ROWID")
        cmdUpdate.Connection = cnn

        With cmdUpdate.Parameters
            .Add("@CRM_NTE", SqlDbType.VarChar, 1000, "CRM_NTE")
        End With
        Dim prm As SqlClient.SqlParameter = _
          cmdUpdate.Parameters.Add( _
          "@ROWID", SqlDbType.Float, 18, "ROWID")
        prm.SourceVersion = DataRowVersion.Original

        Dim cmdInsert As New SqlClient.SqlCommand( _
         "INSERT INTO  CRMTRA (CRM_TYP,CRM_CDE,CRM_SUF,CRM_NTE,RN) VALUES ( " _
        & "@CRM_TYP ,  @CRM_CDE,  @CRM_SUF , @CRM_NTE , @RN )")
        cmdInsert.CommandType = CommandType.Text
        cmdInsert.Connection = cnn

        With cmdInsert.Parameters
            .Add("@CRM_TYP", SqlDbType.VarChar, 5, "CRM_TYP")
            .Add("@CRM_CDE", SqlDbType.VarChar, 5, "CRM_CDE")
            .Add("@CRM_SUF", SqlDbType.VarChar, 5, "CRM_SUF")
            .Add("@RN", SqlDbType.VarChar, 20, "RN")
            .Add("@ROWID", SqlDbType.Float, 18, "ROWID")
            .Add("@CRM_NTE", SqlDbType.VarChar, 1000, "CRM_NTE")
        End With
        cmdInsert.Parameters("@ROWID").Direction = ParameterDirection.Output

        da.UpdateCommand = cmdUpdate
        da.InsertCommand = cmdInsert
        da.DeleteCommand = cmdDelete
        Try
            ' Normally, you won't need the next step:
            '  Make sure the stored procedure has been created.
            'CreateStoredProcProductInsert()
            cnn.Open()
            da.Update(MDS2, "CRMTRA")

            MDS2.AcceptChanges()
            Session("mds2") = MDS2
            lblError.Text = "Save Completed"
            REFRESH_CRMTRA()

        Catch ex As Exception
            lblError.Text = ex.ToString
        Finally
            ' Release the database connection to the pool.
            cnn.Close()
        End Try

    End Sub
End Class

End Namespace
