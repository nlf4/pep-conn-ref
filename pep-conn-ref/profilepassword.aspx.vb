Public Class profilepassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = Session("UName")
        Me.loginPanel.Visible = False
        Me.logoutPanel.Visible = True
    End Sub

End Class