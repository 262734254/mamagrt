<%@ Page Language="C#" AutoEventWireup="true" CodeFile="project_zq.aspx.cs" Inherits="agent_project_zq" %>

<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc4" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
        <script language="javascript" src="/javascript/publish.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="tabbiank" cellspacing="0" cellpadding="0" border="0" style="width: 640px">
            <tr>
                <td colspan="2">
                    <strong><span style="font-size: 16px; color: #ff6600">债券融资发布</span></strong></td>
            </tr>
            <tr>
                <td width="28%" align="right" bgcolor="#f7f7f7">
                    * <strong>项目名称:</strong>&nbsp;</td>
                <td>
                    <input id="txtProjectName" runat="server" style="width: 280px" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>所属行业：</strong></td>
                <td>
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server"></uc2:SelectIndustryControl>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>所属区域：</strong></td>
                <td style="height: 21px">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server"></uc1:ZoneSelectControl>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 42px">
                    * <strong>项目简述：</strong></td>
                <td style="height: 42px">
                    <textarea id="txtProIntro" runat="server" style="height: 200px; width: 90%;"></textarea></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>* 融资对象：</strong></td>
                <td>
                    <asp:RadioButtonList ID="rbtnObj" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>投资总额：</strong></td>
                <td>
                    <asp:TextBox ID="txtCapitalTotal" runat="server" Width="75px"></asp:TextBox>
                    万人民币
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>借款金额：</strong></td>
                <td>
                    <asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList><br />
                    金额的货币单位为人民币</td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>*担保抵押能力：</strong></td>
                <td>
                    <textarea id="txtWarrant" runat="server" cols="50" name="textarea" rows="5"></textarea></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>市场概述</strong><span style="background-color: #f7f7f7">：</span></td>
                <td>
                    <textarea id="txtMarketAbout" runat="server" cols="50" name="textarea2" rows="5"
                        style="height: 100px"></textarea>
                    <span id="spMerchantIntro"></span>
                    <br />
                    <span class="hui">当前目标消费人群分析、市场总量多大、市场发展潜力多大。</span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>借款单位年营业收入：&nbsp;</strong></td>
                <td>
                    <input id="txtCompanyYearIncome" runat="server" name="textfield" type="text" />
                    万元 人民币</td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>借款单位年净利润：</strong>&nbsp;
                </td>
                <td>
                    <input id="txtCompanyNG" runat="server" name="txtCompanyNG" type="text" />
                    万元 人民币</td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>借款单位总资产：</strong></td>
                <td>
                    <input id="txtCompanyTotalCapital" runat="server" name="txtCompanyTotalCapital" type="text" />
                    万元 人民币</td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 4px">
                    <strong>借款单位总负债：</strong></td>
                <td style="height: 4px">
                    <span class="hui">
                        <input id="txtCompanyTotalDebet" runat="server" name="txtCompanyTotalDebet" type="text" />
                        万元 人民币</span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong></strong>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 21px">
                    <strong>上传附件:</strong></td>
                <td style="height: 21px">
                    &nbsp;<uc4:ImageUploadControl ID="ImageUploadControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * 项目单位名称：</td>
                <td>
                    <input id="txtCompanyName" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * 联系人<b>：</b></td>
                <td>
                    <input id="txtLinkMan" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    职位<b>：</b></td>
                <td>
                    <input id="txtCareer" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    *固定电话<b>：</b></td>
                <td>
                    <input id="txtTelStateCode" runat="server" class="show" style="width:40px" /><input
                        id="txtTel" runat="server" class="show" style="width: 160px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 26px">
                    手机：</td>
                <td style="height: 26px">
                    <input id="txtMobile" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    *电子邮箱：</td>
                <td>
                    <input id="txtEmail" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    单位详细地址：</td>
                <td>
                    <input id="txtAddress" runat="server" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    项目单位网址：</td>
                <td>
                    <input id="txtWebSite" runat="server" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 21px">
                    * <strong>有效期限：</strong></td>
                <td style="height: 21px">
                    自发布之日起
                    <asp:RadioButtonList ID="rbtnValiDate" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="3">三个月</asp:ListItem>
                        <asp:ListItem Value="6">半年内</asp:ListItem>
                        <asp:ListItem Value="12">一年内</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="BtnOk" runat="server" ImageUrl="/images/button3.jpg" OnClick="BtnOk_Click" /></td>
            </tr>
        </table>
        <script language="javascript">
       
        function chkpost()
        {
           
            if(document.getElementById("txtProjectName").value=="")
            {
                alert("项目名称不能为空...");
                document.getElementById("txtProjectName").focus();
                return false;
            }
            if(document.getElementById("SelectIndustryControl1_hdselectValue").value=="")
            {
                alert("请选择行业...");
                document.getElementById("SelectIndustryControl1_sltIndustryName_all").focus();
                return false;
            }
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById("ZoneSelectControl1_hideProvince").value=="")
                {
                    alert("请选择省份...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById("ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("请选择城市...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            if(document.getElementById("txtProIntro").value.length<50)
            {
                alert("填写项目简述.建议400字以内（不少于50字）");
                document.getElementById("txtProIntro").focus();
                return false;
            }
             if(isNaN(document.getElementById("txtCapitalTotal").value))
            {
                alert("项目投资总额填写错误...");
                document.getElementById("txtCapitalTotal").focus();
                return false;
            }
            if(document.getElementById("txtWarrant").value.length<10)
            {
                alert("担保抵押介绍不少于50字...");
                document.getElementById("txtWarrant").focus();
                return false;
            }
             if(document.getElementById("txtCompanyYearIncome").value!="")
        {
             if(!isNaN(document.getElementById("txtCompanyYearIncome").value))
             {
               alert(" 借款单位年营业收入请填写数字...");
               document.getElementById("txtCompanyYearIncome").focus();
               return false;
             }
        }
        if(document.getElementById("txtCompanyNG").value!="")
        {
             if(isNaN(document.getElementById("txtCompanyNG").value))
             {
               alert(" 借款单位年净利润请填写数字...");
               document.getElementById("txtCompanyNG").focus();
               return false;
             }
        }
        if(document.getElementById("txtCompanyTotalCapital").value!="")
        {
            if(isNaN(document.getElementById("txtCompanyTotalCapital").value))
            {
               alert(" 借款单位总资产请填写数字...");
               document.getElementById("txtCompanyTotalCapital").focus();
               return false;
             }
        }
        if(document.getElementById("txtCompanyTotalDebet").value!="")
        {
             if(isNaN(document.getElementById("txtCompanyTotalDebet").value))
             {
               alert(" 借款单位总负债请填写数字...");
               document.getElementById("txtCompanyTotalDebet").focus();
               return false;
             }
        }
        chkContact();
        }
        </script>
    </form>
</body>
</html>
