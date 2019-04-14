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
                   
                        ���̻�����Ϣ
              </div>
                <div class="clear">
                </div>
          </div>
            <div class="lightc pad_1 allxian">
                <div class="float_all  spacing_1 mar_6">
                    <span class="cu cheng font14">
                        <asp:Label ID="lbMessage" runat="server" Text="���Ĺ�˾�����Ѿ�ͨ����ˣ�"></asp:Label></span><br />
                    <asp:Label ID="lbResult" runat="server" Width="712px"></asp:Label><br />
                    <asp:Label ID="lbFeedbackStatus"
                        runat="server"></asp:Label><br />
                  <div runat="server" id="divReg">
                        ��Ҫ��ʾ����ȷ���������Ĺ�˾������ʵ��Ч�����ڷ��������Ϣ�������κ����Σ��ɷ��������ге���<br />
                      �������Ĺ�˾����������ͨ��Ա��ǰ�汻�����û���ע��<a href="VIPMemberRegister_In.aspx" class="lanlink">��������ظ�ͨ</a><span
                            class="mar_9">0755-82210116</span><span class="mar_9">82212980</span><a href="http://www.topfo.com/ContactUs.shtml" target="_blank"
                                class="lanlink">���߿ͷ�</a></div>
                </div>
                <div class="clear">
                </div>
            </div>
			<div class="blank0"></div>
            <div class="grayLine1 pad_3 leight30">
            
                   �����̻����������Ͻ����޸ģ�<span class="mar_8"><a href="GovernmentRegister.aspx" class="lanlink">�������</a></span>
                <div class="line_div1" style="display:none" >
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
                        <uc2:FileUploader ID="FileUploader1"  ImgWidth="220" ImgHeight="160" runat="server" ButtonName="����ϴ�" MaxPics="1"  /><p></p>
                        ͼƬ���ʴ�С��220*160px��
                    </div>           
                </div>
                <div class="clear"></div>
            </div>
            <div class="widthL9">
                <table width="100%" border="0" class="tbWidth">
                    <tr>
                        <td width="44%" style="height: 36px">
                            <b>�������壺</b><asp:Label ID="lbMerchantTypeName" runat="server"></asp:Label></td>
                        
                    </tr>
                    <tr>
                        <td style="height: 36px">
                            <strong><span style="font-size: 9pt; color: #000000; font-family: ����; mso-ascii-font-family: 'Times New Roman';
                                mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                mso-bidi-language: AR-SA">��������</span>��</strong><asp:Label ID="lbZone" runat="server"></asp:Label></td>
                        <td style="width: 50%; height: 36px;">
                        </td>
                    </tr>
                </table>
            </div>
            <ul class="comp_Info">
                <li class="titleLi">
                    <img src="../images/icon_yb.gif" width="17" height="17" />
                    ��ϵ��ʽ</li><li><b>�� ϵ �ˣ�</b>
                    <asp:Label ID="lbLinkMan" runat="server"></asp:Label></li><li><b>�������䣺</b>
                        <asp:Label ID="lbMail" runat="server">û���ṩ</asp:Label></li><li><b>��˾��ַ��</b>
                            <asp:Label ID="lbSite" runat="server">û���ṩ</asp:Label></li><li><b>�̶��绰��</b>
                                <asp:Label ID="lbTel" runat="server">û���ṩ</asp:Label></li><li><b>�� &nbsp;&nbsp; �棺</b>
                                    <asp:Label ID="lbFax" runat="server">û���ṩ</asp:Label></li><li><b>�� &nbsp;&nbsp; ����</b>
                                        <asp:Label ID="lbMobile" runat="server">û���ṩ</asp:Label></li><li><b>��ϵ��ַ��</b>
                                            <asp:Label ID="lbAddress" runat="server">û���ṩ</asp:Label></li></ul>
        </div>
</div>
 </asp:Content>