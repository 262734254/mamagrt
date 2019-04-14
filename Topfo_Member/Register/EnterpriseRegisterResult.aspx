<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EnterpriseRegisterResult.aspx.cs" Inherits="Register_EnterpriseRegisterResult " %>

<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/comp_register.css" rel="stylesheet" type="text/css">
    <div class="all_wrap">
        <div class="contant_l">
            <div class="up_note">
                <div class="up_note_ll left">
                    <h3 class="f14_b2">登记公司信息</h3>
                </div>
                <div class="up_note_rr right" ><span></span></div>
                <div class="clear"></div>
            </div>
            <div class="dottedl lightc pad_1">
                <div class="float_all  spacing_1 mar_6" style="width: 713px">
                    <span class="cu cheng font14">
                        <asp:Label ID="lbMessage" runat="server" Text="您的公司资料已经通过审核！"></asp:Label><br />
                        <br />
                    </span>
                    <asp:Label ID="lbResult" runat="server" Width="697px"></asp:Label>
                    <br />
                    <asp:Label ID="lbFeedbackStatus" runat="server"></asp:Label>
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt">
                    </p>
                  <div id="divReg" runat="server"></div>
                </div>
                <div class="clear"></div>
                <span style="color: #000000"></span>              
                <span style="color: #000000"></span>
            </div>
            <div class="grayLine1 pad_3 leight30">
                <div>
                    对公司基本资料进行修改，<span class="mar_8"><a href="EnterpriseRegister.aspx" class="lanlink">请点这里</a></span></div>
                <div class="line_div1" style="display:none">
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
                        <uc1:FileUploader ID="FileUploader1"  ImgWidth="220" ImgHeight="160" runat="server" ButtonName="添加上传" MaxPics="1"  /><p></p>
                        图片最适大小（220*160px）
                    </div>           
                </div>
                <div class="clear"></div>
            </div>
            <div class="widthL9">
                <table width="100%" border="0" class="tbWidth">
                    <tr>
                        <td width="44%" style="height: 36px">
                            <b>主营行业：</b><asp:Label ID="lbindustry" runat="server"></asp:Label></td>
                        <td style="width: 48%; height: 36px;">
                            <b>主营产品或服务：</b><asp:Label ID="lbMainProduct" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <b>企业性质：</b><asp:Label ID="lbManageType" runat="server"></asp:Label></td>
                        <td style="width: 48%">
                            <b>企业资本：</b><asp:Label ID="lbRegCapital" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 36px">
                            <b>注册时间：</b><asp:Label ID="lbRegisterDate" runat="server"></asp:Label></td>
                        <td style="width: 48%; height: 36px;">
                            <b>注册地址：</b><asp:Label ID="lbZone" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <ul class="comp_Info" style="margin-left:8px;">
                <li class="titleLi">
                    <img src="../images/icr_03.gif" width="14" height="14" />
                    联系方式</li><li><span>联 系 人：</span>
                    <asp:Label ID="lbLinkMan" runat="server"></asp:Label></li><li><span>电子邮箱：</span>
                        <asp:Label ID="lbMail" runat="server">没有提供</asp:Label></li><li><span>公司网址：</span>
                            <asp:Label ID="lbSite" runat="server">没有提供</asp:Label></li><li><span>固定电话：</span>
                                <asp:Label ID="lbTel" runat="server">没有提供</asp:Label></li><li><span>传 &nbsp;&nbsp; 真：</span>
                                    <asp:Label ID="lbFax" runat="server">没有提供</asp:Label></li><li><span>手 &nbsp;&nbsp; 机：</span>
                                        <asp:Label ID="lbMobile" runat="server">没有提供</asp:Label></li><li><span>联系地址：</span>
                                            <asp:Label ID="lbAddress" runat="server">没有提供</asp:Label></li></ul>
        </div>
    </div>
</asp:Content>
