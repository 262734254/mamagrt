<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodePage="936" ValidateRequest="false" EnableEventValidation="false" CodeFile="zq2.aspx.cs"
    Inherits="Publish_project_zq2" %>

<%@ Register Src="../../Controls/UpFileControl.ascx" TagName="UpFileControl" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/common.css" rel="stylesheet" type="text/css">
    <link href="/css/stake.css" rel="stylesheet" type="text/css">
    <div id="right_box">
        <div class="mainconbox">
            <div class="titled">
                <div class="left">
                    �����������󡪡�ծȨ����
                </div>
                <div class="right">
                    <img src="/images/biao_01.gif" align="absMiddle">
                    <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">���󷢲�����</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="stepsbox">
                <div class="suggestbox lightc allxian">
                    <img src="/images/falaba.jpg" width="16" height="10">
                    ������Ŀ�ƻ�������������ύ����������������Ŀ�ĺ������ϡ����Ƶ����Ͽ��Եõ�Ͷ�ʷ��������Ρ�</div>
            </div>
            <div class="blank0">
            </div>
            <div class="infozi">
                ��Ŀ��������</div>
            <table class="tabbiank" cellspacing="0" cellpadding="0" border="1">
                <tbody>
                    <tr>
                        <td width="160" align="right" valign="top" bgcolor="#f7f7f7" style="height: 2px">
                            <b>�г�����</b>��</td>
                        <td valign="top" width="594">
                            <textarea id="txtMarketAbout" style="width: 558px; height: 100px" name="textarea2"
                                rows="5" cols="50" runat="server"></textarea>
                            <span id="spMerchantIntro"></span>
                            <br>
                            <span class="hui">��ǰĿ��������Ⱥ�������г���������г���չǱ�����</span> <a href="#"></a>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <b>��λ��Ӫҵ���룺</b></td>
                        <td width="594">
                            <input type="text" name="textfield" id="txtCompanyYearIncome" runat="server">
                            ��Ԫ �����</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7" style="height: 5px">
                            <b>��λ�꾻����</b></td>
                        <td width="594">
                            <input type="text" name="txtCompanyNG" id="txtCompanyNG" runat="server">
                            ��Ԫ �����</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <b>��λ���ʲ���</b>
                            <br>
                        </td>
                        <td width="594">
                            <input type="text" name="txtCompanyTotalCapital" id="txtCompanyTotalCapital" runat="server">
                            ��Ԫ �����</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <b>��λ�ܸ�ծ��</b></td>
                        <td width="594">
                            <input type="text" name="txtCompanyTotalDebet" id="txtCompanyTotalDebet" runat="server">
                            ��Ԫ �����</td>
                    </tr>
                    <tr id="trswitchpublish" name="trswitchpublish">
                        <td align="right" valign="top" bgcolor="#F7F7F7">
                            <strong>�ϴ�������</strong></td>
                        <td width="618" valign="top" class="nonepad">
                            <uc2:FilesUploadControl id="FilesUploadControl1" infotype="Project" runat="server" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right" valign="top" bgcolor="#F7F7F7">
                            <b>�ϴ�����:</b>
                        </td>
                        <td bgcolor="#FFFFFF">
                            <uc1:UpFileControl ID="UpFileControl1" runat="server" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                            <div class="mbbuttom">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/button2.jpg"
                                    OnClick="ImageButton1_Click" />&nbsp;</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script language="javascript">
        function chkpost()
        {
            var CompanyYearIncome="<%=this.txtCompanyYearIncome.ClientID %>";
            var CompanyNG="<%=this.txtCompanyNG.ClientID %>";
            var CompanyTotalCapital="<%=this.txtCompanyTotalCapital.ClientID %>";
            var CompanyTotalDebet="<%=this.txtCompanyTotalDebet.ClientID %>";
            if(document.getElementById(CompanyYearIncome).value!="")
            {
                 if(isNaN(document.getElementById(CompanyYearIncome).value))
                 {
                   alert(" ��λ��Ӫҵ��������д����...");
                   document.getElementById(CompanyYearIncome).focus();
                   return false;
                 }
            }
            if(document.getElementById(CompanyNG).value!="")
            {
                 if(isNaN(document.getElementById(CompanyNG).value))
                 {
                   alert(" ��λ�꾻��������д����...");
                   document.getElementById(CompanyNG).focus();
                   return false;
                 }
            }
            if(document.getElementById(CompanyTotalCapital).value!="")
            {
                if(isNaN(document.getElementById(CompanyTotalCapital).value))
                {
                   alert(" ��λ���ʲ�����д����...");
                   document.getElementById(CompanyTotalCapital).focus();
                   return false;
                 }
            }
            if(document.getElementById(CompanyTotalDebet).value!="")
            {
                 if(isNaN(document.getElementById(CompanyTotalDebet).value))
                 {
                   alert(" ��λ�ܸ�ծ����д����...");
                   document.getElementById(CompanyTotalDebet).focus();
                   return false;
                 }
            }
        }
    </script>

</asp:Content>
