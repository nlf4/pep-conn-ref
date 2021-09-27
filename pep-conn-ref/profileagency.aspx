<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profileagency.aspx.vb" Inherits="pep_conn_ref.profileagency" %>

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
                                    <li>
                                        <a class="dropdown-item" href="/profile.aspx">Profile</a>
                                    </li>
                                    <li>
                                        <a class="dropdown-item" href="/profilepassword.aspx">Password</a>
                                    </li>
                                    <li>
                                        <a class="dropdown-item active" href="/profileagency.aspx">Agency</a>
                                    </li>
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
                                    <li class="nav-item">
                                        <a href="/admissioncriteria.aspx" class="nav-link">
                                            <p>Admission Criteria</p>
                                        </a>
                                    </li>
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
                    <div class="agency-details">
                       
                        <%--<asp:literal id="lblLeftLink" runat="server"></asp:literal>--%>
							
				        <asp:label id="Label1" runat="server" Height="5px"></asp:label>
						
                        <%--<asp:literal id="LblTopLink" runat="server"></asp:literal>--%>
										
						<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
							
							<form id="frm" class="agency-form" method="post" runat="server">
                                <div class="agency-form-row">
                                    <asp:literal id="hiddenFormList" runat="server"></asp:literal>
										
                                    <div class="input-row">
                                        <label>Agency Name:</label>
										<asp:textbox id="frmXXAgencyName" runat="server"></asp:textbox>
                                    </div>
                                                
									<div class="input-row">
                                        <label>Address 1:</label>
                                        <asp:textbox id="frmXXAgencyAddress1" runat="server"></asp:textbox>
									</div>

                                    <div class="input-row">
                                        <label>Address 2:</label>
                                        <asp:textbox id="frmXXAgencyAddress2" runat="server"></asp:textbox>
									</div>
                                  </div>
								    <div class="agency-form-row">
										<div class="input-row">
                                            <label>City:</label>
                                            <asp:textbox id="frmXXAgencyCity" runat="server"></asp:textbox>
										</div>

                                        <div class="input-row">
                                            <label>State:</label>
                                            <asp:textbox id="frmXXAgencyState" runat="server"></asp:textbox>
										</div>

                                            <div class="input-row">
                                            <label>Zip:</label>
                                            <asp:textbox id="frmXXAgencyZip" runat="server"></asp:textbox>
										</div>

                                        <div class="input-row">
                                            <label>Phone:</label>
                                            <asp:textbox id="frmXXAgencyPhone" runat="server"></asp:textbox>
										</div>

                                        <div class="input-row">
                                            <label>Fax:</label>
                                            <asp:textbox id="frmXXAgencyFax" runat="server"></asp:textbox>
										</div>
                                    </div>
                                    <div class="agency-form-row">
                                        <input id="btnUpdateAgency" class="btn" type="submit" name="Update" value="Update"  />
                                    </div>
                                    <div class="agency-form-row">
                                        <p>Please be sure to complete all the information on the pages linked with buttons above. Click the Update button for each page.</p>
                                    </div>

								</form>
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
