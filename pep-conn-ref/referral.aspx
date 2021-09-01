<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referral.aspx.vb" Inherits="pep_conn_ref.referral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>PEP Referral</title>
		    <link href="style/style.css" type="text/css" rel="stylesheet">
		    <!-- Font Awesome -->
		    <link rel="stylesheet" href="style/all.min.css">
            <!-- Bootstrap -->
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
                                    <li class="nav-item active-side">
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
                    <asp:Label id="lblErrMsg" runat="server" ForeColor="Red" Visible="False">Label</asp:Label>

                   
                    <%--<form class="refForm" runat="server"> 
                        <asp:Button ID="newReferralBtn" class="ref-buttons" runat="server" Text="New Referral" PostBackUrl="referralclient.aspx"/>
                        <asp:Button ID="viewProfileBtn" class="ref-buttons" runat="server" Text="View My Profile" PostBackUrl="profile.aspx"/>
                    </form>--%>

        <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item" role="presentation">
                    <a class="nav-link active" id="overview-tab" data-bs-toggle="tab" href="#overview" role="tab" aria-controls="overview" aria-selected="true">Overview</a>
                </li>
                <li class="nav-item" role="presentation">
                    <a class="nav-link" id="newref-tab" data-bs-toggle="tab" href="#newref" role="tab" aria-controls="newref" aria-selected="false">New Referral</a>
                </li>     
                <li class="nav-item dropdown" role="presentation">
                    <a class="nav-link dropdown-toggle" id="account-tab" data-bs-toggle="dropdown" href="#account" role="button" aria-haspopup="true" aria-expanded="false">Account</a>
                <div class="dropdown-menu">
                  <a class="dropdown-item" data-bs-toggle="tab" href="#profile">Profile</a>
                  <a class="dropdown-item" data-bs-toggle="tab" href="#password">Password</a>
                  <a class="dropdown-item" data-bs-toggle="tab" href="#agency">Agency</a>
                </div>
          </li>
          
    </ul>

<div class="container-fluid">

    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active" id="overview" role="tabpanel" aria-labelledby="overview-tab">
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
                        </div>
                        <div class="tab-pane fade" id="newref" role="tabpanel" aria-labelledby="newref-tab">
                        <h3> NEWREF PAGE </h3>
                        </div>
                        <div class="tab-pane fade" id="account" role="tabpanel" aria-labelledby="account-tab">
                         <h3> ACCOUNT PAGE </h3>
                        </div>
                        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                            
                            <asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
                    <asp:literal id="hiddenFormList" runat="server"></asp:literal>
                    <h2>USER PROFILE</h2>

                   
                   
                          
                    <div class="user-details">
                       
                        <form id="frm" method="post" runat="server">
                            <div class="details-col-1">
										<asp:literal id="Literal1" runat="server"></asp:literal>
										        <div class="input-row">
                                                    <label>UserID:</label>
												    <asp:textbox id="frmXXUID" runat="server" ReadOnly="True"></asp:textbox>
										        </div>
												
												
											    <div class="input-row">
												<label>First Name:</label>
												<asp:textbox id="frmXXFirstName" runat="server"></asp:textbox>
												</div>

											    <div class="input-row">
                                                <label>Salutation:</label>
												<asp:textbox id="frmXXSolutation" runat="server"></asp:textbox>
												</div>

											    <div class="input-row">
                                                <label>Phone:</label>
												<asp:textbox id="frmXXPhone" runat="server"></asp:textbox>
												</div>

                                                <div class="input-row">
												<label>Fax:</label>
												<asp:textbox id="frmXXFax" runat="server"></asp:textbox>
												</div>

											    <div class="input-row">
                                                <label>Licensure:</label>
												<asp:textbox id="frmXXLicensure" runat="server" Width="415px"></asp:textbox>
											    </div>
                                            </div>
                                            <div class="details-col-2">
                                                <div class="input-row">
                                                <label>Professional Name:</label>
												<asp:textbox id="frmXXProfessionName" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Last Name:</label>
												<asp:textbox id="frmXXLastName" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Title:</label>
												<asp:textbox id="frmXXTitle" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Mobile:</label>
												<asp:textbox id="frmXXCell" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                <label>Email:</label>
												<asp:textbox id="frmXXeMail" runat="server"></asp:textbox>
                                                </div>

                                                <div class="input-row">
                                                    <input class="btn" type="submit" value="Update" name="Update"/>
                                                </div>
                                            
                                            </div>	
									</form>
                                </div>
                              <p>Please be sure to complete all the information on the pages linked&nbsp;with buttons above. Click Update button for each page.&nbsp;</p>

                        </div>
                        <div class="tab-pane fade" id="password" role="tabpanel" aria-labelledby="password-tab">
                            
                             <table class="bodytext" width="100%">
							<tr>
								<td>
									<table class="bodytext" width="100%">
										<tr>
											<td><asp:label id="Label1" runat="server" Height="5px">Label</asp:label></td>
											<td align="right"><asp:literal id="LblTopLink" runat="server"></asp:literal></td>
										</tr>
									</table>
									<asp:label id="Label2" runat="server" ForeColor="Red"></asp:label></td>
							</tr>
							<tr bgColor="blue" height="2">
								<td></td>
							</tr>
							<tr>
								<td>
									<form id="Form1" method="post">
										<asp:literal id="Literal2" runat="server"></asp:literal>
										<table class="bodytext" width="100%">
											<tr>
												<td class="LabelLeftReq">Enter current Password:</td>
												<td><asp:textbox id="frmXXOldPWD" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Enter New Password:</td>
												<td><asp:textbox id="frmXXNewPWD1" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td class="LabelLeftReq">Re-type Password:</td>
												<td><asp:textbox id="frmXXNewPWD2" runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
			                                <tr><td colspan="4"><hr /></td></tr>
                                <tr><td colspan="4">Password needs to be 8-15 characters.
                        <br />Password must conatin at least 3 out of 4 basic character groups (Upper case, lower case, number, symbol).
                        <br />Password cannot be the same as the login and cannot be re-used.</td></tr>
                                <tr><td colspan="4"><hr /></td></tr>
                                            								<tr>
												<td colspan="4" align="right">
													<INPUT class="btn" type="submit" name="Update" value="Change Password">
												</td>
											</tr>
											<TR>
												<TD align="left" colSpan="4">To change password, please provide current, new and confirming password then click "change password" button.</TD>
											</TR>
										</table>
									</form>
								</td>
							</tr>
							<tr bgcolor="blue" height="2">
								<td></td>
							</tr>
							<tr>
								<td><a class="CenterLinks" href='logoff.aspx'>[Log off]</a>&nbsp;&nbsp;<a class="CenterLinks" href='Referral.aspx'>[Back 
										To Referral]</a></td>
							</tr>
						</table>
                  
                      </div>

                        </div>
                        <div class="tab-pane fade" id="agency" role="tabpanel" aria-labelledby="agency-tab">
                         <h3> AGENCY PAGE </h3>
                        </div>
                          

 <%-- <div class="tab-content">
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
    
  </div>--%>
</div>

                    
                    
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
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.3.4/js/tether.min.js"></script>
    </body
</html>
