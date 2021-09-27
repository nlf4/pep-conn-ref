Public Class referraldel
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sSQL As String
        Dim ds As DataTable
        ds = requestDT("select status from ConnWebReferral where id= " & Request("ID"))
        If ds.Rows(0)("Status") & "" <> "Incomplete" Then
            Response.Redirect("Referral.aspx?MsgCode=AlreadyDelete")
        End If
        sSQL = "exec usp_ConnWebReferral_Delete '" & Session("UID") & "'," & Request.QueryString("ID")
        Try
            executeSql(sSQL)
            Response.Redirect("Referral.aspx")
        Catch ex As Exception
            Me.Label1.Text = "Can not delete this referal due to:<br>" & ex.Message
        End Try
    End Sub

    Public Function requestDT(ByVal sSql As String) As DataTable
        'Dim tDict As System.Collections.Specialized.NameValueCollection
        'tDict = CType(System.Configuration.ConfigurationSettings.AppSettings("APpValues/General"), System.Collections.Specialized.NameValueCollection)
        Dim cn As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("CONNECTIONSTRING"))   '("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;password='';Initial Catalog=pepdev;Data Source=.;") 'Application("ConnectionString"))
        'cn.p()
        evalSQLSTM(sSql)

        Dim selectCMD As New SqlClient.SqlCommand(sSql, cn)
        'selectCMD.CommandText = sSql
        'selectCMD.Connection = cn
        Dim DA As New SqlClient.SqlDataAdapter
        '= New SqlClient.SqlDataAdapter()
        DA.SelectCommand = selectCMD
        cn.Open()
        Dim ds As DataSet = New DataSet
        DA.Fill(ds, "Table0")
        cn.Close()
        Return ds.Tables(0)
        'cn.Close()
    End Function

    Public Sub evalSQLSTM(ByRef sSQL As String)
        Dim sRetv As String = UCase(sSQL)
        addLog(sSQL)
        If InStr(sRetv, ".JS") > 0 Then
            sSQL = ""
            addLog("Possible instrusion")
        End If
        If InStr(sRetv, "<JAVASCRIPT") > 0 Then
            sSQL = ""
            addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSTABLES") > 0 Then
            sSQL = ""
            addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSTEMTABLE") > 0 Then
            sSQL = ""
            addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSOBJECTS") > 0 Then
            sSQL = ""
            addLog("Possible instrusion")
        End If
        If InStr(sRetv, "SYSCOLUMNS") > 0 Then
            sSQL = ""
            addLog("Possible instrusion")
        End If
    End Sub

    Public Sub addLog(ByVal sMsg)
        'Const ForReading = 1, ForWriting = 2, ForAppending = 8
        Dim oHttpSession As New System.Web.UI.Page
        If Len(ConfigurationSettings.AppSettings("LOGFILE")) > 0 Then
            Dim fso, f
            fso = CreateObject("Scripting.FileSystemObject")
            f = fso.OpenTextFile((ConfigurationSettings.AppSettings("LOGFILE")), 8, True)
            f.writeLine(Now() & " - " & sMsg)
            'f.writeLine(Now() & " - " & sMsg)

            f.Close()
            fso = Nothing
        End If
    End Sub
    Public Sub executeSql(ByVal sSql As String)
        Call evalSQLSTM(sSql)
        Dim cn As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings(("CONNECTIONSTRING"))) '("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;password='';Initial Catalog=pepdev;Data Source=.;") 'Application("ConnectionString"))
        cn.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sSql
        cmd.Connection = cn ' New SqlClient.SqlConnection(CONNECTIONSTRING)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub


End Class