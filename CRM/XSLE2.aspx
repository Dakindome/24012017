<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.XSLE2" culture="en-GB" CodeFile="XSLE2.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>XSLE2 CrossSale2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffcc99">
		<form id="Form1" method="post" runat="server">
			<font style="FONT-WEIGHT: bold; FONT-SIZE: smaller; FONT-FAMILY: Tahoma">
				<H5 style="Z-INDEX: 100; LEFT: 56px; WIDTH: 24px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 0px; HEIGHT: 19px">RN
				</H5>
				<asp:textbox id="XTEL_NTE" style="Z-INDEX: 132; LEFT: 96px; POSITION: absolute; TOP: 200px" runat="server"
					Height="32px" Width="496px"></asp:textbox>
				<H5 style="Z-INDEX: 131; LEFT: 16px; WIDTH: 40px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 200px; HEIGHT: 32px">
					<P>Telephone<BR>
						Note</P>
				</H5>
				<asp:textbox id="Textbox1" style="Z-INDEX: 119; LEFT: 64px; POSITION: absolute; TOP: 120px" runat="server"
					Height="72px" Width="528px"></asp:textbox>
				<asp:label id="XTEL" style="Z-INDEX: 130; LEFT: 496px; POSITION: absolute; TOP: 72px" runat="server"
					Height="16px" Width="288px" BackColor="#FFFFC0"></asp:label>
				<asp:label id="XSTS" style="Z-INDEX: 129; LEFT: 96px; POSITION: absolute; TOP: 48px" runat="server"
					BackColor="#FFFFC0" Width="40px" Height="16px"></asp:label>
				<H5 style="Z-INDEX: 128; LEFT: 24px; WIDTH: 72px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 48px; HEIGHT: 16px">Status</H5>
				<asp:label id="XUSR_NME" style="Z-INDEX: 127; LEFT: 240px; POSITION: absolute; TOP: 48px" runat="server"
					BackColor="#FFFFC0" Width="265px" Height="16px"></asp:label><asp:label id="XX_BY" style="Z-INDEX: 126; LEFT: 96px; POSITION: absolute; TOP: 72px" runat="server"
					BackColor="#FFFFC0" Width="112px" Height="16px"></asp:label><asp:label id="RSL" style="Z-INDEX: 125; LEFT: 96px; POSITION: absolute; TOP: 96px" runat="server"
					BackColor="#FFFFC0" Width="112px" Height="16px"></asp:label>
				<H5 style="Z-INDEX: 124; LEFT: 24px; WIDTH: 72px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 96px; HEIGHT: 16px">Result</H5>
				<H5 style="Z-INDEX: 123; LEFT: 240px; WIDTH: 48px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 96px; HEIGHT: 24px">Upd_By</H5>
				<asp:label id="UPD_BY" style="Z-INDEX: 122; LEFT: 304px; POSITION: absolute; TOP: 96px" runat="server"
					BackColor="#FFFFC0" Width="112px" Height="16px"></asp:label><asp:textbox id="nte" style="Z-INDEX: 120; LEFT: 64px; POSITION: absolute; TOP: 120px" runat="server"
					Width="528px" Height="72px"></asp:textbox>
				<H5 style="Z-INDEX: 118; LEFT: 24px; WIDTH: 40px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 120px; HEIGHT: 32px">Note</H5>
				<asp:dropdownlist id="DTO_LOC" style="Z-INDEX: 117; LEFT: 448px; POSITION: absolute; TOP: 24px" runat="server"
					Width="184px" Height="75px" Font-Names="Tahoma" Font-Bold="True" Font-Size="X-Small">
					<asp:ListItem Value="M">Med</asp:ListItem>
					<asp:ListItem Value="S">Sur</asp:ListItem>
				</asp:dropdownlist>
				<H5 style="Z-INDEX: 116; LEFT: 144px; WIDTH: 80px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 32px; HEIGHT: 16px">From 
					Loc</H5>
				<asp:button id="BExit" style="Z-INDEX: 113; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
					BackColor="Peru" Width="48px" Font-Names="Tahoma" Font-Bold="True" ForeColor="White" EnableViewState="False"
					Text="Exit"></asp:button>
				<H5 style="Z-INDEX: 110; LEFT: 240px; WIDTH: 48px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 72px; HEIGHT: 24px">Upd_Date</H5>
				<asp:label id="upd_dte" style="Z-INDEX: 109; LEFT: 304px; POSITION: absolute; TOP: 72px" runat="server"
					BackColor="#FFFFC0" Width="176px" Height="16px"></asp:label><asp:label id="NME" style="Z-INDEX: 108; LEFT: 200px; POSITION: absolute; TOP: 0px" runat="server"
					BackColor="#FFFFC0" Width="361px" Height="16px" Font-Size="Small"></asp:label><asp:textbox id="DTE" style="Z-INDEX: 106; LEFT: 40px; POSITION: absolute; TOP: 24px" runat="server"
					Width="96px" Height="24px"></asp:textbox>
				<H5 style="Z-INDEX: 105; LEFT: 24px; WIDTH: 72px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 72px; HEIGHT: 16px">XSale 
					By</H5>
				<H5 style="Z-INDEX: 103; LEFT: 400px; WIDTH: 56px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 32px; HEIGHT: 16px">To 
					Loc</H5>
				<asp:button id="BSave" style="Z-INDEX: 102; LEFT: 624px; POSITION: absolute; TOP: 0px" runat="server"
					BackColor="Peru" Width="48px" Font-Names="Tahoma" Font-Bold="True" ForeColor="White" Text="Save"></asp:button><asp:button id="BFind" style="Z-INDEX: 101; LEFT: 568px; POSITION: absolute; TOP: 0px" runat="server"
					BackColor="BurlyWood" Width="48px" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" Text="Find"></asp:button>
				<H5 style="Z-INDEX: 104; LEFT: 8px; WIDTH: 24px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 32px; HEIGHT: 19px">Date</H5>
				<asp:label id="RN" style="Z-INDEX: 107; LEFT: 80px; POSITION: absolute; TOP: 0px" runat="server"
					BackColor="#FFFFC0" Width="112px" Height="16px"></asp:label><asp:label id="Rowid" style="Z-INDEX: 111; LEFT: 728px; POSITION: absolute; TOP: 0px" runat="server"
					BackColor="#FFFFC0" Width="57px" Height="16px"></asp:label>
				<H5 style="Z-INDEX: 112; LEFT: 680px; WIDTH: 48px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 0px; HEIGHT: 24px">Rowid</H5>
				<asp:dropdownlist id="DFRM_LOC" style="Z-INDEX: 115; LEFT: 208px; POSITION: absolute; TOP: 24px" runat="server"
					Width="185px" Height="75px" Font-Names="Tahoma" Font-Bold="True" Font-Size="X-Small">
					<asp:ListItem Value="M">Med</asp:ListItem>
					<asp:ListItem Value="S">Sur</asp:ListItem>
					<asp:ListItem Value="O">Obg</asp:ListItem>
					<asp:ListItem Value="P">Ped</asp:ListItem>
				</asp:dropdownlist><asp:label id="xmsg" style="Z-INDEX: 114; LEFT: 24px; POSITION: absolute; TOP: 248px" runat="server"
					Width="648px" Height="72px"></asp:label></font></form>
	</body>
</HTML>
