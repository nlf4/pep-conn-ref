<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referral.aspx.vb" Inherits="pep_conn_ref.referral" %>

<%@Register TagPrefix="footer" TagName="Footer" Src="Shared/footer.ascx" %>
<%@Register TagPrefix="header" TagName="Header" Src="Shared/header.ascx" %>

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
        <nav class="main-header navbar navbar-light navbar-expand-md">
                    
            <!-- Brand Logo -->
            <div class="logo-container">
                <a href="index.aspx" class="brand-link">
                    <img src="images/peplogo2.jpg" alt="PEP Logo" class="logo-image elevation-3">
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
                    <asp:label id="lblUser" runat="server" data-bs-toggle="dropdown" role="button" CssClass="dropdown-toggle"></asp:label>
                    <ul class="dropdown-menu account-dropdown" aria-labelledby="lblUser">
                        <li>
                            <a class="dropdown-item" href="/profile.aspx">Profile</a>
                        </li>
                      <li>
                          <a class="dropdown-item" href="/profilepassword.aspx">Password</a>
                      </li>
                      <li>
                          <a class="dropdown-item" href="/profileagency.aspx">Agency</a>
                      </li>
                        <li>
                          <a class="dropdown-item" href="/index.aspx">Log Out</a>
                      </li>
                    </ul>
                    <asp:Panel ID="loginPanel" runat="server" class="login-link">
                        <a href="/onlinereferral.aspx" class="user-login">Log In</a>
                    </asp:Panel>
                    <asp:Panel ID="logoutPanel" runat="server" class="login-link">
                        <a href="/onlinereferral.aspx" class="user-login">Log Out</a>
                    </asp:Panel>
                    
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
                                </div>
                            <!-- /Sidebar-menu -->
                        <%--</div>--%>
                        <!-- /Sidebar -->
                    </aside>
            
            <section class="main-content">
                <div class="main-text">
                    <asp:Label id="lblErrMsg" runat="server" ForeColor="Red" Visible="False">Label</asp:Label>
                    <h3>Referral Overview</h3>

                     <div class="container-fluid">

                        
                                <asp:DataGrid id="DataGrid1" runat="server" Width="750px" AutoGenerateColumns="false" font-Size="Smaller" font-Names="Arial">
                                    <AlternatingItemStyle font-Size="X-Small" ForeColor="#003399" BackColor="#E4F0FF"></AlternatingItemStyle>
                                    <ItemStyle font-Size="X-Small" ForeColor="#330099" BackColor="White"></ItemStyle>
									<headerStyle font-Size="Larger" font-Names="Arial" font-Bold="true" ForeColor="White" BackColor="#0260B3"></headerStyle>
									<Columns>
										<asp:HyperLinkColumn DataNavigateUrlField="ID" DataNavigateUrlFormatString="ReferralClient.aspx?ID={0}"
											DataTextField="ChildNameID" headerText="Child's Name (Tracking #)">
											<headerStyle Width="340px"></headerStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="DateEntered" headerText="Draft Date" DataFormatString="{0: MMMM d, yyyy}">
											<headerStyle Width="200px"></headerStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="strDateSubmitted" headerText="Submit Date">
											<headerStyle Width="200px"></headerStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="StatusDesc" headerText="Status">
											<headerStyle Width="160px"></headerStyle>
										</asp:BoundColumn>
										<asp:HyperLinkColumn Text="Print" Target="_blank" DataNavigateUrlField="ID" DataNavigateUrlFormatString="ReferralPrint.aspx?ID={0}"
											headerText="Print"></asp:HyperLinkColumn>
										<asp:HyperLinkColumn Text="Delete" DataNavigateUrlField="DelID" DataNavigateUrlFormatString="javascript:deleteMe(&quot;{0}&quot;);"
											headerText="Delete"></asp:HyperLinkColumn>
									</Columns>
                            </asp:DataGrid>

                         <table class="table table-striped">
                              <thead>
                                <tr>
                                  <th scope="col">Child (Tracking #)</th>
                                  <th scope="col">Draft Date</th>
                                  <th scope="col">Submit Date</th>
                                  <th scope="col">Status</th>
                                  <th scope="col">Print</th>
                                  <th scope="col">Delete</th>
                                </tr>
                              </thead>
                              <tbody>
                                <tr>
                                  <th scope="row">test</th>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                </tr>
                                <tr>
                                  <th scope="row">test</th>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                </tr>
                                <tr>
                                  <th scope="row">test</th>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                  <td>test</td>
                                </tr>
                              
                              </tbody>
                            </table>
                        </div>
                        <form class="refForm" runat="server"> 
                            <asp:Button ID="newReferralBtn" class="ref-buttons" runat="server" Text="New Referral" PostBackUrl="referralclient.aspx"/>
                        <%--<asp:Button ID="viewProfileBtn" class="ref-buttons" runat="server" Text="View My Profile" PostBackUrl="profile.aspx"/>--%>
                         </form>



                     

                    </div> 
                </section>
             </div>
<footer:Footer id="test" runat="server" />
        <script language="javascript" type="text/javascript">
			    function deleteMe(sID) {
			        if (sID == 0) {
			            alert("Referrals already submitted cannot be deleted.");
			            return;
			        }
	                if (!window.confirm("Are you sure you want to delete this client from your list?")) return;
	                window.location="ReferralDel.aspx?ID=" + sID;	
                }
        </script>