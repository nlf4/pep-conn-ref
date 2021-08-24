Public Class referralclientCOMM
    Inherits System.Web.UI.Page

    Private Function ValidateInput(ByVal sArea As String) As String
        If Session("REFID") = "" Then Response.Redirect("onlinereferral.aspx")
        Dim ds As DataTable
        ds = requestDT("exec usp_ConWebReferral_GetRecord " & Session("REFID"))
        If ds.Rows(0)("RefBy") <> Session("UID") Then Response.Redirect("onlinereferral.aspx")
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

        If Session("REFID") = "" Then Response.Redirect("onlinereferral.aspx")
        Dim ds As DataTable

        'Dim x
        Dim i As Integer
        If getSecurity(Session, "CWAdmin", "CONWEBUSER") <> 0 Then
        Else
            Response.Redirect(ConfigurationSettings.AppSettings("ROOT_DIRECTORY_SECURE") & "/onlinereferral.aspx")
        End If
        If Me.IsPostBack Then
            Call HasPostBack()
        Else
            'ComboSource(Me.frmXXDistrict, "select DistrictName from ConnReferralDistricts", "Add Blank")
            'Me.l() 'ComboSource(Me.frmXXEduPlacement, "SELECT EdPlcCode, ConnwebDesc FROM EducationalPlacementType order by DispSeq", "Add Blank")
            'ComboSource(Me.frmXXGrade, "SELECT EdCode, EdLevel FROM EducationalLevels", "Add Blank")
        End If
        Me.lblUser.Text = Session("UName") & " - " & Session("AgencyName") & " - Referral/Community Information for '" & Session("ClientName") & "'"
        'If Request.QueryString("NEWUSER") = "YES" Then Me.lblUser.Text=Me.lblUser.Text & 
        'Me.lblLeftLink.Text = getSideLink("REFF")
        'Me.LblTopLink.Text = getTopLink("REFF", "COMM")
        'If Session("IID") > "" Then
        'Me.f()

        ds = requestDT("exec usp_ConWebReferral_GetRecord " & Session("REFID"))
        If ds.Rows(0)("RefBy") <> Session("UID") Then Response.Redirect("onlinereferral.aspx")
        'If ds.Rows(0).IsNull("EduPlacement") Then
        'Me.litEduPlacement.Text = rsMulRows(requestDT("select ID,description from lookupValue where entity='IEP'  order by seq"), False, "EduPlacement", "", "", 2)
        'Else
        '    Me.litEduPlacement.Text = rsMulRows(requestDT("select ID,description from lookupValue where entity='IEP'  order by seq"), False, "EduPlacement", ds.Rows(0)("EduPlacement"), "", 2)
        'End If

        Call PaintScreen(Me, ds)
        '& paint1SYSINV("12", "School in which enrolled", "School", ds.Rows(0), "Contact") _

        'Me.LitSYSINV.Text = _
        '    paint1SYSINV("1", "CCDCFS", "Worker's&nbsp;Name", ds.Rows(0)) _
        '   & paint1SYSINV("2", "Ohio Dept. Youth Srv.", "Worker's&nbsp;Name", ds.Rows(0)) _
        ' & paint1SYSINV("3", "Community Agency", "Agency&nbsp;Name", ds.Rows(0), "Contact") _
        ' & paint1SYSINV("4", "Juvenile Court", "P&nbsp;O&nbsp;'s&nbsp;Name", ds.Rows(0)) _
        ' & paint1SYSINV("5", "Juvenile Court Diversion", "Contact's&nbsp;Name", ds.Rows(0)) _
        '& paint1SYSINV("6", "Board of MR/DD", "Worker's&nbsp;Name", ds.Rows(0)) _
        ' & paint1SYSINV("7", "Private Hospital/Healthcare Provider", "Contact", ds.Rows(0)) _
        '& paint1SYSINV("8", "Private MH Professional", "Name", ds.Rows(0)) _
        '& paint1SYSINV("9", "Mobile Crisis Team", "Contact", ds.Rows(0)) _
        ' & paint1SYSINV("10", "Alcohol and Drug Addiction Services", "Contact", ds.Rows(0)) _
        '& paint1SYSINV("11", "Bureau Of Voc Rehab", "Contact", ds.Rows(0)) _
        '& paint1SYSINV("13", "Guardian ad Litem(GAL)", "Name", ds.Rows(0)) _
        '& paint1SYSINV("14", "Other", "Other", ds.Rows(0))
        'Me.litNoPlacement.Text = paint1NoPlacement("1", "Emergency Shelter", ds.Rows(0)) _
        '& paint1NoPlacement("2", "Foster Home", ds.Rows(0)) _
        '& paint1NoPlacement("3", "Adoptive Home", ds.Rows(0)) _
        '& paint1NoPlacement("4", "Detention Home", ds.Rows(0)) _
        '& paint1NoPlacement("5", "Residential Treatment", ds.Rows(0)) _
        '& paint1NoPlacement("6", "Psychiatric Hospitalization", ds.Rows(0)) _
        '& paint1NoPlacement("7", "Group Home", ds.Rows(0)) _
        '& paint1NoPlacement("8", "Correctional Facility", ds.Rows(0)) _
        '& paint1NoPlacement("10", "Relative Home", ds.Rows(0)) _
        '& paint1NoPlacement("9", "Other", ds.Rows(0), " Please specify:")
        Me.litNoPlacement.Text = paint1NoPlacement("5", "Residential treatment centers", ds.Rows(0)) _
                & paint1NoPlacement("6", "Inpatient Psychiatric Hospitals", ds.Rows(0)) _
                & paint1NoPlacement("10", "Relative Home", ds.Rows(0)) _
                & paint1NoPlacement("3", "Adoptive Home", ds.Rows(0)) _
                & paint1NoPlacement("2", "Foster Home", ds.Rows(0)) _
                & paint1NoPlacement("4", "Detention Center", ds.Rows(0)) _
                & paint1NoPlacement("11", "Crisis Stabilization", ds.Rows(0)) _
                & paint1NoPlacement("1", "Shelter Care", ds.Rows(0)) _
                & paint1NoPlacement("12", "Orphanage", ds.Rows(0)) _
                & paint1NoPlacement("8", "Correctional Facility", ds.Rows(0)) _
                & paint1NoPlacement("7", "Group Home", ds.Rows(0)) _
                & paint1NoPlacement("9", "Other", ds.Rows(0)) ', " Please specify:")
        Me.litNoPlacement.Text += "<tr><td class=labelLeftreq>Other Specify:&nbsp;</td><td>" _
            & InputTag("Text", "frmXXNoPlacement9SPY", ds.Rows(0)("NoPlacement9SPY") & "", "size=45 maxlength='100'")



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
    Private Function paint1NoPlacement(ByVal idx As String, ByVal labelLeft As String, ByVal dr As DataRow, Optional ByVal otherLbl As String = "") As String
        Dim sRetv As String = "<tr><td class=labelLeftreq>" & labelLeft & ":&nbsp;</td><td>" _
            & InputTag("Text", "frmXXNoPlacement" & idx, dr("NoPlacement" & idx) & "", "size='2'")
        If otherLbl & "" > "" Then
            sRetv += otherLbl & InputTag("Text", "frmXXNoPlacement" & idx & "SPY", dr("NoPlacement" & idx & "SPY") & "", "size=20")
        End If
        Return sRetv & "</td></tr>"
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

End Class