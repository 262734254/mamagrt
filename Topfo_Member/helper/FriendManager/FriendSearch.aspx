<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
     CodeFile="FriendSearch.aspx.cs" Inherits="helper_FriendManager_FriendSearch" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
     <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
     <link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
function chk()
{
    if(document.getElementById("ctl00_ContentPlaceHolder1_Radio1").checked)
    {
        document.getElementById("panelExact").style.display="";
        document.getElementById("panelAdvance").style.display="none";
    }
     if(document.getElementById("ctl00_ContentPlaceHolder1_Radio2").checked)
    {
        document.getElementById("panelExact").style.display="none";
        document.getElementById("panelAdvance").style.display="";
    }    
}

    </script>



     <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的好友</div>
            <div class="right">
                <img src="../../images/AccountInfo/handbiao.gif" width="16" height="10" />
                <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">如何添加/管理好友</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank0">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">添加好友</li><li><a href="FriendList.aspx">好友列表</a></li>
                    <li><a href="InfoView.aspx">互告用户资源</a></li>
                    <li><a href="FriendBlacklist.aspx">黑名单</a></li><li><a href="FriendConfig.aspx">
                        防骚扰设置</a></li></ul>
        </div>
        <div class="addbox cshibiank">
            <img src="../../images/MessageManage/buttom_hycx.gif" alt="会员查询" align="absmiddle" />
            您可以在此设置精确的条件查找会员。<br />
            <p>
                &nbsp;<input id="Radio1" name="RadioChk" type="radio" onclick="chk()" runat="server" checked/>精确查找
                <input id="Radio2" name="RadioChk" type="radio" onclick="chk()" runat="server"  />高级查找</p>
            <div class="blank20">
            </div>
            <div class="searchbox">
                <table width="100%" id="panelExact" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="21" colspan="2" style="width: 649px">
                            <strong class="font14 cheng">精确条件：</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 649px; height: 22px;">
                            会员昵称：&nbsp;<label>
                                <asp:TextBox ID="tboxMemberName" runat="server"></asp:TextBox></label></td>
                    </tr>
                </table>
                <table id="panelAdvance" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="display:none">
                    <tr>
                        <td colspan="3" style="height: 25px">
                            <strong class="chengcu font14">高级查找：</strong></td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cheng">
                            请选择会员身份：</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButtonList ID="rblMemberGrade" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">全部会员</asp:ListItem>
                                <asp:ListItem Value="1">普通会员</asp:ListItem>
                                <asp:ListItem Value="2">拓富通会员</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cheng" style="height: 20px">
                            请选择会员类型：</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 30px">
                            <asp:RadioButtonList ID="rblMemberType" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">政府</asp:ListItem>
                                <asp:ListItem Value="1">企业</asp:ListItem>
                                <asp:ListItem Value="2">个人</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cheng">
                            请选择会员意向：（可多选）</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <label>
                                <asp:CheckBoxList runat="server" ID="cklIntent" RepeatDirection="Horizontal" Height="5px"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="0">政府招商</asp:ListItem>
                                    <asp:ListItem Value="1">企业招商</asp:ListItem>
                                    <asp:ListItem Value="2">项目融资</asp:ListItem>
                                    <asp:ListItem Value="3">创业合作</asp:ListItem>
                                    <asp:ListItem Value="4">产品供求</asp:ListItem>
                                    <asp:ListItem Value="5">项目投资</asp:ListItem>
                                </asp:CheckBoxList>
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                            区域： &nbsp;&nbsp; &nbsp;
                            <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" valign="middle" style="height: 4px">&nbsp;
                            </td>
                        <td width="80%" valign="middle" >
                          
                            <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="buttomal" OnClick="btnSearch_Click" Width="60px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
