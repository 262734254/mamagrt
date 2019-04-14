<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="通知设置-拓富中心-中国招商投资网"
    AutoEventWireup="true" CodeFile="Notice.aspx.cs" Inherits="helper_Notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function chkAll(m)
{
    for(j=0;j<chkTab.rows.length;j++)
    {
        var a = chkTab.rows.item(j).cells.item(m).getElementsByTagName("input"); 
			for (var i=0; i<a.length; i++) 
				if (a[i].type == "checkbox") 
				a[i].checked =!a[i].checked; 
    } 
}
    </script>

    <link href="/css/messagemanage.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                通知设置</div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <div class="suggestbox lightc allxian">
            ·您可以轻松使用站内短信、电子邮件、手机短信等方式接收各类通知。<br />
            ·<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank">拓富通会员</a>将享受500条免费手机短信服务。
            <br />
            ·普通会员如需使用手机短信服务，则需<a href="buysms.aspx" style="text-decoration: none">购买短信条数</a>，每条短信0.1元。</div>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">通知设置 </li>
                <li><a href="buysms.aspx" style="text-decoration: none">购买短信</a></li></ul>
        </div>
        <div class="smsnotbox cshibiank">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="chkTab">
                <tr>
                    <td width="4%" align="left" class="tabtitle">
                        &nbsp;
                    </td>
                    <td width="36%" align="left" class="tabtitle" style="padding-left: 50px">
                        通知项目</td>
                    <td width="24%" align="center" class="tabtitle">
                        <a href="javascript:void(0)" onclick="chkAll(2)">站内短信</a></td>
                    <td width="18%" align="center" class="tabtitle">
                        <a href="javascript:void(0)" onclick="chkAll(3)">电子邮件</a></td>
                    <td width="18%" align="center" class="tabtitle">
                        <a href="javascript:void(0)" onclick="chkAll(4)">手机短信</a></td>
                </tr>
                <tr>
                    <td class="taba">
                        &nbsp;
                    </td>
                    <td class="taba">
                        ◎ 需求发布后的审核通知</td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="softtype" value="1" id="infocheck1" runat="server" />
                    </td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="softtype" value="2" id="infocheck2" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="softtype" value="3" id="infocheck3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        ◎ 订制资源新到通知</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="dzchk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="dzchk2" runat="server" checked="CHECKED" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="dzchk3" runat="server" checked="CHECKED" /></td>
                </tr>
                <tr>
                    <td class="taba" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="taba" style="height: 20px">
                        ◎ 资源有效期即将到期通知</td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="InfoValiChk1" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="InfoValiChk2" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="InfoValiChk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        ◎ 拓富通会员即将到期通知</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="memberValiChk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="memberValiChk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="memberValiChk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="taba">
                        &nbsp;
                    </td>
                    <td class="taba">
                        ◎ 好友添加通知</td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="1" id="addfriendchk1" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="2" id="addfriendchk2" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="3" id="addfriendchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        ◎ 资源留言通知</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="commentchk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="commentchk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="commentchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        ◎ 留言回复通知</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="rebackchk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="rebackchk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="rebackchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="taba" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="taba" style="height: 20px">
                        ◎ 匹配资源通知</td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="ppchk1" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="ppchk2" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="ppchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        ◎ 成功购买资源通知</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="buychk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="buychk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="buychk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="taba">
                        &nbsp;
                    </td>
                    <td class="taba">
                        ◎ 成功充值通知</td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="1" id="czchk1" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="2" id="czchk2" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="3" id="czchk3" runat="server" /></td>
                </tr>
            </table>
            <div class="fill">
                接收邮件设置：
                <input name="textarea" type="text" size="30" id="txtEmail" runat="server" />
                <font class="hui">当您选择电子邮件接收时，将通过此邮箱接收通知。 </font><span>接收手机设置：
                    <input name="textarea2" type="text" size="30" id="txtMobile" runat="server" />
                    <font class="hui">当您选择手机接收时，将通过此手机号码接收通知。 </font></span>
                <p>
                    <b class="cheng">温馨提示</b>：您现在还可以接收<b class="cheng"><asp:Literal ID="lblNoticeCount"
                        runat="server" Text="0"></asp:Literal></b>条手机短信。</p>
            </div>
            <div class="buttom">
                <input name="" type="button" class="buttomal" value="设  置" id="Button1" onserverclick="Button1_ServerClick"
                    runat="server" />
                <input name="Input" type="reset" class="buttomal" value="重  置" />
            </div>
        </div>
    </div>
</asp:Content>
