<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="我的购物券-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="ticket_exchange.aspx.cs"
    Inherits="PayManage_ticket_exchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />


    <script language="javascript">
function chkpost()
{
    if ($id("txtExCount").value=="")
    { 
        $id("txtExCount").value="";
        divmsg.innerHTML="<font color='red' size=2>输入整数";
        $id("txtExCount").focus();
       
        return false;
    }
}
function changejifen(v)
{

    var re = /^[1-9]+[0-9]*]*$/   
    if (!re.test($id("txtExCount").value))
    { 
        $id("txtExCount").value="";
        divmsg.innerHTML="<font color='red' size=2>输入整数";
        $id("txtExCount").focus();
        return false;
    }
   if(parseInt(v)>parseInt($id("lblOwnerCount").innerText))
   {
        divmsg.innerHTML="<font color='red' size=2>积分不够";
         $id("txtExCount").value="";
        $id("txtExCount").focus();
        return false;
   }
   else
   {
      divmsg.innerHTML="";
   }
   if(v!="")
   {
      var b=$id("hidB");
      document.getElementById("ExCount").innerText=v/b.value;
   }
 
}

function $id(obj)
{
    return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
}
    </script>

    <!--我的购物车 -->
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的购物券
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox allxian">
            <h1>
                温馨提示：</h1>
            <p>
                ·每<asp:Literal ID="lbVRate" runat="server"></asp:Literal>积分可以兑换1.00元购物券，每人每天最高可兑换<asp:Literal
                    ID="lbExLimit" runat="server"></asp:Literal>元
                <br />
                ·购物券有效使用期为兑换之日起<asp:Literal ID="lbVTerms" runat="server"></asp:Literal>个月内，超过<font
                    class="cheng"><asp:Literal ID="lbVTerms2" runat="server"></asp:Literal>个月仍未消费的购物券将自动作废
                </font>&nbsp;<a href="ticket_exchange_record.aspx" class="lanlink">查看我的购物券有效期</a>
                <br />
                ·购物券只能购买指定的资源
                <br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--购物券兑换 -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li class="liwai">购物券兑换</li><li><a href="ticket_exchange_record.aspx" style="text-decoration: none">
                        兑换记录</a></li><li><a href="http://pay.topfo.com/cost/Project.aspx" target="_blank"
                            style="text-decoration: none">购物券资源专区</a> </li>
                </ul>
            </div>
            <div class="con cshibiank">
                <div class="left">
                    <div class="top">
                        <ul>
                            <li>您的剩余积分：<asp:Label ID="lblOwnerCount" runat="server">0</asp:Label>
                                分</li><li>可兑换购物券：<asp:Literal ID="lblExCount" runat="server">0</asp:Literal>
                                    元<br />
                                </li>
                            <li>购物券剩余金额：<span class="chengcu"><asp:Literal ID="lblLeft" runat="server" Text="0"></asp:Literal></span>元</li><div
                                class="clear">
                            </div>
                        </ul>
                        <div class="blank20">
                        </div>
                        <div>
                            <a href="http://www.topfo.com/web13/help/tradeticket.shtml#13" target="_blank" class="lanlink">
                                如何获得更多积分</a> <a href="ticket_exchange_record.aspx" class="lanlink">查看我的兑换记录</a>
                            <a href="ticket_exchange_record.aspx" class="lanlink" style="display: none">查看我的购物券消费记录</a></div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="blank0">
                    </div>
                    <table width="348" height="152" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="165" height="38" align="right">
                                我要兑换：</td>
                            <td width="191">
                                <label>
                                    <input name="textarea" type="text" id="txtExCount" onkeyup="changejifen(this.value)"
                                        value="" size="7" runat="server" />
                                </label>
                                积分 <span id="divmsg"></span>
                            </td>
                        </tr>
                        <tr>
                            <td height="38" align="right">
                                可兑换购物券金额：</td>
                            <td>
                                <span id="ExCount">0.00</span> 元</td>
                        </tr>
                        <tr>
                            <td height="1" colspan="2" bgcolor="#CCCCCC">
                            </td>
                        </tr>
                        <tr>
                            <td height="70" colspan="2" align="center">
                                <label>
                                    &nbsp;
                                    <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="兑换" Width="53px"
                                        CssClass="buttomal" />
                                    &nbsp;
                                    <input type="reset" name="button2" id="button2" value="重置" style="width: 46px" class="buttomal" />
                                    <input id="hidB" runat="server" style="width: 44px" type="hidden" /></label></td>
                        </tr>
                    </table>
                </div>
                <div class="right" style="display: none">
                    <h2>
                        精选购物券资源
                    </h2>
                    <table width="326" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <strong>资源标题 </strong>
                            </td>
                            <td>
                                <strong>价格(元)</strong></td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <!--帮助 -->
    </div>
</asp:Content>
