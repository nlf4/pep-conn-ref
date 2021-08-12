﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="onlinereferral.aspx.vb" Inherits="pep_conn_ref.onlinereferral" %>

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
                            
                            <div class="login-link">
                                <a href="#" class="user-login">Log In</a>
                            </div>
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
            <section class="main-content">
                <div class="main-text">
                    <h2>Make a Referral</h2>
                    <p>




The online process will allow you to refer a child to the PEP CONNECTIONS program.


All data is submitted through a secure connection, and all information will be held in strict confidence. Currently, the referral program only allows Professional/Agency Referrals .
If you are a parent or guardian and would like to refer your child to the Connections program, please contact the Intake Department at (216) 361-2441. A staff person will assist you with the referral process.





If you are a professional with a pre-established user name and password, please sign in by filling in the boxes below and then click the sign in button.
If you are new to our system (have not previously registered), please click to Register as one of our users.
If you are a return user but forgot your password or user name, please click the link to reset your password or inquire about you user ID/Name.

Please Note- The PEP Connections Referral screens have changed. Please contact PEP's IT Staff at 216-361-4400 or the Intake Department at 216-361-2441 for any concerns with the new referral screens.</p>
                    
                </div>
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>

