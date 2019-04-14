<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Send.aspx.cs" Inherits="InnerInfo_Send" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>我发出的消息</title>
<link href="../css/common.css" rel="stylesheet" type="text/css" />
<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div id="mainconbox">
<div class="topzi">
<div class="left">
我的短消息
</div>
<div class="clear"></div>
</div>
<div class="blank0"></div>
<div class="handtop" >
  <ul><li><u>发送短消息</u></li>
  <li >
  我收到的消息 
  </li> 
  <li class="liwai"> 我发出的消息 </li> <li> 回收站</li> 
 </ul>
</div>
<div class=" cshibiank">
  <div class="search">
  <div class="lefts">
   您现在查看的是：
    <select name="select">
        <option selected="selected" value="所有信息">最近发出的消息 </option>
      </select>
  </div><div class="rights">每页显示：<a href="#" class="lanlink">10</a> 条 <a href="#" class="lanlink">20</a> 条 <a href="#" class="lanlink">30</a> 条</div>
       <div class="clear"></div>
</div>
<table width="100%" height="167" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td width="15%" align="center" class="tabtitle">全选/反选</td>
    <td width="44%" align="center" class="tabtitle"> 标 题</td>
    <td width="21%" align="center" class="tabtitle">收件人</td>
    <td width="20%" align="center" class="tabtitle">发送时间 </td>
    </tr>
  <tr>
    <td align="center" class="taba"><label>
      <input type="checkbox" name="checkbox" id="checkbox" />
    </label></td>
    <td align="center" class="taba"><a href="#" target="_blank">晕，哈哈，你给了我个成人网站</a></td>
    <td align="center" class="taba"><a href="#">Ada</a></td>
    <td align="center" class="taba">2007-02-01 09:18:58</td>
    </tr>
  <tr>
    <td align="center" class="tabb"><label>
      <input type="checkbox" name="checkbox2" id="checkbox2" />
    </label></td>
    <td align="center" class="tabb"><a href="#" target="_blank">晕，哈哈，你给了我个成人网站</a></td>
    <td align="center" class="tabb"><a href="#">Ada</a></td>
    <td align="center" class="tabb">2007-02-01 09:18:58</td>
  </tr>
  <tr>
    <td align="center" class="taba"><label>
      <input type="checkbox" name="checkbox2" id="checkbox3" />
    </label></td>
    <td align="center" class="taba"><a href="#" target="_blank">晕，哈哈，你给了我个成人网站</a></td>
    <td align="center" class="taba"><a href="#">Ada</a></td>
    <td align="center" class="taba">2007-02-01 09:18:58</td>
  </tr>
  <tr>
    <td align="center" class="tabb"><label>
      <input type="checkbox" name="checkbox2" id="checkbox4" />
    </label></td>
    <td align="center" class="tabb"><a href="#" target="_blank">晕，哈哈，你给了我个成人网站</a></td>
    <td align="center" class="tabb"><a href="#">Ada</a></td>
    <td align="center" class="tabb">2007-02-01 09:18:58</td>
  </tr>
  <tr>
    <td align="center" class="tab" ><label>
      <input type="checkbox" name="checkbox2" id="checkbox5" />
    </label></td>
    <td align="center" class="tab"><a href="#" target="_blank">晕，哈哈，你给了我个成人网站</a></td>
    <td align="center" class="tab"><a href="#">Ada</a></td>
    <td align="center" class="tab">2007-02-01 09:18:58</td>
  </tr>
</table>
</div>
<div class="pagebox">
  <div class="left"><img src="../images/MessageManage/biao_01.gif" width="14" height="16" />将选中的短消息
    <label>
    <input type="reset" name="button2" id="button2" value="删除" />
    </label>
    <label>
    <input type="submit" name="button3" id="button3" value="导出" />
    </label>
  </div>
  <div class="right">上一页 下一页 转到第
       <input name="textarea" type="text" id="textarea" value="" size="3" />
    页
       <input type="submit" name="button4" id="button4" value="GO" />
    </div>
       <div class="clear"></div>
</div>
</div>
</body>
</html>
