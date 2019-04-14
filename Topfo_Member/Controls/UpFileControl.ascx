<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpFileControl.ascx.cs"
    Inherits="Controls_UpFileControl" %>

<script language="javascript" src="/js/xhttp.js"></script>

<script>   
  function   locking(){
 
  if(parseInt(document.getElementById("txtCount").value)>2)
  {
    alert("只能上传三个附件");
    return;
  }
  document.all.ly.style.display="block";   
  document.all.ly.style.width=document.body.clientWidth;   
  document.all.ly.style.height=document.body.clientHeight;   
  document.all.Layer2.style.display='block';   
  document.all.Layer2.style.left="";
  document.all.Layer2.style.top="";
  //expression((document.body.offsetWidth-540)/2); top: expression((document.body.offsetHeight-170)/2);
  }   
  function   Lock_CheckForm(){   
     document.all.ly.style.display='none';document.all.Layer2.style.display='none'; 
     return   false;   
  }
  function DeleteID(obj)
  {
    if(confirm("确定删除此附件吗?"))
        Controls_UpFileControl.DeleteRes(obj,backres);
  }
  function backres(res)
  { 
    init();
  }
function init()
{
    var a=<%=InfoID %>;
    AjaxBack('/Controls/InfoResourceList.aspx?InfoID='+a);
}
</script>

<script language="javascript">init()</script>

<div class="fujian">
    <ul>
        <li>
            <img onclick="locking();" style="cursor: hand" src="/images/fujian.jpg">&nbsp;</li><li
                class="liheigh">您可以上传项目的商业计划书、审批文件以及资产负债表等文件。 </li>
    </ul>
</div>
<div id="ly" style="position: absolute; top: 0px; filter: alpha(opacity=60); background-color: #777;
    z-index: 2; left: 0px; display: none;">
</div>
<div id="Layer2" align="left" style="position: absolute; z-index: 3; width: 530px;
    height: 164px; left: background-color: #fff; display: none;" valign="center">
    <iframe src="/Publish/UpFile.aspx?InfoID=<%=InfoID %>&InfoType=<%=InfoType %>" style="width: 530px;
        height: 165px; left: 0; margin-left: 0" scrolling="no" frameborder="0"></iframe>
</div>
<br />
<div id="divshopcarlist">
</div>
