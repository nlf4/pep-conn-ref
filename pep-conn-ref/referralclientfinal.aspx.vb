Public Class referralclientfinal
    Inherits System.Web.UI.Page

    Private Sub frmValidateData(ByRef dr As DataRow)
        Me.lblMsg.Text = ValidateData(dr, "CONNWEB:Referral")
    End Sub
    Private Sub HasPostBack()
        'If Me.lblMsg.Text <> "" Then Exit Sub

        'User might hit the submit key
        If Request.Form("SubmitMe") > "" Then
            Me.lblMsg.Text = UpdateFromForm(Request, "usp_ConnWebReferral_Submit", "")
            If Me.lblMsg.Text > "" Then Exit Sub
            Response.Redirect("Referral.aspx")
        End If
        'User might go to another tag
        If Request.Form("NextPage") <> "" Then Response.Redirect("ReferralClient" & Request.Form("NextPage") & ".aspx")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("REFID") = "" Then Response.Redirect("Login.aspx")
        Dim ds As DataTable
        Dim sAddChildInfo As String
        'Dim x
        Dim i As Integer
        Dim sSQL As String = ""
        If getSecurity(Session, "CWAdmin", "CONWEBUSER") <> 0 Then
        Else
            Response.Redirect(ConfigurationSettings.AppSettings("ROOT_DIRECTORY_SECURE") & "/Login.aspx")
        End If
        If Me.IsPostBack Then
            Call HasPostBack()
        Else
        End If
        Me.lblUser.Text = Session("UName") & " - " & Session("AgencyName") & " - Referral/Referral Information '" & Session("ClientName") & "'"
        'If Request.QueryString("NEWUSER") = "YES" Then Me.lblUser.Text=Me.lblUser.Text & 
        'Me.lblLeftLink.Text = getSideLink("REFF")
        'Me.LblTopLink.Text = getTopLink("REFF", "REFF")
        ds = requestDT("exec usp_ConWebReferral_GetRecord " & Session("REFID"))
        If ds.Rows(0)("RefBy") <> Session("UID") Then Response.Redirect("Login.aspx")

        Me.hiddenFormList.Text = hiddenTag("NextPage", "") & hiddenTag("frmXXID", ds.Rows(0)("ID")) & hiddenTag("frmXXUID", Session("UID"))
        Call frmValidateData(ds.Rows(0))
        sAddChildInfo = ""
        If ds.Rows(0)("AddChildDiaInfo1") & "" = "Y" Then
            'sAddChildInfo = sAddChildInfo & "<br>&nbsp;&#149;&nbsp;Diagnostic/Mental Health Assessment."
        End If
        If ds.Rows(0)("AddChildDiaInfo2") & "" = "Y" Then
            'sAddChildInfo = sAddChildInfo & "<br>&nbsp;&#149;&nbsp;Psychological or Psychiatric Evaluations or Reports."
        End If
        If ds.Rows(0)("AddChildDiaInfo3") & "" = "Y" Then
            'sAddChildInfo = sAddChildInfo & "<br>&nbsp;&#149;&nbsp;Hospital Psychiatric Admission or Discharge Summaries/Reports."
        End If
        If ds.Rows(0)("AddChildDiaInfo4") & "" = "Y" Then
            'sAddChildInfo = sAddChildInfo & "<br>&nbsp;&#149;&nbsp;Therapy Summaries/Notes."
        End If
        If ds.Rows(0)("AddChildDiaInfo5") & "" = "Y" Then
            'sAddChildInfo = sAddChildInfo & "<br>&nbsp;&#149;&nbsp;Special Education Evaluations."
        End If
        If Me.lblMsg.Text > "" Then
            ds = requestDT("Select * from ConnWebContent where Area='ONLINE' and ID='FINALBAD'")
            'Me.SubmitMe.Text = "Submit Anyway"
            'Me.SubmitMe.Text.f
            'Me.SubmitMe.Visible = True
            Me.SubmitMe.Visible = False
            Me.litFinalMsg.Text = ds.Rows(0)("Contents")
        Else
            'IF GOOD DATA SUBMIT Right AWAY
            sSQL = "exec usp_ConnWebReferral_Submit '" & Session("UID") & "'," & Session("REFID")
            Call executeSql(sSQL)
            'If Me.lblMsg.Text > "" Then
            'Exit Sub
            'Else
            'Response.Redirect("Referral.aspx")
            'Response.End()
            'End If
            ds = requestDT("Select * from ConnWebContent where Area='ONLINE' and id='FINALGOOD'")
            Me.SubmitMe.Text = "Submit"
            Me.SubmitMe.Visible = True
            If sAddChildInfo > "" Then
                Me.litFinalMsg.Text = ds.Rows(0)("Contents")
                ds = requestDT("Select * from ConnWebContent where Area='ONLINE' and id='FinalGoodHasAdd'")
                Me.litFinalMsg.Text = Me.litFinalMsg.Text & "<br><br>Your referral will be considered upon receipt of the following information:" _
                        & sAddChildInfo & ds.Rows(0)("Contents")
            Else
                Me.litFinalMsg.Text = ds.Rows(0)("Contents")
            End If

        End If
        'Me.litFinalMsg.Text = ds.Rows(0)("Contents")
    End Sub

    Function ValidateData(ByRef dr As DataRow, ByVal sEntity As String, Optional ByVal sarea As String = "", Optional ByVal iMaxSevereLevel As Integer = 99, Optional ByVal sNewLine As String = "<BR>") As String
        Dim iCurrentLevel As Integer
        Dim i As Integer
        Dim sRetv As String
        Dim tMsg As String
        Dim dt As DataTable
        Dim sSQL As String
        sSQL = "exec usp_ValidationRule_get '" & sEntity & "'," _
            & IIf(sarea > "", "'" & sarea & "'", "null") & "," _
            & myDRTostring(dr, "ID")

        dt = requestDT(sSQL)
        sRetv = ""
        iCurrentLevel = 0
        For i = 0 To dt.Rows.Count - 1
            tMsg = Validate1Token(dr, dt.Rows(i))
            If tMsg > "" Then
                sRetv = sRetv & tMsg & sNewLine
                If dt.Rows(i)("SevereLevel") > iCurrentLevel Then iCurrentLevel = dt.Rows(i)("SevereLevel")
                If iCurrentLevel >= iMaxSevereLevel Then Return sRetv
            End If
        Next
        Return sRetv

    End Function

    Public Function UpdateFromForm(ByRef req As System.Web.HttpRequest, ByVal sSPName As String, ByRef retParam As String, ByVal ParamArray addArgms() As String) As String
        Dim i As Int32
        Call addLog(sSPName)
        Dim cn As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings(("CONNECTIONSTRING")))


        '("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;password='';Initial Catalog=pepdev;Data Source=.;") 'Application("ConnectionString"))
        cn.Open()
        Dim cmd As New SqlClient.SqlCommand
        Dim cmd1 As New SqlClient.SqlCommandBuilder

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sSPName
        cmd.Connection = cn ' New SqlClient.SqlConnection(CONNECTIONSTRING)
        cmd1.DeriveParameters(cmd)
        Try
            'Argument from Form
            For i = 0 To cmd.Parameters.Count - 1
                If cmd.Parameters(i).Direction = ParameterDirection.Input Then
                    Call setUSPParamValue(cmd.Parameters(i), req.Form("frmXX" & toGoodSQLArgName(Mid(cmd.Parameters(i).ParameterName, 2))))
                Else
                    cmd.Parameters(i).Value = DBNull.Value
                End If
            Next
            'Additional Arguments that pre-calculated
            For i = 0 To addArgms.Length - 1 Step 2
                Call setUSPParamValue(cmd.Parameters(addArgms(i)), addArgms(i + 1))
            Next
        Catch e As Exception
            Return "Can not assign Parameters:" & e.ToString()
        End Try
        Try
            cmd.ExecuteNonQuery()
        Catch e As Exception
            Return "Can not execute Stored Procedure:" & e.ToString()
        End Try
        If retParam > "" Then retParam = cmd.Parameters(retParam).Value
        cn.Close()
        Return ""
    End Function

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
        cn.Open()
        Dim ds As DataSet = New DataSet
        DA.Fill(ds, "Table0")
        cn.Close()
        Return ds.Tables(0)
        'cn.Close()
    End Function
    Public Function retSingleValue(ByVal sSQL As String)
        Dim dt As New DataTable
        dt = requestDT(sSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return DBNull.Value
        End If
    End Function
    Function hiddenTag(ByVal sName As String, ByVal sValue As String)
        Return "<input type=hidden name=""" & sName & """ value=""" & sValue & """>"
    End Function
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
    Function myDRTostring(ByRef dr As DataRow, ByVal idx As String) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
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
    Function Validate1Token(ByRef drData As DataRow, ByRef drRule As DataRow) As String
        Dim i As Integer, j As Integer
        Dim aryCols() As String
        Dim aryValues() As String
        Select Case UCase(drRule("ValidateType"))
            Case "REQUIRED" : If drData.IsNull(drRule("COLS")) Then Return drRule("ErrMsg") Else Return ""
            Case "REQUIRED ALL"
                aryCols = Split(drRule("Cols"), "|")
                For i = 0 To aryCols.Length - 1
                    If drData.IsNull(aryCols(i)) Then Return drRule("ErrMsg")
                Next
                Return ""
            Case "REQUIRED 1"
                aryCols = Split(drRule("Cols"), "|")
                For i = 0 To aryCols.Length - 1
                    If Not drData.IsNull(aryCols(i)) Then Return ""
                Next
                Return drRule("ErrMsg")

            Case "REQUIRED IF"
                aryCols = Split(drRule("Cols"), "|")
                If Not drData.IsNull(aryCols(0)) Then Return ""
                If validateDataIF(drData, drRule) Then Return drRule("ErrMsg")
                Return ""
            Case "NULL IF"
                aryCols = Split(drRule("Cols"), "|")
                If drData.IsNull(aryCols(0)) Then Return ""
                If validateDataIF(drData, drRule) Then Return drRule("ErrMsg")
                Return ""

            Case "LIST"
                If drData.IsNull(drRule("Cols")) Then Return ""
                If InStr(drRule("ARg1"), "|" & drData(drRule("COLS")) & "|") > 0 Then
                    Return ""
                Else
                    Return drRule("ErrMsg")
                End If
            Case "RANGE"
                If drData.IsNull(drRule("Cols")) Then Return ""
                Select Case UCase(drRule("Arg3"))
                    Case "D"
                        If drData(drRule("COLS")) >= CDate(drRule("Arg1")) And drData(drRule("COLS")) <= CDate(drRule("Arg2")) Then Return ""
                    Case "N"
                        If drData(drRule("COLS")) >= CDbl(drRule("Arg1")) And drData(drRule("COLS")) <= CDbl(drRule("Arg2")) Then Return ""
                    Case Else
                        If drData(drRule("COLS")) >= drRule("Arg1") And drData(drRule("COLS")) <= drRule("Arg2") Then Return ""
                End Select
                Return drRule("ErrMsg")
        End Select
    End Function
    Function validateDataIF(ByRef drData, ByRef drRule) As Boolean
        Dim ValCols As String
        Dim i As Integer, j As Integer
        i = InStr(drRule("Cols"), "|")
        If i = 0 Or i >= Len(drRule("Cols")) Then Return False
        ValCols = Mid(drRule("Cols"), i + 1)
        Select Case UCase(myDRTostring(drRule, "Arg1"))
            Case "VALUE"
                Select Case UCase(drRule("Arg2"))
                    Case "NULL"
                        Return drData.IsNull(ValCols)
                    Case "NOT NULL"
                        Return Not drData.IsNull(ValCols)
                    Case Else
                        If drData.IsNull(ValCols) Then Return False
                        Select Case UCase(myDRTostring(drRule, "Arg3")) 'UCase(drRule("Arg3"))
                            Case "D" : Return drData(ValCols) = CDate((drRule("arg2")))
                            Case "N" : Return drData(ValCols) = CDbl((drRule("arg2")))
                            Case Else
                                Return drData(ValCols) = (drRule("arg2"))
                        End Select
                End Select
            Case "LIST"
                If drData.IsNull(ValCols) Then Return False
                Return InStr(drRule("ARg2"), "|" & drData(ValCols) & "|") > 0
            Case "RANGE"
                If drData.IsNull(ValCols) Then Return False
                Select Case UCase(myDRTostring(drRule, "Arg4")) 'UCase(drRule("Arg4"))
                    Case "D" : Return drData(ValCols) >= CDate((drRule("arg2"))) And drData(ValCols) <= CDate((drRule("arg3")))
                    Case "N" : Return drData(ValCols) >= CDbl((drRule("arg2"))) And drData(ValCols) <= CDbl((drRule("arg3")))
                    Case Else
                        Return drData(ValCols) >= ((drRule("arg2"))) And drData(ValCols) <= ((drRule("arg3")))
                End Select
        End Select
        Return False
    End Function
    Sub setUSPParamValue(ByRef param As SqlClient.SqlParameter, ByVal sFrmValue As String)

        If sFrmValue = "" And param.SqlDbType <> SqlDbType.Bit Then
            'addLog()
            param.Value = DBNull.Value
            Exit Sub
        End If
        Select Case param.SqlDbType
            Case SqlDbType.BigInt, SqlDbType.Float, SqlDbType.Int, SqlDbType.Money, SqlDbType.Real, SqlDbType.SmallInt, SqlDbType.Money, SqlDbType.TinyInt
                If IsNumeric(sFrmValue) And sFrmValue > "" Then
                    param.Value = CDbl(sFrmValue)
                Else
                    param.Value = DBNull.Value
                End If
            Case SqlDbType.SmallDateTime, SqlDbType.DateTime
                If IsDate(sFrmValue) Then
                    param.Value = CDate(sFrmValue)
                Else
                    param.Value = DBNull.Value
                End If
            Case SqlDbType.Bit
                If sFrmValue > "" Then
                    param.Value = True
                Else
                    param.Value = False
                End If
            Case SqlDbType.Char, SqlDbType.VarChar
                param.Value = Left(sFrmValue, param.Size)
            Case SqlDbType.NChar, SqlDbType.NVarChar
                param.Value = Left(sFrmValue, param.Size / 2)
            Case Else
                param.Value = sFrmValue
        End Select
    End Sub
    Function toGoodSQLArgName(ByVal sV As String) As String
        Return sV
    End Function

End Class