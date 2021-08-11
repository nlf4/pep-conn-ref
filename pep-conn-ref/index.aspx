<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="pep_conn_ref.index" %>

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
                                <img src="images/peplogo2.jpg" alt="PEP Logo" class="logo-image elevation-3" style="opacity: .9">
                            </a>
                        </div>
                        
                       <%-- <a href="#" class="brand-link">
                            &nbsp;<span class="brand-text font-weight-light" aria-autocomplete="none"></span></a>--%>
                        <div class="header-container">
                        <h2>PEP Referral System</h2>
                        <!-- Sidebar user panel -->
                        <div class="user-panel">
                            <i class="fas fa-user-circle"></i>
                            <div class="user-info">
                                <a href="#" class="user-link">Guest User</a>
                            </div>
                        </div>
                    </div>
                </nav>
            <!-- / Navbar -->

		    <!-- Main Sidebar Container -->
                <aside class="main-sidebar sidebar-dark-primary elevation-4">
   

                    <!-- Sidebar -->
                    <div class="sidebar">
                        

		                 <!-- Sidebar Menu -->
                        <nav class="nav-sidebar">
                            <ul class="sidebar-list" role="menu" data-accordion="false">
                                <li class="nav-item">
                                    <a href="#" class="nav-link">
                                        <!-- <i class="nav-icon fa fa-home"></i> -->
                                        <p>Connections Home</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="#" class="nav-link ">
                                        <!--<i class="nav-icon fas fa-th"></i>-->
                                        <p>Latest News</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="#" class="nav-link active">
                                        <!--<i class="nav-icon fas fa-th"></i>-->
                                        <p>Admission Criteria</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="#" class="nav-link">
                                       <!-- <i class="nav-icon fas fa-th"></i>-->
                                        <p>Staff</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="#" class="nav-link">
                                        <!--<i class="nav-icon fas fa-th"></i>-->
                                        <p>Online Referral</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="#" class="nav-link">
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
        <section>
            <h3>Main Content</h3>
        </section>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>
