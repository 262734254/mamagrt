<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" Title="���л���ֵ-�ظ�����-�й�����Ͷ����"
    AutoEventWireup="true" CodeFile="account_cz_bank_hk.aspx.cs" Inherits="PayManage_account_cz_bank_hk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript">
	function chkPostOrder()
	{
		if($id("txtName").value=="")
		{
			alert("��������Ϊ��!");
			$id("txtName").focus();
			return false;
		}
		if($id("txtTel").value==""&&$id("txtMobile").value=="")
		{
			alert("�绰���ֻ�ѡ��һ��!"); 
			$id("txtTel").focus();
			return false;
	    }
	    if($id("txtMobile").value!="")
        {
            if($id("txtMobile").value.length!=11)
            {
                alert("�ֻ���ʽ����!");
                $id("txtMobile").focus();
                return false;
            }
            if(isNaN($id("txtMobile").value))
            {
                 alert("�ֻ���ʽ����!");
                $id("txtMobile").focus();
                return false;
            }
        }
	}
	function valiLoginName()
	{
	    var u=$id("txtLoginName1");
	    AjaxMethod.ValiLoginName(u.value,backres);
	}
	function backres(res)
	{
	   if(!res.value)
	   {
	      document.getElementById("divmsg").innerHTML="<font color='red'>������ʻ�������!<font>";
	       $id("txtLoginName1").value="";
	   }
	   else
	   {
	       document.getElementById("divmsg").innerHTML="";
	   }
	}
	function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    </script>

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;����ת�ʳ�ֵ</div>
            <div class="right">
            <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">��ֵ�������</a> <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <h1 class="pad_1" style="padding-left:200px">
               ��ȷ�����Ķ�����Ϣ��</h1>
            <table width="100%" height="328" align="center" id="tabOrder" runat="server">
                <tr>
                    <td width="32%" height="30" align="right">
                        <span class="cheng">*</span> ��ֵ�ʻ���</td>
                  <td colspan="3">
                        <input name="textfield92" type="text" size="18" id="txtLoginName1" onblur="valiLoginName()"
                            runat="server" />                    <span class="hui">��������Ҫ��ֵ���ʺ�<span id="divmsg"></span></span></td>
                </tr>
                <tr>
                    <td width="32%" height="30" align="right">
                        <span class="cheng">*</span> ȷ���ʻ���</td>
                  <td colspan="3">
                        <input name="textfield92" type="text" size="18" id="txtLoginName2" runat="server" />
                      <span class="hui">                      �ٴ�ȷ�ϳ�ֵ���ʺ�</span></td>
                </tr>
                <tr>
                    <td width="32%" height="30" align="right">
                        <span class="cheng">*</span> ��ֵ��</td>
                    <td colspan="3">
                        <input name="textfield92" type="text" size="18" id="txtMoney" runat="server" />
                        Ԫ<span class="hui font12 "> </span>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right">
                        <span class="STYLE9"><span class="cheng">*</span></span> �������ұߵ���֤�룺</td>
                    <td width="16%" class="STYLE9">
                        <input name="textfield9" type="text" size="18" id="txtValiNo" runat="server" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali">
                        <a onclick="refreshVerifyCode();return false;" class="font12 bule" href="javascript:;">
                            ���������һ��</a></td>
                </tr>
                <tr>
                    <td colspan="4" align="center" class="font12">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="128" align="center">&nbsp;
                  </td>
                    <td height="128" colspan="2" align="left" class="font12">
                        <font class="cheng">�������¼���»����Ϣ��</font>
                        <br>
                        �Թ�����: ����������Ͷ�����޹�˾
                        <br>
                        ũ ��: ������ũ�й�ó֧�� 41008900040016258
                       
                        <br>
                        �� ��: �����й��̹�ó֧�� 4000022819200018954
                        <br>
                        <br>
                        ���˻���: ������
                        <br>
                        ũ ��: ũҵ���н���ͨ���� 6228480120057721116
                        <br>
                        �� ��: ��������һ��ͨ 5124257555525555
                        <br>
                        �� ��: ��������ĵ����ͨ�� 9558804000111681363
                        <br>
                        �����;: ���ڻ��ĸ�����ע�������ź��û�����<font class="cheng">�мǣ�</font>��</td>
                    <td align="left" valign="bottom" class="font12" style="width: 113px">
                        <img src="../images/PayManage/biao_print.gif" width="15" height="14" />
                        <a href="javascript:;" onclick="window:print()">��ӡ��ҳ</a></td>
                </tr>
                <tr>
                    <td height="28" colspan="4" align="center" class="font12">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center">&nbsp;
                  </td>
                    <td height="27" align="center">
                        <label>
                            &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttomal" Text="��һ��" Width="95px" OnClick="btnNext_Click" /></label></td>
                    <td width="37%" height="27">
                        &nbsp;<input id="Button1" style="width: 85px" type="button" value="�� ��" class="buttomal" onclick="window.location.href='account_cz.aspx'" /></td>
                    <td height="27" align="center" style="width: 113px">&nbsp;
                  </td>
                </tr>
            </table>
            <table width="100%" height="328" align="center" id="tabOrderNext" runat="server">
                <tr>
                    <td align="right" style="width: 236px">
                        ��ֵ�ʻ���</td>
                    <td align="left">
                        <asp:Label ID="lblLoginName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        ��ֵ��</td>
                    <td align="left">
                        <asp:Label ID="lblMoney" runat="server"></asp:Label>Ԫ                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        ��ֵ���ڣ�</td>
                    <td align="left">
                        <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" height="33">
                        &nbsp;<img src="../images/icon_yb.gif" align="absmiddle" />
                        ����ȷ��д���ĸ������ϡ��Ա������ܼ�ʱ֪ͨ����ֵ�ɹ���</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> �� ϵ �ˣ�</td>
                  <td align="left">
                        <input id="txtName" type="text" name="textarea" runat="server">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> ��ϵ�绰��</td>
                    <td align="left">
                        <input id="txtTel" type="text" name="textarea3" runat="server">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        ��ϵ�ֻ���</td>
                    <td align="left">
                        <input id="txtMobile" type="text" name="textarea3" runat="server"></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        �����ʼ���</td>
                    <td align="left">
                        <input id="txtEmail" type="text" name="textarea32" runat="server"></td>
                </tr>
                <tr>
                    <td style="width: 236px">                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnEnter" runat="server" CssClass="buttomal" Text="�ύ����" OnClick="btnEnter_Click"></asp:Button>&nbsp;
                        <asp:Button ID="btnExit" runat="server" Text="����"  CssClass="buttomal" Width="75px" OnClick="btnExit_Click">                        </asp:Button></td>
                </tr>
            </table>
            <div class="blank20"></div>
            <div class="helpbox">
                <div class="con">
                    <h1>
                        <img src="../images/icon_yb.gif" align="absmiddle" /><strong> ע������</strong></h1>
                    <p>
                        1. �����뽫���ƾ֤���浽0755-82213698����������֧���ͻ����ӡ֧���ɹ�ҳ�棩
                        <br />
                        2. ������ǽ�����Ϊ����ֵ�����ڳ�ֵ��ĵ�һʱ������绰����Ż���
                        <br />
                        3. ��������κ����ʣ��벦�����ǵĿͷ��绰��<!--#include file="../common/custel.html"-->
                    </p>
                </div>
            </div>
			 <div class="blank20"></div>
        </div>
    </div>
</asp:Content>