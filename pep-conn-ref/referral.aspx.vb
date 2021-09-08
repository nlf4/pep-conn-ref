

Public Class referral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        Dim ds As DataTable
        Dim DaysPWDExpired As Integer
        'Dim i As Integer
        If getSecurity(Session, "CWAdmin", "CONWEBUSER") <> 0 Then
        Else
            Response.Redirect(ConfigurationSettings.AppSettings("ROOT_DIRECTORY_SECURE") & "/onlinereferral.aspx")
        End If
        Me.lblUser.Text = Session("UName")
        Me.loginPanel.Visible = False
        Me.logoutPanel.Visible = True

        'If IsNumeric(Session("DaysPWDExpired")) Then
        '    DaysPWDExpired = CLng(Session("DaysPWDExpired"))
        '    If DaysPWDExpired < 31 Then
        '        Me.lblUser.Text = Me.lblUser.Text & "<br><font color='red'>Your password will expire in " _
        '            & Session("DaysPWDExpired") & IIf(DaysPWDExpired > 1, " days", "day") _
        '            & ". Please <a href='ProfilePWD.aspx'>change your password</a> at your earliest convenience.</font>"
        '    End If
        'End If
        'Me.lblLeftLink.Text = getSideLink("REFF")
        DataGrid1.DataSource = requestDT("exec usp_ConnWebReferral_GetListExt '" & Replace(Session("UID"), "'", "''") & "'")
        'datagrid1.
        DataGrid1.DataBind()
        If Request("MsgCode") > "" Then
            ds = requestDT("Select * from ConnWebContent where Area='ONLINE' and id='" & Replace(Request("MsgCode"), "'", "''") & "'")
            Me.lblErrMsg.Text = ds.Rows(0)("Contents")
            Me.lblErrMsg.Visible = True
            Me.lblErrMsg.ForeColor = Drawing.Color.Red
            'Me.lblErrMsg.BackColor = Drawing.Color.Red
            'Me.lblErrMsg. = Drawing.Color.Red
        Else
            Me.lblErrMsg.Visible = False
        End If
    End Sub

    Public Function getSecurity(ByRef Session As System.Web.SessionState.HttpSessionState, ByVal sAppId As String, ByVal sFunctID As String) As Int32
        Dim sASPSession As String, sDotNetSession As String
        Dim sSQL As String
        Dim retv
        If Session("UID") > "" Then
        Else
            Return 0
        End If
        'sASPSession = request.
        sSQL = "select dbo.udf_AppSec('" & Session("UID") & "','" _
            & Replace(sAppId, "'", "''") & "','" & Replace(sFunctID, "'", "''") & "')"
        retv = retSingleValue(sSQL)
        If retv <> 0 Then Return retv Else Return 0
    End Function

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
        'cn.Open()
        Dim ds As DataSet = New DataSet
        DA.Fill(ds, "Table0")
        cn.Close()
        Return ds.Tables(0)
        'cn.Close()
    End Function

    Public Sub evalSQLSTM(ByRef sSQL As String)
        Dim sRetv As String = UCase(sSQL)
        'addLog(sSQL)
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

    Public Function retSingleValue(ByVal sSQL As String)
        Dim dt As New DataTable
        dt = requestDT(sSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return DBNull.Value
        End If
    End Function

End Class