<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VIPMemberSubmint_In.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="Register_VIPMemberSubmint_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../css/Vip_Reg/VipReg.css" rel="stylesheet" type="text/css">
    <div class="vipreg_warp">
        <div class="reg_channel">
            �����Ϊ�ظ�ͨ��Ա�������ɹ��Ļ������<span>12</span>����
        </div>
        <div class="clear">
        </div>
        <div class="succeednote">
            <div class="succeelay">
                <div class="sleft">
                    <h2>
                        <img src="/images/vip_reg/icr03.gif" /></h2>
                    <div class="tip">
                        ��л��ѡ�����ǵ��ظ�ͨ����<br />
                        ���ǽ�����һ���������������绰��ϵ��
                    </div>
                    <h3>
                        �ظ�ͨ��Ա<span>6</span>����Ȩ��</h3>
                    <div>
                        ��������������60��ע���Ա����ӱ�������ú�������һʱ���ҵ�����<br />
                        �����֤��־��99�����û�Ը����ͨ�������֤�Ļ�ԱǢ̸������</div>
                    <div class="more">
                        <img src="/images/vip_reg/icon_yb.gif" />
                        <a href="" target="" class="lanlink">����˽����</a></div>
                </div>
                <div class="sright">
                    <h3>
                        ��ȷ��������Ϣ�Ƿ���ȷ��<img height="21" src="../images/Application/icon_jt03.gif" width="20" /></h3>
                    <div class="rfall">
                        <h1>
                            <asp:Label ID="lbOrgName" runat="server" ForeColor="#FF8000"></asp:Label>
                            <asp:Label ID="lbtbRealName" runat="server" ForeColor="#FF8000"></asp:Label><asp:Label
                                ID="lbSex" runat="server"></asp:Label></h1>
                        <p>
                            ��Ա���ͣ��ظ�ͨ��Ա<asp:Label ID="lbManageType" runat="server"></asp:Label><br />
                            �������ޣ�<asp:Label ID="lbBuyTerm" runat="server"></asp:Label><br />
                            �ܽ�<asp:Label ID="lbPrice" runat="server"></asp:Label>Ԫ<br />
                            ��ϵ�绰��<asp:Label ID="lbTel" runat="server"></asp:Label><br />
                            �������䣺<asp:Label ID="lbEmail" runat="server"></asp:Label></p>
                        <div class="dizi">
                            �����Ϣ����
                            <img align="absMiddle" height="17" src="../images/icon_yb.gif" width="17" />
                            <asp:HyperLink ID="hlUpdate" runat="server">�����޸�</asp:HyperLink></div>
                        <a href="" target="" class="lanlink"></a>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="succeedownline">
            </div>
        </div>
        <div class="vipflow">
            <div class="flowtitle">
                ��ֻ��Ҫ���¼��������������ظ�ͨ��Ա��<span>���</span>����</div>
        </div>
        <div class="vipflowp">
            <div class="flowbj">
                <div class="bgflow">
                    <h3>
                        ǩ��Э��</h3>
                    ������������
                </div>
                <div class="arwflow">
                </div>
                <div class="bgflow">
                    <h3>
                        �� ��</h3>
                    ����֧���������ɿ��
                </div>
                <div class="arwflow">
                </div>
                <div class="bgflow">
                    <h3>
                        �����֤</h3>
                    1-3��������
                </div>
                <div class="arwflow">
                </div>
                <div class="bgflow">
                    <h3>
                        ��ͨ����</h3>
                    ��Ϊ�ظ�ͨ��Ա
                </div>
            </div>
        </div>
    </div>
</asp:Content>
