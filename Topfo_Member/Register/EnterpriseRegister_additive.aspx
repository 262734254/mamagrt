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
                            登记公司信息</h3>
                    </div>
                    <div class="up_note_rr">
                        <span>
                            <img src="../images/Company_Manage/biao_01.gif"></span><span><a href="" class="lanlink">如何上传文件</a></span></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="dottedl lightc pad_1">
                    <h3 class="cu cheng font14">
                        附加信息(非必填项)</h3>
                    <div>
                        您的公司基本信息已经登记，接下来您可以在下面上传公司的营业执照、税务登记证、组织代码、各种荣誉和证书等， 赢得客户的更多信任，提高合作成功率。</div>
                </div>
                <div class="widthTable mar_7">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="table_style1">
                        <tr>
                            <td width="167" class="gray3 blue13_b" style="height: 15px">
                                上传营业执照：</td>
                            <td style="width: 544px; height: 19px;"><div style="width:300px"><uc2:FileUploader ID="fuYYZZ" runat="server" ImgHeight="160" ImgWidth="220"  IsCancel="1"/>  </div>                              </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="gray3 blue13_b">
                                上传税务登记证：</td>
                            <td style="width: 544px">                            &nbsp; &nbsp; 国税<br />
                                <div style="width:300px" ><uc2:FileUploader ID="fuGS" runat="server" ImgHeight="160" ImgWidth="220"  IsCancel="1"/></div></td>
                        </tr>
                        <tr>
                          <td style="width: 544px">&nbsp;&nbsp; 地税<br />
                            <div style="width:300px"><uc2:FileUploader ID="fuDS" runat="server" ImgHeight="160" ImgWidth="220"  IsCancel="1" /></div></td>
                        </tr>
                        <tr>
                            <td class="gray3 blue13_b" style="height: 43px">
                                上传其它荣誉和证书：</td>
                            <td style="width: 544px; height: 43px;">
                               <div style="width:300px"> <uc2:FileUploader ID="fuRYZS" runat="server" ImgHeight="160" ImgWidth="220" IsCancel="1" />  </div>                          </td>
                        </tr>
                        <tr>
                            <td class="gray3 blue13_b" style="height: 74px">
                                组织机构代码：</td>
                            <td style="width: 544px; height: 74px">
                                <div class="hui">
                                    公开组织机构代码，可以增加合作方的信任感，组织机构代码是由八位数字（或大写拉丁字母）本体 代码和一位数字（或大写拉丁字母）校验码组成，样式如12345678－1</div>
                                <div>
                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="8"></asp:TextBox>-<asp:TextBox ID="TextBox2"
                                        runat="server" Width="72px" MaxLength="1"></asp:TextBox></div>                            </td>
                        </tr>
                    </table>
                </div>
                <div class="center_all mar_7">
                    <a href="EnterpriseRegisterResult.aspx" class="lanlink"></a></div>
                <div class="center_all mar_1">
                    <asp:Button ID="btSend" runat="server" OnClick="btSend_Click" Text="完 成" />&nbsp;</div>
            </div>
        </div>
 </asp:Content>