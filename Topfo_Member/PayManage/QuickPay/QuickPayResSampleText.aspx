<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuickPayResSampleText.aspx.cs" Inherits="PayManage_QuickPay_QuickPayResSampleText" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">我要充值 >>银联支付</span></span></h1>

        <div class="chongzhi01">
      
          <h3>提醒：</h3>
          <ul>
       <li>拓富充值卡可以快速对指定账户进行充值，完成资源购买和其他消费行为。 <a href="#" >了解更多</a></li> 
<li>我们准备了多种购买渠道供您选择，方便、快捷！</li> 
<li>如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="#" >立即购买</a></li>
</ul> 
    
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="29%" class="account-3-td-r">交易订单号：</td>
    <td width="71%" class="account-3-td-l"><span class="strong"> <asp:Label ID="lab_OrderNo" runat="server"></asp:Label></span></td>
  </tr>
  <tr>
    <td class="account-3-td-r">交易流水号：</td>
    <td class="account-3-td-l"><span class="strong"><asp:Label ID="lab_aliNo" runat="server"></asp:Label></span></td>
  </tr>
    <tr>
    <td class="account-3-td-r">交易金额：</td>
    <td class="account-3-td-l"><span class="hong strong"> <asp:Label ID="lab_Point" runat="server"></asp:Label>元</span></td>
  </tr>
   

</table>

        </div>
     
    
    
    
   
    
      </div>
</div>
    </form>
</body>
</html>
