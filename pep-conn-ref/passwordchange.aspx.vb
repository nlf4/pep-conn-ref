Public Class passwordchange
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim i As Integer
        Dim sSQL As String
        Dim errMsg As String = ""
        'If getSecurity(Request, "CONNWEB", "USER") = 0 Then Response.Redirect(ROOT_DIRECTORY_SECURE & "/Login.aspx")

        If Me.Page.IsPostBack Then
            Me.lblMsg.Text = ValidateInput()
            If Me.lblMsg.Text = "" Then
                sSQL = "exec usp_Users_PWDChange '" _
                    & Replace(Me.frmXXUID.Text, "'", "''") & "' ,'" _
                    & Replace(Me.frmXXOldPWD.Text, "'", "''") & "','" _
                    & Replace(Me.frmXXNewPWD1.Text, "'", "''") & "','" _
                    & Replace(Me.frmXXNewPWD2.Text, "'", "''") & "',1"
                dt = requestDT(sSQL)
                If dt.Rows.Count = 0 Then
                    Me.lblMsg.Text = "Sorry, there is issue changing your password, please contact PEP's IT Dept for further assistance. ."
                Else
                    errMsg = mydrToString(dt.Rows(0), "ErrMsg")
                    If errMsg = "" Then
                        Session("UID") = dt.Rows(0)("UID")
                        Session("IID") = dt.Rows(0)("ID")
                        Session("UName") = dt.Rows(0)("UName")
                        Session("AgencyName") = dt.Rows(0)("AgencyName")
                        Session("DaysPWDExpired") = dt.Rows(0)("DaysPWDExpired")
                        Me.lblMsg.Text = "Your password has been changed. Please <a href='Referral.aspx'>click here</a> or the link in left sidebar to continue your referral."
                    Else
                        Me.lblMsg.Text = errMsg
                    End If

                End If
            End If
        End If
        dt = requestDT("Select * from ConnWebContent where Area='SIGNON' and ID='ChangePWD' order by seq")
        For i = 0 To dt.Rows.Count - 1
            If i = 0 Then
                Me.lblContent.Text = dt.Rows(i)("Contents")
            Else
                Me.lblContent.Text = Me.lblContent.Text & "<BR><br>" & dt.Rows(i)("Contents")
            End If
        Next
        If Request("Expired") > "" Then
            Me.lblExpire.Text = "Password expired. "
        Else
            Me.lblExpire.Text = ""
        End If
        Me.lblContent.Text = Me.lblContent.Text & "<br>"
        'Me.lblLeftLink.Text = getSideLink("REFF")
    End Sub
    Private Function ValidateInput() As String
        If Me.frmXXUID.Text = "" Or Me.frmXXOldPWD.Text = "" Or Me.frmXXNewPWD1.Text = "" Or Me.frmXXNewPWD2.Text = "" Then Return "Both user name and current, new, and confirming password are required."
        Return ""
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

    Function myDRTostring(ByRef dr As DataRow, ByVal idx As String) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
    End Function

End Class