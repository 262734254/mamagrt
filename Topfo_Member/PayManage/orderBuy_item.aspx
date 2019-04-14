<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="orderBuy_item.aspx.cs" Inherits="PayManage_order_item" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

</script>


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
              <p><asp:ImageButton src="http://img2.topfo.com/member/img/payment2_11.jpg" ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" /></p>
             </div>
           </li>
           
              <li style="display:none"> 
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
             <li> 
             <img src="http://img2.topfo.com/member/img/zf.gif" class="fl" />
             <div class="pagment-01-1">
              <h3>中国银联支付</h3>
              <p>中国银联支付.</p>
              <p>  <asp:ImageButton src="http://img2.topfo.com/member/img/payment2_11.jpg" ID="ImageButton4" runat="server" OnClick="ImageButton4_Click" /></p>
             </div>
           </li>
           <%--
              <li> 
             <img src="http://img2.topfo.com/member/img/recharge_10.jpg" class="fl" />
             <div class="pagment-01-1">
              <h3>支付宝充值</h3>
              <p>只要您开通了支付宝，即可实现对帐户充值，足不出户，使用方便、快捷！</p>
               <p><input name="" type="image" src="http://img2.topfo.com/member/img/payment2_11.jpg" /></p>
             </div>
           </li>--%>
          </ul>
            <table width="700" style="margin-left:auto; margin-right:auto; border: solid 2px #C33" border="1">
        <tr>
            <td colspan="3">
             <h3>
                 银行转账(直接汇款)

</h3>
            </td>
        </tr>
  <tr>
    <td style="width: 55px"><div align="center">[01]</div></td>
    <td width="347" height="40"><div align="center"><img src="http://img2.topfo.com/member/images/icbc.gif" width="98" height="28" /></div></td>
    <td width="283">户　　名：深圳拓富网络有限公司<br />
      开户银行：工行深圳分行高新园支行<br />
      帐　　号：4000 0919 0910 0034 735</td>
  </tr>
  <tr>
    <td style="width: 55px"><div align="center">[02]</div></td>
    <td height="40"><div align="center"><img src="http://img2.topfo.com/member/images/gdfz.gif" width="96" height="28" /></div></td>
    <td><p>户　　名：深圳拓富网络有限公司</p>
      <p>开户银行：广东发展银行深圳分行发展中心支行</p>
      <p>帐　　号：1020 3151 6010 0050 75</p></td>
  </tr>
  <tr>
    <td style="width: 55px"><div align="center">[03]</div></td>
    <td height="40"><div align="center"><img src="http://img2.topfo.com/member/images/le.gif" width="100" height="30" /></div></td>
    <td>户　　名：张晓红<br />
      开户银行：中国农业银行<br />
      帐　　号：62284 8012 02482 34417</td>
  </tr>
  <tr>
    <td style="width: 55px"><div align="center">[04]</div></td>
    <td height="40"><div align="center"><img src="http://img2.topfo.com/member/images/icbc.gif" width="98" height="28" /></div></td>
    <td>户　　名：张晓红<br />
      开户银行：中国工商银行<br />
      帐　　号：62220 04000 11466 9138</td>
  </tr>
  <tr>
    <td style="width: 55px"><div align="center">[05]</div></td>
    <td height="40"><div align="center"><img src="http://img2.topfo.com/member/images/cmb.gif" width="96" height="28" /></div></td>
    <td>户　　名：张晓红<br />
      开户银行：中国招商银行<br />
      帐　　号：6225 8878 1995 0409</td>
  </tr>
  <tr>
    <td style="width: 55px"><div align="center">[06]</div></td>
    <td height="40"><div align="center"><img src="http://img2.topfo.com/member/images/cmb2.gif" width="96" height="28" /></div></td>
    <td>户　　名：张晓红<br />
      开户银行：中国建设银行<br />
      帐　　号：6227 0072 0001 0552 018</td>
   </tr>
        <tr>
            <td colspan="3">
            <h3>
                备注：使用银行转账，转账成功后请联系</h3>
                <h3>
                    &nbsp; &nbsp;&nbsp; &nbsp;周小姐 电话：86146728/18925252758 &nbsp;&nbsp; 黄先生 电话：89805588-8028/18925252763</h3>
            </td>
        </tr>
</table>
      
          
</div>

</asp:Content>

