<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="��Ҫ��ֵ-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="account_cz_post.aspx.cs"
    Inherits="PayManage_account_cz_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
--%>
    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
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
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;��������ֵ</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">��ֵ�������</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <h1 class="pad_1" style="padding-left: 200px">
                ����������д�Ի�ö����ţ�<span class="cheng">*</span>Ϊ������</h1>
            <table width="100%" height="336" align="center" cellpadding="0" cellspacing="0" id="tabOrder"
                runat="server">
                <tr>
                    <td align="right" width="32%">
                        <span class="cheng">*</span> ��ֵ�ʻ���</td>
                    <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />
                        <span class="hui">��������Ҫ��ֵ���ʺ�</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right" width="32%">
                        <span class="cheng">*</span> ȷ���ʻ���</td>
                    <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">�ٴ�ȷ�ϳ�ֵ���ʺ�</span></td>
                </tr>
                <tr>
                    <td align="right" width="32%">
                        <span class="cheng">*</span> ��ֵ��</td>
                    <td colspan="3">
                        <input id="txtMoney" runat="server" name="textfield92" size="18" type="text" />
                        Ԫ<span class="hui font12 "> </span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="STYLE9"><span class="cheng">*</span></span> �������ұߵ���֤�룺</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle"
                            id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            ���������һ��</a>&nbsp;&nbsp;( ��֤�벻���ִ�Сд )</td>
                </tr>
                <tr>
                    <td align="center" class="font12" colspan="4">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" height="128">
                        &nbsp;
                    </td>
                    <td align="left" class="font12" colspan="2" height="128">
                        <font class="cheng">�������¼���»����Ϣ��</font>
                        <br />
                        �����: 6221 8858 40000 3803 934<br />
                        
                        <br />
                        �տ���: ������
                        <br />
                       
                        �����;: ���ڻ��ĸ�����ע�������ź��û���(<span class="cheng">�м�</span>)
                    </td>
                    <td align="left" class="font12" style="width: 113px" valign="bottom">
                        <img height="14" src="../images/PayManage/biao_print.gif" width="15" />
                        <a href="javascript:;" onclick="window:print()">��ӡ��ҳ</a></td>
                </tr>
                <tr>
                    <td align="center" class="font12" colspan="4" height="11">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" height="27">
                        &nbsp;
                    </td>
                    <td align="center" height="27">
                        <label>
                            &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttomal" OnClick="btnNext_Click"
                                Text="��һ��" Width="95px" /></label></td>
                    <td height="27" width="37%">
                        &nbsp;<input id="Button1" onclick="window.location.href='account_cz.aspx'" style="width: 85px"
                            type="button" value="�� ��" class="buttomal" /></td>
                    <td align="center" height="27" style="width: 113px">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table id="tabOrderNext" runat="server" align="center" height="328" width="100%">
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
                        <asp:Label ID="lblMoney" runat="server"></asp:Label>Ԫ
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        ��ֵ���ڣ�</td>
                    <td align="left">
                        <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" height="33">
                        &nbsp;<img align="absMiddle" src="../images/icon_yb.gif" />
                        ����ȷ��д���ĸ������ϡ��Ա������ܼ�ʱ֪ͨ����ֵ�ɹ���</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> �� ϵ �ˣ�</td>
                    <td align="left">
                        <input id="txtName" runat="server" name="textarea" type="text" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> ��ϵ�绰��</td>
                    <td align="left">
                        <input id="txtTel" runat="server" name="textarea3" type="text" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        ��ϵ�ֻ���</td>
                    <td align="left">
                        <input id="txtMobile" runat="server" name="textarea3" type="text" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        �����ʼ���</td>
                    <td align="left">
                        <input id="txtEmail" runat="server" name="textarea32" type="text" /></td>
                </tr>
                <tr>
                    <td style="width: 236px">
                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnEnter" CssClass="buttomal" runat="server" OnClick="btnEnter_Click"
                            Text="�ύ����" />&nbsp;
                        <asp:Button ID="btnExit" CssClass="buttomal" runat="server" OnClick="btnExit_Click"
                            Text="����" Width="75px" /></td>
                </tr>
            </table>
            <br />
            <div class="helpbox">
                <div class="con">
                    <h1>
                        <img align="absMiddle" src="../images/icon_yb.gif" /><strong> ע������</strong></h1>
                    <p>
                        1. �����뽫���ƾ֤���浽0755-82213698����������֧���ͻ����ӡ֧���ɹ�ҳ�棩
                        <br />
                        2. ������ǽ�����Ϊ����ֵ�����ڳ�ֵ��ĵ�һʱ������绰����Ż���
                        <br />
                        3. ��������κ����ʣ��벦�����ǵĿͷ��绰��<!--#include file="../common/custel.html"-->
                    </p>
                </div>
            </div>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>
