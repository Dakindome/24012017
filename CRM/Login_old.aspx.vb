Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page
    Dim XFLG As String = "N"
    Protected WithEvents MSG1 As System.Web.UI.WebControls.Label
    Protected WithEvents Cancel As System.Web.UI.WebControls.Button
    Protected WithEvents RQFV2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents New_Pwd As System.Web.UI.WebControls.TextBox
    Protected WithEvents XNEW_PWD As System.Web.UI.WebControls.Label
    Dim scn_sql As String = Constants.SCN_SQL
    Protected WithEvents chg_pwd As System.Web.UI.WebControls.Button
    Protected WithEvents BSVE_Pwd As System.Web.UI.WebControls.Button
    Dim xchk_pwd As String = "N"
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents MyLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents MyPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents MySelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents MySubmit As System.Web.UI.WebControls.Button

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
        If Not Page.IsPostBack Then
            Dim MyStyle As System.Web.UI.WebControls.Style

            MyStyle = New System.Web.UI.WebControls.Style
            MyStyle.BorderColor = Color.Black
            MyStyle.BorderStyle = BorderStyle.Dashed
            MyStyle.BorderWidth = New Unit(1)

            MyLogin.ApplyStyle(MyStyle)
            MyPassword.ApplyStyle(MyStyle)
        Else
        End If
    End Sub


    Private Sub MySubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MySubmit.Click
        chkpwd()
        If xchk_pwd = "Y" Then
            If Session("NUR_TYP") = "H" Then
                If InStr(CType(Session("USR_GRP_DES"), String), "Head") = 0 And InStr(CType(Session("USR_GRP_DES"), String), "Admin") = 0 And InStr(CType(Session("USR_GRP_DES"), String), "Manager") = 0 Then
                    MSG1.Text = "Khun " & Session("USR_NME") & " group " & Session("USR_GRP_DES") & " are not authorized , Security group Head only"
                Else
                    Response.Redirect(CType(Session("LOG_YES"), String))
                End If
            Else
                Response.Redirect(CType(Session("LOG_YES"), String))
            End If
        End If
    End Sub
    Sub updpwd(ByVal yusr, ByVal ypwd)
        Dim xsql As String
        Dim xcmd As SqlCommand
        Dim scnn As New SqlConnection(scn_sql)
        xsql = "update hr_id set pwd = '" & ypwd & "' where emplid = '" & yusr & "'"
        xcmd = New SqlCommand(xsql, scnn)
        If scnn.State <> ConnectionState.Open Then
            scnn.Open()
        End If
        xcmd.ExecuteNonQuery()
        scnn.Close()
    End Sub
    Sub chkpwd()
        MSG1.Text = ""
        Session("USR_ID") = ""
        Session("USR_NME") = ""
        Session("USR_GRP") = ""
        Session("USR_GRP_DES") = ""
        If MyPassword.Text <> "" Then
            xchk_pwd = "N"
            MSG1.Text = ""
            Dim SQL As String = _
                   "SELECT PWD,name,grp,GRP_DES FROM HR_ID WHERE EMPLID = '" & MyLogin.Text & "' "

            Dim scnn As New SqlConnection(scn_sql)
            Dim scmd As New SqlCommand(SQL, scnn)
            Dim sda1 As SqlDataReader
            Dim XPWD As String
            Dim XNME As String
            Dim XGRP As String
            Dim XGRP_DES As String
            If scnn.State <> ConnectionState.Open Then
                scnn.Open()
            End If
            sda1 = scmd.ExecuteReader
            If sda1.Read Then
                Try
                    XPWD = sda1.Item("PWD")
                    XNME = sda1.Item("NAME")
                    XGRP = sda1.Item("GRP")
                    XGRP_DES = sda1.Item("GRP_DES")
                Catch EX As Exception
                    MSG1.Text = EX.Message
                End Try
                sda1.Close()
                scnn.Close()

                If Trim(XNME) <> "" Then
                    If Trim(XPWD) = Trim(MyPassword.Text) Then
                        Session("USR_ID") = MyLogin.Text
                        Session("USR_NME") = XNME
                        Session("USR_GRP") = XGRP
                        Session("USR_GRP_DES") = XGRP_DES
                        xchk_pwd = "Y"
                    ElseIf Trim(XPWD) = "0" Then
                        Session("USR_ID") = MyLogin.Text
                        Session("USR_NME") = XNME
                        Session("USR_GRP") = XGRP
                        Session("USR_GRP_DES") = XGRP_DES
                        updpwd(MyLogin.Text, MyPassword.Text)
                        xchk_pwd = "Y"
                    Else
                        MSG1.Text = "KHUN " & XNME & " Invalid Password  , Please try again"
                    End If
                Else
                    MSG1.Text = " Invalid User ID  , Please try again"
                End If
            Else
                MSG1.Text = " Invalid User ID  , Please try again"
            End If
        Else
            MSG1.Text = "Password cannot be blank"
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If MyLogin.Text = "" Then
            MyLogin.Text = "0"
        End If
        If MyPassword.Text = "" Then
            MyPassword.Text = "0"
        End If
        Session("USR_ID") = ""
        Session("USR_NME") = ""
        Session("USR_GRP") = ""
        Session("USR_GRP_DES") = ""
        Response.Redirect(CType(Session("LOG_NO"), String))
    End Sub

    Private Sub chg_pwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chg_pwd.Click
        chkpwd()
        If xchk_pwd = "Y" Then
            XNEW_PWD.Visible = True
            New_Pwd.Visible = True
            XNEW_PWD.Text = "New Password"
            BSVE_Pwd.Visible = True
        End If
    End Sub

    Private Sub BSVE_Pwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSVE_Pwd.Click
        MSG1.Text = ""
        If New_Pwd.Text <> "" Then
            updpwd(MyLogin.Text, New_Pwd.Text)
            MSG1.Text = "Password has been Changed successfully"
            XNEW_PWD.Visible = False
            New_Pwd.Visible = False
            BSVE_Pwd.Visible = False
        Else
            MSG1.Text = "Invalid New password"
        End If
    End Sub
End Class
