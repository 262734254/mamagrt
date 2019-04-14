<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="OrgRegisterSucceed.aspx.cs" Inherits="Register_OrgRegisterSucceed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/comp_register.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
init();
document.write("test");
function init()
{
     var typeVaule= document.getElementById("ctl00_ContentPlaceHolder1_Hidden1").value) ;
  
    if(typeVaule==0){
    document.getElementById("div1001").style.display="block";
    document.getElementById("div1002").style.display="none";
    }
    else if(typeVaule==1)
    {
       document.getElementById("div1002").style.display="block";
       document.getElementById("div1001").style.display="none";
    }
}
    </script>

    <div class="all_wrap" onload="init();">
        <div class="contant_l">
            <div class="up_note">
                <div class="up_note_ll">
                    <h3 class="f14_b2">
                        <asp:Label ID="lbOrgType" runat="server" Text="登记公司信息"></asp:Label>&nbsp;</h3>
                </div>
                <div class="up_note_rr">
                    <span>
                        <img src="../images/Company_Manage/biao_01.gif" align="absmiddle" /></span><span><a
                            href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank" class="lanlink">需求发布规则</a></span></div>
                <div class="clear"> </div>
            </div>
			<div style="clear:both;margin:3px;"> </div>
			
			
            <div class="dottedl lightc pad_1">
                <div class="float_all">
                    <img src="../images/Company_Manage/biao_03.gif" class="mar_5" /></div>
                <div class="float_all  spacing_1 mar_6 widthL11">
                    <span class="cu cheng font14">恭喜，您的信息<asp:Label ID="Label1" runat="server"></asp:Label>成功，已提交审核！<br />
                    </span>
					
                    <div class="clear"> </div>
                    <div id="Message" runat="server">
                    </div>
                    <div class="clear"></div>
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt; text-indent: 76.5pt; line-height: 12pt;
                        mso-char-indent-count: 8.5">
                        <span style="font-size: 9pt; color: black; font-family: 宋体"></span>
                    </p>
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt; text-indent: 76.5pt; line-height: 12pt;
                        mso-char-indent-count: 8.5">&nbsp;
                        </p>
                </div>
				<div class="clear"> </div>
			</div>
				
				
				
		<div class="clear"> </div>
		<div id="divMG"></div>
				<asp:Panel ID="panel1002" runat="server">
            <div id="div1002">
                <div class="grayLine1 pad_3 fz_14">
                    您现在可以：</div>
                <div>
                    <a href="/Publish/publishNavigate.aspx" class="Spaces">
                        <img src="../images/Company_Manage/arr_07.gif" align="absmiddle" class="mar_3 onpic" /></a>让客户主动找上门！</div>
                <div class="grayLine1 pad_3 fz_14">
                    <b>拓富通会员可以刷新自己登记的公司，优先排序：</b></div>
                <p>
                    规定的周期内，您登记的公司将放在普通会员的前面，被更多潜在客户关注。</p>
                <p>
                    优先排序的周期结束之后，您还可以通过<a href="/Manage/InfoRefreshSet.aspx"><span class="red_c2">刷新</span></a>您的公司，继续享有优先排序的权利，这可是拓富通会员专享的功能哦<br />
                    （每个公司每天只能刷新一次）!</p>
                <div class="widthTable400">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="table_style2">
                        <tr>
                            <td class="gray2 blue12_b">
                                位 置</td>
                            <td>
                                优先排序周期</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                分类列表</td>
                            <td>
                                一周</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                搜索列表</td>
                            <td>
                                一周</td>
                        </tr>
                    </table>
                </div>
            </div>
			</asp:Panel>
			<div class="clear"> </div>
			<asp:Panel ID="panel1001" runat="server">
            <div id="div1001" >
                <div class="grayLine1 pad_3 fz_14">
                    您现在可以：</div>
                <div>
                    <a href="../Publish/PublishMerchant1.aspx">
                        <img src="../images/Company_Manage/arr_07.gif" align="absmiddle" class="mar_3 onpic"></a>让客户主动找上门！</div>
                <div class="grayLine1 pad_3 fz_14">
                    升级拓富通会员，体验个性化服务，客户更信任！</div>
                <div class="widthTable620">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="table_style4">
                        <tr>
                            <td class="gray2">&nbsp;
                                </td>
                            <td>
                                拓富通会员</td>
                            <td>
                                普通会员</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                公司诚信认证</td>
                            <td>
                                有</td>
                            <td>
                                无</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                刷新设置，优先排序</td>
                            <td>
                                有</td>
                            <td>
                                无</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                个性化展厅
                            </td>
                            <td>
                                功能强大</td>
                            <td>
                                功能简单</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                VIP价格享受所有服务</td>
                            <td>
                                有</td>
                            <td>
                                无</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                专业服务</td>
                            <td>
                                有申请资格</td>
                            <td>
                                无申请资格</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="gray4">
                                <a href="http://www.topfo.com/Service/enterprisemember.shtml" class="lanlink">了解拓富通更多特权 &gt; &gt;</a></td>
                        </tr>
                    </table>
                    <div class="widthTable620">
                        <div class="float_all">
                            <a href="VIPMemberRegister_In.aspx" class="lanlink">花1元钱体验1天拓富通会员服务</a> <span><a href="VIPMemberRegister_In.aspx" class="lanlink mar_8">
                                马上申请拓富通</a></span>
                        </div>
                        <div class="float_right">
                            <span class="mar_8">0755-82210116</span> <span class="mar_8">82212980</span> <span
                                class="mar_8">在线客服</span> <span>
                                    <img src="../images/Company_Manage/arr_09.gif"></span>
                        </div>
                    </div>
                </div>
            </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
