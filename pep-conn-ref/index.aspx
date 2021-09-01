<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="pep_conn_ref.index" %>
<%@Register TagPrefix="footer" TagName="Footer" Src="Shared/footer.ascx" %>
<%@Register TagPrefix="header" TagName="Header" Src="Shared/header.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>PEP Referral</title>
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
		    
        <!-- Bootstrap -->
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
    </head>
    <body>
           
            <!-- Top Navbar -->
                <nav class="main-header navbar navbar-light navbar-expand-lg">
                    
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
                                 
                                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavbar1">
                                             <i class="fas fa-bars"></i>
                                        </button>
                                    
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
                        <div class="sidebar">

		                     <!-- Sidebar Menu -->
                            
                                     
                                <div class="collapse navbar-collapse text-center" id="collapsibleNavbar1">
                                <ul class="sidebar-list" role="menu" data-accordion="false">
                                    <li class="nav-item active-side">
                                        <a href="#" class="nav-link">
                                            <!-- <i class="nav-icon fa fa-home"></i> -->
                                            <p>Connections Home</p>
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="/latestnews.aspx" class="nav-link ">
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
                                </div>
                              
                            <!-- /Sidebar-menu -->
                        </div>
                        <!-- /Sidebar -->
                    </aside>
            
           <%-- </form>--%>
            <section class="main-content">
                <div class="main-text">
                    <h2>Welcome to <span class="red">P</span>ositive <span class="red">E</span>ducation <span class="red">P</span>rogram's online referral system for Connections.</h2>
                    <p>PEP Connections coordinates services for children and youth who are experiencing serious emotional difficulties and are determined to be 
                    at-risk for deeper system involvement and/or returning home or to the community from out of home placement.</p>
                    <p>PEP Connections works with the child and everyone involved in his or her life to create a plan of care aimed 
                    at helping the child access community supports and begin on a path to success.</p>
                    <p>For referrals, please call <a href="tel:+12163612441">216-361-2441</a> or click on the Online Referral link in the menu to the left. Click <a href="pepcleve.org">here</a> to visit PEP's website.</p>
                    <div class="warning"><p>In our efforts to improve compliance with the  requirements for protecting client information, Positive Education 
                    Program has removed identifying information from our email communications for Connections referrals and replaced them 
                    with an assigned tracking number.  When you are signed into the referral website, the associated client name will be  
                    visibly paired with the tracking number for your reference.  Please continue to use this tracking number in email 
                    communications regarding your submitted referral.</p></div>
                </div>
                
            </section>
        </div>
         <footer:Footer id="test" runat="server" />
       
     
