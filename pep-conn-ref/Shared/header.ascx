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
        <nav class="main-header navbar navbar-light navbar-expand-lg">
            <%--<div class="container-fluid"></div>--%>
                    
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
                        <a href="/onlinereferral.aspx" class="user-login">Log In</a>
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
                                    <ul class="sidebar-list" role="menu" data-accordion="false">
                                        <li class="nav-item active-side">
                                            <a href="#" class="nav-link">
                                                <p>Connections Home</p>
                                            </a>
                                        </li>
                                        <%--<li class="nav-item">
                                            <a href="/latestnews.aspx" class="nav-link ">
                                                <p>Latest News</p>
                                            </a>
                                        </li>--%>
                                        <li class="nav-item">
                                            <a href="/admissioncriteria.aspx" class="nav-link">
                                                <p>Admission Criteria</p>
                                            </a>
                                        </li>
                                       <%-- <li class="nav-item">
                                            <a href="/staff.aspx" class="nav-link">
                                                <p>Staff</p>
                                            </a>
                                        </li>--%>
                                        <li class="nav-item">
                                            <a href="#submenu1" class="nav-link" data-bs-toggle="collapse">
                                                <p>Online Referral</p>
                                            </a>
                                            <ul class="collapse show nav flex-column ms-1 sidebar-list" id="submenu1" data-bs-parent="#menu">
                                                <li class="nav-item w-100">
                                                    <a href="/referral.aspx" class="nav-link px-0">Overview</a>
                                                </li>
                                                <li class="nav-item w-100">
                                                    <a href="/referralclient.aspx" class="nav-link px-0">New Referral</a>
                                                </li>
                                            </ul>
                                        </li>
                                        <li class="nav-item">
                                            <a href="/contact.aspx" class="nav-link">
                                                <p>Contact Us</p>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            <!-- /Sidebar-menu -->
                        <%--</div>--%>
                        <!-- /Sidebar -->
                    </aside>