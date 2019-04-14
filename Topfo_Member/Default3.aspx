<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

  <!DOCTYPE   HTML   PUBLIC   "-//W3C//DTD   HTML   4.01   Transitional//EN"   "http://www.w3.org/TR/html4/loose.dtd">   
  <HTML>   
  <HEAD>   
  <title>增删附件</title>   
  <meta   http-equiv="Content-Type"   content="text/html;   charset=gb2312">   
  </HEAD>   
  <body>   
  <script   language="javascript">   
  /*function   isindrop(str,drop)   
  {   
  for(i=0;i<drop.length;i++)   
  {   
  if(str==drop.options[i].text)   
  return(true);   
  }   
  return(false);   
  }*/   
  function   isindrop(str,drop)   
  {   
  for(i=0;i<drop.length;i++)   
  {   
  var   tmp=drop.options[i].text;   
  if(str.substring(str.lastIndexOf("\\")+1)==tmp.substring(tmp.lastIndexOf("\\")+1))   
  {   
  /*set   MyFileObject=Server.CreateObject("Scripting.FileSystemObject");   
  set   mfile=MyFileObject.GetFile(str);   
  set   mfile1=MyFileObject.GetFile(tmp);   
  if(mfile.size==mfile1.size)*/   
  return(true);   
  }   
  }   
  return(false);   
  }   
  function   emptyfile(fbr)   
  {   
  fbr.select();   
  document.execCommand('Delete');   
  }   
  function   madd(fbr)   
  {   
  if(isindrop(fbr.value,att))   
  {alert('您已经选择了这文件,请重新选择');   
  emptyfile(fbr);return;}   
  var   oOption=document.createElement('OPTION');   
  oOption.text=fbr.value;   
  if(oOption.text!='')   
  att.add(oOption);   
  att.selectedIndex=att.length-1;   
  emptyfile(fbr);   
  }   
  </script>   
  <table   width="120%"   border="1">   
  <tr>   
  <td   width="146">现有附件：</td>   
  <td><SELECT   id="att"   runat="server"></SELECT><INPUT   id="delatt"   type="button"   value="删除"   onclick="var   idx=att.selectedIndex;if(idx==-1)return;att.remove(idx);if(idx>0)   idx--;else   if(att.length==0)idx=-1;att.selectedIndex=idx;"></td>   
  </tr>   
  <tr>   
  <td   width="146">新增附件：</td>   
  <td><INPUT   id="filebr"   type="file">   <INPUT   id="addatt"   onclick="madd(filebr)"   type="button"   value="添加">   
  </td>   
  </tr>   
  </table>   
  <INPUT   id="rtn"   onclick="var   mtxt='';for(i=0;i<att.length;i++){if(att.options[i].text!='')mtxt+=','+att.options[i].text;}window.opener.document.all['txtatt'].value=mtxt.substring(1);window.close();"   
  type="button"   value="返回">   
  </body>   
  </HTML>   
