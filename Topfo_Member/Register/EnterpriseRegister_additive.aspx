<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EnterpriseRegister_additive.aspx.cs"
    Inherits="Register_EnterpriseRegister_additive" %>

<%@ Register Src="Control/test.ascx" TagName="FileUploader" TagPrefix="uc2" %>
<%@ Register Src="Control/ImageUpLoadForAdditive.ascx" TagName="ImageUpLoadForAdditive"
    TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../css/comp_register.css" rel="stylesheet" type="text/css" />
        <div class="all_wrap">
            <div class="contant_l">
                <div class="up_note">
                    <div class="up_note_ll">
                        <h3 class="f14_b2">
                            �Ǽǹ�˾��Ϣ</h3>
                    </div>
                    <div class="up_note_rr">
                        <span>
                            <img src="../images/Company_Manage/biao_01.gif"></span><span><a href="" class="lanlink">����ϴ��ļ�</a></span></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="dottedl lightc pad_1">
                    <h3 class="cu cheng font14">
                        ������Ϣ(�Ǳ�����)</h3>
                    <div>
                        ���Ĺ�˾������Ϣ�Ѿ��Ǽǣ��������������������ϴ���˾��Ӫҵִ�ա�˰��Ǽ�֤����֯���롢����������֤��ȣ� Ӯ�ÿͻ��ĸ������Σ���ߺ����ɹ��ʡ�</div>
                </div>
                <div class="widthTable mar_7">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="table_style1">
                        <tr>
                            <td width="167" class="gray3 blue13_b" style="height: 15px">
                                �ϴ�Ӫҵִ�գ�</td>
                            <td style="width: 544px; height: 19px;"><div style="width:300px"><uc2:FileUploader ID="fuYYZZ" runat="server" ImgHeight="160" ImgWidth="220"  IsCancel="1"/>  </div>                              </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="gray3 blue13_b">
                                �ϴ�˰��Ǽ�֤��</td>
                            <td style="width: 544px">                            &nbsp; &nbsp; ��˰<br />
                                <div style="width:300px" ><uc2:FileUploader ID="fuGS" runat="server" ImgHeight="160" ImgWidth="220"  IsCancel="1"/></div></td>
                        </tr>
                        <tr>
                          <td style="width: 544px">&nbsp;&nbsp; ��˰<br />
                            <div style="width:300px"><uc2:FileUploader ID="fuDS" runat="server" ImgHeight="160" ImgWidth="220"  IsCancel="1" /></div></td>
                        </tr>
                        <tr>
                            <td class="gray3 blue13_b" style="height: 43px">
                                �ϴ�����������֤�飺</td>
                            <td style="width: 544px; height: 43px;">
                               <div style="width:300px"> <uc2:FileUploader ID="fuRYZS" runat="server" ImgHeight="160" ImgWidth="220" IsCancel="1" />  </div>                          </td>
                        </tr>
                        <tr>
                            <td class="gray3 blue13_b" style="height: 74px">
                                ��֯�������룺</td>
                            <td style="width: 544px; height: 74px">
                                <div class="hui">
                                    ������֯�������룬�������Ӻ����������θУ���֯�����������ɰ�λ���֣����д������ĸ������ �����һλ���֣����д������ĸ��У������ɣ���ʽ��12345678��1</div>
                                <div>
                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="8"></asp:TextBox>-<asp:TextBox ID="TextBox2"
                                        runat="server" Width="72px" MaxLength="1"></asp:TextBox></div>                            </td>
                        </tr>
                    </table>
                </div>
                <div class="center_all mar_7">
                    <a href="EnterpriseRegisterResult.aspx" class="lanlink"></a></div>
                <div class="center_all mar_1">
                    <asp:Button ID="btSend" runat="server" OnClick="btSend_Click" Text="�� ��" />&nbsp;</div>
            </div>
        </div>
 </asp:Content>