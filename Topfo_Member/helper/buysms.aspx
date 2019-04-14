<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="短信购购条数-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="buysms.aspx.cs"
    Inherits="helper_buysms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/messagemanage.css" rel="stylesheet" type="text/css" />

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
            helper_buysms.getDis($id("txtcount").value,backres);
         }
    }
    function backres(res)
    {  
        var array=new Array();
        array=res.value.split('|');
        
        if(array[2]=="False")//非VIP
        {
             $id("lblmoney").innerHTML=array[1]+"元";
             $id("lbltofomoney").innerHTML="<font color='#C0C0C0'>"+array[0]+"元</font>";
        }
        else
        {
             $id("lblmoney").innerHTML="<font color='#C0C0C0'>"+array[1]+"元</font>";
             $id("lbltofomoney").innerHTML=array[0]+"元";
        }
       
        
    }   
    function post()
    {
        if($id("txtcount").value=="")
        {
            alert("请输入短信条数!");
            return false;
        }
        if(confirm("购买通知短信"+$id("txtcount").value+"条!"))
        {
           var a=$id("txtcount").value;
           window.location.href="http://pay.topfo.com/order_item_sms.aspx?smscount="+a;
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
                通知设置</div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <div class="suggestbox  lightc">
            ·您可以轻松使用站内短信、电子邮件、手机短信等方式接收各类通知。<br />
            ·<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank">拓富通会员</a>将享受500条免费手机短信服务。
            <br />
            ·普通会员如需使用手机短信服务，则需<a href="buysms.aspx">购买短信条数</a>，每条短信0.1元。</div>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li><a href="Notice.aspx" style="text-decoration: none">通知设置</a></li><li class="liwai">
                    购买短信 </li>
            </ul>
        </div>
        <div class="smsconbox cshibiank">
            <h1 class="dottedl">
                <img src="/images/icon_tishi.gif" align="absmiddle" />
                <span class="cheng">温馨提示：</span>您现在还可以接收<asp:Label ID="lblMobileCount" runat="server"
                    Text="0"></asp:Label>条手机短信</h1>
            <table width="465" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="46" align="right">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="186" align="right" style="height: 27px">
                        请输入购买手机短信条数:</td>
                    <td colspan="2" style="height: 27px">
                        <input name="textarea" type="text" value="" onkeyup="getpoint()" size="15" id="txtcount"
                            maxlength="9" />
                        条(输入整数)</td>
                </tr>
                <tr>
                    <td align="right">
                        购买费用:</td>
                    <td class="chengcu">
                        <span id="lblmoney">0</span></td>
                    <td class="chengcu">
                        <a href="/Register/VIPMemberRegister_In.aspx">
                            <img src="../images/buttom_lijisj.gif" width="188" height="26" border="0" id="imgVip"
                                runat="server" /></a></td>
                </tr>
                <tr>
                    <td align="right">
                        拓富通会员购买:</td>
                    <td width="64" class="chengcu">
                        <span id="lbltofomoney">0</span></td>
                    <td width="215" align="left" class="cheng">
                        (拓富通会员享受8折购买优惠)</td>
                </tr>
                <tr>
                    <td height="49" colspan="3" align="center">
                        &nbsp;<input type="button" class="buttomal" id="Submit1" style="width: 92px" onclick="post()"
                            value="立即购买" /></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
