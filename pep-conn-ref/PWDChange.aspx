<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PWDChange.aspx.vb" Inherits="pep_conn_ref.PWDChange" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
            <title>PEP Referral</title>
            <link rel="icon" type="image/png" href="/images/pep_apple.png">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
		    <link rel="stylesheet" href="style/all.min.css">
            <!-- Bootstrap -->
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
            
    </head>
 
    <body> 
            <!-- Navbar -->
                <nav class="main-header navbar navbar-expand">
                    
                        <!-- Brand Logo -->
                        <div class="logo-container">
                            <a href="index.aspx" class="brand-link">
                                <img src="images/peplogo2.jpg" alt="PEP Logo" class="logo-image elevation-3">
                            </a>
                        </div>
                        
                        <div class="header-container">
                            <div class="title-panel">
                                <h2>PEP Referral System</h2>
                            </div>
                            
                            <div class="user-panel">
                                <asp:label id="lblUser" runat="server" data-bs-toggle="dropdown" role="button" CssClass="dropdown-toggle"></asp:label>
                                <ul class="dropdown-menu account-dropdown" aria-labelledby="lblUser">
                                  <a class="dropdown-item active" href="/profile.aspx">Profile</a>
                                  <a class="dropdown-item" href="/profilepassword.aspx">Password</a>
                                  <a class="dropdown-item" href="/profileagency.aspx">Agency</a>
                                </ul>
                                <asp:Panel ID="loginPanel" runat="server" class="login-link">
                                    <a href="/onlinereferral.aspx" class="user-login">Log In</a>
                                </asp:Panel>
                                <asp:Panel ID="logoutPanel" runat="server" class="login-link">
                                    <a href="/onlinereferral.aspx" class="user-login">Log Out</a>
                                </asp:Panel>
                    
                         </div>
                            <div class="menu-panel">
                                
                            </div>
                        </div>
                </nav>
            <!-- / Navbar -->

        <div class="wrapper">

		        <!-- Main Sidebar Container -->
                    <aside class="main-sidebar sidebar-dark-primary elevation-4">

                        <!-- Sidebar -->
                        <div class="sidebar">
                        
		                     <!-- Sidebar Menu -->
                            <nav class="nav-sidebar">
                               <ul class="sidebar-list" role="menu" data-accordion="false">
                                    <li class="nav-item">
                                        <a href="/index.aspx" class="nav-link">
                                            <p>Connections Home</p>
                                        </a>
                                    </li>
                                   <%-- <li class="nav-item">
                                        <a href="#" class="nav-link">
                                            <p>Latest News</p>
                                        </a>
                                    </li>--%>
                                    <li class="nav-item">
                                        <a href="/admissioncriteria.aspx" class="nav-link">
                                            <p>Admission Criteria</p>
                                        </a>
                                    </li>
                                    <%--<li class="nav-item">
                                        <a href="/staff.aspx" class="nav-link">
                                            <p>Staff</p>
                                        </a>
                                    </li>--%>
                                    <li class="nav-item">
                                        <a href="/onlinereferral.aspx" class="nav-link">
                                            <p>Online Referral</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/contact.aspx" class="nav-link">
                                            <p>Contact Us</p>
                                        </a>
                                    </li>
                                </ul>
                            </nav>
                            <!-- /Sidebar-menu -->
                        </div>
                        <!-- /Sidebar -->
                    </aside>

            <section class="main-content">
                <div class="main-text">
                   
                    <table height="7" cellSpacing="0" cellPadding="0" width="772" border="0">
			<tbody>
				<tr>
					<td class="gray1" colSpan="2" height="1"><IMG height="1" src="images/pixel.gif" width="1"></td>
				</tr>
				<tr>
					<td class="gray2" align="left" height="7"><IMG height="7" src="images/arrows.gif" width="16"></td>
					<td class="gray2" align="right"><IMG height="7" src="images/circles.gif" width="31"></td>
				</tr>
				<tr>
					<td class="gray3" colSpan="2" height="1"><IMG height="1" src="images/pixel.gif" width="1"></td>
				</tr>
				<tr>
					<td colSpan="2" height="1"><IMG height="1" src="images/pixel.gif" width="1"></td>
				</tr>
			</tbody></table>
		<table cellSpacing="0" cellPadding="0" border="0">
			<tbody>
				<tr>
					<td width="160" height="53"><IMG height="53" src="images/logo.gif" width="160"></td>
					<td class="title" id="ContentCONN" align="center" width="612" background="images/titleBg1.jpg"
						height="53">&nbsp;&nbsp;PEP Referral System</td>
				</tr>
				<tr>
					<td width="160" height="9"><IMG height="10" src="images/divider_top.gif" width="160"></td>
					<td width="612" height="9"><IMG height="9" src="images/pixel.gif" width="1"></td>
				</tr>
			</tbody></table>
		<table height="90%" cellSpacing="0" cellPadding="0" border="0">
			<tbody>
				<tr>
					<td vAlign="top" width="160" background="images/sidebarBg.jpg" height="179">
						<table width="160" class="bodytext" background="images/sidebarBg.jpg">
							<tr valign="top" height="70">
								<td height="97"><asp:literal id="lblLeftLink" runat="server"></asp:literal></td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
					<td width="17" height="359" rowspan="2">&nbsp;</td>
					<td class="bodyText" vAlign="top" width="597" height="359" rowSpan="2">
						<form id="frm" method="post" runat="server">
							<table class="bodytext">
								<tr>
									<td colspan="4">
                                        <asp:Literal ID="lblContent" runat="server"></asp:Literal>
									</td>
								</tr>
								<tr bgColor="blue" height="2">
									<td colspan="4"></td>
								</tr>
								<TR bgColor="#a0b8c8">
									<TD colSpan="4"><FONT face="Arial" size="+1">Change Password</FONT></TD>
								</TR>
								<TR>
									<TD colspan="4"><FONT face="Arial" size="-1">Please enter the your user name (ID), current/temporary password and new password.</FONT>
									</TD>
								</TR>
								<tr>
									<td width="162"><STRONG></STRONG></td>
									<td align="right" width="176"><STRONG>Your User ID:&nbsp;</STRONG></td>
									<td><asp:textbox id="frmXXUID" runat="server"></asp:textbox></td>
								</tr>

											<tr><td width="162"><STRONG></STRONG></td>
												<td class="LabelLeftReq">Old/Temporary Password:</td>
												<td><asp:textbox id="frmXXOldPWD" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr><td width="162"><STRONG></STRONG></td>
												<td class="LabelLeftReq">Enter New Password:</td>
												<td><asp:textbox id="frmXXNewPWD1" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr><td width="162"><STRONG></STRONG></td>
												<td class="LabelLeftReq">Re-type Password:</td>
												<td><asp:textbox id="frmXXNewPWD2" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
                                <tr><td colspan="4"><hr /></td></tr>
                                <tr><td colspan="4">Password needs to be 8-15 characters.
                        <br />Password must conatin at least 3 out of 4 basic character groups (Upper case, lower case, number, symbol).
                        <br />Password cannot be the same as the login and cannot be re-used.</td></tr>
                                <tr><td colspan="4"><hr /></td></tr>
								<tr>
									<td align="center" colspan="4"><asp:button id="submit" runat="server" Text="change password" CssClass="btn"></asp:button></td>
								</tr>
								<tr align="left" class="error">
									<td colSpan="4" class="error">
                                        <asp:Label id="lblExpire" runat="server"></asp:Label>
										<asp:Label id="lblMsg" runat="server" ></asp:Label>&nbsp;</td>
								</tr>
							</table>
						</form>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" width="160" background="images/sidebarBg.jpg" height="179"></TD>
					<TD width="17" height="359"></TD>
					<TD class="bodyText" vAlign="top" width="597" height="359"></TD>
				</TR>
				<tr>
					<td class="ltBlue" vAlign="top" height="6"><br>
						<IMG src="images/pixel.gif" width="1"></td>
				</tr>
			</tbody></table>
		</SCRIPT>


                </div>
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.3.4/js/tether.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.3/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
</html>

