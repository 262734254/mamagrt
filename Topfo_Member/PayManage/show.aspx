<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="show.aspx.cs" Inherits="PayManage_show" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��Ҫ��ֵ&gt;&gt;�Ƹ�ͨ��ֵ</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">��ֵ�������</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">��ȫ������֪</a>
            </div>
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
                    ��������κ����ʣ��벦�����ǵĿͷ��绰��0755-82210116 82212980 <a href="tofocard_buy.aspx" class="bule">��������</a> </span>
            </div>
            <div class="blank20">
            </div>
            <%=showStr %>
        </div>
    </div>
</asp:Content>
