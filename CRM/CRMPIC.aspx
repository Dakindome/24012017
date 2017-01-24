<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.CRMPIC" CodeFile="CRMPIC.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<script language="vb">
		PG1.SCROLLING = 10
		</script>
		<META http-equiv="Content-Type" content="text/html; charset=windows-874">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffcc66">
		<form id="Form1" method="post" runat="server">
			<FONT face="Tahoma" size="Smaller">
				<H5 style="Z-INDEX: 102; LEFT: 16px; WIDTH: 40px; POSITION: absolute; TOP: 8px; HEIGHT: 19px">RN
				</H5>
				<asp:textbox id="xrn" style="Z-INDEX: 101; LEFT: 48px; POSITION: absolute; TOP: 8px" runat="server"
					Width="112px"></asp:textbox><asp:button id="BFind" style="Z-INDEX: 103; LEFT: 176px; POSITION: absolute; TOP: 8px" runat="server"
					Font-Bold="True" Width="48px" Text="Find" Font-Names="Tahoma"></asp:button>
				<asp:Label id="XPIC" style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 48px" runat="server"
					Height="16px" Width="40px"></asp:Label></FONT></form>
	</body>
</HTML>
