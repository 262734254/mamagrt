<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ad_buylist.aspx.cs" Inherits="PayManage_Ad_buylist" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript">
function State(name,page,time,Info)
{

   $.ajax({type:"get",url:"AjaxBuy.ashx",data:"name="+name+"&Type=0&page="+page+"&time="+time+"&Info="+Info+"",success:function(msg) 
   { 
   document.getElementById("StateId").innerHTML=msg;
   }});
}

function PageIndex(name,page,time,Info)
{

$.ajax({type:"get",url:"AjaxBuy.ashx",data:"name="+name+"&Type=1&page="+page+"&time="+time+"&Info="+Info+"",success:function(msg) 
   { 
   document.getElementById("spanPage").innerHTML=msg;
   }});
}
function Having(page)
{
   var name=document.getElementById("ctl00_ContentPlaceHolder1_LgName").value;
   var a = document.getElementById("<%=ddldiff.ClientID %>");//根据DropDownList的客户端ID获取该控件
   var time = a.options[a.selectedIndex].value;//获取DropDownList当前选中值
   var b = document.getElementById("<%=ddltype.ClientID %>");//根据DropDownList的客户端ID获取该控件
   var Info = b.options[b.selectedIndex].value;//获取DropDownList当前选中值
   State(name,page,time,Info);
   PageIndex(name,page,time,Info);
}
window.onload=function()
{
   setTimeout("Having(0)",1000);
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
          Having(dd);
       }
    }
     
   }
}
</script>
<input type="hidden" runat="server" id="LgName" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">购买记录管理</span></span><span class="fr pb-mg01"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="http://www.topfo.com/help/resourceswap.shtml" target="_blank" class="publica-fbxq">完全交易教程</a></span></h1>

        <div class="jl-wxts">
         <h3><img src="http://img2.topfo.com/member/img/icon_tishi.gif" align="absmiddle" /> 温馨提示：</h3>
         <p>我们为您开通了多种支付渠道，无论金额大小皆可轻松支付！<br />
如果您的账户余额充足，使用账户余额支付是最快捷的支付方式。您现在的账户余额为2106元。 <a href="account_cz.aspx" class=" lan1">点此>>立即充值</a><br />
为降低您的交易风险，建议您优先选择<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml"
                    target="_blank" class="lan1">拓富通会员</a>发布的资源！</p>

        </div>
        <div class="manage" id="sh_con_1">
        <div class="shenhe">
<ul>

<li><span class=" lanl">需求筛选：</span>
<select id="ddldiff"  runat="server">
            <option value="all" selected="selected">全部</option>
             <option value="3">最近三天</option>
            <option value="7">最近一周</option>
            <option value="30">最近一月</option>
            <option value="90">三个月以内</option>
            <option value="91">三个月以上</option>
        </select> 
        <select id="ddltype"  runat="server">
            <option value="all" selected="selected">全部</option>
            <option value="Merchant">招商资源</option>
            <option value="Capital">投资资源</option>
            <option value="Project">融资资源</option>
        </select>  <input name="" onclick="Having(0)" type="button" value="查 询" class="btn-002"  /> 
</li>

</ul>
</div>
<div id="StateId">
</div>
<table  width="100%" border="0" cellspacing="0" cellpadding="0">
     <tfoot>
  <tr>
    <td colspan="6" >
      <span class="fl bianji">
<input name="" type="button" onclick="window.open('http://search.topfo.com/SearchAllResult.aspx')" value="继续寻找资源" class="btn-003"  /> <%--<a href="#" class=" lan1">打印该页</a> --%>
     </span>
      <span class="fr" id="spanPage"> </span></td>
    </tr>
</tfoot>
</table>
<span class="fr">
      <img src="http://img2.topfo.com/member/images/biao_print.gif" /><a href="javascript:;" class="lan1" onclick="window.print()">打印该页</a>
       </span> 
    </div>
<div class="zhuyi" >
     <h3 style=" margin-bottom:10px"><img src="http://img2.topfo.com/member/img/gif-0290.gif" align="absmiddle" /> 帮助</h3>

      <ul style="margin:0 0 20px 20px">
       <li >· 如果您提交了订单，点击我的购物车可以查看订单的明细情况；</li>
         <li>· 相关资源是指系统根据您选择的资源为您推荐的类似资源</li>
       
      </ul>

    </div>
     <p class="f_14px f_black" style="margin-top:10px">您还可以联系我们专业的线下运作团队帮您解决招商问题，<a href="http://www.topfo.com/Aboutus/ServiceNet/MerchantService.shtml" target="_blank"class=" lan1">了解一下专业服务</a></p>
    </div>
    
    
      </div>
</asp:Content>

