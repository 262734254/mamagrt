<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="OrgRegisterSucceed.aspx.cs" Inherits="Register_OrgRegisterSucceed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/comp_register.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
init();
document.write("test");
function init()
{
     var typeVaule= document.getElementById("ctl00_ContentPlaceHolder1_Hidden1").value) ;
  
    if(typeVaule==0){
    document.getElementById("div1001").style.display="block";
    document.getElementById("div1002").style.display="none";
    }
    else if(typeVaule==1)
    {
       document.getElementById("div1002").style.display="block";
       document.getElementById("div1001").style.display="none";
    }
}
    </script>

    <div class="all_wrap" onload="init();">
        <div class="contant_l">
            <div class="up_note">
                <div class="up_note_ll">
                    <h3 class="f14_b2">
                        <asp:Label ID="lbOrgType" runat="server" Text="�Ǽǹ�˾��Ϣ"></asp:Label>&nbsp;</h3>
                </div>
                <div class="up_note_rr">
                    <span>
                        <img src="../images/Company_Manage/biao_01.gif" align="absmiddle" /></span><span><a
                            href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank" class="lanlink">���󷢲�����</a></span></div>
                <div class="clear"> </div>
            </div>
			<div style="clear:both;margin:3px;"> </div>
			
			
            <div class="dottedl lightc pad_1">
                <div class="float_all">
                    <img src="../images/Company_Manage/biao_03.gif" class="mar_5" /></div>
                <div class="float_all  spacing_1 mar_6 widthL11">
                    <span class="cu cheng font14">��ϲ��������Ϣ<asp:Label ID="Label1" runat="server"></asp:Label>�ɹ������ύ��ˣ�<br />
                    </span>
					
                    <div class="clear"> </div>
                    <div id="Message" runat="server">
                    </div>
                    <div class="clear"></div>
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt; text-indent: 76.5pt; line-height: 12pt;
                        mso-char-indent-count: 8.5">
                        <span style="font-size: 9pt; color: black; font-family: ����"></span>
                    </p>
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt; text-indent: 76.5pt; line-height: 12pt;
                        mso-char-indent-count: 8.5">&nbsp;
                        </p>
                </div>
				<div class="clear"> </div>
			</div>
				
				
				
		<div class="clear"> </div>
		<div id="divMG"></div>
				<asp:Panel ID="panel1002" runat="server">
            <div id="div1002">
                <div class="grayLine1 pad_3 fz_14">
                    �����ڿ��ԣ�</div>
                <div>
                    <a href="/Publish/publishNavigate.aspx" class="Spaces">
                        <img src="../images/Company_Manage/arr_07.gif" align="absmiddle" class="mar_3 onpic" /></a>�ÿͻ����������ţ�</div>
                <div class="grayLine1 pad_3 fz_14">
                    <b>�ظ�ͨ��Ա����ˢ���Լ��ǼǵĹ�˾����������</b></div>
                <p>
                    �涨�������ڣ����ǼǵĹ�˾��������ͨ��Ա��ǰ�棬������Ǳ�ڿͻ���ע��</p>
                <p>
                    ������������ڽ���֮����������ͨ��<a href="/Manage/InfoRefreshSet.aspx"><span class="red_c2">ˢ��</span></a>���Ĺ�˾�������������������Ȩ����������ظ�ͨ��Աר��Ĺ���Ŷ<br />
                    ��ÿ����˾ÿ��ֻ��ˢ��һ�Σ�!</p>
                <div class="widthTable400">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="table_style2">
                        <tr>
                            <td class="gray2 blue12_b">
                                λ ��</td>
                            <td>
                                ������������</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                �����б�</td>
                            <td>
                                һ��</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                �����б�</td>
                            <td>
                                һ��</td>
                        </tr>
                    </table>
                </div>
            </div>
			</asp:Panel>
			<div class="clear"> </div>
			<asp:Panel ID="panel1001" runat="server">
            <div id="div1001" >
                <div class="grayLine1 pad_3 fz_14">
                    �����ڿ��ԣ�</div>
                <div>
                    <a href="../Publish/PublishMerchant1.aspx">
                        <img src="../images/Company_Manage/arr_07.gif" align="absmiddle" class="mar_3 onpic"></a>�ÿͻ����������ţ�</div>
                <div class="grayLine1 pad_3 fz_14">
                    �����ظ�ͨ��Ա��������Ի����񣬿ͻ������Σ�</div>
                <div class="widthTable620">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="table_style4">
                        <tr>
                            <td class="gray2">&nbsp;
                                </td>
                            <td>
                                �ظ�ͨ��Ա</td>
                            <td>
                                ��ͨ��Ա</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                ��˾������֤</td>
                            <td>
                                ��</td>
                            <td>
                                ��</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                ˢ�����ã���������</td>
                            <td>
                                ��</td>
                            <td>
                                ��</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                ���Ի�չ��
                            </td>
                            <td>
                                ����ǿ��</td>
                            <td>
                                ���ܼ�</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                VIP�۸��������з���</td>
                            <td>
                                ��</td>
                            <td>
                                ��</td>
                        </tr>
                        <tr>
                            <td class="gray2 blue12_b">
                                רҵ����</td>
                            <td>
                                �������ʸ�</td>
                            <td>
                                �������ʸ�</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="gray4">
                                <a href="http://www.topfo.com/Service/enterprisemember.shtml" class="lanlink">�˽��ظ�ͨ������Ȩ &gt; &gt;</a></td>
                        </tr>
                    </table>
                    <div class="widthTable620">
                        <div class="float_all">
                            <a href="VIPMemberRegister_In.aspx" class="lanlink">��1ԪǮ����1���ظ�ͨ��Ա����</a> <span><a href="VIPMemberRegister_In.aspx" class="lanlink mar_8">
                                ���������ظ�ͨ</a></span>
                        </div>
                        <div class="float_right">
                            <span class="mar_8">0755-82210116</span> <span class="mar_8">82212980</span> <span
                                class="mar_8">���߿ͷ�</span> <span>
                                    <img src="../images/Company_Manage/arr_09.gif"></span>
                        </div>
                    </div>
                </div>
            </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
