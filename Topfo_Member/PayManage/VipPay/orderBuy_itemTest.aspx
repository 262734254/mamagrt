<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderBuy_itemTest.aspx.cs" Inherits="PayManage_VipPay_orderBuy_itemTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
 <link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />

<link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
 

</head>
<body>
    <form id="form1" runat="server">



<%--<div class="head-bg">
  <div class="head">
    <div class="logo"> <img src="http://img2.topfo.com/member/images/member_14.jpg" /> </div>
    <div class="head-list">
      <ul>
        <li><a href="#">融资</a></li>
        <li><a href="#">投资</a></li>
        <li><a href="#">政府招商</a></li>
        <li><a href="#">资源超市</a></li>
        <li><a href="#">资源联盟</a></li>
        <li id="head-kf-bg"><a href="#">客服中心</a></li>
        <li id="head-fh-bg"><a href="#">返回首页</a></li>
      </ul>
    </div>
    <div class="head-phon"><img src="http://img2.topfo.com/member/images/member_20.jpg" /> </div>
  </div>
</div>--%>
<div class="zfliucheng"><img src="http://img2.topfo.com/member/img/payment_03.jpg"  /></div>
<div class="payment1">
  <h1> 请核对和选择支付方式</h1>
  <div class="payment1-1">
    <ul>
      <li><span class="payment1-1-a">应付总额：</span><span class="f_red strong"><asp:Label
          ID="lblorder_no" runat="server"></asp:Label></span></li>
      <li><span class="payment1-1-a">您的账户余额：</span><span class="f_red strong"><asp:Label
          ID="lblUser_no" runat="server"></asp:Label></span></li>
    </ul>
  </div>
</div>

<div class="pagment-01">
<ul>
           <li> 
             <img src="http://img2.topfo.com/member/img/recharge_03.jpg" class="fl" />
             <div class="pagment-01-1">
              <h3>拓富充值卡充值(推荐使用,充值更实惠)</h3>
              <p>拓富充值卡是中国招商投资网为广大用户提供的 一种即时充值工具，请先购买拓富充值卡.</p>
              <p>  <asp:ImageButton src="http://img2.topfo.com/member/img/payment2_11.jpg" ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" />
             </div>
           </li>
           
              <li> 
             <img src="http://img2.topfo.com/member/img/recharge_10.jpg" class="fl" />
             <div class="pagment-01-1">
              <h3>支付宝充值</h3>
              <p>只要您开通了支付宝，即可实现对帐户充值，足不出户，使用方便、快捷！</p>
              <p>
                  <asp:ImageButton src="http://img2.topfo.com/member/img/payment2_11.jpg" ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" />
              
 <%--             <input name="" type="image" src="http://img2.topfo.com/member/img/payment2_11.jpg" id="Image1" />--%>
              </p>
             </div>
           </li>
       <%--      <li> 
             <img src="http://img2.topfo.com/member/img/recharge_03.jpg" class="fl" />
             <div class="pagment-01-1">
              <h3>拓富充值卡充值(推荐使用,充值更实惠)</h3>
              <p>拓富充值卡是中国招商投资网为广大用户提供的 一种即时充值工具，请先购买拓富充值卡.</p>
              <p><input name="" type="image" src="http://img2.topfo.com/member/img/payment2_11.jpg" /></p>
             </div>
           </li>
           
              <li> 
             <img src="http://img2.topfo.com/member/img/recharge_10.jpg" class="fl" />
             <div class="pagment-01-1">
              <h3>支付宝充值</h3>
              <p>只要您开通了支付宝，即可实现对帐户充值，足不出户，使用方便、快捷！</p>
               <p><input name="" type="image" src="http://img2.topfo.com/member/img/payment2_11.jpg" /></p>
             </div>
           </li>--%>
          </ul>
</div>
<div class="foot-fg">
  <div class="foot">
    <p> <a href="#">关于我们</a> | <a href="#">平台介绍</a> | <a href="#">我们的服务</a> | <a href="#">支付方式</a> | <a href="#">广告服务</a> | <a href="#">服务条款</a> | <a href="#">联系我们</a> | <a href="#">留言反馈</a> | <a href="#">友情链接</a> </p>
    <p> 1998-2009 版权所有    InvestGuide.cn <br />
      拓富科技 中国招商投资网  英文站  拓富网  贤泽投资 支持合作：联合国工业发展组织中国投资促进处唯一授权合作网站<br />
      经营许可证编号为:粤B2-20040428 　ICP编号：粤B2-19981001
      E-Mial:advise@tz888.cn </p>
  </div>
</div>
    </form>
</body>
</html>
