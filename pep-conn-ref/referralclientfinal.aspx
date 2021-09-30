<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referralclientfinal.aspx.vb" Inherits="pep_conn_ref.referralclientfinal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="bodytext" width="100%">
						<tr>
							<td><asp:label id="lblUser" runat="server" Height="5px">Label</asp:label></td>
						</tr>
						<tr>
							<td><table width="100%">
									<tr>
										<td width="80%">&nbsp;</td>
										<td align="right"><asp:literal id="LblTopLink" runat="server"></asp:literal></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr bgColor="blue" height="2">
							<td></td>
						</tr>
						<tr>
							<td>
								<form id="frm" method="post" runat="server">
									<asp:literal id="hiddenFormList" runat="server"></asp:literal>
									<table class="bodytext" width="100%">
										<tr>
											<td colSpan="4"><asp:literal id="litFinalMsg" runat="server"></asp:literal></td>
										</tr>
										<!--tr>
											<td align="right" colSpan="4">
												&nbsp;&nbsp;<asp:Button id="SubmitMe" runat="server" class="btn" Text="Submit"></asp:Button>
					
											</td>
										</tr-->
									</table>
									<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
								</form>
							</td>
						</tr>
						<tr bgColor="blue" height="2">
							<td></td>
						</tr>
						<tr>
							<td align="right"><a class="CenterLinks" href="logoff.aspx">[Log off]</a>&nbsp;&nbsp;<a class="CenterLinks" href="Referral.aspx">[Back 
									To List]</a></td>
						</tr>
						<tr>
							<td class="ltBlue" vAlign="top" height="100%"></td>
						</tr>
					</table>
</body>
</html>
