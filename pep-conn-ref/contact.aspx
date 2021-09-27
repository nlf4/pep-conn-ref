<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="contact.aspx.vb" Inherits="pep_conn_ref.contact" %>

<%@Register TagPrefix="footer" TagName="Footer" Src="Shared/footer.ascx" %>
<%@Register TagPrefix="header" TagName="Header" Src="Shared/header.ascx" %>

    <header:Header id="MainHeader" runat="server" />
    <section class="contact-main-content">
        <h1>Contact Us</h1>
        <div class="contact-main-text">

            <div class="contact-item">
                <h3>PEP Connections</h3>
                <p>3134 Euclid Avenue<br />
                    Cleveland, Ohio 44115<br />
                    Tel: <a href="tel:+12163619100">216-361-9100</a><br />
                    Fax: <a href="tel:+12163617774">216-361-7774</a> 
                </p>
            </div>
            
            <div class="contact-item">
                <h3>Jill Koenig </h3>
                <p>Program Director PEP Connections<br />
                <a href="mailto:Jkoenig@pepcleve.org">Jkoenig@pepcleve.org</a>
                </p>
            
            </div>
            <div class="contact-item">
                <h3>PEP Connections</h3>
                <p>
                    Tel: <a href="tel:+12163612441x41">216-361-2441 x41</a><br />
                    Fax: <a href="tel:+12163612448">216-361-2448</a><br />
                </p>
            </div>
            
        </div>
    </section>
</div>
    <footer:Footer id="test" runat="server" />
