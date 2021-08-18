<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profile.aspx.vb" Inherits="pep_conn_ref.profile" %>

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
                    <asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
                    <asp:literal id="hiddenFormList" runat="server"></asp:literal>
                    <h2>USER PROFILE</h2>
                    <div class="user-details">
                        <%--<form runat="server">
                            <div class="details-col-1">
                                <div class="input-row">
                                    <label for="UID">User ID:</label>
                                    <asp:TextBox ID="UID" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                <label for="firstname">First Name:</label>
                                    <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                                </div>
                                    <div class="input-row">
                                    <label for="salutation">Salutation:</label>
                                    <asp:TextBox ID="salutation" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                    <label for="phone">Phone:</label>
                                    <asp:TextBox ID="phone" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                    <label for="fax">Fax:</label>
                                    <asp:TextBox ID="fax" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="details-col-2">
                                <div class="input-row">
                                <label for="profname">Full Name:</label>
                                    <asp:TextBox ID="profname" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                    <label for="lastname">Last Name:</label>
                                    <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                    <label for="title">Title:</label>
                                    <asp:TextBox ID="title" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                    <label for="mobile">Mobile Phone:</label>
                                    <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-row">
                                    <label for="email">Email:</label>
                                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                                </div>
                                <asp:Button ID="updateBtn" runat="server" Text="Update" PostBackUrl="profile.aspx"/>
                            </div>
                        </form>--%>
                        <form id="frm" method="post" runat="server">
										<asp:literal id="Literal1" runat="server"></asp:literal>
										<table class="bodytext" width="100%">
											<tr>
												<td class="LabelLeftReq">User ID:&nbsp;
												</td>
												<td><asp:textbox id="frmXXUID" runat="server" ReadOnly="True"></asp:textbox></td>
												<td class="LabelLeftReq">Professional Name:&nbsp;
												</td>
												<td><asp:textbox id="frmXXProfessionName" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">First Name:&nbsp;
												</td>
												<td><asp:textbox id="frmXXFirstName" runat="server"></asp:textbox></td>
												<td class="LabelLeftReq">Last Name:&nbsp;
												</td>
												<td><asp:textbox id="frmXXLastName" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Salutation:&nbsp;
												</td>
												<td><asp:textbox id="frmXXSolutation" runat="server"></asp:textbox></td>
												<td class="LabelLeftReq">
												Title:&nbsp;
												<td><asp:textbox id="frmXXTitle" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Phone:&nbsp;
												</td>
												<td><asp:textbox id="frmXXPhone" runat="server"></asp:textbox></td>
												<td class="LabelLeftReq">Mobile Phone:&nbsp;
												</td>
												<td><asp:textbox id="frmXXCell" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Fax:&nbsp;
												</td>
												<td><asp:textbox id="frmXXFax" runat="server"></asp:textbox></td>
												<td class="LabelLeftReq">eMail Address:&nbsp;
												</td>
												<td><asp:textbox id="frmXXeMail" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Licensure:&nbsp;
												</td>
												<td ><asp:textbox id="frmXXLicensure" runat="server" Width="415px"></asp:textbox></td>
											</tr>
											<tr>
												<td align="right" >&nbsp;&nbsp;
                                                    <input class="btn" type="submit" value="Update" name="Update"/>
												</td>
											</tr>
											<tr>
												<td align="left" >Please be sure to complete all the information on the 
													pages linked&nbsp;with buttons above. Click Update button for each page.&nbsp;</td>
											</tr>
										</table>
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

