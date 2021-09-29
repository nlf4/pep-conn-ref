<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="onlinereferral.aspx.vb" Inherits="pep_conn_ref.onlinereferral" %>

<%@Register TagPrefix="footer" TagName="Footer" Src="Shared/footer.ascx" %>
<%@Register TagPrefix="header" TagName="Header" Src="Shared/header.ascx" %>

   

<header:Header id="MainHeader" runat="server" />
            <section class="main-content">
               
                <div class="main-text">
                    <h2 class="page-heading">Make a Referral</h2>
                    <p>The online process will allow you to refer a child to the PEP CONNECTIONS program.<br />
                        All data is submitted through a secure connection, and all information will be held in strict 
                        confidence. Currently, the referral program only allows Professional/Agency Referrals.<br />
                        </p>
                        <ul class="online-ref-ul">
                            <li>If you are a parent or guardian and would like to refer your child to the Connections program, please contact the Intake Department at <a href="tel:+12163612441">216-361-2441</a>. A staff person will assist you with the referral process.</li>
                            <li>If you are a professional with a pre-established user name and password, please sign in by filling in the boxes below and then click the sign in button.</li>
                            <li>If you are new to our system (have not previously registered), please click <a href="/newuser.aspx">here</a> to register as one of our users.</li>
                            <li>If you are a return user but forgot your password or user name, please click <a href="/forgetpassword.aspx">here</a> to reset your password or inquire about you user ID/Name.</li>
                        </ul>
                    <p>Please Note - The PEP Connections Referral screens have changed. Please contact PEP's IT Staff at <a href="tel:+12163614400">216-361-4400</a> or the Intake Department at <a href="tel:+12163612441">216-361-2441</a> for any concerns with the new referral screens.</p>
                        
                    <div class="login-form-container">
                        <form id="loginForm" runat="server"> 

                            <div class="login-input">
                                <label for="UID">User ID:</label>
                                <asp:TextBox ID="UID" runat="server">Nfurtado</asp:TextBox>
                            </div>

                            <div class="login-input">
                                <label for="password">Password:</label>
                                <asp:TextBox ID="password" runat="server" TextMode="Password" Text=""></asp:TextBox>
                            </div>

                            <asp:Button ID="submitBtn" runat="server" Text="Log In"  />
                            <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label><br />

                            <p><a id="forgot-pwd-link" href="forgetpassword.aspx">I forgot my password/user ID</a></p>
                           <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                           </form>

                        </div>
                     <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label><br />
                <asp:label id="lblContent" runat="server"  Width="588px" Font-Size="Larger"></asp:label>
                </div>
                
            </section>
        </div>

        <footer:Footer id="test" runat="server" />