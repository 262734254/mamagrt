<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="GB2312" MasterPageFile="~/MasterPage.master"
    Title="通知设置-拓富中心-中国招商投资网" CodeFile="getPromotion1.aspx.cs" Inherits="helper_getPromotion1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--
    <link href="/css/promotion.css" rel="stylesheet" type="text/css" />
-->

    <script language="javascript" type="text/javascript">
    function chkAll()
    {
       var a =document.getElementsByTagName("input"); 
       for (var i=0; i<a.length; i++)
	   {
		 if (a[i].type == "checkbox") 
		 a[i].checked =!a[i].checked;
	    }
         
    }
    function chkValue(flag)
	{
	    var a = document.documentElement.getElementsByTagName("input");
		var str="";

		for (var i=0; i<a.length-3; i++) 
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
		      if(flag=="1")
		      {
		          if(confirm("确定拒收所选推荐吗?拒收后该用户所有信息将不会接收到!"))
	              {
		            NoReceive(str);
		          }
		      }
		      if(flag=="2")
		      {
		          if(confirm("确定删除推荐资源吗?"))
	              {       
		            DeleteInfo(str);
		          }
		      }
		}
		else
		{
		   alert("请选择所要设置的项");
		}
	}
	function NoReceive(str)
	{
	    helper_getPromotion.NoReceive(str,backres)
	}
	function DeleteInfo(str)
	{
	   helper_getPromotion.DeleteInfo(str,backres);
	}
	function DeleteAll()
	{
	   if(confirm("确定删除所有推荐资源吗?"))
	   { 
	        helper_getPromotion.DeleteAllInfo(backres);
	   }
	}
	function AddBlack(obj)
	{
	    if(confirm("拒收后将不能收到"+obj+"推荐的资源"))
	    { 
	        helper_getPromotion.AddBlack(obj,backres);
	    }
	}
	function backres(res)
	{
	   
	    if(res.value=="success")
	    {
	        window.location.reload();
	    }
	}
	function del()
{
    return confirm('这将不可恢复,真的要删除吗？');
}
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                定向推广</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" alt="" width="14" height="15" align="absmiddle" />
                <a href="http://www.topfo.com/help/directionalextend.shtml#12" target="_blank">使用说明</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="/helper/myPromotion.aspx">推广我的需求</a> </li>
                <li class="liwai">我收到的推荐资源</li><li><a href="/helper/ReceivedSet.aspx">接收设置</a> </li>
                <li><a href="/helper/PromotionServer.aspx">服务购买</a> </li>
            </ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
                <div class="demandbox cshibiank">
                    <h1 class="dottedl lightc">
                        <img src="/images/icon_tishi.gif" align="absmiddle" />
                        <span class="cheng">温馨提示：</span>如果你不想收到这样的推广内容，您可以退订或设置详细接收条件。</h1>
                    <div class="blank20">
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="chkTab">
                        <tr>
                            <td colspan="2" class="tabtitle" style="width: 24%">
                                资源标题</td>
                            <td width="11%" align="center" class="tabtitle">
                                资源类型</td>
                            <td width="19%" align="left" class="tabtitle">
                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;所属行业</td>
                            <td width="14%" align="left" class="tabtitle">
                                &nbsp;&nbsp;&nbsp;&nbsp;投资区域</td>
                            <td align="left" width="12%" class="tabtitle">
                                &nbsp; &nbsp;价格(元)</td>
                            <td align="left" width="11%" class="tabtitle">
                                &nbsp; 发布时间</td>
                            <td align="left" width="28%" class="tabtitle">
                                &nbsp;&nbsp;&nbsp;操作</td>
                        </tr>
                        <asp:Repeater runat="server" ID="myList" OnItemCommand="myList_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td colspan="2">
                                        <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>" />
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                            <%#GetTitle(Eval("Title")) %>
                                        </a>
                                    </td>
                                    <%--<td></td>--%>
                                    <td align="center">
                                        <%#GetTypeName(Eval("InfoTypeID")) %>
                                    </td>
                                    <td align="center">
                                      <%#GetIndustry(Eval("InfoID"))%>
                                    </td>
                                    <td align="center">
                                         <%#GetQu(Eval("InfoID"))%>
                                    </td>
                                    <td align="center">
                                        价格
                                    </td>
                                    <td align="center">
                                        <%#Convert.ToDateTime(Eval("publishT")).ToString("yyyy-MM-dd")%>
                                    </td>
                                    <td align="left" class="taba">
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">查看</a>&nbsp; 
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("InfoID") %>' CommandName="Delete" OnClientClick="del()" Text="删除" /></td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td class="tabb" colspan="2">
                                        <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>" />
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                            <%#GetTitle(Eval("Title"))%>
                                        </a>
                                    </td>
                                    <%-- <td class="tabb">
                                
                                
                            </td>--%>
                                    <td align="center">
                                        <%#GetTypeName(Eval("InfoTypeID")) %>
                                    </td>
                                    <td align="center">
                                        <%#GetIndustry(Eval("InfoID"))%>
                                    </td>
                                    <td align="center">
                                         <%#GetQu(Eval("InfoID"))%>
                                    </td>
                                    <td align="center">
                                        价格
                                    </td>
                                    <td align="center">
                                        <%#Convert.ToDateTime(Eval("publishT")).ToString("yyyy-MM-dd")%>
                                    </td>
                                    <td align="left" class="taba">
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">查看</a>&nbsp;  <asp:LinkButton ID="lbtnDel1" runat="server" CommandArgument='<%#Eval("InfoID") %>' CommandName="Delete" OnClientClick="del()" Text="删除" /></td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="pagebox">
                        <div class="left">
                            <img src="../images/MessageManage/biao_01.gif" align="absbottom" />
                            <a href="javascript:void(0)" onclick="chkAll()">全选</a>/<a href="javascript:void(0)"
                                onclick="chkAll()">反选</a></div>
                        <div class="right">
                            共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                                ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                                    runat="server" Text="0"></asp:Literal>页&nbsp;
                            <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton>&nbsp;<span>转到
                                第
                                <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                                    runat="server" />
                                页</span>
                            <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                                font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <p>
                        <input name="" type="button" class="buttomal" value="批量拒收" style="display: none"
                            onclick="chkValue(1)" />
                        <input name="" type="button" class="buttomal" value="批量删除" onclick="chkValue(2)" />
                        <input name="" type="button" class="buttomal" value="清空所有资源" onclick="DeleteAll()" />
                    </p>
                    <div class="clear">
                    </div>
                </div>
            </contenttemplate>
        </asp:UpdatePanel>
    </div>
    <div class="blank20">
    </div>
</asp:Content>
