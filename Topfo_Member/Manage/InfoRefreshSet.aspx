<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="InfoRefreshSet.aspx.cs" Inherits="Default4" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<LINK href="../css/refresh.css" type=text/css rel=stylesheet>
<script language="javascript" type="text/javascript">
function windowOpener(url,title)
{
    newWindow = window.open(url,title,'toolbar,resizable=0,scrollbars=0,status=no,toolbar=no,location=no,menu=no,width=550,height=600');
    newWindow.focus();
}

function IMG1_onclick() {

}

</script>
    <asp:Panel ID="plRefreshSet_Topfo" runat="server">
        <div class="mainconbox">
            <div class="titled">
                <div class="left">
                    刷新提醒设置</div>
                <div class="clear">
                </div>
            </div>
            <!-- -->
            <div class="cshibiank">
                <div class="setubcon">
                    <a href="javascript:windowOpener('./InfoRefresh.aspx','资源刷新');"><img src="../images/buttom_shuaxin.gif" id="IMG1" onclick="return IMG1_onclick()" /></a><br />
                    ”刷新”资源可以迅速提高它在列表中的位置，大大提高曝光机会。
                    <p>
                        <asp:RadioButton ID="RbtnSet" GroupName="refreshlist"  runat="server" />超过<asp:TextBox ID="txtDayMsg" runat="server" Text="5" Width="21px" />天没有刷新时出现刷新提醒&nbsp;<span>
                        <asp:RadioButton ID="RbtnDel" GroupName="refreshlist" runat="server" />以后不再提醒(您可以随时恢复刷新提醒设置)</span></p>
                        <asp:Button ID="btnSave" CssClass="buttomal" runat="server" Text="保 存" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" CssClass="buttomal" runat="server" Text="取 消" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="plRefreshSet_General" runat="server">
        <div id="DIV1">
            <div class="titled">
                <div class="left">
                    资源刷新设置</div>
                <div class="clear">
                </div>
            </div>
            <strong>
                <!-- -->
            </strong>
            <div class="cshibiank">
                <div class="setubcon">
                   刷新资源让资源排列在最前位置，让更多的用户关注，这是中国招商投资网专门为<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" class="lanlink" target="_blank">拓富通会员</a>提供的一项增值服务。
                    <div class="resources">
                        <img src="../images/AccountInfo/biao_yuan.gif" align="middle" > <a href="http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml" class="lanlink" target="_blank">点此了解拓富通服务详情</a> <span>咨询热线：0755-89805558</span></div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
