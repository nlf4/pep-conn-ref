Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.VisualBasic


Public Class forgetpassword
    Inherits System.Web.UI.Page

    Private Function ValidateInput() As String
        If Request.Form("btnPasswordReset") & "" > "" Then
            If Me.frmXXEmail.Text = "" Then Return "Email is a required field"
        End If
        If Request.Form("btnUIDInquery") & "" > "" Then
            If Me.frmXXEmailFGUID.Text = "" Then Return "Email is a required field"
        End If
        Return ""
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        Dim i As Integer
        Dim sSQL As String
        Dim errMsg As String = ""
        Dim Url As String = ""
        'If getSecurity(Request, "CONNWEB", "USER") = 0 Then Response.Redirect(ROOT_DIRECTORY_SECURE & "/Login.aspx")
        If Me.Page.IsPostBack Then
            Me.lblMsg.Text = ValidateInput()
            If Me.lblMsg.Text = "" Then
                If Request.Form("btnPasswordReset") & "" > "" Then
                    sSQL = "exec usp_Users_PWDReset '" _
                        & Replace(Me.frmXXUID.Text, "'", "''") & "' ,'" _
                        & Replace(Me.frmXXEmail.Text, "'", "''") & "',0,1"
                    Url = "CMSShow.aspx?AREA=SIGNON&ID=PWDReset"
                    Url = "CMSShowPWD.aspx"
                End If
                If Request.Form("btnUIDInquery") & "" > "" Then
                    sSQL = "exec usp_Users_UID_Inquery '" _
                        & Replace(Me.frmXXEmailFGUID.Text, "'", "''") & "',1"
                    Url = "CMSShow.aspx?AREA=SIGNON&ID=UIDInquery"
                End If
                dt = requestDT(sSQL)
                If dt.Rows.Count = 0 Then
                    Me.lblMsg.Text = "Sorry, there is issue resetting your password, please contact PEP's IT Dept for further assistance. ."
                Else
                    errMsg = dt.Rows(0)(0)
                    If errMsg = "" Then
                        'Me.lblMsg.Text = "A temporary password has been send to your email. Plesae check your email for sign on instructions=
                        Response.Redirect(Url)
                        Response.End()
                    Else
                        Me.lblMsg.Text = errMsg
                    End If

                End If
            End If
        End If
        'dt = requestDT("exec usp_ConnWebContent_get 'SIGNON','FORGET'")
        'For i = 0 To dt.Rows.Count - 1
        '    If i = 0 Then
        '        Me.lblContent.Text = dt.Rows(i)("Contents")
        '    Else
        '        Me.lblContent.Text = Me.lblContent.Text & "<BR><br>" & dt.Rows(i)("Contents")
        '    End If
        'Next
        Me.lblContent.Text = ""
        'Me.lblLeftLink.Text = getSideLink("REFF")
    End Sub

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



End Class