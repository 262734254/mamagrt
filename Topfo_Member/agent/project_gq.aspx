<%@ Page Language="C#" AutoEventWireup="true" CodeFile="project_gq.aspx.cs" Inherits="agent_project_gq" %>

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
    <link href="/css/common.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <table class="tabbiank" cellspacing="0" cellpadding="0" border="0" style="width: 600px">
            <tr>
                <td colspan="2">
                    <strong><span style="font-size: 16px; color: #ff6600">股权融资发布</span></strong></td>
            </tr>
            <tr>
                <td width="24%" align="right" bgcolor="#f7f7f7">
                    * <strong>项目名称:</strong></td>
                <td>
                    <input id="txtProjectName" runat="server" style="width: 401px" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>所属行业:</strong></td>
                <td>
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server"></uc2:SelectIndustryControl>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>所属区域:</strong></td>
                <td style="height: 21px">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server"></uc1:ZoneSelectControl>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 42px">
                    * <strong>项目简述:</strong></td>
                <td style="height: 42px">
                    <textarea id="txtProIntro" runat="server" style="height: 200px; width: 412px;"></textarea></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>* 融资对象:</strong></td>
                <td>
                    <asp:RadioButtonList ID="rbtnObj" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>投资总额:</strong></td>
                <td>
                    <asp:TextBox ID="txtCapitalTotal" runat="server" Width="75px"></asp:TextBox>
                    万人民币
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * <strong>融资金额:</strong></td>
                <td>
                    <asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList><br />
                    金额的货币单位为人民币</td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>* 出让股份:</strong></td>
                <td>
                    <asp:TextBox ID="txtSellStockShare" runat="server" Width="75px"></asp:TextBox>%</td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>*退出方式:</strong></td>
                <td>
                    <asp:CheckBoxList ID="chkReturn" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>产品概述:</strong></td>
                <td>
                    <textarea id="txtProjectAbout" runat="server" cols="50" name="textarea2" style="height: 80px"></textarea><br />
                    <span class="hui">您主要提供哪些产品与服务，针对哪些客户进行服务，如何定价。</span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>市场前景:</strong></td>
                <td>
                    <textarea id="txtMarketAbout" runat="server" cols="50" name="textarea2" style="height: 80px"></textarea>
                    <br />
                    <span class="hui">当前市场法制环境、目标消费人群分析、市场总量多大，市场发展潜力多大</span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>竞争分析:</strong></td>
                <td>
                    <textarea id="txtCompetitioAbout" runat="server" cols="50" name="textarea2" style="height: 80px"></textarea><br />
                    <span class="hui">竞争状况、你所能占领的市场份额、SWOT分析（优势、劣势、机会、威胁）。</span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>商业模式:</strong></td>
                <td>
                    <textarea id="txtBussinessModeAbout" runat="server" cols="50" name="textarea2" style="height: 80px"></textarea><br />
                    <span class="hui">您在市场、产品、销售、管理、收入来源以及盈利等方面以什么形式实现，您的核心竞争力是什么？ 如何保证核心竞争力？ </span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <strong>管理团队:</strong></td>
                <td>
                    <textarea id="txtManageTeamAbout" runat="server" cols="50" name="textarea2" style="height: 80px"></textarea><br />
                    <span class="hui">团队架构、高管人员的从业经历等。</span>
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
                    * 项目单位名称:</td>
                <td>
                    <input id="txtCompanyName" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    * 联系人<b>:</b></td>
                <td>
                    <input id="txtLinkMan" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    职位<b>:</b></td>
                <td>
                    <input id="txtCareer" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    *固定电话<b>:</b></td>
                <td>
                    <input id="txtTelStateCode" runat="server" class="show" style="width: 28px" /><input
                        id="txtTel" runat="server" class="show" style="width: 172px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 26px">
                    手机:</td>
                <td style="height: 26px">
                    <input id="txtMobile" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    *电子邮箱:</td>
                <td>
                    <input id="txtEmail" runat="server" class="show" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    单位详细地址:</td>
                <td>
                    <input id="txtAddress" runat="server" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    项目单位网址:</td>
                <td>
                    <input id="txtWebSite" runat="server" style="width: 210px" type="text" /></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 21px">
                    * <strong>有效期限:</strong></td>
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
            if(document.getElementById("txtProIntro").value==""||document.getElementById("txtProIntro").value.length>50)
            {
                alert("请填写项目简述.建议400字以内（不少于50字）");
                document.getElementById("txtProIntro").focus();
                return false;
            }
                if(parseInt(document.getElementById("txtSellStockShare").value)>100)
            {
                alert("出让股份%数不能大于100%...");
                document.getElementById("txtSellStockShare").focus();
                return false;
            }
             if(isNaN(document.getElementById("txtSellStockShare").value))
            {
                alert("出让股份%数请填写整数...");
                document.getElementById("txtSellStockShare").focus();
                return false;
            }
            if(isNaN(document.getElementById(SellStockShare).value))
            {
                alert("出让股份请填写整数...");
                document.getElementById(SellStockShare).focus();
                return false;
            }
   
        }
        </script>

    </form>
</body>
</html>
