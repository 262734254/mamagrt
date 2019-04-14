<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Access.aspx.cs" Inherits="Access_Access" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../js/jquery.js" ></script>
<script language="javascript" type="text/javascript" >
//绑定内容
function Hand(InfoID,page)
{
   $.ajax({type:"post",url:"AccessTest.ashx",data:"InfoID="+InfoID+"&Type=1&Page="+page,success:function(msg) 
   {
   document.getElementById("ctl00_ContentPlaceHolder1_StatuID").innerHTML=msg;
   }
   }); 
}
//绑定分页
function PageIndex(InfoID,page)
{
   $.ajax({type:"post",url:"AccessTest.ashx",data:"InfoID="+InfoID+"&Type=2&Page="+page,success:function(msg) 
   { 
   document.getElementById("ctl00_ContentPlaceHolder1_spanPage").innerHTML=msg;
   }}); 
}

function Having(page)
{
var InfoID=document.getElementById("ctl00_ContentPlaceHolder1_LoginInfoId").value;
   Hand(InfoID,page);
   PageIndex(InfoID,page);
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
          Having(dd);
       }
    }
     
   }
}

window.onload=function()
{
   setTimeout("Having(0)",100);
}

</script>
<input runat="server" type="hidden" id="LoginInfoId" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">访问信息</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
<div class="manage" id="MessageID" runat="server">
    </div>
     <div class="manage" id="sh_con_1" runat="server">
     <div id="StatuID" runat="server">

    </div>
   
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tfoot><tr>
    <td >
    <span class="fl bianji">
    <a href="Attention.aspx" class="btn-003">返回上一步</a>
      </span>
      <span class="fr" id="spanPage" runat="server">
       </span></td>
    </tr>
</tfoot>
</table>

    </div>

    <div class="zhuyi">
     <h3><span class="fl" style="margin:2px 10px 0 0"><img src="http://img2.topfo.com/member/images/manage_23.jpg"  /></span> <span class="fl" >注意事项</span></h3>
   <p>
                · 您可以修改您发布的需求，但修改后的内容需要经过我们的审核才能出现在网上。
                <br>
                · 经常刷新您发布的需求，可以让需求尽量排在同类信息的前面！刷新功能为拓富通会员专享。1元钱体验拓富通会员服务 <a href="/Register/VIPMemberRegister.aspx" target="_blank" class="publica-fbxq">申请拓富通</a>
                <br>
                · 您可以通过设置，指示系统将匹配的资源通过邮件或站内短信的形式发送给您！<a href="/helper/Notice.aspx" class="publica-fbxq">点此立即设置 </a>
                <br>

            </p>
    </div>
      </div>
</div>
</asp:Content>

