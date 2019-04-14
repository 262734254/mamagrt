<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trade_info_waitTest.aspx.cs" Inherits="PayManage_trade_info_waitTest" %>
<%@ Register Src="../Controls/PayPageFoot.ascx" TagName="PayPageFoot" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="/css/paymanage.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>

    <script type="text/javascript" language="javascript" src="/javascript/comm.js"></script>

    <script language="javascript" type="text/javascript">
    function chkValue()
	{
	    var a = document.documentElement.getElementsByTagName("input");
		var str="";

		for (var i=0; i<a.length; i++) 
		{
			if (a[i].type == "checkbox")
			{
				if(a[i].checked)
				{
					str+=a[i].value+",";
				}
			}
		}
		if(str!="")
		{
		alert(str);
		    if(confirm('确定删除吗?'))
		        deleteChk(str);
		}
		else
		{
		   alert("请选择所要删除的项");
		}
	}
	
	//获取批量购买的id号
	function GetSelectValue()
	{
	    var a=document.documentElement.getElementsByTagName("input");
	    var str="";
	    
	    for( var i=0;i<a.length;i++)
	    {
	        if(a[i].type=="checkbox")
	        {
	            if(a[i].checked)
	            {
	                str+=a[i].value+",";
	            }
	        }
	    }
	    
	    if(str!="")
	    {
	        window.open("http://pay.topfo.com/account/Lotaccountpay.aspx?order_no="+str,"_blank");
	    }
	    else 
	    {
	        alert("请选择资源！");
	    }
	}
	
	
    function deleteChk(str)
    {
        PayManage_trade_info_wait.deleShopCar(str,backres);
    }
    function backres(res)
    {
        if(res)
            window.location.reload();
        else
            alert("删除失败");
            
    }
    </script>
<body>
 
    <form id="form1" runat="server">
    
<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                资源交易管理</div>
            <div class="right" style="margin-bottom: 13px;">
                <img src="http://member.topfo.com/images/hand_1_2.gif" />
                <a href="http://www.topfo.com/web13/help/resourceswap.shtml" target="_blank" class="chenglink">
                    交易完全教程</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox">
            <h1>
                温馨提示：</h1>
            <p>
                ·我们为您开通了多种支付渠道，无论金额大小皆可轻松支付！
                <br />
                ·如果您的账户余额充足，使用账户余额支付是最快捷的支付方式。您现在的账户余额为
                <asp:Literal runat="server" ID="lblUserPoint"></asp:Literal>元。 点此&gt;&gt;<a href="account_cz.aspx"
                    class="chenglink">立即充值</a><br />
                ·为降低您的交易风险，建议您优先选择<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml"
                    target="_blank" class="chenglink">拓富通会员</a>发布的资源！<br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--我的购物车 -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li class="liwai">我的购物车</li><li><a href="trade_info_list.aspx" style="text-decoration: none">
                        已付款交易</a></li><li><a href="ticket_trade_list.aspx">购物券交易</a></li></ul>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        资源查询：



                        <select id="ddldiff" name="select" runat="server">
                            <option value="all" selected="selected">全部</option>
                            <option value="90">三个月以上</option>
                            <option value="30">最近一月</option>
                            <option value="3">最近三天</option>
                            <option value="7">最近一周</option>
                            <option value="14">最近两周</option>
                        </select>
                        <label>
                        </label>
                        <select id="ddltype" name="select2" runat="server">
                            <option value="all" selected="selected">全部</option>
                            <option value="Merchant">招商资源</option>
                            <option value="Capital">投资资源</option>
                            <option value="Project">项目资源</option>
                        </select>
                        <select id="ddluserType" name="select3" runat="server">
                            <option value="all" selected="selected">所有会员</option>
                            <option value="1">政府会员</option>
                            <option value="2">企业会员</option>
                            <option value="2">个人会员</option>
                        </select>
                        <input id="Submit1" type="submit" value="查询" name="button" runat="server" onserverclick="button_ServerClick" />
                    </div>
                    <div class="rights">
                        每页显示：<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>条



                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        条 <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        条</div>
                    <div class="clear">
                    </div>
                </div>
                <table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">
                    <td width="4%"  align="center" class="tabtitle">
                    <a href="javascript:;" onclick="chkAll()">选择</a>
                    </td>
                        <td width="10%" align="center" class="tabtitle">
                            类别</td>
                        <td align="left" class="tabtitle" style="width: 20%">
                            资源标题</td>
                        <td width="15%" align="center" class="tabtitle">
                            价格(元)</td>
                        <td width="10%" align="center" class="tabtitle">
                            发布时间</td>
                        <td width="20%" align="center" class="tabtitle">
                            状态</td>
                        <td width="8%" align="center" class="tabtitle">
                            匹配</td>
                         
                    </tr>
                    <asp:Repeater runat="server" ID="myList">
                        <ItemTemplate>
                        <tr>
                        <td width="4%"  align="center"><input type=checkbox name=checkbox value="<%#Eval("ShopCarID") %>" /></td>
                            
                                <td width="10%" height="25" align="center">
                                   <%#GetTypeName(Eval("InfoTypeID"))%>
                                </td>
                                <td width="20%">
                                    <%#GetUrl(Eval("InfoTypeID").ToString(), Eval("HtmlFile").ToString(), Eval("SourceType").ToString())%>
                                </td>
                                <td width="15%" align="center">
                                <%#Eval("disWorthPoint") == "" ? Eval("WorthPoint", "{0:N}") : Eval("disWorthPoint", "{0:N}")%>
                                    元


                                </td>
                                <td width="10%" align="center">
                                    <%#Eval("packdate","{0:yyyy-MM-dd}")%>
                                </td>
                                <td width="20%" align="center">
                                    
                                   <a target="_blank" href="order_itemTest.aspx?InfoID=<%#Eval("InfoID") %>">
                                        立即付款</a>|--%> <a href='trade_detail.aspx?infoid=<%#Eval("infoid") %>&type=info&status=0'>
                                            查看明细</a>
                                </td>
                                <td width="8%" align="center">
                                    <a href="/Manage/PertinentLink.aspx?infoid=<%#Eval("InfoID") %>&type=<%#Eval("InfoTypeID") %>">相关资源</a><a href="#"></a></td>
                                
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                           <td width="4%"  align="center"><input type=checkbox name=checkbox value="<%#Eval("ShopCarID") %>" /></td>
                                <td width="10%" height="25"  align="center">
                                     <%#GetTypeName(Eval("InfoTypeID"))%>                                
                                </td>
                                <td width="26%" class="tabb">
                                   <a href='http://www.topfo.com/<%#Eval("HtmlFile")%>' target="_blank" title="<%#Eval("SourceType")%>">
                                        <%#GetStr(Eval("SourceType"),15)%>
                                    </a>
                                </td>
                                <td width="15%" align="center" class="tabb">
                               <%#Eval("disWorthPoint") == "" ? Eval("WorthPoint", "{0:N}") : Eval("disWorthPoint", "{0:N}")%>
                                    元


                                </td>
                                <td width="15%" align="center" class="tabb">
                                    <%#Eval("packdate","{0:yyyy-MM-dd}")%>
                                </td>
                                <td width="20%" align="center" class="tabb">
                                     <a target="_blank" href="order_item.aspx?InfoID=<%#Eval("InfoID") %>">
                                        立即付款</a>| <a href='order_item.aspx?infoid=<%#Eval("infoid") %>&type=info&status=0'>
                                            查看明细</a>
                                </td>
                                <td width="8%" align="center" class="tabb">
                                    <a href="order_item.aspx?InfoID=<%#Eval("InfoID") %>">相关资源</a><a href="#"></a></td>
                                
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
               
                <p>
                  <a href="javascript:;" onclick="chkAll2()">全选</a> /<a href="javascript:;" onclick="chkAll()">反选</a>
                    
                    总记录：<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                            runat="server" Text="0"></asp:Literal>页


                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>转到
                        第


                        <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                            runat="server">
                        页</span>
                    <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                        font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                </p>
               
            </div>      
            </contenttemplate>
            </asp:UpdatePanel>
            <div class="buttom">
                <input type="button" value="批量购买" title="批量购买所选择的商品" class="buttomal" onclick="GetSelectValue()" />
                <input type="button" value="删除所选" class="buttomal" onclick="chkValue()" />
                <input type="button" class="buttomal" onclick="window.open('http://search.topfo.com/SearchAllResult.aspx')"
                    value="继续寻找资源>>" />
            </div>
        </div>
        <div class="blank20">
        </div>
        <!--帮助 -->
        <div class="helpbox">
            <div class="titleh">
                <img src="../images/PayManage/biao_print.gif" />
                <a href="javascript:;" onclick="window.print();">打印该页</a></div>
            <div class="con">
                <h1>
                    <img src="../images/icon_yb.gif" align="absmiddle" />
                    帮助</h1>
                <p>
                    · 如果您提交了订单，点击"查看明细"可以查看订单的明细情况；<br />
                    · 相关资源是指系统根据您选择的资源为您推荐的类似资源；<br />
                </p>
                <dir>
                    <img src="../images/PayManage/hand.gif" width="18" height="12" />
                    <a href="http://www.topfo.com/help/resourceswap.shtml" target="_blank">更多帮助</a></dir></div>
            <div class="bottomzi">
                <uc1:PayPageFoot ID="PayPageFoot1" runat="server" />
                &nbsp;</div>
        </div>
    </div>
    </form>
</body>
</html>
