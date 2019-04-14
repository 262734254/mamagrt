<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alipay_Return.aspx.cs" Inherits="Pay_Alipay_Return" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">我要充值 >> 支付宝充值</span></span></h1>

        <div class="chongzhi01">
      
          <h3>提醒：</h3>
          <ul>
       <li>拓富充值卡可以快速对指定账户进行充值，完成资源购买和其他消费行为。 <a href="#" >了解更多</a></li> 
<li>我们准备了多种购买渠道供您选择，方便、快捷！</li> 
<li>如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="#" >立即购买</a></li>
</ul> 
    
<%--          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="29%" class="account-3-td-r">充值订单号：</td>
    <td width="71%" class="account-3-td-l"><span class="strong"> <asp:Label ID="lab_OrderNo" runat="server"></asp:Label></span></td>
  </tr>
  <tr>
    <td class="account-3-td-r">银行交易号：</td>
    <td class="account-3-td-l"><span class="strong"><asp:Label ID="lab_aliNo" runat="server"></asp:Label></span></td>
  </tr>
    <tr>
    <td class="account-3-td-r">充值金额：</td>
    <td class="account-3-td-l"><span class="hong strong"> <asp:Label ID="lab_Point" runat="server"></asp:Label>元</span></td>
  </tr>
   

</table>--%>

          <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                  <td class="account-3-td-r" width="29%">
                      购买资源：</td>
                  <td class="account-3-td-l" width="71%">
                    <span class="strong">  <asp:Label ID="lblTitle" runat="server"></asp:Label></span></td>
              </tr>
  <tr>
    <td width="29%" class="account-3-td-r">交易订单号：</td>
    <td width="71%" class="account-3-td-l"><span class="strong"> <asp:Label ID="lab_OrderNo" runat="server"></asp:Label></span></td>
  </tr>
  <tr>
    <td class="account-3-td-r">银行交易号：</td>
    <td class="account-3-td-l"><span class="strong"><asp:Label ID="lab_aliNo" runat="server"></asp:Label></span></td>
  </tr>
    <tr>
    <td class="account-3-td-r">交易金额：</td>
    <td class="account-3-td-l"><span class="hong strong"> <asp:Label ID="lab_Point" runat="server"></asp:Label>元</span></td>
  </tr>
              <tr>
                  <td class="account-3-td-r">
                      交易状态：</td>
                  <td class="account-3-td-l">
                  <span class="strong"> <asp:Label ID="lblStatus" runat="server"></asp:Label><span>
                  </td>
              </tr>
              <tr>
                  <td class="account-3-td-r">
                      支付方式：</td>
                  <td class="account-3-td-l">
                  <span class="strong"> 
                  <asp:Label ID="lblPayType"
                        runat="server"></asp:Label>
                        </span>
                  </td>
              </tr>
              <tr>
                  <td class="account-3-td-r">
                      交易时间:</td>
                  <td class="account-3-td-l">
                    <span class="strong">  <asp:Label ID="lblOrderDate" runat="server"></asp:Label></span></td>
              </tr>
</table>
<p> 
 <a href="http://member.topfo.com/PayManage/trade_info_wait.aspx" class="lan1" >查看购买记录</a>
    <a href="javascript:;" class="lan1" onclick="window.print()">打印该页</a></p>

        </div>
     
    
    
    
   
    
      </div>
</div>
</asp:Content>

