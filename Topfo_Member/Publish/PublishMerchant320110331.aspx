<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PublishMerchant320110331.aspx.cs" Inherits="Publish_PublishMerchant3" Title="招商需求-发布成功" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布政府招商需求</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absmiddle"  />
                 <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a>            </div>
            <div class="clear">
            </div>
        </div>
        <asp:Panel ID="plTitle" runat='server'>
        <div class='stepsbox'>
            <ul>
                <li>第1步 登记招商机构 </li>
                <li class="liimg">
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='liwai'>第2步 填写招商项目信息</li>
                <li class='liimg'>
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='lishort'>第3步 发布成功</li>
            </ul>
            <div class='clear'>
            </div>
            <div class='blank0'>
            </div>
            <div class='suggestbox lightc'>
                "招商机构已经登记，接下来请您填写招商项目信息</div>
        </div>
        </asp:Panel>
        <asp:Panel ID="plnoneTitle" runat="server">
        <div class="suggestboxc lightc allxian">
            <div class="leftimg">
            </div>
            <img src="../images/publish/biao_03.gif" width="74" height="74" align="left" class="san" />
            <strong>恭喜，您的需求发布成功，已提交审核！</strong> <a href="/Publish/PublishNavigateH.aspx">继续发布专业服务需求</a> <br />
           <p> <span class="lansen cu">重要提示：</span>
            
                为保证政府招商需求的真实性和严肃性，您需要将招商的委托授权书传真给我们，经确认后您的需求方可发布上网！
                传真号码：<span class="hong">0755-82213698</span> 咨询电话<!--#include file="../common/custel.html"-->
            </p>
            <div class="clear">
            </div>
        </div>
        </asp:Panel>
        <asp:Panel ID="plTopfoTitle" runat="server">
        <div class="suggestboxc lightc allxian">
            <div class="leftimg">
            </div>
            <img src="../images/publish/biao_03.gif" width="74" height="74" align="left" class="san" />
            <strong>发布成功，恭喜您迈出成功的第一步！</strong><br />
            拓富通会员发布需求采取<span class="cheng">先发后审</span>的形式，您发布的需求已经上网！<br />
            稍后我们将对您的需求进行例行审核，审核结果通过邮件通知您，请注意查收！
            
            <div class="clear">
            </div>
        </div>
        </asp:Panel>
        <div class="blank0">
        </div>
        <div class="viewbox lightc">
            我们为您找到了 <span id="spCount" class="hong">-</span> 条关于“<span><%=this.title %></span>”的匹配资源，或许您的机会就在这里！ <a href="../Manage/PertinentLink.aspx?id=<%=this._infoID %>&type=Merchant">点击查看</a>
            | <a href="/helper/MatchingInfo.aspx">订阅此类资源</a></div>
        <asp:Panel ID="plnoneMsg" runat="server">
        <div class="threebox">
            <ul>
              <li>
                    <a href="http://member.topfo.com/Register/VIPMemberRegister.aspx" target="_blank"><img src="../images/publish/buttom_ljjl.gif" width="149" height="35" border="0" align="left"
                        class="a" /></a>拓富通会员发布的需求将放在普通会员的前面，成交机会是普通会员的 <span class="hong">12</span> 倍；<br />
                    <a href="http://www.tz888.cn/TopfoCenter/Application/superiorityApp.shtml" target="_blank">查看拓富通会员的4大优势</a> 拓富热线：
                    <!--#include file="../common/toptel.html"--> 
            </li>
                <li>
                    <img src="../images/publish/buttom_cjwszd.gif" width="149" height="35" border="0" align="left"  onclick="alert('系统升级中……')"  style=" cursor:pointer"/>获得全球唯一子域名，全面展示您的形象和项目优势，免费的哦！

                    <a href="http://www.topfo.com/help/setup.shtml" target="_blank">先了解一下</a> </li>
                <div class="blank0">
                </div>
                <li>
                    <a href="http://www.topfo.com" target="_blank"><img src="../images/publish/buttom_ssqldzy.gif" width="149" height="35" border="0" align="left" /></a>主动出击，寻找对口的资源！</li>
                <li>您还可以联系我们专业的线下运作团队帮您解决招商问题，<a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml" target="_blank" class="lanlink">了解一下专业服务</a></li>
            </ul>
        </div>
        </asp:Panel>
        <asp:Panel ID="plTopfoMsg" runat="server">
		 <div class="blank0"></div>
        <div class="nextbox">
            <h1>
                接下来，您还可以</h1>
            <p>
                <a href="http://www.tz888.cn/Member/Manage/intro.aspx" target="_blank" >进入您的企业展厅</a>，发布更多内容，全面展示您的企业！</p>
        </div>
        <div class="blank0">
        </div>
        <div class="nextbox">
            <h1>
                拓富通会员的需求将放在普通会员的前面</h1>
          <p>
                ·规定的周期内，您的需求将放在普通会员的前面，被更多投资机构关注。<br />
                ·优先排序的周期结束之后，您还可以通过<span class="hong">刷新</span>您的资源，继续享有优先排序的权利，这可是拓富通会员专享的功能哦<br />
              （每条资源每天只 能刷新一次）! <a href="http://www.topfo.com/help/demandmanage.shtml#17" target="_blank" >如何刷新</a></p>
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
                联系我们专业的线下运作团队帮您解决招商问题</h1>
            <p>
                <span class="cheng">只有拓富通会员才有资格申请我们的专业服务！</span><br />
                专业服务推荐：<a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#01" target="_blank">标的式招商委托</a> 
            <a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#02" target="_blank">产业规划及产业招商</a>
            <a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#03" target="_blank">龙头企业引进</a>
            <a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#04" target="_blank">高效招商活动支持</a>
           <a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#05" target="_blank">区域投资环境评测</a>
             <a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#06" target="_blank">招商宣传策划</a>
             <a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml#07" target="_blank">招商培训</a>
          
            
              <br />
              专业服务咨询电话：<span class="cheng">0755-89805589</span></p>
            </div>
        </asp:Panel>
    </div>
    <script type="text/javascript" language="javascript">
    var infoid = <%=this._infoID %>;
    PublishMerchant.GetMatchCount(infoid,
            function(result){
                   document.getElementById("spCount").innerHTML = result.value;
            });
    </script>
</asp:Content>
