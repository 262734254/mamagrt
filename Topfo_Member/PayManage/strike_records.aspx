<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="strike_records.aspx.cs" Inherits="PayManage_strike_records" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>

 <script language="javascript" type="text/javascript">
 function Hand(str,page,time,pay,name)
 {
     if(str==0)
     {
       document.getElementById("RecId").style.display="block";
       document.getElementById("OrderId").style.display="none";
       document.getElementById("RecT").className="btn_on";
       document.getElementById("OrderT").className="";
       document.getElementById("shanchu").style.display="none";
     }else if(str==1)
     {
        document.getElementById("RecId").style.display="none";
       document.getElementById("OrderId").style.display="block";
       document.getElementById("RecT").className="";
       document.getElementById("OrderT").className="btn_on";
       document.getElementById("shanchu").style.display="block";
     }
   $.ajax({type:"post",url:"AajxTab.ashx",data:"name="+name+"&Strike="+str+"&page="+page+"&Type=1&payType="+pay+"&BegTime="+time+"",success:function(msg) 
   { 
   document.getElementById("ctl00_ContentPlaceHolder1_StateId").innerHTML=msg;
   }});
 }
 
 function PageIndex(str,page,time,pay,name)
 {
    $.ajax({type:"post",url:"AajxTab.ashx",data:"name="+name+"&Strike="+str+"&page="+page+"&Type=2&payType="+pay+"&BegTime="+time+"",success:function(msg) 
   { 
   document.getElementById("ctl00_ContentPlaceHolder1_spanPage").innerHTML=msg;
   }});
 }
 
 function Having(str,page)
 {
  var name=document.getElementById("ctl00_ContentPlaceHolder1_LgName").value;
   var a = document.getElementById("<%=ddlTime.ClientID %>");//根据DropDownList的客户端ID获取该控件
   var time = a.options[a.selectedIndex].value;//获取DropDownList当前选中值
   var b = document.getElementById("<%=sType.ClientID %>");
   var pay = b.options[b.selectedIndex].value;
   Hand(str,page,time,pay,name);
   PageIndex(str,page,time,pay,name);
 }
 
 function load()
 {
    setTimeout("Having(1,0)",50);
 }
 
 function onccxx(str)
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
          Having(str,dd);
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
//删除时，传值
function DelNav(id)
{
 if(confirm('确认要删除吗！'))
 {
PayManage_strike_records.Del(id);
 }
 Having(1,0);
}

//批量删除
function SumDel()
{
var a = document.documentElement.getElementsByTagName("input");
		var str="";

    for (var i=0; i<a.length; i++) 
    {
	    if (a[i].type == "checkbox")
	    {
		    if(a[i].checked)
		    {
			    str+=a[i].value+",";
		    }
	    }
    }
    if(str!="")
    {
        if(confirm('确定删除吗?'))
            PayManage_strike_records.dele(str);
    }
    else
    {
       alert("请选择所要删除的项");
    }
		Having(1,0);
}
    </script>
<input type="hidden" runat="server" id="LgName" />
<input type="hidden" runat="server" id="StrID" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">充值管理</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank" class="publica-fbxq">需求发布规则</a></span></h1>
      <div class="zhuyi" id="OrderId" style="display:none">
     <h3><span class="fl" >重要提示：</span></h3>
    <p>
       您现在共有<span class="hong" runat="server" id="SpanOrder1"></span>条未完成的充值订单，总金额<span class="hong" runat="server" id="SpanOrder2"></span>元 
        <br> 
        请及时处理您的充值定单，超过10天仍未完成付款的订单将会被系统自动关闭！
    </p>
    </div>
    <div class="zhuyi" id="RecId">
     <h3><span class="fl" >重要提示：</span></h3>
    <p>
        您现在共有<span class="hong" runat="server" id="SpanRec1"></span>条充值记录，总金额 <span class="hong" runat="server" id="SpanRec2"></span> 元 
    </p>
    </div>
     <br />
   <div class="search-1">充值查询：
   <asp:DropDownList runat="server" ID="ddlTime">
   <asp:ListItem Value="-1">---全部---</asp:ListItem>
   <asp:ListItem Value="90">三个月以上</asp:ListItem>
   <asp:ListItem Value="60">最近三个月</asp:ListItem>
   <asp:ListItem Value="30">最近一个月</asp:ListItem>
   <asp:ListItem Value="7">最近一周内</asp:ListItem>
   </asp:DropDownList>
   <asp:DropDownList ID="sType" runat="server"></asp:DropDownList>
<asp:Button ID="btnSearch" runat="server" CssClass="btn-002"  Text="查 询" />
</div>
        <h2>
        <ul>
         <li class="btn_on"  id="OrderT" onclick="Having(1,0)">充值订单管理</li>
         <li   id="RecT" onclick="Having(0,0)">完成的充值</li>
         </ul>
        </h2>
     <div class="manage" id="sh_con_1">
     <div id="StateId" runat="server"></div>
     <script language="javascript" type="text/javascript">load();</script>
     
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
    <tfoot>
      <tr>
        <td colspan="7">
          <span class="fl bianji" id="shanchu" style="display:none">
         <%--<asp:Button ID="btnDelete" runat="server" CssClass="btn-002" Text="删除选中" OnClientClick="return SumDel();" OnClick="btnDelete_Click" /> --%>
         <input type="button" class="btn-002" value="删除选中" onclick="SumDel();" />
          </span>
          <span class="fr" runat="server" id="spanPage" >
           </span>
           </td>
        </tr>
    </tfoot>
    </table>    
<span class="fr">
      <img src="http://img2.topfo.com/member/images/biao_print.gif" /><a href="javascript:;" onclick="window.print()">打印该页</a>
       </span> 
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

