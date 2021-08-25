<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referral.aspx.vb" Inherits="pep_conn_ref.referral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>PEP Referral</title>
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
		    <link rel="stylesheet" href="style/all.min.css">
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
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
            
            <section class="main-content">
                <div class="main-text">
                    <h2>Referrals</h2>
                    <asp:Label id="lblErrMsg" runat="server" ForeColor="Red" Visible="False">Label</asp:Label>

                   
                    <form class="refForm" runat="server"> 
                        <asp:Button ID="newReferralBtn" class="ref-buttons" runat="server" Text="New Referral" PostBackUrl="referralclient.aspx"/>
                        <asp:Button ID="viewProfileBtn" class="ref-buttons" runat="server" Text="View My Profile" PostBackUrl="profile.aspx"/>
                    </form>

     <ul class="nav nav-tabs" id="myTab" role="tablist">
          <li class="nav-item" role="presentation">
            <a class="nav-link active" id="overview-tab" data-bs-toggle="tab" href="#overview" role="tab" aria-controls="overview" aria-selected="true">Overview</a>
          </li>
         <li class="nav-item" role="presentation">
            <a class="nav-link active" id="newref-tab" data-bs-toggle="tab" href="#newref" role="tab" aria-controls="newref" aria-selected="false">New Referral</a>
          </li>
          <li class="nav-item dropdown" role="presentation">
            <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#profile" role="button" aria-haspopup="true" aria-expanded="false">Account</a>
            <div class="dropdown-menu">
              <a class="dropdown-item" data-toggle="tab" href="#profile">Profile</a>
              <a class="dropdown-item" data-toggle="tab" href="#password">Password</a>
              <a class="dropdown-item" data-toggle="tab" href="#agency">Agency</a>
            </div>
          </li>
          
    </ul>

<div class="container-fluid">
  <div class="tab-content">
    <div role="tabpanel" class="tab-pane fade in active" id="overview">
      <div class="alert alert-info">Overview</div>
    </div>
    <div role="tabpanel" class="tab-pane fade" id="newref">
      <div class="alert alert-info">New Referral</div>
    </div>
    <div role="tabpanel" class="tab-pane fade" id="profile">
      <div class="alert alert-info">Profile</div>
    </div>
    <div role="tabpanel" class="tab-pane fade" id="password">
      <div class="alert alert-info">Password</div>
    </div>
    <div role="tabpanel" class="tab-pane fade" id="agency">
      <div class="alert alert-info">Agency</div>
    </div>
    
  </div>
</div>

                    
                    <asp:DataGrid id="DataGrid1" runat="server" Width="750px" AutoGenerateColumns="false" font-Size="Smaller"
										font-Names="Arial">
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
											<asp:HyperLinkColumn Text="[print]" Target="_blank" DataNavigateUrlField="ID" DataNavigateUrlFormatString="ReferralPrint.aspx?ID={0}"
												headerText="Print"></asp:HyperLinkColumn>
											<asp:HyperLinkColumn Text="Delete" DataNavigateUrlField="DelID" DataNavigateUrlFormatString="javascript:deleteMe(&quot;{0}&quot;);"
												headerText="Delete"></asp:HyperLinkColumn>
										</Columns>
                        </asp:DataGrid>
                    <%--<asp:Table runat="server" ID="refTable">
                        <asp:TableHeaderRow ID="headerRow">
                            <asp:TableHeaderCell>Child's Name (Tracking #)</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Draft Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Submit Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Print</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>--%>
                    
                </div>
                
            </section>
        </div>

        <footer>
            <p>&copy; 2021 - Positive Education Program</p>
        </footer>
    </body>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.3.4/js/tether.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.3/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
</html>
