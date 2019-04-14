<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeFile="gq1.aspx.cs"
    Inherits="Publish_project_gq1" %>

<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/common.css" rel="stylesheet" type="text/css">
    <link href="/css/stake.css" rel="stylesheet" type="text/css">
    <div id="right_box">
        <div class="mainconbox">
            <div class="titled">
                <div class="left">
                    �����������󡪡���Ȩ����
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
                    �������Ͻ�������١���ƭ��������Ϣ�����ڴ���Ϣ���������κη��ɺ���ɷ��������ге���</div>
            </div>
            <div class="blank0">
            </div>
            <div>
                <strong>��Ŀ������Ϣ</strong>��ǰ����� <span class="hong">*</span> ��Ϊ������)</div>
            <table class="tabbiank" cellspacing="0" cellpadding="0" border="1">
                <tbody>
                    <tr>
                        <td style="height: 2px" align="right" width="15%" bgcolor="#f7f7f7">
                            <span class="hong">* </span><strong>��Ŀ����</strong>��</td>
                        <td style="height: 2px">
                            <input id="txtProjectName" style="width: 286px" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">* </span><strong>������ҵ��</strong></td>
                        <td>
                            <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>��������</strong></td>
                        <td style="height: 5px" width="618">
                            <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>��Ŀ������</strong>
                            <br>
                        </td>
                        <td valign="top" width="618">
                            <textarea id="txtProIntro" runat="server" cols="50" style="width: 558px; height: 215px"></textarea><span
                                id="spProIntro"></span>
                            <br>
                            <span class="hui">��������Ŀ���м򵥡������Ľ��ܣ�����400�����ڣ�������50�֣�������Ͷ���˺ܿ������жϡ� </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <strong><span class="hong">* </span>���ʶ���</strong></td>
                        <td class="nonepad" width="618">
                            <asp:RadioButtonList ID="rbtnObj" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>��ĿͶ���ܶ</strong></td>
                        <td class="nonepad">
                            <asp:TextBox ID="txtCapitalTotal" runat="server" Width="75px">
                            </asp:TextBox>
                            �������
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>���ʽ�</strong></td>
                        <td class="nonepad">
                            <asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList><br />
                            <span class="hui">���Ļ��ҵ�λΪ�����</span></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <strong><span class="hong">*</span>���ùɷݣ�</strong></td>
                        <td class="nonepad">
                            <asp:TextBox ID="txtSellStockShare" runat="server" Width="75px">
                            </asp:TextBox>%</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <strong><span class="hong">*</span>�˳���ʽ��</strong></td>
                        <td class="nonepad">
                            <asp:CheckBoxList ID="chkReturn" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>��Ŀ��Ч���ޣ�</strong></td>
                        <td class="nonepad">
                            �Է���֮����
                            <asp:RadioButtonList ID="rbtnValiDate" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="3">������</asp:ListItem>
                                <asp:ListItem Value="6" Selected="True">������</asp:ListItem>
                                <asp:ListItem Value="12">һ����</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                            <div class="mbbuttom">
                                <p>
                                    <input name="checkbox" type="checkbox" value="checkbox" checked="checked">
                                    <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" class="lanlink">
                                        �����Ķ���ͬ���ظ�.�й�����Ͷ��������</a></p>
                                <asp:ImageButton ID="BtnOk" runat="server" ImageUrl="/images/button.jpg" OnClick="BtnOk_Click" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script language="javascript">
       
        function chkpost()
        {
            
             var c="ctl00_ContentPlaceHolder1_";
            var ProjectName="<%=this.txtProjectName.ClientID %>";
            if(document.getElementById(ProjectName).value=="")
            {
                alert("��Ŀ���Ʋ���Ϊ��...");
                document.getElementById(ProjectName).focus();
                return false;
            }
            if(document.getElementById(c+"SelectIndustryControl1_hdselectValue").value=="")
            {
                alert("��ѡ����ҵ...");
                document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
                return false;
            }
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
                {
                    alert("��ѡ��ʡ��...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById(c+"ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("��ѡ�����...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            var ProIntro="<%=this.txtProIntro.ClientID %>";
            if(document.getElementById(ProIntro).value.length<50)
            {
                alert("��д��Ŀ����.����400�����ڣ�������50�֣�");
                document.getElementById(ProIntro).focus();
                return false;
            }
            var CapitalTotal="<%=this.txtCapitalTotal.ClientID %>";
            if(document.getElementById(CapitalTotal).value=="")
            {
                  alert("����д��ĿͶ���ܶ�...");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
             if(document.getElementById(CapitalTotal).value.length>10)
            {
                alert("��ĿͶ���ܶ���д����...");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
            if(isNaN(document.getElementById(CapitalTotal).value))
            {
                alert("��ĿͶ���ܶ���д����...");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
            var SellStockShare="<%=this.txtSellStockShare.ClientID %>";
            if(document.getElementById(SellStockShare).value=="")
            {
                alert("����д���ùɷ�(��д����)...");
                document.getElementById(SellStockShare).focus();
                return false;
            }
           
            if(isNaN(document.getElementById(SellStockShare).value))
            {
                alert("���ùɷ�����д����...");
                document.getElementById(SellStockShare).focus();
                return false;
            }
            if(parseInt(document.getElementById(SellStockShare).value)>100 )
            {
                alert("���ùɷݰٷֱ�ҪС��100%...");
                document.getElementById(SellStockShare).focus();
                return false;
            }
        }
    </script>

</asp:Content>
