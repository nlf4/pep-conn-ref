Imports System.Data.SqlClient
Imports System.Data


Public Class onlinereferral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub submitbtn_Click(sender As Object, e As EventArgs) Handles submitbtn.Click
        'Dim connection As New SqlConnection("Server= (localdb)\MSSQLLocalDB; Database = LoginDB; Integrated Security = true")
        'Dim connection As New SqlConnection("Server= PEP-SQL4 \ SQLPEPWA; Database = SQLPEPWA; Integrated Security = true")
        Dim connection As New SqlConnection("User ID=PEPPublic;password=768sds1ll11l%$^bjsdh;Initial Catalog=PEP;Data Source=PEP-SQL4\SQLPEPWA;")

        'Dim connection As New SqlConnection("Data Source = (localdb) \ MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True;")

        'If sUID = "" Or sPWD = "" Then Return "The user name and password are both required."
        'sSQL = "exec usp_Users_SignON '" _
        '& Replace(sUID, "'", "''") & "','" _
        '& Replace(sPWD, "'", "''") & "',1"
        'dt = requestDT(sSQL)
        'If dt.Rows.Count = 0 Then Return "Sorry, but your name is not on our system. Please verify your user name and/or password."



        Dim command As New SqlCommand("select * from users where UID = @UID", connection)

        'command.Parameters.Add("@id", SqlDbType.Int).Value = id.Text
        command.Parameters.Add("@UID", SqlDbType.VarChar).Value = UID.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = password.Text

        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()
        lblErrorMessage.Text = "you have clicked login"

        'adapter.SelectCommand = command
        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            lblErrorMessage.Text = "userid not found"



        Else


            lblErrorMessage.Text = "userid found"

            'Dim frm As New VBNET_SQL_Insert_Update_Delete()

            'Me.Hide()

            'frm.Show()

        End If
    End Sub


End Class