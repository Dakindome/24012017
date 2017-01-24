<%@ Page Language="vb" AutoEventWireup="false" Inherits="CRM.CRM1" CodeFile="CRM1.aspx.vb" %>
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
				<H5 style="Z-INDEX: 106; LEFT: 384px; WIDTH: 80px; POSITION: absolute; TOP: 24px; HEIGHT: 24px">Last&nbsp;Name
				</H5>
				<H5 style="Z-INDEX: 108; LEFT: 656px; WIDTH: 112px; POSITION: absolute; TOP: 24px; HEIGHT: 32px">Total 
					Hit
					<% = Application("VCRM") %>
				</H5>
				<H5 style="Z-INDEX: 104; LEFT: 8px; WIDTH: 40px; POSITION: absolute; TOP: 24px; HEIGHT: 19px">RN
				</H5>
				<H5 style="Z-INDEX: 103; LEFT: 152px; WIDTH: 80px; POSITION: absolute; TOP: 24px; HEIGHT: 24px">First 
					Name
				</H5>
				<asp:textbox id="xrn" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 24px" runat="server"
					Width="112px"></asp:textbox><asp:textbox id="xnme" style="Z-INDEX: 100; LEFT: 224px; POSITION: absolute; TOP: 24px" runat="server"
					Width="152px"></asp:textbox><asp:textbox id="xlst_nme" style="Z-INDEX: 107; LEFT: 456px; POSITION: absolute; TOP: 24px" runat="server"
					Width="136px"></asp:textbox><asp:button id="BFind" style="Z-INDEX: 105; LEFT: 600px; POSITION: absolute; TOP: 24px" runat="server"
					Font-Bold="True" Width="48px" Text="Find" Font-Names="Tahoma"></asp:button><asp:datalist id="Gfrq" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 56px" runat="server"
					Width="768px" OnItemCommand="VST" Font-Size="&#9;Smaller" BorderColor="#996633" BorderWidth="1px" BackColor="LightGoldenrodYellow" CellPadding="1" ShowFooter="False" GridLines="Both"
					OnEditCommand="EDT" OnUpdateCommand="Uppic" OnDeleteCommand="BldGrp">
					<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderTemplate>
						<FONT face="Tahoma">Customer Relation Management</FONT>
					</HeaderTemplate>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="SaddleBrown" Font-Size="Medium"></HeaderStyle>
					<AlternatingItemStyle BorderColor="Olive" BackColor="PaleGoldenrod"></AlternatingItemStyle>
					<ItemStyle Font-Names="Tahoma"></ItemStyle>
					<ItemTemplate>
						<asp:label id="PAPMI_NO" runat="server" Text='<%# Container.DataItem("PAPMI_NO") %>' Width="105px" >
						</asp:label>
						<asp:label id="NME" runat="server" Text='<%# Container. DataItem("NME") %>' Width="650px" BackColor=#ffcc99 Font-Size="Medium">
						</asp:label>
						<TABLE style="FONT-WEIGHT: bold; FONT-SIZE: x-small; FONT-FAMILY: Tahoma">
							<tr>
								<td bgcolor="Coral">
									<asp:label id="Label17" runat="server" Text='<%# Container.DataItem("STATUS") %>' Font-Size="Medium" >
									</asp:label>
								</td>
								<td bgcolor="Gold">
									<asp:label id="Label23" runat="server" Text='Total Visit ' Width="110px"></asp:label>
									<asp:label id="Label20" runat="server" Text='<%# Container.DataItem("TOT_VST") %>' >
									</asp:label><br>
									<asp:label id="Label24" runat="server" Text='Admission' Width="110px"></asp:label>
									<asp:label id="Label21" runat="server" Text='<%# Container.DataItem("IPD_VST") %>' >
									</asp:label><br>
									<asp:label id="Label25" runat="server" Text=' Amount OPD' Width="110px"></asp:label>
									<asp:label id="Label22" runat="server" Font-Size="Medium" Text='<%# Container.DataItem("NET_OPD") %>' BackColor="Coral">
									</asp:label><br>
									<asp:label id="Label7" runat="server" Text=' Amount IPD' Width="110px"></asp:label>
									<asp:label id="Label27" runat="server" Font-Size="Medium" Text='<%# Container.DataItem("NET_IPD") %>' BackColor=#00cc99>
									</asp:label>
								</td>
								<td>
									<asp:Image ID="Img1" Runat="server" ImageAlign="Middle" ImageUrl='<%# String.Format("http://tsv/CRM/pic/{0}.jpg", Container.dataitem("PAPMI_NO") )%>' BorderColor=Coral BorderWidth="1px">
									</asp:Image>
								</td>
							</tr>
						</TABLE>
						<asp:label id="Label6" runat="server" Text='Age ' Width="105px"></asp:label>
						<asp:label id="Label3" runat="server" Text= '<%# Container.DataItem("AGE")  %>' >
						</asp:label>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="Label5" runat="server" Text= '<%# String.format("  Birth Date  {0:d} ", Container.DataItem("PAPMI_DOB") ) %>' >
						</asp:label>
						&nbsp; &nbsp;&nbsp;&nbsp;Nation
						<asp:label id="Label16" runat="server" Text= '<%# Container.DataItem("CTNAT_DESC") %>' >
						</asp:label>
						<br>
						<asp:label id="Label8" runat="server" Text='Address ' Width="105px"></asp:label>
						<asp:label id="Label9" runat="server" Text= '<%# Container.DataItem("PAPER_STNAMELINE1") %>' Width="650px">
						</asp:label>
						<asp:label id="Label4" runat="server" Text=' ' Width="105px"></asp:label>
						<asp:label id="Label10" runat="server" Text= '<%# Container.DataItem("CITAREA_DESC") %>' >
						</asp:label>&nbsp; &nbsp;&nbsp;
						<asp:label id="Label11" runat="server" Text= '<%# Container.DataItem("CTCIT_DESC") %>' >
						</asp:label>&nbsp; &nbsp;&nbsp;
						<asp:label id="Label2" runat="server" Text= '<%# Container.DataItem("PROV_DESC") %>' >
						</asp:label>&nbsp; &nbsp;&nbsp;
						<asp:label id="Label12" runat="server" Text= '<%# Container.DataItem("CTZIP_CODE") %>' >
						</asp:label>
						<br>
						<asp:label id="Label13" runat="server" Text='Tel Home ' Width="105px"></asp:label>
						<asp:label id="Label14" runat="server" Text= '<%# Container.DataItem("PAPER_TELH") %>' >
						</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;Tel Office
						<asp:label id="Label15" runat="server" Text= '<%# Container.DataItem("PAPER_TELO") %>' >
						</asp:label><br>
						<asp:label id="Label19" runat="server" Text='Alert' Width="101px"></asp:label>
						<asp:label id="Label18" runat="server" Text='<%# Container.DataItem("MSG") %>' Width="650px">
						</asp:label>
						<asp:label id="Label1" runat="server" Text='<%# Container.DataItem("HAB") %>' >
						</asp:label>
						<br>
						<asp:Button Text="Edit" Runat="server" ID="Edit" Width="105px" CommandName="Edit"></asp:Button>
						<asp:Button Text="Visit History" Runat="server" ID="Visit" Width="105px" CommandArgument='<%# Container.DataItem("PAPMI_NO") %>' >
						</asp:Button>
						<asp:Button Text="Upload Pic" Runat="server" ID="Upload" CommandName="Update" Width="105px" CommandArgument='<%# Container.DataItem("PAPMI_NO") %>' >
						</asp:Button>
						<asp:Button Text="BloodGroup" Runat="server" ID="BloodGroup" CommandName="Delete" Width="105px" CommandArgument='<%# Container.DataItem("PAPMI_NO") %>' >
						</asp:Button>
						<asp:label id="Label26" runat="server" Text='<%# Container.DataItem("VST") %>' >
						</asp:label>
					</ItemTemplate>
				</asp:datalist><asp:hyperlink id="Hyperlink1" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 0px" runat="server"
					Height="24px" NavigateUrl="XSLE.aspx" Font-Bold="True" Width="120px">CrossSale</asp:hyperlink><asp:hyperlink id="Hyperlink2" style="Z-INDEX: 111; LEFT: 152px; POSITION: absolute; TOP: 0px"
					runat="server" Height="24px" NavigateUrl="/crm/crmadr.aspx" Font-Bold="True" Width="208px">Audience By Address</asp:hyperlink></FONT></form>
	</body>
</HTML>
