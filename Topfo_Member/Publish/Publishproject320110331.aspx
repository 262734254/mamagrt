<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Publishproject320110331.aspx.cs" Inherits="Publish_Publishproject3" Title="融资需求-发布完成" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布融资需求
            </div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absmiddle" />
                <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank" class="lanlink">
                    需求发布规则</a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="stepsbox">
            <ul>
                <li class="liimg">
                    <img src="../images/publish/projectbg.gif" align="left" /></li>
                <li class="lishortc">发布成功</li>
            </ul>
            <div class="clear ">
            </div>
        </div>
        <div class="blank0">
        </div>
        <asp:Panel ID="plnoneTitle" runat="server">
            <div class="suggestboxc lightc allxian">
                <img src="../images/publish/biao_03.gif" align="left" class="san" />
                <strong>发布成功，您的需求已提交审核。恭喜您迈出成功的第一步！</strong>
                <br />
                您的需求将在<span class="cheng">1个工作日内(遇节假日顺延)</span>被审核，审核结果通过邮件通知您，请注意查收！<br />
                信息通过审核后，您可以在“<a href="/Manage/ResourceManage_Pass.aspx" class='lanlink'>通过审核</a>”中查看和管理。
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="plTopfoTitle" runat="server">
            <div class="suggestboxc lightc allxian">
                <div class="leftimg">
                </div>
                <img src="../images/publish/biao_03.gif" align="left" class="san" />
                <strong>发布成功，恭喜您迈出成功的第一步！</strong><br />
                拓富通会员发布需求采取<span class="cheng">先发后审</span>的形式，您发布的需求已经上网！<br />
                稍后我们将对您的需求进行例行审核，审核结果通过邮件通知您，请注意查收！
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <div class="blank0">
        </div>
        <div class="viewbox lightc ">
            我们为您找到了 <span id="spCount" class="hong">-</span> 条关于“<span><%=this.title %></span>”的匹配资源，或许您的机会就在这里！
            <a href="../Manage/PertinentLink.aspx?id=<%=this._infoID %>&type=project">点击查看</a>
            | <a href="/helper/MatchingInfo.aspx">订阅此类资源</a></div>
        <div class="blank0">
        </div>
        <asp:Panel ID="plnoneMsg" runat="server">
            <div class="threebox">
                <ul>
                    <li><a href="http://member.topfo.com/Register/VIPMemberRegister.aspx" target="_blank">
                        <img src="../images/publish/buttom_ljjl.gif" width="149" height="35" border="0" align="left"
                            class="a" /></a>拓富通会员发布的需求将放在普通会员的前面，成交机会是普通会员的 <span class="hong">12</span>
                        倍；<br />
                        <a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank">
                            查看拓富通会员4大优势</a> 拓富热线：
                        <!--#include file="../common/toptel.html"-->
                        <a href="/ContactUs.shtml" target="_blank"></a></li>
                    <li>
                        <img src="../images/publish/buttom_cjwszd.gif" width="149" height="35" border="0"
                            align="left" onclick="alert('系统升级中……')" style="cursor: pointer" />获得全球唯一子域名，全面展示您的形象和项目优势，免费的哦！
                        <a href="http://www.topfo.com/help/setup.shtml" target="_blank">先了解一下</a> </li>
                    <div class="blank0">
                    </div>
                    <li><a href="http://www.topfo.com" target="_blank">
                        <img src="../images/publish/buttom_ssqldzy.gif" width="149" height="35" border="0"
                            align="left" /></a>主动出击，寻找对口的资源！</li>
                    <li>您还可以联系我们专业的线下运作团队帮您解决融资问题，<a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml"
                        target="_blank" class="lanlink">了解一下专业服务</a></li>
                </ul>
            </div>
        </asp:Panel>
        <asp:Panel ID="plTopfoMsg" runat="server">
            <div class="nextbox">
                <h1>
                    接下来，您还可以</h1>
                <p>
                    <a href="http://www.tz888.cn/Member/Manage/intro.aspx" target="_blank">进入您的企业展厅</a>，发布更多内容，全面展示您的企业！</p>
            </div>
            <div class="blank0">
            </div>
            <div class="nextbox">
                <h1>
                    拓富通会员的需求将放在普通会员的前面</h1>
                <p>
                    ·规定的周期内，您的需求将放在普通会员的前面，被更多投资机构关注。<br />
                    ·优先排序的周期结束之后，您还可以通过<span class="hong">刷新</span>您的资源，继续享有优先排序的权利，这可是拓富通会员专享的功能哦<br />
                    （每条资源每天只 能刷新一次）! <a href="http://www.topfo.com/help/demandmanage.shtml#17" target="_blank">
                        如何刷新</a></p>
                <table width="238" border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="111" align="center">
                            <strong>位 置</strong></td>
                        <td width="121" align="center">
                            <strong>优先排序周期</strong></td>
                    </tr>
                    <tr>
                        <td width="111" align="center" bgcolor="#EFEFEF">
                            分类列表</td>
                        <td width="121" align="center" bgcolor="#EFEFEF">
                            一周
                        </td>
                    </tr>
                    <tr>
                        <td width="111" align="center">
                            搜索列表
                        </td>
                        <td width="121" align="center">
                            一周
                        </td>
                    </tr>
                    <tr>
                        <td width="111" align="center" bgcolor="#EFEFEF">
                            最新资源列表</td>
                        <td width="121" align="center" bgcolor="#EFEFEF">
                            一天</td>
                    </tr>
                </table>
                <div class="blank0">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="nextbox">
                <h1>
                    联系我们专业的线下运作团队帮您解决融资问题</h1>
                <p>
                    <span class="cheng">只有拓富通会员才有资格申请我们的专业服务！</span><br />
                    专业服务推荐：<a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#01">项目融资</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#02">资金借贷</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#03">购并重组</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#04">财务顾问</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#05">股权私募</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#06">投、融资咨询</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#07">创业投资</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#08">投资委托</a>
                    <a href="http://www.topfo.com/Aboutus/ServiceNet/ProjectService.shtml#09">投资合作</a>
                    <br />
                    专业服务咨询电话：<span class="cheng">0755-89805589</span></p>
            </div>
        </asp:Panel>
    </div>

    <script type="text/javascript" language="javascript">
    var infoid = <%=this._infoID %>;
    PublishProject.GetMatchCount(infoid,
            function(result){
                   document.getElementById("spCount").innerHTML = result.value;
            });
    </script>

</asp:Content>
