Public Class onlinereferral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub BTN_LOGIN_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        Dim connection As New SqlConnection("Server= SAMSNG-PC; Database = TestDB; Integrated Security = true")

        Dim command As New SqlCommand("select * from Table_Login where Username = @username and Password = @password", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = id.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = password.Text

        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            message.Show("Username Or Password Are Invalid")

        Else

            'MessageBox.Show("Login Successfully")

            Dim frm As New VBNET_SQL_Insert_Update_Delete()

            Me.Hide()

            frm.Show()

        End If
    End Sub


End Class