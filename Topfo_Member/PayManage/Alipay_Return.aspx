<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Alipay_Return.aspx.cs" Inherits="PayManage_Alipay_Return" Title="֧������ֵ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;֧������ֵ</div>
            <div class="right">
                <img src="http://www.topfo.com/t/images/publish/biao_01.gif" alt="" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">��ֵ�������</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="szxczbox">
            <div class="suggestbox lightc allxian ">
                <h1>
                    ��ܰ��ʾ</h1>
                <span class="tishiwb">�ظ���ֵ�����Կ��ٶ�ָ���˻����г�ֵ�������Դ���������������Ϊ�� <a href="http://www.topfo.com/help/AccountCZ.shtml"
                    target="_blank">�˽����</a>
                    <br>
                    ����׼���˶��ֹ�����������ѡ�񣬷��㡢��ݣ�
                    <br />
                    ��������κ����ʣ��벦�����ǵĿͷ��绰��0755-82210116 82212980 <a href="http://www.topfo.com/tofocard_buy.aspx"
                        class="bule">��������</a> </span>
            </div>
            <div class="blank20">
            </div>
            <div class="xia">
                <table width="737" height="127" border="0" align="center" cellpadding="0" cellspacing="0"
                    class="huikuang">
                    <tr>
                        <td height="125">
                            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#eeeedd"
                                class="baikuang">
                                <tr>
                                    <td height="29" align="right" bgcolor="#ebebeb">
                                        ��ֵ�����ţ�</td>
                                    <td width="518" align="left" bgcolor="#ffffff">
                                        <asp:Label ID="lab_OrderNo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="29" align="right" bgcolor="#ebebeb">
                                        ���н��׺ţ�</td>
                                    <td align="left" bgcolor="#ffffff">
                                        <asp:Label ID="lab_aliNo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="35" align="right" bgcolor="#ebebeb">
                                        ��ֵ��</td>
                                    <td align="left" bgcolor="#ffffff" height="35">
                                        <asp:Label ID="lab_Point" runat="server"></asp:Label>Ԫ</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
