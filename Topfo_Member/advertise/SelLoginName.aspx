<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SelLoginName.aspx.cs" Inherits="advertise_SelLoginName" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
     function btn()
     {
        var url="";
        var nn=document.getElementById("ctl00_ContentPlaceHolder1_divId").value;
        url="AdvisitInfo.aspx?adv="+nn;
        window.location.href=url;
     }
    </script>
    <input id="divId" runat="server" type="hidden" />
<div class="member-right">
    <div class="publication">
          <h1><span class="fl"><span class="f_14px strong f_cen">访问者的详细资料</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href=" http://emarketing.topfo.com/ADbusiness/index.html" class="publica-fbxq">广告服务</a></span></h1>

        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
        
        <asp:Panel runat="server" ID="PaNum" Visible="true">
         <tr>
        <td class="f_14px strong f_cen" colspan="2" >访问者资料</td>
        </tr>
            <tr>
                <td  class="publica-td-left" width="20%">
                   <strong>固定电话：</strong></td>
                <td width="80%">
                    <asp:Label runat="server" ID="lblPhone"></asp:Label></td>
            </tr>
            <tr>
                <td class="publica-td-left" width="20%">
                    <span class="f_red"></span><strong>手机号码：</strong></td>
                <td width="80%">
                       <asp:Label runat="server" ID="lblMobile"></asp:Label>
                    </td>
            </tr>
            <tr >
                <td class="publica-td-left" width="20%">
                     <strong>电子邮箱：</strong></td>
                <td width="80%">
                    <asp:Label runat="server" ID="lblEmial"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="publica-td-left" width="20%">
                    <strong>详细地址：</strong></td>
                <td width="80%">
                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="publica-td-left" width="20%">
                    <strong>公司名片：</strong></td>
                <td width="80%">
                     <span runat="server" id="SpanCard" ></span>
                    </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                
                    <input type="button" id="btnOk" class="btn-002" onclick="btn();"   value="返回"/></td>
                
            </tr>
            </asp:Panel>
            <asp:Panel runat="server" ID="PanTishi" Visible="false">
            <tr >
            <td colspan="2" style="text-align:center"><span style="color:Red;">该用户是浏览者，不存在详细信息！</span>
           <asp:LinkButton runat="server" OnClick="Lbtadv_Click" ID="Lbtadv" CssClass="btn-002" Text="返回>>>"></asp:LinkButton></td>
            </tr>
            </asp:Panel>
</table>

    </div>
      </div>
</asp:Content>

