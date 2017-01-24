<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.CRMUpl" CodeFile="CRMUpl.aspx.vb" %>
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
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<FONT face="Tahoma" size="Smaller"><INPUT id="myfile" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 680px; POSITION: absolute; TOP: 72px; HEIGHT: 22px"
					type="file" size="94" name="myfile" runat="server">
				<H5></H5>
				<H5 style="Z-INDEX: 109; LEFT: 8px; WIDTH: 152px; POSITION: absolute; TOP: 48px; HEIGHT: 24px">Select 
					File Name</H5>
				<H5 style="Z-INDEX: 110; LEFT: 8px; WIDTH: 24px; POSITION: absolute; TOP: 24px; HEIGHT: 24px">RN.</H5>
				<asp:textbox id="SRN" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 24px" runat="server"></asp:textbox><asp:label id="lblError" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 440px" runat="server"
					Font-Bold="True" Height="19px" Width="512px" Font-Names="Tahoma" ForeColor="IndianRed"></asp:label><asp:hyperlink id="lnkHome" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 0px" runat="server"
					Font-Bold="True" Height="24px" Width="112px" Font-Names="Tahoma" BackColor="#ffcc00" NavigateUrl="CRM1.aspx">Back to Main</asp:hyperlink><asp:datalist id="Gfrq" style="Z-INDEX: 100; LEFT: 136px; POSITION: absolute; TOP: 104px" runat="server"
					Height="152px" Width="688px" BackColor="LightGoldenrodYellow" Font-Size="&#9;Smaller" OndeleteCommand="DEL" GridLines="Both" ShowFooter="False" CellPadding="1" BorderWidth="1px" BorderColor="#996633">
					<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderTemplate>
						<FONT face="Tahoma">List of file Picture Upload</FONT>&nbsp;
					</HeaderTemplate>
					<AlternatingItemStyle BorderColor="Olive" BackColor="PaleGoldenrod"></AlternatingItemStyle>
					<ItemStyle Font-Names="Tahoma"></ItemStyle>
					<ItemTemplate>
						<asp:label id="Label1" runat="server" Text='<%# Container.DataItem("RN") %>' Width="100px" >
						</asp:label>
						<asp:label id="Label3" runat="server" Text='<%# Container.DataItem("CRM_TYP") %>' Width="50px" >
						</asp:label>
						<asp:label id="Label2" runat="server" Text='<%# Container.DataItem("CRM_NTE") %>' Width="450px" >
						</asp:label>
						<asp:Button Text="Delete" Runat="server" ID="Delete" Width="50px" CommandName="Delete"></asp:Button>
					</ItemTemplate>
					<HeaderStyle Font-Size="Medium" Font-Bold="True" ForeColor="White" BackColor="SaddleBrown"></HeaderStyle>
				</asp:datalist><asp:button id="BLEFT" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 104px" runat="server"
					Font-Bold="True" Height="35px" Width="120px" Font-Names="Tahoma" Text="Upload-->" Font-Size="Medium"></asp:button><asp:label id="SNME" style="Z-INDEX: 107; LEFT: 200px; POSITION: absolute; TOP: 24px" runat="server"
					Font-Bold="True" Height="24px" Width="448px" Font-Names="Tahoma"></asp:label></FONT></form>
	</body>
</HTML>
