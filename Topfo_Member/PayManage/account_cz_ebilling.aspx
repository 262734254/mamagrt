<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" EnableEventValidation="false" 
    Title="��Ҫ��ֵ-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="account_cz_ebilling.aspx.cs"
    Inherits="PayManage_account_cz_ebilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/accountinfo.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function chkInPut()
    {   
            
		    var p=$id("txtMoney");
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
		    if(u1.value!=u2.value)
		    {
		        alert("����������ʺŲ�һ��");
			    $id("txtLoginName2").focus();
			    return false;
		    }
		    if(p.value=="")
		    {
			    alert("����д���!");
			    $id("txtMoney").focus();
			    return false;
		    }
		    if(isNaN(p.value))
		    {
			    alert("����д��ȷ�Ľ��!");
			    $id("txtMoney").focus();
			    return false;
		    }
		    if(parseFloat(p.value)>50||parseFloat(p.value)<=0)
		    {
			    alert("����д��0-50��Ľ��!");
			    $id("txtMoney").focus();
			    return false;
		    }
		    if($id("txtValiNo").value=="")
		    {
			    alert("��֤�벻��Ϊ��!!");
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
	function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    </script>

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;ebilling�̻���ֵ</div>
            <div class="right">
             <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/help/AccountCZ.shtml" target="_blank">��ֵ�������</a> <a href="http://www.topfo.com/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <div class="suggestbox lightc allxian">
                <h1>
                    ��ܰ��ʾ</h1>
                <span class="tishi">��֧����ʽĿǰֻ�����ڹ㶫���������Ϻ����������㽭������������ȵ��û���</span><br />
                �������֧����ͬ���������Ϊ50Ԫ��ÿ���绰ÿ�����֧�����30-200Ԫ���ȡ�
            </div>
			 <div class="blank20"></div>
            <table id="tabOrder" runat="server" align="center" width="100%">
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> ��ֵ�ʻ���</td>
                  <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />                    <span class="hui">��������Ҫ��ֵ���ʺ�</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> ȷ���ʻ���</td>
                  <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">�ٴ�ȷ�ϳ�ֵ���ʺ�</span></td>
                </tr>
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> ��ֵ��</td>
                    <td colspan="3">
                        <select id="txtMoney" runat="server" style="width: 116px">
                            <option value="1">1.00Ԫ</option>
                            <option value="2">2.00Ԫ</option>
                            <option value="5">5.00Ԫ</option>
                            <option value="8">8.00Ԫ</option>
                            <option value="10">10.00Ԫ</option>
                            <option value="15">15.00Ԫ</option>
                            <option value="20">20.00Ԫ</option>
                            <option value="25">25.00Ԫ</option>
                            <option value="30">30.00Ԫ</option>
                            <option value="35">35.00Ԫ</option>
                            <option value="40">40.00Ԫ</option>
                            <option value="45">45.00Ԫ</option>
                            <option selected="selected" value="50">50.00Ԫ</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" >
                        <span class="STYLE9"><span class="cheng">*</span></span> �������ұߵ���֤�룺</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali" />
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
                    <td align="center" style="height: 27px">&nbsp;
                        </td>
                    <td align="center" style="height: 27px">
                        <asp:Button ID="btnNext" CssClass="buttomal" runat="server" OnClick="btnNext_Click"
                            Text="��һ��" Width="95px" />
                    </td>
                    <td width="37%" style="height: 27px">
                        <input id="Button1" class="buttomal" onclick="window.location.href='account_cz.aspx'"
                            style="width: 85px" type="button" value="�� ��" />&nbsp;</td>
                    <td align="center" style="width: 113px; height: 27px;">&nbsp;
                        </td>
                </tr>
            </table>
            <table id="tabOrderNext" runat="server" align="center" width="100%">
                <tr>
                    <td align="center" style="height: 50px">
                        <span style="font-size: 12pt"><strong>Ϊ�ʻ�<asp:Label ID="lblLoginName" runat="server"></asp:Label>��ֵ<asp:Label
                            ID="lblMoney" runat="server"></asp:Label>Ԫ</strong></span></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnEnter" CssClass="buttomal" runat="server" OnClick="btnEnter_Click"
                            Text="������ֵ" />&nbsp;
                        <asp:Button ID="btnExit" CssClass="buttomal" runat="server" OnClick="btnExit_Click"
                            Text="��һ��" Width="63px" /></td>
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
        </div>
    </div>
</asp:Content>
