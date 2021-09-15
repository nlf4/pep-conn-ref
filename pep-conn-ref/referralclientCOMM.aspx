<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referralclientCOMM.aspx.vb" Inherits="pep_conn_ref.referralclientCOMM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
       <title>PEP Referral</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="icon" type="image/png" href="/images/pep_apple.png">
	    <link href="../style/style.css" type="text/css" rel="stylesheet">
	    <!-- Font Awesome -->
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        <!-- Bootstrap -->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
    </head>
    <body>
        <%--<form id="form1" runat="server">--%>
            <!-- Navbar -->
                <nav class="main-header navbar navbar-expand">
                    
                        <!-- Brand Logo -->
                        <div class="logo-container">
                            <a href="index.aspx" class="brand-link">
                                <img src="images/peplogo2.jpg" alt="PEP Logo" class="logo-image elevation-3">
                            </a>
                        </div>
                        
                       <%-- <a href="#" class="brand-link">
                            &nbsp;<span class="brand-text font-weight-light" aria-autocomplete="none"></span></a>--%>
                        <div class="header-container">
                            <div class="title-panel">
                                <h2>PEP Referral System</h2>
                            </div>
                            
                            <div class="user-panel">
                                <div class="login-link">
                                    <a href="/onlinereferral.aspx" class="user-login">Log In</a>
                                </div>
                            </div>
                            <div class="menu-panel">
                                <%--<i class="fas fa-bars"></i>--%>
                                
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
                                            <!-- <i class="nav-icon fa fa-home"></i> -->
                                            <p>Connections Home</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/latestnews.aspx" class="nav-link">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
                                            <p>Latest News</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/admissioncriteria.aspx" class="nav-link active">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
                                            <p>Admission Criteria</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/staff.aspx" class="nav-link">
                                           <!-- <i class="nav-icon fas fa-th"></i>-->
                                            <p>Staff</p>
                                        </a>
                                    </li>
                                    <li class="nav-item active">
                                        <a href="#" class="nav-link">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
                                            <p>Online Referral</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/contact.aspx" class="nav-link">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
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

                <table height="7" cellSpacing="0" cellPadding="0" width="772" border="0">
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
		</table>
		<table cellSpacing="0" cellPadding="0" border="0">
			<tr>
				<td width="160" height="53"><IMG height="53" src="images/logo.gif" width="160"></td>
				<td class="title" id="ContentCONN" align="center" width="612" background="images/titleBg1.jpg"
					height="53">&nbsp;&nbsp;PEP Referral System</td>
			</tr>
			<tr>
				<td width="160" height="9"><IMG height="10" src="images/divider_top.gif" width="160"></td>
				<td width="612" height="9"><IMG height="9" src="images/pixel.gif" width="1"></td>
			</tr>
		</table>
		<table height="90%" cellSpacing="0" cellPadding="0" border="0">
			<tr>
				<td vAlign="top" width="160" background="images/sidebarBg.jpg" height="179">
					<table class="bodytext" background="images/sidebarBg.jpg">
						<tr vAlign="top" height="70">
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
				<td width="1" rowSpan="2">&nbsp;</td>
				<td class="bodyText" vAlign="top" width="597" rowSpan="2">
					<table class="bodytext" width="100%">
						<tr>
							<td><asp:label id="lblUser" runat="server" Height="5px">Label</asp:label></td>
						</tr>
						<tr>
							<td>
								<table width="100%">
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
									<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
									<table class="bodytext" width="100%">
									<tr class="LabelTop">
											<td colSpan="4"><font color="red">*</font>Referral Information</td>
										</tr>
                                        <tr><td colspan=4><table class=bodyText cellpadding=0 cellspacing=0>
                                        <tr>
                                         <td ><b>Is this a Rainbow Care Connection Referral? </b><font color="red">*</font> </td><td>
                                                <asp:radiobuttonlist id="frmXXRainbowCare"  Repeatdirection=Horizontal runat="server"  font-Size="X-Small"><asp:ListItem Value="Y">Yes</asp:ListItem><asp:ListItem Value="N">No</asp:ListItem>
												</asp:radiobuttonlist>                                     
                                         </td>
                                        </tr>
                                        </table></td>

                                        </tr>
                                        <tr>
											<td class="LabelLeftreq" nowrap><b>If Yes, PCP Name:</b>&nbsp;</td>
											<td colspan=3><asp:textbox id="frmXXPCPName" runat="server" Width="360px"></asp:textbox><font title='If Rainbow Care Referral' color="red">*</font></td>
										</tr>
                                        <tr>
											<td class="LabelLeftreq"><b>Phone:</b>&nbsp;</td>
											<td ><asp:textbox id="frmXXPCPPhone" runat="server" Width="140px"></asp:textbox><font title='If Rainbow Care Referral' color="red">*</font></td>
											<td class="LabelLeftreq">Fax:&nbsp;</td>
											<td ><asp:textbox id="frmXXPCPFax" runat="server" Width="140px"></asp:textbox><font title='If Rainbow Care Referral' color="red">*</font></td>
										</tr>

						<tr vAlign="top">
							<td align="center" colSpan="4">
								<table class="bodytext" width="100%">
	
									<tr class="labelTop">
										<td colSpan="2" align=left>If child has ever been placed out of his/her home, enter the number 
											of placements in each category below. If child has never been placed out of 
											his/her home, leave categories below blank:</td>
									</tr>
									<tr vAlign="top" align="center">
										<td colSpan="2">
											<table class="bodytext">
												<asp:literal id="litNoPlacement" runat="server"></asp:literal></table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
                                       <tr class="LabelTop">
											<td colSpan="4"  align=left>Special considerations (religion, culture, language translator, substance abuse, developmental or intellectual disabilities): </td>
										</tr>
										<tr align="center">
											<td colSpan="4"><asp:textbox id="frmXXCommSpcialConsideration" runat="server" TextMode="MultiLine" Columns="60" Rows="6"></asp:textbox></td>
										</tr>
						<tr>
							<td align="right" colSpan="4"><input class="btn" type="submit" value="Save" name="SaveMe">
								&nbsp;&nbsp; <input class="btn" type="submit" value="Prev" name="PrevMe"> <input class="btn" type="submit" value="Next" name="NextMe">
							</td>
						</tr>
						<tr>
							<td align="left" colSpan="4">Save button saves current page. Next button saves and 
								moves to next page. Prev button saves and moves to previous page.</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr bgColor="blue" height="2">
				<td></td>
			</tr>
			<tr>
				<td align=right><a class="CenterLinks" href="logoff.aspx">[Log off]</a>&nbsp;&nbsp;<a class="CenterLinks" href="Referral.aspx">[Back 
						To List]</a></td>
			</tr>
			<tr>
				<td class="ltBlue" vAlign="top" height="100%"></td>
			</tr>
		</table>
		</td></tr></TBODY></TABLE></FORM>
                
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>

