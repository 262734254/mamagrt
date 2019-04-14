<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VIPMemberSubmint_In.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="Register_VIPMemberSubmint_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../css/Vip_Reg/VipReg.css" rel="stylesheet" type="text/css">
    <div class="vipreg_warp">
        <div class="reg_channel">
            申请成为拓富通会员，让您成功的机会提高<span>12</span>倍！
        </div>
        <div class="clear">
        </div>
        <div class="succeednote">
            <div class="succeelay">
                <div class="sleft">
                    <h2>
                        <img src="/images/vip_reg/icr03.gif" /></h2>
                    <div class="tip">
                        感谢您选择我们的拓富通服务！<br />
                        我们将会在一个工作日内与您电话联系！
                    </div>
                    <h3>
                        拓富通会员<span>6</span>大特权：</h3>
                    <div>
                        优先排序：让您在60万注册会员中脱颖而出，让合作方第一时间找到您。<br />
                        获得认证标志：99％的用户愿意与通过身份认证的会员洽谈合作。</div>
                    <div class="more">
                        <img src="/images/vip_reg/icon_yb.gif" />
                        <a href="" target="" class="lanlink">点此了解更多</a></div>
                </div>
                <div class="sright">
                    <h3>
                        请确认以下信息是否正确！<img height="21" src="../images/Application/icon_jt03.gif" width="20" /></h3>
                    <div class="rfall">
                        <h1>
                            <asp:Label ID="lbOrgName" runat="server" ForeColor="#FF8000"></asp:Label>
                            <asp:Label ID="lbtbRealName" runat="server" ForeColor="#FF8000"></asp:Label><asp:Label
                                ID="lbSex" runat="server"></asp:Label></h1>
                        <p>
                            会员类型：拓富通会员<asp:Label ID="lbManageType" runat="server"></asp:Label><br />
                            申请期限：<asp:Label ID="lbBuyTerm" runat="server"></asp:Label><br />
                            总金额：<asp:Label ID="lbPrice" runat="server"></asp:Label>元<br />
                            联系电话：<asp:Label ID="lbTel" runat="server"></asp:Label><br />
                            常用邮箱：<asp:Label ID="lbEmail" runat="server"></asp:Label></p>
                        <div class="dizi">
                            如果信息有误，
                            <img align="absMiddle" height="17" src="../images/icon_yb.gif" width="17" />
                            <asp:HyperLink ID="hlUpdate" runat="server">请点此修改</asp:HyperLink></div>
                        <a href="" target="" class="lanlink"></a>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="succeedownline">
            </div>
        </div>
        <div class="vipflow">
            <div class="flowtitle">
                您只需要如下几步，即可享受拓富通会员的<span>尊贵</span>服务</div>
        </div>
        <div class="vipflowp">
            <div class="flowbj">
                <div class="bgflow">
                    <h3>
                        签订协议</h3>
                    保障您的利益
                </div>
                <div class="arwflow">
                </div>
                <div class="bgflow">
                    <h3>
                        付 款</h3>
                    多种支付渠道轻松快捷
                </div>
                <div class="arwflow">
                </div>
                <div class="bgflow">
                    <h3>
                        身份认证</h3>
                    1-3个工作日
                </div>
                <div class="arwflow">
                </div>
                <div class="bgflow">
                    <h3>
                        开通服务</h3>
                    成为拓富通会员
                </div>
            </div>
        </div>
    </div>
</asp:Content>
