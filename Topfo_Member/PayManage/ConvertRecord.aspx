<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConvertRecord.aspx.cs" Inherits="PayManage_DConvertRecord" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Literal1" runat="server" Text="<link href=../css/paymanage.css rel='stylesheet' type='text/css' />"></asp:Literal>
<div id="mainconbox">
<div class="topzi"><div class="left">我的购物券 </div>
  <div class="clear"></div>
</div>

<!--购物券兑换 -->
<div class="mycartbox">
<div class="title">
  <ul><li >购物券兑换</li>
  <li class="liwai">兑换记录</li><li class="linone"><a href="#">购物券资源专区</a> </li>
 </ul>
  </div>
  <div class="con">
  <div class="titlea">拓富通会员<span class="chengcu">vince727</span>的详细兑换记录</div>
    <div class="titleb">累计积分<a href="#" class="chenglink">80000</a>分，共兑换4次，累计兑换购物券总额<strong >400</strong>元，已使用<strong >400</strong>元<span><a href="#" class="lanlink">查看购物券消费记录</a> </span></div><table width="757" border="0" cellpadding="0" cellspacing="0" class="tabtitle">
  <tr>
    <td width="111" align="center">编号                                               </td>
    <td width="126">兑换时间</td>
    <td width="120">兑换积分 </td>
    <td width="128">兑换金额(元)</td>
    <td width="121">剩余积分</td>
    <td width="151">购物券有效截至日期 </td>
    </tr>
</table>
<table width="757" border="0" cellpadding="0" cellspacing="0" class="taba">
  <tr>
    <td width="110" align="center">第4次 </td>
    <td width="127">2007-8-10</td>
    <td width="120">10000分</td>
    <td width="129">100.00</td>
    <td width="120">15000</td>
    <td width="151"> 2007-11-10</td>
    </tr>
</table>
<table width="757" border="0" cellpadding="0" cellspacing="0" class="tabb">
  <tr>
    <td width="109" align="center">第4次 </td>
    <td width="127">2007-8-10</td>
    <td width="122">10000分</td>
    <td width="128">100.00</td>
    <td width="120">15000</td>
    <td width="151"> 2007-11-10</td>
    </tr>
</table>
<table width="757" border="0" cellpadding="0" cellspacing="0" class="taba">
  <tr>
    <td width="108" align="center">第4次 </td>
    <td width="127">2007-8-10</td>
    <td width="122">10000分</td>
    <td width="129">100.00</td>
    <td width="120">15000</td>
    <td width="151"> 2007-11-10</td>
    </tr>
</table>
<div class="bottom"> 共3条 　页次：1/1页    　首页    　上一页    　下一页    　尾页<span>转到
  
    第
    <input name="textarea" type="text" id="textarea" value="" size="5"  style="width:20px;height:15px;"/ >       
    页</span>
  
    <input type="submit" name="button2" id="button2" value="GO" style="width:30px;height:20px;font-size:12px;" />
    </label>
  </div>
<div class="clear"></div>
   </div>
  </div>
<!--帮助 -->
</div>
</asp:Content>

