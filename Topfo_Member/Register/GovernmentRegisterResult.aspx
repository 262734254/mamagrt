<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="GovernmentRegisterResult.aspx.cs"
    Inherits="Register_GovernmentRegisterResult" %>

<%@ Register Src="Control/ImageUploadControl.ascx" TagName="ImageUploadControl" TagPrefix="uc1" %>
<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc2" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/comp_register.css" rel="stylesheet" type="text/css">
  <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="contant_l">
            <div class="titled">
                <div class="left">
                   
                        招商机构信息
              </div>
                <div class="clear">
                </div>
          </div>
            <div class="lightc pad_1 allxian">
                <div class="float_all  spacing_1 mar_6">
                    <span class="cu cheng font14">
                        <asp:Label ID="lbMessage" runat="server" Text="您的公司资料已经通过审核！"></asp:Label></span><br />
                    <asp:Label ID="lbResult" runat="server" Width="712px"></asp:Label><br />
                    <asp:Label ID="lbFeedbackStatus"
                        runat="server"></asp:Label><br />
                  <div runat="server" id="divReg">
                        重要提示：请确保您发布的公司资料真实有效，由于发布虚假信息产生的任何责任，由发布者自行承担！<br />
                      想让您的公司介绍排在普通会员的前面被更多用户关注吗？<a href="VIPMemberRegister_In.aspx" class="lanlink">点此申请拓富通</a><span
                            class="mar_9">0755-82210116</span><span class="mar_9">82212980</span><a href="http://www.topfo.com/ContactUs.shtml" target="_blank"
                                class="lanlink">在线客服</a></div>
                </div>
                <div class="clear">
                </div>
            </div>
			<div class="blank0"></div>
            <div class="grayLine1 pad_3 leight30">
            
                   对招商机构基本资料进行修改，<span class="mar_8"><a href="GovernmentRegister.aspx" class="lanlink">请点这里</a></span>
                <div class="line_div1" style="display:none" >
                    您发布的需求共被关注<asp:Label ID="lbHits" runat="server"></asp:Label>次，<span class="mar_8"><a
                        href="#" class="lanlink">点此查看详细访问记录</a></span></div>
            </div>
            <h3 class="line_div2 red_c1">
                <asp:Label ID="lbOrgName" runat="server" Text="中国招商投资网"></asp:Label>&nbsp;</h3>
            <div class="ll_rr">
                <div class="float_all widthL7" >
                    <asp:Label ID="lbComAboutBrief" runat="server"></asp:Label>
                </div>
                <div class="profileuser">
                    <div class="profileuser">
                        <uc2:FileUploader ID="FileUploader1"  ImgWidth="220" ImgHeight="160" runat="server" ButtonName="添加上传" MaxPics="1"  /><p></p>
                        图片最适大小（220*160px）
                    </div>           
                </div>
                <div class="clear"></div>
            </div>
            <div class="widthL9">
                <table width="100%" border="0" class="tbWidth">
                    <tr>
                        <td width="44%" style="height: 36px">
                            <b>机构主体：</b><asp:Label ID="lbMerchantTypeName" runat="server"></asp:Label></td>
                        
                    </tr>
                    <tr>
                        <td style="height: 36px">
                            <strong><span style="font-size: 9pt; color: #000000; font-family: 宋体; mso-ascii-font-family: 'Times New Roman';
                                mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                mso-bidi-language: AR-SA">所属区域</span>：</strong><asp:Label ID="lbZone" runat="server"></asp:Label></td>
                        <td style="width: 50%; height: 36px;">
                        </td>
                    </tr>
                </table>
            </div>
            <ul class="comp_Info">
                <li class="titleLi">
                    <img src="../images/icon_yb.gif" width="17" height="17" />
                    联系方式</li><li><b>联 系 人：</b>
                    <asp:Label ID="lbLinkMan" runat="server"></asp:Label></li><li><b>电子邮箱：</b>
                        <asp:Label ID="lbMail" runat="server">没有提供</asp:Label></li><li><b>公司网址：</b>
                            <asp:Label ID="lbSite" runat="server">没有提供</asp:Label></li><li><b>固定电话：</b>
                                <asp:Label ID="lbTel" runat="server">没有提供</asp:Label></li><li><b>传 &nbsp;&nbsp; 真：</b>
                                    <asp:Label ID="lbFax" runat="server">没有提供</asp:Label></li><li><b>手 &nbsp;&nbsp; 机：</b>
                                        <asp:Label ID="lbMobile" runat="server">没有提供</asp:Label></li><li><b>联系地址：</b>
                                            <asp:Label ID="lbAddress" runat="server">没有提供</asp:Label></li></ul>
        </div>
</div>
 </asp:Content>