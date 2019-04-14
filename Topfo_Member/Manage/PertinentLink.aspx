<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PertinentLink.aspx.cs" Inherits="PertinentLink" Title="Untitled Page" %>

<%@ Register Src="MatchInfoList.ascx" TagName="MatchInfoList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        <uc1:MatchInfoList id="MatchInfoList1" runat="server">
        </uc1:MatchInfoList>
        
        <uc1:MatchInfoList id="MatchInfoList2" runat="server">
        </uc1:MatchInfoList>
    </div>
</asp:Content>

