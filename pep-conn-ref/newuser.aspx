<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="newuser.aspx.vb" Inherits="pep_conn_ref.newuser" %>

<%@Register TagPrefix="footer" TagName="Footer" Src="Shared/footer.ascx" %>
<%@Register TagPrefix="header" TagName="Header" Src="Shared/header.ascx" %>

	<header:Header id="MainHeader" runat="server" />
            <section class="main-content">
                <div class="register-main-text">
					<div class="register-details">
                    
						<form id="frm" class="register-form" method="post" runat="server">
							
								<%--<asp:label id="lblContent" runat="server">Label</asp:label>--%>
								
									<h4>Register As New User</h4>
									
									<div class="input-row">
										<asp:textbox id="frmXXFirstName" placeholder="First Name" runat="server"></asp:textbox>
										<asp:textbox id="frmXXLastName" placeholder="Last Name" runat="server"></asp:textbox>
									</div>
									<div class="input-row">
										<asp:textbox id="frmXXUID" runat="server" placeholder="User ID"></asp:textbox>
										<asp:textbox id="frmXXAgencyName" placeholder="Agency Name" runat="server" ></asp:textbox>
									</div>

									<div class="input-row">
										<asp:textbox id="frmXXeMail" placeholder="Email" runat="server"></asp:textbox>
										<asp:textbox id="frmXXeMail2" placeholder="Re-type Email" runat="server"></asp:textbox>
									</div>
								
									<div class="input-row">
										<asp:textbox id="frmXXPWD" runat="server" placeholder="Password" TextMode="Password"></asp:textbox>
										<asp:textbox id="frmXXPWDCONFIRM" runat="server" placeholder="Re-type Password" TextMode="Password"></asp:textbox>
									</div>
									
									<asp:button id="btnRegister" runat="server" Text="Register" CssClass="btn"></asp:button>
								
									<asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label>
								
						</form>
					


                    </div>
                </div>
            </section>
        </div>
    <footer:Footer id="test" runat="server" />
