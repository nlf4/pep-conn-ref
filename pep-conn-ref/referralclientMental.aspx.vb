Public Class referralclientMental
    Inherits System.Web.UI.Page

    Private Function ValidateInput(ByVal sArea As String) As String
        If Session("REFID") = "" Then Response.Redirect("Login.aspx")
        Dim ds As DataTable
        ds = requestDT("exec usp_ConWebReferral_GetRecord " & Session("REFID"))
        If ds.Rows(0)("RefBy") <> Session("UID") Then Response.Redirect("Login.aspx")
        Return ValidateData(ds.Rows(0), "CONNWEB:Referral", sArea)
    End Function
    Private Sub HasPostBack()
        Dim sProblemARY As String
        Dim ttt As String
        For Each ttt In Request.Form
            If Left(ttt, 2) = "P:" Then
                If Request.Form(ttt) = "on" Then sProblemARY = sProblemARY & "," & CStr(Mid(ttt, 3))
            End If
        Next

        Me.lblMsg.Text = UpdateFromForm(Request, "usp_ConnWebReferral_Update_MENTAL", "", "@ProblemARY", sProblemARY)
        If Me.lblMsg.Text > "" Then Exit Sub
        Me.lblMsg.Text = ValidateInput("Mental Health")
        If Me.lblMsg.Text <> "" Then
            Me.lblMsg.Text = retSingleValue("Select Contents from ConnWebContent where Area='ONLINE' and ID='BADINPUT'") & "<BR>" & Me.lblMsg.Text
        Else
            Me.lblMsg.Text = "Record updated."
        End If

        If Request.Form("PrevMe") <> "" Then Response.Redirect("ReferralClientCOMM.aspx")
        If Request.Form("SubmitMe") <> "" Then Response.Redirect("ReferralClientFinal.aspx")
        If Request.Form("NextPage") <> "" Then Response.Redirect("ReferralClient" & Request.Form("NextPage") & ".aspx")
    End Sub
    Function paint1Problem(ByRef dr As DataRow, ByRef sProblemAry As String, ByVal bIndent As Integer) As String
        Return "<tr valign=top><td>" & IIf(bIndent > 0, "", "") _
                & "<input type=checkbox name=P:" & dr("ID") _
                & IIf(InStr(sProblemAry, "," & dr("ID") & ",") > 0, " Checked", "") & "></td><td>" & dr("Problems") & "</td></tr>"

    End Function
    Private Sub showProblem(ByVal sProblemAry As String)
        Dim dt As DataTable
        Dim iSep As Integer, i As Integer
        Dim sRetv As String = ""
        sProblemAry = "," & sProblemAry & ","
        dt = requestDT("exec usp_ConnWebProblemList_getlist")

        iSep = Int(dt.Rows.Count / 2) + 1
        For i = 0 To dt.Rows.Count - 1
            If i Mod iSep = 0 Then
                If i = 0 Then
                    sRetv = sRetv & "<td><table class=bodytext>"
                Else
                    sRetv = sRetv & "</table></td><td><table class=bodytext>"
                End If
            End If
            sRetv = sRetv & paint1Problem(dt.Rows(i), sProblemAry, (i Mod 2))
        Next
        Me.LitProblems.Text = sRetv & "</table></td>"
    End Sub
    Function Paint1Service(ByVal sLabel As String, ByVal sName As String, ByVal sValue As String) As String
        Return "<tr align=center><td class=labelLeftreq>" & sLabel _
            & ":&nbsp;</td><td><input type=Radio name='" & sName & "' value='N'" & IIf(sValue = "N", " checked", "") _
            & "></td><td><input type=Radio name='" & sName & "' value='0'" & IIf(sValue = "0", " checked", "") _
            & "></td><td><input type=Radio name='" & sName & "' value='1'" & IIf(sValue = "1", " checked", "") _
            & "></td><td><input type=Radio name='" & sName & "' value='2'" & IIf(sValue = "2", " checked", "") _
            & "></td><td><input type=Radio name='" & sName & "' value='x'" & IIf(sValue = "x", " checked", "") _
           & "></td></tr>"
    End Function
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("REFID") = "" Then Response.Redirect("Login.aspx")
        Dim ds As DataTable

        'Dim x
        Dim i As Integer
        If getSecurity(Session, "CWAdmin", "CONWEBUSER") <> 0 Then
        Else
            Response.Redirect(ConfigurationSettings.AppSettings("ROOT_DIRECTORY_SECURE") & "/Login.aspx")
        End If
        If Me.IsPostBack Then
            Call HasPostBack()
        Else
            'ComboSource(Me.frmXXDSMIV1, "SELECT Code, Description FROM ConnReferralDsm", "Add Blank", "Proper")
            'Me.frmXXDSMIV2.DataSource = Me.frmXXDSMIV1.DataSource
            'Me.frmXXDSMIV2.DataTextField = "Description"
            'Me.frmXXDSMIV2.DataValueField = "Code"
            'Me.frmXXDSMIV2.DataBind()
            'Me.frmXXDSMIV3.DataSource = Me.frmXXDSMIV1.DataSource
            'Me.frmXXDSMIV3.DataTextField = "Description"
            'Me.frmXXDSMIV3.DataValueField = "Code"
            'Me.frmXXDSMIV3.DataBind()
        End If
        Me.lblUser.Text = Session("UName") & " - " & Session("AgencyName") & " - Referral/Mental Health Information '" & Session("ClientName") & "'"
        'If Request.QueryString("NEWUSER") = "YES" Then Me.lblUser.Text=Me.lblUser.Text & 
        'Me.lblLeftLink.Text = getSideLink("REFF")
        'Me.LblTopLink.Text = getTopLink("REFF", "MENTAL")

        ds = requestDT("exec usp_ConWebReferral_GetRecord " & Session("REFID"))
        If ds.Rows(0)("RefBy") <> Session("UID") Then Response.Redirect("Login.aspx")

        Call PaintScreen(Me, ds)
        Call showProblem(ds.Rows(0)("ProblemARY") & "")
        'Me.litService.Text = Paint1Service("Private Mental Health Professional", "frmXXMHSHPrivatePratice", ds.Rows(0)("MHSHPrivatePratice") & "") _
        '   & Paint1Service("Psychiatric Hospital", "frmXXMHSHPrivateHospital", ds.Rows(0)("MHSHPrivateHospital") & "") _
        '   & Paint1Service("Positive Education Program", "frmXXMHSHThisAgency", ds.Rows(0)("MHSHThisAgency") & "") _
        '  & Paint1Service("Other Community Agency", "frmXXMHSHOtherCmtAgcy", ds.Rows(0)("MHSHOtherCmtAgcy") & "") _
        ' & Paint1Service("Residential TreatmentFacility", "frmXXMHSHResTxFacility", ds.Rows(0)("MHSHResTxFacility") & "") _
        ' & "<tr align=center><td class=labelleftreq>Other:<input type=text name=frmXXMHSHOtherDesc value=""" & ds.Rows(0)("MHSHOtherDesc") _
        ' & """></td><td></td>" _
        ' & "<td><input type=radio name=frmXXMHSHOther value='0' " & IIf(ds.Rows(0)("MHSHOther") & "" = "0", "checked", "") _
        ' & "></td><td><input type=radio name=frmXXMHSHOther value='1' " & IIf(ds.Rows(0)("MHSHOther") & "" = "1", "checked", "") _
        ' & "></td><td><input type=radio name=frmXXMHSHOther value='2' " & IIf(ds.Rows(0)("MHSHOther") & "" = "2", "checked", "") _
        ' & "></td><td><input type=radio name=frmXXMHSHOther value='x' " & IIf(ds.Rows(0)("MHSHOther") & "" = "x", "checked", "") _
        ' & "></td></tr>"
        If ds.Rows(0)("Status") = "Incomplete" Then
            Me.SubmitMe.Visible = True
        Else
            Me.SubmitMe.Visible = False
        End If
        Me.hiddenFormList.Text = hiddenTag("NextPage", "") & hiddenTag("frmXXID", ds.Rows(0)("ID")) & hiddenTag("frmXXUID", Session("UID"))
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
    Function hiddenTag(ByVal sName As String, ByVal sValue As String)
        Return "<input type=hidden name=""" & sName & """ value=""" & sValue & """>"
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
    Function myDRTostring(ByRef dr As DataRow, ByVal idx As String) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
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
    Function toGoodSQLArgName(ByVal sV As String) As String
        Return sV
    End Function


End Class