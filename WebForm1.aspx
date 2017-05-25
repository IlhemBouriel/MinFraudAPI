<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="MinFraudAPI.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td colSpan="2">Test Page for MinFraud C#/ASP.NET Wrapper API</td>
				</tr>
				<tr>
					<td style="WIDTH: 182px">&nbsp;</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="2"><asp:label id="Label1" runat="server" Font-Size="Medium" Font-Bold="True">Required Fields</asp:label></td>
				</tr>
				<tr>
					<td style="WIDTH: 182px">&nbsp;</td>
					<td></td>
				</tr>
				<TR>
					<TD style="WIDTH: 182px">IP</TD>
					<TD><asp:textbox id="txtIP" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">City</TD>
					<TD><asp:textbox id="txtCity" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">State</TD>
					<TD><asp:textbox id="txtState" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">Zip</TD>
					<TD><asp:textbox id="txtZip" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">Country</TD>
					<TD><asp:textbox id="txtCountry" runat="server"></asp:textbox></TD>
				</TR>
				<tr>
					<td style="WIDTH: 182px">&nbsp;</td>
					<td></td>
				</tr>
				<TR>
					<td colSpan="2"><asp:label id="Label2" runat="server" Font-Size="Medium" Font-Bold="True">Optional Fields</asp:label></td>
				</TR>
				<tr>
					<td style="WIDTH: 182px">&nbsp;</td>
					<td></td>
				</tr>
				<TR>
					<TD style="WIDTH: 182px">Email</TD>
					<TD><asp:textbox id="txtEmail" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">Phone Number</TD>
					<TD><asp:textbox id="txtPhone" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">CC Bin</TD>
					<TD><asp:textbox id="txtBin" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 182px">&nbsp;</TD>
					<TD align="left"><asp:button id="btnCheck" runat="server" Text="Check"></asp:button></TD>
				</TR>
				<tr>
					<td colspan="2" style="WIDTH: 182px" align="left">
						<asp:Label id="Label3" runat="server" Font-Size="Medium" Font-Bold="True">Fraud Results</asp:Label></td>
				</tr>
				<tr>
					<td style="WIDTH: 182px">Accept:</td>
					<td>
						<asp:Label id="lblSafe" runat="server" Font-Bold="True"></asp:Label></td>
				</tr>
				<tr>
					<td style="WIDTH: 182px">Fraud Score:</td>
					<td>
						<asp:Label id="lblScore" runat="server" Font-Bold="True"></asp:Label></td>
				</tr>
				<tr>
					<td style="WIDTH: 182px">Return Params</td>
					<td>
						<asp:Label id="lblResults" runat="server"></asp:Label></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
