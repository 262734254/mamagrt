<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EnterpriseRegisterResult.aspx.cs" Inherits="Register_EnterpriseRegisterResult " %>

<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/comp_register.css" rel="stylesheet" type="text/css">
    <div class="all_wrap">
        <div class="contant_l">
            <div class="up_note">
                <div class="up_note_ll left">
                    <h3 class="f14_b2">�Ǽǹ�˾��Ϣ</h3>
                </div>
                <div class="up_note_rr right" ><span></span></div>
                <div class="clear"></div>
            </div>
            <div class="dottedl lightc pad_1">
                <div class="float_all  spacing_1 mar_6" style="width: 713px">
                    <span class="cu cheng font14">
                        <asp:Label ID="lbMessage" runat="server" Text="���Ĺ�˾�����Ѿ�ͨ����ˣ�"></asp:Label><br />
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
                    �Թ�˾�������Ͻ����޸ģ�<span class="mar_8"><a href="EnterpriseRegister.aspx" class="lanlink">�������</a></span></div>
                <div class="line_div1" style="display:none">
                    �����������󹲱���ע<asp:Label ID="lbHits" runat="server"></asp:Label>�Σ�<span class="mar_8"><a
                        href="#" class="lanlink">��˲鿴��ϸ���ʼ�¼</a></span></div>
            </div>
            <h3 class="line_div2 red_c1">
                <asp:Label ID="lbOrgName" runat="server" Text="�й�����Ͷ����"></asp:Label>&nbsp;</h3>
            <div class="ll_rr">
                <div class="float_all widthL7" >
                    <asp:Label ID="lbComAboutBrief" runat="server"></asp:Label>
                </div>
                <div class="profileuser">
                    <div class="profileuser">
                        <uc1:FileUploader ID="FileUploader1"  ImgWidth="220" ImgHeight="160" runat="server" ButtonName="����ϴ�" MaxPics="1"  /><p></p>
                        ͼƬ���ʴ�С��220*160px��
                    </div>           
                </div>
                <div class="clear"></div>
            </div>
            <div class="widthL9">
                <table width="100%" border="0" class="tbWidth">
                    <tr>
                        <td width="44%" style="height: 36px">
                            <b>��Ӫ��ҵ��</b><asp:Label ID="lbindustry" runat="server"></asp:Label></td>
                        <td style="width: 48%; height: 36px;">
                            <b>��Ӫ��Ʒ�����</b><asp:Label ID="lbMainProduct" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <b>��ҵ���ʣ�</b><asp:Label ID="lbManageType" runat="server"></asp:Label></td>
                        <td style="width: 48%">
                            <b>��ҵ�ʱ���</b><asp:Label ID="lbRegCapital" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 36px">
                            <b>ע��ʱ�䣺</b><asp:Label ID="lbRegisterDate" runat="server"></asp:Label></td>
                        <td style="width: 48%; height: 36px;">
                            <b>ע���ַ��</b><asp:Label ID="lbZone" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <ul class="comp_Info" style="margin-left:8px;">
                <li class="titleLi">
                    <img src="../images/icr_03.gif" width="14" height="14" />
                    ��ϵ��ʽ</li><li><span>�� ϵ �ˣ�</span>
                    <asp:Label ID="lbLinkMan" runat="server"></asp:Label></li><li><span>�������䣺</span>
                        <asp:Label ID="lbMail" runat="server">û���ṩ</asp:Label></li><li><span>��˾��ַ��</span>
                            <asp:Label ID="lbSite" runat="server">û���ṩ</asp:Label></li><li><span>�̶��绰��</span>
                                <asp:Label ID="lbTel" runat="server">û���ṩ</asp:Label></li><li><span>�� &nbsp;&nbsp; �棺</span>
                                    <asp:Label ID="lbFax" runat="server">û���ṩ</asp:Label></li><li><span>�� &nbsp;&nbsp; ����</span>
                                        <asp:Label ID="lbMobile" runat="server">û���ṩ</asp:Label></li><li><span>��ϵ��ַ��</span>
                                            <asp:Label ID="lbAddress" runat="server">û���ṩ</asp:Label></li></ul>
        </div>
    </div>
</asp:Content>
