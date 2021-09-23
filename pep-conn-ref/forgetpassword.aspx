<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="forgetpassword.aspx.vb" Inherits="pep_conn_ref.forgetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
            <title>PEP Referral</title>
            <link rel="icon" type="image/png" href="/images/pep_apple.png">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
		    <link rel="stylesheet" href="style/all.min.css">
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
                                    <%--<li class="nav-item">
                                        <a href="#" class="nav-link">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
                                            <p>Latest News</p>
                                        </a>
                                    </li>--%>
                                    <li class="nav-item">
                                        <a href="/admissioncriteria.aspx" class="nav-link">
                                            <!--<i class="nav-icon fas fa-th"></i>-->
                                            <p>Admission Criteria</p>
                                        </a>
                                    </li>
                                    <%--<li class="nav-item">
                                        <a href="/staff.aspx" class="nav-link">
                                           <!-- <i class="nav-icon fas fa-th"></i>-->
                                            <p>Staff</p>
                                        </a>
                                    </li>--%>
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
            
          
            <section class="main-content">
                <div class="main-text">
                    <h2>Forgot Your Password?</h2>
                    <form id="frm" method="post" class="pwd-reset-form" runat="server">
						<asp:label id="lblContent" runat="server">Label</asp:label>
                        
                        <p>Please enter your user ID and email and we'll send you a reset link. If you do not have an email address or cannot access your email at this moment, please contact our IT department at <a href='tel:+12163614400'>216-361-4400</a>.</p>
                        <div class="input-row">
                            <div class="input-col col1">
                                <asp:textbox id="frmXXUID" runat="server" placeholder="User ID"></asp:textbox>
                                <asp:textbox id="frmXXEmail" runat="server" placeholder="Email"></asp:textbox>
                            </div>
                            <div class="input-col col2">
                                <asp:button id="btnPasswordReset" runat="server" Text="Reset My Password" CssClass="btn"></asp:button>
                            </div>
						</div>
                        
                        
                        <h3>Forgot your User ID?</h3>
                        <p>Please enter your email and we will mail you the associated user ID.</p>
                        <div class="input-row">
                            <div class="input-col col1">
                                <asp:textbox id="frmXXEmailFGUID" runat="server" placeholder="Email"></asp:textbox>
                            </div>
                            <div class="input-col col2">
                                 <asp:button id="btnUIDInquery" runat="server" Text="Send My User ID" CssClass="btn"></asp:button>
                            </div>
                            
                        </div>
                        
                        
						<asp:Label id="lblMsg" runat="server" ForeColor="Red"></asp:Label>
								
					</form>
                </div>
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>
