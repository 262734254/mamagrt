<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PublishMerchant4.aspx.cs" Inherits="Publish_PublishMerchant4" ValidateRequest="false" %>
<%@ Register Src="../Controls/MerchantInfoAddressInfo.ascx" TagName="MerchantInfoAddressInfo"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../css/publish.css" rel="stylesheet" type="text/css" />

    <!--联系方式 -->
<div>
    <table width="100%" height="60" border="0" cellpadding="0" cellspacing="0" style="text-align:center; line-height:20px; margin:15px 0;" class="f_14">
        <tr>
            <td width="130" class="strong">发布资源只需<span class="f_red">2</span>步：</td>
            <td width="125" style="background:url(img/member_bg1_off.gif) no-repeat;">第一步<br />
                填写项目信息</td>
            <td width="50"><img src="images/member_icon1.gif" /></td>
            <td width="125" style="background:url(img/member_bg1_on.gif) no-repeat;" class="f_red strong">第二步<br />
                确认联系方式</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</div>
            <!--这里是添加联系方式的联系方式-->
<uc4:MerchantInfoAddressInfo ID="MerchantInfoAddressInfo1" runat="server"></uc4:MerchantInfoAddressInfo>
        <!--申请域名 建立我的展厅 -->
<div class="blank0">
</div>
<div class="mbbuttom">
            <p>
                <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank">点此阅读中国招商投资网服务条款</a>
            </p>
            <asp:ImageButton ID="IbtnSubmit" ImageUrl="../images/publish/buttom_tywftk.gif" runat="server" />
                
</div>
</asp:Content>