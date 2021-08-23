<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referralclient.aspx.vb" Inherits="pep_conn_ref.referralclient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>PEP Referral</title>
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
		    <link rel="stylesheet" href="style/all.min.css">
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
                                <asp:label id="lblUser" runat="server"></asp:label>
                                <div class="login-link">
                                    <a href="/onlinereferral.aspx" class="user-login">Log Out</a>
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
                                        <a href="#" class="nav-link">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
                                            <p>Latest News</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/admissioncriteria.aspx" class="nav-link">
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
                                    <li class="nav-item">
                                        <a href="/onlinereferral.aspx" class="nav-link">
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
            
           <%-- </form>--%>
            <section class="main-content">
                <div class="main-text">

       
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
							<td><asp:label id="Label1" runat="server" Height="5px">Label</asp:label></td>
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
										<tr valign=top>
											<td class="LabelLeftreq"><br /><font color="red">*</font>Child's Name:
											</td>
											<td nowrap='nowrap' colspan="3">
                                            <table cellpadding=0 cellspacing=2 class=bodyText>
                                            <tr>
                                                <td><asp:textbox id="frmXXFName" runat="server" Width="110px"></asp:textbox><br /><sup><font color="red">*</font>First Name</sup></td>
                                                <td><asp:textbox id="frmXXMI" runat="server" Width="20px"></asp:textbox><br /><sup>M.I.</sup></td>
                                                <td><asp:textbox id="frmXXLName" runat="server" Width="110px"></asp:textbox><br /><sup><font color="red">*</font>Last Name</sup></td>
                                 
                                            <td><asp:textbox id="frmXXSuffix" runat="server" Width="110px"></asp:textbox><br /><sup>&nbsp;Suffix (Jr., III)</sup></td>
                                               </tr>
                                            </table>
                                            </td>
										</tr>
										<tr>
											<td class="LabelLeftreq"><font color="red">*</font>DOB:
											</td>
                                            <td><asp:textbox id="frmXXDOB" runat="server" Width="100px"></asp:textbox>
                                            </td>
											<td class="LabelLeftreq">SSN:&nbsp;</td><td><asp:textbox onchange='changedMe();' id="frmXXSS" runat="server" Width="100px"></asp:textbox>
																	
                                                                    </td>				
                                                                                    </tr>

										<tr>
											<td class="LabelLeftreq"><font color="red">*</font>Gender:
											</td>
                                            <td nowrap='nowrap' colspan=3>
                                            <asp:radiobuttonlist id="frmXXSex"  Repeatdirection=Horizontal runat="server" Width="100px" font-Size="X-Small"><asp:ListItem Value="M">Male</asp:ListItem><asp:ListItem Value="F">Female</asp:ListItem>
												</asp:radiobuttonlist>
                                                </td>
										</tr>

										<tr class="labelTop">
											<td colSpan="4">Care Giver/Current address and phone numbers:</td>
										</tr>
										<tr>
											<td class="LabelLeftreq"><font color="red">*</font>Name:&nbsp;</td>
											<td ><asp:textbox id="frmXXCareGiver" runat="server" Width="140px"></asp:textbox></td>
											<td class="LabelLeftreq"><font color="red">*</font>Relationship:&nbsp;</td>
											<td ><asp:textbox id="frmXXCaregiverRelationship" runat="server" Width="120px"></asp:textbox></td>
										</tr>
											<tr>
											<td class="LabelLeftreq"><font color="red">*</font>Address:&nbsp;
											</td>
											<td colSpan="3"><asp:textbox id="frmXXAddress" runat="server" Width="415px"></asp:textbox></td>
										</tr>
										<tr>
											<td class="LabelLeftreq">Add. Line 2:&nbsp;
											</td>
											<td colSpan="3"><asp:textbox id="frmXXAddress2" runat="server" Width="415px"></asp:textbox></td>
										</tr>
										<tr>
											<td class="LabelLeftreq"><font color="red">*</font>City:&nbsp;
											</td>
											<td colspan=3><asp:textbox id="frmXXCity" runat="server"></asp:textbox>&nbsp;&nbsp;<b><font color="red">*</font>State:</b>&nbsp;
        <asp:textbox id="frmXXST" runat="server" Width="30px"></asp:textbox>&nbsp;&nbsp;<font color="red">*</font><b>Zip:&nbsp;</b>
												<asp:textbox id="frmXXZip" runat="server" Width="90px"></asp:textbox></td>
										<tr>
    									<tr>
											<td class="LabelLeftreq">Phone:<font color="red">*</font>&nbsp;
											</td>
											<td nowrap colspan=3><asp:textbox id="frmXXPhone" maxlength=20 runat="server" Width="128px"></asp:textbox>
                                            <asp:textbox id="frmXXPhoneWork" maxlength=25 runat="server" Width="128px"></asp:textbox>
                                            <asp:textbox id="frmXXPhoneCell" maxlength=25 runat="server" Width="128px"></asp:textbox>
											</td>
										</tr>

										<tr class="labelTop">
											<td colSpan="4">Legal Guardian&nbsp;
                                                
                                            </td>
										</tr>
                                        <tr><td colspan="4" align="center">
                                             <asp:CheckBox ID="frmXXLegalSameAddress" runat="server" /><b> The Care Giver is also the Legal Guardian.</b>
                                            <sup><i>If checked, please skip this section.</i>.</sup>
                                            </td></tr>
										<tr>
											<td class="LabelLeftreq">Name:&nbsp;</td>
											<td ><asp:textbox id="frmXXLegalCareGiver" runat="server" Width="140px"></asp:textbox></td>
											<td class="LabelLeftreq">Relationship:&nbsp;</td>
											<td ><asp:textbox id="frmXXLegalCareGiverRelationship" runat="server" Width="120px"></asp:textbox></td>
										</tr>
										<tr>
											<td class="LabelLeftreq">Address:&nbsp;
											</td>
											<td colSpan="3"><asp:textbox id="frmXXLegalAddress" runat="server" Width="415px"></asp:textbox></td>
										</tr>
										<tr>
											<td class="LabelLeftreq">Add. Line 2:&nbsp;
											</td>
											<td colSpan="3"><asp:textbox id="frmXXLegalAddress2" runat="server" Width="415px"></asp:textbox></td>
										</tr>
										<tr>
											<td class="LabelLeftreq">City:&nbsp;
											</td>
											<td colspan=3><asp:textbox id="frmXXLegalCity" runat="server"></asp:textbox>&nbsp;&nbsp;<b>State:</b>&nbsp;
											<asp:textbox id="frmXXLegalSt" runat="server" Width="30px"></asp:textbox>&nbsp;&nbsp;<b>Zip:&nbsp;</b>
												<asp:textbox id="frmXXLegalZip" runat="server" Width="90px"></asp:textbox></td>
										<tr>
    									<tr>
											<td class="LabelLeftreq">Phone:&nbsp;
											</td>
											<td nowrap colspan=3><asp:textbox id="frmXXlegalPhone1" maxlength=20 runat="server" Width="128px"></asp:textbox>
                                            <asp:textbox id="frmXXlegalPhone2" maxlength=25 runat="server" Width="128px"></asp:textbox>
                                            <asp:textbox id="frmXXlegalPhone3" maxlength=25 runat="server" Width="128px"></asp:textbox>
											</td>
										</tr>
										<tr class="labelTop">
											<td colSpan="4">
												Custody Information</td>
										</tr>
										<tr>
											<td class="LabelLeftreq">Type Of Custody:&nbsp;
											</td>
											<td><asp:dropdownlist id="frmXXTypeOfCustody" runat="server"></asp:dropdownlist></td>
											<td class="LabelLeftreq">Type of Insurance:&nbsp;
											</td>
											<td>
                                            <asp:textbox id="frmXXTypeOfInsurance" maxlength=25 runat="server" Width="128px"></asp:textbox>
                                           </td>
										</tr>

										<tr>
											<td align="right" colSpan="4"><input class="btn" type="submit" value="Save" name="SaveMe">
												&nbsp; <input class="btn" type="submit" value="Next" name="NextMe">
											</td>
										</tr>
										<tr>
											<td align="left" colSpan="4">Save button saves current page. Next button saves and 
												moves to next page.</td>
										</tr>
									</table>
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
				</td>
			</tr>
		</table>
                   
                </div>
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>
