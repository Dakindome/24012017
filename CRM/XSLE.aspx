<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.XSLE" culture="en-GB" CodeFile="XSLE.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>XSLE CrossSale</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffffcc">
		<form id="Form1" method="post" runat="server">
			<H5 style="Z-INDEX: 100; LEFT: 16px; WIDTH: 24px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 24px; HEIGHT: 19px">HN
			</H5>
			<H5 style="Z-INDEX: 119; LEFT: 440px; WIDTH: 24px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 48px; HEIGHT: 19px">Status</H5>
			<asp:textbox id="TDTE" style="Z-INDEX: 117; LEFT: 448px; POSITION: absolute; TOP: 24px" runat="server"
				Width="120px"></asp:textbox>
			<H5 style="Z-INDEX: 116; LEFT: 384px; WIDTH: 24px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 24px; HEIGHT: 19px">Date&nbsp;To</H5>
			<H5 style="Z-INDEX: 110; LEFT: 16px; WIDTH: 64px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 48px; HEIGHT: 24px">From 
				Loc</H5>
			<asp:textbox id="XFRM_LOC" style="Z-INDEX: 109; LEFT: 80px; POSITION: absolute; TOP: 48px" runat="server"
				Width="64px"></asp:textbox>
			<H5 style="FONT-SIZE: larger; Z-INDEX: 108; LEFT: 16px; WIDTH: 160px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 0px; HEIGHT: 22px">Cross 
				Sale Entry</H5>
			<H5 style="Z-INDEX: 107; LEFT: 168px; WIDTH: 24px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 24px; HEIGHT: 19px">Date&nbsp;From&nbsp;
			</H5>
			<asp:textbox id="FDTE" style="Z-INDEX: 106; LEFT: 248px; POSITION: absolute; TOP: 24px" runat="server"
				Width="120px"></asp:textbox><asp:label id="xmsg" style="Z-INDEX: 105; LEFT: 296px; POSITION: absolute; TOP: 0px" runat="server"
				Width="473px" Font-Size="Smaller" Height="24px" Font-Names="Tahoma" Font-Bold="True"></asp:label><asp:button id="BNew" style="Z-INDEX: 104; LEFT: 192px; POSITION: absolute; TOP: 0px" runat="server"
				Width="88px" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="BurlyWood" Text="Add New"></asp:button><asp:textbox id="xrn" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 24px" runat="server"
				Width="120px"></asp:textbox><asp:button id="BFind" style="Z-INDEX: 102; LEFT: 568px; POSITION: absolute; TOP: 48px" runat="server"
				Width="56px" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="BurlyWood" Text="Find"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 80px" runat="server"
				Width="98%" Font-Size="Smaller" Height="112px" Font-Names="Tahoma" ForeColor="Black" BackColor="LightGoldenrodYellow" DataKeyField="ROWID" OnDeleteCommand="DEL" OnEditCommand="DTL" GridLines="None" CellPadding="2"
				BorderWidth="1px" BorderColor="Tan" AutoGenerateColumns="False">
				<FooterStyle BackColor="Tan"></FooterStyle>
				<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
				<ItemStyle Wrap="False"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Edit" CommandName="Edit"></asp:ButtonColumn>
					<asp:BoundColumn DataField="rn" ReadOnly="True" HeaderText="RN"></asp:BoundColumn>
					<asp:BoundColumn DataField="dte" ReadOnly="True" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
					<asp:BoundColumn DataField="nme" ReadOnly="True" HeaderText="Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="STS" ReadOnly="True" HeaderText="Status"></asp:BoundColumn>
					<asp:BoundColumn DataField="X_BY" ReadOnly="True" HeaderText="XSale By"></asp:BoundColumn>
					<asp:BoundColumn DataField="FRM_LOC" HeaderText="From Loc"></asp:BoundColumn>
					<asp:BoundColumn DataField="TO_LOC" HeaderText="To Loc"></asp:BoundColumn>
					<asp:BoundColumn DataField="RSL" HeaderText="Result"></asp:BoundColumn>
					<asp:BoundColumn DataField="Nte" ReadOnly="True" HeaderText="Note"></asp:BoundColumn>
					<asp:BoundColumn DataField="TEL" HeaderText="Tel"></asp:BoundColumn>
					<asp:BoundColumn DataField="TEL_NTE" HeaderText="Tel Note"></asp:BoundColumn>
					<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="UPD_DTE" HeaderText="Upd Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="UPD_BY" ReadOnly="True" HeaderText="Upd By"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
			</asp:datagrid>
			<asp:textbox id="XTO_LOC" style="Z-INDEX: 111; LEFT: 200px; POSITION: absolute; TOP: 48px" runat="server"
				Width="64px"></asp:textbox>
			<H5 style="Z-INDEX: 112; LEFT: 152px; WIDTH: 48px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 48px; HEIGHT: 24px">To 
				Loc</H5>
			<asp:textbox id="XX_BY" style="Z-INDEX: 113; LEFT: 336px; POSITION: absolute; TOP: 48px" runat="server"
				Width="96px"></asp:textbox>
			<H5 style="Z-INDEX: 114; LEFT: 272px; WIDTH: 64px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 48px; HEIGHT: 24px">XSale 
				By</H5>
			<asp:DropDownList id="DDLSTS" style="Z-INDEX: 118; LEFT: 488px; POSITION: absolute; TOP: 48px" runat="server"
				AutoPostBack="True">
				<asp:ListItem Value="S">Success</asp:ListItem>
				<asp:ListItem Value="A">Active</asp:ListItem>
				<asp:ListItem Value="E">Expired</asp:ListItem>
				<asp:ListItem Value="%" Selected="True">All</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
