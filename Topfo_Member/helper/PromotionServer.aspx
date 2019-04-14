<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" Title="通知设置-拓富中心-中国招商投资网" CodeFile="PromotionServer.aspx.cs"
    Inherits="helper_PromotionServer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<link href="/css/promotion.css" rel="stylesheet" type="text/css" />

     <script language="javascript" type="text/javascript">
    function getpoint()
    {
        var re = /^[1-9]+[0-9]*]*$/   
        if (!re.test($id("txtcount").value))
        {
            $id("txtcount").value="";
            $id("txtcount").focus();
            return false;
         }
         
         if($id("txtcount").value.length>9)
         {
            $id("txtcount").value=$id("txtcount").value;
            return false;
         }
         else
         {
            helper_PromotionServer.getDis($id("txtcount").value,backres);
         }
    }
    function backres(res)
    {  
        var array=new Array();
        array=res.value.split('|');
         if(array[2]=="False")//非VIP
        {
           
             $id("lblmoney").innerHTML=array[0]+"元";
             $id("lbltofomoney").innerHTML="<font color='#C0C0C0'>"+array[1]+"元</font>";
        }
        else
        {
             $id("lblmoney").innerHTML="<font color='#C0C0C0'>"+array[0]+"元</font>";
             $id("lbltofomoney").innerHTML=array[1]+"元";
        }
        
    }   
    function post()
    {
        if($id("txtcount").value=="")
        {
            alert("请输入短信条数!");
            return false;
        }
        if(confirm("购买推广短信"+$id("txtcount").value+"条!"))
        {
           var a=$id("txtcount").value;
           window.location.href="http://pay.topfo.com/order_item_promotion.aspx?smscount="+a;
        }
    }
  
    function $id(obj)
    {
       
       return document.getElementById(obj);
    }
    </script>

    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                定向推广</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" alt="" width="14" height="15" align="absmiddle" />
               <a href="http://www.topfo.com/help/directionalextend.shtml#12"  target="_blank">使用说明</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="/helper/myPromotion.aspx">推广我的需求</a></li><li><a href="/helper/getPromotion.aspx">我收到的推荐资源</a></li><li><a href="/helper/ReceivedSet.aspx">接收设置</a> </li>
                <li class="liwai">服务购买</li></ul>
        </div>
        <div class="buybox cshibiank">
            <h1 class="dottedl lightc">
                <img src="/images/icon_tishi.gif" align="absmiddle" alt=""/> <span class="cheng"> 温馨提示：</span>您现在还可以发送<asp:Literal ID="lblPromotionCount" runat="server" Text="0"></asp:Literal>条定向推广，每条定向推广包括邮件、站内短信和手机短信三种形式的推送。</h1>
            <div class="blank20">
            </div>
            <table width="449" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="191" align="right">
                        定向推广条数:</td>
                    <td colspan="2">
                       <input name="textarea" runat="server" type="text"  onkeyup="getpoint()"
                            size="15" id="txtcount" maxlength="9" />
                        条(输入整数)</td>
                </tr>
                <tr>
                    <td align="right">
                        购买费用:</td>
                    <td colspan="2" class="chengcu">
                        <span id="lblmoney">0</span></td>
                </tr>
                <tr>
                    <td align="right">
                        拓富通会员购买:</td>
                    <td width="59" class="chengcu">
                        <span id="lbltofomoney">0</span></td>
                    <td width="199">
                        <a href="/Register/VIPMemberRegister_In.aspx">
                            <img src="../images/buttom_lijisj2.gif" alt="" width="188" height="26" border="0" /></a></td>
                </tr>
                <tr>
                    <td height="49" colspan="3" align="center">
                        <input name="Submit" onclick="post()" type="button" class="buttomal" value="立即购买" />
                    </td>
                </tr>
            </table>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>