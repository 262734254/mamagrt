<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="InviteFriend.aspx.cs" Inherits="Register_InviteFriend" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
.vipreg_warp{float:right;width:750px; clear:both}
.vipreg_warp{padding-bottom:18px;}
.reg_channel{ background:url(/images/vip_reg/bg01.gif) no-repeat 0 0;width:756px;height:38px;display:block}
.reg_channel{ text-align:right;padding-top:25px;font-weight:bold;font-size:11pt;color:#1F73C1;}
.reg_channel span{ font-size:20pt;color:#FF6600;}
.vrtopbg{background: url(/images/vip_reg/bg02.gif) no-repeat top left;height:18px;width:756px; display:block;margin-top:6px; }
.vip_box{width:747px; clear:both;border:1px solid #7EB3F0;border-width:0px 1px 1px 1px; clear:both;padding-bottom:20px;}
.vip_title1{padding:9px 0 0 60px;}
.vipcont{width:694px;margin:15px auto}
.vipcont h3{font-size:14px;margin:12px 0 8px 0;font-weight:bold;color:#ff6600;}
.method{ margin-bottom:30px;float:left;width:100%;clear:both;}
.method input{margin-top:6px;}
.method2{ float:left;width:100%;clear:both;}
.vntop{width:694px;margin:0 auto}
.vntop{ background:#F3F3F3 url(/images/vip_reg/bg03.gif) no-repeat 0 0;padding-top:10px;}
.vnbot{ background:url(/images/vip_reg/bg04.gif) no-repeat bottom left; padding-bottom:15px;}
.vnimg{ background: url(/images/vip_reg/icr01.gif) no-repeat left 0px; display:block;padding-left:90px;}
.vnimg h3{ color:#F75F03;font-size:11pt;font-weight:bold}
.vnimg p{line-height:28px;}
.vipInfo{width:694px;clear:both}
.vipInfo td{font-size:10pt; vertical-align:top;padding-bottom:12px;padding-top:4px;}
.vipInfo td span{color:#ff0000;}
.vipInfo td.w120{width:186px; text-align:right;padding-right:8px;}
.vipInfo td.vipsolid{ border-top:1px  dashed #C0C0C0;}
.btn_style1{ background:url(/images/vip_reg/bt03.gif) no-repeat bottom left;border:0;height:25px;padding:3px 0 2px 0;letter-spacing:1px;width:187px; text-align:center; cursor:hand; cursor:pointer}
input.fstyel{padding:2px 4px; cursor:hand; cursor:pointer}
.viplineon{ background:#FFFCC7;border:1px solid #F3C089;font-size:9pt;margin-left:6px;padding:2px 5px; color:#FD2704;line-height:14px;}
.viplineoff{ background:#F3F3F3;border:1px solid #e4e4e4;font-size:9pt;margin-left:6px;padding:2px 5px;line-height:16px;width:290px;}
.selwi{width:340px;height:130px;padding:2px;line-height:16px;}
.vipwid200{width:200px;}
.vipwid300{width:340px;padding:1px;}
.vipgj{width:40px;margin-right:4px;}
.vipgj2{width:100px;margin-right:4px;}
.vipcenter{ text-align:center}
.vipdj{width:720px;margin:20px auto;padding-bottom:80px; clear:both}
.r12font{color:#ff0000;}
</style>

    <script language="javascript" type="text/javascript">
    function showMsg(messsage)
    {
        alert(messsage); 
       return false;
    }
    function checkValf()
    {
        //var Rex = /^(\w\,)*$/;
        var femail = document.getElementById("ctl00_ContentPlaceHolder1_txtFemail").value;
        var email = document.getElementById("ctl00_ContentPlaceHolder1_txtemail").value;
        var name  = document.getElementById("ctl00_ContentPlaceHolder1_name").value;
        var ssc = document.getElementById("ctl00_ContentPlaceHolder1_content").value;
       
        
        if(femail.length < 1)
        { return showMsg("请填写你好友的E-Mail!");}
        else
        {
            var Rex = /^([\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+\,?)+$/;
            if(!Rex.test(femail))
            { return showMsg("好友邮箱格式不正确!") }
        }
        
        if(email.length < 1 || name.length <1)
        { return  showMsg("请填写完整带星号的项!"); }
        else
        {
            var Rex = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
            if(!Rex.test(email))
            { return showMsg("您的邮箱格式不正确！");}
        }
        
        
        if(ssc.length < 1)
        { return  showMsg("邮件内容不能为空！");}
        
        return true;
    }
  
    document.getElementById("aspnetForm").onsubmit = checkValf;
    </script>

    <div class="vipreg_warp">
        <div>
            <img src="http://member.topfo.com/images/vip_reg/yqtitle01.gif" /></div>
        <div class="clear">
        </div>
        <div class="vrtopbg">
        </div>
        <div class="vip_box">
            <div class="vntop">
                <div class="vnbot">
                    <div class="vnimg">
                        <h3>
                            温馨提示：</h3>
                        <p>
                            ·您每成功邀请一个好友注册成为我们的会员，便可以获得500积分；<br />
                            ·100积分兑换1元购物券，购物券可以购买我们高质量的收费资源哦！ <a href="http://www.topfo.com/web13/help/tradeticket.shtml"
                                target="_blank" class="lanlink">如何兑换购物券？</a><br />
                            ·每人最多只能推荐50名新会员；
                        </p>
                    </div>
                </div>
            </div>
            <div class="vipcont">
                <h3>
                    您可以通过以下两种方式推荐：</h3>
                <div class="method">
                    <div class="float_all cu">
                        方法一：</div>
                    <div class="float_all">
                        <b>点击下面的按钮复制注册的地址，通过MSN、QQ等发给您的好友</b><br />
                        <span class="cheng">别忘了，让您的朋友注册时在“邀请人”一栏填上您的昵称：<asp:Label ID="pnick2" runat="server"></asp:Label></span><br />
                        <input name="" readonly="readonly" type="text" class="vipwid300" value="http://member.topfo.com/Register/Register.aspx" /><br />
                        <input type="button" onclick="clipboardData.setData('Text','http://member.topfo.com/Register/Register.aspx');alert('已经成功复制到粘贴板，马上粘贴到MSN、QQ等发给您的好友吧！');"
                            name="Submit3" value="复制推荐地址发送给好友" class="btn_style1" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="method2">
                    <div class="float_all cu">
                        方法二：</div>
                    <div class="float_all">
                        <b>通过邮件推荐好友注册</b>(<span class="cheng">*为必填项</span>)
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="vipInfo">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="w120">
                                <span>*</span>输入您的好友E-mail：</td>
                            <td>
                                <div class="float_all">
                                    <asp:TextBox ID="txtFemail" runat="server" CssClass="vipwid200"></asp:TextBox></div>
                                <div class="float_all viplineon">
                                    如果您要填写多个好友的E-mail，请用 , 隔开</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="w120">
                                <span>*</span>您的E-mail：</td>
                            <td>
                                <div class="float_all">
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="vipwid200"></asp:TextBox></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="w120">
                                <span>*</span>您的名字：</td>
                            <td>
                                <asp:TextBox ID="name" runat="server" CssClass="vipwid200"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="w120">
                                邮件内容：</td>
                            <td>
                                <textarea name="textarea" id="content" runat="server" class="selwi">　　
 </textarea></td>
                        </tr>
                        <tr>
                            <td class="w120">
                                &nbsp;</td>
                            <td>
                                <input type="submit" id="button1" runat="server" name="Submit" value="发送" class="fstyel"
                                    onserverclick="button1_ServerClick" />
                                <input type="reset" name="Submit2" value="取消" class="fstyel" /></td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
