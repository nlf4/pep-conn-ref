Imports System.Data.SqlClient
Imports System.Data


Public Class onlinereferral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As DataTable
        Dim i As Integer

        'If getSecurity(Request, "CONNWEB", "USER") = 0 Then Response.Redirect(ROOT_DIRECTORY_SECURE & "/Login.aspx")

        If Me.Page.IsPostBack Then
            Me.lblMsg.Text = validateUser(Me.UID.Text, Me.password.Text)
            If Me.lblMsg.Text = "" Then Response.Redirect("referral.aspx")
        End If
        'ds = requestDT("exec usp_ConnWebContent_getList 'SIGNON' ,'DESC'")
        'For i = 0 To ds.Rows.Count - 1
        '    If i = 0 Then
        '        Me.lblContent.Text = ds.Rows(i)("Contents")
        '    Else
        '        Me.lblContent.Text = Me.lblContent.Text & "<BR><br>" & ds.Rows(i)("Contents")
        '    End If
        'Next
        'Me.lblContent.Text = Me.lblContent.Text & "<br><br>"

        'Me.lblLeftLink.Text = getSideLink("REFF")
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

        If UID.Text = "" Or password.Text = "" Then lblErrorMessage.Text = "All fields must be filled in"

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

            lblErrorMessage.Text = "user id not found"
        Else
            lblErrorMessage.Text = "user id found"

            'Dim frm As New VBNET_SQL_Insert_Update_Delete()

            'Me.Hide()

            'frm.Show()

        End If
    End Sub

    Private Function validateUser(ByVal sUID As String, ByVal sPWD As String) As String
        'Validate UID and PWD
        'Return '' as sucessful
        Dim sSQL As String
        Dim dt As DataTable
        If sUID = "" Or sPWD = "" Then Return "The user name and password are both required."
        sSQL = "exec usp_Users_SignON '" _
                & Replace(sUID, "'", "''") & "','" _
                & Replace(sPWD, "'", "''") & "',1"
        dt = requestDT(sSQL)
        Dim sValue As String = Convert.ToString(dt.Rows(0))
        If dt.Rows.Count = 0 Then
            Return "Sorry username not found"
        Else
            Console.Write(dt.Rows(0))

        End If
        '"Sorry, but your name is not on our system. Please verify your user name and/or password."
        'Dim Redist As String = myDRTostring(dt.Rows(0), "Redirest")
        'If Redist > "" Then
        'Response.Redirect(Redist)
        'Response.End()
        'Exit Function
        'End If
        Session("UID") = dt.Rows(0)("UID")
        Session("IID") = dt.Rows(0)("ID")
        Session("UName") = dt.Rows(0)("UName")
        Session("AgencyName") = dt.Rows(0)("AgencyName")
        Session("DaysPWDExpired") = dt.Rows(0)("DaysPWDExpired")
        Return ""
    End Function

    Public Function requestDT(ByVal sSql As String) As DataTable
        'Dim tDict As System.Collections.Specialized.NameValueCollection
        'tDict = CType(System.Configuration.ConfigurationSettings.AppSettings("APpValues/General"), System.Collections.Specialized.NameValueCollection)
        Dim cn As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("CONNECTIONSTRING"))   '("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;password='';Initial Catalog=pepdev;Data Source=.;") 'Application("ConnectionString"))
        'cn.p()

        'evalSQLSTM(sSql)

        Dim selectCMD As New SqlClient.SqlCommand(sSql, cn)
        'selectCMD.CommandText = sSql
        'selectCMD.Connection = cn
        Dim DA As New SqlClient.SqlDataAdapter
        '= New SqlClient.SqlDataAdapter()
        DA.SelectCommand = selectCMD
        'cn.Open()
        Dim ds As DataSet = New DataSet
        DA.Fill(ds, "Table0")
        cn.Close()
        Return ds.Tables(0)
        'cn.Close()
    End Function

    Public Sub evalSQLSTM(ByRef sSQL As String)
        Dim sRetv As String = UCase(sSQL)
        ' addLog(sSQL)
        If InStr(sRetv, ".JS") > 0 Then
            sSQL = ""
            'addLog("Possible instrusion")
        End If
        If InStr(sRetv, "<JAVASCRIPT") > 0 Then
            sSQL = ""
            'addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSTABLES") > 0 Then
            sSQL = ""
            'addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSTEMTABLE") > 0 Then
            sSQL = ""
            'addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSOBJECTS") > 0 Then
            sSQL = ""
            'addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSCOLUMNS") > 0 Then
            sSQL = ""
            'addLog("Possible instrusion")
        End If
    End Sub

    Function myDRTostring(ByRef dr As DataRow, ByVal idx As Integer) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
    End Function



End Class