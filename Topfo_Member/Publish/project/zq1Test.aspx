﻿
<%@ Page Language="C#"  AutoEventWireup="true"
    CodePage="936" ValidateRequest="false" EnableEventValidation="false" CodeFile="zq1Test.aspx.cs"
    Inherits="Publish_project_zq1Test" %>

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
                    发布融资需求——债权融资
                </div>
                <div class="right">
                    <img src="/images/biao_01.gif" align="absMiddle">
                    <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="stepsbox">
                <div class="suggestbox lightc allxian">
                    <img src="/images/falaba.jpg" width="16" height="10">
                    声明：严禁发布虚假、欺骗或误导性信息，基于此信息而产生的任何法律后果由发布者自行承担。</div>
            </div>
            <div class="blank0">
            </div>
            <div>
                <strong>项目基本信息</strong>（前面标有 <span class="hong">*</span> 的为必填项)</div>
            <table class="tabbiank" cellspacing="0" cellpadding="0" border="1">
                <tbody>
                    <tr>
                        <td style="height: 2px" align="right" width="15%" bgcolor="#f7f7f7">
                            <span class="hong">* </span><strong>项目名称</strong>：</td>
                        <td style="height: 2px">
                            <input id="txtProjectName" style="width: 286px" onchange="JavaScrpit:checkMerchantName()"
                                runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">* </span><strong>所属行业：</strong></td>
                        <td>
                            <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>所属区域：</strong></td>
                        <td style="height: 5px" width="618">
                            <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>项目简述：</strong>
                            <br>
                        </td>
                        <td valign="top" width="618">
                            <textarea id="txtProIntro" runat="server" cols="50" rows="10" style="width: 558px;
                                height: 300px"></textarea><span id="spProIntro"></span>
                            <br>
                            <span class="hui">对您的项目进行简单、清晰的介绍，建议400字以内（不少于50字），便于投资人很快做出判断。 </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <strong><span class="hong">* </span>融资对象：</strong></td>
                        <td class="nonepad" width="618">
                            <asp:RadioButtonList ID="rbtnObj" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>项目投资总额：</strong></td>
                        <td class="nonepad">
                            <asp:TextBox ID="txtCapitalTotal" runat="server" Width="75px">
                            </asp:TextBox>
                            万人民币
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>借款金额：</strong></td>
                        <td class="nonepad">
                            <asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList><br />
                            <span class="hui">金额的货币单位为人民币</span></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <strong><span class="hong">*</span>担保抵押能力：</strong></td>
                        <td class="nonepad">
                            <textarea id="txtWarrant" style="width: 558px; height: 100px" name="textarea" rows="5"
                                cols="50" runat="server"></textarea>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>项目有效期限：</strong></td>
                        <td class="nonepad">
                            自发布之日起
                            <asp:RadioButtonList ID="rbtnValiDate" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="3">三个月</asp:ListItem>
                                <asp:ListItem Value="6" Selected="true">半年内</asp:ListItem>
                                <asp:ListItem Value="12">一年内</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>验证码：</strong></td>
                        <td class="nonepad">
                            <input name="vercode" id="vercode" type="text" />
                            <div class="commonly">
                                <img alt="验证码" src="../../ValidateNumber.aspx" width="73" height="25" align="middle"
                                    id="validimg" />
                                <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">换一张图片</a><span
                                    style="padding-right: 1px" id="vercodeinfo"></span></div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                            <div class="mbbuttom">
                                <p>
                                    <input name="checkbox" type="checkbox" value="checkbox" checked>
                                    <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" class="lanlink">
                                        我已阅读并同意拓富.中国招商投资网服务</a></p>
                                <asp:ImageButton ID="BtnOk" runat="server" ImageUrl="/images/button.jpg" OnClick="BtnOk_Click" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    
    <script language="javascript" type="text/javascript">
       
function ChangeValidCode(id)
{
   document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
  
}
        function chkpost()
        {
            var c="ctl00_ContentPlaceHolder1_";
            var ProjectName="<%=this.txtProjectName.ClientID %>";
            if(document.getElementById(ProjectName).value=="")
            {
                alert("项目名称不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
            if(document.getElementById(c+"SelectIndustryControl1_hdselectValue").value=="")
            {
                alert("请选择行业...");
                document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
                return false;
            }
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
                {
                    alert("请选择省份...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById(c+"ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("请选择城市...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            var ProIntro="<%=this.txtProIntro.ClientID %>";
            if(document.getElementById(ProIntro).value.length<50)
            {
                alert("填写项目简述.建议400字以内（不少于50字）");
                document.getElementById(ProIntro).focus();
                return false;
            }
            var CapitalTotal="<%=this.txtCapitalTotal.ClientID %>";
            if(document.getElementById(CapitalTotal).value=="")
            {
                  alert("请填写项目投资总额...");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
            if(document.getElementById(CapitalTotal).value.length>10)
            {
                alert("项目投资总额填写错误...");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
            if(isNaN(document.getElementById(CapitalTotal).value))
            {
                alert("项目投资总额填写错误...");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
            var Warrant="<%=this.txtWarrant.ClientID %>";
            if(document.getElementById(Warrant).value.length<50)
            {
                alert("担保抵押介绍不少于50字...");
                document.getElementById(Warrant).focus();
                return false;
            }
            var vercode=document.getElementById("vercode");
            if(vercode.value.length<5)
            {
                alert("请输入验证码...");
                vercode.focus();
                return false;
            }
        }
    </script>

</asp:Content>
