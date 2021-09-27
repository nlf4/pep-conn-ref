<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="referralprint.aspx.vb" Inherits="pep_conn_ref.referralprint" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ReferralPrint</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="default.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
    <table width="100%" class=""bodytext"">
    <tr><td>
        <table width='100%' class='bodytext' >
        <tr vlaign=top>
        <td><img src='http://pep-iis.pepcleve.org/images/logo.gif' border=0 /></td>
        <td class='ReportHeader'>Referral Information for 
        <asp:Label ID="frmXXChildNameTitle" runat="server" Text="Label"></asp:Label>&nbsp;
        &nbsp;[Entered:<asp:Label ID="frmXXDateEnteredP" runat="server" Text="Label"></asp:Label>]
        </td>
        </tr>
        </table>
    </td></tr>

     <tr><td class='ReportHeader1'><br />Demographic Information</td></tr>
     <tr><td><table width='100%' class='bodytext' border='1'>
        <colgroup width='25%'></colgroup>
        <tr><td class='ReportLable'>Child's Name:</td><td class='ReportContent'><asp:Label ID="FrmXXChildName" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>Date Of Birth:</td><td class='ReportContent'><asp:Label ID="FrmXXDOB" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>SSN#:</td><td class='ReportContent'><asp:Label ID="frmXXSS" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>Gender:</td><td class='ReportContent'><asp:Label ID="frmXXSex" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>Care Giver:</td><td class='ReportContent'><asp:Label ID="frmXXCareGiver" runat="server" Text="Label"></asp:Label>&nbsp;
            - <asp:Label ID="frmXXCareGiverRelationship" runat="server" Text="Label"></asp:Label>
        </td></tr>
        <tr valign=top><td class='ReportLable'>Care Giver Address:</td><td class='ReportContent'><asp:Label ID="frmXXCareGiverAddFull" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>Phones:</td><td class='ReportContent'>
            <b>PHone1:</b><asp:Label ID="frmXXPhone" runat="server" Text="Label"></asp:Label>
            <b>PHone2:</b><asp:Label ID="frmXXPhoneWork" runat="server" Text="Label"></asp:Label>
            <b>PHone3:</b><asp:Label ID="frmXXPhoneCell" runat="server" Text="Label"></asp:Label>
            &nbsp;</td></tr>
         
        </table></td></tr>
     <tr><td class='ReportHeader2'> <asp:Label ID="frmXXLGTitle" runat="server" Text="Label"></asp:Label> </td></tr>
     <tr <asp:Literal ID="frmXXLGDisplay" runat="server"></asp:Literal>><td><table width='100%'  class='bodytext' border='1'>
        <colgroup width='25%'></colgroup>
         <tr><td class='ReportLable'>Parent/Legal Guardian:</td><td class='ReportContent'><asp:Label ID="frmXXLegalCareGiver" runat="server" Text="Label"></asp:Label> - <asp:Label ID="frmXXLegalCareGiverRelationship" runat="server" Text="Label"></asp:Label></td></tr>
        <tr valign=top><td class='ReportLable'>Address:</td><td class='ReportContent'><asp:Label ID="frmXXLGAddFull" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>Phones:</td><td class='ReportContent'>
            <b>PHone1:</b><asp:Label ID="frmXXlegalPhone1" runat="server" Text="Label"></asp:Label>
            <b>PHone2:</b><asp:Label ID="frmXXlegalPhone2" runat="server" Text="Label"></asp:Label>
            <b>PHone3:</b><asp:Label ID="frmXXlegalPhone3" runat="server" Text="Label"></asp:Label>
            &nbsp;</td></tr>
        </table></td></tr>
      <tr><td class='ReportHeader2'>Custody Information</td></tr>
     <tr><td>
        <table width='100%' class='bodytext' border='1'>
        <colgroup width='25%'></colgroup>
         <tr><td class='ReportLable'>Type Of Custody:</td><td class='ReportContent'><asp:Label ID="frmXXTypeOfCustodyDesc" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
        <tr><td class='ReportLable'>Type Of Insurance:</td><td class='ReportContent'><asp:Label ID="frmXXTypeOfInsurance" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>

        </table></td></tr>
      <tr><td class='ReportHeader1'><br />Community Information</td></tr>
     <tr><td>
        <table width='100%' class='bodytext' border='1'>
        <colgroup width='50%'></colgroup>
          <tr><td class='ReportLable'>Is this a Rainbow Care Connection Referral?</td><td class='ReportContent'><asp:Label ID="frmXXRainbowCareYN" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
          <tr><td class='ReportLable'>If yes, PCP Name, Phone, Fax:</td><td class='ReportContent'><asp:Label ID="frmXXDCPInfo" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
 
        </table></td></tr>
    <tr><td>
        <table width='100%' class='bodytext' >
        <colgroup width='40%'></colgroup>
        <colgroup width='10%'></colgroup>
        <colgroup width='50%'></colgroup>
  <tr><td colspan='3'>
        If child has ever been placed out of his/her home, enter the number of placements in each category below. If child has never been placed out of his/her home, leave categories below blank:
   </td></tr>
    <tr><td>Residential treatment centers:</td><td class=Box><asp:Label ID="frmXXNoPlacement5" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Inpatient Psychiatric Hospitals:</td><td class=Box><asp:Label ID="frmXXNoPlacement6" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Relative Home:</td><td class=Box><asp:Label ID="frmXXNoPlacement10" runat="server" Text=""></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Adoptive Home:</td><td class=Box><asp:Label ID="frmXXNoPlacement3" runat="server" Text=""></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Foster Home:</td><td class=Box><asp:Label ID="frmXXNoPlacement2" runat="server" Text=""></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Detention Center:</td><td class=Box><asp:Label ID="frmXXNoPlacement4" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Crisis Stabilization:</td><td class=Box><asp:Label ID="frmXXNoPlacement11" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Shelter Care:</td><td class=Box><asp:Label ID="frmXXNoPlacement1" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Orphanage:</td><td class=Box><asp:Label ID="frmXXNoPlacement12" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Correctional Facility:</td><td class=Box><asp:Label ID="frmXXNoPlacement8" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Group Home:</td><td class=Box><asp:Label ID="frmXXNoPlacement7" runat="server" Text="Label"></asp:Label>&nbsp;</td><td>&nbsp;</td></tr>    
    <tr><td>Other:</td><td class=Box><asp:Label ID="frmXXNoPlacement9" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
    <tr><td align=right>Specify:</td><td colspan=2 class=box><asp:Label ID="frmXXNoPlacement9SPY" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>    

        </table></td></tr>
    <tr><td>
        <table width='100%' class='bodytext' >

      <tr style='{ page-break-before:always;}'><td colspan='3'>
            Special considerations (religion, culture, language translator, substance abuse, developmental or intellectual disabilities)
       </td></tr>  
       <tr><td colspan='3' class=boxLeft>
            <asp:Label ID="frmXXCommSpcialConsideration" runat="server" Text="Label"></asp:Label>&nbsp;
       </td></tr>  
 
          </table></td></tr> 

      <tr ><td class='ReportHeader1'><br />Mental Health Information</td></tr>
     <tr><td>
        <table width='100%' class='bodytext' border='1'>
        <colgroup width='25%'></colgroup>
          <tr><td class='ReportContent' align=center><asp:Label ID="frmXXAdmAnsNew1YN" runat="server" Text="Label"></asp:Label>&nbsp;</td><td class='ReportLable'>Is the client a legal resident of Cuyahoga County?</td></tr>
          <tr><td class='ReportContent' align=center><asp:Label ID="frmXXAdmAnsNew2YN" runat="server" Text="Label"></asp:Label>&nbsp;</td><td class='ReportLable'>Has the client been diagnosed with a serious emotional disturbance?</td></tr>
          <tr><td class='ReportContent' align=center><asp:Label ID="frmXXAdmAnsNew3YN" runat="server" Text="Label"></asp:Label>&nbsp;</td><td class='ReportLable'>Is the client having multiple problems in multiple areas (i.e., home and school) resulting from their mental health symptoms?</td></tr>
          <tr><td class='ReportContent' align=center><asp:Label ID="frmXXAdmAnsNew4YN" runat="server" Text="Label"></asp:Label>&nbsp;</td><td class='ReportLable'>Is the client receiving mental health services, but remains at risk of deeper system involvement or is returning to the community from a placement?</td></tr>

        </table></td></tr>
     <tr><td class='ReportHeader2'>Current Concerns</td></tr>
     <tr><td>
        <table width='100%' class='bodytext' border='1'>
        <colgroup width='25%'></colgroup>
          <tr><td class='ReportLable'>Diagnosis:</td><td class='ReportContent'><asp:Label ID="frmXXDSMDesc1" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
          <tr><td class='ReportLable'>Diagnosis:</td><td class='ReportContent'><asp:Label ID="frmXXDSMDesc2" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
          <tr><td class='ReportLable'>Diagnosis:</td><td class='ReportContent'><asp:Label ID="frmXXDSMDesc3" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
          <tr><td class='ReportLable'>Diagnosis:</td><td class='ReportContent'><asp:Label ID="frmXXDSMDesc4" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
          <tr><td class='ReportLable'>Diagnosis:</td><td class='ReportContent'><asp:Label ID="frmXXDSMDesc5" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>

        </table></td></tr>

     <tr><td>
        <table width='100%' class='bodytext' border='1'>
            <colgroup width='7%'></colgroup>
            <colgroup width='43%'></colgroup>
            <colgroup width='7%'></colgroup>
            <colgroup width='43%'></colgroup>
     <tr><td colspan=4 class='ReportHeader2'>Symptom Checklist</td></tr>
            <asp:Label ID="lblSymtomList" runat="server" Text="Label"></asp:Label>
            <tr><td colspan=4>Other (Specify)<br />
            <asp:Label ID="frmXXProblemOther" runat="server" Text="Label"></asp:Label>
            </td></tr>
        </table></td></tr>
   <tr><td>
        <table width='100%' class='bodytext' >

      <tr><td colspan='3' class='ReportHeader2'>
            Current providers: (Please include agency name, provider/contact name and role, and phone number.)
       </td></tr>  
       <tr><td colspan='3' class=boxLeft>
            <asp:Label ID="frmXXCurrentProviders" runat="server" Text="Label"></asp:Label>&nbsp;
       </td></tr>  
 
          </table></td></tr> 
   <tr><td>
        <table width='100%' border=1 class='bodytext' >

      <tr><td colspan='3' class='ReportHeader2'>
            Summary – reason for referral?
       </td></tr>  
       <tr><td colspan='3' class=boxLeft>
            <asp:Label ID="frmXXCause" runat="server" Text="Label"></asp:Label>&nbsp;
       </td></tr>  
 
          </table></td></tr> 
      <tr ><td class='ReportHeader1'>Referent Information</td></tr>
     <tr><td>
        <table width='100%' class='bodytext' border='1'>
        <colgroup width='25%'></colgroup>
         <tr><td class='ReportLable'>Referent Agency:</td><td class='ReportContent'><asp:Label ID="frmXXRefAgency" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
         <tr><td class='ReportLable'>Referent Name(Title):</td><td class='ReportContent'><asp:Label ID="frmXXReferenctInfo" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
         <tr><td class='ReportLable'>Agency Phone/Fax:</td><td class='ReportContent'><asp:Label ID="frmXXAgencyContactNo" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>
         <tr><td class='ReportLable'>Email Address:</td><td class='ReportContent'><asp:Label ID="frmXXRefEmail" runat="server" Text="Label"></asp:Label>&nbsp;</td></tr>

        </table></td></tr>
    </table>
	</body>
</HTML>
