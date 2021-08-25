<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profilepassword.aspx.vb" Inherits="pep_conn_ref.profilepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>PEP Referral</title>
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
		    <link rel="stylesheet" href="style/all.min.css">
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

                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                      <li class="nav-item">
                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Profile</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link active" id="password-tab" data-toggle="tab" href="#password" role="tab" aria-controls="password" aria-selected="true">Password</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" id="agency-tab" data-toggle="tab" href="#agency" role="tab" aria-controls="agency" aria-selected="false">Agency</a>
                      </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                      <div class="tab-pane fade show active" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                          
                    <div class="user-details">
                       
                       
                    </div>
                    <p>Please be sure to complete all the information on the 
													pages linked&nbsp;with buttons above. Click Update button for each page.&nbsp;</p>
                      </div>
                      <div class="tab-pane fade show active" id="password" role="tabpanel" aria-labelledby="password-tab">
                          <table class="bodytext" width="100%">
							<tr>
								<td>
									<table class="bodytext" width="100%">
										<tr>
											<td><asp:label id="Label1" runat="server" Height="5px">Label</asp:label></td>
											<td align="right"><asp:literal id="LblTopLink" runat="server"></asp:literal></td>
										</tr>
									</table>
									<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label></td>
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
												<td class="LabelLeftReq">Enter current Password:</td>
												<td><asp:textbox id="frmXXOldPWD" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Enter New Password:</td>
												<td><asp:textbox id="frmXXNewPWD1" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Re-type Password:</td>
												<td><asp:textbox id="frmXXNewPWD2" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
			                                <tr><td colspan="4"><hr /></td></tr>
                                <tr><td colspan="4">Password needs to be 8-15 characters.
                        <br />Password must conatin at least 3 out of 4 basic character groups (Upper case, lower case, number, symbol).
                        <br />Password cannot be the same as the login and cannot be re-used.</td></tr>
                                <tr><td colspan="4"><hr /></td></tr>
                                            								<tr>
												<td colspan="4" align="right">
													<INPUT class="btn" type="submit" name="Update" value="Change Password">
												</td>
											</tr>
											<TR>
												<TD align="left" colSpan="4">To change password, please provide current, new and confirming password then click "change password" button.</TD>
											</TR>
										</table>
									</form>
								</td>
							</tr>
							<tr bgcolor="blue" height="2">
								<td></td>
							</tr>
							<tr>
								<td><a class="CenterLinks" href='logoff.aspx'>[Log off]</a>&nbsp;&nbsp;<a class="CenterLinks" href='Referral.aspx'>[Back 
										To Referral]</a></td>
							</tr>
						</table>
                  
                      </div>
                      <div class="tab-pane fade" id="agency" role="tabpanel" aria-labelledby="agency-tab">
                          <h3> AGENCY PAGE </h3>
                      </div>
                        
                    </div>
                   
                   
                </div>
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
</html>
