Imports Microsoft.VisualBasic
Imports System.Data

Public Module mobUtil
    'Public oGenutil As New clsGenutil()
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
    Function QuoteMe(ByVal sV As String) As String
        Return Replace(sV, """", "&quot;")
    End Function
    Function rsMulRows(ByVal rs As System.Data.DataTable, ByVal bIncludeID As Boolean, ByVal sName As String, ByVal sV As String, ByVal sAddInfo As String, ByVal iRow As Integer) As String
        Dim cc As Int16
        Dim sRetv As String
        If UCase(Left(sName, 4)) <> "FRMXX" Then sName = "frmXX" & sName
        sRetv = "<table width=100% cellpadding=0 cellspacing=0 class=bodytext>" _
            & "<input type=hidden name='" & sName & "' " & sAddInfo & " value=""" & QuoteMe(sV) & """>"
        cc = 0
        For cc = 1 To rs.Rows.Count
            If cc Mod iRow = 1 Then sRetv = sRetv & "<tr>"
            sRetv = sRetv & "<td><input type=checkbox name='CHK:" & sName & ":" & rs.Rows(cc - 1)("ID") & "' onclick='appndSEL();'"
            If InStr(", " & UCase(sV) & ", ", ", " & UCase(rs.Rows(cc - 1)("ID")) & ", ") > 0 Then sRetv = sRetv & " Checked"
            sRetv = sRetv & ">"
            If bIncludeID Then sRetv = sRetv & "<b>" & rs.Rows(cc - 1)("ID") & "</b> - "
            sRetv = sRetv & rs.Rows(cc - 1)("Description") & "</td>"
            If cc Mod iRow = 0 Then sRetv = sRetv & "</tr>"
            'rs.movenext()
        Next
        If cc Mod iRow <> 0 Then sRetv = sRetv & "</tr>"
        Return sRetv & "</table>"
    End Function

    Function lookupMulRows(ByVal sTable As String, ByVal bIncludeID As Boolean, ByVal sName As String, ByVal sV As String, ByVal sAddInfo As String, ByVal iRow As Integer) As String
        Dim rs As DataTable
        Dim sSQL As String
        sSQL = "exec usp_looupValue_GetList '" & Replace(sTable, "'", "''") & "'"
        rs = requestDT(sSQL)
        Return rsMulRows(rs, bIncludeID, sName, sV, sAddInfo, iRow)
    End Function
    Function sendMail(ByVal sTo As String, ByVal sCC As String, ByVal sSubject As String, ByVal sBody As String) As String
        'oMsg.Body = sBody
        'oMsg.To = sTo
        'oMsg.Cc = sCC
        'oMsg.Subject = sSubject
        'oMsg.BodyFormat = Mail.MailFormat.Text
        Dim sSQL As String = "exec usp_email '" & Replace(sTo, "'", "''") _
            & "','" & Replace(sCC, "'", "''") & "','" & Replace(sSubject, "'", "''") _
            & "','" & Replace(sBody, "'", "''") & "'"

        Try
            'System.Web.Mail.SmtpMail.Send(ConfigurationSettings.AppSettings("MailMaster"), sTo, sSubject, sBody)
            Call executeSql(sSQL)
            Return ""
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Function properOneWord(ByVal ttmpStr As String) As String
        If Len(ttmpStr) < 2 Then Return UCase(ttmpStr)
        If ttmpStr = "II" Or ttmpStr = "III" Or ttmpStr = "IV" _
               Or ttmpStr = "VI" Or ttmpStr = "VII" _
               Or ttmpStr = "ATC" Or ttmpStr = "QA" _
               Or ttmpStr = "EIC" Or ttmpStr = "DTC" _
               Or ttmpStr = "RN" Or ttmpStr = "LPN" _
               Or ttmpStr = "DAS" Or ttmpStr = "GH" _
               Or ttmpStr = "CSP" Or ttmpStr = "PEP" _
               Or ttmpStr = "ESC" Or ttmpStr = "BTH" Then
            Return ttmpStr
        Else
            Return UCase(Left(ttmpStr, 1)) & LCase(Mid(ttmpStr, 2))
        End If
    End Function
    Public Function proper(ByVal ttmpStr As String) As String
        'Dim aryWords() As String
        Dim i As Integer
        Dim sREtv As String
        Dim sSEp As String, sWord As String, ch As String
        If Trim(ttmpStr & "") = "" Then
            proper = ""
            Exit Function
        End If
        sREtv = "" : sSEp = "" : sWord = ""

        For i = 1 To Len(ttmpStr)
            ch = Mid(ttmpStr, i, 1)
            If (ch >= "a" And ch <= "z") Or (ch >= "A" And ch <= "Z") Then
                sWord = sWord & ch
            Else
                If sWord > "" Or sSEp > "" Then sREtv = sREtv & sSEp & properOneWord(sWord)
                sSEp = ch
                sWord = ""
            End If
        Next
        If sWord > "" Or sSEp > "" Then sREtv = sREtv & sSEp & properOneWord(sWord)
        Return sREtv
    End Function
    Public Function ComboSource(ByRef oCopmbo As System.Web.UI.WebControls.DropDownList, ByVal sSQL As String, ByVal ParamArray aryAddARgm() As String) As String
        Dim dt As DataTable
        Dim i As Integer
        Dim j As Integer
        Dim p As Integer
        Dim aryID As String
        Dim dr As DataRow
        Dim aryValue As String
        dt = requestDT(sSQL)
        j = dt.Columns.Count - 1
        For i = 0 To aryAddARgm.Length - 1
            p = InStr(aryAddARgm(i), "|")
            If p = 0 Then
                aryID = aryAddARgm(i)
                aryValue = ""
            Else
                aryID = Left(aryAddARgm(i), p - 1)
                aryValue = Mid(aryAddARgm(i), p + 1)
            End If
            Select Case UCase(aryID)
                Case "PROPER"
                    For p = 0 To dt.Rows.Count - 1
                        dt.Rows(p)(j) = proper(dt.Rows(p)(j) & "")
                    Next
                Case "ADD BLANK"
                    dr = dt.NewRow()
                    dr(0) = DBNull.Value
                    If dt.Columns.Count > 1 Then dr(1) = "--Select--"
                    dt.Rows.InsertAt(dr, 0)
            End Select
        Next
        oCopmbo.DataSource = dt
        oCopmbo.DataTextField = dt.Columns(j).ColumnName
        oCopmbo.DataValueField = dt.Columns(0).ColumnName
        oCopmbo.DataBind()
        Return ""
    End Function
    Public Function InputTag(ByVal sTYpe As String, ByVal sName As String, ByVal sValue As String, ByVal sAddInfo As String, ByVal ParamArray AddInfo() As String) As String
        Dim sRetv As String = ""
        Select Case UCase(sTYpe)
            Case "YN"
                sRetv = "<input type=radio name=""" & sName & """ value=""Y""" _
                    & IIf(sValue = "Y", " Checked", "") _
                    & " " & sAddInfo & ">Yes &nbsp;&nbsp;" _
                    & "<input type=radio name=""" & sName & """ value=""N""" _
                    & IIf(sValue = "N", " Checked", "") _
                    & " " & sAddInfo & ">No"
            Case "TEXT"
                sRetv = "<input type=text name=""" & sName & """ value=""" & sValue & """" _
                    & " " & sAddInfo & ">"

        End Select
        Return sRetv
    End Function
    Public Function getSecurityASP(ByRef request As System.Web.HttpRequest, ByVal sAppId As String, ByVal sFunctID As String) As Int32
        Dim sASPSession As String
        Dim sSQL As String
        sASPSession = ""
        Try
            sASPSession = request.QueryString("ASPSessionID")
        Catch e As Exception
            'do not care if 
        End Try
        sSQL = "exec usp_SessionState_getSecurityASP " _
            & IIf(sASPSession > "", "'" & Replace(sASPSession, "'", "''") & "',", "null,") _
            & "'" & Replace(sAppId, "'", "''") & "','" & Replace(sFunctID, "'", "''") & "'"
        Return retSingleValue(sSQL)
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
    Function AddTopLink(ByVal sUrl As String, ByVal sLabel As String, ByVal sTitle As String, ByVal bCurrent As Boolean) As String
        Dim sRetv As String

        sRetv = "<a class=""TopCenterLinks"
        If bCurrent Then sRetv = sRetv & "Current"
        sRetv = sRetv & """"
        If sTitle > "" Then sRetv = sRetv & " title=""" & sTitle & """"
        sRetv = sRetv & "  href='" & sUrl & "'>[" & Replace(sLabel, " ", "&nbsp;") & "]</a>"
        Return sRetv
    End Function
    Function getTopLink(ByVal FunctionName As String, ByVal CurrentTag As String) As String
        Select Case UCase(FunctionName)
            Case "PROFILE" : Return "<table class=bodytext width=100%><tr><td>" _
                    & AddTopLink("ProfilePWD.aspx", "Password", "Change Password", CurrentTag = "PWD") _
                    & "</td><td>" & AddTopLink("Profile.aspx", "Personal Info", "Personal Information", CurrentTag = "PER") _
                    & "</td><td>" & AddTopLink("ProfileAGENCY.aspx", "Agency Info", "Agency Information", CurrentTag = "AGENCY") _
                    & "</td></tr></table>"
            Case "REFF" : Return "<table class=bodytext width=100%><tr><td>" _
                    & AddTopLink("javascript:submitWithValue(""NextPage"",""DEMO"");", "Demographic", "Demographic Information", CurrentTag = "DEMO") _
                    & "</td><td>" & AddTopLink("javascript:submitWithValue(""NextPage"",""COMM"");", "Community", "Community Information", CurrentTag = "COMM") _
                    & "</td><td>" & AddTopLink("javascript:submitWithValue(""NextPage"",""MENTAL"");", "Mental Health", "Mental Health Information", CurrentTag = "MENTAL") _
                                        & "</td></tr></table>"
                '& "</td><td>" & AddTopLink("javascript:submitWithValue(""NextPage"",""REFF"");", "Referral", "Referral Information", CurrentTag = "REFF") _
        End Select
    End Function
    Function toGoodSQLArgName(ByVal sV As String) As String
        Return sV
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
    Function hiddenTag(ByVal sName As String, ByVal sValue As String)
        Return "<input type=hidden name=""" & sName & """ value=""" & sValue & """>"
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
    'Function myDRTostring(ByRef dr As DataRow, ByVal idx As Integer) As String
    '    If dr.IsNull(idx) Then Return ""
    '    Return dr(idx) & ""
    'End Function
    Function myDRTostring(ByRef dr As DataRow, ByVal idx As String) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
    End Function
    Public Sub PaintScreen(ByRef pge As System.Web.UI.Page, ByRef dt As DataTable)
        Dim i As Int32
        Dim j As Integer
        Dim oCtl As System.Web.UI.Control
        'Dim oCtlLit As System.Web.UI.LiteralControl
        Dim oCtlTxt As System.Web.UI.WebControls.TextBox
        Dim oCtlLit As System.Web.UI.WebControls.Literal
        Dim oCtlLbl As System.Web.UI.WebControls.Label
        Dim oCtlRadio As System.Web.UI.WebControls.RadioButtonList
        Dim oCtlDropDown As System.Web.UI.WebControls.DropDownList
        Dim oCtlcheckBox As System.Web.UI.WebControls.CheckBox
        Dim oCtlName As String
        For i = 0 To dt.Columns.Count - 1
            oCtlName = "frmXX" & dt.Columns.Item(i).ColumnName
            oCtl = pge.FindControl(oCtlName)
            If TypeOf (oCtl) Is System.Web.UI.WebControls.TextBox Then
                oCtlTxt = CType(oCtl, System.Web.UI.WebControls.TextBox)
                oCtlTxt.Text = myDRTostring(dt.Rows(0), i)

                'Exit For
            ElseIf TypeOf (oCtl) Is System.Web.UI.WebControls.Literal Then
                oCtlLit = CType(oCtl, System.Web.UI.WebControls.Literal)
                oCtlLit.Text = myDRTostring(dt.Rows(0), i)
            ElseIf TypeOf (oCtl) Is System.Web.UI.WebControls.Label Then
                oCtlLbl = CType(oCtl, System.Web.UI.WebControls.Label)
                oCtlLbl.Text = myDRTostring(dt.Rows(0), i)
            ElseIf TypeOf (oCtl) Is System.Web.UI.WebControls.CheckBox Then
                oCtlcheckBox = CType(oCtl, System.Web.UI.WebControls.CheckBox)
                If dt.Rows(0).IsNull(i) Then
                    oCtlcheckBox.Checked = False
                ElseIf dt.Rows(0)(i) Then
                    oCtlcheckBox.Checked = True
                Else
                    oCtlcheckBox.Checked = False
                End If

            ElseIf TypeOf (oCtl) Is System.Web.UI.WebControls.RadioButtonList Then
                oCtlRadio = CType(oCtl, System.Web.UI.WebControls.RadioButtonList)
                For j = 0 To oCtlRadio.Items.Count - 1
                    If dt.Rows(0)(i) & "" = oCtlRadio.Items(j).Value & "" Then
                        oCtlRadio.Items(j).Selected = True
                        j = oCtlRadio.Items.Count - 1
                    End If
                Next
            ElseIf TypeOf (oCtl) Is System.Web.UI.WebControls.DropDownList Then
                oCtlDropDown = CType(oCtl, System.Web.UI.WebControls.DropDownList)
                For j = 0 To oCtlDropDown.Items.Count - 1
                    If dt.Rows(0)(i) & "" = oCtlDropDown.Items(j).Value & "" Then
                        oCtlDropDown.Items(j).Selected = True
                        j = oCtlDropDown.Items.Count - 1
                    End If
                Next
            End If
        Next
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

    Public Function SQLQuote(ByVal vValue As VariantType, ByVal sType As String) As String
        If Trim(CStr(vValue)) & "" = "" Then
            Return "NULL"
        Else
            Select Case sType
                Case "TEXT" : Return "'" & Replace(vValue, "'", "''") & "'"
                Case "DATE" : Return "'" & CStr(vValue) & "'"
                Case "NUM" : Return CStr(vValue)
            End Select
        End If
    End Function

    Public Function SQLQuoteDefault(ByVal vValue As VariantType, ByVal sType As String, ByVal sDefault As VariantType) As String
        If Trim(CStr(vValue)) & "" = "" Then
            Return sDefault
        Else
            Select Case sType
                Case "TEXT" : Return "'" & Replace(vValue, "'", "''") & "'"
                Case "DATE" : Return "'" & CStr(vValue) & "'"
                Case "NUM" : Return CStr(vValue)
            End Select
        End If
    End Function
    Public Function requestConnection() As SqlClient.SqlConnection
        Return New SqlClient.SqlConnection(ConfigurationSettings.AppSettings(("CONNECTIONSTRING")))
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

    Private Function AddOneLink(ByVal sLabel As String, ByVal sTitle As String, ByVal sLink As String, ByVal bCurrent As Boolean, ByVal bSecured As Boolean)
        'If bCurrent Then
        'Return "<tr valign=bottom class=""sideLinks1Current""  title=""" & sTitle & """>" _
        '                & "<td>" _
        '                & "<STRONG>" & sLabel & "</STRONG>" _
        ' '               & "</td>" _
        '                & "</tr>"
        'Else
        Return "<tr valign=bottom class=""sideLinks1"">" _
            & "<td><A class=""" & IIf(bCurrent, "sideLinks1Current", "sideLinks1") & """ title=""" _
            & sTitle & """ href=""" & IIf(bSecured, ConfigurationSettings.AppSettings("ROOT_DIRECTORY_SECURE"), ConfigurationSettings.AppSettings("ROOT_DIRECTORY")) & "/" & sLink & """>" & sLabel & "</a>" _
            & "</td>" _
            & "</tr>"

        'End If
    End Function
    Private Function addLeftImage(ByVal iImgID As Integer) As String
        Return "<tr align=center>" _
            & "<td><img src=""Images/Cand" & iImgID & ".jpg"" border=""0"" style=""height:110px;width:145px;"" /></td>" _
            & "</tr>"
    End Function
    Public Function getSideLink(ByVal sID As String) As String
        Dim sRetv As String
        Dim img1 As Integer, img2 As Integer
        Call rand2Number(img1, img2, 10)
        'Me.IMGLeft1.ImageUrl = "Images/Cand" & CStr(img1) & ".jpg"
        'Me.IMGLeft2.ImageUrl = "Images/Cand" & CStr(img2) & ".jpg"

        'sRetv = "<table cellpadding=0 cellspacing=0>" _
        '    & AddOneLink("Connections Home", "Connections Home", "Index.aspx", sID = "CONN", False) _
        '    & AddOneLink("Latest News", "Latest News", "LatestNews.aspx", sID = "NEWS", False) _
        '    & AddOneLink("Admission Criteria", "Admission Criteria", "AdmissionCriteria.aspx", sID = "ADM", False) _
        '    & AddOneLink("Staff", "Staff Directory", "Staff.aspx", sID = "STAFF", False) _
        '    & AddOneLink("On Line Referral", "On Line Referral", "Referral.aspx", sID = "REFF", True) _
        '    & AddOneLink("Contact Us", "Contact Us", "ContactUS.aspx", sID = "CONTACTUS", False) _
        '    & addLeftImage(img1) & "<tr height=8><td></td></tr>" _
        '    & addLeftImage(img2) _
        '    & "</table>"
        sRetv = "<table cellpadding=0 cellspacing=0>" _
            & AddOneLink("Connections Home", "Connections Home", "Index.aspx", sID = "CONN", False) _
            & AddOneLink("Latest News", "Latest News", "LatestNews.aspx", sID = "NEWS", False) _
            & AddOneLink("Admission Criteria", "Admission Criteria", "AdmissionCriteria.aspx", sID = "ADM", False) _
            & AddOneLink("Staff", "Staff Directory", "Staff.aspx", sID = "STAFF", False) _
            & AddOneLink("On Line Referral", "On Line Referral", "Referral.aspx", sID = "REFF", True) _
            & AddOneLink("Contact Us", "Contact Us", "ContactUS.aspx", sID = "CONTACTUS", False) _
            & "</table>"

        Return sRetv

    End Function
    Function LookupDesc(ByVal sTbl As String, ByVal sIDF As String, ByVal sDESCF As String, ByVal sID As String, Optional ByVal sType As String = "YY") As String
        Dim sSQL As String
        Dim dt As DataTable
        If sID & "" = "" Then Return ""
        If sID = "Null" Then Return ""
        If sIDF = "LUD" And sDESCF = "LUV" Then
            sSQL = "Select Description from lookupValue where entity='" & sTbl & "' and ID= '" & Replace(sID, "'", "''") & "'"
        Else
            sSQL = "Select [" & sDESCF & "] from [" & sTbl & "] where [" & sIDF & "] = '" & Replace(sID, "'", "''") & "'"
        End If
        dt = requestDT(sSQL)
        If dt.Rows.Count > 0 Then
            If sType = "YY" Then
                Return sID & " - " & dt.Rows(0)(0)
            Else
                Return dt.Rows(0)(0)
            End If
        Else
            If sType = "YY" Then
                Return sID & " - No Match"
            Else
                Return "no Match"
            End If
        End If
    End Function
    Function LookupDescM(ByVal sTbl As String, ByVal sIDF As String, ByVal sDESCF As String, ByVal sID As String, Optional ByVal sType As String = "YY") As String
        Dim sRetev As String
        Dim arysIDF
        Dim i As Integer
        arysIDF = Split(sID, ",")
        sRetev = ""
        For i = LBound(arysIDF) To UBound(arysIDF)
            If Trim(arysIDF(i)) > "" Then sRetev += ", " & LookupDesc(sTbl, sIDF, sDESCF, Trim(arysIDF(i)), sType)
        Next
        If sRetev > "" Then sRetev = Mid(sRetev, 3)
        Return sRetev
    End Function
    Public Sub rand2Number(ByRef id1 As Integer, ByRef id2 As Integer, ByVal iMax As Integer)
        Randomize()
        id1 = Int(Rnd() * iMax) + 1
        id2 = Int(Rnd() * iMax) + 1
        Do While id2 = id1
            id2 = Int(Rnd() * iMax) + 1
        Loop

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

End Module
