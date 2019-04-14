<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="index2.aspx.cs" Inherits="index" ResponseEncoding="GB2312" Title="Untitled Page" %>

<%@ Register Src="Controls/IndexTFZS.ascx" TagName="IndexTFZS" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="JavaScript/TodayCommand.js" type="text/javascript"></script>

    <script language="javascript" src="JavaScript/UserCenter.js" type="text/javascript"></script>

    <div class="in_wrap">
        <div class="note">
            <h3 class="cc_1">
                尊敬的<span><asp:Label runat="server" ID="lblUserName"></asp:Label></span></h3>
            <p class="note_info">
			您好！为了给广大会员提供更优质的服务，中国招商投资网隆重推出拓富通会员服务，四大优势让您拓富更轻松！<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" class="blue" target="_blank">先了解一下</a></p>
            <p class="note_info">
               如果您满意我们的服务，请将 <span class="red_2">topfo.com</span> 推荐给您的朋友。现在，您每成功推荐一位好友注册，便能得到<span class="red_2"> 500 </span>积分（100积分=1元人民币），积分兑换后可以购买网站高质量的收费资源哦！<a href="http://member.topfo.com/Register/InviteFriend.aspx" class="blue" target="_blank">立即邀请我的朋友</a></p>
        </div>
        <div class="bottom_wrap">
            <div class="box_ll">
                <div class="all_box">
                    <h3 class="allboxt f14_b">
                        <div class="allbtbg">
                            <span>重要操作提示</span></div>
                    </h3>
                    <div class="box_bg">
                        <div class="allboxt_2" id="forInfo" runat="server">
                            </div>
                        <div class="t_top">
                            <div id="forOrgReg" runat="server">
                            </div>
                            <div id="forSite" runat="server">
                            </div>
                        </div>
                    </div>
                    <h3></h3>
                    <div class="box_bg">
                        <div class="allboxt_2" id="Div1" runat="server">
                            </div>
                        <div class="t_top">
                            增值服务定制功能上线了，会员都可以量身定制自己所需要的服务啦！<br />
                            服务项目<br />
                            定向推广　　对口资源推荐　　商业计划书摘要　　电子杂志推广<br />
                            领导专访　　尊贵展示　　　　招商路演 　　　　　专题推荐<br />
                            广告服务　　站内互告　　　　广告互告窄告<br />
                            <br />　　　　　　　　　　　　　<a href="/valueadd/ServiceAdd.aspx">查看增值服务定制详情</a>

                        </div>
                    </div>
                </div>
                <div class="all_box">
                    <h3 class="allboxt f14_b">
                        <div class="allbtbg">
                            <span>拓富助手提示您</span></div>
                    </h3>
                    <div class="zhelpbox">
                        <ul>
                            <li class="liwai" id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(0);" name="TodyTab">
                                <img src="images_fhy/icon_mail.gif" width="16" height="10" /><a href="http://member.topfo.com/InnerInfo/inbox2.aspx">我的短信息</a></li><li id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(1);"
                                        name="TodyTab">
                                        <img src="images_fhy/icon_ly.gif" width="15" height="13" /><a href="http://member.topfo.com/helper/InfoComment/commentReceive.aspx">给我的留言</a></li><li class="linone" id="TodyTab"
                                                onmouseover="JavaScript:ChangeTodayTab(2);" name="TodyTab">
                                                <img src="images_fhy/icon_ty.gif" width="21" height="16" align="absmiddle" /><a href="http://member.topfo.com/helper/MatchingInfo.aspx">我的订阅</a></li></ul>
                        <div class="con zhelpsanb" id="DispUp" name="DispUp">
                            <div class="msglistable llmsgbg01" id="TodayDetailTab" style="display: block" name="TodayDetailTab">
                                <div id="dgInner">
                                </div>
                                <div class="rtop_wai" id="UserCenter_Inner" style="display: block">
                                    <div class="r_top">
                                    </div>
                                    <div class="r_c">
                                        <table width="262" height="164" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="262" align="center">
                                                    <img src="images/down.gif">
                                                    加载中....</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="r_b">
                                    </div>
                                </div>
                            </div>
                            <div class="clear"></div>
                            <div class="msglistable llmsgbg02" id="TodayDetailTab" style="display: none" name="TodayDetailTab">
                                <div id="dgMsgToMe">
                                </div>
                                <div class="rtop_wai" id="UserCenter_divMsgToMe" style="display: block">
                                    <div class="r_top">
                                    </div>
                                    <div class="r_c">
                                        <table width="262" height="164" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="262" align="center">
                                                    <img src="images/down.gif">
                                                    加载中....</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="r_b">
                                    </div>
                                </div>
                                .
                            </div>
                            <div class="clear"></div>
                            <div class="msglistable llmsgbg03" id="TodayDetailTab" style="display: none" name="TodayDetailTab">
                                <div id="dgMyDingYue">
                                </div>
                                <div class="rtop_wai" id="UserCenter_DingYue" style="display: block">
                                    <div class="r_top">
                                    </div>
                                    <div class="r_c">
                                        <table width="262" height="164" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="262" align="center">
                                                    <img src="images/down.gif">
                                                    加载中....</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="r_b">
                                    </div>
                                </div>
                            </div>
							<div class="clear"></div>
                        </div>
                        <ul>
                            <li id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(3);" name="TodyTab">
                                <img src="images_fhy/icon_li04.gif" align="absmiddle" /><a
                                    href="http://member.topfo.com/helper/FriendManager/FriendAttention.aspx">谁在关注我</a></li><li
                                        id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(4);" name="TodyTab">
                                        <img src="images_fhy/icon_li05.gif" align="absmiddle" /><a
                                            href="http://member.topfo.com/helper/FriendManager/FriendList.aspx">好友的更新</a></li><li
                                                id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(5);" name="TodyTab">
                                                <img src="images_fhy/icon_li06.gif" align="absmiddle" /><a
                                                    href="http://member.topfo.com/PayManage/trade_info_wait.aspx">我的购物车</a></li></ul>
                        <div class="con zhelpsanb" id="DispDown" name="DispDown" style="display: none">
                            <div class="msglistable llmsgbg04" id="TodayDetailTab" style="display: none" name="TodayDetailTab">
                                <div id="dgFocuseMe">
                                </div>
                                <div class="rtop_wai" id="UserCenter_FocuseMe" style="display: block">
                                    <div class="r_top">
                                    </div>
                                    <div class="r_c">
                                        <table width="262" height="164" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="262" align="center">
                                                    <img src="images/down.gif">
                                                    加载中....</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="r_b">
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="msglistable  llmsgbg05" id="TodayDetailTab" style="display: none" name="TodayDetailTab">
                         <div id="dgRefresh">
                        </div>
                        <div class="rtop_wai" id="UserCenter_Refresh" style="display: block">
                            <div class="r_top">
                            </div>
                            <div class="r_c">
                                <table width="262" height="164" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="262" align="center">
                                            <img src="images/down.gif">
                                            加载中....</td>
                                    </tr>
                                </table>
                            </div>
                            <div class="r_b">
                            </div>
                        </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="msglistable llmsgbg06" id="TodayDetailTab" style="display: none" name="TodayDetailTab">
                                <div id="dgCart">
                                </div>
                                <div class="rtop_wai" id="UserCenter_Cart" style="display: block">
                                    <div class="r_top">
                                    </div>
                                    <div class="r_c">
                                        <table width="262" height="164" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="262" align="center">
                                                    <img src="images/down.gif">
                                                    加载中....</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="r_b">
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="margin_d10">
                   <a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank"><img src="images_fhy/banner_04.jpg" class="border_3 "></a></div>
                <div class="centeralign">
                    <img src="images_fhy/gif-0119.gif" width="16" height="13" />
                    温馨提示：您只需花费<span class="fred14">1元钱</span>便能试用拓富通会员价值<span class="fred14">1000元</span>的贴心服务!</div>
					<div class="blank6"></div>
                <div class="center2">
                    <button class="btn_1" onmouseover="this.className='btn1_over'" onclick="window.location.href='helper/try_vip.aspx'"
                        onmouseout="this.className='btn_1'">
                        立即试用拓富通</button>
                </div>
                <div class="blank20"></div>
            </div>
            <div class="box_rr">
                <div class="s_block">
                    <div class="s_title">
                        <div class="s_title_ll">
                            <span>公告栏</span></div>
                        <div class="s_title_rr">
                            <span><span><a href="#" target="_blank">&gt;&gt;更多</a></span></span></div>
                        <br class="clear" />
                    </div>
                    <div class="right_list">
                    <asp:Label ID="lblBulletin"
                    runat="server"></asp:Label>
                        
                    </div>
                </div>
                <div class="s_block2">
                    <div class="s_title">
                        <div class="s_title_ll">
                            <span>新手向导</span></div>
                        <div class="s_title_rr">
                            <span><a href="http://www.topfo.com/help/index.shtml" target="_blank">&gt;&gt;更多</a></span></div>
                        <br class="clear" />
                    </div>
                    <div class="right_list">
                        <ul>
                            <li>·<a href="http://www.topfo.com/help/releasedemand.shtml" target="_blank">如何发布需求？</a></li><li>
                                ·<a href="http://www.topfo.com/help/releasecriterion.shtml" class="red">需求发布规范？</a></li><li>
                                    ·<a href="http://www.topfo.com/help/setupexhibit.shtml" target="_blank">为什么要创建我的展厅？</a></li><li>
                                        ·<a href="http://www.topfo.com/help/searchres.shtml" target="_blank">如何寻找资源？</a></li><li>
                                            ·<a href="http://www.topfo.com/help/buyres.shtml" target="_blank">如何购买收费资源？</a></li></ul>
                    </div>
                </div>
                <div class="margin_d10">
                    <a href="http://www.topfo.com/TopfoCenter/exponent/index.shtml" target="_blank">
                        <img src="images/banner_02.gif" /></a></div>
                <div class="s_block">
                    <div class="s_title">
                        <div class="s_title_ll">
                            <span>资源拓富指数排行</span>							
							</div>
							<br class="clear" />
                    </div>
                    <div class="right_list">
                        <uc1:IndexTFZS ID="IndexTFZS1" runat="server" />
                        &nbsp;</div>
                </div>
            </div>
        </div>
    </div>

    <script language="javascript">
        ChangeTodayTab(0)
    </script>

</asp:Content>
