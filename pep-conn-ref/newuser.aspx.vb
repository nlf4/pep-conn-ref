Public Class newuser
    Inherits System.Web.UI.Page

    Private Function ValidateInput() As String
        Dim sSQL As String
        Dim dt As DataTable
        If Me.frmXXAgencyName.Text = "" Or Me.frmXXFirstName.Text = "" _
                        Or Me.frmXXLastName.Text = "" Or Me.frmXXPWD.Text = "" Or Me.frmXXPWDCONFIRM.Text = "" _
                        Or Me.frmXXUID.Text = "" Or Me.frmXXeMail.Text = "" Then
            Return "All the information on the form is required. Please enter all data then try again to register."
        End If
        If Me.frmXXPWD.Text <> Me.frmXXPWDCONFIRM.Text Then
            Return "The password and Re-Type password do not match. Please try again."
        End If
        If Me.frmXXeMail.Text <> Me.frmXXeMail2.Text Then
            Return "The email and Re-Type email do not match. Please try again."
        End If
        'frmXXeMail2
        sSQL = "Select count(*) from users where UID='" & Replace(Me.frmXXUID.Text, "'", "''") & "'"
        dt = requestDT(sSQL)
        If dt.Rows(0)(0) > 0 Then
            Return "Sorry, this user name has been assigned to another user. Please select a different user name."
        End If
        sSQL = "Select count(*) from connWebUser where eMail='" _
                & Replace(Me.frmXXeMail.Text, "'", "''") & "' or UID='" & Me.frmXXUID.Text & "'"
        dt = requestDT(sSQL)
        If dt.Rows(0)(0) > 0 Then
            Return "Sorry, the information you entered match one of our existing user. Please verify your information, if you have trouble signing on, please contact our service department."
        End If
        sSQL = "Select case when dbo.udf_PWD_IsGood('" & Replace(Me.frmXXUID.Text, "'", "''") & "','" & Replace(Me.frmXXPWD.Text, "'", "''") & "')=1 then 'Y' else 'N' end"
        dt = requestDT(sSQL)
        If myDRToString(dt.Rows(0), 0) = "N" Then
            Return "Sorry, password must be 8-15 characters and contains 3 out of 4 basic character groups (Lower, Upper case, number, and symbol) ."
        End If
        sSQL = "Select case when dbo.udf_ConnRef_SpamCheck('" & Replace(Me.frmXXFirstName.Text, "'", "''") & "','" & Replace(Me.frmXXLastName.Text, "'", "''") & "','" & Replace(Me.frmXXAgencyName.Text, "'", "''") & "','" & Replace(Me.frmXXeMail.Text, "'", "''") & "')=1 then 'Y' else 'N' end"

        'dt = requestDT(sSQL)
        If myDRToString(dt.Rows(0), 0) = "N" Then
            Return "Sorry, your submission could not be processed.  Please call 216-361-2441"
        End If
        Return ""
    End Function
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim sSQL As String
        Dim i As Integer
        Dim sID As String
        'Dim ErrMsg As String = ""
        'If getSecurity(Request, "CONNWEB", "USER") = 0 Then Response.Redirect(ROOT_DIRECTORY_SECURE & "/Login.aspx")
        If Me.Page.IsPostBack Then
            Me.lblMsg.Text = ValidateInput()
            If Me.lblMsg.Text = "" Then
                sID = "@ID"
                'ErrMsg = "@ErrMsg"
                Me.lblMsg.Text = UpdateFromForm(Request, "usp_ConnWebUser_add", "")
                '
                If Me.lblMsg.Text = "" Then
                    sSQL = "Select a.UName,b.* from users a inner join ConnWebUser b on a.UID=b.UID where a.UID='" _
                            & Replace(Me.frmXXUID.Text, "'", "''") & "'"
                    dt = requestDT(sSQL)
                    'If dt.Rows.Count = 0 Then Return "Sorry, but your name is not on our system. Please verify your sign on id and/or password."
                    Session("IID") = dt.Rows(0)("ID")
                    Session("UID") = dt.Rows(0)("UID")
                    Session("UName") = dt.Rows(0)("LastName") & ", " & dt.Rows(0)("FirstName")
                    Session("AgencyName") = dt.Rows(0)("AgencyName")
                    Response.Redirect("Profile.aspx?NEWUSER=YES")
                End If
            End If
        End If
        'dt = requestDT("Select * from ConnWebContent where Area='SIGNON' and ID='NEWUSER' order by seq")
        'For i = 0 To dt.Rows.Count - 1
        'If i = 0 Then
        'Me.lblContent.Text = dt.Rows(i)("Contents")
        'Else
        'Me.lblContent.Text = Me.lblContent.Text & "<BR><br>" & dt.Rows(i)("Contents")
        'End If
        'Next
        'Me.lblContent.Text = "Please fill in all fields on the form and then click 'Register'"
        ' Me.lblLeftLink.Text = getSideLink("REFF")
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

    Function myDRTostring(ByRef dr As DataRow, ByVal idx As Integer) As String
        If dr.IsNull(idx) Then Return ""
        Return dr(idx) & ""
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

    Function toGoodSQLArgName(ByVal sV As String) As String
        Return sV
    End Function

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