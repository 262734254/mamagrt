<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" 
    CodeFile="ServiesManage.aspx.cs" Inherits="Publish_Professional_ServiesManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../js/jquery.js"></script>

    <script language="javascript" type="text/javascript">
    var kong;
//定时器
 function load()
 {
    setTimeout("Having(1,0)",50);
 }
 
 function Having(auditID,page)//
 {

 var d = document.getElementById("<%=ddlInfoType.ClientID %>");//根据DropDownList的客户端ID获取该控件
 var type = d.options[d.selectedIndex].value;//获取DropDownList当前选中值
 var title=document.getElementById("<%=txtTitle.ClientID %>").value;

   Hand(auditID,page,type,title);
   PageIndex(auditID,page,type,title);
   Nopass();
 }
 //模糊查询
function tt()
{
    var c=kong;
    Having(c,0);
}
 function Hand(auditID,page,type,title)
 { 
 
 kong=auditID;
    document.getElementById("ctl00_ContentPlaceHolder1_statuId1").value=auditID;
    document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value=page;


    if(auditID==1)//审批通过
     {
       document.getElementById("spanb").style.display="block";
       document.getElementById("OrderT").className="btn_on";
       document.getElementById("RecT").className="";
       document.getElementById("Li1").className="";
       
     }else if(auditID==0)//审核中
     {
     document.getElementById("spanb").style.display="none";
       document.getElementById("OrderT").className="";
       document.getElementById("RecT").className="btn_on";
       document.getElementById("Li1").className="";
     }
     else if(auditID==2)//未通过审核
     {
     document.getElementById("spanb").style.display="none";
       document.getElementById("OrderT").className="";
       document.getElementById("RecT").className="";
       document.getElementById("Li1").className="btn_on";
     }
   $.ajax({type:"post",url:"AajxStr.aspx",data:"type="+type+"&title="+title+"&auditID="+auditID+"&index=1&page="+page+"",success:function(msg) 
   { 
   
   document.getElementById("ctl00_ContentPlaceHolder1_StatuID").innerHTML=msg;
   }});
 }
 function PageIndex(auditID,page,type,title)
 {
    $.ajax({type:"post",url:"AajxStr.aspx",data:"type="+type+"&title="+title+"&auditID="+auditID+"&index=2&page="+page+"",success:function(msg) 
   { 
   
   document.getElementById("spanPage").innerHTML=msg;
   }});
 }
 function onccxx(str)
{
   var num=document.getElementById("ctl00_ContentPlaceHolder1_pCount").value;
   var mm=document.getElementById("ctl00_ContentPlaceHolder1_countss").innerText;

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
         document.getElementById("ctl00_ContentPlaceHolder1_pCount").value="";
        }
   }
   else{ 
       if(num > parseInt(mm))
       {
            try{ return confirm('您输入的数字大于页面总数');
            }finally{
            document.getElementById("ctl00_ContentPlaceHolder1_pCount").value="";
            }
       }else
       {
      var dd=parseInt(num-1);
          Having(str,dd);
       }
    }
     
   }
}
        function checkall()//全选
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++){
                if(all[i].type == "checkbox"){
                   all[i].checked = true;
                }
            }
        }
        function checknull()//反选
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++){
                if(all[i].checked){
                   all[i].checked = false;
                }
                else{all[i].checked = true;}
            }
        }
        //查询总数量
function Nopass()
{
var d = document.getElementById("<%=ddlInfoType.ClientID %>");//根据DropDownList的客户端ID获取该控件
 var type = d.options[d.selectedIndex].value;//获取DropDownList当前选中值
 var title=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
  $.ajax({type:"post",url:"AajxStr.aspx",data:"type="+type+"&title="+title+"&index=3",success:function(msg) 
   { 
      var a=msg.split('$');
//alert(a[0]+":"+a[1]+":"+a[2]);
      pass.innerHTML=a[1];//审核通过
      statu.innerHTML=a[0]; //审核中
      nopass.innerHTML=a[2];//审核未通过
      
   }}); 
}
        //删除时，传值
        function DelNav(id)
        {
            var url="";
            var dd=0;
//            alert('123');
            Publish_Professional_ServiesManage.DeleteID(id);
//            alert('321');
            var str= document.getElementById("ctl00_ContentPlaceHolder1_statuId1").value;
            var num= document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value;
           
            if(num>0)
            {
             dd=parseInt(num-1);
             }
             else 
             {
             dd=0;
             }
             Having(str,dd);
            //url="ServiesManage.aspx?fID="+id;
            //window.location.href = url;
        }
        
        //不同类型，修改跳转页面
            function modifyNavigate(id,type)
            {
                var url="";
                switch(type)
                {
                    case 1:
                        url = "ModefiyProService.aspx?ProfessionalID="+id+"&type="+type;
                        break;
                    case 2:
                        url = "ModefiyProOrg.aspx?ProfessionalID="+id+"&type="+type;
                        break;
                    case 3:
                        url = "ModefiyProtalent.aspx?ProfessionalID="+id+"&type="+type;
                        break;
                    default:
                        break;
                }
                window.location.href = url;
            }
        function deleteAll()//删除选择的
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++)
            {
                if(all[i].checked)
                {
                    //Publish_Professional_ServiesManage.DeleteID(all[i].name);
                }
            }
           
            var str= document.getElementById("ctl00_ContentPlaceHolder1_statuId1").value;
            var num= document.getElementById("ctl00_ContentPlaceHolder1_txtPageID").value;
//            alert(num);
//            alert(str);
            if(num>0)
            {
             dd=parseInt(num-1);
             }
             else 
             {
             dd=0;
             }
             Having(str,dd);
        }
        function deleteAlloK() {
            var bool = confirm("删除后无法恢复!");
            if (bool == true)
            { deleteAll(); }
        }
    </script>

    <%--   </head>
    <form runat="server">--%>
    <input type="hidden" id="NameID" runat="server" />
    <input type="hidden" id="statuId1" runat="server" />
    <input type="hidden" id="txtPageID" runat="server" />
    <div class="member-right">
        <div class="publication">
            <h1>
                <span class="fl"><span class="f_14px strong f_cen">管理资源</span></span> <span class="fr">
                    <img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle" />
                    <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
            <div class="search-1">
                需求筛选：<%--<input id="txtTitle" name="txtTitle" type="text" runat="server" value="aaa" />--%>
                <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
                <asp:DropDownList ID="ddlInfoType" runat="server">
                    <asp:ListItem Value="All">查询全部</asp:ListItem>
                    <asp:ListItem Value="1">专业服务</asp:ListItem>
                    <asp:ListItem Value="2">专业机构</asp:ListItem>
                    <asp:ListItem Value="3">专业人才</asp:ListItem>
                </asp:DropDownList>
                <input type="button" id="ccc" class="btn-002" value="查询" onclick="tt();" />
                <%--<a href="PublishProOrg.aspx">机构</a> <a href="PublishProtalent.aspx">人才</a> <a href="PublishProfessional.aspx">
                    服务</a>--%>
            </div>
            <h2>
                <ul>
                    <li class="btn_on" id="OrderT" onclick="Having(1,0);"><a href="#">审核通过（<span id="pass"></span>）</a></li>
                    <li id="RecT" onclick="Having(0,0);"><a href="#">审核中（<span id="statu"></span>）</a></li>
                    <li id="Li1" onclick="Having(2,0);"><a href="#">未通过审核（<span id="nopass"></span>）</a></li>
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
                                    <button id="btnDelete" class="btn-002" onclick="deleteAlloK()">
                                        删除选中</button>
                                    <span id="spanb">
                                        <%--<asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" CssClass="btn-002"
                                            Text="刷新选中" />--%>
                                        <%--<asp:Button runat="server" ID="btnSetOverdue" OnClick="btnSetOverdue_Click" CssClass="btn-003"
                                    Text="放入已过期需求" />--%>
                                    </span></span><span class="fr" id="spanPage"></span>
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
                    <br />
                    · 经常刷新您发布的需求，可以让需求尽量排在同类信息的前面！刷新功能为拓富通会员专享。1元钱体验拓富通会员服务 <a href="/Register/VIPMemberRegister.aspx"
                        target="_blank" class="publica-fbxq">申请拓富通</a>
                    <br>
                    · 您可以通过设置，指示系统将匹配的资源通过邮件或站内短信的形式发送给您！<a href="/helper/Notice.aspx" class="publica-fbxq">点此立即设置
                    </a>
                    <br />
                </p>
            </div>
        </div>
    </div>
</asp:Content>

