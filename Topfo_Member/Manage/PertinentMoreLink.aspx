<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PertinentMoreLink.aspx.cs" Inherits="Manage_PertinentMoreLink" Title="更多匹配" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
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
                                <%#Eval("InfoTypeName") %>
                            </td>
                            <td class="tab" align="middle">
                                <a href="<%#this.GetTitle(Eval("HtmlFile"),Eval("InfoTypeID"),Eval("InfoID")) %>" target="_blank">
                                    <%#Eval("Title") %>
                                </a><a href="#"></a>
                            </td>
                            <td class="tab" align="middle">
                                <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                                    <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                                </label>
                            </td>
                            <td class="tab" align="middle">
                                <label title="">
                                    <%#Convert.ToDateTime(Eval("FrontDisplayTime")).ToString("yyyy-MM-dd") %>
                                </label>
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
    </div>
    <div class="titled">
        <div class="left">
            <%=this.GetTitle() %>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class=" cshibiank">
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tbody>
                <tr>
                    <td class="tabtitle" align="middle" width="3%">
                        &nbsp;
                    </td>
                    <td class="tabtitle" align="middle" width="43%">
                        标题
                    </td>
                    <td class="tabtitle" align="middle" width="18%">
                        发布时间</td>
                    <td class="tabtitle" align="middle" width="18%">
                        发布者
                    </td>
                    <td class="tabtitle" align="middle" width="18%">
                        &nbsp;</td>
                </tr>
                <asp:Repeater ID="RfMatch" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="tab" align="middle">
                                &nbsp;
                            </td>
                            <td class="tab" align="left">
                                <a href="<%#this.wwwdomain + @"/" + Eval("HtmlFile") %>" target="_blank">
                                    <%#Eval("Title") %>
                                </a><a href="#"></a>
                            </td>
                            <td class="tab" align="middle">
                                <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                            </td>
                            <td class="tab" align="middle">
                                <label title="">
                                    <%#Eval("LoginName")%>
                                </label>
                            </td>
                            <td class="tab" align="middle">
                                &nbsp;<a href='../helper/CollectingInfo.aspx?infoid=<%#Eval("InfoID") %>'>收藏</a>&nbsp;<a href="<%#this.wwwdomain + @"/" + Eval("HtmlFile") %>" target="_blank">查看</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
