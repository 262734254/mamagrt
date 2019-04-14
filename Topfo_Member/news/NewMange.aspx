<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewMange.aspx.cs" Inherits="news_NewMange" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href=" http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" /><link href=" http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" /><script type="text/javascript" src=" http://img2.topfo.com/member/js/trigger.js"></script><script type="text/javascript" src=" http://img2.topfo.com/member/js/trigger-1.js"></script><script language="JavaScript" type="text/javascript" src=" http://img2.topfo.com/member/js/navbar.js"></script><script type="text/javascript" src=" http://img2.topfo.com/member/js/tuofu-help.js"></script>
<script type ="text/javascript" language ="javascript" src="../js/jquery.js"></script>
<script language="javascript" type ="text/javascript">
        function load()
 {
   setTimeout("Having(1,0)",50);
 }
 function Having(shenhetype,pageindex)
 {

 var d = document.getElementById("<%=ddlInfoType.ClientID %>");//根据DropDownList的客户端ID获取该控件
 var daitype = d.options[d.selectedIndex].value;//获取DropDownList当前选中值
 var title=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
  Hand(shenhetype,pageindex,daitype,title);
  PageIndex(shenhetype,pageindex,daitype,title);
  Nopass();

 }
 var kong;
 function  Hand(shenhetype,pageindex,daitype,title)
{
kong=shenhetype;
document.getElementById("ctl00_ContentPlaceHolder1_NameID").value=shenhetype;
document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value=pageindex;

if(shenhetype==1)
{
   document.getElementById("spanb").style.display="block";
   document.getElementById("sh_btn_1").className="btn_on";
   document.getElementById("sh_btn_0").className="";
   document.getElementById("sh_btn_2").className="";
   document.getElementById("sh_btn_3").className="";
}
else if(shenhetype==0)
{
   document.getElementById("spanb").style.display="none";
   document.getElementById("sh_btn_1").className="";
   document.getElementById("sh_btn_0").className="btn_on";
   document.getElementById("sh_btn_2").className="";
   document.getElementById("sh_btn_3").className="";
}
else if(shenhetype==3)
{
   document.getElementById("spanb").style.display="none";
   document.getElementById("sh_btn_1").className="";
   document.getElementById("sh_btn_0").className="";
   document.getElementById("sh_btn_2").className="btn_on";
   document.getElementById("sh_btn_3").className="";
}else if(shenhetype==4)
{
   document.getElementById("spanb").style.display="none";
   document.getElementById("sh_btn_1").className="";
   document.getElementById("sh_btn_0").className="";
   document.getElementById("sh_btn_2").className="";
   document.getElementById("sh_btn_3").className="btn_on";
}

   $.ajax({type:"post",url:"News.ashx",data:"typeId="+daitype+"&username="+document.getElementById("ctl00_ContentPlaceHolder1_username").value+"&loanstitle="+title+"&status="+shenhetype+"&type=1&pageIndex="+pageindex,success:function(msg) 
   { 
   document.getElementById("ctl00_ContentPlaceHolder1_StatuID").innerHTML=msg;
   }
}); 
}
    
    //查询总数量
function Nopass()
{

 var d = document.getElementById("<%=ddlInfoType.ClientID %>");//根据DropDownList的客户端ID获取该控件
 var type = d.options[d.selectedIndex].value;//获取DropDownList当前选中值
 var title=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
 $.ajax({type:"post",url:"News.ashx",data:"typeId="+type+"&username="+document.getElementById("ctl00_ContentPlaceHolder1_username").value+"&loanstitle="+title+"&type=3",success:function(msg) 
   { 
      var a=msg.split('$');
      document.getElementById ("pass").innerHTML=a[1];
      document.getElementById ("statu").innerHTML=a[0];
      document.getElementById ("nopass").innerHTML=a[2];
      document.getElementById ("Over").innerHTML=a[3];
      
   }}); 
   
}

//绑定分页
function PageIndex(shenhetype,pageIndex,daitype,title)
{
   $.ajax({type:"post",url:"News.ashx",data:"typeId="+daitype+"&loanstitle="+title+"&username="+document.getElementById("ctl00_ContentPlaceHolder1_username").value+"&status="+shenhetype+"&type=2&pageIndex="+pageIndex,success:function(msg) 
   { 
   document.getElementById("ctl00_ContentPlaceHolder1_spanPage").innerHTML=msg;
   }}); 
}

//分页中选择查询
function onccxx(stat)
{
   var num=document.getElementById("pCount").value;
   var mm=document.getElementById("countss").innerText;

   if(num=="")
   {
     return confirm('请选择您要查询的页面数');
   }
   else{
   if(num==0)
   {
       try{
       return confirm('请正确选择您要查询的页面');
       }finally
       {
         document.getElementById("pCount").value="";
        }
   }
   else{ 
       if(num > parseInt(mm))
       {
            try{ return confirm('您输入的数字大于页面总数');
            }finally{
            document.getElementById("pCount").value="";
            }
       }else
       {
      var dd=parseInt(num-1);
          Having(stat,dd,stat);
       }
    }
     
   }
}   

//全选
function SelectAll()
{
    if(!document.getElementById("cbxSelect"))
        return;
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
		    if(elem[i].checked!=true)			
			    elem[i].click();
		}
    }
}
//反选
function ReSelect()
{
    if(!document.getElementById("cbxSelect"))
        return;
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
			    elem[i].click();
		}
    }
}
function search()
{
Having(kong,0);
}

//删除
function Del()
{

 if(confirm('确认要删除吗！'))
 {
 return true;
 }
 else{
 return false;
 }
}

function DelNav(id)
{
            var url="";
            var dd=0;
 $.ajax({type:"post",url:"DeleteNew.ashx",data:"Id="+id+"&type=1",success:function(msg) 
   { 
               var num=document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value;
            var str=document.getElementById("ctl00_ContentPlaceHolder1_NameID").value;
            if(num>0)
            {
             dd=parseInt(num);
             }
             else 
             {
             dd=0;
             }
             Having(str,dd);
   }}); 

           
             
    
}
function deleteall()
{
 var allid=document.getElementsByName("cbxSelect");
  var strd='';
  for(i=0;i<allid.length;i++)
  {
     if(allid[i].checked==true)
     {
     strd+=allid[i].value+",";
     }
  }
  if(strd=="")
  {
   alert('请选择要删除的项目');
  }
  else{
   var url="";
            var dd=0;
 $.ajax({type:"post",url:"DeleteNew.ashx",data:"str="+strd+"&type=2",success:function(msg) 
   { 
              var num=document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value;
            var str=document.getElementById("ctl00_ContentPlaceHolder1_NameID").value;
            if(num>0)
            {
             dd=parseInt(num);
             }
             else 
             {
             dd=0;
             }
             Having(str,dd);
   }}); 
 
 }
}
function updateloans(ithisid,idd)
{
  if(ithisid==0)
  {
      url="NewsTabShenHes.aspx?str="+idd;
      window.location.href = url;
  }
}
 </script>
    <input type="hidden" id="NameID" runat="server" />
         <input type="hidden" id="username" runat="server" />
<input type="hidden" id="txtPageID" runat="server" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">管理资讯</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
   <div class="search-1">需求筛选：<%--<input id="txtTitle" name="txtTitle" type="text" runat="server" value="aaa" />--%>
   <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
   <asp:DropDownList ID="ddlInfoType" runat="server">

   </asp:DropDownList>
<input type="button" id="ccc"  class="btn-002" value="查询" onclick="search();" />
</div>
        <h2>
        <ul>
         <li  class="btn_on"  id="sh_btn_1" onclick="Having(1,0);"><a href="#">审批通过（<span id="pass"></span>）</a></li><li  id="sh_btn_0" onclick="Having(0,0);"><a href="#" > 审核中（<span id="statu"></span>）</a></li><li  id="sh_btn_2" onclick="Having(3,0);"> <a href="#">未通过审核（<span id="nopass"></span>）</a></li><li  id="sh_btn_3" onclick="Having(4,0);"> <a href="#">已过期（<span id="Over"></span>）</a></li></ul>
        </h2>
     <div class="manage" id="sh_con_1">
     <div id="StatuID" runat="server">
 
    </div>
   <script language="javascript" type="text/javascript">load();Nopass();</script> 
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tfoot><tr>
    <td colspan="6">
      <span class="fl bianji">
<a href ="javascript:deleteall()" class="btn-002">删除选中</a>&nbsp;<span id="spanb">
</span>
      </span>
      <span class="fr" id="spanPage" runat="server">
       </span></td>
    </tr>
</tfoot>
</table>
</div>

    </div>
</asp:Content>

