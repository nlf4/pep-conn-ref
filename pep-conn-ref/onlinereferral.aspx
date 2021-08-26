<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="onlinereferral.aspx.vb" Inherits="pep_conn_ref.onlinereferral" %>

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
                                    <li class="nav-item active-side">
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
            
           <%-- </form>--%>
            <section class="main-content">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label><br />
                <asp:label id="lblContent" runat="server"  Width="588px" Font-Size="Larger"></asp:label>
                <div class="main-text">
                    <h2>Make a Referral</h2>
                    <p>The online process will allow you to refer a child to the PEP CONNECTIONS program.<br />
                        All data is submitted through a secure connection, and all information will be held in strict 
                        confidence. Currently, the referral program only allows Professional/Agency Referrals.<br />
                        </p>
                        <ol>
                            <li>If you are a parent or guardian and would like to refer your child to the Connections program, please contact the Intake Department at <a href="tel:+12163612441">216-361-2441</a>. A staff person will assist you with the referral process.</li>
                            <li>If you are a professional with a pre-established user name and password, please sign in by filling in the boxes below and then click the sign in button.</li>
                            <li>If you are new to our system (have not previously registered), please click to Register as one of our users.</li>
                            <li>If you are a return user but forgot your password or user name, please click the link to reset your password or inquire about you user ID/Name.</li>
                        </ol>
                    <p>Please Note - The PEP Connections Referral screens have changed. Please contact PEP's IT Staff at <a href="tel:+12163614400">216-361-4400</a> or the Intake Department at <a href="tel:+12163612441">216-361-2441</a> for any concerns with the new referral screens.</p>
                        
                    <div class="login-form-container">
                        <form id="loginForm" runat="server"> 

                            <div class="login-input">
                                <label for="UID">User ID:</label>
                                <asp:TextBox ID="UID" runat="server">Nfurtado</asp:TextBox>
                            </div>

                            <div class="login-input">
                                <label for="password">Password:</label>
                                <asp:TextBox ID="password" runat="server" TextMode="Password" Text="PipFroMer6!"></asp:TextBox>
                            </div>

                            <asp:Button ID="submitBtn" runat="server" Text="Log In"  />
                            <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label><br />

                            <p><a id="forgot-pwd-link" href="forgetpassword.aspx">I forgot my password/user ID</a></p>
                           <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                           </form>

                        </div>

                </div>
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>

