<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="trade_detail.aspx.cs" Inherits="PayManage_trade_detail1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

</script>

 <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">订单明细</span></span></h1>
        <div class="fbcg">
         <div class="fbcg1"> 
         <img src="http://img2.topfo.com/member/img/IS0sBMZWfZj7qQG.png"  class="fl"/>
         <div class="fbcg1-1">
          <p class="f_14px lanl">您现在查看的订单号为 <span class="hong"> <asp:Literal ID="lblORDER" runat="server"></asp:Literal></span> 的订单明细情况。</p>
          <br />
          <p class="f_black">如果您有任何疑问<br />请拨打我们的客服电话：0755-82010116 82212980</p>
         </div>
         </div>
         <div class="dingdxx">
          <h3>交易订单信息</h3>
           <table width="46%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="36%" class="dingd-l">购买资源：</td>
    <td width="64%" class="dingd-r"><asp:Label ID="lblTitle" runat="server"></asp:Label></td>
  </tr>
    <ul>
      <asp:Literal runat="server" ID="cardList"></asp:Literal></ul>
  <tr>
    <td class="dingd-l">订单号：</td>
    <td class="dingd-r"><asp:Label ID="lblOrderNo" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="dingd-l">交易时间:</td>
    <td class="dingd-r"><asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td class="dingd-l">应付金额：</td>
    <td class="dingd-r"><asp:Label ID="lblAmount" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="dingd-l">状态：</td>
    <td class="dingd-r"><asp:Label ID="lblStatus" runat="server"></asp:Label></td>
    </tr>
    <tr>
     <td class="dingd-l" style="height: 32px">支付方式：</td><td class="dingd-r" style="height: 32px"><asp:Label ID="lblPayType"
                        runat="server"></asp:Label></td>
    </tr>
</table>
<p><input name="" type="button" value="关 闭" class="btn-002" id="Button1" onclick="javascript:history.go(-1)"  /> 
    <a href="javascript:;" class="lan1" onclick="window.print()">打印该页</a></p>
         </div>
         
        </div>

    </div>
      </div>
</asp:Content>

