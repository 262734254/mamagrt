﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResourceManage_Audit.aspx.cs" Inherits="ResourceManage_Audit" Title="Untitled Page" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/publish.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
function SelectAll()
{
    if(!document.getElementById("cbxSelect"))
        return;
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
    if(!document.getElementById("cbxSelect"))
        return;
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

//function modifyNavigate(id,type,CraveOutType,grade)
function modifyNavigate(id,type,grade)
{
    var url="";
    switch(type)
    {
        case "Capital":
            url = "/offer/ModifyCapital.aspx?id="+id+"&type="+type;
            break;
        case "Project":
            url = "./ModifyProject.aspx?id="+id+"&type="+type;
            break;
        case "Merchant":
            url = "./ModifyMerchant.aspx?id="+id+"&type="+type;
            break;
        case "CarveOut":
//            url = "/Publish/ModifyCarveOut.aspx?id="+id+"&type="+CraveOutType;
              url = "/Publish/ModifyCarveOut.aspx?id=+id+"&type="+type;
            break;
        case "Oppor":
            url = "http://www.topfo.com/member/Info/ModifyOppor.aspx?InfoID="+id+"&type="+type;
            break;
        default:
            break;
    }
    window.location.href = url;
}

function TabNavigate(url)
{
    window.location.href = url;
}

    </script>
   <style type="text/css">

.pagebox{
	padding: 20px 15px 20px 5px;
}
.pagebox .left{
	width: 350px;
	float: left;
}
.pagebox .right{
	width: 350px;
	float: right;
	text-align: right;
}
.search{
	color: #563B1D;
	padding: 2px 0 5px 10px;
	background-color: #FFC24F;
}
.search .lefts{
	width: 480px;
	float: left;
}
.search .rights{
	width: 220px;
	float: right;
	text-align: right;
	padding-right: 15px;
}

.helpbox{
	border: 1px solid #CCCCCC;
}

.helpbox h1{
	font-size: 14px;
	color: #563B1D;
	background-color: #F7F6F6;
	padding: 4px 0 4px 10px;
}
.helpbox  p{
	padding: 10px 0px 15px 15px;
}
.notes{
	background-image: url(../images/publish/zf_bg.gif);
	background-repeat: no-repeat;
	background-position: 35px 6px;
	padding: 9px 0 0 80px;
	height: 35px;
	text-align: left;
}
.notes span{
	color: #FF6600;
	padding: 0 3px 0 3px;
}

    </style>
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                需求管理</div>
            <div class="right" style="margin-bottom:6px;">
<img src="http://member.topfo.com/images/hand_1_2.gif" alt=""/> 
               <a href="/Publish/publishNavigate.aspx" target="_blank">发布新的需求</a></div></div>
            <div class="clear">
            </div>
        
        <div>
            <ul class="handtop">
                <li style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('ResourceManage_Pass.aspx');">通过审核(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.Pass) %>)</li><li style="CURSOR: pointer;" class="liwai">审核中(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.Auditing)%>)</li><li style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('ResourceManage_NoPass.aspx');">未通过审核(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.NoPass)%>)</li><li style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('ResourceManage_Overdue.aspx');">已过期(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.Overdue)%>)</li></ul>
        </div>
        <div class=" cshibiank">
            <div class="search">
                <div class="leight30 ">
                    <%=this.GetRemind()%>
                </div>
                <div class="lefts">
                    需求筛选：<asp:TextBox ID="txtConditions" runat="server"></asp:TextBox>&nbsp;<asp:DropDownList
                        ID="ddlInfoType" runat="server">
                    </asp:DropDownList>
                    <label>
                        <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />
                    </label>
                </div>
                <div class="rights">
                    每页显示：<asp:LinkButton ID="lbtn10" runat="server" OnClick="lbtn10_Click">10</asp:LinkButton>
                    条
                    <asp:LinkButton ID="lbtn20" runat="server" OnClick="lbtn20_Click">20</asp:LinkButton>
                    条
                    <asp:LinkButton ID="lbtn30" runat="server" OnClick="lbtn30_Click">30</asp:LinkButton>
                    条</div>
                <div class="clear">
                </div>
            </div>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="10%" align="center" class="tabtitle" style="height: 32px">
                        <a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a></td>
                    <td width="12%" align="left" class="tabtitle" style="height: 32px">
                        类别                    </td>
                    <td width="39%" align="left" class="tabtitle" style="height: 32px">
                        标题                    </td>
                    <td width="19%" align="center" class="tabtitle" style="height: 32px">
                        发布时间</td>
                    <td width="20%" align="center" class="tabtitle" style="height: 32px">
                        管理
                    </td>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center" class="taba" style="height: 5px">
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("InfoID") %>" />
                                </label>
                            </td>
                            <td align="left" class="taba" style="height: 5px">
                                <%#Eval("InfoTypeName") %>
                          </td>
                            <td align="left" class="taba" style="height: 5px">
                            <a href='JavaScript:modifyNavigate("<%#Eval("InfoID") %>","<%#Eval("InfoTypeID").ToString().Trim() %>");'><%#Eval("Title") %></a>
                          </td>
                            <td align="center" class="taba" style="height: 5px">
                                <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                                <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                                </label>
                            </td>
                            <td align="center" class="taba" style="height: 5px">
                                <a href="./PertinentLink.aspx?id=<%#Eval("InfoID") %>&type=<%#Eval("InfoTypeID") %>">
                                    匹配</a>
                                       &nbsp;<a href='JavaScript:modifyNavigate("<%#Eval("InfoID") %>","<%#Eval("InfoTypeID").ToString().Trim() %>","<%#Eval("MemberGradeID").ToString().Trim() %>");'>修改</a>
                                     
                             <%--   &nbsp;<a href='JavaScript:modifyNavigate("<%#Eval("InfoID") %>","<%#Eval("InfoTypeID").ToString().Trim() %>","<%#Eval("CarveOutInfoType").ToString().Trim() %>","<%#Eval("MemberGradeID").ToString().Trim() %>");'>修改</a>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
          </table>
        </div>
        <div class="pagebox">
            <div class="left">
                <img src="../images/MessageManage/biao_01.gif" width="14" height="16" />将选中的需求
                <label>
                    <asp:Button ID="btnDelete" CssClass="buttomal" runat="server" Text="彻底删除" OnClick="btnDelete_Click" />
                </label>
            </div>
            <div class="right">
                <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                    PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                    UseCustomDataSource="False" ShowCount="False" SortColumn="PublishT" SortType="DESC"
                    TableViewName="MainInfoVIW" ContentPlaceHolder="ContentPlaceHolder1" KeyColumn="InfoID"
                    ShowPageCount="False"></cc1:Pager>
                &nbsp;</div>
            <div class="clear">
            </div>
        </div>
    </div>
	<%--</div>--%>
</asp:Content>
