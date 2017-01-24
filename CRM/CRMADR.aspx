<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.CRMADR" culture="en-GB" smartnavigation="True" CodeFile="CRMADR.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CRMADR CrossSale</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffffcc">
		<form id="Form1" method="post" runat="server">
			<asp:button id="BName" style="Z-INDEX: 109; LEFT: 560px; POSITION: absolute; TOP: 24px" runat="server"
				Width="88px" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="BurlyWood"
				Text="ShowName"></asp:button>
			<H5 style="FONT-SIZE: larger; Z-INDEX: 108; LEFT: 16px; WIDTH: 176px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 0px; HEIGHT: 24px">Patient 
				By Address</H5>
			<H5 style="Z-INDEX: 107; LEFT: 16px; WIDTH: 168px; FONT-FAMILY: tahoma; POSITION: absolute; TOP: 24px; HEIGHT: 32px">Search 
				Matching Part of Address&nbsp;
			</H5>
			<asp:textbox id="XADR" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 24px" runat="server"
				Width="289px"></asp:textbox><asp:label id="xmsg" style="Z-INDEX: 105; LEFT: 200px; POSITION: absolute; TOP: 0px" runat="server"
				Width="570px" Font-Size="Smaller" Height="24px" Font-Names="Tahoma" Font-Bold="True"></asp:label><asp:button id="BFind" style="Z-INDEX: 103; LEFT: 496px; POSITION: absolute; TOP: 24px" runat="server"
				Width="48px" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="BurlyWood" Text="Find"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 56px" runat="server"
				Width="98%" Font-Size="Smaller" Height="112px" Font-Names="Tahoma" ForeColor="Black" BackColor="LightGoldenrodYellow" OnDeleteCommand="DEL" OnEditCommand="DTL" CellPadding="2" BorderWidth="1px" BorderColor="Tan"
				AutoGenerateColumns="False">
				<FooterStyle BackColor="Tan"></FooterStyle>
				<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
				<ItemStyle Wrap="False"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
				<Columns>
					<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="RN" DataNavigateUrlFormatString="CRM1.aspx?RN={0}"
						DataTextField="RN" HeaderText="HN"></asp:HyperLinkColumn>
					<asp:ButtonColumn Text="Mark" CommandName="Edit"></asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="XPT_NME" ReadOnly="True" HeaderText="Name"></asp:BoundColumn>
					<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="PAPER_StNameLine1" ReadOnly="True" HeaderText="Address"></asp:BoundColumn>
					<asp:BoundColumn DataField="PAPER_Dob" ReadOnly="True" HeaderText="DOB" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
					<asp:BoundColumn DataField="AGE" ReadOnly="True" HeaderText="Age"></asp:BoundColumn>
					<asp:BoundColumn DataField="CTNAT_DESC" ReadOnly="True" HeaderText="Nation"></asp:BoundColumn>
					<asp:BoundColumn DataField="CTSEX_Desc" ReadOnly="True" HeaderText="Sex"></asp:BoundColumn>
					<asp:BoundColumn DataField="CITAREA_Desc" HeaderText="Area"></asp:BoundColumn>
					<asp:BoundColumn DataField="CTCIT_Desc" HeaderText="City"></asp:BoundColumn>
					<asp:BoundColumn DataField="PROV_Desc" HeaderText="Province"></asp:BoundColumn>
					<asp:BoundColumn DataField="CTZIP_Code" HeaderText="Zip"></asp:BoundColumn>
					<asp:BoundColumn DataField="Email" ReadOnly="True" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="paper_telh" ReadOnly="True" HeaderText="Tel Home"></asp:BoundColumn>
					<asp:BoundColumn DataField="paper_telO" ReadOnly="True" HeaderText="Tel Office"></asp:BoundColumn>
					<asp:BoundColumn DataField="CTMAR_Desc" ReadOnly="True" HeaderText="Marital Status"></asp:BoundColumn>
					<asp:BoundColumn DataField="PAPMI_Deceased" ReadOnly="True" HeaderText="Deceased"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
