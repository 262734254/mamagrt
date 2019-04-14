<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyCarve.aspx.cs" Inherits="Manage_ModifyCarve" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.DateTimeBox" TagPrefix="cc1" %>
<%@ Register Src="../Controls/ProjectAddressInfo.ascx" TagName="ProjectAddressInfo"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>创业信息修改-中国招商投资网</title>
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.trnone{
    display:none;
    }
.note
{
	float:left;
	text-align:left;
	font-size:12px;
	color:#999999;
	padding:3px;
	line-height:130%;
	background:#ffffff;
	border:#ffffff 1px solid;
}
.notetrue
{
	float:left;
	text-align:left;
	font-size:12px;
	padding:3px;
	line-height:130%;
	color:#485E00;
	background:#F7FFDD;
	border:#485E00 1px solid;
}
.noteawoke
{
	float:left;
	text-align:left;
	padding:3px;
	line-height:130%;
	background:#fff5d8;
	border:#ff7300 1px solid;
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <div class="titled">
                <div class="left">
                    创业信息修改</div>
                <div class="right">
                    <img src="../images/publish/biao_01.gif" align="absmiddle" />
                    <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class='dottedlline'>
            </div>
            <div class="blank6">
            </div>
            <div class="infozi" id="switchtext">
                基本信息<span></span></div>
            <table border="0" cellpadding="0" cellspacing="0" class="tabbiank">
                <tr>
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span class="hong">*</span> <strong><span style="color: #333333">创业信息标题：</span></strong></td>
                    <td width="625">
                        <strong></strong><span id="spCapitalName2">
                            <input id="Text1" style="width: 296px" type="text" /></span></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7">
                        <strong>广告语：</strong></td>
                    <td>
                        <span id="spCapitalType">
                            <input id="Text2" style="width: 296px" type="text" /></span></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7">
                        <span class="hong">*</span> <strong>所属区域：</strong></td>
                    <td>
                        <uc2:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr id="trswitchpublish" name="trswitchpublish">
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span style="color: #ff0000">*</span><span style="color: #000000; background-color: #f7f7f7">
                            <strong><span style="color: #333333">所属行业</span></strong></span><strong>：</strong></td>
                    <td width="625">
                        <span style="color: #0000ff">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="169px">
                            </asp:DropDownList></span></td>
                </tr>
                <tr>
                    <td width="133" align="right" valign="top" bgcolor="#F7F7F7">
                        <span class="hong">*</span> <strong><span style="color: #333333">投资金额</span>：</strong></td>
                    <td width="625">
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="169px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span class="hong">* </span><strong>投资对象：</strong></td>
                    <td width="625">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" Width="181px">
                            <asp:ListItem>个人</asp:ListItem>
                            <asp:ListItem>公司</asp:ListItem>
                            <asp:ListItem>不限</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td width="133" align="right" valign="top" bgcolor="#F7F7F7">
                        <span class="hong">*</span> <strong>投资要求：</strong>
                        <br />
                    </td>
                    <td width="625" valign="top">
                        <label>
                            <textarea id="txtCapitalIntent" onchange="JavaScrpit:checkCapitalIntent()" runat="server"
                                cols="50" style="width: 558px; height: 95px"></textarea></label></td>
                </tr>
                <tr id="tr1" name="trswitchpublish">
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span style="color: #ff0000">*</span><span style="color: #000000; background-color: #f7f7f7">
                        </span><strong>回报形式：</strong><span style="color: #000000; background-color: #f7f7f7">
                        </span>
                    </td>
                    <td width="625" valign="top">
                        <textarea id="Textarea1" runat="server" cols="50" onchange="JavaScrpit:checkCapitalIntent()"
                            style="width: 558px; height: 95px"></textarea></td>
                </tr>
                <tr id="tr3" name="trswitchpublish">
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span style="color: #000000; background-color: #f7f7f7"><strong><span style="color: #333333">
                            备注：</span></strong> </span>
                    </td>
                    <td width="625" valign="top">
                        <textarea id="Textarea2" runat="server" cols="50" onchange="JavaScrpit:checkCapitalIntent()"
                            style="width: 558px; height: 95px"></textarea></td>
                </tr>
                <tr id="tr4" name="trswitchpublish">
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span style="color: #ff0000"></span><span style="color: #000000; background-color: #f7f7f7">
                            <strong><span style="color: #333333">图片上传：</span></strong> </span>
                    </td>
                    <td width="625" valign="top">
                        <input id="File1" style="border-right: #cccccc 1px solid; border-top: #cccccc 1px solid;
                            border-left: #cccccc 1px solid; width: 358px; border-bottom: #cccccc 1px solid;
                            height: 21px" type="file" /></td>
                </tr>
                <tr id="tr2" name="trswitchpublish">
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span style="color: #ff0000">*</span><span style="color: #000000; background-color: #f7f7f7">
                        </span><strong>开始有效日期：</strong></td>
                    <td width="625" class="nonepad">
                        <cc1:DateTimeBox ID="DateTimeBox1" runat="server" Width="174px"></cc1:DateTimeBox>
                    </td>
                </tr>
                <tr>
                    <td width="133" align="right" bgcolor="#F7F7F7">
                        <span class="hong">*</span> <strong>有效期：</strong></td>
                    <td width="625">
                        <asp:DropDownList ID="ddlValiditeTerm" runat="server">
                            <asp:ListItem Value="3">三个月内</asp:ListItem>
                            <asp:ListItem Value="6">半年内</asp:ListItem>
                            <asp:ListItem Value="12">一年内</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
            <!--附加信息 -->
            <div class="blank0">
            </div>
            <!--联系方式 -->
            <div class="infozi">
                联系方式</div>
            <div class="blank0">
            </div>
            <uc1:ProjectAddressInfo ID="ProjectAddressInfo1" runat="server" />
            <div class="mbbuttom">
                <p>
                    <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank">点此阅读中国招商投资网服务条款</a><span><a
                        href="#" class="lanlink">查询是否属于重复信息</a></span></p>
                <input id="Button1" type="button" value="修  改" style="width: 205px" class="buttomal" /></div>
        </div>
    </form>
</body>
</html>
