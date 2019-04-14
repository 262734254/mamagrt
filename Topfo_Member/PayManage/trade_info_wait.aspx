<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="trade_info_wait.aspx.cs" Inherits="PayManage_trade_info_wait" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript">
 function Hand(str,page,time,type,name)
 {
     if(str==0)
     {
       document.getElementById("ShopId").className="btn_on";
       document.getElementById("ConsumeId").className="";
       document.getElementById("neirong").style.display="block";
     }else if(str==1)
     {
       document.getElementById("ShopId").className="";
       document.getElementById("ConsumeId").className="btn_on";
       document.getElementById("neirong").style.display="none";
     }
   $.ajax({type:"get",url:"trade_info_wait_Ajax.aspx",data:"name="+name+"&Strike="+str+"&page="+page+"&Type=1&InfoType="+type+"&BegTime="+time+"",success:function(msg) 
   { 
   document.getElementById("StateId").innerHTML=msg;
   }});
 }
 
 function PageIndex(str,page,time,type,name)
 {
    $.ajax({type:"get",url:"trade_info_wait_Ajax.aspx",data:"name="+name+"&Strike="+str+"&page="+page+"&Type=2&InfoType="+type+"&BegTime="+time+"",success:function(msg) 
   { 
   document.getElementById("spanPage").innerHTML=msg;
   }});
 }
 
 function Having(str,page)
 {
   var name=document.getElementById("ctl00_ContentPlaceHolder1_LgName").value;
   var a = document.getElementById("<%=ddldiff.ClientID %>");//根据DropDownList的客户端ID获取该控件
   var time = a.options[a.selectedIndex].value;//获取DropDownList当前选中值
   var b = document.getElementById("<%=ddltype.ClientID %>");
   var type = b.options[b.selectedIndex].value;
   Hand(str,page,time,type,name);
   PageIndex(str,page,time,type,name);
 }
 
function load()
 {
    setTimeout("Having(0,0)",50);
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
	//获取批量购买的id号
	function GetSelectValue()
	{
	    var a=document.documentElement.getElementsByTagName("input");
	    var str="";
	    
	    for( var i=0;i<a.length;i++)
	    {
	        if(a[i].type=="checkbox")
	        {
	            if(a[i].checked)
	            {
	                str+=a[i].value+",";
	            }
	        }
	    }
	    
	    if(str!="")
	    {
	        window.open("http://pay.topfo.com/account/Lotaccountpay.aspx?order_no="+str,"_blank");
	    }
	    else 
	    {
	        alert("请选择资源！");
	    }
	}
</script>
<input type="hidden" runat="server" id="LgName" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">资源交易管理</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank" class="publica-fbxq">需求发布规则</a></span></h1>
      <div class="zhuyi" id="OrderId">
     <h3><span class="fl" >温馨提示：</span></h3>
    <p>
       ·我们为您开通了多种支付渠道，无论金额大小皆可轻松支付！
        <br> 
       ·如果您的账户余额充足，使用账户余额支付是最快捷的支付方式。您现在的账户余额为<span class="hong"><asp:Literal runat="server" ID="lblUserPoint"></asp:Literal></span>元。 点此&gt;&gt;<a href="account_cz.aspx" class="publica-fbxq">立即充值</a>
        <br>
       ·为降低您的交易风险，建议您优先选择<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml"
                    target="_blank" class="publica-fbxq">拓富通会员</a>发布的资源！
    </p>
    </div>
    <br />
   <div class="search-1">需求筛选：
   <select id="ddldiff" name="select" runat="server">
    <option value="all" selected="selected">全部</option>
    <option value="90">三个月以上</option>
    <option value="30">最近一月</option>
    <option value="3">最近三天</option>
    <option value="7">最近一周</option>
    <option value="14">最近两周</option>
   </select>
   <label>
   </label>
   <select id="ddltype" name="select2"  runat="server">
    <option value="all" selected="selected">全部</option>
    <option value="Merchant">招商资源</option>
    <option value="Capital">投资资源</option>
    <option value="Project">融资资源</option>
   </select>
       &nbsp;
   <input type="button" class="btn-002" value="查询" onclick="Having(0,0);" />
   </div>
        <h2>
        <ul>
         <li class="btn_on" id="ShopId" onclick="Having(0,0);" style="cursor: pointer">我的购物车</li>
         <li style="cursor: pointer" id="ConsumeId" onclick="Having(1,0);">已付款交易</li>
         </ul>
        </h2>
     <div class="manage" id="sh_con_1">
     <div id="StateId"></div>
     
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tfoot>
          <tr>
            <td colspan="6">
              <span class="fl bianji">
              <div id="neirong">
             <input type="button" class="btn-002" title="批量购买所选择的商品" value="批量购买" onclick="GetSelectValue()" />
             <asp:Button ID="btnRefresh" runat="server" CssClass="btn-002" Text="删除所选" OnClick="btnRefresh_Click" />
             </div>
             <input type="button" class="btn-003" value="继续寻找资源>" onclick="window.open('http://search.topfo.com/SearchAllResult.aspx')" />
              </span>
              <span class="fr" id="spanPage">
               </span></td>
            </tr>
        </tfoot>
     </table>
        <span class="fr">
      <img src="http://img2.topfo.com/member/images/biao_print.gif" /><a href="javascript:;" class="publica-fbxq" onclick="window.print()">打印该页</a>
       </span>    
    </div>
<script language="javascript" type="text/javascript">load();</script>
    
   
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

