<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    EnableEventValidation="false" Title="接收推广设置-拓富中心-中国招商投资网" AutoEventWireup="true"
    CodeFile="ReceivedSet.aspx.cs" Inherits="helper_ReceivedSet" %>

<%@ Register Src="../Controls/ZoneMoreSelectControl.ascx" TagName="ZoneMoreSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <!--  <link href="/css/promotion.css" rel="stylesheet" type="text/css" />-->

    <script language="javascript" type="text/javascript">
    function showPoint()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_isGet").checked)
        {
            document.getElementById("ctl00_ContentPlaceHolder1_isShow").style.display="";
        }
        else
        {
            document.getElementById("ctl00_ContentPlaceHolder1_isShow").style.display="none";
        }
    }
    </script>

    <script>showPoint();</script>

    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                定向推广</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" align="absmiddle" />
                <a href="http://www.topfo.com/web13/help/directionalextend.shtml#12" target="_blank">
                    使用说明</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="/helper/myPromotion.aspx">推广我的需求</a></li><li><a href="/helper/getPromotion.aspx">
                    我收到的推荐资源</a></li><li class="liwai">接收设置</li><li><a href="/helper/PromotionServer.aspx">
                        服务购买</a></li></ul>
        </div>
        <div class="psetbox cshibiank">
            <h1 class="dottedl lightc">
                <img src="/images/icon_tishi.gif" align="absmiddle" />
                <span class="cheng">温馨提示：</span>如果你不想收到这样的推广内容，您可以退订或设置详细接收条件。</h1>
            <div class="blank20">
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right" style="width: 133px">
                        <strong>接收哪类用户的资源：</strong></td>
                    <td align="left">
                        <asp:RadioButtonList ID="rabGradeID" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1002">拓富通会员</asp:ListItem>
                            <asp:ListItem Value="1001">普通会员</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1001,1002">全部会员</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </table>
            <table width="100%" border="0" id="isShow" runat="server" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <span style="font-size: 9pt"><strong>资源类型：</strong></span></td>
                    <td width="82%">
                        <asp:CheckBoxList ID="chkNeed" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="Merchant">招商资源</asp:ListItem>
                            <asp:ListItem Value="Project">融资资源</asp:ListItem>
                            <asp:ListItem Value="Capital">投资资源</asp:ListItem>
                        </asp:CheckBoxList>(*可多选)<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label><br />
                        </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>所属区域：</strong></td>
                    <td class="local"> <uc1:ZoneMoreSelectControl ID="ZoneControl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" rowspan="2">
                        <strong>接收方式设置：</strong>&nbsp;&nbsp;</td>
                    <td style="height: 24px">
                        <span class="hui">
                            <asp:CheckBox ID="cbkEmail" runat="server" Text="站内短信" /></span></td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <span class="hui">
                            <asp:CheckBox ID="cbkMobile" runat="server" Text="手机短信" />&nbsp;<input id="txtMobile" type="text" runat="server" />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                ErrorMessage="手机号码格式错误" ValidationExpression="^(130|131|132|133|134|135|136|137|138|139|159|158)\d{8}$"></asp:RegularExpressionValidator></span></td>
                </tr>
            </table>
            <p>
                <input type="button" class="buttomal" value="确 认" id="btnEnter" runat="server" onserverclick="btnEnter_ServerClick" />&nbsp;<label>
                </label>
            </p>
        </div>
        <div class="blank20">
        </div>
    </div>
</asp:Content>
