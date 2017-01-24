<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.CRM2" CodeFile="CRM2.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CRM2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="palegoldenrod">
		<form id="Form1" method="post" runat="server">
			<FONT face="Tahoma" size="Smaller">
				<asp:dropdownlist id="cboCRMH" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 24px" runat="server"
					AutoPostBack="True" Font-Names="Tahoma" Width="208px" Height="24px" Font-Bold="True"></asp:dropdownlist>
				<H5 style="Z-INDEX: 111; LEFT: 120px; WIDTH: 64px; POSITION: absolute; TOP: 0px; HEIGHT: 16px">RN</H5>
				<asp:textbox id="SRN" style="Z-INDEX: 110; LEFT: 152px; POSITION: absolute; TOP: 0px" runat="server"></asp:textbox><asp:button id="btnSave" style="Z-INDEX: 106; LEFT: 408px; POSITION: absolute; TOP: 24px" tabIndex="6"
					runat="server" Font-Names="Tahoma" Width="184px" Height="32px" Text="Save All Changes" Font-Bold="True" ForeColor="White" BackColor="#004000" Font-Size="Medium" BorderColor="LightGreen" BorderStyle="Inset"></asp:button><asp:label id="lblError" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 360px" runat="server"
					Font-Names="Tahoma" Width="512px" Height="19px" ForeColor="IndianRed" Font-Bold="True"></asp:label>
				<asp:hyperlink id="lnkHome" style="Z-INDEX: 104; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
					Font-Names="Tahoma" Width="112px" Height="24px" NavigateUrl='CRM1.aspx' BackColor="#ffcc00"
					Font-Bold="True">Back to Main</asp:hyperlink><asp:listbox id="lboCRMD" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 56px" tabIndex="5"
					runat="server" Font-Names="Tahoma" Width="208px" Height="184px" Font-Bold="True"></asp:listbox><asp:datalist id="Gfrq" style="Z-INDEX: 103; LEFT: 216px; POSITION: absolute; TOP: 56px" runat="server"
					Width="556px" Height="169px" BorderColor="#996633" BorderWidth="1px" BackColor="LightGoldenrodYellow" CellPadding="1" ShowFooter="False" GridLines="Both" OndeleteCommand="DEL" Font-Size="&#9;Smaller">
					<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderTemplate>
						<FONT face="Tahoma">Customer Relationship Management</FONT>
					</HeaderTemplate>
					<AlternatingItemStyle BorderColor="Olive" BackColor="PaleGoldenrod"></AlternatingItemStyle>
					<ItemStyle Font-Names="Tahoma"></ItemStyle>
					<ItemTemplate>
						<asp:label id="Label27" runat="server" Text='<%# Container.DataItem("CCRM_DES") %>' Width="100px" >
						</asp:label>
						<asp:label id="Label1" runat="server" Text='<%# Container.DataItem("CCRM_SUF_DES") %>' Width="250px" >
						</asp:label>
						<asp:label id="Label2" runat="server" Text='<%# Container.DataItem("CRM_NTE") %>' Width="140px" >
						</asp:label>
						<asp:Button Text="Delete" Runat="server" ID="Delete" Width="50px" CommandName="Delete"></asp:Button>
					</ItemTemplate>
					<HeaderStyle Font-Size="Medium" Font-Bold="True" ForeColor="White" BackColor="SaddleBrown"></HeaderStyle>
				</asp:datalist><asp:button id="BLEFT" style="Z-INDEX: 107; LEFT: 216px; POSITION: absolute; TOP: 24px" runat="server"
					Font-Names="Tahoma" Width="144px" Height="32px" Text="Select to --->" Font-Size="Medium" Font-Bold="True"
					ForeColor="White" BackColor="#004000" BorderColor="#00C000" BorderStyle="Inset"></asp:button><asp:textbox id="XNTE" style="Z-INDEX: 108; LEFT: 0px; POSITION: absolute; TOP: 264px" runat="server"
					Width="200px" Height="88px" TextMode="MultiLine"></asp:textbox>
				<H5 style="Z-INDEX: 109; LEFT: 8px; WIDTH: 64px; POSITION: absolute; TOP: 240px; HEIGHT: 16px">Note</H5>
				<asp:Label id="SNME" style="Z-INDEX: 112; LEFT: 312px; POSITION: absolute; TOP: 0px" runat="server"
					Font-Names="Tahoma" Width="448px" Height="24px" Font-Bold="True"></asp:Label></FONT></form>
	</body>
</HTML>
