<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeFile="zq_update.aspx.cs"
    Inherits="Publish_project_zq_update" %>

<%@ Register Src="../../Controls/UpFileControl.ascx" TagName="UpFileControl" TagPrefix="uc3" %>
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
                    修改融资需求——债权融资
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
                        <td style="height: 2px" align="right" width="124" bgcolor="#f7f7f7">
                            <span class="hong">* </span><strong>项目名称</strong>：</td>
                        <td style="height: 2px" width="618">
                            <input id="txtProjectName" style="width: 286px" runat="server">
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
                        <td width="160" align="right" valign="top" bgcolor="#f7f7f7" style="height: 2px">
                            <b>市场概述</b>：</td>
                        <td valign="top" width="594">
                            <textarea id="txtMarketAbout" style="width: 558px; height: 100px" name="textarea2"
                                rows="5" cols="50" runat="server"></textarea>
                            <span id="spMerchantIntro"></span>
                            <br>
                            <span class="hui">当前目标消费人群分析、市场总量多大、市场发展潜力多大。</span> <a href="#"></a>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <b>借款单位年营业收入：</b></td>
                        <td width="594">
                            <span id="Span1"></span>
                            <input type="text" name="textfield" id="txtCompanyYearIncome" runat="server">
                            万元 人民币</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7" style="height: 5px">
                            <b>借款单位年净利润：</b></td>
                        <td width="594">
                            <span id="Span2"></span>
                            <input type="text" name="textfield2" id="txtCompanyNG" runat="server">
                            万元 人民币</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <b>借款单位总资产：</b>
                            <br>
                        </td>
                        <td width="594">
                            <span id="Span3"></span>
                            <input type="text" name="txtCompanyTotalCapital" id="txtCompanyTotalCapital" runat="server">
                            万元 人民币</td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7">
                            <b>借款单位总负债：</b></td>
                        <td class="nonepad">
                            <input type="text" name="textfield4" id="txtCompanyTotalDebet" runat="server">
                            万元 人民币</td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#F7F7F7">
                            <b>上传附件:</b>
                        </td>
                        <td bgcolor="#FFFFFF">
                            <uc3:UpFileControl ID="UpFileControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="124" align="right" valign="top" bgcolor="#f7f7f7" style="height: 2px">
                            <span class="hong">*</span> 项目单位名称：</td>
                        <td valign="top" width="618">
                            <input id="txtCompanyName" class="show" type="text" value="" style="width: 210px"
                                runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#f7f7f7">
                            <span class="hong">* </span>联系人<b>：</b></td>
                        <td valign="top" width="618">
                            <input id="txtLinkMan" class="show" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#f7f7f7" style="height: 5px">
                            职位<b>：</b></td>
                        <td valign="top" width="618">
                            <input id="txtCareer" class="show" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span>固定电话<b>：</b></td>
                        <td valign="top" width="618">
                            <input id="txtTelStateCode" runat="server" class="show" style="width: 40px">
                            <input id="txtTel" class="show" type="text" value="" style="width: 160px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            手机：</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtMobile" class="show" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span>电子邮箱：</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtEmail" class="show" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            项目单位详细地址：</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            项目单位网址：</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7" style="height: 22px">
                            <span class="hong">*</span> <strong>项目有效期限：</strong></td>
                        <td class="nonepad" style="height: 22px">
                            自发布之日起
                            <asp:RadioButtonList ID="rbtnValiDate" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="3">三个月</asp:ListItem>
                                <asp:ListItem Value="6">半年内</asp:ListItem>
                                <asp:ListItem Value="12">一年内</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" valign="top" bgcolor="#FFFFFF">
                            <div class="mbbuttom">
                                <p>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/button3.jpg"
                                        OnClick="ImageButton1_Click" /></p>
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
            var CompanyYearIncome="<%=this.txtCompanyYearIncome.ClientID %>";
            var CompanyNG="<%=this.txtCompanyNG.ClientID %>";
            var CompanyTotalCapital="<%=this.txtCompanyTotalCapital.ClientID %>";
            var CompanyTotalDebet="<%=this.txtCompanyTotalDebet.ClientID %>";
            if(document.getElementById(CompanyYearIncome).value!="")
            {
                 if(isNaN(document.getElementById(CompanyYearIncome).value))
                 {
                   alert(" 借款单位年营业收入请填写数字...");
                   document.getElementById(CompanyYearIncome).focus();
                   return false;
                 }
            }
            if(document.getElementById(CompanyNG).value!="")
            {
                 if(isNaN(document.getElementById(CompanyNG).value))
                 {
                   alert(" 借款单位年净利润请填写数字...");
                   document.getElementById(CompanyNG).focus();
                   return false;
                 }
            }
            if(document.getElementById(CompanyTotalCapital).value!="")
            {
                if(isNaN(document.getElementById(CompanyTotalCapital).value))
                {
                   alert(" 借款单位总资产请填写数字...");
                   document.getElementById(CompanyTotalCapital).focus();
                   return false;
                 }
            }
            if(document.getElementById(CompanyTotalDebet).value!="")
            {
                 if(isNaN(document.getElementById(CompanyTotalDebet).value))
                 {
                   alert(" 借款单位总负债请填写数字...");
                   document.getElementById(CompanyTotalDebet).focus();
                   return false;
                 }
            }
     var CompanyName="<%=this.txtCompanyName.ClientID %>";
   if(document.getElementById(CompanyName).value=="")
  {
    alert("项目单位名称不能为空...");
    document.getElementById(CompanyName).focus();
    return false;
  }
  var LinkMan="<%=this.txtLinkMan.ClientID %>";
  if(document.getElementById(LinkMan).value=="")
  {
    alert("联系人不能为空...");
    document.getElementById(LinkMan).focus();
    return false;
  }
  var TelStateCode="<%=this.txtTelStateCode.ClientID %>";
  var Tel="<%=this.txtTel.ClientID %>";
  var Mobile="<%=this.txtMobile.ClientID %>";
   if(document.getElementById(Tel).value==""&&document.getElementById(Mobile).value=="")
  {
         alert("电话号码或手机须至少填写一个...");
         document.getElementById(Tel).focus();
         return false;
  }
  if(document.getElementById(Tel).value!="")
  {
      if(isNaN(document.getElementById(Tel).value))
      {
             alert("电话号码格式错误");
             document.getElementById(Tel).focus();
             return false;
      }
      if(document.getElementById(TelStateCode).value=="")
      {
        alert("区号不能为空...");
        document.getElementById(TelStateCode).focus();
        return false;
      }
      else
      {
           var filter = /^[0-9]+$/;
           if(!filter.test(document.getElementById(TelStateCode).value))
           {
             alert("区号错误...");
             document.getElementById(TelStateCode).focus();
             return false;
           }
      }
  } 
  if(document.getElementById(Mobile).value!="")
  {
        if(isNaN(document.getElementById(Mobile).value)||document.getElementById(Mobile).value.length!=11)
        {
             alert("手机位数不正确...")
             document.getElementById(Mobile).focus();
              return false;
         }
  }
   var Email="<%=this.txtEmail.ClientID %>";
  if(document.getElementById(Email).value=="")
  {
         alert("电子邮件不能为空...");
    	  document.getElementById(Email).focus();
	      return false;
  }
  if(document.getElementById(Email).value!="")
  {
                var obj = document.getElementById(Email);
    	        var str = obj.value;
    	        var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    	        if(str !=0 &&!filter.test(str))
    	        {
    	            alert("电子邮件格式错误...");
    	            txtshow("Email");
    	            document.getElementById(Email).focus();
	                return false;
    	        }
   }
 }
    </script>

</asp:Content>
