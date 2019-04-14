<%@ Page Language="C#"   AutoEventWireup="true" CodeFile="FriendConfig.aspx.cs" MasterPageFile="~/MasterPage.master"  Inherits="helper_FriendManager_FriendConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
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
                   <li><a href="FriendSearch.aspx">添加好友</a></li>
                   <li><a href="FriendList.aspx">好友列表</a></li>
                    <li><a href="InfoView.aspx">互告用户资源</a></li>
                   <li><a href="FriendBlacklist.aspx">黑名单</a></li>
                   <li class="liwai">防骚扰设置</li></ul>
            </div>
            <div class=" cshibiank">
                <div class="blacktopbox">
                    <h1 class="dottedl">
                        <img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" align="absmiddle" />
                        <strong>提示：</strong>只有拓富通会员才有设置防骚扰的权限！  
                        <asp:HyperLink ID="linktopf" runat="server" Visible="False">立即升级到拓富通</asp:HyperLink>
                    </h1>
                    <div class="blank0">
                    </div>
                    <table width="680" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" align="center" class="font14">
                                只有满足下列条件的会员才能加我为好友：</td>
                        </tr>
                        <tr>
                            <td width="338" align="right">
                                会员身份：</td>
                            <td width="342">
                                <p>
                                    <label>
                                        <asp:DropDownList ID="ddlMemberGrade" runat="server">
                                            <asp:ListItem Value="0">不限</asp:ListItem>
                                            <asp:ListItem Value="1">拓富通会员</asp:ListItem>
                                            <asp:ListItem Value="2">普通会员</asp:ListItem>
                                        </asp:DropDownList></label>&nbsp;</p>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                会员类型：</td>
                            <td>
                                <asp:DropDownList ID="ddlMemberType" runat="server" OnSelectedIndexChanged="ddlMemberType_SelectedIndexChanged" AutoPostBack="true" Width="83px">
                                    <asp:ListItem Value="0" Selected="True">不限</asp:ListItem>
                                    <asp:ListItem Value="1">政府机构</asp:ListItem>
                                    <asp:ListItem Value="2">企业单位</asp:ListItem>
                                    <asp:ListItem Value="3">个人</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right">
                                会员意向：</td>
                            <td>
                                <asp:DropDownList ID="ddlMemberIntent" runat="server" Width="80px">
                                    <asp:ListItem Value="0">不限</asp:ListItem>
                                    <asp:ListItem Value="1">政府招商</asp:ListItem>
                                    <asp:ListItem Value="2">产品招商</asp:ListItem>
                                    <asp:ListItem Value="3">项目融资</asp:ListItem>
                                    <asp:ListItem Value="4">项目投资</asp:ListItem>
                                    <asp:ListItem Value="5">创业合作</asp:ListItem>
                                    <asp:ListItem Value="6">产品供求</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                          <td height="76" colspan="2" align="center">
                               <asp:Button ID="btnOk" runat="server" Height="25px" Text="确定" OnClick="btnOk_Click" />
                                <asp:Button ID="btnCancel" runat="server" Height="26px" Text="取消" />
                                <br />
								<div class="blank6"></div>
                                <asp:Panel runat="server" ID="panelSet" Width="680" Visible="false">
                                    <asp:Label ID="lbSetText" runat="server" Text="" Width="490px"></asp:Label>
                                </asp:Panel>
								<div class="blank6"></div>
                              <span class="hui">设置太多条件将影响加您被加为好友的数量 </span>                            </td>
                        </tr>
                    </table>
                    <div class="blank20">
                    </div>
                </div>
            </div>
        </div>
</asp:Content>