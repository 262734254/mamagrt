<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResourceManage_NoPass.aspx.cs" Inherits="ResourceManage_NoPass" Title="Untitled Page" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

function modifyNavigate(id,type)
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

function TabNavigate(url)
{
    window.location.href = url;
}


    </script>
    <style type="text/css">
<!--
.pagebox{
	padding: 20px 15px 20px 5px;
}
.pagebox .left{
	width: 400px;
	float: left;
}
.pagebox .right{
	width: 300px;
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
-->
    </style>
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                需求管理</div>
            <div class="right">
                 <a href="/Publish/publishNavigate.aspx" target="_blank">发布新的需求</a></div>
            <div class="clear">
            </div>
        </div>
        <div>
            <ul class="handtop">
                <li style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('ResourceManage_Pass.aspx');">通过审核(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.Pass) %>)</li>
                <li style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('ResourceManage_Audit.aspx');">审核中(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.Auditing)%>)</li>
                <li style="CURSOR: pointer;" class="liwai">未通过审核(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.NoPass)%>)</li>
                <li style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('ResourceManage_Overdue.aspx');">已过期(<%=this.GetCount(Tz888.BLL.Common.AuditStatus.Overdue)%>)</li>
            </ul>
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
                    <td width="9%" align="center" class="tabtitle">
                        <a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a></td>
                    <td width="9%" align="left" class="tabtitle">
                        类别                    </td>
                    <td width="31%" align="left" class="tabtitle">
                        标题                    </td>
                    <td width="15%" align="center" class="tabtitle">
                        发布时间</td>
                    <td width="22%" align="center" class="tabtitle">
                        未通过原因
                    </td>
                    <td width="14%" align="center" class="tabtitle">
                        状态
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
                                <a href="<%#Eval("HtmlFile") %>" target="_blank">
                                    <%#Eval("Title") %>
                              </a><a href="#"></a>
                          </td>
                            <td align="center" class="taba" style="height: 5px">
                                <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                                <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                                </label>
                            </td>
                            <td align="center" class="taba" style="height: 5px">
                                --
                            </td>
                            <td align="center" class="taba" style="height: 5px">
                                <a href='JavaScript:modifyNavigate("<%#Eval("InfoID") %>","<%#Eval("InfoTypeID").ToString().Trim() %>");'>
                                    修改</a>
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
        <div class="helpbox">
            <h1>
                <img src="../images/icon_yb.gif" width="17" height="17" />
                注意事项</h1>
            <p>
                ·状态为“可修改”的需求请您在<span class="hong"> 15 </span>天内进行修改，15天后仍未修改系统将自动删除！<br />
                ·状态为“即将删除”的需求系统将在<span class="hong"> 7 </span>天后自动删除！</p>
        </div>
    </div>
</asp:Content>
