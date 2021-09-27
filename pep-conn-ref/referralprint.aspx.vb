Public Class referralprint
    Inherits System.Web.UI.Page

    Sub Write1Line(ByVal sLabel As String, ByVal sData As Object)
        Response.Write("<tr valign=top><td class=labelLeftreq>" & sLabel & ":&nbsp;</td><td>" & sData & "</td></tr>")
    End Sub
    Sub Write1LineX(ByVal sLabel As String, ByRef dr As DataRow, ByVal sIdx As String)
        Dim sData As String
        sData = myDRTostring(dr, "SYSINV" & sIdx)
        If sData = "Y" Then
            sData += " - " & myDRTostring(dr, "SYSINVName" & sIdx) & " [" & myDRTostring(dr, "SYSINVContactPhone" & sIdx) & "]"
            If sIdx = "3" Then sData += " (" & myDRTostring(dr, "SYSINVNameAdd" & sIdx) & ")"
        End If
        Write1Line(sLabel, sData)
    End Sub
    Sub ShowDemo(ByRef dr As DataRow)
        Response.Write("<tr class=Header><td>Demographic Information</td></tr><tr><td><table width=100% class=bodytext><colgroup width=50% span=2>")
        Write1Line("Name", dr("LName") & ", " & dr("FName") & " " & dr("MI") & " " & dr("Suffix"))
        Write1Line("Address", dr("Address") & IIf(dr.IsNull("Address2"), "", "<br>" & dr("Address2")) & "<BR>" & dr("City") & ", " & dr("st") & "  " & dr("Zip"))
        Write1Line("Date Of Birth", dr("DOB"))
        Write1Line("SSN#", dr("ss"))
        Write1Line("Gender", dr("Sex"))
        Write1Line("Phones:", dr("Phone") & " " & dr("PhoneWork") & " " & dr("PhoneCell"))

        Write1Line("Care Giver:", dr("CareGiver") & " - " & dr("CareGiverRelationship"))
        If Not dr("LegalSameAddress") Then
            Response.Write("<tr class=subheader><td colspan=2>Legal Guardian and Address</td></tr>")
            Write1Line("Parent/Legal Guardian", dr("LegalCareGiver") & " - " & dr("LegalCareGiverRelationship"))
            Write1Line("Address", dr("LegalAddress") & IIf(dr.IsNull("LegalAddress2"), "", "<br>" & dr("LegalAddress2")) & "<BR>" & dr("LegalCity") & ", " & dr("Legalst") & "  " & dr("LegalZip"))
            Write1Line("Phone", dr("legalPhone1") & " " & dr("legalPhone2") & " " & dr("legalPhone3"))
        End If

        Response.Write("<tr class=subheader><td colspan=2>Custody Information</td></tr>")
        Write1Line("Type Of Custody", LookupDesc("REFF:CUST:TYPE", "LUD", "LUV", dr("TypeOfCustody") & ""))
        Write1Line("Type Of Insurance", dr("TypeOfInsurance"))

        Response.Write("</table></td></tr>")
    End Sub
    Sub ShowComm(ByRef dr As DataRow)
        Response.Write("<tr class=Header><td>Community Information</td></tr><tr><td><table width=100% class=bodytext><colgroup width=50% span=2>")
        'Write1Line("Is this Child currently enrolled in school", dr("InSchool"))
        'Write1Line("School Enrolled", dr("SYSINVName12"))
        'Write1Line("Contact", dr("SYSINVNameAdd12"))
        'Write1Line("Phone", dr("SYSINVContactPhone12"))

        'Write1Line("Last Grade Completed", dr("Grade"))
        'Write1Line("Educational Placement", LookupDescM("IEP", "LUD", "LUV", dr("EduPlacement") & ""))
        'Write1Line("Specify if Other", dr("EduPlacementOther"))
        'Response.Write("<tr class=subheader><td colspan=2>Is this child currently involved in any system-of-care wrap around programs?." & dr("InWarpProgram") & "</td></tr>")
        'Write1Line("If Yes, Agency", dr("WPAgency"))
        'Write1Line("Contact", dr("WPContact"))
        'Write1Line("Phone", dr("WPPhone"))

        'Response.Write("<tr class=subheader><td colspan=2>Current System Involvement, please check 'Yes' for each agency that is applicable, and 'No' for each agency that is not applicable.</td></tr>")
        'W'rite1LineX("CCDCFS", dr, "1")
        'Write1LineX("Ohio Dept. Youth Srv.", dr, "2")
        'Write1LineX("Community Agency", dr, "3")
        'Write1LineX("Juvenile Court", dr, "4")
        'Write1LineX("Juvenile Court Diversion", dr, "5")
        'Write1LineX("Board of MR/DD", dr, "6")
        'Write1LineX("Private Hospital/Healthcare Provider", dr, "7")
        'Write1LineX("Provate MH Professional", dr, "8")
        'Write1LineX("Mobile Crisis Team", dr, "9")
        'Write1LineX("Alcohol and Drug Addiction Services", dr, "10")
        'Write1LineX("Bureau Of Voc Rehab", dr, "11")
        'Write1LineX("School in which enrolled", dr, "12")
        'Write1LineX("Other", dr, "13")
        'Response.Write("</table><table border=1 style='{PAGE-BREAK-AFTER: always;} width=100% class=""bodytext"">")
        'Response.Write("</table></td></tr></table>")
        'Response.Write("<table width=100% border=1 style='{PAGE-BREAK-BEFORE: always;}' class=bodytext><tr class=Header><td>Community Information - Continue</td></tr><tr><td><table width=100% class=bodytext><colgroup width=50% span=2>")

        Response.Write("<tr class=subheader><td colspan=2>If child has ever been placed out of his/her home, enter the number of placements in each category below. If child has never been placed out of his/her home, leave categories below blank:</td></tr>")

        'paint1NoPlacement("5", "Residential treatment centers", ds.Rows(0)) _
        ' & paint1NoPlacement("6", "Inpatient Psychiatric Hospitals", ds.Rows(0)) _
        '& paint1NoPlacement("10", "Relative Home", ds.Rows(0)) _
        ' & paint1NoPlacement("3", "Adoptive Home", ds.Rows(0)) _
        ' & paint1NoPlacement("2", "Foster Home", ds.Rows(0)) _
        ' & paint1NoPlacement("4", "Detention Center", ds.Rows(0)) _
        ' & paint1NoPlacement("11", "Crisis Stabilization", ds.Rows(0)) _
        ' & paint1NoPlacement("1", "Shelter Care", ds.Rows(0)) _
        ' & paint1NoPlacement("12", "Orphanage", ds.Rows(0)) _
        ' & paint1NoPlacement("8", "Correctional Facility", ds.Rows(0)) _
        '  & paint1NoPlacement("7", "Group Home", ds.Rows(0)) _
        ' & paint1NoPlacement("9", "Other", ds.Rows(0), " Please specify:")
        Write1Line("Residential treatment centers", dr("NoPlacement5"))
        Write1Line("Inpatient Psychiatric Hospitals", dr("NoPlacement6"))
        Write1Line("Relative Home", dr("NoPlacement10"))
        Write1Line("Adoptive Home", dr("NoPlacement3"))
        Write1Line("Foster Home", dr("NoPlacement2"))
        Write1Line("Detention Center", dr("NoPlacement4"))
        Write1Line("Crisis Stabilization", dr("NoPlacement11"))
        Write1Line("Shelter Care", dr("NoPlacement1"))
        Write1Line("Orphanage", dr("NoPlacement12"))
        Write1Line("Correctional Facility", dr("NoPlacement8"))
        Write1Line("Group Home", dr("NoPlacement7"))
        Write1Line("Other", dr("NoPlacement9") & ":" & dr("NoPlacement9SPY"))

        'SpcialConsideration
        Response.Write("</table></td></tr>")
    End Sub
    Sub ShowMental(ByRef dr As DataRow)
        Dim dt As DataTable
        Dim sSQL As String
        Dim i As Integer
        Response.Write("<tr class=Header><td>Current Concerns</td></tr><tr><td><table width=100% class=bodytext><colgroup width=50% span=2>")

        Write1Line("Is the client a legal resident of Cuyahoga County?", myDRTostring(dr, "AdmAnsNew1"))
        Write1Line("Has the client been diagnosed with a serious emotional disturbance?", myDRTostring(dr, "AdmAnsNew2"))
        Write1Line("Is the client having multiple problems in multiple areas (i.e., home and school) resulting from their mental health symptoms?", myDRTostring(dr, "AdmAnsNew3"))
        Write1Line("Is the client receiving mental health services, but remains at risk of deeper system involvement or is returning to the community from a placement?", myDRTostring(dr, "AdmAnsNew4"))
        If Not dr.IsNull("DSMDesc1") Then Write1Line("Diagnoses", dr("DSMDesc1"))
        If Not dr.IsNull("DSMDesc2") Then Write1Line("Diagnoses", dr("DSMDesc2"))
        If Not dr.IsNull("DSMDesc3") Then Write1Line("Diagnoses", dr("DSMDesc3"))
        If Not dr.IsNull("DSMDesc4") Then Write1Line("Diagnoses", dr("DSMDesc4"))
        If Not dr.IsNull("DSMDesc5") Then Write1Line("Diagnoses", dr("DSMDesc5"))
        Response.Write("</table></td></tr>")
        Response.Write("<tr class=Header><td>Mental Health Information</td></tr><tr><td><table width=100% class=bodytext><colgroup width=50% span=2>")
        If Not dr.IsNull("ProblemAry") Then
            Response.Write("<tr class=subheader><td colspan=2>The following problem(s) have been checked.</td></tr>")
            sSQL = "Select * from ConnWebProblemList where id in (" & Mid(dr("ProblemAry"), 2) & ") order by ID"
            dt = requestDT(sSQL)
            For i = 0 To dt.Rows.Count - 1
                Response.Write("<tr><td></td><td>&#149;&nbsp;" & dt.Rows(i)("Problems") & "</td></tr>")
            Next
        Else
            Response.Write("<tr class=subheader><td colspan=2>There are no problems checked.</td></tr>")
        End If
        If Not dr.IsNull("ProblemOther") Then
            Write1Line("Other Problem", dr("ProblemOther"))
        End If
        Response.Write("<tr class=subheader><td colspan=2>Special considerations (religion, culture, language translator, substance abuse, developmental or intellectual disabilities)</td></tr>")
        Response.Write("<tr><td colspan=2>" & dr("CommSpcialConsideration") & "&nbsp;</td></tr>")
        Response.Write("<tr class=subheader><td colspan=2>Current providers: (Please include agency name, provider/contact name and role, and phone number.)</td></tr>")
        Response.Write("<tr><td colspan=2>" & dr("CurrentProviders") & "&nbsp;</td></tr>")

        Response.Write("</table></td></tr>")
    End Sub
    Private Function toPeriod(ByVal sV As Object) As String
        If sV Is DBNull.Value Then Return ""
        If sV = "N" Then Return "Never"
        If sV = "1" Then Return "During Last 12 Months"
        If sV = "2" Then Return "More than 12 Months ago"
        Return ""
    End Function
    Sub ShowReff(ByRef dr As DataRow)
        Dim i As Integer
        Response.Write("<tr class=Header><td>Referral Information</td></tr><tr><td><table width=100% class=bodytext><colgroup width=50% span=2>")
        Write1Line("Referred by (Agency)", IIf(dr.IsNull("OVRAgency"), dr("AgencyName"), dr("OVRAgency")))
        Write1Line("Case Worker/Staff", IIf(dr.IsNull("OVRAgency"), dr("ProfessionName"), dr("OVRContact")))
        Write1Line("Agency Phone/Fax", "Phone:" & dr("AgencyPhone") & " Fax:" & dr("AgencyFax"))
        Write1Line("Is this a Rainbow Care Connection Referral?", myDRTostring(dr, "RainbowCare"))
        Write1Line("If yes, DCP Name, Phone, Fax:", myDRTostring(dr, "PCPName") & " - (P)" & myDRTostring(dr, "PCPPhone") & " - (F) " & myDRTostring(dr, "PCPFax"))


        Write1Line("Summary – reason for referral?", dr("Cause"))


        Response.Write("</table></td></tr>")
    End Sub

    Private Function Render1Question(ByRef dr As DataRow, ByVal sClass As String, ByVal Ans As String) As String
        Dim sRetv As String
        Dim aryYN() As String
        Dim sYN2 As String
        Ans = "||" & Ans
        Dim p1 As Integer
        Dim p2 As Integer
        p1 = InStr(Ans, "||" & dr("SEQ") & "::")
        'If p1 = 0 Then Return ""
        p2 = InStr(p1 + 2, Ans, "||")
        'If p2 = 0 Then Return ""
        If p1 = 0 Or p2 = 0 Then
            Ans = "::::"
        Else
            Ans = Mid(Ans, p1 + 2, p2 - p1 - 2)
        End If

        aryYN = Split(Ans, "::")

        sRetv = "<tr class=""" & sClass & """><td class=labelleftreq>" & dr("Label") & ". </td><td>" & dr("Question") _
            & "</td><td align=center><b>" & aryYN(1) & "</b></td></tr>"
        If Not dr.IsNull("AddQuestion") Then
            If dr("AddQuestion") > "" Then
                sRetv = sRetv & "<tr class=""" & sClass & """><td></td><td>" & dr("AddQuestion") & "</td><td align=center><b>" _
                & aryYN(2) & "</b></td></tr>"
            End If
        End If

        Return sRetv
    End Function

    Sub ShowAdm(ByRef dr As DataRow)
        Dim dt As DataTable
        Dim sSql As String
        Dim i As Integer

        Response.Write("<tr class=Header><td>Admission Criteria</td></tr><tr><td><table width=100% class=bodytext><colgroup width=5%><colgroup width=90%><colgroup width=5%>")
        sSql = "Select seq,Label,Question,Bold,Answer,Comment,AddQuestion,AddQuestionWhenAnswered,AddAnswered from ConnWebAdimissionCriteria where active=1 order by seq"
        dt = requestDT(sSql)

        For i = 0 To dt.Rows.Count - 1
            Response.Write(Render1Question(dt.Rows(i), "Row" & IIf(i Mod 2, "Odd", "Even"), myDRTostring(dr, "AdmAnswer")))
        Next

        Response.Write("</table></td></tr>")
    End Sub
    Sub showStatusHis(ByVal ID As Integer)
        Dim dt As DataTable
        Dim sSql As String
        Dim i As Integer

        Response.Write("<tr class=Header><td>Status History</td></tr><tr><td><table width=100% class=bodytext><colgroup width=5%><colgroup width=90%><colgroup width=5%>")
        sSql = "exec usp_ConnWebStatusHis_getList " & ID
        dt = requestDT(sSql)
        For i = 0 To dt.Rows.Count - 1
            Response.Write("<tr class=Row" & IIf(i Mod 2, "Odd", "Even") & "><td colspan=2><b>" & dt.Rows(i)("UpdatedBy") & " - " & dt.Rows(i)("DateUpdated") & " '" & dt.Rows(i)("StatusFromDesc") & "' to '" & dt.Rows(i)("StatusToDesc") & "'</b></td></tr>")
            If Not dt.Rows(i).IsNull("Notes") Then
                Response.Write("<tr class=Row" & IIf(i Mod 2, "Odd", "Even") & "><td></td><td>" & dt.Rows(i)("Notes") & "</td></tr>")
            End If
        Next

        Response.Write("</table></td></tr>")

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sSQL As String
        Dim dt As DataTable
        sSQL = "exec usp_ConnWebReferral_GetRecord_Print " & Request.QueryString("ID")
        dt = requestDT(sSQL)
        If dt.Rows(0)("RefBy") <> Session("UID") Then
            If getSecurityASP(Request, "Client", "ConnRef") = 0 Then
                Response.Write("Sorry, but we can not verify your credential to view this client. It might be that your session has been timed out. If that is the case, please sign on again.")
                Exit Sub
            End If
        End If

        Call PaintScreen(Me, dt)
        Me.lblSymtomList.Text = SymtomList(myDRTostring(dt.Rows(0), "ProblemAry"))
        Exit Sub
        Response.Write("<table border=1 width=100% class=""bodytext"">")
        Response.Write("<tr class=labelTop><td>Detail Information for " & dt.Rows(0)("LName") & ", " & dt.Rows(0)("FName") & "</td></tr>")
        'Call ShowAdm(dt.Rows(0))
        Call ShowDemo(dt.Rows(0))
        Call ShowComm(dt.Rows(0))
        Call ShowMental(dt.Rows(0))
        Call ShowReff(dt.Rows(0))
        'not isnull(rs("DateOfStatus").value)
        'If Not dt.Rows(0).IsNull("DateOfStatus") Then
        'Call showStatusHis(dt.Rows(0)("ID"))
        'End If
        Response.Write("</table>")
    End Sub
    Function SymtomList(sList As String) As String
        Dim sRetv As String = ""
        'Dim sSQL As String = "Select * from ConnWebProblemList where active=1 order by ID"
        Dim dt As DataTable = requestDT("exec usp_ConnWebProblemList_getlist")
        Dim i As Integer = 0
        Dim iHalf As Integer = dt.Rows.Count / 2
        'Dim sList As String = dr("ProblemAry")
        For i = 0 To iHalf - 1
            sRetv = sRetv & "<tr>" & oneProblem(dt, i, sList) & oneProblem(dt, i + iHalf, sList) & "</tr>"
            'sRetv = sRetv & "<td align='center'>" + CheckOrNot(myDRTostring(dt.Rows(i), "ID"), dr("ProblemAry")) & "</td><td class='ReportContent'>" & dt.Rows(i)("Problems") & "</td>"
            If i Mod 2 = 1 Then sRetv = sRetv & "</tr>"
        Next
        If dt.Rows.Count Mod 2 = 1 Then sRetv = sRetv & "</td colspan=2>&nbsp;</td></tr>"
        Return sRetv
    End Function
    Function oneProblem(ByRef dt As DataTable, iRow As Integer, sList As String) As String
        If iRow >= dt.Rows.Count Then Return "<td>&nbsp;</td><td>&nbsp;</td>"
        Dim dr As DataRow = dt.Rows(iRow)
        Return "<td align='center'>" + CheckOrNot(myDRTostring(dr, "ID"), sList) & "</td><td class='ReportContent'>" & dr("Problems") & "</td>"
    End Function
    Function CheckOrNot(sID As String, sList As String) As String
        If InStr(sList, sID) > 0 Then Return "X"
        Return "&nbsp;"
    End Function

    Function myDRTostring(ByRef dr As DataRow, ByVal idx As String) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
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

    Public Function retSingleValue(ByVal sSQL As String)
        Dim dt As New DataTable
        dt = requestDT(sSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return DBNull.Value
        End If
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


End Class