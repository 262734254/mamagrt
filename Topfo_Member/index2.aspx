<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="index2.aspx.cs" Inherits="index" ResponseEncoding="GB2312" Title="Untitled Page" %>

<%@ Register Src="Controls/IndexTFZS.ascx" TagName="IndexTFZS" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="JavaScript/TodayCommand.js" type="text/javascript"></script>

    <script language="javascript" src="JavaScript/UserCenter.js" type="text/javascript"></script>

    <div class="in_wrap">
        <div class="note">
            <h3 class="cc_1">
                �𾴵�<span><asp:Label runat="server" ID="lblUserName"></asp:Label></span></h3>
            <p class="note_info">
			���ã�Ϊ�˸�����Ա�ṩ�����ʵķ����й�����Ͷ����¡���Ƴ��ظ�ͨ��Ա�����Ĵ����������ظ������ɣ�<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" class="blue" target="_blank">���˽�һ��</a></p>
            <p class="note_info">
               ������������ǵķ����뽫 <span class="red_2">topfo.com</span> �Ƽ����������ѡ����ڣ���ÿ�ɹ��Ƽ�һλ����ע�ᣬ���ܵõ�<span class="red_2"> 500 </span>���֣�100����=1Ԫ����ң������ֶһ�����Թ�����վ���������շ���ԴŶ��<a href="http://member.topfo.com/Register/InviteFriend.aspx" class="blue" target="_blank">���������ҵ�����</a></p>
        </div>
        <div class="bottom_wrap">
            <div class="box_ll">
                <div class="all_box">
                    <h3 class="allboxt f14_b">
                        <div class="allbtbg">
                            <span>��Ҫ������ʾ</span></div>
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
                            ��ֵ�����ƹ��������ˣ���Ա�������������Լ�����Ҫ�ķ�������<br />
                            ������Ŀ<br />
                            �����ƹ㡡���Կ���Դ�Ƽ�������ҵ�ƻ���ժҪ����������־�ƹ�<br />
                            �쵼ר�á������չʾ������������·�� ����������ר���Ƽ�<br />
                            �����񡡡�վ�ڻ��桡��������滥��խ��<br />
                            <br />��������������������������<a href="/valueadd/ServiceAdd.aspx">�鿴��ֵ����������</a>

                        </div>
                    </div>
                </div>
                <div class="all_box">
                    <h3 class="allboxt f14_b">
                        <div class="allbtbg">
                            <span>�ظ�������ʾ��</span></div>
                    </h3>
                    <div class="zhelpbox">
                        <ul>
                            <li class="liwai" id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(0);" name="TodyTab">
                                <img src="images_fhy/icon_mail.gif" width="16" height="10" /><a href="http://member.topfo.com/InnerInfo/inbox2.aspx">�ҵĶ���Ϣ</a></li><li id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(1);"
                                        name="TodyTab">
                                        <img src="images_fhy/icon_ly.gif" width="15" height="13" /><a href="http://member.topfo.com/helper/InfoComment/commentReceive.aspx">���ҵ�����</a></li><li class="linone" id="TodyTab"
                                                onmouseover="JavaScript:ChangeTodayTab(2);" name="TodyTab">
                                                <img src="images_fhy/icon_ty.gif" width="21" height="16" align="absmiddle" /><a href="http://member.topfo.com/helper/MatchingInfo.aspx">�ҵĶ���</a></li></ul>
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
                                                    ������....</td>
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
                                                    ������....</td>
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
                                                    ������....</td>
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
                                    href="http://member.topfo.com/helper/FriendManager/FriendAttention.aspx">˭�ڹ�ע��</a></li><li
                                        id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(4);" name="TodyTab">
                                        <img src="images_fhy/icon_li05.gif" align="absmiddle" /><a
                                            href="http://member.topfo.com/helper/FriendManager/FriendList.aspx">���ѵĸ���</a></li><li
                                                id="TodyTab" onmouseover="JavaScript:ChangeTodayTab(5);" name="TodyTab">
                                                <img src="images_fhy/icon_li06.gif" align="absmiddle" /><a
                                                    href="http://member.topfo.com/PayManage/trade_info_wait.aspx">�ҵĹ��ﳵ</a></li></ul>
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
                                                    ������....</td>
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
                                            ������....</td>
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
                                                    ������....</td>
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
                    ��ܰ��ʾ����ֻ�軨��<span class="fred14">1ԪǮ</span>���������ظ�ͨ��Ա��ֵ<span class="fred14">1000Ԫ</span>�����ķ���!</div>
					<div class="blank6"></div>
                <div class="center2">
                    <button class="btn_1" onmouseover="this.className='btn1_over'" onclick="window.location.href='helper/try_vip.aspx'"
                        onmouseout="this.className='btn_1'">
                        ���������ظ�ͨ</button>
                </div>
                <div class="blank20"></div>
            </div>
            <div class="box_rr">
                <div class="s_block">
                    <div class="s_title">
                        <div class="s_title_ll">
                            <span>������</span></div>
                        <div class="s_title_rr">
                            <span><span><a href="#" target="_blank">&gt;&gt;����</a></span></span></div>
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
                            <span>������</span></div>
                        <div class="s_title_rr">
                            <span><a href="http://www.topfo.com/help/index.shtml" target="_blank">&gt;&gt;����</a></span></div>
                        <br class="clear" />
                    </div>
                    <div class="right_list">
                        <ul>
                            <li>��<a href="http://www.topfo.com/help/releasedemand.shtml" target="_blank">��η�������</a></li><li>
                                ��<a href="http://www.topfo.com/help/releasecriterion.shtml" class="red">���󷢲��淶��</a></li><li>
                                    ��<a href="http://www.topfo.com/help/setupexhibit.shtml" target="_blank">ΪʲôҪ�����ҵ�չ����</a></li><li>
                                        ��<a href="http://www.topfo.com/help/searchres.shtml" target="_blank">���Ѱ����Դ��</a></li><li>
                                            ��<a href="http://www.topfo.com/help/buyres.shtml" target="_blank">��ι����շ���Դ��</a></li></ul>
                    </div>
                </div>
                <div class="margin_d10">
                    <a href="http://www.topfo.com/TopfoCenter/exponent/index.shtml" target="_blank">
                        <img src="images/banner_02.gif" /></a></div>
                <div class="s_block">
                    <div class="s_title">
                        <div class="s_title_ll">
                            <span>��Դ�ظ�ָ������</span>							
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
