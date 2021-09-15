<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profile.aspx.vb" Inherits="pep_conn_ref.profile" %>

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
                                <%--<asp:Panel ID="loginPanel" runat="server" class="login-link">
                                    <a href="/onlinereferral.aspx" class="user-login">Log In</a>
                                </asp:Panel>--%>
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
                    <asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
                    <asp:literal id="hiddenFormList" runat="server"></asp:literal>
                    <h3>User Profile</h3>

                    
                    
                     
                          
                    <div class="user-details">
                       
                        <form id="frm" method="post" runat="server">
                            <div class="details-col-1">
										<asp:literal id="Literal1" runat="server"></asp:literal>
										        <div class="input-row">
                                                    <label>UserID:</label>
												    <asp:textbox id="frmXXUID" runat="server" ReadOnly="True"></asp:textbox>
										        </div>
												
											    <div class="input-row">
												<label>First Name:</label>
												<asp:textbox id="frmXXFirstName" runat="server"></asp:textbox>
												</div>

											    <div class="input-row">
                                                <label>Salutation:</label>
												<asp:textbox id="frmXXSolutation" runat="server"></asp:textbox>
												</div>

											    <div class="input-row">
                                                <label>Phone:</label>
												<asp:textbox id="frmXXPhone" runat="server"></asp:textbox>
												</div>

                                                <div class="input-row">
												<label>Fax:</label>
												<asp:textbox id="frmXXFax" runat="server"></asp:textbox>
												</div>

											    <div class="input-row">
                                                <label>Licensure:</label>
												<asp:textbox id="frmXXLicensure" runat="server" Width="415px"></asp:textbox>
											    </div>
                                                </div>

                                                <div class="details-col-2">
                                                <div class="input-row">
                                                <label>Professional Name:</label>
												<asp:textbox id="frmXXProfessionName" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Last Name:</label>
												<asp:textbox id="frmXXLastName" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Title:</label>
												<asp:textbox id="frmXXTitle" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Mobile:</label>
												<asp:textbox id="frmXXCell" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Email:</label>
												<asp:textbox id="frmXXeMail" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                    <input class="btn update-profile-btn" type="submit" value="Update" name="Update"/>
                                                </div>
                                            
                                            </div>
													
									</form>
                        
                    </div>
<%--                    <p>Please be sure to complete all the information on the 
													pages linked&nbsp;with buttons above. Click Update button for each page.&nbsp;</p>--%>
                   
                      
                   

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

