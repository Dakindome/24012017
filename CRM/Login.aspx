<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.Login" CodeFile="Login.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style>.beige { BACKGROUND-COLOR: beige }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<font style="FONT-WEIGHT: bold" face="Tahoma">
				<table style="FONT: 10pt Tahoma; WIDTH: 278px; HEIGHT: 160px; BACKGROUND-COLOR: tan" cellSpacing="10">
					<tr>
						<td style="WIDTH: 72px"><b>Login: </b>
						</td>
						<td style="FONT-WEIGHT: bold">011-
							<ASP:TEXTBOX id="MyLogin" style="FONT-WEIGHT: 700" runat="server" Width="120px" Font-Bold="True">0</ASP:TEXTBOX><asp:requiredfieldvalidator id="RQFV2" runat="server" Display="Dynamic" ControlToValidate="MyLogin" ErrorMessage="User ID cannot be blank"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 72px"><b>Password: </b>
						</td>
						<td><ASP:TEXTBOX id="MyPassword" runat="server" Font-Bold="True" TextMode="Password"></ASP:TEXTBOX></td>
					</tr>
					<tr>
						<td style="WIDTH: 72px">&nbsp;</td>
						<td><ASP:BUTTON id="MySubmit" runat="server" Font-Bold="True" Text="   OK   "></ASP:BUTTON>&nbsp;&nbsp;
							<ASP:BUTTON id="Cancel" runat="server" Font-Bold="True" Text="Cancel"></ASP:BUTTON></td>
					</tr>
					<tr>
						<td></td>
						<td><asp:button id="chg_pwd" runat="server" Width="144px" Font-Bold="True" Text="Change Password"></asp:button></td>
					</tr>
					<tr>
						<td style="WIDTH: 72px"><ASP:LABEL id="XNEW_PWD" runat="server" Font-Bold="True" Visible="False" BackColor="#C00000"
								ForeColor="White"></ASP:LABEL></td>
						<td><ASP:TEXTBOX id="New_Pwd" runat="server" Font-Bold="True" Visible="False" cssclass="beige"></ASP:TEXTBOX></td>
					</tr>
					<tr>
						<td></td>
						<td><asp:button id="BSVE_Pwd" runat="server" Width="144px" Font-Bold="True" Text="Save New Password"
								Visible="False"></asp:button></td>
					</tr>
					<tr>
						<td colSpan="2"><ASP:LABEL id="MSG1" runat="server" Font-Bold="True" BackColor="#C00000" ForeColor="White"></ASP:LABEL></td>
					</tr>
				</table>
			</font>
		</form>
		<P><FONT face="Tahoma"></FONT></P>
	</body>
</HTML>
