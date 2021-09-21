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
           
        <!-- Top Navbar -->
        <nav class="main-header navbar navbar-light ">
            <div class="container-fluid">
                    
            <!-- Brand Logo -->
            <div class="logo-container">
                <a href="index.aspx" class="brand-link">
                    <img src="images/peplogo2.jpg" alt="PEP Logo" class="logo-image elevation-3"/>
                </a>
            </div>
                        
           
            <div class="header-container">
                <div class="menu-panel">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavbar1">
                        <i class="fas fa-bars"></i>
                    </button>
                </div>
                <div class="title-panel">
                    <h2>PEP Referral System</h2>
                </div>
                <div class="user-panel">
                    <div class="login-link">
                        <a href="/onlinereferral.aspx#loginForm" class="user-login">Log In</a>
                    </div>
                </div>
            </div>

            </div>
        </nav>
        <!-- / Top Navbar -->

        <div class="wrapper">     

		        <!-- Main Sidebar Container -->
                    <aside class="main-sidebar sidebar-dark-primary elevation-4">
   
                        <!-- Sidebar -->
                        <%--<div class="sidebar">--%>

		                     <!-- Sidebar Menu -->    
                                <div class="collapse navbar-collapse" id="collapsibleNavbar1">
                                    <ul class="navbar-nav">
                                        <li class="nav-item active-side">
                                            <a href="/index.aspx" class="nav-link">Connections Home
                                                <%--<p>Connections Home</p>--%>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="/admissioncriteria.aspx" class="nav-link">
                                                <p>Admission Criteria</p>
                                            </a>
                                        </li>
                                        <li class="nav-item dropdown" id="ref-dropdown">
                                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" data-bs-toggle="dropdown" role="button" aria-expanded="false">
                                               <%-- <p>Online Referral</p>--%>
                                                Online Referral
                                            </a>
                                            <ul class="dropdown-menu">
                                                <li>
                                                    <a href="/referral.aspx" class="dropdown-item">Overview</a>
                                                </li>
                                                <li>
                                                    <a href="/referralclient.aspx" class="dropdown-item">New Referral</a>
                                                </li>
                                            </ul>
                                        </li>
                                        <li class="nav-item">
                                            <a href="/contact.aspx" class="nav-link"> Contact Us
                                                <%--<p>Contact Us</p>--%>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            <!-- /Sidebar-menu -->
                        <%--</div>--%>
                        <!-- /Sidebar -->
                    </aside>