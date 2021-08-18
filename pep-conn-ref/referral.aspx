<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referral.aspx.vb" Inherits="pep_conn_ref.referral" %>

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
                        
                        <div class="header-container">
                            <div class="title-panel">
                                <h2>PEP Referral System</h2>
                            </div>
                            
                            <div class="user-panel">
                                <p><asp:label id="lblUser" runat="server">Label</asp:label></p>
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
                                    <li class="nav-item active">
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
                    <h2>Referrals</h2>
                    <asp:Label id="lblErrMsg" runat="server" ForeColor="Red" Visible="False">Label</asp:Label>

                    <%--<p><asp:label id="lblUser" runat="server">Label</asp:label></p>--%>
                    <form class="refForm" runat="server"> 
                        <asp:Button ID="newReferralBtn" class="ref-buttons" runat="server" Text="New Referral"/>
                        <asp:Button ID="viewProfileBtn" class="ref-buttons" runat="server" Text="View My Profile" PostBackUrl="profile.aspx"/>
                    </form>

                    <asp:DataGrid id="DataGrid1" runat="server" Width="581px" AutoGenerateColumns="False" font-Size="Smaller"
										font-Names="Arial">
                        <AlternatingItemStyle font-Size="X-Small" ForeColor="#003399" BackColor="#CCCCFF"></AlternatingItemStyle>
										<ItemStyle font-Size="X-Small" ForeColor="#330099" BackColor="White"></ItemStyle>
										<headerStyle font-Size="Larger" font-Names="Arial" font-Bold="true" ForeColor="White" BackColor="DarkBlue"></headerStyle>
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
											<asp:HyperLinkColumn Text="[print]" Target="_blank" DataNavigateUrlField="ID" DataNavigateUrlFormatString="ReferralPrint.aspx?ID={0}"
												headerText="Print"></asp:HyperLinkColumn>
											<asp:HyperLinkColumn Text="Delete" DataNavigateUrlField="DelID" DataNavigateUrlFormatString="javascript:deleteMe(&quot;{0}&quot;);"
												headerText="Delete"></asp:HyperLinkColumn>
										</Columns>
                        </asp:DataGrid>
                    <asp:Table runat="server" ID="refTable">
                        <asp:TableHeaderRow ID="headerRow">
                            <asp:TableHeaderCell>Child's Name (Tracking #)</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Draft Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Submit Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Print</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    
                </div>
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
</html>
