<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="��Ҫ��ֵ-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="account_cz_szx.aspx.cs"
    Inherits="PayManage_account_cz_szx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    function chkInPut()
    {
        var v=$id("txtValiNo");
		var u1=$id("txtLoginName1");
		var u2=$id("txtLoginName2");
		if(u1.value=="")
		{
		    alert("����д��Ҫ��ֵ���ʻ�");
			$id("txtLoginName1").focus();
			return false;
		}
		if(u2.value=="")
		{
		    alert("��ȷ����Ҫ��ֵ���ʻ�");
			$id("txtLoginName2").focus();
			return false;
		}
		if(u2.value!=u1.value)
		{
		    alert("����������ʺŲ�һ��!");
			$id("txtLoginName2").focus();
			return false;
		}
		if(v.value=="")
		{
		    alert("��������֤��!");
		    $id("txtValiNo").focus();
		    return false;
		    
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

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;�����г�ֵ</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">��ֵ�������</a> <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="szxczbox">
            <div class="suggestbox lightc allxian ">
                <h1>
                    ��ܰ��ʾ</h1>
                Ŀǰ�����г�ֵ����50Ԫ��100Ԫ��300Ԫ��500Ԫ���ֲ�ͬ��ֵ����ȷ����ѡ��ĳ�ֵ�����������ӵ�� <span>�������г�ֵ�������ͬ��</span></div>
				 <div class="blank20"></div>
            <table width="100%" align="center" runat="server" id="tabOrder">
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> ��ֵ�ʻ���</td>
                  <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />
                        <span class="hui">��������Ҫ��ֵ���ʺ�</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> ȷ���ʻ���</td>
                  <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">�ٴ�ȷ�ϳ�ֵ���ʺ�</span></td>
                </tr>
                <tr>
                    <td  align="right">
                        ��ѡ���ֵ��</td>
                    <td colspan="3" style="width: 100%">
                        <input checked="checked" name="payMoney" type="radio" value="50" />
                        50Ԫ
                        <input name="payMoney" type="radio" value="100" />
                        100Ԫ
                        <input name="payMoney" type="radio" value="300" />
                        300Ԫ
                        <input name="payMoney" type="radio" value="500" />
                        500Ԫ <span class="hui font12">��ѡ��Ľ��������ӵ�еĳ�ֵ�������ͬ</span></td>
                </tr>
                <tr>
                    <td align="right" >
                        <span class="STYLE9"><span class="cheng">*</span></span> �������ұߵ���֤�룺</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2" style="width: 442px">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            ���������һ��</a>&nbsp;&nbsp;( ��֤�벻���ִ�Сд )</td>
                </tr>
                <tr>
                    <td height="21" colspan="3" align="center" class="font12">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="33" align="center">&nbsp;
                        </td>
                    <td height="33" colspan="3" align="left" style="width: 442px">
                        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" CssClass="buttomal"
                            Text="��һ��" Width="95px" />
                        <input id="Button1" onclick="window.location.href='account_cz.aspx'" style="width: 85px"
                            type="button" value="�� ��" class="buttomal" /></td>
                </tr>
            </table>
            <table id="tabOrderNext" runat="server" align="center" width="100%">
                <tr>
                    <td align="center" style="height: 50px">
                        <span style="font-size: 12pt"><strong>Ϊ�ʻ�<asp:Label ID="lblLoginName" runat="server"></asp:Label>��ֵ<asp:Label
                            ID="lblMoney" runat="server"></asp:Label><strong>Ԫ</strong></span></td>
                </tr>
                <tr>
                    <td align="center" style="height: 11px">
                        <asp:Button ID="btnEnter" runat="server" OnClick="btnEnter_Click" CssClass="buttomal"
                            Text="������ֵ" />&nbsp;
                        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" CssClass="buttomal"
                            Text="��һ��" Width="63px" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
