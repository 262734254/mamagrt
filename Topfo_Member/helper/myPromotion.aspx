<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="GB2312" MasterPageFile="~/MasterPage.master"
    Title="通知设置-拓富中心-中国招商投资网" CodeFile="myPromotion.aspx.cs" Inherits="helper_myPromotion" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<!--
<link href="/css/promotion.css" rel="stylesheet" type="text/css" />
-->

    <script language="javascript" type="text/javascript">
    function openwin(str)
	{
	    helper_myPromotion.PromotionCount(backres)
        function backres(res)
        {
            if(res.value)
            {
                var url="Promotionset.aspx?InfoID="+str;
		        window.open(url,"newwindow","height=570,width=710,top=150,left=200,toolbar=no,menubar=no,resizable=no,location=no,status=no");
            }
            else
            {
            alert('您的定向推广服务已经使用完啦，请您尽快购买定向推广服务，以免贻误商机！');
            }
        }
		
    }
    function toset()
    {
        helper_myPromotion.PromotionCount(backres)
        function backres(res)
        {
            if(res.value)
            {chkValue();}
            else
            {alert('您的定向推广服务已经使用完啦，请您尽快购买定向推广服务，以免贻误商机！');}
        }
    }
	function chkValue()
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
		   openwin(str);
		}
		else
		{
		   alert("请选择所要设置的项");
		}
	}
	function chkAll(f) 
	{ 
	    var a = document.getElementsByTagName("input"); 
	    if(f=="2")//反选
	    {
	      for (var i=0; i<a.length; i++) 
		  if (a[i].type == "checkbox") 
		  a[i].checked =!a[i].checked;		
		}
		else//全选
		{
		    for (var i=0; i<a.length; i++) 
		    if (a[i].type == "checkbox") 
			a[i].checked =true;
		}
	}	
	function del()
{
      msg='这将不可恢复,真的要删除吗？'
   if(!window.confirm(msg))
    {
        return false;
    }
}

    </script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                定向推广</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" alt="" height="15" align="absmiddle" />
                <a href="http://www.topfo.com/help/directionalextend.shtml#12" target="_blank">使用说明</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">推广我的需求</li><li><a href="/helper/getPromotion.aspx">我收到的推荐资源</a></li></ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
<DIV class="demandbox cshibiank"><H1 class="dottedl lightc">
<span class="cheng"><IMG alt="" src="/images/icon_tishi.gif" align=absMiddle />
<asp:Label id="lblMsg" runat="server" Text="您的免费定向推广服务已经使用完啦，请您尽快购买定向推广服务，以免贻误商机！"></asp:Label></span>
</H1><DIV class="ggzi">☆ 最高效的推广手段 ☆ 直接面向对口客户 ☆ 快速送达用户终端</DIV>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR>
<TD class="tabtitle" align=center width="25%">推广资源标题</TD>
<TD class="tabtitle" align=center width="17%">开始推广时间</TD>
<TD class="tabtitle" align=center width="20%">推广方式</TD>
<TD style="WIDTH: 16%" class="tabtitle" align=center>推广数量</TD>
<TD class="tabtitle" align=center width="25%">操作</TD></TR>
<asp:Repeater id="myList" runat="server" OnItemCommand="myList_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="taba">
                                    <input type="checkbox" name="checkbox" value="<%#Eval("InfoID") %>" />
                                   <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>"><%#GetTitle(Eval("Title")) %>  
                                   </a>
                                </td>
                                <td align="center" class="taba">
                                    <%#Convert.ToDateTime(Eval("approvetime")).ToString("yyyy-MM-dd")%>
                                    </td>
                                     <td align="center" class="taba">
                                 
                                   <%#Getpopularize(Eval("InfoID"))%>
                                   </td>
                                <td align="center" class="taba">
                                    <%#GetCount(Eval("InfoID"),"1") %>
                                    条</td>
                                <td align="center" class="taba">
                                <a href="ResourceOver.aspx?infoId=<%#Eval("InfoID") %>">查看</a>&nbsp;
                               
                                  <asp:LinkButton runat="server" ID="lkPromotion" CommandName="promotion" CommandArgument='<%#Eval("InfoID") %>'>推广</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("InfoID") %>'
                                    CommandName="Delete" OnClientClick="return del()" Text="删除"></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                                <td class="tabb">
                                    <input type="checkbox" name="checkbox" value="<%#Eval("InfoID") %>" />
                                    <a href=" <%#Eval("HtmlFile") %>">
                                        <%#GetTitle(Eval("Title"))%>
                                    </a>
                                </td>
                                <td align="center" class="taba">
                                    <%#Convert.ToDateTime(Eval("approvetime")).ToString("yyyy-MM-dd")%>
                                    </td>
                                     <td align="center" class="taba">
                                    
                                    <!----><%#Getpopularize(Eval("InfoID"))%>
                                    </td>
                                <td align="center" class="taba">
                                    <%#GetCount(Eval("InfoID"),"1") %>
                                    条</td>
                                <td align="center" class="taba">
                                 <a href="ResourceOver.aspx?infoId=<%#Eval("InfoID") %>">查看</a>&nbsp;
                                 <asp:LinkButton runat="server" ID="lkPromotion" CommandName="promotion" CommandArgument='<%#Eval("InfoID") %>'>推广</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("InfoID") %>'
                                    CommandName="Delete" OnClientClick="return del()" Text="删除"></asp:LinkButton></td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    </TBODY></TABLE><DIV class="pagebox"><DIV class="left"><IMG height=16 src="../images/MessageManage/biao_01.gif" align=absBottom /> <A href="javascript:chkAll(1)">全选</A>/<A href="javascript:chkAll(2)">反选</A></DIV><DIV class="right">共<asp:Literal id="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal id="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal id="lblPageCount" runat="server" Text="0"></asp:Literal>页 <asp:LinkButton id="FirstPage" onclick="FirstPage_Click" runat="server">首页</asp:LinkButton>&nbsp; <asp:LinkButton id="PerPage" onclick="PerPage_Click" runat="server">上一页</asp:LinkButton>&nbsp; <asp:LinkButton id="NextPage" onclick="NextPage_Click" runat="server">下一页</asp:LinkButton>&nbsp; <asp:LinkButton id="LastPage" onclick="LastPage_Click" runat="server">尾页</asp:LinkButton> &nbsp; 
                    <span>转到 第 <input style="WIDTH: 36px; HEIGHT: 15px" id="txtPage" type=text name="textarea" runat="server" /> 页</span> <input style="FONT-SIZE: 12px; WIDTH: 30px; HEIGHT: 20px" id="btnGo" type=button value="GO" name="button2" runat="server" onserverclick="btnGo_ServerClick" /></DIV><DIV class="clear"></DIV></DIV><P><input id="btnSet" class="buttomal" onclick="toset()" type=button value="批量设置" name="" /> </P></DIV>
</contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
