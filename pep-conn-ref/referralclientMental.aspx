<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referralclientMental.aspx.vb" Inherits="pep_conn_ref.referralclientMental" %>

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
                                 <asp:label id="lblUser" runat="server"></asp:label>
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

                <form id="frm" method="post" runat="server">
									<asp:literal id="hiddenFormList" runat="server"></asp:literal>
									<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
									<table class="bodytext" width="100%">
										<tr class="labelTop">
											<td colSpan="4">Admission Criteria</td>
										</tr>
                                        <tr>
                                            <td nowrap='nowrap' >
                                            <asp:radiobuttonlist id="frmXXAdmAnsNew1"  Repeatdirection=Horizontal runat="server" Width="100px" font-Size="X-Small"><asp:ListItem Value="Y">Yes</asp:ListItem><asp:ListItem Value="N">No</asp:ListItem>
												</asp:radiobuttonlist>
                                                </td>
                                        <td colspan=3 ><b>Is the client a legal resident of Cuyahoga County? </b> </td>

                                        </tr>
                                        <tr>
                                            <td nowrap='nowrap' >
                                            <asp:radiobuttonlist id="frmXXAdmAnsNew2"  Repeatdirection=Horizontal runat="server" Width="100px" font-Size="X-Small"><asp:ListItem Value="Y">Yes</asp:ListItem><asp:ListItem Value="N">No</asp:ListItem>
												</asp:radiobuttonlist>
                                                </td>
                                         <td colspan=3 ><b>Has the client been diagnosed with a serious emotional disturbance? </b> </td>

                                        </tr>
                                        <tr>
                                                                                    <td nowrap='nowrap' >
                                            <asp:radiobuttonlist id="frmXXAdmAnsNew3"  Repeatdirection=Horizontal runat="server" Width="100px" font-Size="X-Small"><asp:ListItem Value="Y">Yes</asp:ListItem><asp:ListItem Value="N">No</asp:ListItem>
												</asp:radiobuttonlist>
                                                </td>
                                        <td colspan=3><b>Is the client having multiple problems in multiple areas (i.e., home and school) resulting from their mental health symptoms? </b> </td>

                                        </tr>
                                        <tr>
                                            <td nowrap='nowrap' >
                                            <asp:radiobuttonlist id="frmXXAdmAnsNew4"  Repeatdirection=Horizontal runat="server" Width="100px" font-Size="X-Small"><asp:ListItem Value="Y">Yes</asp:ListItem><asp:ListItem Value="N">No</asp:ListItem>
												</asp:radiobuttonlist>
                                                </td>
                                        <td colspan=3 ><b>Is the client receiving mental health services, but remains at risk of deeper system involvement or is returning to the community from a placement? </b> </td>

                                        </tr>
                                        <tr class="labelTop">
											<td colSpan="4">Current Concerns</td>
										</tr>
                                        <tr>
											<td class="LabelLeftreq">Diagnoses:&nbsp;</td>
											<td colspan=3><asp:textbox id="frmXXDSMDesc1" runat="server" Width="385px"></asp:textbox>
                                               
                                            </td>
										</tr>
                                        <tr>
											<td class="LabelLeftreq">&nbsp;</td>
											<td colspan=3><asp:textbox id="frmXXDSMDesc2" runat="server" Width="190px"></asp:textbox>
                                                <asp:textbox id="frmXXDSMDesc3" runat="server" Width="190px"></asp:textbox>
                                            </td>
										</tr>
                                        <tr>
											<td class="LabelLeftreq">&nbsp;</td>
											<td colspan=3>
                                            <asp:textbox id="frmXXDSMDesc4" runat="server" Width="190px"></asp:textbox>
                                            <asp:textbox id="frmXXDSMDesc5" runat="server" Width="190px"></asp:textbox>
                                            </td>
										</tr>
										<tr>
											<td colspan="4"><table class="bodytext">
                                                    <tr><td colspan=3>
                                                        &nbsp;&nbsp;<b>Symptom Checklist: </b>
                                                    </td></tr>
													<tr valign="top">
														<asp:literal id="LitProblems" runat="server"></asp:literal></tr>
													<tr>
														<td colspan=3>&nbsp;&nbsp;<b>Other (Specify):
														</b><asp:textbox id="frmXXProblemOther" maxlength="200" width="400" runat="server"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>

                                        <tr class="LabelTop">
											<td colSpan="4"  align=left>Current providers: (Please include agency name, provider/contact name and role, and phone number.)</td>
										</tr>
										<tr align="center">
											<td colSpan="4"><asp:textbox id="frmXXCurrentProviders" runat="server" TextMode="MultiLine" Columns="60" Rows="6"></asp:textbox></td>
										</tr>
										<tr class="LabelTop">
											<td colSpan="4"  align=left><font color="red">*</font>Summary – reason for referral?</td>
										</tr>
										<tr align="center">
											<td colSpan="4"><asp:textbox id="frmXXCause" runat="server" TextMode="MultiLine" Columns="60" Rows="8"></asp:textbox></td>
										</tr>
										<tr>
											<td align="right" colSpan="4"><input class="btn" type="submit" value="Save" name="SaveMe">
												&nbsp;&nbsp; <input class="btn" type="submit" value="Prev" name="PrevMe"> &nbsp;&nbsp;<asp:button class="btn" id="SubmitMe" color="red" runat="server" Text="Submit"></asp:button>
											</td>
										</tr>
										<tr>
											<td align="left" colSpan="4">Save button saves current page. Next button saves and 
												moves to next page. Prev button saves and moves to previous page.</td>
										</tr>
									</table>
								</form>
                
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>


