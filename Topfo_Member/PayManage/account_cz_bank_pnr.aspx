<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="�������г�ֵ-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="account_cz_bank_pnr.aspx.cs"
    Inherits="PayManage_account_cz_bank_pnr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
   
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;�������г�ֵ</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">��ֵ�������</a> <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
          <div class="suggestbox lightc allxian">
                <h1>
                    ��ܰ��ʾ</h1>
              <span class="tishiwb">ʹ�ô˳�ֵ��ʽ����Ҫ����ͨ�������й��ܡ��������û�п�ͨ����&gt;&gt;<a href="http://www.topfo.com/web13/help/defray.shtml#14" target="_blank" >��˿�ͨ</a>
                  &gt;&gt;<a href="#" class="bule">�鿴�����޶�</a></span></div>
					<div class="blank20"></div>
            <table id="tabOrder" runat="server" align="center" width="100%">
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> ��ֵ�ʻ���</td>
                  <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />                    <span class="hui">��������Ҫ��ֵ���ʺ�</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> ȷ���ʻ���</td>
                  <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                     <span class="hui"> �ٴ�ȷ�ϳ�ֵ���ʺ�</span></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> ��ֵ��</td>
                    <td colspan="3">
                        <input id="txtMoney" runat="server" name="textfield92" size="18" type="text" />
                        Ԫ<span class="hui font12 "> </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="30">
                        <span class="STYLE9"><span class="cheng">*</span></span> �������ұߵ���֤�룺</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            ���������һ��</a></td>
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
                        <label>
                            &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttomal" OnClick="btnNext_Click"
                                Text="��һ��" Width="95px" /></label></td>
                    <td width="37%" style="height: 27px">
                        &nbsp;<input id="Button1" onclick="window.location.href='account_cz.aspx'" style="width: 85px"
                            type="button" value="�� ��" class="buttomal" /></td>
                    <td align="center" style="width: 113px; height: 27px;">&nbsp;
                        </td>
                </tr>
            </table>
			<div class="blank20"></div>
            <table id="tabOrderNext" runat="server" align="center" width="100%">
                <tr>
                    <td align="center" style="height: 40px">
                        <span style="font-size: 12pt">Ϊ�ʻ�
                            <asp:Literal ID="lblLoginName" runat="server">
                            </asp:Literal>��ֵ<asp:Literal ID="lblMoney" runat="server"></asp:Literal>Ԫ</span></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnEnter" runat="server" CssClass="buttomal" OnClick="btnEnter_Click"
                            Text="������ֵ" />&nbsp;
                        <asp:Button ID="btnExit" runat="server" CssClass="buttomal" OnClick="btnExit_Click"
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
