<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoRefresh.aspx.cs" Inherits="Manage_InfoRefresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源刷新提醒</title>
    <link href="../css/refresh.css" type="text/css" rel="stylesheet">
    <link href="../css/common.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" language="javascript">
		function SelectAll(tempControl,dlrefresh)
        {
            var theBox=tempControl;
            xState=theBox.checked;
            elem=theBox.form.elements;
            for(i=0;i<elem.length;i++)
            {          
				if(elem[i].type=="checkbox" && elem[i].id!=theBox.id)
				{
					if (elem[i].id.indexOf(dlrefresh) == 0)
					{						
						if(elem[i].checked!=xState)
							elem[i].click();
					}
				}
            }
		}
		function TabNavigate(url)
        {
            window.location.href = url;
        }
	</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="waibox">
            <h1>
                <b>刷新提醒：</b><br>
                请选择您发布的资源进行刷新。“刷新”资源可以迅速提高它在列表中的位置，大大提高曝光机会。</h1>
            <div class="blank20">
            </div>
            <div class="remindtop">
                <ul>
                    <li class="<%=(this.InfoType == "All")?"liwai":"" %>" style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('InfoRefresh.aspx?type=All');">全 部 </li>
                    <li class="<%=(this.InfoType == "Merchant")?"liwai":"" %>" style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('InfoRefresh.aspx?type=Merchant');">政府招商 </li>
                    <li class="<%=(this.InfoType == "Capital")?"liwai":"" %>" style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('InfoRefresh.aspx?type=Capital');">资 本 </li>
                    <li class="<%=(this.InfoType == "Project")?"liwai":"" %>" style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('InfoRefresh.aspx?type=Project');">项 目 </li>
                    <li class="<%=(this.InfoType == "Carveout")?"liwai":"" %>" style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('InfoRefresh.aspx?type=Carveout');">创 业 </li>
                    <li class="<%=(this.InfoType == "Oppor")?"liwai":"" %>" style="CURSOR: pointer;" onclick="JavaScript:TabNavigate('InfoRefresh.aspx?type=Oppor');">商 机 </li>
                </ul>
            </div>
            <div class="remindcon">
                <asp:DataList ID="dlrefresh" runat="server" OnItemDataBound="dlrefresh_ItemDataBound">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td style="height: 18px;">
                                    <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox></td>
                                <td>
                                    <asp:HyperLink ID="lnkTitle" runat="server" Target="_blank"></asp:HyperLink></td>
                            </tr>
                        </table>
                        <asp:Label ID="lblInfo" runat="server" Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="selectall">
                <asp:CheckBox ID="chkAllSel" onclick="javascript:SelectAll(this,'dlrefresh');" runat="server"
                    Text="全选" />
                <asp:CheckBox ID="chkRefreshMsg" runat="server" Text="以后不再提醒"></asp:CheckBox>
                (您可以随时回复提醒设置)</div>
            <div class="bottom">
                <asp:Button ID="btnSubmit" CssClass="buttomal" Text="确 定" runat="server" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClose" CssClass="buttomal" Text="关 闭" runat="server" OnClick="btnClose_Click" />
            </div>
        </div>
    </form>
</body>
</html>
