<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EquityRaised_Issue2.aspx.cs" Inherits="Publish_project_EquityRaised_Issue2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
<table width="100%" height="60" border="0" cellpadding="0" cellspacing="0" style="text-align:center; line-height:20px; margin:15px 0;" class="f_14">
  <tr>
    <td width="130" class="strong">发布资源只需<span class="f_red">2</span>步：</td>
    <td width="125" style="background:url(../../img/member_bg1_off.gif) no-repeat;">第一步<br>填写项目信息</td>
    <td width="50"><img src="../../img/member_icon1.gif" alt="" /></td>
    <td width="125" style="background:url(../../img/member_bg1_on.gif) no-repeat;" class="f_red strong">第二步<br />确认联系方式</td>
    <td>&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="f_14 f_red strong" style="padding:5px 10px;">联系方式确认</td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td width="130" class="tdbg"><span class="f_red">*</span> <strong>项目单位名称：</strong></td>
    <td><input name="textfield" type="text" size="30" /></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>联系人：</strong></td>
    <td><input name="textfield4" type="text" size="10" /></td>
  </tr>
  <tr>
    <td class="tdbg"><strong>职位：</strong></td>
    <td><input name="textfield5" type="text" size="15" /></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>联系电话：</strong></td>
    <td>固话
      <input name="textfield42" type="text" value="86" size="3" />
    <input name="textfield422" type="text" value="0755" size="5" />
    <input name="textfield423" type="text" size="15" />
    <input name="textfield424" type="text" size="5" />
    <br />
    手机
    <input name="textfield425" type="text" size="25" />
    <span class="f_gray">（固定电话或手机至少填写一项）</span></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>电子邮箱：</strong></td>
    <td><input name="textfield2" type="text" size="25" /></td>
  </tr>
  <tr>
    <td class="tdbg"><strong>项目单位详细地址：</strong></td>
    <td><input name="textfield22" type="text" style="width:90%;" /></td>
  </tr>
  <tr>
    <td class="tdbg"><strong>目单位网址：</strong></td>
    <td><input name="textfield3" type="text" size="25" /></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>验证码：</strong></td>
    <td><input name="textfield23" type="text" size="5" /></td>
  </tr>
</table>
<table width="100%" height="60"  cellspacing="0" style="text-align:center;">
  <tr>
    <td><input type="submit" name="Submit33" value="上一步(修改项目信息)" />
    <input type="submit" name="Submit332" value="确认发布" /></td>
  </tr>
</table>
</div>


</asp:Content>