<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MemberFollow.aspx.cs" Inherits="MemberFollow" Title="Untitled Page" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/publish.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" language="javascript">
function SelectAll()
{
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
		    if(elem[i].checked!=true)			
			    elem[i].click();
		}
    }
}

function ReSelect()
{
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
			    elem[i].click();
		}
    }
}

function TabNavigate(url)
{
    window.location.href = url;
}

function modifyNavigate(id,type)
{
    if(confirm('如果您对发布的内容进行修改，需要经过再次审核，您已经通过审核的需求将暂时不在网上展示!'))
    {
    var url="";
    switch(type)
    {
        case "Capital":
            url = "./ModifyCapital.aspx?id="+id+"&type="+type;
            break;
        case "Project":
            url = "./ModifyProject.aspx?id="+id+"&type="+type;
            break;
        case "Merchant":
            url = "./ModifyMerchant.aspx?id="+id+"&type="+type;
            break;
        default:
            break;
    }
    //alert(url);
    window.location.href = url;
    }
}
    </script>

    <div id="mainconbox">
        <div class="titled">
            <div class="left">
                需求管理</div>
            <div class="right">
                <a href="#">免费发布需求</a></div>
            <div class="clear">
            </div>
        </div>
        <table class="cshibiank" cellspacing="0" width="100%" align="center">
            <tbody>
                <tr>
                    <td class="tabtitle" align="middle" width="12%" height="25">
                        类别</td>
                    <td class="tabtitle" align="middle" width="42%">
                        标题
                    </td>
                    <td class="tabtitle" align="middle" width="15%">
                        发布时间</td>
                    <td class="tabtitle" align="middle" width="16%">
                        上次刷新
                    </td>
                    <td class="tabtitle" align="middle" width="15%">
                        管理</td>
                </tr>
                <asp:Repeater ID="RfInfo" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="tab" align="middle" height="25">
                                <%#Eval("InfoTypeName") %></td>
                            <td class="tab" align="middle">
                                <a href="<%#this.GetTitle(Eval("HtmlFile"),Eval("InfoTypeID"),Eval("InfoID")) %>" target="_blank">
                                    <%#Eval("Title") %>
                                </a><a href="#"></a></td>
                            <td class="tab" align="middle">
                                <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                                <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                                </label>
                            </td>
                            <td class="tab" align="middle">
                                <label title="">
                                <%#Convert.ToDateTime(Eval("FrontDisplayTime")).ToString("yyyy-MM-dd") %></label>
                            </td>
                            <td class="tab" align="middle">
                                &nbsp;<a href='JavaScript:modifyNavigate("<%#Eval("InfoID") %>","<%#Eval("InfoTypeID").ToString().Trim() %>");'>修改</a>
                                &nbsp; <a href="./InfoRefreshSet.aspx">
                                    刷新</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="blank20">
        </div>
        <div class="titled">
            <div class="left">
                关注过的会员</div>
            <div class="clear">
            </div>
        </div>
        <div class=" cshibiank">
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tbody>
                    <tr>
                        <td class="tabtitle" align="middle" width="10%">
                            &nbsp;</td>
                        <td class="tabtitle" width="16%">
                            会员</td>
                        <td class="tabtitle" width="12%">
                            会员类型
                        </td>
                        <td class="tabtitle" align="middle" width="34%">
                            来源</td>
                        <td class="tabtitle" align="middle" width="16%">
                            操作</td>
                        <td class="tabtitle" align="middle" width="12%">
                            在线沟通</td>
                    </tr>
                    <asp:Repeater ID="RfUser" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="taba" align="middle">
                                    <label>
                                        <input type="checkbox" name="cbxSelect" id="cbxSelect"  value="<%#Eval("LoginName") %>" />
                                    </label>
                                </td>
                                <td class="taba">
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>
                                </td>
                                <td class="taba">
                                    <a href="#">
                                       <%#Eval("MemberType") %>
                                    </a>
                                </td>
                                <td class="taba" align="middle">
                                    <%#this.GetZoneInfo(Eval("CountryName"),Eval("ProvinceName"),Eval("CityName"),Eval("CountyName")) %>
                                    </td>
                                <td class="taba" align="middle">
                                    <a href="<%#Eval("LoginName") %>">加为好友</a> <a href="<%#Eval("LoginName") %>">站内短消息</a>
                                </td>
                                <td class="taba" align="middle">
                                    <a href="#">会员在线</a>
                                    <img height="20" alt="会员在线" src="../images/publish/icon_member.gif" width="16"></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="pagebox">
            <div class="left">
                <img height="16" src="../images/MessageManage/biao_01.gif" width="14"><a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a>
                <label>
                    <input class="buttomal" id="button2" type="button" value="加为好友" name="button2">
                </label>
                <label>
                </label>
                <input class="buttomal" id="button" type="button" value="群发短消息" name="button">
            </div>
            <div class="right">
                <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                    PagerStyle="CustomAndNumeric" ShowPageCount="False" UseCustomDataSource="False" ContentPlaceHolder="ContentPlaceHolder1" ControlToPaginate="RfUser" PagingMode="NonCached" />
                &nbsp;</div>
            <div class="clear">
            </div>
        </div>
        <div class="helpbox">
            <h1>
                <img height="17" src="../images/icon_yb.gif" width="17">
                查看给我的留言</h1>
            <p>
                想得到更多人的关注吗？立即<a href="#">升级拓富通会员</a>。据统计，拓富通会员受到的关注是普通会员的<span class="hong">10</span>倍！</p>
        </div>
    </div>
</asp:Content>
