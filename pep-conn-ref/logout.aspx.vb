Public Class logout
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Session("UID") = ""
        Session("UName") = ""
        Session("AgencyName") = ""
        Session.Abandon()
        Response.Redirect("index.aspx")
    End Sub

End Class