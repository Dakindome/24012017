<%@ Page %>
<%@import namespace="system.data" %>
<%@import namespace="system.data.oledb" %>
<HTML>
	<HEAD>
		<script runat="server">
Sub update_db(id As Integer , filename As String )
	Dim conn As New oledbconnection("provider=Microsoft.jet.oledb.4.0;data source=" & server.mappath("member.mdb") & ";Jet oledb:database password=member007;")
	conn.open
	Dim sqlstr As String = "update member set picture='" & filename & "' where id=" & id
	Dim cmd As New oledbcommand(sqlstr, conn)
	cmd.executenonquery()
	conn.close
End Sub 
	Sub upload_file(o As object, e As EventArgs )
		If Not (myfile.postedfile Is nothing ) then
			Dim filenamelength As integer
			Dim filepath As string
			Dim filename As string
			Dim id As Integer = 1
			filepath= myfile.postedfile.filename
			filenamelength = instr(1, strreverse(filepath), "\")
			filename = mid(filepath, (len(filepath) - filenamelength)+2)
			myfile.postedfile.saveas(server.mappath("images") & "\" & filename)
			update_db(id, filename)
			displaymsg.text = "File Upload Success."
		'	displaymsg.text = filename

		End if
	End Sub 
		</script>
	</HEAD>
	<body>
		<Form enctype="multipart/form-data" runat="server">
			Choose File:&nbsp; <Input id="myfile" type="file" runat="server">
			<br>
			<Input type="button" value="upload" onserverclick="upload_file" runat="server" id="Button1"
				name="Button1"><br>
			<asp:Label id="displaymsg" runat="server" />
		</Form>
	</body>
</HTML>
