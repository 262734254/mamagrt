<%@ Page Language="C#" MasterPageFile="~/Page20110314.master" AutoEventWireup="true"
    CodeFile="AajxStatus.aspx.cs" Inherits="Manage_AajxStatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../js/jquery.js"></script>

    <script language="javascript" type="text/javascript">
var kong;
//绑定内容
function Hand(stat,page,ec,InfoType,title)
{
kong=ec;
document.getElementById("ctl00_ContentPlaceHolder1_NameID").value=ec;
document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value=page;

if(ec==1)
{
   document.getElementById("spanb").style.display="block";
   document.getElementById("sh_btn_1").className="btn_on";
   document.getElementById("sh_btn_0").className="";
   document.getElementById("sh_btn_2").className="";
   document.getElementById("sh_btn_3").className="";
}
else if(ec==0)
{
   document.getElementById("spanb").style.display="none";
   document.getElementById("sh_btn_1").className="";
   document.getElementById("sh_btn_0").className="btn_on";
   document.getElementById("sh_btn_2").className="";
   document.getElementById("sh_btn_3").className="";
}
else if(ec==2)
{
   document.getElementById("spanb").style.display="none";
   document.getElementById("sh_btn_1").className="";
   document.getElementById("sh_btn_0").className="";
   document.getElementById("sh_btn_2").className="btn_on";
   document.getElementById("sh_btn_3").className="";
}else
{
   document.getElementById("spanb").style.display="none";
   document.getElementById("sh_btn_1").className="";
   document.getElementById("sh_btn_0").className="";
   document.getElementById("sh_btn_2").className="";
   document.getElementById("sh_btn_3").className="btn_on";
}

   $.ajax({type:"get",url:"Ajax.aspx",data:"InfoType="+InfoType+"&Title="+title+"&Status="+stat+"&Type=1&Page="+page,success:function(msg) 
   { 
//   prompt('',msg);
   document.getElementById("ctl00_ContentPlaceHolder1_StatuID").innerHTML=msg;
   }
}); 
}
//绑定分页
function PageIndex(stat,page,InfoType,title)
{
   $.ajax({type:"get",url:"Ajax.aspx",data:"InfoType="+InfoType+"&Title="+title+"&Status="+stat+"&Type=2&Page="+page,success:function(msg) 
   { 
   document.getElementById("ctl00_ContentPlaceHolder1_spanPage").innerHTML=msg;
   }}); 
}
//查询总数量
function Nopass()
{
var d = document.getElementById("<%=ddlInfoType.ClientID %>");//根据DropDownList的客户端ID获取该控件
 var type = d.options[d.selectedIndex].value;//获取DropDownList当前选中值
 var title=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
  $.ajax({type:"get",url:"Ajax.aspx",data:"InfoType="+type+"&Title="+title+"&Type=3",success:function(msg) 
   { 
      var a=msg.split('$');
      pass.innerHTML=a[1];
      statu.innerHTML=a[0];
      nopass.innerHTML=a[2];
      Over.innerHTML=a[3];
      
   }}); 
}

function Having(stat,page,cd)
{

 var d = document.getElementById("<%=ddlInfoType.ClientID %>");//根据DropDownList的客户端ID获取该控件
 var type = d.options[d.selectedIndex].value;//获取DropDownList当前选中值
 var title=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
   Hand(stat,page,cd,type,title);
   PageIndex(stat,page,type,title);
   Nopass();
}
//模糊查询
function tt()
{
    var c=kong;
    Having(c,0,c);
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
//定时器
function load()
{
   setTimeout("Having(1,0,1)",50);
}
//不同类型，修改跳转页面
function modifyNavigate(id,type)
{
    var url="";
    switch(type)
    {
        case "Capital":
            url = "/offer/ModifyCapital.aspx?id="+id+"&type="+type;
            break;
        case "Project":
            url = "./ModifyProject.aspx?id="+id+"&type="+type;
            break;
        case "Merchant":
            url = "./ModifyMerchant.aspx?id="+id+"&type="+type;
            break;
        case "Oppor":
            url = "http://www.topfo.com/member/Info/ModifyOppor.aspx?InfoID="+id+"&type="+type;
            break;
        default:
            break;
    }
    window.location.href = url;
}
//删除时，传值
function DelNav(id)
{
    var url="";
    url="AajxStatus.aspx?fID="+id;
    window.location.href = url;
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
//审核通过修改
function Modify()
{
   if(!confirm('您的资源已经展示在网上，如您要修改，请重新发布资源！'))
   {return false;}
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
//批量删除
function SumDel()
{
var b=kong;
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
		alert(str);
		if(str!="")
		{
		    if(confirm('确定删除吗?'))
		         Manage_AajxStatus.Del(str);
		}
		else
		{
		   alert("请选择所要删除的项");
		}
		Having(b,0,b);
}

    </script>

    <input type="hidden" id="NameID" runat="server" />
    <input type="hidden" id="txtPageID" runat="server" />
    <div class="member-right">
        <div class="publication">
            <h1>
                <span class="fl"><span class="f_14px strong f_cen">管理资源</span></span><span class="fr">
                <img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle" />
                    <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
            <div class="search-1">
                需求筛选：<%--<input id="txtTitle" name="txtTitle" type="text" runat="server" value="aaa" />--%>
                <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
                <asp:DropDownList ID="ddlInfoType" runat="server">
                </asp:DropDownList>
                <input type="button" id="ccc" class="btn-002" value="查询" onclick="tt();" />
            </div>
            <h2>
                <ul>
                    <li class="btn_on" id="sh_btn_1" onclick="Having(1,0,1);"><a href="#">审批通过（<span
                        id="pass"></span>）</a></li>
                    <li id="sh_btn_0" onclick="Having(0,0,0);"><a href="#">审核中（<span id="statu"></span>）</a></li>
                    <li id="sh_btn_2" onclick="Having(2,0,2);"><a href="#">未通过审核（<span id="nopass"></span>）</a></li>
                    <li id="sh_btn_3" onclick="Having(3,0,3);"><a href="#">已过期（<span id="Over"></span>）</a></li>
                </ul>
            </h2>
            <div class="manage" id="sh_con_1">
                <div id="StatuID" runat="server">
                </div>

                <script language="javascript" type="text/javascript">load();Nopass();</script>

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tfoot>
                        <tr>
                            <td colspan="6">
                                <span class="fl bianji">
                                    <%--<asp:Button runat="server" ID="btnDelete" OnClick="btnDelete_Click" OnClientClick="return SumDel();" CssClass="btn-002" Text="删除选中"/>--%>
                                    <input id="btnDelete" type="button" class="btn-002" value="删除选择" onclick="SumDel();" />
                                    <span id="spanb">
                                        <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" CssClass="btn-002"
                                            Text="刷新选中" />
                                        <asp:Button runat="server" ID="btnSetOverdue" OnClick="btnSetOverdue_Click" CssClass="btn-003"
                                            Text="放入已过期需求" />
                                    </span></span><span class="fr" id="spanPage" runat="server"></span>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="zhuyi">
                <h3>
                    <span class="fl" style="margin: 2px 10px 0 0">
                        <img src="http://img2.topfo.com/member/images/manage_23.jpg" /></span> <span class="fl">
                            注意事项</span></h3>
                <p>
                    · 您可以修改您发布的需求，但修改后的内容需要经过我们的审核才能出现在网上。
                    <br>
                    · 经常刷新您发布的需求，可以让需求尽量排在同类信息的前面！刷新功能为拓富通会员专享。1元钱体验拓富通会员服务 <a href="/Register/VIPMemberRegister.aspx"
                        target="_blank" class="publica-fbxq">申请拓富通</a>
                    <br>
                    · 您可以通过设置，指示系统将匹配的资源通过邮件或站内短信的形式发送给您！<a href="/helper/Notice.aspx" class="publica-fbxq">点此立即设置
                    </a>
                    <br>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
